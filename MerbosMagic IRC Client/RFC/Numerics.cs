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
                        RFC_1459_Numerics.RPL_ISUPPORT_005(input);
                        break;
                    case 353:
                        RFC_1459_Numerics.RPL_NAMREPLY_353(input);
                        break;
					case 401:
						RFC_1459_Numerics.ERR_NOSUCHNICK(input);
						break;
					case 402:
						RFC_1459_Numerics.ERR_NOSUCHSERVER(input);
						break;
					case 403:
						RFC_1459_Numerics.ERR_NOSUCHCHANNEL(input);
						break;
					case 404:
						RFC_1459_Numerics.ERR_CANNOTSENDTOCHAN(input);
						break;
					case 405:
						RFC_1459_Numerics.ERR_TOOMANYCHANNELS(input);
						break;
					case 406:
						RFC_1459_Numerics.ERR_WASNOSUCHNICK(input);
						break;
					case 407:
						RFC_1459_Numerics.ERR_TOOMANYTARGETS(input);
						break;
					case 409:
						RFC_1459_Numerics.ERR_NOORIGIN(input);
						break;
					case 411:
						RFC_1459_Numerics.ERR_NORECIPIENT(input);
						break;
					case 412:
						RFC_1459_Numerics.ERR_NOTEXTTOSEND(input);
						break;
					case 413:
						RFC_1459_Numerics.ERR_NOTOPLEVEL(input);
						break;
					case 414:
						RFC_1459_Numerics.ERR_WILDTOPLEVEL(input);
						break;
					case 421:
						RFC_1459_Numerics.ERR_UNKNOWNCOMMAND(input);
						break;
					case 422:
						RFC_1459_Numerics.ERR_NOMOTD(input);
						break;
					case 423:
						RFC_1459_Numerics.ERR_NOADMININFO(input);
						break;
					case 424:
						RFC_1459_Numerics.ERR_FILEERROR(input);
						break;
					case 431:
						RFC_1459_Numerics.ERR_NONICKNAMEGIVEN(input);
						break;
					case 432:
						RFC_1459_Numerics.ERR_ERRONEUSNICKNAME(input);
						break;
					case 433:
						RFC_1459_Numerics.ERR_NICKNAMEINUSE(input);
						break;
					case 436:
						RFC_1459_Numerics.ERR_NICKCOLLISION(input);
						break;
					case 441:
						RFC_1459_Numerics.ERR_USERNOTINCHANNEL(input);
						break;
					case 442:
						RFC_1459_Numerics.ERR_NOTONCHANNEL(input);
						break;
					case 443:
						RFC_1459_Numerics.ERR_USERONCHANNEL(input);
						break;
					case 444:
						RFC_1459_Numerics.ERR_NOLOGIN(input);
						break;
					case 445:
						RFC_1459_Numerics.ERR_SUMMONDISABLED(input);
						break;
					case 446:
						RFC_1459_Numerics.ERR_USERDISABLED(input);
						break;
					case 451:
						RFC_1459_Numerics.ERR_NOTREGISTERED(input);
						break;
					case 461:
						RFC_1459_Numerics.ERR_NEEDMOREPARAMS(input);
						break;
					case 462:
						RFC_1459_Numerics.ERR_ALREADYREGISTERED(input);
						break;
					case 463:
						RFC_1459_Numerics.ERR_NOPERMFORHOST(input);
						break;
					case 464:
						RFC_1459_Numerics.ERR_PASSWDMISMATCH(input);
						break;
					case 465:
						RFC_1459_Numerics.ERR_YOUREBANNECREEP(input);
						break;
					case 467:
						RFC_1459_Numerics.ERR_KEYSET(input);
						break;
					case 471:
						RFC_1459_Numerics.ERR_CHANNELISFULL(input);
						break;
					case 472:
						RFC_1459_Numerics.ERR_UNKNOWNMODE(input);
						break;
					case 473:
						RFC_1459_Numerics.ERR_INVITEONLYCHAN(input);
						break;
					case 474:
						RFC_1459_Numerics.ERR_BANNEDFROMCHAN(input);
						break;
					case 475:
						RFC_1459_Numerics.ERR_BADCHANNELKEY(input);
						break;
					case 481:
						RFC_1459_Numerics.ERR_NOPRIVILEGES(input);
						break;
					case 482:
						RFC_1459_Numerics.ERR_CHANOPRIVSNEEDED(input);
						break;
					case 483:
						RFC_1459_Numerics.ERR_CANTKILLSERVER(input);
						break;
					case 491:
						RFC_1459_Numerics.ERR_NOOPERHOST(input);
						break;
					case 501:
						RFC_1459_Numerics.ERR_UMODEUNKNOWNFLAG(input);
						break;
					case 502:
						RFC_1459_Numerics.ERR_USERSDONTMATCH(input);
						break;
				}
			}
        }
    }
}
