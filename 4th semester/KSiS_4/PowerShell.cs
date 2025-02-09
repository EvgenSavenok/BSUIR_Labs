namespace Ping;

public class PowerShell
{
    Dictionary<string, ICommand> _cmdCommandsDictionary = new()
    {
        { "ping", new CustomPing() },
        { "tracert", new CustomTracer() }
    };
    public void DetermineCommand()
    {
        while (true)
        {
            string command = Console.ReadLine()!;
            string[] partsOfCommand = command.Split(' ');
            if (partsOfCommand.Count() > 2)
                return;
            if (_cmdCommandsDictionary.ContainsKey(partsOfCommand[0]))
            {
                _cmdCommandsDictionary[partsOfCommand[0]].ExecuteCommand(partsOfCommand[1]);
            }
        }
    }
}
