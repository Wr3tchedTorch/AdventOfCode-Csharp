namespace SectionAssignments;

public class SectionAssignments
{
    string[] assignmentPairs;
    public SectionAssignments(string filePath)
    {
        assignmentPairs = new StreamReader(filePath).ReadToEnd().Replace("\r", "").Split("\n");
    }

    public int GetOverlappingPairsCount() {
        throw new NotImplementedException();
    }
    
    public int GetFullyOverlappingPairsCount()
    {   
        int count = 0;

        foreach (string pair in assignmentPairs)
        {
            string assignmentOne = pair.Split(",")[0];
            string assignmentTwo = pair.Split(",")[1];

            if (CheckAssignmentsFullyOverlaps(assignmentOne, assignmentTwo)) count++;
        }

        return count;
    }

    private bool CheckAssignmentsFullyOverlaps(string assignmentOne, string assignmentTwo)
    {
        int assignmentOneMin = int.Parse(assignmentOne.Split("-")[0]);
        int assignmentOneMax = int.Parse(assignmentOne.Split("-")[1]);
        int assignmentTwoMin = int.Parse(assignmentTwo.Split("-")[0]);
        int assignmentTwoMax = int.Parse(assignmentTwo.Split("-")[1]);

        bool assignmentOneContainsTwo = (assignmentOneMin <= assignmentTwoMin && assignmentOneMax >= assignmentTwoMax);
        bool assignmentTwoContainsOne = (assignmentTwoMin <= assignmentOneMin && assignmentTwoMax >= assignmentOneMax);

        return assignmentOneContainsTwo || assignmentTwoContainsOne;
    }
    
    private bool CheckAssignmentsOverlaps(string assignmentOne, string assignmentTwo) {
        throw new NotImplementedException();
    }
}
