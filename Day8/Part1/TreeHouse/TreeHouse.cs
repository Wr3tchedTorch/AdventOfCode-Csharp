namespace TreeHouse;

public class TreeHouse
{
    private string[] inputLines { get; set; }
    // private int[,] treeMap { get; set; }
    public TreeHouse(string filePath)
    {
        string input = new StreamReader(filePath).ReadToEnd();
        inputLines = input.Split("\n");
    }

    public int GetNumberOfVisibleTrees()
    {
        int rowsLength = inputLines.Length - 1;
        int columnsLength = inputLines[0].Length - 1;

        int total = (rowsLength * 2) + ((columnsLength * 2) - 2);
        for (int row = 1; row < rowsLength - 1; row++)
        {
            for (int col = 1; col < columnsLength - 1; col++)
            {
                int treeHeight = (int)char.GetNumericValue(inputLines[row].ToCharArray()[col]);
                if (IsVisible(treeHeight, row, col)) total++;
            }
        }
        return total;
    }

    private bool IsVisible(int treeHeight, int targetRow, int targetCol)
    {
        for (int col = 0; col < inputLines[targetRow].Length-1; col++)
        {
            int otherTreeHeight = (int)char.GetNumericValue(inputLines[targetRow].ToCharArray()[col]);
            if (treeHeight > otherTreeHeight) return true;
        }
        for (int row = 0; row < inputLines[row].Length-1; row++)
        {
            int otherTreeHeight = (int)char.GetNumericValue(inputLines[row].ToCharArray()[targetCol]);
            if (treeHeight > otherTreeHeight) return true;
        }

        return false;
    }
}
