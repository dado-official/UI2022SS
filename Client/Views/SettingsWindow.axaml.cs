using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace desktop_client.Views;

public partial class SettingsWindow : UserControl
{
    public SettingsWindow()
    {
        InitializeComponent();
        

    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}