namespace Domain;

public class RuckSack
{
    string[] sacks;
    public RuckSack(string filePath) => sacks = new StreamReader(filePath).ReadToEnd().Replace("\r", "").Split("\n");

    public int PrioritySum()
    {
        int total = 0;
        foreach (string sack in sacks)
        {
            total += GetSackPriority(sack);
        }
        return total;
    }

    private int GetSackPriority(string sack)
    {
        string firstSack = sack.Substring(0, sack.Length / 2);
        string secondSack = sack.Substring(sack.Length / 2);

        for (int i = 0; i < firstSack.Length; i++)
        {
            for (int j = 0; j < secondSack.Length; j++)
            {
                if (firstSack[i].Equals(secondSack[j]))
                {
                    return GetItemPriorityNumber(firstSack[i]);
                }
            }
        }

        throw new ArgumentException("each sack should contain exactly 1 matching item id, but none were found");
    }

    private int GetItemPriorityNumber(char itemId)
    {
        if (char.ToUpper(itemId).Equals(itemId)) return itemId - 38;

        return itemId - 96;
    }
}
