using System.Collections.Generic;

namespace AIMarkingTool
{
    public class Sentence
    {
        public string text { get; set; }
        public bool matched { get; set; }
        public List<int> matchedCriteriaIndex = new List<int>();
    }
}
