using System;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Xml;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using DynamicData;
using UIServer.Models;
using UIServer.ViewModels;

namespace UIServer.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_OnClick_0(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(0);
            MainWindowViewModel._connection.SendLine("Button0");

        }
        
        private void Button_OnClick_1(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(1);
            MainWindowViewModel._connection.SendLine("Button1");
        }
        
        private void Button_OnClick_2(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(2);
            MainWindowViewModel._connection.SendLine("Button2");

        }
        
        private void Button_OnClick_3(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(3);
            MainWindowViewModel._connection.SendLine("Button3");

        }
        
        private void Button_OnClick_4(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(4);
            MainWindowViewModel._connection.SendLine("Button4");

        }
        
        private void Button_OnClick_5(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(5);
            MainWindowViewModel._connection.SendLine("Button5");

        }
        

    }
}