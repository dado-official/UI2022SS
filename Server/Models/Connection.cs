using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UIServer.Views;

namespace UIServer.Models;

public class Connection
{
    private Socket _clientSocket;
    private readonly IPAddress _ipAddr;
    private readonly IPHostEntry _ipHost;
    private readonly Socket _listener;
    private readonly IPEndPoint _localEndPoint;

    public Connection()
    {
        Console.Write("one");
        _ipHost = Dns.GetHostEntry(Dns.GetHostName());
        _ipAddr = _ipHost.AddressList[1];
        _localEndPoint = new IPEndPoint(_ipAddr, 9000);
        Console.WriteLine("Starting Server on " + _ipAddr + ":" + "9000");
        _listener = new Socket(_ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Start()
    {
        try
        {
            _listener.Bind(_localEndPoint);
            _listener.Listen(10);
            Console.WriteLine("Waiting for connection ...");
            _clientSocket = _listener.Accept();
            Console.WriteLine("Client Connected ...");

            var message = ReadLine();
            Console.WriteLine(message);
            SendLine("iidd");
            var focuser = new Thread(WaitForAppFocus);
            focuser.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected exception : {0}", e);
        }
    }

    public void WaitForAppFocus()
    {
        Console.WriteLine("listening tp applications");

        while (true)
        {
            var application = ReadLine();
            MainWindow.ChangeApplication(application);
        }
    }

    public int SendLine(string str)
    {
        var messageSent = Encoding.ASCII.GetBytes(str);
        var byteSent = _clientSocket.Send(messageSent);
        return byteSent;
    }

    public string? ReadLine()
    {
        var bytes = new byte[1024];
        string data = null;

        var numByte = _clientSocket.Receive(bytes);

        data += Encoding.ASCII.GetString(bytes,
            0, numByte);

        return data;
    }
}