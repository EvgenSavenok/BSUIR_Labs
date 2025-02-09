namespace Chat_Sirinity_Server;

public class Entrance
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        Server server = new();
        server.StartWorkingOfServer();
        app.Run();
    }
}
