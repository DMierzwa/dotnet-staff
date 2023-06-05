namespace RockPaperScissors;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> gameItems = GetGameItems();

        string? playerChoice = string.Empty;

        do
        {
            Console.Write("Write Rock, Paper, Scissors or Exit: ");
            playerChoice = Console.ReadLine()?.ToLower() ?? string.Empty;

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

        } while (true);
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