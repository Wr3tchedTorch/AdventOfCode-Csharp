namespace TreeHouse;

public class TreeHouse
{
    private string[] inputLines { get; set; }
    public TreeHouse(string filePath)
    {
        string input = new StreamReader(filePath).ReadToEnd();
        inputLines = input.Split("\n");
    }

    public int GetNumberOfVisibleTrees()
    {
        int rowsLength = inputLines.Length;
        int columnsLength = inputLines[0].Length;

        int total = 2 * (rowsLength + columnsLength) - 4;
        for (int row = 1; row < rowsLength - 1; row++)
        {
            for (int col = 1; col < columnsLength - 1; col++)
            {
                int treeHeight = GetTreeHeight(row, col);
                if (IsVisible(treeHeight, row, col)) total++;
            }
        }
        return total;
    }

    private bool IsVisible(int treeHeight, int row, int col)
    {
        int left = col - 1, right = col + 1, top = row - 1, down = row + 1;
        while (true)
        {
            bool CanSeeThroughLeft = CanSeeThroughTree(treeHeight, row, left),
            CanSeeThroughRight = CanSeeThroughTree(treeHeight, row, right),
            CanSeeThroughTop = CanSeeThroughTree(treeHeight, top, col),
            CanSeeThroughDown = CanSeeThroughTree(treeHeight, down, col);

            if (CanSeeThroughLeft) left--;
            if (left < 0) return true;

            if (CanSeeThroughRight) right++;
            if (right > inputLines[0].Length - 1) return true;

            if (CanSeeThroughTop) top--;
            if (top < 0) return true;

            if (CanSeeThroughDown) down++;
            if (down > inputLines.Length - 1) return true;

            if (!CanSeeThroughLeft && !CanSeeThroughRight && !CanSeeThroughTop && !CanSeeThroughDown) return false;
        }
    }

    private int GetTreeHeight(int row, int col) => (int)char.GetNumericValue(inputLines[row].ToCharArray()[col]);

    private bool CanSeeThroughTree(int treeHeight, int row, int col)
    {
        int otherTreeHeight = GetTreeHeight(row, col);
        if (treeHeight > otherTreeHeight) return true;

        return false;
    }
}
