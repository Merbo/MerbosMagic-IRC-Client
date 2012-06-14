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
                return _MajorVersion.ToString() +"."+ _MinorVersion.ToString() +"."+ _SubVersion.ToString();
            }
        }
            
    }
}
