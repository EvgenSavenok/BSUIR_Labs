using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Chat_Sirinity_Client.Pages;
using Chat_Sirinity_Client.Tools;

namespace Chat_Sirinity_Client;

public partial class MainWindow : Window
{
    public static Frame MainFrameInstance { get; set; }
    
    private void LoadIcon()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "Icons", "telegram.png");
        var uri = new Uri(path, UriKind.Relative);
        var bitmap = new BitmapImage(uri);
        Icon = bitmap;
    }
    public MainWindow()
    {
        InitializeComponent();
        MainFrameInstance = MainFrame;
        MainFrame.Content = new WelcomePage();
        //MainFrame.Content = new ListOfChatsPage();
    }
    protected override void OnSourceInitialized(EventArgs e)
    {
        LoadIcon();
    }
    
    private void OnLoad(object sender, RoutedEventArgs e)
    {
        Broadcast broadcast = new Broadcast();
        broadcast.ConnectToServer();
    }
}
