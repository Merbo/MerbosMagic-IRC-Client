using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client
{
    class RFC_1459_Commands
    {
        

        public static void PASS(string password)
        {
            IRC.SendRaw("PASS " + password);
            Program.M.ChatAdd("Password sent.");
        }
        public static void NICK(string nick)
        {
            IRC.SendRaw("NICK " + nick);
            Program.M.ChatAdd("You are now known as " + nick);
        }
        public static void USER(string user, string host, string server, string real)
        {
            IRC.SendRaw("USER " + user + " " + host + " " + server + " :" + real);
            Program.M.ChatAdd("You have identified as user " + user + " with real name " + real);
        }
        public static void OPER(string user, string password)
        {
            IRC.SendRaw("OPER " + user + " " + password);
            Program.M.ChatAdd("You have \"Opered Up\"!");
        }
        public static void QUIT(string quitMessage)
        {
            IRC.SendRaw("QUIT :" + quitMessage);
            Program.M.ChatAdd("You've quit with message \"" + quitMessage + "\"");
        }
        public static void JOIN(string channel, string key = "")
        {
            if (key != "")
            {
                IRC.SendRaw("JOIN " + channel + " " + key);
            }
            else
            {
                IRC.SendRaw("JOIN " + channel); 
            }
            Program.M.AddPage(channel.Remove(0, 1), channel);
            Program.M.ChatAdd(channel.Remove(0, 1), "You have joined " + channel);
        }
        public static void PART(string channel, string partMessage = "")
        {
            if (partMessage != "")
            {
                IRC.SendRaw("PART " + channel + " :" + partMessage); 
            }
            else
            {
                IRC.SendRaw("PART " + channel);
            }
            Program.M.RemovePage(channel);
            Program.M.ChatAdd("You have left channel " + channel);
        }
        public static void MODE(string channel, string mode)
        {
            /*
             * I need to process this through the RFC mode handlers.
             */
        }
        public static void TOPIC(string channel, string topic = "")
        {
            if (topic != "")
            {
                IRC.SendRaw("TOPIC " + channel + " :" + topic);
            }
            else
            {
                IRC.SendRaw("TOPIC " + channel);
            }
            Program.M.ChatAdd(channel, "Set topic of " + channel + " to " + topic);
        }
    }
}
