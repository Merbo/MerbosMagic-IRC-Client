using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerbosMagic_IRC_Client
{
    class VersionClass
    {
        private int _MajorVersion;
        private int _MinorVersion;
        private int _SubVersion;



        public VersionClass(int MajorVersion, int MinorVersion, int Subversion)
        {
            _MajorVersion = MajorVersion;
            _MinorVersion = MinorVersion;
            _SubVersion = Subversion;
        }

        public string Text
        {
            get
            {
                return _MajorVersion.ToString() + "." + _MinorVersion.ToString() + "." + _SubVersion.ToString();
            }
        }
        public int[] ToArray()
        {
            int[] i =
            {
                _MajorVersion,
                _MinorVersion,
                _SubVersion
            };

            return i;
        }

        public static implicit operator string(VersionClass c) //This is for referring to it as a string.
        {
            return c._MajorVersion.ToString() + "." + c._MinorVersion.ToString() + "." + c._SubVersion.ToString();
        }

        public static implicit operator int[](VersionClass c) //We can get an int[] if we're gonna be handling the version inside the client.
        {
            int[] i = 
            {
                c._MajorVersion,
                c._MinorVersion,
                c._SubVersion
            };

            return i;
        }

    }
}
