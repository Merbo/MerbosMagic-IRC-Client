using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client.RFC
{
    class Numerics
    {
        public static void Parse(string input)
        {
            string[] commands = input.Split(' ');
            int i;
            bool worked = int.TryParse(commands[1], out i);
            if (worked)
            {
                switch (i)
                {
                    case 001:
                        RFC_1459_Numerics.RPL_WELCOME_001(input);
                        break;
                    case 002:
                        RFC_1459_Numerics.RPL_YOURHOST_002(input);
                        break;
                    case 003:
                        RFC_1459_Numerics.RPL_CREATED_003(input);
                        break;
                    case 004:
                        RFC_1459_Numerics.RPL_MYINFO_004(input);
                        break;
                    case 005:
                        RFC_1459_Numerics.RPL_MYINFO_005(input);
                        break;
                    case 353:
                        RFC_1459_Numerics.RPL_NAMREPLY_353(input);
                        break;
                }
            }
        }
    }
}
