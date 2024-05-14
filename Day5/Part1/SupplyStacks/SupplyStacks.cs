namespace SupplyStacks;
using System.Collections;
using System.Text.RegularExpressions;

public class SupplyStacks
{
    Dictionary<int, Queue<string>> stacksMap = new Dictionary<int, Queue<string>>();
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
            Queue<string> cratesInThisColumn = new Queue<string>();

            foreach (string stack in cratesStack)
            {
                string crate = stack.Substring(offset * 3 + offset, 3).Trim();

                if (string.IsNullOrEmpty(crate.Trim())) continue;

                cratesInThisColumn.Enqueue(crate);
            }

            stacksMap.Add(i, cratesInThisColumn);
            offset++;
        }
    }

    public string GetTopCrates()
    {
        throw new NotImplementedException();
        
    }

    private void SortStacks()
    {
        throw new NotFiniteNumberException();
    }

    private void ChangeCratePosition()
    {
        throw new NotImplementedException();
    }
}
