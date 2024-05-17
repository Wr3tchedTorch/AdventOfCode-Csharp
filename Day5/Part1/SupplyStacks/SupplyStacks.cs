namespace SupplyStacks;
using System.Text.RegularExpressions;

public class SupplyStacks
{
    Dictionary<int, Stack<string>> stacksMap = new Dictionary<int, Stack<string>>();
    List<int>[] steps = new List<int>[3];
    public SupplyStacks(string filePath)
    {
        string input = new StreamReader(filePath).ReadToEnd().Replace("\r", "");

        ParseInstructions("move", input, 0);
        ParseInstructions("from", input, 1);
        ParseInstructions("to", input, 2);

        ParseStacksMap(input);
    }

    private void ParseInstructions(string instructionName, string input, int index)
    {
        List<int> valuesList = new List<int>();
        foreach (Match match in Regex.Matches(input, $@"(?<={instructionName}\s)\d+")) valuesList.Add(int.Parse(match.Value));

        steps[index] = valuesList;
    }

    private void ParseStacksMap(string input)
    {
        string cratesInput = input.Split("\n\n")[0];
        string cratesInputWithoutNumbers = Regex.Replace(cratesInput, @"[0-9]", " ");

        string[] cratesStack = Regex.Replace(cratesInputWithoutNumbers, @"\n\s+$", "").Split("\n");
        int stacksCount = Regex.Matches(cratesInput, @"[0-9]").Count();

        SetStacksMap(stacksCount, cratesStack);
    }

    private void SetStacksMap(int stacksCount, string[] cratesStack)
    {
        for (int i = 1, offset = 0; i <= stacksCount; i++)
        {
            Stack<string> cratesInThisColumn = new Stack<string>();

            for (int j = cratesStack.Length - 1; j >= 0; j--)
            {
                string stack = cratesStack[j];
                string crate = stack.Substring(offset * 3 + offset, 3).Trim();

                if (string.IsNullOrEmpty(crate.Trim())) continue;

                cratesInThisColumn.Push(crate);
            }

            stacksMap.Add(i, cratesInThisColumn);
            offset++;
        }
    }

    public string GetTopCrates()
    {
        SortStacks();

        string stacksTopCrates = "";
        foreach (Stack<String> stack in stacksMap.Values)
        {
            stacksTopCrates += stack.Peek();
        }
        return Regex.Replace(stacksTopCrates, "[^a-zA-Z]", "");
    }

    private void SortStacks()
    {
        for (int i = 0; i < steps[0].Count; i++)
        {
            int repeatCount = steps[0][i];
            int fromStack = steps[1][i];
            int toStack = steps[2][i];

            for (int j = 0; j < repeatCount; j++) ChangeCratePosition(fromStack, toStack);
        }
    }

    private void ChangeCratePosition(int fromStackKey, int toStackKey)
    {
        string crate = stacksMap[fromStackKey].Pop();
        stacksMap[toStackKey].Push(crate);
    }
}
