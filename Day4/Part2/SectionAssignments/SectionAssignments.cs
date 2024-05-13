namespace SectionAssignments;

public class SectionAssignments
{
    string[] assignmentPairs;

    class Range()
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public Range(int min, int max) : this()
        {
            Min = min;
            Max = max;
        }
    }

    public SectionAssignments(string filePath)
    {
        assignmentPairs = new StreamReader(filePath).ReadToEnd().Replace("\r", "").Split("\n");
    }

    public int GetOverlappingPairsCount(bool onlyFullyContained = false)
    {
        int count = 0;

        foreach (string pair in assignmentPairs)
        {
            string assignmentOne = pair.Split(",")[0];
            string assignmentTwo = pair.Split(",")[1];

            if ((onlyFullyContained && CheckAssignmentsOverlaps(assignmentOne, assignmentTwo, true)) ||
                (!onlyFullyContained && CheckAssignmentsOverlaps(assignmentOne, assignmentTwo)))
            {
                count++;
            }
        }

        return count;
    }

    private bool CheckAssignmentsOverlaps(string assignmentOne, string assignmentTwo, bool fullyOverlaps = false)
    {
        Range assignmentOneValues = new Range(int.Parse(assignmentOne.Split("-")[0]), int.Parse(assignmentOne.Split("-")[1]));
        Range assignmentTwoValues = new Range(int.Parse(assignmentTwo.Split("-")[0]), int.Parse(assignmentTwo.Split("-")[1]));

        if (fullyOverlaps)
        {
            bool assignmentOneContainsTwo = (assignmentOneValues.Min <= assignmentTwoValues.Min && assignmentOneValues.Max >= assignmentTwoValues.Max);
            bool assignmentTwoContainsOne = (assignmentTwoValues.Min <= assignmentOneValues.Min && assignmentTwoValues.Max >= assignmentOneValues.Max);

            return assignmentOneContainsTwo || assignmentTwoContainsOne;
        }

        bool overlaps = (assignmentOneValues.Min <= assignmentTwoValues.Min && assignmentOneValues.Max >= assignmentTwoValues.Min) ||
                        (assignmentTwoValues.Min <= assignmentOneValues.Min && assignmentTwoValues.Max >= assignmentOneValues.Min);

        return overlaps;
    }
}
