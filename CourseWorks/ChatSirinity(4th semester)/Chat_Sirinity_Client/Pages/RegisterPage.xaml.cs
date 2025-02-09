using System.Windows;
using System.Windows.Controls;
using Chat_Sirinity_Client.Tools;

namespace Chat_Sirinity_Client.Pages;

public partial class RegisterPage : Page
{
    readonly Frame _mainFrame = MainWindow.MainFrameInstance;

    public RegisterPage()
    {
        InitializeComponent();
    }

    private bool CheckLengthOfPasswordFields(TextBox loginTb)
    {
        if (loginTb.Text.Length < 8)
        {
            SetErrorLabelVisibility(Visibility.Visible);
            SetErrorLabelContent("Пароль должен содержать более семи символов!");
            return false;
        }
        return true;
    }

    private bool CheckPasswordFieldsOnSimilarity(TextBox passwordTb, TextBox confirmPasswordTb)
    {
        if (!passwordTb.Text.Equals(confirmPasswordTb.Text))
        {
            SetErrorLabelVisibility(Visibility.Visible);
            SetErrorLabelContent("Пароли должны совпадать!");
            return false;
        }
        return true;
    }

    private bool CheckOnEmptyFields(TextBox loginTb, TextBox emailTb)
    {
        if (loginTb.Text.Length.Equals(0) || emailTb.Text.Length.Equals(0))
        {
            SetErrorLabelVisibility(Visibility.Visible);
            SetErrorLabelContent("Имя и почта не должны быть пустыми!");
            return false;
        }
        return true;
    }
    private void RegisterBtn_CLick(object sender, EventArgs e)
    {
        if (CheckLengthOfPasswordFields(PasswordTb) && CheckPasswordFieldsOnSimilarity(PasswordTb, ConfirmPasswordTb)
            && CheckOnEmptyFields(LoginTb, EmailTb))
        {
            TCP tcp = new();
            tcp.ConnectToChat(LoginTb.Text, PasswordTb.Text, _mainFrame, null, this);
        }
    }

    private void BackToWelcomePageBtn_Click(object sender, EventArgs e)
    {
        _mainFrame.Content = new WelcomePage();
    }

    public void SetErrorLabelVisibility(Visibility visibility)
    {
        ErrorRegisterLabel.Visibility = visibility;
    }

    public void SetErrorLabelContent(string content)
    {
        ErrorRegisterLabel.Content = content;
    }

    private void RegisterTb_KeyDown(object sender, EventArgs e)
    {
        ErrorRegisterLabel.Visibility = Visibility.Collapsed;
    }
}
