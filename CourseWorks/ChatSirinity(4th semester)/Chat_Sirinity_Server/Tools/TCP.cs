using System.Net;
using System.Net.Sockets;
using System.Text;
using Chat_Sirinity_Server.Database;

namespace Chat_Sirinity_Server;

public class TCP
{
    private const int Port = 8888;
    private Broadcast Broadcast { get; } = new();
    Dictionary<int, Socket> _clientsSockets = new();
    Dictionary<string, string> _localChats = new();
    private AuthenticationDb AuthenticationDb { get; } = new();

    private IPEndPoint CreateServerEndPoint(IPAddress ipAddress)
    {
        IPEndPoint localEndPoint = new(IPAddress.Any, 0);
        try
        {
            localEndPoint = new IPEndPoint(ipAddress, Port);
        }
        catch (Exception)
        {
            Console.WriteLine("Cannot create local endpoint!");
        }
        return localEndPoint;
    }

    private Socket TryCreateSocket(IPEndPoint localEndPoint)
    {
        Socket listener = null;
        try
        {
            listener = new Socket(localEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        return listener;
    }

    private void SendMessageToClient(string mes, Socket socket)
    {
        byte[] byteMes = Encoding.UTF8.GetBytes(mes);
        socket.Send(byteMes);
    }

    private void HandleClient(Socket clientSocket)
    {
        try
        {
            
        }
        catch (SocketException e)
        {
            Console.WriteLine(e.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private async void StartListening(Socket listener)
    {
        while (true)
        {
            Socket clientSocket = listener.Accept();
            //int clientID = nextClientID++;
            //_clientsSockets.Add(clientID, clientSocket);
            byte[] nameBuffer = new byte[1024];
            int nameBytesRec = clientSocket.Receive(nameBuffer);
            string clientData = Encoding.UTF8.GetString(nameBuffer, 0, nameBytesRec);
            //string clientData = "register\r\nEugen\r\n1111";
            string[] clientDataParts = clientData.Split("\r\n");
            AuthenticationDbCols.TypeOfAuthentication = clientDataParts[0];
            AuthenticationDbCols.Name = clientDataParts[1];
            AuthenticationDbCols.Password = clientDataParts[2];
            switch (AuthenticationDbCols.TypeOfAuthentication)
            {
                case "login":
                    if (await AuthenticationDb.TryLoginUser(AuthenticationDbCols.Name,
                            AuthenticationDbCols.Password))
                    {
                        AuthenticationDbCols.Id = await AuthenticationDb.GetIdByName();
                        _clientsSockets.Add(AuthenticationDbCols.Id, clientSocket);
                        SendMessageToClient("login\r\nok", clientSocket);
                        string connectMessage = $"Client {AuthenticationDbCols.Name} with ID {AuthenticationDbCols.Id} has been connected to chat";
                        Console.WriteLine(connectMessage);
                        Task.Run(() => HandleClient(clientSocket));
                    }
                    else
                    {
                        SendMessageToClient("login\r\nfail", clientSocket);
                    }
                    break;
                case "register":
                    if (await AuthenticationDb.TryRegisterUser(AuthenticationDbCols.Name,
                            AuthenticationDbCols.Password))
                    {
                        SendMessageToClient("register\r\nok", clientSocket);
                    }
                    else
                    {
                        SendMessageToClient("register\r\nfail", clientSocket);
                    }
                    break;
            }
        }
    }

    private void TryStartListening(Socket listener, IPEndPoint localEndPoint)
    {
        const int numOfBacklogs = 20;
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(numOfBacklogs);
            Console.WriteLine($"Port {localEndPoint.Port} has been connected successfully");
            Console.WriteLine("Waiting for users connection...");
            StartListening(listener);
        }
        catch (Exception)
        {
            Console.WriteLine("Port already is used");
        }
    }

    public void HandleTcp()
    {
        IPAddress localIpAddress = Broadcast.GetLocalAddress();
        IPEndPoint localEndPoint = CreateServerEndPoint(localIpAddress);
        Socket listener = TryCreateSocket(localEndPoint);
        TryStartListening(listener, localEndPoint);
    }
}
