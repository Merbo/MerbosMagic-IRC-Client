using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_UserModes : RFC
    {
        private const char
            USERMODE_NOWHO      = 'i',
            USERMODE_IRCOP      = 'o',
            USERMODE_SNOTICE    = 's',
            USERMODE_SEEWALLOPS = 'w';

        public static string GetMode(string sender, string user, char mode, string args, bool add)
        {
            string yes_or_no = !add ? "" : "not";
            string got_or_lost = add ? "now" : "no longer";
            string plus_or_minus = add ? "+" : "-";

            switch (mode)
            {
                case USERMODE_NOWHO:
                    return IRCColorList.Yellow + "You will " + yes_or_no + " be shown in /who. (" + plus_or_minus + "i)";
                case USERMODE_IRCOP:
                    return IRCColorList.Yellow + "You are " + got_or_lost + " an IRC operator. (" + plus_or_minus + "o)";
                case USERMODE_SNOTICE:
                    return IRCColorList.Yellow + "You may " + got_or_lost + " see Server Notice Masks. (" + plus_or_minus + "s " + args + ")";
                case USERMODE_SEEWALLOPS:
                    return IRCColorList.Yellow + "You may " + got_or_lost + " see wallops notices. (" + plus_or_minus + "w)";
                default:
                    return "";
            }
        }
    }
}
