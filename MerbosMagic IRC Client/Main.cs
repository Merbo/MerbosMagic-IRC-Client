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

        private delegate void ChatAddSafe(string text);
        public void ChatAdd(string text)
        {
            if (this.textBox1.InvokeRequired) 
            {
                this.textBox1.BeginInvoke(new ChatAddSafe(ChatAdd), text);
                return;
            }
            else
            {
                this.textBox1.Text = this.textBox1.Text + "\r\n" + text;
            }
        }

        /*private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }*/

        Thread IRCThread = new Thread(IRC.Connect);
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IRCThread.Name = "IRCThread";
            IRCThread.Start();
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            IRCThread.Abort();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ScrollToCaret();
        }


    }
}
