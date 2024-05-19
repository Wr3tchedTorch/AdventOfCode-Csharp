namespace Domain;

public class TuningTrouble
{
    enum MarkerType
    {
        Package = 4,
        Message = 14
    }

    string input;
    public TuningTrouble(string inputPath)
    {
        input = new StreamReader(inputPath).ReadToEnd();
    }

    public int GetStartOfPacketMarker() => GetStartOfMarker(0, MarkerType.Package);
    public int GetStartOfMessageMarker() => GetStartOfMarker(0, MarkerType.Message);

    private int GetStartOfMarker(int index, MarkerType marker)
    {        
        string sequence = input.Substring(index, (int) marker);

        if (!HasDuplicate(sequence.ToCharArray())) return index + (int) marker;

        return GetStartOfMarker(index + 1, marker);
    }

    private bool HasDuplicate(char[] array)
    {
        HashSet<char> duplicate = [];
        foreach (char marker in array)
        {
            if (duplicate.Contains(marker)) return true;

            duplicate.Add(marker);
        }

        return false;
    }
}
