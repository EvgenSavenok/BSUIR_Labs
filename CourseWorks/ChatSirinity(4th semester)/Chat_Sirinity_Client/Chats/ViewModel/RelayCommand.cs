using System.Windows.Input;

namespace Chat_Sirinity_Client.Chats;

public class RelayCommand : ICommand
{
    #region Private Members
    
    private Action mAction;

    #endregion

    #region Public Events
    
    public event EventHandler CanExecuteChanged = (sender, e) => { };

    #endregion

    #region Constructor
    
    public RelayCommand(Action action)
    {
        mAction = action;
    }

    #endregion

    #region Command Methods
    
    public bool CanExecute(object parameter)
    {
        return true;
    }
    
    public void Execute(object parameter)
    {
        mAction();
    }

    #endregion
}
