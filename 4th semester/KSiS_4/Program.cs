using Ping;

class Program
{
    static void Main(string[] args)
    {
        PowerShell powerShell = new();
        powerShell.DetermineCommand();
    }
}