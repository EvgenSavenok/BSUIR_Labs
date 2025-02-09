using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Chat_Sirinity_Client.Chats.Design;
using Chat_Sirinity_Client.Pages;
using Chat_Sirinity_Client.Tools;

namespace Chat_Sirinity_Client.Authentication;

public class CustomAuthentication
{
    private bool _isLoginSuccessful;
    private bool _isRegisterSuccessful;

    public static bool IsAuthenticationSuccessful { get; set; }

    private bool HandleAuthorizationAnswer(string answer)
    {
        string[] answerParts = answer.Split("\r\n");
        if (answerParts[1] == "ok" && answerParts.Length == 2)
            return true;
        if (answerParts[1] == "fail")
            return false;
        return false;
    }

    private bool GetMessage(Socket clientSocket)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int numOfBytes = clientSocket.Receive(buffer);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numOfBytes);
            return HandleAuthorizationAnswer(receivedMessage);
        }
        catch (Exception)
        {
            Console.WriteLine("Connection error");
        }
        return false;
    }

    private void TryLoginUser()
    {
        string loginMessage = $"login\r\n{TCP.Name}\r\n{TCP.Password}";
        byte[] nameBuffer = Encoding.UTF8.GetBytes(loginMessage);
        TCP.ClientSocket.Send(nameBuffer);
        _isLoginSuccessful = GetMessage(TCP.ClientSocket);
    }

    private async Task HandlePing()
    {
        byte[] buffer = new byte[1024];
        while (true)
        {
            try
            {
                int bytesRead = TCP.ClientSocket.Receive(new ArraySegment<byte>(buffer));
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                if (message == "PING")
                {
                    byte[] pongMessage = Encoding.UTF8.GetBytes("PONG");
                    await TCP.ClientSocket.SendAsync(pongMessage, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ping error from server: {ex.Message}");
                break;
            }
        }
    }

    private void StartLoginProcess(Frame mainFrame, LoginPage loginWindow)
    {
        TryLoginUser();
        if (_isLoginSuccessful)
        {
            loginWindow.SetErrorLabelVisibility(Visibility.Collapsed);
            IsAuthenticationSuccessful = true;
        }
        else
        {
            loginWindow.SetErrorLabelVisibility(Visibility.Visible);
        }
    }

    private void TryRegisterUser()
    {
        string registerMessage = $"register\r\n{TCP.Name}\r\n{TCP.Password}";
        byte[] nameBuffer = Encoding.UTF8.GetBytes(registerMessage);
        TCP.ClientSocket.Send(nameBuffer);
        _isRegisterSuccessful = GetMessage(TCP.ClientSocket);
    }

    private void StartRegisterProcess(Frame mainFrame, RegisterPage registerWindow)
    {
        TryRegisterUser();
        if (_isRegisterSuccessful)
        {
            mainFrame.Content = new LoginPage();
            registerWindow.SetErrorLabelVisibility(Visibility.Collapsed);
        }
        else
        {
            registerWindow.SetErrorLabelVisibility(Visibility.Visible);
            registerWindow.SetErrorLabelContent("Такой пользователь уже существует.");
        }
    }

    public void DetermineTypeOfAuthentication(Frame mainFrame, LoginPage? loginWindow,
        RegisterPage? registerWindow)
    {
        if (loginWindow != null)
            StartLoginProcess(mainFrame, loginWindow!);
        else
            StartRegisterProcess(mainFrame, registerWindow!);
    }
}
