using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Chat_Sirinity_Client.Tools;

namespace Chat_Sirinity_Client.Pages;

public partial class SideMenuControl : UserControl
{
    public SideMenuControl()
    {
        InitializeComponent();
    }

    // private async void SearchPerson_KeyDown(object sender, KeyEventArgs e)
    // {
    //     if (e.Key != Key.LeftShift || e.Key != Key.RightShift)
    //     {
    //         TextBox tb = sender as TextBox;
    //         byte[] buffer = Encoding.UTF8.GetBytes("search\r\n" + tb.Text);
    //         if (tb.Text.Length > 0)
    //         {
    //             await TCP.ClientSocket.SendAsync(buffer);
    //             byte[] friendBuffer = new byte[1024];
    //             int numOfBytes = TCP.ClientSocket.Receive(friendBuffer);
    //             string message = Encoding.UTF8.GetString(friendBuffer, 0, numOfBytes);
    //             if (message.Equals("friend\r\nok"))
    //             {
    //                 
    //             }
    //         }
    //     }
    // }
}
