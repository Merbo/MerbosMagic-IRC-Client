using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_MerbosMagic_IRC_Client_Commands : RFC
    {
        static Thread RunningIRCThread;
        public static void SERVER(string server, int port = 6667)
        {
            Thread IRCThread = new Thread(IRC.Connect);
            if (IRC.IRCClient != null && IRC.IRCClient.Connected)
            {
                IRC.IRCStream.Close();
            }
            IRC.server = server;
            IRC.port = port;
            IRCThread.Name = "IRCThread";
            IRCThread.IsBackground = true;

            if (RunningIRCThread != null && RunningIRCThread.IsAlive)
            {
                RunningIRCThread.Abort();
                RunningIRCThread = IRCThread;
                RunningIRCThread.Start();
            }
            else
            {
                RunningIRCThread = IRCThread;
                RunningIRCThread.Start();
            }
        }
    }
}
