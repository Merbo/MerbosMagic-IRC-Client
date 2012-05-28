using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class Commands
    {
        public static void Parse(string input)
        {
            try
            {
                string[] commands = input.Split(' ');
                if (commands[0] == "PING")
                {
                    RFC_1459_Commands.PONG(commands[1]);
                }
                else
                {
                    #region Get the args
                    string args;
                    if (commands.Length > 2)
                    {
                        args = String.Join(" ", commands, 2, commands.Length - 2);
                    }
                    else
                    {
                        args = "";
                    }
                    #endregion
                    #region Get the nick, user, and host
                    //Input:
                    //:nick!user@host

                    string nick, user, host; //null
                    string tmpString; //null
                    string[] tmpArray; //null
                    //Let's get the nick
                    tmpString = commands[0].Remove(0, 1); //nick!user@host
                    tmpArray = tmpString.Split('!'); //nick | user@host
                    tmpString = tmpArray[0]; //nick
                    nick = tmpString; //nick
                    //Let's get the user
                    tmpString = tmpArray[1]; //user@host
                    tmpArray = tmpString.Split('@'); //user | host
                    tmpString = tmpArray[0]; //user
                    user = tmpString; //user
                    //Let's get the host
                    tmpString = tmpArray[1]; //host
                    host = tmpString; //host
                    #endregion
                    #region Get the channel
                    string chan;
                    if (commands[2].StartsWith(":"))
                    {
                        commands[2] = commands[2].Remove(0, 1);
                    }
                    chan = commands[2];
                    #endregion
                    #region Get the Tab Name
                    string tabname;
                    tabname = chan;
                    if (tabname.StartsWith("#"))
                    {
                        tabname = tabname.Remove(0, 1);
                    }
                    #endregion
                    #region switch (commands[1])
                    switch (commands[1])
                    {
                        case "JOIN":
                            Program.M.ChatAdd(tabname, nick + " has joined " + chan + ".");
                            if (nick != IRC.nick)
                                Program.M.UserAdd(tabname, nick);
                            break;
                        case "PART":
                            if (args != "")
                                Program.M.ChatAdd(tabname, nick + " has left " + chan + ". (" + args.Remove(0, chan.Length + 2) + ")");
                            else
                                Program.M.ChatAdd(tabname, nick + " has left " + chan + ".");
                            Program.M.UserRemove(chan, nick);
                            break;
                        case "NICK":
                            //NOTES:
                            //In this case, chan is the new nick. Don't get confused.
                            Program.M.ChatAdd(nick + " is now known as " + chan);
                            Program.M.UserRename(nick, chan);
                            break;
                        case "PRIVMSG":
                            Program.M.ChatAdd(tabname, "<" + nick + "> " + args.Remove(0, chan.Length + 2));
                            break;
                        case "NOTICE":
                            Program.M.ChatAdd(tabname, "-" + nick + "- " + args.Remove(0, chan.Length + 2));
                            break;
                    }
                    #endregion
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }
    }
}
