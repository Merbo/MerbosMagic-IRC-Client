using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_Numerics : RFC
    {
        public static void RPL_WELCOME_001(string input)
        {

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
