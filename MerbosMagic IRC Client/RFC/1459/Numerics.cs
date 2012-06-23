using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_Numerics : RFC
    {
        private static int CompareNicks(string x, string y)
        {
            string pNickx, pNicky, aNickx, aNicky;

            if (x != null && x != "")
            {
                pNickx = x.Substring(0, 1);
            }
            else return 0;
            
            if (y != null && y != "")
            {
                pNicky = y.Substring(0, 1);
            }
            else return 0;

            int xValue, yValue, xNick, yNick;

            #region switch (pNickx)
            switch (pNickx)
            {
                case "+":
                    xValue = 1;
                    break;
                case "%":
                    xValue = 2;
                    break;
                case "@":
                    xValue = 3;
                    break;
                case "&":
                    xValue = 4;
                    break;
                case "=":
                    xValue = 5;
                    break;
                case "~":
                    xValue = 6;
                    break;
                case ".":
                    xValue = 7;
                    break;
                default:
                    xValue = 0;
                    break;
            }
            #endregion
            #region switch (pNicky)
            switch (pNicky)
            {
                case "+":
                    yValue = 1;
                    break;
                case "%":
                    yValue = 2;
                    break;
                case "@":
                    yValue = 3;
                    break;
                case "&":
                    yValue = 4;
                    break;
                case "=":
                    yValue = 5;
                    break;
                case "~":
                    yValue = 6;
                    break;
                case ".":
                    yValue = 7;
                    break;
                default:
                    yValue = 0;
                    break;
            }
            #endregion

            aNickx = xValue == 0 ? pNickx : x.Substring(1, 1);
            aNicky = yValue == 0 ? pNicky : y.Substring(1, 1);

            #region switch (aNickx)
            switch (aNickx)
            {
                case "Z":
                    xNick = 0;
                    break;
                case "z":
                    xNick = 1;
                    break;
                case "Y":
                    xNick = 2;
                    break;
                case "y":
                    xNick = 3;
                    break;
                case "X":
                    xNick = 3;
                    break;
                case "x":
                    xNick = 4;
                    break;
                case "W":
                    xNick = 5;
                    break;
                case "w":
                    xNick = 6;
                    break;
                case "V":
                    xNick = 7;
                    break;
                case "v":
                    xNick = 8;
                    break;
                case "U":
                    xNick = 9;
                    break;
                case "u":
                    xNick = 10;
                    break;
                case "T":
                    xNick = 11;
                    break;
                case "t":
                    xNick = 12;
                    break;
                case "S":
                    xNick = 13;
                    break;
                case "s":
                    xNick = 14;
                    break;
                case "R":
                    xNick = 15;
                    break;
                case "r":
                    xNick = 16;
                    break;
                case "Q":
                    xNick = 17;
                    break;
                case "q":
                    xNick = 18;
                    break;
                case "P":
                    xNick = 19;
                    break;
                case "p":
                    xNick = 20;
                    break;
                case "O":
                    xNick = 21;
                    break;
                case "o":
                    xNick = 22;
                    break;
                case "N":
                    xNick = 23;
                    break;
                case "n":
                    xNick = 24;
                    break;
                case "M":
                    xNick = 25;
                    break;
                case "m":
                    xNick = 26;
                    break;
                case "L":
                    xNick = 27;
                    break;
                case "l":
                    xNick = 28;
                    break;
                case "K":
                    xNick = 29;
                    break;
                case "k":
                    xNick = 30;
                    break;
                case "J":
                    xNick = 31;
                    break;
                case "j":
                    xNick = 32;
                    break;
                case "I":
                    xNick = 33;
                    break;
                case "i":
                    xNick = 34;
                    break;
                case "H":
                    xNick = 35;
                    break;
                case "h":
                    xNick = 36;
                    break;
                case "G":
                    xNick = 37;
                    break;
                case "g":
                    xNick = 38;
                    break;
                case "F":
                    xNick = 38;
                    break;
                case "f":
                    xNick = 39;
                    break;
                case "E":
                    xNick = 40;
                    break;
                case "e":
                    xNick = 41;
                    break;
                case "D":
                    xNick = 42;
                    break;
                case "d":
                    xNick = 43;
                    break;
                case "C":
                    xNick = 44;
                    break;
                case "c":
                    xNick = 45;
                    break;
                case "B":
                    xNick = 46;
                    break;
                case "b":
                    xNick = 47;
                    break;
                case "A":
                    xNick = 48;
                    break;
                case "a":
                    xNick = 49;
                    break;
                default:
                    xNick = 50;
                    break;
            }
            #endregion
            #region switch (aNicky)
            switch (aNicky)
            {
                case "Z":
                    yNick = 0;
                    break;
                case "z":
                    yNick = 1;
                    break;
                case "Y":
                    yNick = 2;
                    break;
                case "y":
                    yNick = 3;
                    break;
                case "X":
                    yNick = 3;
                    break;
                case "x":
                    yNick = 4;
                    break;
                case "W":
                    yNick = 5;
                    break;
                case "w":
                    yNick = 6;
                    break;
                case "V":
                    yNick = 7;
                    break;
                case "v":
                    yNick = 8;
                    break;
                case "U":
                    yNick = 9;
                    break;
                case "u":
                    yNick = 10;
                    break;
                case "T":
                    yNick = 11;
                    break;
                case "t":
                    yNick = 12;
                    break;
                case "S":
                    yNick = 13;
                    break;
                case "s":
                    yNick = 14;
                    break;
                case "R":
                    yNick = 15;
                    break;
                case "r":
                    yNick = 16;
                    break;
                case "Q":
                    yNick = 17;
                    break;
                case "q":
                    yNick = 18;
                    break;
                case "P":
                    yNick = 19;
                    break;
                case "p":
                    yNick = 20;
                    break;
                case "O":
                    yNick = 21;
                    break;
                case "o":
                    yNick = 22;
                    break;
                case "N":
                    yNick = 23;
                    break;
                case "n":
                    yNick = 24;
                    break;
                case "M":
                    yNick = 25;
                    break;
                case "m":
                    yNick = 26;
                    break;
                case "L":
                    yNick = 27;
                    break;
                case "l":
                    yNick = 28;
                    break;
                case "K":
                    yNick = 29;
                    break;
                case "k":
                    yNick = 30;
                    break;
                case "J":
                    yNick = 31;
                    break;
                case "j":
                    yNick = 32;
                    break;
                case "I":
                    yNick = 33;
                    break;
                case "i":
                    yNick = 34;
                    break;
                case "H":
                    yNick = 35;
                    break;
                case "h":
                    yNick = 36;
                    break;
                case "G":
                    yNick = 37;
                    break;
                case "g":
                    yNick = 38;
                    break;
                case "F":
                    yNick = 38;
                    break;
                case "f":
                    yNick = 39;
                    break;
                case "E":
                    yNick = 40;
                    break;
                case "e":
                    yNick = 41;
                    break;
                case "D":
                    yNick = 42;
                    break;
                case "d":
                    yNick = 43;
                    break;
                case "C":
                    yNick = 44;
                    break;
                case "c":
                    yNick = 45;
                    break;
                case "B":
                    yNick = 46;
                    break;
                case "b":
                    yNick = 47;
                    break;
                case "A":
                    yNick = 48;
                    break;
                case "a":
                    yNick = 49;
                    break;
                default:
                    yNick = 50;
                    break;
            }
            #endregion


            if (xValue > yValue)
            {
                return -1; //X has a higher rank
            }
            else if (xValue == yValue)
            {
                if (xNick > yNick)
                {
                    return -1; //Same rank, but X is higher in the alphabet
                }
                else if (xNick < yNick)
                {
                    return 1;  //Same rank, but Y is higher in the alphabet
                }
                else
                {
                    return 0; //The fuck is this shit?
                }
            }
            else if (xValue < yValue)
            {
                return 1; //Y has a higher rank
            }
            else
            {
                return 0; //The fuck is this shit?
            }
                   
        }

        public static string FormatInfo = "\x03"+"02\x1d"; // italic, blue
        public static string FormatMsgYourHost = "\x03"+"08\x1d"; // italic, yellow
        public static string FormatError = "\x03"+"04\x02"; // bold, red

        private static void StatusAdd(string text)
        {
            Program.M.ChatAdd("page_Status", text);
        }

        private static void ErrorAdd(string text)
        {
            StatusAdd(FormatError + text);
        }

        public static void RPL_WELCOME_001(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(FormatInfo + RestOfIt.Remove(0, 1));
        }
        public static void RPL_YOURHOST_002(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(FormatMsgYourHost + RestOfIt.Remove(0, 1));
        }
        public static void RPL_CREATED_003(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(FormatInfo + RestOfIt.Remove(0, 1));
        }
        public static void RPL_MYINFO_004(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(FormatInfo + RestOfIt);
        }
        public static void RPL_ISUPPORT_005(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(FormatInfo + RestOfIt);
        }

        public static void RPL_NAMREPLY_353(string input)
        {
            //:merbosmagic.org 353 ClientTest = #MerbosMagic :Triclops200 !StatServ !MMServiceBot xaxes !Merbo ClientTest 
            string[] split = input.Split(' ');
            string chan = split[4];
            string[] nicks = input.Remove(0, 1).Split(':');
            string[] nicksonchan = nicks[1].Split(' ');
            List<string> alldemnicks = nicksonchan.ToList<string>();
            alldemnicks.Sort(CompareNicks);

            Program.M.UserClear(chan.Remove(0, 1));
            foreach (string nick in alldemnicks)
            {
                if (nick != "")
                {
                    Program.M.UserAdd(chan.Remove(0, 1), nick);
                }
            }
        }

        public static void ERR_NOSUCHNICK_401(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOSUCHSERVER_402(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOSUCHCHANNEL_403(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_CANNOTSENDTOCHAN_404(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_TOOMANYCHANNELS_405(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_WASNOSUCHNICK_406(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_TOOMANYTARGETS_407(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOORIGIN_409(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NORECIPIENT_411(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NOTEXTTOSEND_412(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NOTOPLEVEL_413(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_WILDTOPLEVEL_414(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_UNKNOWNCOMMAND_421(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOMOTD_422(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NOADMININFO_423(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_FILEERROR_424(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NONICKNAMEGIVEN_431(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_ERRONEUSNICKNAME_432(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NICKNAMEINUSE_433(string input)
        {
            string[] commands = input.Split(' ');
            RFC_1459_Commands.NICK(IRC.nick + "_");
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NICKCOLLISION_436(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_USERNOTINCHANNEL_441(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOTONCHANNEL_442(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_USERONCHANNEL_443(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOLOGIN_444(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_SUMMONDISABLED_445(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_USERDISABLED_446(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NOTREGISTERED_451(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NEEDMOREPARAMS_461(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_ALREADYREGISTERED_462(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NOPERMFORHOST_463(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_PASSWDMISMATCH_464(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_YOUREBANNEDCREEP_465(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_KEYSET_467(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_CHANNELISFULL_471(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_UNKNOWNMODE_472(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_INVITEONLYCHAN_473(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_BANNEDFROMCHAN_474(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_BADCHANNELKEY_475(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt);
        }
        public static void ERR_NOPRIVILEGES_481(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_CHANOPRIVSNEEDED_482(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_CANTKILLSERVER_483(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_NOOPERHOST_491(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_UMODEUNKNOWNFLAG_501(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
        public static void ERR_USERSDONTMATCH_502(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            ErrorAdd(RestOfIt.Remove(0, 1));
        }
    }
}
