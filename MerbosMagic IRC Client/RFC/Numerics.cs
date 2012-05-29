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
						RFC_1459_Numerics.ERR_NOSUCHNICK_401(input);
						break;
					case 402:
						RFC_1459_Numerics.ERR_NOSUCHSERVER_402(input);
						break;
					case 403:
						RFC_1459_Numerics.ERR_NOSUCHCHANNEL_403(input);
						break;
					case 404:
						RFC_1459_Numerics.ERR_CANNOTSENDTOCHAN_404(input);
						break;
					case 405:
						RFC_1459_Numerics.ERR_TOOMANYCHANNELS_405(input);
						break;
					case 406:
						RFC_1459_Numerics.ERR_WASNOSUCHNICK_406(input);
						break;
					case 407:
						RFC_1459_Numerics.ERR_TOOMANYTARGETS_407(input);
						break;
					case 409:
						RFC_1459_Numerics.ERR_NOORIGIN_409(input);
						break;
					case 411:
						RFC_1459_Numerics.ERR_NORECIPIENT_411(input);
						break;
					case 412:
						RFC_1459_Numerics.ERR_NOTEXTTOSEND_412(input);
						break;
					case 413:
						RFC_1459_Numerics.ERR_NOTOPLEVEL_413(input);
						break;
					case 414:
						RFC_1459_Numerics.ERR_WILDTOPLEVEL_414(input);
						break;
					case 421:
						RFC_1459_Numerics.ERR_UNKNOWNCOMMAND_421(input);
						break;
					case 422:
						RFC_1459_Numerics.ERR_NOMOTD_422(input);
						break;
					case 423:
						RFC_1459_Numerics.ERR_NOADMININFO_423(input);
						break;
					case 424:
						RFC_1459_Numerics.ERR_FILEERROR_424(input);
						break;
					case 431:
						RFC_1459_Numerics.ERR_NONICKNAMEGIVEN_431(input);
						break;
					case 432:
						RFC_1459_Numerics.ERR_ERRONEUSNICKNAME_432(input);
						break;
					case 433:
						RFC_1459_Numerics.ERR_NICKNAMEINUSE_433(input);
						break;
					case 436:
						RFC_1459_Numerics.ERR_NICKCOLLISION_436(input);
						break;
					case 441:
						RFC_1459_Numerics.ERR_USERNOTINCHANNEL_441(input);
						break;
					case 442:
						RFC_1459_Numerics.ERR_NOTONCHANNEL_442(input);
						break;
					case 443:
						RFC_1459_Numerics.ERR_USERONCHANNEL_443(input);
						break;
					case 444:
						RFC_1459_Numerics.ERR_NOLOGIN_444(input);
						break;
					case 445:
						RFC_1459_Numerics.ERR_SUMMONDISABLED_445(input);
						break;
					case 446:
						RFC_1459_Numerics.ERR_USERDISABLED_446(input);
						break;
					case 451:
						RFC_1459_Numerics.ERR_NOTREGISTERED_451(input);
						break;
					case 461:
						RFC_1459_Numerics.ERR_NEEDMOREPARAMS_461(input);
						break;
					case 462:
						RFC_1459_Numerics.ERR_ALREADYREGISTERED_462(input);
						break;
					case 463:
						RFC_1459_Numerics.ERR_NOPERMFORHOST_463(input);
						break;
					case 464:
						RFC_1459_Numerics.ERR_PASSWDMISMATCH_464(input);
						break;
					case 465:
						RFC_1459_Numerics.ERR_YOUREBANNEDCREEP_465(input);
						break;
					case 467:
						RFC_1459_Numerics.ERR_KEYSET_467(input);
						break;
					case 471:
						RFC_1459_Numerics.ERR_CHANNELISFULL_471(input);
						break;
					case 472:
						RFC_1459_Numerics.ERR_UNKNOWNMODE_472(input);
						break;
					case 473:
						RFC_1459_Numerics.ERR_INVITEONLYCHAN_473(input);
						break;
					case 474:
						RFC_1459_Numerics.ERR_BANNEDFROMCHAN_474(input);
						break;
					case 475:
						RFC_1459_Numerics.ERR_BADCHANNELKEY_475(input);
						break;
					case 481:
						RFC_1459_Numerics.ERR_NOPRIVILEGES_481(input);
						break;
					case 482:
						RFC_1459_Numerics.ERR_CHANOPRIVSNEEDED_482(input);
						break;
					case 483:
						RFC_1459_Numerics.ERR_CANTKILLSERVER_483(input);
						break;
					case 491:
						RFC_1459_Numerics.ERR_NOOPERHOST_491(input);
						break;
					case 501:
						RFC_1459_Numerics.ERR_UMODEUNKNOWNFLAG_501(input);
						break;
					case 502:
						RFC_1459_Numerics.ERR_USERSDONTMATCH_502(input);
						break;
				}
			}
        }
    }
}
