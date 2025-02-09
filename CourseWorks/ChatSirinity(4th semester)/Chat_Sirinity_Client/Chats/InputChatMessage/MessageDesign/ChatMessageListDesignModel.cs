using System.Collections.ObjectModel;
using System.Windows.Media;
using Chat_Sirinity_Client.Chats;

namespace Chat_Sirinity_Client.Chats.InputChatMessage.MessageDesign;

public class ChatMessageListDesignModel : ChatMessageListViewModel
{
    #region Singleton

    public static ChatMessageListDesignModel DesignInstance => new();

    #endregion

    #region Constructor

    private void CreateChats()
    {
        Items = new ObservableCollection<ChatMessageListItemViewModel>()
        {
            new ChatMessageListItemViewModel()
            {
                SenderName = "Lera",
                Message = "Йоу",
                Initial = "L",
                SentByMe = false,
                ProfilePictureRGB = "3099c5"
            },
            new ChatMessageListItemViewModel()
            {
                SenderName = "Eugen",
                Initial = "E",
                Message = "Привет",
                SentByMe = true,
                ProfilePictureRGB = "16c432"
            },
            new ChatMessageListItemViewModel()
            {
                SenderName = "Lera",
                Message = "Как дела?",
                Initial = "L",
                SentByMe = false,
                ProfilePictureRGB = "3099c5"
            }
        };
    }

    public ChatMessageListDesignModel()
    {
        CreateChats();
    }

    #endregion
}
