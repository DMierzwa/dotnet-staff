namespace RockPaperScissors;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Rock, Paper, or Scissors: ");
        string? playerItemName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(playerItemName))
            return;

        Dictionary<string, int> gameItems = GetGameItems();

        if (!gameItems.TryGetValue(playerItemName.ToLower(), out int playerValue))
            return;

        int compValue = new Random().Next(-1, 2);

        Console.WriteLine(playerValue);
        Console.WriteLine(compValue);

        int compareResult = CompareValue(playerValue, compValue);

        Console.WriteLine(compareResult);

        if (compareResult == 2)
            Console.WriteLine("It's a draw");
        else if (compareResult == playerValue)
            Console.WriteLine("You won");
        else
            Console.WriteLine("Computer won");
    }

    static Dictionary<string, int> GetGameItems()
    {
        Dictionary<string, int> dict = new();

        dict.Add("paper", -1);
        dict.Add("rock", 0);
        dict.Add("scissors", 1);

        return dict;
    }

    static int CompareValue(int val1, int val2)
    {
        if (val1 == val2)
            return 2;

        if (Math.Abs(val1) == Math.Abs(val2))
            return Math.Max(val1, val2);

        return Math.Min(val1, val2);
    }
}