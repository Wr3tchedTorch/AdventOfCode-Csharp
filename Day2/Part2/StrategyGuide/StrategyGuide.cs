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
        None = 0,
        Rock = 1,
        Paper = 2,
        Scissors = 3
    };

    string[] rounds;
    public StrategyGuide(string filePath) => rounds = new StreamReader(filePath).ReadToEnd().Replace("\r", "").Split("\n");

    public int GetTotalScore()
    {
        int totalScore = 0;
        foreach (string round in rounds)
        {
            handShape enemyHandShape = GetHandShape(round[0]);
            handShape playerHandShape = GetHandShape(round[round.Length - 1], enemyHandShape);

            totalScore += (int)playerHandShape;

            totalScore += GetRoundScore(playerHandShape, enemyHandShape);
        }

        return totalScore;
    }

    private int GetRoundScore(handShape playerHandShape, handShape enemyHandShape)
    {
        if (playerHandShape == enemyHandShape) return (int) roundOutcome.Draw;
        
        if (GetWinningHandShape(enemyHandShape) == playerHandShape) return (int) roundOutcome.Win;

        return (int) roundOutcome.Lose;
    }

    private handShape GetHandShape(char letter, handShape enemyHandShape = handShape.None)
    {
        switch (letter)
        {
            case 'A': return handShape.Rock;
            case 'B': return handShape.Paper;
            case 'C': return handShape.Scissors;

            // Win
            case 'X': return GetWinningHandShape(GetWinningHandShape(enemyHandShape));
            // Draw
            case 'Y': return enemyHandShape;
            // Lose
            case 'Z': return GetWinningHandShape(enemyHandShape);
        }

        throw new ArgumentException($"Invalid hand shape {enemyHandShape}");
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