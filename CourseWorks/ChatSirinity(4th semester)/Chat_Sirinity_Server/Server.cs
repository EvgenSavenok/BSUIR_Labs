using System.Data;
using Microsoft.Data.SqlClient;

namespace Chat_Sirinity_Server;

public class Server
{
    private Broadcast Broadcast { get; } = new();
    private TCP Tcp { get; } = new();
    
    public async void StartWorkingOfServer()
    {
        Broadcast.StartBroadcasting();
        Tcp.HandleTcp();
    }
}
