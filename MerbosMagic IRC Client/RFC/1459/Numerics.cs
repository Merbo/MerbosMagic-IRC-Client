using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_Numerics : RFC
    {
        private static void StatusAdd(string text)
        {
            Program.M.ChatAdd("page_Status", text);
        }
        public static void RPL_WELCOME_001(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(RestOfIt.Remove(0, 1));
        }
        public static void RPL_YOURHOST_002(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(RestOfIt.Remove(0, 1));
        }
        public static void RPL_CREATED_003(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(RestOfIt.Remove(0, 1));
        }
        public static void RPL_MYINFO_004(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(RestOfIt);
        }
        public static void RPL_MYINFO_005(string input)
        {
            string[] commands = input.Split(' ');
            string RestOfIt = String.Join(" ", commands, 3, commands.Length - 3);
            StatusAdd(RestOfIt);
        }




        public static void RPL_NAMREPLY_353(string input)
        {
            //:merbosmagic.org 353 ClientTest = #MerbosMagic :Triclops200 !StatServ !MMServiceBot xaxes !Merbo ClientTest 
            string[] split = input.Split(' ');
            string chan = split[4];
            string[] nicks = input.Remove(0, 1).Split(':');
            string[] nicksonchan = nicks[1].Split(' ');
            List<string> alldemnicks = nicksonchan.ToList<string>();
            foreach (string nick in alldemnicks)
            {
                Program.M.UserAdd(chan.Remove(0, 1), nick);
            }
        }
    }
}
