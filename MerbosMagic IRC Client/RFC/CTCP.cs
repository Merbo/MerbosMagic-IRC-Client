﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class CTCP : RFC
    {
        //(char)1
        private static string ctcpchar = "\x01";
        public static void SendCTCPReply(string sender, string CTCP)
        {
            switch (CTCP.ToLower())
            {
                case "\x01version\x01":
                    RFC_1459_Commands.NOTICE(sender, ctcpchar + "VERSION MerbosMagic IRC Client");
                    break;
            }
        }
        public static void SendCTCPRequest(string target, string CTCP)
        {
            RFC_1459_Commands.PRIVMSG(target, ctcpchar + CTCP + ctcpchar);
        }
    }
}
