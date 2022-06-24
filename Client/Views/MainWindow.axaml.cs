using System.Threading.Tasks;
using Avalonia.ReactiveUI;
using desktop_client.ViewModels;
using ReactiveUI;

namespace desktop_client.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            
           // this.WhenActivated(d => d(ViewModel!.SettingsDialog.RegisterHandler(DoShowSettingsAsync)));
        }

        

        /*private async Task DoShowSettingsAsync(InteractionContext<SettingsViewModel, MainWindowViewModel?> interaction)
        {
            var dialog = new SettingsWindow();
            dialog.DataContext = interaction.Input;

            var result = await dialog.ShowDialog<MainWindowViewModel?>(this);
            interaction.SetOutput(result);
        }*/
    }
}