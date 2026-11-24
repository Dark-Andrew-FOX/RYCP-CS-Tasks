CommandLogger logger = new CommandLogger();
CommandReader.CommandEntered += logger.LogCommand;

ApplicationQuitter quitter = new ApplicationQuitter();
quitter.Connect();

CommandReader.CommandEntered += ShowHelp;

while (CommandReader.ReadCommand())
{
}

static void ShowHelp(Commands command)
{
    if (command != Commands.help)
        return;

    Console.WriteLine("Available commands: help, quit");
}
