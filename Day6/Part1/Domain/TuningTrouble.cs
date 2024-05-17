namespace Domain;

public class TuningTrouble
{
    string input;
    public TuningTrouble(string inputPath) {
        string input = new StreamReader(inputPath).ReadToEnd();
        this.input = input;
    }

    public int GetStartOfPacketMarker() {
        throw new NotImplementedException();
    }

    private int GetStartOfPacketMarker(int previousIndex) {
        string sequence = input.Substring(previousIndex, previousIndex+4);
        

        return 0;
    }
}
