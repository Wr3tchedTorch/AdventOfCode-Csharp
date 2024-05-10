namespace StrategyGuide;

public class StrategyGuide
{
    enum roundOutcome
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
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

    private int GetRoundScore(handShape playerHandShape, handShape enemyHandShape)
    {
        if (playerHandShape == enemyHandShape) return (int) roundOutcome.Draw;
        
        if (GetWinningHandShape(enemyHandShape) == playerHandShape) return (int) roundOutcome.Win;

        return (int) roundOutcome.Lose;
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

    private handShape GetWinningHandShape(handShape enemyHandShape)
    {
        switch (enemyHandShape)
        {
            case handShape.Rock: return handShape.Paper;
            case handShape.Paper: return handShape.Scissors;
            case handShape.Scissors: return handShape.Rock;
        }

        throw new ArgumentException($"Invalid handshape: {enemyHandShape}");
    }
}