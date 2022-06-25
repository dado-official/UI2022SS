using System.Collections.Generic;
using Avalonia.Controls;
using UIServer.Models;

namespace UIServer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static Connection _connection;
    public Image image1;
    public Image image2;


    public MainWindowViewModel()
    {
        _connection = new Connection();
        _connection.Start();
    }

    public static void SetIcons(List<JSONModel.Shortcut> list)
    {
        
    }

    public int ButtonMargin { get; set; }
}