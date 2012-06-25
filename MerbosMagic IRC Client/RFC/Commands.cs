using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client.RFC
{
    class Commands
    {
        public static string FormatQuit        = IRCColorList.Green;
        public static string FormatJoin        = IRCColorList.Yellow;
        public static string FormatPart        = IRCColorList.Yellow;
        public static string FormatCtcp        = IRCColorList.Orange;
        public static string FormatNickChange  = IRCColorList.Green;
        public static string FormatHighlight   = IRCColorList.Blue;  
        public static string FormatMode        = IRCColorList.Red;


        public static void Parse(string input)
        {
            try {
                string[] commands = input.Split(' ');
                if (commands[0] == "PING") 
                {
                    RFC_1459_Commands.PONG(commands[1]);
                } 
                else 
                {
                    #region Get the args
                    string args = "";
                    if (commands.Length > 2) 
                    {
                        args = commands[2];
                        if (commands.Length > 3)
                            args = String.Join(" ", commands, 2, commands.Length - 2);
                    }
                    #endregion
                    #region Get the nick, user, and host
                    //Input:
                    //:nick!user@host

                    string nick = "", user = "", host = ""; //Empty string
                    string tmpString; //null
                    string[] tmpArray; //null
                    //Let's get the nick
                    if (commands.Length > 0 && commands[0].Contains("!") && commands[0].Contains("@")) 
                    {
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
                    }
                    #endregion
                    #region Get the channel
                    string chan = "";
                    if (commands.Length > 2) 
                    {
                        if (commands[2].StartsWith(":")) 
                        {
                            commands[2] = commands[2].Remove(0, 1);
                        }
                        chan = commands[2];
                    }
                    #endregion
                    #region Get the Tab Name
                    string tabname;
                    tabname = chan;
                    if (tabname.StartsWith("#")) 
                    {
                        tabname = tabname.Remove(0, 1);
                    }
                    #endregion
                    #region CTCP Processing
                    if (commands.Length > 3 && commands[3].StartsWith(":\x01"))
                    {

                        CTCP.SendCTCPReply(nick, commands[3].Remove(0, 1));
                        string c3 = commands[3];
                        c3 = c3.Remove(0, 2);
                        if (c3 == "ACTION")
                        {
                            string rest = DataProcessing.GetRest(commands, 4);
                            Program.M.ChatAdd(chan.Remove(0, 1), "* " + nick + " " + rest.Remove(rest.Length - 1, 1));
                            return;
                        }
                        c3 = c3.Remove(c3.Length - 1, 1);
                        Program.M.ChatAdd(FormatCtcp + "CTCP request \"" + c3 + "\" from " + nick);
                        Program.M.ChatAdd(FormatCtcp + "page_Status", "CTCP request \"" + c3 + "\" from " + nick);
                    }
                    #endregion

                    #region switch (commands[1])
                    else 
                    {
                        switch (commands[1].ToUpper()) 
                        {
                            case "QUIT":
                                if (commands.Length > 3 && args != "")
                                    Program.M.ChatAdd(FormatQuit + nick + " (" + user + "@" + host + ") has quit. (" + args.Remove(0, 1) + ")");
                                else
                                    Program.M.ChatAdd(FormatQuit + nick + " (" + user + "@" + host + ") has quit.");
                                Program.M.UserRemove(nick);
                                break;
                            case "JOIN":
                                Program.M.ChatAdd(tabname, FormatJoin + nick + " (" + user + "@" + host + ") has joined " + chan + ".");
                                if (nick != IRC.nick)
                                    Program.M.UserAdd(tabname, nick);
                                break;
                            case "PART":
                                if (commands.Length > 3 && args != "")
                                    Program.M.ChatAdd(tabname, FormatPart + nick + " (" + user + "@" + host + ") has left " + chan + ". (" + args.Remove(0, chan.Length + 2) + ")");
                                else
                                    Program.M.ChatAdd(tabname, FormatPart + nick + " (" + user + "@" + host + ") has left " + chan + ".");
                                if (nick != IRC.nick)
                                    Program.M.UserRemove(tabname, nick);
                                break;
                            case "NICK":
                                //NOTES:
                                //In this case, chan is the new nick. Don't get confused.
                                Program.M.ChatAdd(FormatNickChange + nick + " is now known as " + chan);
                                Program.M.UserRename(nick, chan);
                                break;
                            case "PRIVMSG":
                                if (chan == IRC.nick) 
                                {
                                    Program.M.ChatAdd(nick, "<" + nick + "> " + args.Remove(0, chan.Length + 2));
                                } 
                                else
                                    Program.M.ChatAdd(tabname, (args.Remove(0, chan.Length + 2).Contains(IRC.nick) ? FormatHighlight : "") + "<" + nick + "> " + args.Remove(0, chan.Length + 2));
                                break;
                            case "NOTICE":
                                if (chan == IRC.nick) 
                                {
                                    Program.M.ChatAdd(FormatHighlight + "-" + nick + "- " + args.Remove(0, chan.Length + 2));
                                } 
                                else
                                    Program.M.ChatAdd(tabname, FormatHighlight + "-" + nick + "- " + args.Remove(0, chan.Length + 2));
                                break;
                            case "MODE":
                                string[] argsplit = args.Split(' ');
                                string trueargs = "", PrintWhat = "";
                                if (argsplit.Length > 2)
                                    trueargs = String.Join(" ", argsplit, 2, argsplit.Length - 2);
                                if (commands.Length > 3)
                                    PrintWhat = RFC_ModeHandler.Handle(nick, chan, commands[3], trueargs);
                                Program.M.ChatAdd(tabname, PrintWhat);
                                break;

                        }
                    }
                    #endregion
                }
            }
            catch (IndexOutOfRangeException ex) 
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            catch (ArgumentOutOfRangeException ex) 
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
    }
}
