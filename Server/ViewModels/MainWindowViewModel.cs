using System;
using System.Reflection.Metadata;
using Avalonia.Controls;
using Avalonia.Interactivity;
using UIServer.Models;

namespace UIServer.ViewModels
{
    
    public class MainWindowViewModel : ViewModelBase
    {
        public static Connection _connection;
        public MainWindowViewModel()
        {
            _connection = new Connection();
            _connection.Start();
        }
        
        public int ButtonMargin{ get; set; }

    }
    
    
    
}