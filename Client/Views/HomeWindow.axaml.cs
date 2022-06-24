using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using desktop_client.ViewModels;

namespace desktop_client.Views;

public partial class HomeWindow : ReactiveWindow<MainWindowViewModel>



{
    public HomeWindow()
    {
        InitializeComponent();

    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}