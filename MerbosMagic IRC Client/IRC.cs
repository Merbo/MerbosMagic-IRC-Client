using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace MerbosMagic_IRC_Client
{
    class IRC
    {
        public static TcpClient IRCClient;
        public static NetworkStream IRCStream;
        public static StreamReader IRCReader;
        public static StreamWriter IRCWriter;
        public static string nick = "ClientTest";
        public static string user = "Ethan Carr";
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
            SendRaw("NICK " + nick);
            SendRaw("USER " + nick + " 0 * :" + user);

            ReadInput();
        }

        public static void ProcessRaw(string raw) {
#if DEBUG
            Program.M.ChatAdd("debugPage", "<-- " + raw);
#endif
            string[] commands = raw.Split(' ');
            if (commands[0] == "PING")
            {
                SendRaw("PONG " + commands[1]);
            }
            else
            {
                switch (commands[1])
                {
                    case "JOIN":
                        if (commands[0].StartsWith(":" + nick))
                        {
                            Program.M.AddPage(commands[2].Remove(0, 2), commands[2].Remove(0, 1));
                        }
                        break;
                    case "PRIVMSG":
                        string whattheysaid = String.Join(" ", commands, 3, commands.Length - 3).Remove(0, 1);
                        string whotheyare = commands[0].Remove(0, 1);
                        string nicksep = "!";
                        int i = whotheyare.IndexOf(nicksep);
                        if (i >= 0)
                        {
                            whotheyare = whotheyare.Remove(i, whotheyare.Length - i);
                        }
                        string text = "<" + whotheyare + "> " + whattheysaid;
                        Program.M.ChatAdd(commands[2].Remove(0, 1), text);
                        break;
                }
            }
        }

        public static void ReadInput()
        {
            while (true)
            {
                string input;

                try
                {
                    input = IRCReader.ReadLine();

                    if (input != null)
                    {
                        ProcessRaw(input);
                        //Thread.Sleep(25);
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
            Program.M.ChatAdd("debugPage", "--> " + raw);
#endif
            string[] commands = raw.Split(' ');

            if (commands[0].ToUpper() == "PRIVMSG")
            {
                Program.M.ChatAdd(commands[1].Remove(0, 1), "<" + nick + "> " + String.Join(" ", commands, 2, commands.Length - 2).Remove(0, 1));
            }
            if (commands[0].ToUpper() == "NICK")
            {
                nick = commands[1];
                Program.M.ChatAdd("You are now known as " + nick + ".");
            }

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
