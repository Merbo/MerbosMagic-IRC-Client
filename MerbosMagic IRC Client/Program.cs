﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client
{
    static class Program
    {
        public static Main M;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            M = new Main();
            Application.Run(M);
        }
    }
}
