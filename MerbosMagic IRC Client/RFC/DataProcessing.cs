using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class DataProcessing : RFC
    {
        public static void ProcessSend(string raw)
        {
            string[] commands = raw.Split(' ');
            try
            {
                string chan = "";
                string msgargs = "";
                string allargs = "";
                if (commands.Length > 0)
                {
                    chan = commands[1];
                    allargs = String.Join(" ", commands, 1, commands.Length - 1);
                }
                if (commands.Length > 1)
                {
                    msgargs = String.Join(" ", commands, 2, commands.Length - 2);
                }
                switch (commands[0].ToLower().Remove(0, 1))
                {
                    case "msg":
                        RFC_1459_Commands.PRIVMSG(chan, msgargs);
                        break;
                    case "privmsg":
                        RFC_1459_Commands.PRIVMSG(chan, msgargs);
                        break;
                    case "notice":
                        RFC_1459_Commands.NOTICE(chan, msgargs);
                        break;
                    case "join":
                        RFC_1459_Commands.JOIN(chan);
                        break;
                    case "part":
                        if (msgargs != "")
                        {
                            RFC_1459_Commands.PART(chan, msgargs);
                        }
                        else
                        {
                            RFC_1459_Commands.PART(chan);
                        }
                        break;
                    case "quit":
                        if (allargs != "")
                        {
                                RFC_1459_Commands.QUIT(allargs);
                        }
                        else
                        {
                            RFC_1459_Commands.QUIT();
                        }
                        break;
                    case "nick":
                        RFC_1459_Commands.NICK(commands[1]);
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Program.M.ChatAdd("Not enough parameters!");
            }
        }
        public static void ProcessRecv(string raw)
        {
#if DEBUG
            Program.M.ChatAdd("page_debugPage", "<-- " + raw);
#endif
            int num = 0;
            string[] commands = raw.Split(' ');
            if (int.TryParse(commands[1], out num))
            {
                Numerics.Parse(raw);
            }
            else
            {
                Commands.Parse(raw);
            }
        }
    }
}
