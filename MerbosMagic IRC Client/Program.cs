using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client
{
    static class Program
    {
        /*
         * If you are not retarded you will install this font:
         * http://www.moviecorner.de/download/fixedsys500c.zip
         * Otherwise you are severely retarded.
         * No offense.
         */

        public static Main M;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                M = new Main();
                Application.Run(M);
            }
            catch (Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show("There was an error. Contact Merbo.");
#endif
            }
        }
    }
}
