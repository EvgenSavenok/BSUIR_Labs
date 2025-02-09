using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Chat_Sirinity_Client.Chats;

namespace Chat_Sirinity_Client.Controls;

public partial class ChatMessageListControl : UserControl
{
    public ChatMessageListControl()
    {
        InitializeComponent();
        DataContext = new ChatMessageListViewModel();
    }
}

