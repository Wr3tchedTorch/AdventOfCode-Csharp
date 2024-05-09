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
        int highestCalorie = int.MinValue;
        string[] elfsCalories = input.Split("\n\n");

        for (int i = 0; i < elfsCalories.Length; i++)
        {
            int[] newElf = Array.ConvertAll(elfsCalories[i].Split("\n"), int.Parse);
            
            int caloriesSum = newElf.Sum();
            
            if (caloriesSum > highestCalorie) highestCalorie = caloriesSum;
        }

        return highestCalorie;
    }
}
