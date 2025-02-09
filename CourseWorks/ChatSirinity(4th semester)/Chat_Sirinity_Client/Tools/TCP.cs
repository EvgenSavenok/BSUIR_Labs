using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Chat_Sirinity_Client.Authentication;
using Chat_Sirinity_Client.Pages;
using Chat_Sirinity_Client;
using Chat_Sirinity_Client.Chats;
using Chat_Sirinity_Client.Chats.Design;

namespace Chat_Sirinity_Client.Tools;

public class TCP
{
    public static string Name { get; set; }
    public static string Password { get; set; }
    public static Socket ClientSocket { get; set; }

    private void SetListOfFriends()
    {
        byte[] buffer = new byte[20000];
        ClientSocket.Receive(buffer);
        string list = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        ChatsInfo.ListOfFriends = list.Split(" ");
    }
    
    private void SetListOfColors()
    {
        byte[] buffer = new byte[20000];
        ClientSocket.Receive(buffer);
        string list = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        ChatsInfo.ListOfColors = list.Split(" ");
    }

    private void StartCommunication(Frame mainFrame)
    {
        byte[] byteMessage = Encoding.UTF8.GetBytes("chats\r\ndisplay");
        ClientSocket.Send(byteMessage);
        SetListOfFriends();
        SetListOfColors();
        mainFrame.Content = new ListOfChatsPage();
    }

    private void StartConnection(string login, string password, Frame mainFrame, LoginPage? loginWindow,
        RegisterPage? registerWindow)
    {
        Name = login;
        Password = password;
        IPEndPoint remoteEndPoint;
        try
        {
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(Broadcast.ServerIpAddress), Broadcast.Port);
            ClientSocket = new Socket(remoteEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket.Connect(remoteEndPoint);
            CustomAuthentication authentication = new();
            authentication.DetermineTypeOfAuthentication(mainFrame, loginWindow, registerWindow);
            if (CustomAuthentication.IsAuthenticationSuccessful)
            {
                StartCommunication(mainFrame);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Server connection error. Try to entrance later. Error: " +
                            e.Message);
        }
    }

    public void ConnectToChat(string login, string password, Frame mainFrame, LoginPage? loginWindow,
        RegisterPage? registerWindow)
    {
        StartConnection(login, password, mainFrame, loginWindow, registerWindow);
    }
}
