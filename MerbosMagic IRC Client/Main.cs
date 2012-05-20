using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MerbosMagic_IRC_Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void ChatAdd(string text)
        {
            Program.M.textBox2.Text = Program.M.textBox2.Text + "\r\n" + text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IRC.Connect();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox2.Text.StartsWith("/"))
                {
                    //ToDo: Add a parser that takes out the '/' from a commands up till the space.
                }
                else
                {
                    textBox2.Text = "";
                    //Msg the channel
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
