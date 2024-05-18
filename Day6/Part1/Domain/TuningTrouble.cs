namespace Domain;

public class TuningTrouble
{
    string input;
    public TuningTrouble(string inputPath)
    {
        input = new StreamReader(inputPath).ReadToEnd();
    }

    public int GetStartOfPacketMarker()
    {
        return GetStartOfPacketMarker(0);
    }

    private int GetStartOfPacketMarker(int index)
    {
        System.Console.WriteLine("AAAAAAAAAAAARG");

        string sequence = input.Substring(index, 4);

        if (!HasDuplicate(sequence.ToCharArray())) return index + 4;

        return GetStartOfPacketMarker(index + 1);
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
