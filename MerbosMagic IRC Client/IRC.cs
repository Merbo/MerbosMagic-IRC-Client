using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MerbosMagic_IRC_Client
{
    class IRC
    {
        public static TcpClient IRCClient;
        public static NetworkStream IRCStream;
        public static StreamReader IRCReader;
        public static StreamWriter IRCWriter;
        public static void Connect()
        {
            int port = 6667; //Port to connect on
            string server = "irc.merbosmagic.co.cc"; //Server to connect to

            IRCClient.Connect(server, port); //Connect to the server

            IRCStream = IRCClient.GetStream(); //Initialize the stream

            IRCReader = new StreamReader(IRCStream); //Initialize the Reader
            IRCWriter = new StreamWriter(IRCStream); //Initialize the Writer
        }
        public static void SendRaw(string raw)
        {
            if (IRCClient.Connected)
            {
                IRCWriter.WriteLine(raw);
                IRCWriter.Flush();
            }
        }
        public static void SendCommand(string cmd, string target, string args = "")
        {
            switch (cmd.ToLower())
            {
                case "msg":
                    SendRaw("PRIVMSG" + target + " :" + args);
                    break;
                case "notice":
                    SendRaw("NOTICE" + target + " :" + args);
                    break;
            }
        }
    }
}
