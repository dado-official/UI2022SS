using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using desktop_client.Models;

namespace desktop_client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static Connection? Connection;
    public MainWindowViewModel()
    {
        
        Connection = new Connection();
        Connection.Start();
        Thread sniffer = new Thread(ExecuteCommand);
        sniffer.Start();


    }
    
    
    public static void ExecuteCommand()
    {
        string? last = "";
        while (true)
        {
            Process proc = new System.Diagnostics.Process ();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + "xdotool getactivewindow getwindowname" + " \"";
            proc.StartInfo.UseShellExecute = false; 
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start ();

            while (!proc.StandardOutput.EndOfStream)
            {
                string? appl = proc.StandardOutput.ReadLine();
                if (last != appl)
                {
                    Connection.SendLine(appl);
                    Console.WriteLine("appl " + appl);
                    last = appl;
                }
            }
        }
    }
    
    // public Interaction<SettingsViewModel, MainWindowViewModel?> SettingsDialog { get; }
}

internal class ActiveWindowModel
{
}