namespace RockPaperScissors;

internal class Program
{
    static void Main()
    {
        Dictionary<string, int> gameItems = GetGameItems();

        while (true)
        {
            Console.Write("Write Rock, Paper, Scissors or Exit: ");

            string? playerChoice = Console.ReadLine()?.ToLower() ?? string.Empty;

            if ("exit" == playerChoice)
            {
                Console.WriteLine("Exit game");
                return;
            }

            if (!gameItems.TryGetValue(playerChoice.ToLower(), out int playerValue))
            {
                Console.WriteLine("Bad command.");
                continue;
            }

            int compValue = new Random().Next(-1, 2);
            int compareResult = CompareValue(playerValue, compValue);

            if (compareResult == 2)
                Console.WriteLine("It's a draw");
            else if (compareResult == playerValue)
                Console.WriteLine("You won !!!");
            else
                Console.WriteLine("Computer won");
        }
    }

    static Dictionary<string, int> GetGameItems()
    {
        Dictionary<string, int> dict = new()
        {
            { "paper", -1 },
            { "rock", 0 },
            { "scissors", 1 }
        };

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