using System.Windows.Media;

namespace Chat_Sirinity_Client.Chats;

public class ChatMessageListItemViewModel
{
    public string SenderName { get; set; }
    
    public string Message { get; set; }

    public string Initial { get; set; }
    
    public string ProfilePictureRGB { get; set; }
    
    public bool IsSelected { get; set; }
    
    public bool SentByMe { get; set; }
}
