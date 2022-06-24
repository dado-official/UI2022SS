using desktop_client.Models;

namespace desktop_client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Connection connection = new Connection();
        connection.Start();
    }


    // public Interaction<SettingsViewModel, MainWindowViewModel?> SettingsDialog { get; }
}