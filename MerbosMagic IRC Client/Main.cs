using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MerbosMagic_IRC_Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private delegate void ChatAddSafe(string target, string text);
        public void ChatAdd(string target, string text)
        {
            //target is the tab window to add it to
            //text is the text to add

            /*if (this.textBox1.InvokeRequired) 
            {
                this.textBox1.BeginInvoke(new ChatAddSafe(ChatAdd), text);
                return;
            }
            else
            {
                this.textBox1.Text = this.textBox1.Text + "\r\n" + text;
            }*/
        }

        Thread IRCThread = new Thread(IRC.Connect);
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IRCThread.Name = "IRCThread";
            IRCThread.Start();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            IRCThread.Abort();
        }



    }
}
