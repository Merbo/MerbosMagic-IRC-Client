﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_Numerics : RFC
    {
        //:merbosmagic.org 353 ClientTest = #MerbosMagic :jenn4 Crunkstar !StatServ !MMServiceBot xaxes !Merbo ClientTest 
        //input starts at the first ClientTest
        public static void RPL_NAMREPLY(string input)
        {
            string[] commands = input.Split(' ');
            commands[3] = commands[3].Remove(0, 1);
            string[] nicks = String.Join(" ", commands, 3, commands.Length - 3).Split(' ');
            List<string> nickslist = nicks.ToList<string>();
            foreach (string nick in nickslist)
            {
                Program.M.UserAdd(commands[2].Remove(0, 1), nick);
            }
        }
    }
}
