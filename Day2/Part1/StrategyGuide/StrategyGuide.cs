namespace StrategyGuide;

public class StrategyGuide
{
    enum handShape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    string[] rounds;
    public StrategyGuide(string filePath)
    {
        rounds = new StreamReader(filePath).ReadToEnd().Replace("\r", "").Split("\n");
    }

    public int GetTotalScore()
    {
        int totalScore = 0;
        foreach (string round in rounds)
        {
            handShape enemyType = GetHandShape(round[0]);
            handShape playerType = GetHandShape(round[round.Length - 1]);

            totalScore += (int) playerType;

            totalScore += GetRoundScore(playerType, enemyType);
        }

        return totalScore;
    }

    private int GetRoundScore(handShape playerType, handShape enemyType) {
        if (playerType == enemyType) {
            return 3;
        }
        else if (playerType == handShape.Rock && enemyType == handShape.Paper ||
            playerType == handShape.Paper && enemyType == handShape.Scissors || 
            playerType == handShape.Scissors && enemyType == handShape.Rock) {
            return 0;
        }

        return 6;
    }

    private handShape GetHandShape(char letter)
    {
        switch (letter)
        {
            case 'A':
            case 'X':
                return handShape.Rock;
            case 'B':
            case 'Y':
                return handShape.Paper;
            case 'C':
            case 'Z':
                return handShape.Scissors;
        }

        throw new ArgumentException("Invalid hand shape type");
    }
}