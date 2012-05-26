using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

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

            IRCClient = new TcpClient(server, port); //Connect to the server

            IRCStream = IRCClient.GetStream(); //Initialize the stream

            IRCReader = new StreamReader(IRCStream); //Initialize the Reader
            IRCWriter = new StreamWriter(IRCStream); //Initialize the Writer

            PostConnect();
        }

        public static bool alive = true;
        public static void PostConnect() {
            SendRaw("NICK ClientTest");
            SendRaw("USER ClientTest 0 * :Ethan Carr");

            ReadInput();
        }

        public static void ProcessRaw(string raw) {
#if DEBUG
            Program.M.ChatAdd("<-- " + raw);
#endif
            string[] commands = raw.Split(' ');
            if (commands[0] == "PING")
            {
                SendRaw("PONG " + commands[1]);
            }
            else
            {
                
            }
        }

        public static void ReadInput()
        {
            while (true)
            {
                string input;

                input = IRCReader.ReadLine();

                try
                {
                    if (input != null)
                    {
                        ProcessRaw(input);
                        Thread.Sleep(50);
                    }
                }
                catch (NullReferenceException)
                {

                }
            }
        }

        public static void SendRaw(string raw)
        {
#if DEBUG
            Program.M.ChatAdd("--> " + raw);
#endif
            if (IRCClient.Connected)
            {
                IRCWriter.WriteLine(raw);
                IRCWriter.Flush();
            }
        }
        public static void SendCommand(string cmd)
        {
            string[] commands = cmd.Split(' ');
            switch (commands[0].ToLower())
            {
                case "/msg":
                    SendRaw("PRIVMSG " + commands[1] + " :" + commands[2]);
                    break;
                case "/notice":
                    SendRaw("NOTICE");
                    break;
            }
        }
    }
}
