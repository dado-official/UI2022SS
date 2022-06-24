using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UIServer.Models;

public class Connection
{
    private IPHostEntry _ipHost;
    private IPAddress _ipAddr;
    private IPEndPoint _localEndPoint;
    private Socket _listener;
    private Socket _clientSocket;
    public Connection()
    {
        _ipHost = Dns.GetHostEntry(Dns.GetHostName());
        _ipAddr = _ipHost.AddressList[0];
        _localEndPoint = new IPEndPoint(_ipAddr, 11111);
        Console.WriteLine("Starting Server on " + _ipAddr);
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
    
            string? message = ReadLine();
            Console.WriteLine(message);
            SendLine("bubububububu");
           


        
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected exception : {0}", e.ToString());
    
        }

    }
    
    public int SendLine(string str)
    {
        byte[] messageSent = Encoding.ASCII.GetBytes(str);
        int byteSent = _clientSocket.Send(messageSent);
        return byteSent;
    }

    public string? ReadLine()
    {
        
        byte[] bytes = new Byte[1024];
        string data = null;

        int numByte = _clientSocket.Receive(bytes);
             
        data += Encoding.ASCII.GetString(bytes,
            0, numByte);

        return data;


    }
}