using System.Windows;
using System.Windows.Controls;
using Chat_Sirinity_Client.Tools;

namespace Chat_Sirinity_Client;

public partial class LoginPage : Page
{
    readonly Frame _mainFrame = MainWindow.MainFrameInstance;

    public LoginPage()
    {
        InitializeComponent();
    }

    private void BackToWelcomePageBtn_Click(object sender, EventArgs e)
    {
        _mainFrame.Content = new WelcomePage();
    }

    private void LoginBtn_CLick(object sender, EventArgs e)
    {
        TCP tcp = new();
        tcp.ConnectToChat(LoginTb.Text, PasswordTb.Text, _mainFrame, this, null);
    }

    public void SetErrorLabelVisibility(Visibility visibility)
    {
        ErrorLoginLabel.Visibility = visibility;
    }

    private void LoginTb_KeyDown(object sender, EventArgs e)
    {
        ErrorLoginLabel.Visibility = Visibility.Collapsed;
    }
}
