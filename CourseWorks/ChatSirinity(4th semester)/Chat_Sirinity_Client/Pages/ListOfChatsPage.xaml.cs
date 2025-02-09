using System.Windows.Controls;
using Chat_Sirinity_Client.Controls;

namespace Chat_Sirinity_Client.Pages;

public partial class ListOfChatsPage : Page
{
    public static Frame _mainChatFrame;

    public static void InitializeMainChatFrame(Frame MainChatFrame)
    {
        _mainChatFrame = MainChatFrame;
    }
    public ListOfChatsPage()
    {
        InitializeComponent();
        MainChatFrame.Content = new ChatMessageListControl();
        InitializeMainChatFrame(MainChatFrame);
    }
}

