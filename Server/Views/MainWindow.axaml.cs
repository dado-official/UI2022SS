using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DynamicData;
using UIServer.Models;
using UIServer.ViewModels;

namespace UIServer.Views;

public partial class MainWindow : Window
{
    public static List<JSONModel.ApplicationF>? List;
    public static List<JSONModel.Shortcut> Comm = new List<JSONModel.Shortcut>();

    public MainWindow()
    {
        InitializeComponent();
        Console.WriteLine("MainWindow");
        LoadJson();
    }

    private void LoadJson()
    {
        var text = File.ReadAllText("../../../file.json");
        List = JsonSerializer.Deserialize<List<JSONModel.ApplicationF>>(text);
        Console.WriteLine("Load Json");
        var collection = List?[0].commands;
        if (collection != null) Comm.Add(collection);
    }

    public static void ChangeApplication(string application)
    {
        Comm.Clear();
        var isFound = false;
        Console.WriteLine(application);
        foreach (var apl in List)
                if (application.Contains(apl.name))
                {
                    foreach (var sh in apl.commands)
                    {
                        Console.WriteLine(sh.shortCut + " ---- " + sh.imageUrl);
                        Comm.Add(sh);
                    }
                    isFound = true;
                    break;
                }

        if (!isFound)
        {
            foreach (var sh in List[0].commands)
            {
                //Console.WriteLine(sh.keys);
                Comm.Add(sh);
            }
        }
        MainWindowViewModel.SetIcons(Comm);
    }

    
    private void Button_OnClick_6(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(Comm[0].shortCut);
        MainWindowViewModel._connection.SendLine(Comm[0].shortCut);
    }
    private void Button_OnClick_1(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(1);
        MainWindowViewModel._connection.SendLine(Comm[1].shortCut);
    }
    

    private void Button_OnClick_2(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(2);
        MainWindowViewModel._connection.SendLine(Comm[2].shortCut);
    }

    private void Button_OnClick_3(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(3);
        MainWindowViewModel._connection.SendLine(Comm[3].shortCut);
    }

    private void Button_OnClick_4(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(4);
        MainWindowViewModel._connection.SendLine(Comm[4].shortCut);
    }

    private void Button_OnClick_5(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine(5);
        MainWindowViewModel._connection.SendLine(Comm[5].shortCut);
    }
}