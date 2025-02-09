using System.Windows.Media;

namespace Chat_Sirinity_Client.Chats.Design;

public class ChatListDesignModel : ChatListViewModel
{
    #region Singleton

    public static ChatListDesignModel DesignInstance => new();

    #endregion

    #region Constructor

    private void CreateChats()
    {
        Items = new List<ChatListItemViewModel>();
        if (ChatsInfo.ListOfFriends != null)
        {
            for (int i = 0; i < ChatsInfo.ListOfFriends.Length - 1; i++)
            {
                string name = ChatsInfo.ListOfFriends[i];
                string avatarColor = ChatsInfo.ListOfColors[i];
                if (name != "" && avatarColor != "")
                {
                    ChatListItemViewModel friend = new ChatListItemViewModel
                    {
                        Name = name,
                        Initial = name.Substring(0, 1),
                        Message = "Привет!",
                        ProfilePictureRGB = avatarColor,
                        IsSelected = false
                    };
                    Items.Add(friend);
                }
            }
        }
    }

    public ChatListDesignModel()
    {
        CreateChats();
    }

    #endregion
}
