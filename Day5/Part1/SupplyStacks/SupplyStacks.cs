namespace SupplyStacks;
using System.Text.RegularExpressions;

public class SupplyStacks
{
    string[,] cratesMap;
    string[] steps;
    public SupplyStacks(string filePath)
    {
        string input = new StreamReader(filePath).ReadToEnd().Replace("\r", "");
        string[] inputSplited = input.Split("\n\n");

        steps = Regex.Replace(inputSplited[1], "[^0-9.\n]", "").Split("\n");
        int[] columns = Array.ConvertAll(Regex.Replace(inputSplited[0], "[^0-9.' ']", "").Trim().Split("   "), s => int.Parse(s));
        System.Console.WriteLine(columns);
    }

    public string GetTopCrates()
    {
        throw new NotImplementedException();
    }

    private void SortCrates()
    {
        throw new NotFiniteNumberException();
    }

    private void ChangeCratePosition()
    {
        throw new NotImplementedException();
    }
}
