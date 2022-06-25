using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace desktop_client.Models;

public class Connection
{
    private IPHostEntry _ipHost;
    private IPAddress _ipAddr;
    private IPEndPoint _localEndPoint;
    private Socket _sender;
    public Connection()
    {
        _ipHost = Dns.GetHostEntry(Dns.GetHostName());
        _ipAddr = _ipHost.AddressList[0];
        _localEndPoint = new IPEndPoint(_ipAddr, 9000);
        _sender = new Socket(_ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Start()
    {
        try
        {
            Console.WriteLine("Connecting to Server ...");
            _sender.Connect(_localEndPoint);
            SendLine(Environment.MachineName.ToString());
            string? message = ReadLine();
            Console.WriteLine(message);

            Thread thread = new Thread(ButtonHandler);
            thread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected exception : {0}", e.ToString());

        }
        
    }
    
    private void ButtonHandler()
    {
        Console.WriteLine("Starting Thread");
        while (true)
        {
            string? message = ReadLine();
            Console.WriteLine(message);
            ExecuteCommand(message);
        }
    }
    
    public static void ExecuteCommand(string commad)
    {
        Thread.Sleep(1000);
        Process proc = new System.Diagnostics.Process ();
        proc.StartInfo.FileName = "/bin/bash";
        proc.StartInfo.Arguments = "-c \" " + "xdotool key " + commad + " \"";
        proc.StartInfo.UseShellExecute = false; 
        proc.StartInfo.RedirectStandardOutput = true;
        proc.Start ();
    }
    
    public int SendLine(string? str)
    {
        if (str != null)
        {
            byte[] messageSent = Encoding.ASCII.GetBytes(str);
            int byteSent = _sender.Send(messageSent);
            return byteSent;
        }

        return 0;
    }

    public string? ReadLine() 
    {
        
        byte[] bytes = new Byte[1024];
        string? data = "";
        int numByte = _sender.Receive(bytes);
         
        data += Encoding.ASCII.GetString(bytes,
            0, numByte);
        return data;

    }

    


    
    public int Port { get; set; } 
    public string Address { get; set; } 
    public Boolean Auto { get; set; } 
}