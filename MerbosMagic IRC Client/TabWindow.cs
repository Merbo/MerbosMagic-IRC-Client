using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client
{
    public partial class TabWindow : UserControl
    {
        public TabWindow()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string[] commands = textBox2.Text.Split(' ');
                IRC.SendRaw(textBox2.Text);
                textBox2.Text = "";
            }
        }

    }
}
