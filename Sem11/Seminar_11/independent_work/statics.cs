public static class CommandReader
{
    public static event Action<Commands>? CommandEntered;

    public static bool ReadCommand()
    {
        while (true)
        {
            Console.WriteLine("Please input valid command");
            string? input = Console.ReadLine();

            if (input == null)
                return false;

            if (Enum.TryParse(input, true, out Commands command)
                && Enum.IsDefined(typeof(Commands), command)
                && command != Commands.none)
            {
                CommandEntered?.Invoke(command);
                return true;
            }
        }
    }
}

public enum Commands
{
    none,
    quit,
    help
}
