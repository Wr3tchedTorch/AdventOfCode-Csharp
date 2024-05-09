namespace Domain;

public class CalorieCounter
{
    string input;
    public CalorieCounter(String filePath)
    {
        input = new StreamReader(filePath).ReadToEnd();
        input = input.Replace("\r", "");
    }

    public int GetHighestCalorieCount()
    {
        int highestCalorie = 0;
        string[] elfsCalories = input.Split("\n\n");

        for (int i = 0; i < elfsCalories.Length; i++)
        {
            int[] newElf = Array.ConvertAll(elfsCalories[i].Split("\n"), int.Parse);

            int caloriesSum = newElf.Sum();

            if (caloriesSum > highestCalorie) highestCalorie = caloriesSum;
        }

        return highestCalorie;
    }

    public int GetTopTreeCalorieCount()
    {
        int topOne = 0,
            topTwo = 0,
            topTree = 0;

        string[] elfsCalories = input.Split("\n\n");

        for (int i = 0; i < elfsCalories.Length; i++)
        {
            int[] newElf = Array.ConvertAll(elfsCalories[i].Split("\n"), int.Parse);

            int caloriesSum = newElf.Sum();

            if (caloriesSum > topOne)
            {
                topTree = topTwo;
                topTwo = topOne;
                topOne = caloriesSum;
            }
            else if (caloriesSum > topTwo)
            {
                topTree = topTwo;
                topTwo = caloriesSum;
            }
            else if (caloriesSum > topTree) { topTree = caloriesSum; }
        }

        return topOne + topTree + topTwo;
    }
}
