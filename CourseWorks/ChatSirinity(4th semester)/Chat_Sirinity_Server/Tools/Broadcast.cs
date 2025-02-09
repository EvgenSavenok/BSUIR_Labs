using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Chat_Sirinity_Server;

public class Broadcast
{
    private const int Port = 8888;
    private bool IsInLocalRange(IPAddress address)
    {
        byte[] bytes = address.GetAddressBytes();
        return bytes[0] == 192 && bytes[1] == 168;
    }
    public IPAddress GetLocalAddress()
    {
        List<string> result = new List<string>();
        foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            var items = networkInterface.GetIPProperties().UnicastAddresses
                .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork && IsInLocalRange(x.Address));
            result.AddRange(items.Select(ip => ip.Address.ToString()));
        }
        //return IPAddress.Parse(result.Last());
        return IPAddress.Parse(result[result.Count - 2]);
    }
    
    private IPAddress GetLocalMask()
    {
        List<string> mask = new List<string>();
        foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            var items = networkInterface.GetIPProperties().UnicastAddresses
                .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork && IsInLocalRange(x.Address));
            mask.AddRange(items.Select(ip => ip.IPv4Mask.ToString()));
        }
        return IPAddress.Parse(mask.Last());
    }

    private IPAddress GetBroadcastAddress(IPAddress ipAddress, IPAddress subnetMask)
    {
        if (string.IsNullOrEmpty(ipAddress.ToString()) || string.IsNullOrEmpty(subnetMask.ToString()))
            throw new ArgumentException("IP address and subnet mask cannot be empty.");
        
        byte[] ipBytes = ipAddress.GetAddressBytes();
        byte[] maskBytes = subnetMask.GetAddressBytes();
        
        if (ipBytes.Length != maskBytes.Length)
            throw new ArgumentException("Invalid IP address or subnet mask format.");
        
        byte[] broadcastBytes = new byte[ipBytes.Length];
        for (int i = 0; i < broadcastBytes.Length; i++)
            broadcastBytes[i] = (byte)(ipBytes[i] | (byte)~maskBytes[i]);
        return new IPAddress(broadcastBytes);
    }

    private async Task SendAsync(UdpClient udpClient, IPAddress serverIpAddress, IPEndPoint broadcastEndPoint)
    {
        byte[] sendBytes = Encoding.UTF8.GetBytes(serverIpAddress.ToString());
        udpClient.Send(sendBytes, sendBytes.Length, broadcastEndPoint);
        Console.WriteLine("Broadcast has been sent!");
        await Task.Delay(3000);
    }
    private async void SendBroadcastToAllClients(IPAddress broadcastAddress, IPAddress serverIpAddress)
    {
        UdpClient udpClient = new();
        udpClient.EnableBroadcast = true;
        IPEndPoint broadcastEndPoint = new(broadcastAddress, Port);
        try
        {
            while (true)
            {
                var task = SendAsync(udpClient, serverIpAddress, broadcastEndPoint);
                await task;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Cannot send message to client.");
        }
    }

    public void StartBroadcasting()
    {
        IPAddress serverIpAddress = GetLocalAddress();
        IPAddress subnetMask = GetLocalMask();
        IPAddress broadcastAddress = GetBroadcastAddress(serverIpAddress, subnetMask);
        SendBroadcastToAllClients(broadcastAddress, serverIpAddress);
    }
}
