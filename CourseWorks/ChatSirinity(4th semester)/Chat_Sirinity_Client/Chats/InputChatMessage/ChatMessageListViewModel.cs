using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;

namespace Chat_Sirinity_Client.Chats;

public class ChatMessageListViewModel
{
    public static ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }

    public ICommand SendCommand { get; set; }

    public ChatMessageListViewModel()
    {
        SendCommand = new RelayCommand(Send);
    }

    public string PendingMessageText { get; set; }

    public void Send()
    {
        if (Items == null)
            Items = new ObservableCollection<ChatMessageListItemViewModel>();
        Items.Add(new ChatMessageListItemViewModel
        {
            Initial = "L",
            Message = PendingMessageText,
            SentByMe = true,
            SenderName = "Eugen"
        });
    }
}
