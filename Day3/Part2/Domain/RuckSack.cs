namespace Domain;

public class RuckSack
{
    string[] sacks;
    public RuckSack(string filePath) => sacks = new StreamReader(filePath).ReadToEnd().Replace("\r", "").Split("\n");

    public int GetPrioritySum()
    {
        int total = 0;
        foreach (string sack in sacks) total += GetSackPriority(sack);

        return total;
    }

    public int GetGroupsPrioritySum()
    {
        int total = 0;
        for (int i = 3; i <= sacks.Length; i += 3) total += GetGroupBadgePriority(sacks[i - 3], sacks[i - 2], sacks[i - 1]);

        return total;
    }

    private int GetGroupBadgePriority(string firstSack, string secondSack, string thirdSack)
    {
        for (int i = 0; i < firstSack.Length; i++)
        {
            for (int j = 0; j < secondSack.Length; j++)
            {
                for (int k = 0; k < thirdSack.Length; k++)
                {
                    if (secondSack[j] == firstSack[i] && firstSack[i] == thirdSack[k])
                    {
                        return GetItemPriorityNumber(firstSack[i]);
                    }
                }
            }
        }

        throw new ArgumentException("Error: each group should contain exactly one matching item id, but none were found.");
    }

    private int GetSackPriority(string sack)
    {
        string firstSack = sack.Substring(0, sack.Length / 2);
        string secondSack = sack.Substring(sack.Length / 2);

        for (int i = 0; i < firstSack.Length; i++)
        {
            for (int j = 0; j < secondSack.Length; j++)
            {
                if (!firstSack[i].Equals(secondSack[j])) continue;

                return GetItemPriorityNumber(firstSack[i]);
            }
        }

        throw new ArgumentException("Error: each sack should contain exactly one matching item id, but none were found.");
    }

    private int GetItemPriorityNumber(char itemId)
    {
        if (char.ToUpper(itemId).Equals(itemId)) return itemId - 38;

        return itemId - 96;
    }
}