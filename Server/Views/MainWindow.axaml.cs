using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using DynamicData;
using Tmds.DBus;
using UIServer.Models;
using UIServer.ViewModels;

namespace UIServer.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("MainWindow");
            LoadJson();
        }

        public static List<JSONModel.ApplicationF> list;
        private void LoadJson()
        {
            string text = File.ReadAllText("../../../file.json");
            list = JsonSerializer.Deserialize<List<JSONModel.ApplicationF>>(text);
        }

        public static void ChangeApplication(string application)
        {
            bool isFound = false;
            foreach (var apl in list)
            {
                if (application.Contains(apl.name))
                {
                    Console.WriteLine("Got The appl");
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                
            }
            else
            {
                Console.WriteLine("no appl found --> default");
            }
        }
        
        public static void ExecuteCommand(string commad)
        {
            Process proc = new System.Diagnostics.Process ();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + "xdotool key " + commad + " \"";
            proc.StartInfo.UseShellExecute = false; 
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start ();
        }

        private void Button_OnClick_0(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(0);
            //MainWindowViewModel._connection.SendLine("space");
        }
        
        private void Button_OnClick_1(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(1);
            //MainWindowViewModel._connection.SendLine("");
        }
        
        private void Button_OnClick_2(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(2);
            //MainWindowViewModel._connection.SendLine("Button2");

        }
        
        private void Button_OnClick_3(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(3);
            //MainWindowViewModel._connection.SendLine("Button3");

        }
        
        private void Button_OnClick_4(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(4);
            //MainWindowViewModel._connection.SendLine("Button4");

        }
        
        private void Button_OnClick_5(object? sender, RoutedEventArgs e)
        {
            Console.WriteLine(5);
            MainWindowViewModel._connection.SendLine("asd");

        }
        

    }
}