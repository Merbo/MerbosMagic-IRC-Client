﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client.RFC
{
    class DataProcessing : RFC
    {
        public static string GetRest(string[] Array, int Start)
        {
            return String.Join(" ", Array, Start, Array.Length - Start);
        }

        public static void ProcessSend(string raw)
        {
            string[] commands = raw.Split(' ');
            try {
                string chan = "";
                string msgargs = "";

                if (commands.Length > 1) 
                {
                    chan = commands[1];
                }
                if (commands.Length > 2) 
                {
                    msgargs = GetRest(commands, 2);
                }
                if (commands[0].StartsWith("/"))
                {
                    commands[0] = commands[0].Remove(0, 1);
                }
                switch (commands[0]) {
                    case "msg":
                        RFC_1459_Commands.PRIVMSG(chan, msgargs);
                        break;
                    case "describe":
                        CTCP.ACTION(chan, GetRest(commands, 2));
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
                        string rest = GetRest(commands, 1);
                        if (rest != "") 
                        {
                            RFC_1459_Commands.QUIT(rest);
                        } 
                        else 
                        {
                            RFC_1459_Commands.QUIT();
                        }
                        break;
                    case "nick":
                        RFC_1459_Commands.NICK(commands[1]);
                        break;
                    case "query":
                        Program.M.AddPage(commands[1], commands[1]);
                        if (commands.Length > 2) {
                            RFC_1459_Commands.PRIVMSG(commands[1], GetRest(commands, 2));
                        }
                        break;
                    case "server":
                        if (commands.Length > 1)
                        {
                            int port = 6667;
                            if (commands.Length > 2)
                            {
                                bool worked = int.TryParse(commands[2], out port);
                            }
                            RFC_MerbosMagic_IRC_Client_Commands.SERVER(commands[1], port);
                            //Let the client know he's moving to a new server, and close all non-debug/chan windows.
                            Program.M.ChatAdd("page_Status", IRCColorList.Red + "* Disconnected: Switching servers!");
                            Program.M.RemoveAllPages();
                        }
                        break;
                }
            }
            catch (IndexOutOfRangeException) {
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
        public static string ResolveVars(string input)
        {
            string output = input;
            string[] outsplit = output.Split(' ');
            List<string> outlist = outsplit.ToList<string>();

            output = "";

            int i = 0;

            foreach (string s in outlist) {
                i++;
                string tmp = s;
                switch (tmp.ToLower()) {
                    case "$time":
                        tmp = DateTime.Now.ToString();
                        break;
                    case "$version":
                        tmp = IRC.version.ToString();
                        break;
                    case "$longversion":
                        tmp = IRC.longversion.ToString();
                        break;
                    case "$me":
                        tmp = IRC.nick;
                        break;
                    case "$active":
                        TabPage TP;
                        object o = Program.M.GetPage();
                        try
                        {
                            TP = (TabPage)o;
                            tmp = TP.Text;
                        }
                        catch (Exception)
                        {
                            tmp = "$active";
                        }
                        break;

                }
                output += i == outlist.Count ? tmp + "" : tmp + " ";
            }

            return output;
        }
    }
}
