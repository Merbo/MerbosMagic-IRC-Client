using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MerbosMagic_IRC_Client.RFC;

namespace MerbosMagic_IRC_Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private delegate void ChatAddSafeOne(string target, string text);
        public void ChatAdd(string target, string text)
        {
            //target is the tab window to add it to
            //text is the text to add

            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new ChatAddSafeOne(ChatAdd), target, text);
                return;
            }
            else
            {
                Control[] targetFindTabPage = this.tabControl1.Controls.Find(target, true);
                if (targetFindTabPage.Length >= 1) 
                {
                    TabPage TP = (TabPage)targetFindTabPage[0];
                    Control[] targetFindTextBox = TP.Controls.Find(target + "_tb1", true);
                    if (targetFindTextBox.Length >= 1)
                    {
                        TextBox TB = (TextBox)targetFindTextBox[0];
                        TB.Text += "\r\n[" + DateTime.Now + "] " + text;
                    }
                }
            }
        }

        private delegate void ChatAddSafeTwo(string text);
        public void ChatAdd(string text)
        {
            //target is the tab window to add it to
            //text is the text to add

            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new ChatAddSafeTwo(ChatAdd), text);
                return;
            }
            else
            {
                //tabControl1.SelectedTab
                TabPage TP = tabControl1.SelectedTab;

                Control[] targetFindTextBox = TP.Controls.Find(TP.Name + "_tb1", true);
                //if (targetFindTextBox.Length >= 1)
                //{
                    TextBox TB = (TextBox)targetFindTextBox[0];
                    TB.Text += "\r\n[" + DateTime.Now + "] " + text;
                //}
            }
        }

        private delegate void UserAddSafe(string chan, string text);
        public void UserAdd(string chan, string nick)
        {
            //target is the tab window to add it to
            //text is the text to add
            try
            {
                if (this.tabControl1.InvokeRequired)
                {
                    this.tabControl1.BeginInvoke(new UserAddSafe(UserAdd), chan, nick);
                    return;
                }
                else
                {
                    Control[] targetFindTabPage = tabControl1.Controls.Find(chan, true);
                    TabPage TP = (TabPage)targetFindTabPage[0];

                    Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                    ListBox LB = (ListBox)targetFindListBox[0];
                    LB.Items.Add(nick);
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private delegate void UserRemoveSafe(string chan, string text);
        public void UserRemove(string chan, string nick)
        {
            //target is the tab window to add it to
            //text is the text to add
            try
            {
                if (this.tabControl1.InvokeRequired)
                {
                    this.tabControl1.BeginInvoke(new UserRemoveSafe(UserRemove), chan, nick);
                    return;
                }
                else
                {
                    Control[] targetFindTabPage = tabControl1.Controls.Find(chan, true);
                    TabPage TP = (TabPage)targetFindTabPage[0];

                    Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                    ListBox LB = (ListBox)targetFindListBox[0];
                    string[] PNicks = { nick, "+" + nick, "%" + nick, "@" + nick, "&" + nick, "=" + nick, "~" + nick, "!" + nick, "." + nick };
                    List<string> PNicksList = PNicks.ToList<string>();
                    foreach (string nicktoremove in PNicksList)
                        LB.Items.Remove(nicktoremove);
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        Thread IRCThread = new Thread(IRC.Connect);
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                IRCThread.Name = "IRCThread";
                IRCThread.Start();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("You're already connected.");
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RFC_1459_Commands.QUIT("Program Closing");
                IRC.IRCStream.Close();
                IRCThread.Abort();
            }
            catch (Exception)
            {

            }
            finally
            {
                Application.Exit();
            }
        }

        private delegate void AddPageSafe(string codeName, string Text);
        public void AddPage(string codeName, string Text)
        {
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new AddPageSafe(AddPage), codeName, Text);
                return;
            }
            else
            {
                #region TextBox1
                TextBox tb1 = new TextBox();
                tb1.BackColor = Color.Black;
                tb1.Dock = DockStyle.Top;
                tb1.ForeColor = Color.White;
                tb1.Location = new Point(3, 3);
                tb1.MaxLength = 99999999;
                tb1.Multiline = true;
                tb1.Name = codeName + "_tb1";
                tb1.ReadOnly = true;
                tb1.Size = new Size(751, 349);
                tb1.TabIndex = 0;
                tb1.ScrollBars = ScrollBars.Vertical;
                tb1.TextChanged += new EventHandler(tb1_TextChanged);
                #endregion
                #region TextBox2
                TextBox tb2 = new TextBox();
                tb2.BackColor = Color.Black;
                tb2.Dock = DockStyle.Bottom;
                tb2.ForeColor = Color.White;
                tb2.Location = new Point(3, 347);
                tb2.Name = codeName + "_tb2";
                tb2.Size = new Size(751, 20);
                tb2.TabIndex = 1;
                tb2.KeyPress += new KeyPressEventHandler(this.tb2_KeyPress);
                #endregion
                #region ListBox1
                ListBox lb1 = new ListBox();
                lb1.BackColor = Color.Black;
                lb1.Dock = DockStyle.Right;
                lb1.ForeColor = Color.White;
                lb1.Name = codeName + "_lb1";
                #endregion
                #region Page
                TabPage tp = new TabPage();
                tp.BackColor = Color.Black;
                tp.Controls.Add(tb2);
                tp.Controls.Add(tb1);
                tp.Controls.Add(lb1);
                tp.Location = new Point(4, 22);
                tp.Name = codeName;
                tp.Padding = new Padding(3);
                tp.Size = new Size(757, 370);
                tp.TabIndex = 0;
                tp.Text = Text;
                //tp.Text = tp.Name; //Debugging
                #endregion
                tabControl1.Controls.Add(tp);
            }
        }

        private delegate void RemovePageSafe(string Key);
        public void RemovePage(string Key)
        {
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new RemovePageSafe(RemovePage), Key);
                return;
            }
            else
            {
                this.tabControl1.Controls.RemoveByKey(Key);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
#if DEBUG
            AddPage("debugPage", "debugPage");
#endif
            AddPage("Status", "Status");
        }

        private void tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TextBox TB = (TextBox)sender;
                TabPage TP = (TabPage)TB.Parent;

                if (TP.Text.StartsWith("#") && !TB.Text.StartsWith("/"))
                {
                    RFC_1459_Commands.PRIVMSG(TP.Text, TB.Text);
                }
                else if (TB.Text.StartsWith("/"))
                {
                    DataProcessing.ProcessSend(TB.Text);
                }
                
                TB.Text = "";
            }
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {

            TextBox TB = (TextBox)sender;

            TB.SelectionStart = TB.Text.Length;
            TB.ScrollToCaret();
            TB.Refresh();
        }



    }
}
