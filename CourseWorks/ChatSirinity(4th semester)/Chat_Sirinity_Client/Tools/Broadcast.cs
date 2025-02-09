using System.Net.Sockets;
using System.Text;

namespace Chat_Sirinity_Client.Tools;

public class Broadcast
{
    public const int Port = 8888;
    public static string ServerIpAddress;
    
    public async void ConnectToServer()
    {
        try
        {
            UdpClient udpClient = new(Port);
            udpClient.EnableBroadcast = true;
            UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
            byte[] receiveBytes = receiveResult.Buffer;
            string receivedData = Encoding.UTF8.GetString(receiveBytes);
            udpClient.Close();
            Console.WriteLine($"Received broadcast from {receiveResult.RemoteEndPoint} : {receivedData}\n");
            ServerIpAddress = receivedData;
        }
        catch (Exception)
        {
            Console.WriteLine("Cannot connect to server.");
        }
    }
}
