using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class RFC_ModeHandler : RFC
    {

        public static string Handle(string sender, string chan, string mode, string args)
        {
            char[] modeletters = mode.ToCharArray();
            char modeletter = modeletters[1];
            bool addingmode = modeletters[0] == '-' ? false : true;
            string ret = "";

            if (chan == IRC.nick)
            {
                //Usermodes
                ret = RFC_1459_UserModes.GetMode(sender, chan, modeletter, args, addingmode);
                if (ret == "")
                {
                    //IRCd specific parsing :D
                }
            }
            else
            {
                //Channelmodes
                ret = RFC_1459_ChannelModes.GetMode(sender, chan, modeletter, args, addingmode);
                if (ret == "")
                {
                    //IRCd specific parsing :D
                }
            }

            return ret;
        }

    }
}
