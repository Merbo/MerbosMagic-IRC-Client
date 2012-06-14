using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using MerbosMagic_IRC_Client.RFC;

namespace MerbosMagic_IRC_Client
{
    class IRC
    {
        public static TcpClient IRCClient;
        public static NetworkStream IRCStream;
        public static StreamReader IRCReader;
        public static StreamWriter IRCWriter;
        public static string nick = Environment.UserName.Replace(" ","");                                //Nick
        public static string user = Environment.UserName;                                //Real name
        public static int port = 6667;                                             //Port to connect on
        public static string server = "chat.freenode.net";                         //Server to connect to
        public static VersionClass version = new VersionClass(1,5,4);                                     //Client version :D
        public static string longversion = "MerbosMagic IRC Client Version " + version; //Longer client version :D
        public static void Connect()
        {
            try 
            {
                IRCClient = new TcpClient(server, port); //Connect to the server
            }
            catch (SocketException) 
            {
                return;
            }

            IRCStream = IRCClient.GetStream(); //Initialize the stream

            IRCReader = new StreamReader(IRCStream); //Initialize the Reader
            IRCWriter = new StreamWriter(IRCStream); //Initialize the Writer

            PostConnect();
        }

        public static bool alive = true;
        public static void PostConnect()
        {
            RFC_1459_Commands.NICK(nick);
            RFC_1459_Commands.USER(nick, "*", "0", user);

            ReadInput();
        }

        public static void ReadInput()
        {
            while (true) {
                string input;

                try {
                    input = IRCReader.ReadLine();

                    if (input != null) {
                        DataProcessing.ProcessRecv(input);
                    }
                }
                catch (NullReferenceException) {
                    break;
                }
                catch (IOException) {
                    break;
                }
                catch (ObjectDisposedException) {
                    break;
                }
            }
        }

        public static void SendRaw(string raw)
        {
#if DEBUG
            Program.M.ChatAdd("page_debugPage", "--> " + raw);
#endif
            if (IRCClient.Connected) {
                IRCWriter.WriteLine(raw);
                IRCWriter.Flush();
            }
        }
        public static void SendCommand(string cmd)
        {
            //Process this later using RFC1459/RFCInsp
        }
    }
}
