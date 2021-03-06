from nltk.tokenize import word_tokenize, sent_tokenize
from nltk.tag import *
from nltk.corpus import wordnet as wn
from nltk.wsd import lesk
from munkres import Munkres, make_cost_matrix, DISALLOWED
import json
import sys

VERBS = 0
NOUNS = 1
SINGULARS = 2
No_POS_GROUPS = 3


class Word:
    def __init__(self, word):
        self.word = str(word)
        self.partOfSpeech = pos_tag(word_tokenize(self.word))[0][1]
        self.wordSense = ""

class Semantics:
    def __init__(self):
        self.sentences = []
        self.tokenizedSentences = []#a list containing sentences which are stored as a list of objects of type Word
        self.comparablePartsOfSpeech = []#list containing parts of speech that can be used in the comparison (NOUNS, VERBS, SINGULARS). Hierarchy:
                                                                                                                                        #semantics[sentence[[verbs],[nouns],[singulars]]]
    def populate(self):
        pass

    def tokenize_sentences(self):
        for sentence in self.sentences:
            tokenizedSentence = word_tokenize(sentence)
            tokensIntoObjects = []
            for word in tokenizedSentence:
                tokensIntoObjects.append(Word(word))
            self.tokenizedSentences.append(tokensIntoObjects)

    '''this function categorizes each word based on their part of speech and whether or not the word has a comparable set of synonyms
       If yes, then based on the part of speech of that word it is put into a corresponding list. If not it is put into "singulars".
       Those lists are then appended to a "putTogether" list which represents the semantics of a given sentence. That sentence is then pushed
       to the list that contains all sentences represented in such hierarchy. semantics[sentence[[verbs],[nouns],[singulars]]] '''
    def populate_comparable_pos(self):
        for index, sentence in enumerate(self.tokenizedSentences):

            verbs = []
            nouns = []
            singulars = []
            putTogether = []

            for word in sentence:

                if word.partOfSpeech[0] != '.':

                    if word.partOfSpeech[0] == 'V' and word.partOfSpeech[1] == 'B':

                        self.assign_word_senses(word, VERBS, index)

                        if word.wordSense: #if the word sense was assigned append to verbs
                            verbs.append(word)
                        else: #else append to singulars
                            singulars.append(word)

                    elif word.partOfSpeech[0] == 'N' and word.partOfSpeech[1] == 'N':

                        self.assign_word_senses(word, NOUNS, index)

                        if word.wordSense: #if the word sense was assigned append to verbs
                            nouns.append(word)
                        else: #else append to singulars
                            singulars.append(word)

                    elif word.partOfSpeech[0] == 'C' and word.partOfSpeech[1] == 'D': #numbers are also appended to singulars
                        singulars.append(word)

            putTogether.append(verbs)
            putTogether.append(nouns)
            putTogether.append(singulars)

            self.comparablePartsOfSpeech.append(putTogether)

    def assign_word_senses(self, word, partOfSpeech, sentenceIndex):

        if partOfSpeech == VERBS:
            wordSense = wn.synsets(word.word, pos=wn.VERB)
            if wordSense:
                word.wordSense = lesk(self.sentences[sentenceIndex], word.word, 'v')

        elif partOfSpeech == NOUNS:
            wordSense = wn.synsets(word.word, pos=wn.NOUN)
            if wordSense:
                word.wordSense = lesk(self.sentences[sentenceIndex], word.word, 'n')


class Examination(Semantics):

    def __init__(self, filename):
        Semantics.__init__(self)
        self.question = ""
        self.populate(filename)

    #open the question file here:
    def populate(self, filename):
        try:
            with open(filename) as examinationFile:
                text = json.load(examinationFile)

        except IOError:
            print ("Examination file does not exist!")
            return

        #fetches the Question from the JSON file and puts into a Text BLob
        self.question = text["question"]
        #iterates through all critria entries in the JSON and puts each sentence as a Word List into a list (2D)
        for _criteria in text["criteria"]:
            self.sentences.append(_criteria["fact"])

        examinationFile.close()

class Answer(Semantics):

    def __init__(self, filename):
        Semantics.__init__(self)
        self.populate(filename)

    def populate(self, filename):
        try: #deserilise the text file
            with open(filename, 'r') as asnwerFile:
                data = asnwerFile.read()

        except IOError:
            print ("Answer file does not exist!")
            return

        asnwerFile.close()
        #split the string into sentences and store in the list
        for line in sent_tokenize(data):
            self.sentences.append(line)

def return_relationship_matrix(sentence1, sentence2, posGroup):

    relationshipMatrix = []

    if posGroup == NOUNS or posGroup == VERBS:

        for word_A in sentence1:
            relationshipMatrixNode = []

            for word_B in sentence2:
                similarity = wn.path_similarity(word_A.wordSense, word_B.wordSense)
                relationshipMatrixNode.append(similarity)

            relationshipMatrix.append(relationshipMatrixNode)

    elif posGroup == SINGULARS:

        for word_A in sentence1:
            relationshipMatrixNode = []

            for word_B in sentence2:
                if word_A.word.lower() == word_B.word.lower():
                    relationshipMatrixNode.append(1)

                else:
                    relationshipMatrixNode.append(0)

            relationshipMatrix.append(relationshipMatrixNode)

    return relationshipMatrix

def return_munkres_result(matrix):

    cost_matrix = make_cost_matrix(matrix, lambda cost: (sys.maxsize - cost) if (cost != DISALLOWED) else DISALLOWED)
    m = Munkres()
    indexes = m.compute(cost_matrix)
    bestMatches = []

    for row, column in indexes:
        value = matrix[row][column]
        bestMatches.append(value)

    return bestMatches

def return_semantic_similarity_matrix (answer, examination):
    matchMatrix = []

    for sentenceIndex, sentence in enumerate(answer.comparablePartsOfSpeech):

        for criteriaIndex, criteria in enumerate(examination.comparablePartsOfSpeech):

            numberOfCriteriaTokens = 0
            sumOfResults = 0.0

            for i in range(No_POS_GROUPS):

                if criteria[i]: #proceeds if the criteria nouns/verbs/singulars list is not empty
                    numberOfCriteriaTokens += len(criteria[i])

                    if sentence[i]: #proceeds if the sentence inouns/verbs/singulars list is not empty
                        matrix = return_relationship_matrix(criteria[i], sentence[i], i)
                        sumOfResults += sum(return_munkres_result(matrix))

            semanticSimilarity = sumOfResults/numberOfCriteriaTokens

            if semanticSimilarity > 0.5:
                matchMatrix.append([sentenceIndex, criteriaIndex])

    return matchMatrix

if __name__ == '__main__':

    #file setup
    examFile = sys.argv[1]
    answerFile = sys.argv[2]

    #instantiating objects to compare
    examination = Examination(examFile)
    answer = Answer(answerFile)

    #preparing objects to compare
    examination.tokenize_sentences()
    examination.populate_comparable_pos()
    answer.tokenize_sentences()
    answer.populate_comparable_pos()

    print ("<s>") #this line marks the beginning of the sentences part of the results
    #returning sentences for the Frontend
    for sentence in answer.sentences:
        print (sentence)
    print ("<!s>") #this line marks the end of the sentences part of the results

    print("<m>") #this line marks the beginning of the sentences part of the results
    # calculating semantic similarity, and returning for the Frontend
    similarityMatrix = return_semantic_similarity_matrix(answer, examination)
    for match in similarityMatrix:
        print('{},{}'.format(match[0], match[1]))
    print("<!m>") #this line marks the end of the sentences part of the results
