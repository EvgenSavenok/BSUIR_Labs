using System.Windows.Media;
using Chat_Sirinity_Client.Chats;
using Chat_Sirinity_Client.Chats.Design;

namespace Chat_Sirinity_Client.Chats.InputChatMessage.MessageDesign;

public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
{
    #region Singleton

    public static ChatMessageListItemDesignModel DesignInstance => new();

    #endregion

    #region Constructor
    
    public ChatMessageListItemDesignModel()
    {
        Initial = "L";
        SenderName = "Luke";
        Message = "This chat is amazing!";
        ProfilePictureRGB = "3099c5";
        SentByMe = false;
    }
    
    #endregion
}
