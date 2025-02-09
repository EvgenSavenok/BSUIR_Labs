using System.Windows.Controls;
using Chat_Sirinity_Client.Pages;

namespace Chat_Sirinity_Client;

public partial class WelcomePage : Page
{
    readonly Frame _mainFrame = MainWindow.MainFrameInstance;
    public WelcomePage()
    {
        InitializeComponent();
    }
    
    private void LoginBtn_Click(object sender, EventArgs e)
    {
        _mainFrame.Content = new LoginPage();
    }

    private void RegisterBtn_Click(object sender, EventArgs e)
    {
        _mainFrame.Content = new RegisterPage();
    }
}

