namespace Domain;

public class TuningTrouble
{
    string input;
    public TuningTrouble(string inputPath)
    {
        string input = new StreamReader(inputPath).ReadToEnd();
        this.input = input;
    }

    public int GetStartOfPacketMarker()
    {
        return GetStartOfPacketMarker(0);
    }

    private int GetStartOfPacketMarker(int previousIndex)
    {
        if (previousIndex >= input.Length - 5) return previousIndex+1;

        string sequence = input.Substring(previousIndex, 4);

        if (!HasDuplicate(sequence.ToCharArray())) return previousIndex+1;

        return GetStartOfPacketMarker(previousIndex + 4);
    }

    private bool HasDuplicate(char[] array)
    {
        HashSet<char> duplicate = new HashSet<char>();
        foreach (char marker in array)
        {
            if (duplicate.Contains(marker)) return true;

            duplicate.Add(marker);
        }

        return false;
    }
}
