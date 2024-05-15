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
        string[] inputSplited = input.Split("\n\n");

        steps = Regex.Replace(inputSplited[1], "[^0-9.\n]", "").Split("\n");
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
            int repeatCount = (int)char.GetNumericValue(step[0]);
            int fromStack = (int)char.GetNumericValue(step[1]);
            int toStack = (int)char.GetNumericValue(step[2]);

            for (int i = 0; i < repeatCount; i++) ChangeCratePosition(fromStack, toStack);
        }
    }

    private void ChangeCratePosition(int fromStackKey, int toStackKey)
    {
        try
        {
            string crate = stacksMap[fromStackKey].Pop();
            stacksMap[toStackKey].Push(crate);
        }
        catch (System.Exception)
        {
            throw new ArgumentException($"Error: there's no crate present on stack of id: {toStackKey}");
        }
    }
}
