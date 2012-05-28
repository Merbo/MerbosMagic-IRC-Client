using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_Numerics : RFC
    {
        private static void StatusAdd(string text)
        {
            Program.M.ChatAdd("page_Status", text);
        }
        //Go to 4 and remove 1 for everything but numeric 004
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
            string[] commands = input.Split(' ');
            commands[6] = commands[6].Remove(0, 1);
            string[] nicks = String.Join(" ", commands, 6, commands.Length - 6).Split(' ');
            List<string> nickslist = nicks.ToList<string>();
            foreach (string nick in nickslist)
            {
                if (nick != "")
                    Program.M.UserAdd(commands[5].Remove(0, 1), nick);
            }
        }
    }
}
