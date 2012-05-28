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
            Program.M.ChatAdd("debugPage", "<-- " + raw);
#endif
            string[] commands = raw.Split(' ');
            if (commands[0] == "PING")
            {
                RFC_1459_Commands.PONG(commands[1]);
            }
            else
            {
                string whattheysaid = "";
                string whotheyare = "";
                string nicksep = "";
                int i = 0;
                string text = "";
                string AllArgs = String.Join(" ", commands, 2, commands.Length - 2); 
                switch (commands[1])
                {
                    #region Show PRIVMSGs
                    case "PRIVMSG":
                        whattheysaid = String.Join(" ", commands, 3, commands.Length - 3).Remove(0, 1);
                        whotheyare = commands[0].Remove(0, 1);
                        nicksep = "!";
                        i = whotheyare.IndexOf(nicksep);
                        if (i >= 0)
                        {
                            whotheyare = whotheyare.Remove(i, whotheyare.Length - i);
                        }
                        text = "<" + whotheyare + "> " + whattheysaid;
                        Program.M.ChatAdd(commands[2].Remove(0, 1), text);
                        break;
                    #endregion
                    #region Show NOTICEs
                    case "NOTICE":
                        whattheysaid = String.Join(" ", commands, 3, commands.Length - 3).Remove(0, 1);
                        whotheyare = commands[0].Remove(0, 1);
                        nicksep = "!";
                        i = whotheyare.IndexOf(nicksep);
                        if (i >= 0)
                        {
                            whotheyare = whotheyare.Remove(i, whotheyare.Length - i);
                        }
                        text = "-" + whotheyare + "- " + whattheysaid;
                        Program.M.ChatAdd(commands[2].Remove(0, 1), text);
                        break;
                    #endregion
                    #region Numerics
                    case "353":
                        RFC_1459_Numerics.RPL_NAMREPLY(AllArgs);
                        break;
                    #endregion
                }
            }
        }
    }
}
