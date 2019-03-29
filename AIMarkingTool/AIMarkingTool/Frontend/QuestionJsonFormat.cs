using System.Collections.Generic;

namespace AIMarkingTool
{
    public class Criteria
    {
        public string fact { get; set; }
        public int marksAvailable { get; set; }
    }

    public class Examination
    {
        public string question { get; set; }
        public List<Criteria> criteria = new List<Criteria>();
        public int overallMarksAvailable { get; set; }
    }
}
