namespace SupplyStacks;
using System.Collections;
using System.Text.RegularExpressions;

public class SupplyStacks
{
    Dictionary<int, Stack<string>> stacksMap = new Dictionary<int, Stack<string>>();
    string[] steps;
    public SupplyStacks(string filePath)
    {
        string input = new StreamReader(filePath).ReadToEnd().Replace("\r", "");
        ReadInput(input);
    }

    private void ReadInput(string input)
    {
        string[] inputSplited = input.Split("\n\n");

        steps = Array.ConvertAll(Regex.Replace(inputSplited[1], "[^0-9.\n.' ']", "").Split("\n"), n => Regex.Replace(n.Trim(), @"\s+", " "));
        int stacksCount = Regex.Replace(inputSplited[0], "[^0-9.' ']", "").Trim().Split("   ").Length;

        string[] cratesStack = Utils.ReplaceLastOccurrence(Regex.Replace(inputSplited[0], "[0-9]", ""), "\n", "").Split("\n");
        cratesStack[cratesStack.Length - 1] = cratesStack[cratesStack.Length - 1].Trim();

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
        foreach (string step in steps)
        {
            int[] stepValues = Array.ConvertAll(step.Split(" "), n => int.Parse(n));
            int repeatCount = stepValues[0];
            int fromStack = stepValues[1];
            int toStack = stepValues[2];

            for (int i = 0; i < repeatCount; i++) ChangeCratePosition(fromStack, toStack);
        }
    }

    private void ChangeCratePosition(int fromStackKey, int toStackKey)
    {
        string crate = stacksMap[fromStackKey].Pop();
        stacksMap[toStackKey].Push(crate);
    }
}
