using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Chat_Sirinity_Client.Controls;
using Chat_Sirinity_Client.Pages;

namespace Chat_Sirinity_Client.Chats;

public class ChatListItemViewModel
{
    #region Public Properties

    public string Name { get; set; }

    public string Message { get; set; }

    public string Initial { get; set; }

    public string ProfilePictureRGB { get; set; }

    public bool IsSelected { get; set; }

    #endregion

    #region Command methods

    public ICommand OpenMessageCommand { get; set; }

    public ChatListItemViewModel()
    {
        OpenMessageCommand = new RelayCommand(OpenMessage);
    }

    public void OpenMessage()
    {
        ListOfChatsPage._mainChatFrame.Content = new ChatMessageListControl();
    }

    #endregion
}
