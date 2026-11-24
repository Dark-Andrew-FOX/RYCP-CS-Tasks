public class CommandLogger
{
    public void LogCommand(Commands c) => Console.WriteLine($"Player entered command: {c}");
}

public class ApplicationQuitter
{
    private void QuitOnCommand(Commands s)
    {
        if (s != Commands.quit) return;
        Environment.Exit(0);
    }

    public void Connect()
    {
        CommandReader.CommandEntered += QuitOnCommand;
    }
}
