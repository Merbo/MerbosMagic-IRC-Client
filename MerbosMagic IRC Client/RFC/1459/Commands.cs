using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_Commands : RFC
    {
        public static void PASS(string password)
        {
            IRC.SendRaw("PASS " + password);
            Program.M.ChatAdd("page_status", "Password sent.");
        }
        public static void NICK(string nick)
        {
            Program.M.ChatAdd("page_Status", "You are now known as " + nick + ".");
            IRC.SendRaw("NICK " + nick);
            IRC.nick = nick;
        }
        public static void USER(string user, string host, string server, string real)
        {
            IRC.SendRaw("USER " + user + " " + host + " " + server + " :" + real);
            Program.M.ChatAdd("page_Status", "You have identified as user " + user + " with real name " + real);
        }
        public static void OPER(string user, string password)
        {
            IRC.SendRaw("OPER " + user + " " + password);
            Program.M.ChatAdd("You have \"Opered Up\"!");
            Program.M.ChatAdd("page_Status", "You have \"Opered Up\"!");
        }
        public static void QUIT(string quitMessage = "")
        {
            if (quitMessage != "")
            {
                IRC.SendRaw("QUIT :" + quitMessage);
                Program.M.ChatAdd("You've quit with message \"" + quitMessage + "\"");
            }
            else
            {
                IRC.SendRaw("QUIT");
                Program.M.ChatAdd("You've quit IRC.");
            }
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
            Program.M.RemovePage(channel.Remove(0, 1));
            Program.M.ChatAdd("You have left channel " + channel);
        }
        public static void MODE(string channel, string mode)
        {
        }//Process these through my Mode Handlers!
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
        }//Shows output of TOPIC in a numeric!
        public static void NAMES(string channel = "")
        {
            if (channel != "")
            {
                IRC.SendRaw("NAMES " + channel);
            }
            else
            {
                IRC.SendRaw("NAMES");
            }
        } //Shows output of NAMES in a numeric!
        public static void LIST()
        {
            IRC.SendRaw("LIST");
        }//Shows output of LIST in a numeric!
        public static void INVITE(string nick, string channel)
        {
            IRC.SendRaw("INVITE " + nick + " " + channel);
        }
        public static void KICK(string channel, string nick, string reason = "")
        {
            if (reason != "")
            {
                IRC.SendRaw("KICK " + channel + " " + nick + " :" + reason);
            }
            else
            {
                IRC.SendRaw("KICK " + channel + " " + nick);
            }
        }
        public static void VERSION(string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("VERSION " + server);
            }
            else
            {
                IRC.SendRaw("VERSION");
            }
        }//Shows output of VERSION in a numeric!
        public static void STATS(string query, string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("STATS " + query + " " + server);
            }
            else
            {
                IRC.SendRaw("STATS " + query);
            }
        }//Shows output of STATS in a numeric!
        public static void LINKS(string servermask, string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("LINKS " + server + " " + servermask);
            }
            else
            {
                IRC.SendRaw("LINKS " + servermask);
            }
        }//Shows output of LINKS in a numeric!
        public static void TIME(string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("TIME " + server);
            }
            else
            {
                IRC.SendRaw("TIME");
            }
        }//Shows output of TIME in a numeric!
        public static void CONNECT(string target, string port = "", string remote = "")
        {
            if (remote != "")
            {
                IRC.SendRaw("CONNECT " + target + " " + port + " " + remote);
            }
            else if (port != "")
            {
                IRC.SendRaw("CONNECT " + target + " " + port);
            }
            else
            {
                IRC.SendRaw("CONNECT " + target);
            }
        }
        public static void ADMIN(string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("ADMIN " + server);
            }
            else
            {
                IRC.SendRaw("ADMIN");
            }
        }//Shows output of ADMIN in a numeric!
        public static void INFO(string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("INFO " + server);
            }
            else
            {
                IRC.SendRaw("INFO");
            }
        }//Shows output of INFO in a numeric!
        public static void PRIVMSG(string target, string text)
        {
            IRC.SendRaw("PRIVMSG " + target + " :" + text);
            if (target.StartsWith("#"))
                target = target.Remove(0, 1);
            Program.M.ChatAdd(target, "<" + IRC.nick + "> " + text);
        }
        public static void NOTICE(string target, string text)
        {
            IRC.SendRaw("NOTICE " + target + " :" + text);
            if (target.StartsWith("#"))
                target = target.Remove(0, 1);
            Program.M.ChatAdd(target, "-" + IRC.nick + "- " + text);
        }
        public static void WHO(string mask, bool opers = false)
        {
            string extratext = opers ? " o" : "";
            IRC.SendRaw("WHO " + mask + extratext);
        }//Shows output of WHO in a numeric!
        public static void WHOIS(string nick, string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("WHOIS " + server + " " + nick);
            }
            else
            {
                IRC.SendRaw("WHOIS " + nick);
            }
        }//Shows output of WHOIS in a numeric!
        public static void WHOWAS(string nick, string count = "", string server = "")
        {
            if (server != "")
            {
                IRC.SendRaw("WHOWAS " + nick + " " + count + " " + server);
            }
            else if (count != "")
            {
                IRC.SendRaw("WHOWAS " + nick + " " + count);
            }
            else
            {
                IRC.SendRaw("WHOWAS " + nick);
            }
        }//Shows output of WHOWAS in a numeric!
        public static void KILL(string nick, string reason)
        {
            IRC.SendRaw("KILL " + nick + " :" + reason);
        }
        public static void PING(string server1, string server2 = "")
        {
            if (server2 != "")
            {
                IRC.SendRaw("PING " + server1 + " " + server2);
            }
            else
            {
                IRC.SendRaw("PING " + server1);
            }
        }
        public static void PONG(string server1, string server2 = "")
        {
            if (server2 != "")
            {
                IRC.SendRaw("PONG " + server1 + " " + server2);
            }
            else
            {
                IRC.SendRaw("PONG " + server1);
            }
        }
        public static void AWAY(string awaymsg = "")
        {
            if (awaymsg != "")
            {
                IRC.SendRaw("AWAY :" + awaymsg);
                Program.M.ChatAdd("You are now away. Reason: \"" + awaymsg + "\"");
            }
            else
            {
                IRC.SendRaw("AWAY");
                Program.M.ChatAdd("You are no longer away.");
            }
        }
        public static void REHASH()
        {
            IRC.SendRaw("REHASH");
        }
        public static void WALLOPS(string text)
        {
            IRC.SendRaw("WALLOPS :" + text);
        }
    }
}
