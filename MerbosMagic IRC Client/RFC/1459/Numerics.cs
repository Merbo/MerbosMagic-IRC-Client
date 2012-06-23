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
            string pNickx, pNicky;

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

            int xValue, yValue;

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

            if (xValue > yValue)
            {
                return -1; //Variable x is bigger
            }
            else if (xValue == yValue)
            {
                return 0; //Both variables are the same :<
            }
            else if (xValue < yValue)
            {
                return 1; //Variable y is bigger
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
