using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_1459_ChannelModes : RFC
    {
        private const char
            CHANNELMODE_BAN        = 'b',
            CHANNELMODE_INVITEONLY = 'i',
            CHANNELMODE_KEY        = 'k',
            CHANNELMODE_LIMIT      = 'l',
            CHANNELMODE_MODERATED  = 'm',
            CHANNELMODE_NOEXTERNAL = 'n',
            CHANNELMODE_OPERATOR   = 'o',
            CHANNELMODE_PRIVATE    = 'p',
            CHANNELMODE_SECRET     = 's',
            CHANNELMODE_OPTOPIC    = 't',
            CHANNELMODE_VOICE      = 'v';

        public static string GetMode(string sender, string chan, char mode, string args, bool add)
        {
            string yes_or_no = !add ? "" : "not";
            string got_or_lost = add ? "" : "no longer";
            string plus_or_minus = add ? "+" : "-";
            string undone = !add ? "un" : "";
            string de = !add ? "de" : "";
            string il = !add ? "il" : "";

            switch (mode)
            {
                case CHANNELMODE_BAN:
                    return IRCColorList.Red + sender + " has " + undone + "banned the host " + args + " (" + plus_or_minus + "b " + args + ")";
                case CHANNELMODE_INVITEONLY:
                    return IRCColorList.Yellow + sender + " has " + undone + "set the channel invite only. (" + plus_or_minus + "i)";
                case CHANNELMODE_KEY:
                    return IRCColorList.Yellow + sender + " has " + undone + "set a key on the channel. Key: \"" + args + "\" (" + plus_or_minus + "k " + args + ")";
                case CHANNELMODE_LIMIT:
                    return IRCColorList.Yellow + sender + " has " + undone + "set a " + args + " user limit on the channel. (" + plus_or_minus + "l " + args + ")";
                case CHANNELMODE_MODERATED:
                    return IRCColorList.Yellow + sender + " has made the channel " + got_or_lost + " moderated. (" + plus_or_minus + "m)";
                case CHANNELMODE_NOEXTERNAL:
                    return IRCColorList.Yellow + sender + " has made it " + il + "legal for external messages in the channel. (" + plus_or_minus + "n)";
                case CHANNELMODE_OPERATOR:
                    RFC_1459_Commands.NAMES(chan);
                    return IRCColorList.Yellow + sender + " has " + de + "opped " + args + " (" + plus_or_minus + "o " + args + ")";
                case CHANNELMODE_PRIVATE:
                    return IRCColorList.Yellow + sender + " has made the channel " + got_or_lost + " private. (" + plus_or_minus + "p)";
                case CHANNELMODE_SECRET:
                    return IRCColorList.Yellow + sender + " has made the channel " + got_or_lost + " secret. (" + plus_or_minus + "s)";
                case CHANNELMODE_OPTOPIC:
                    return IRCColorList.Yellow + sender + " has made it " + il + "legal for any user under halfop (+h) rank to set the topic of this channel. (" + plus_or_minus + "t)";
                case CHANNELMODE_VOICE:
                    RFC_1459_Commands.NAMES(chan);
                    return IRCColorList.Yellow + sender + " has " + de + "voiced " + args + " (" + plus_or_minus + "v " + args + ")";
                default:
                    return "";
            }

        }
    }
}
