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

        #region Chat Functions

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
                if (!target.StartsWith("page_"))
                    target = "page_" + target;
                Control[] targetFindTabPage = this.tabControl1.Controls.Find(target, true);
                if (targetFindTabPage.Length >= 1)
                {
                    TabPage TP = (TabPage)targetFindTabPage[0];
                    Control[] targetFindTextBox = TP.Controls.Find(target + "_tb1", true);
                    if (targetFindTextBox.Length >= 1)
                    {
                        RichTextBox RTB = (RichTextBox)targetFindTextBox[0];
                        string stext = Environment.NewLine + "[" + DateTime.Now + "] " + text;
                        RFC_mIRC_Colors.ParseIrcToRtf(stext, RTB);
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
                int Count = tabControl1.TabPages.Count;
                List<Control> ControlList = new List<Control>();
                for (int i = 1; i < Count; i++)
                {
                    ControlList.Add(tabControl1.GetControl(i));
                }
                foreach (Control C in ControlList)
                {
                    TabPage TP = (TabPage)C;
                    if (TP.Name != "page_debugPage" && TP.Name != "page_Status")
                    {
                        Control[] targetFindTextBox = TP.Controls.Find(TP.Name + "_tb1", true);
                        RichTextBox RTB = (RichTextBox)targetFindTextBox[0];
                        string stext = Environment.NewLine + "[" + DateTime.Now + "] " + text;
                        RFC_mIRC_Colors.ParseIrcToRtf(stext, RTB);
                    }
                }
            }
        }
        #endregion

        #region User Functions

        private delegate void UserClearSafe(string chan);
        public void UserClear(string chan)
        {
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new UserClearSafe(UserClear), chan);
                return;
            }
            else
            {
                int Count = tabControl1.TabPages.Count;
                List<Control> ControlList = new List<Control>();
                for (int i = 1; i < Count; i++)
                {
                    ControlList.Add(tabControl1.GetControl(i));
                }
                foreach (Control C in ControlList)
                {
                    TabPage TP = (TabPage)C;
                    if (TP.Name != "page_debugPage" && TP.Name != "page_Status")
                    {
                        Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                        ListBox LB = (ListBox)targetFindListBox[0];
                        LB.Items.Clear();
                    }
                }
            }
        }

        private delegate void UserAddSafeOne(string chan, string text);
        public void UserAdd(string chan, string nick)
        {
            //target is the tab window to add it to
            //text is the text to add
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new UserAddSafeOne(UserAdd), chan, nick);
                return;
            }
            else
            {
                chan = "page_" + chan;
                Control[] targetFindTabPage = tabControl1.Controls.Find(chan, true);
                TabPage TP = (TabPage)targetFindTabPage[0];

                Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                ListBox LB = (ListBox)targetFindListBox[0];
                LB.Items.Add(nick);
            }
        }
        private delegate void UserAddSafeTwo(string nick);
        public void UserAdd(string nick)
        {
            //text is the text to add
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new UserAddSafeTwo(UserAdd), nick);
                return;
            }
            else
            {
                int Count = tabControl1.TabPages.Count;
                List<Control> ControlList = new List<Control>();
                for (int i = 1; i < Count; i++)
                {
                    ControlList.Add(tabControl1.GetControl(i));
                }
                foreach (Control C in ControlList)
                {
                    TabPage TP = (TabPage)C;
                    if (TP.Name != "page_debugPage" && TP.Name != "page_Status")
                    {
                        Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                        ListBox LB = (ListBox)targetFindListBox[0];
                        LB.Items.Add(nick);
                    }
                }
            }
        }

        private delegate void UserRemoveSafeOne(string chan, string nick);
        public void UserRemove(string chan, string nick)
        {
            //target is the tab window to add it to
            //text is the text to add
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new UserRemoveSafeOne(UserRemove), chan, nick);
                return;
            }
            else
            {
                if (!chan.StartsWith("page_"))
                    chan = "page_" + chan;
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
        private delegate void UserRemoveSafeTwo(string nick);
        public void UserRemove(string nick)
        {
            //target is the tab window to add it to
            //text is the text to add
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new UserRemoveSafeTwo(UserRemove), nick);
                return;
            }
            else
            {
                int Count = tabControl1.TabPages.Count;
                List<Control> ControlList = new List<Control>();
                for (int i = 1; i < Count; i++)
                {
                    ControlList.Add(tabControl1.GetControl(i));
                }
                foreach (Control C in ControlList)
                {
                    TabPage TP = (TabPage)C;
                    if (TP.Name != "page_debugPage" && TP.Name != "page_Status")
                    {
                        Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                        ListBox LB = (ListBox)targetFindListBox[0];
                        string[] PNicks = { nick, "+" + nick, "%" + nick, "@" + nick, "&" + nick, "=" + nick, "~" + nick, "!" + nick, "." + nick };
                        List<string> PNicksList = PNicks.ToList<string>();
                        foreach (string nicktoremove in PNicksList)
                            LB.Items.Remove(nicktoremove);
                    }
                }
            }
        }

        private delegate void UserRenameSafe(string oldnick, string newnick);
        public void UserRename(string oldnick, string newnick)
        {
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new UserRenameSafe(UserRename), oldnick, newnick);
                return;
            }
            else
            {
                int Count = tabControl1.TabPages.Count;
                List<Control> ControlList = new List<Control>();
                for (int i = 1; i < Count; i++)
                {
                    ControlList.Add(tabControl1.GetControl(i));
                }
                foreach (Control C in ControlList)
                {
                    TabPage TP = (TabPage)C;
                    if (TP.Name != "page_debugPage" && TP.Name != "page_Status")
                    {
                        Control[] targetFindListBox = TP.Controls.Find(TP.Name + "_lb1", true);
                        ListBox LB = (ListBox)targetFindListBox[0];
                        string[] PNicks = { oldnick, "+" + oldnick, "%" + oldnick, "@" + oldnick, "&" + oldnick, "=" + oldnick, "~" + oldnick, "!" + oldnick, "." + oldnick };
                        List<string> PNicksList = PNicks.ToList<string>();
                        foreach (string nicktoremove in PNicksList)
                        {
                            if (LB.Items.Contains(nicktoremove))
                            {
                                LB.Items.Remove(nicktoremove);
                                LB.Items.Add(newnick);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Page Functions
        private delegate void AddPageSafe(string codeName, string Text, bool generateUserList);
        public void AddPage(string codeName, string Text, bool generateUserList = true)
        {
            if (this.tabControl1.InvokeRequired)
            {
                this.tabControl1.BeginInvoke(new AddPageSafe(AddPage), codeName, Text, generateUserList);
                return;
            }
            else
            {
                if (!codeName.StartsWith("page_"))
                    codeName = "page_" + codeName;
                #region Input box
                RichTextBox tb2 = new RichTextBox();
                tb2.BackColor = Color.Black;
                //tb2.Location = new Point(3, 347);
                //tb2.Size = new Size(751, 20);
                tb2.Height = 20;
                tb2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                tb2.Dock = DockStyle.Bottom;
                tb2.ForeColor = Color.White;
                tb2.Name = codeName + "_tb2";
                tb2.TabIndex = 0;
                tb2.Multiline = false;
                tb2.KeyPress += new KeyPressEventHandler(this.tb2_KeyPress);
                #endregion
                #region User list
                ListBox lb1 = new ListBox();
                if (generateUserList)
                {
                    lb1.BackColor = Color.Black;
                    lb1.Dock = DockStyle.Right;
                    lb1.ForeColor = Color.White;
                    lb1.Name = codeName + "_lb1";
                    lb1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                    lb1.ItemHeight = 15;

                    lb1.DrawMode = DrawMode.OwnerDrawVariable;
                    lb1.DrawItem += new DrawItemEventHandler(this.NickListColorHandler);
                }
                #endregion
                #region Chat history text box
                RichTextBox tb1 = new RichTextBox();
                tb1.BackColor = Color.Black;
                tb1.Dock = DockStyle.Fill;
                tb1.ForeColor = Color.White;
                tb1.MaxLength = 99999999;
                tb1.Multiline = true;
                tb1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                tb1.Name = codeName + "_tb1";
                tb1.Font = tb2.Font = new Font("Courier New", 9);
                tb1.ReadOnly = true;
                tb1.Size = new Size(751, 349);
                tb1.TabStop = false;
                tb1.TabIndex = 1;
                tb1.ScrollBars = RichTextBoxScrollBars.Both;
                tb1.TextChanged += new EventHandler(tb1_TextChanged);
                #endregion
                #region Page
                TabPage tp = new TabPage();
                tp.BackColor = Color.Black;
                tp.Controls.Add(tb2);
                tp.Controls.Add(tb1);
                if (generateUserList) tp.Controls.Add(lb1);
                tp.Location = new Point(4, 22);
                tp.Name = codeName;
                tp.Padding = new Padding(3);
                tp.Size = new Size(757, 370);
                tp.TabIndex = 0;
                tp.Text = Text;
                tb1.BringToFront();
                //tp.Text = tp.Name; //Debugging
                #endregion
                tabControl1.Controls.Add(tp);
                tabControl1.SelectedTab = tp;
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
                this.tabControl1.Controls.RemoveByKey("page_" + Key);
            }
        }

        private delegate TabPage GetPageSafe();
        public object GetPage()
        {
            if (this.tabControl1.InvokeRequired)
            {
                return "ERR_INVOKEREQUIRED";
            }
            else
            {
                TabPage tp = this.tabControl1.SelectedTab;
                return tp;
            }
        }
        #endregion

        #region Form Functions
        Thread IRCThread = new Thread(IRC.Connect);
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (IRC.IRCClient != null && IRC.IRCClient.Connected)
                MessageBox.Show("You are already connected!", IRC.longversion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    IRCThread.Name = "IRCThread";
                    IRCThread.IsBackground = true;
                    IRCThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RFC_1459_Commands.QUIT(IRC.longversion);
                IRC.IRCStream.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Application.Exit();
            }
        }



        private void Main_Load(object sender, EventArgs e)
        {
#if DEBUG
            AddPage("debugPage", "debugPage", false);
#endif
            AddPage("Status", "Status", false);
        }

        private void tb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                RichTextBox TB = (RichTextBox)sender;
                TabPage TP = (TabPage)TB.Parent;

                if (TB.Text.StartsWith("/."))
                {
                    string s = DataProcessing.ResolveVars(RFC_mIRC_Colors.ParseRtfToIrc(TB).Remove(0, 2));
                    RFC_1459_Commands.PRIVMSG(TP.Text, s);
                }
                else if (TB.Text.StartsWith("//"))
                {
                    string s = DataProcessing.ResolveVars(TB.Text.Remove(0, 1));
                    DataProcessing.ProcessSend(s);
                }
                else if (TB.Text.StartsWith("/"))
                {
                    DataProcessing.ProcessSend(TB.Text);
                }
                else if (TP.Text != "debugPage" && TP.Text != "Status")
                {
                    RFC_1459_Commands.PRIVMSG(TP.Text, TB.Text);
                }

                TB.Text = "";
            }
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {

            RichTextBox TB = (RichTextBox)sender;

            TB.SelectionStart = TB.Text.Length;
            TB.ScrollToCaret();
            TB.Refresh();
        }

        private void tc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change form window name.
            TabControl tc = (TabControl)sender;
            TabPage tp = tc.SelectedTab;
            this.Text = IRC.longversion + " - " + tp.Text;
        }

        private void NickListColorHandler(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            ListBox LB = (ListBox)sender;

            int index = e.Index;
            LB.SelectedIndex = index;
            string currentNick = LB.SelectedItem.ToString();

            //string currentNick = NickAdding;
            //NickAdding = "";
            char[] NickInChars = currentNick.ToCharArray();
            char pNick = NickInChars[0];

            Color color = Color.White;

            #region switch (pNick)
            switch (pNick)
            {

                case '.':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.Orange;
                    break;
                case '~':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.Purple;
                    break;
                case '=':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.DarkBlue;
                    break;
                case '&':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.Red;
                    break;
                case '@':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.LawnGreen;
                    break;
                case '%':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.DeepSkyBlue;
                    break;
                case '+':
                    currentNick = pNick.ToString() + "|" + currentNick.Remove(0, 1);
                    color = Color.Yellow;
                    break;
                default:
                    currentNick = " |" + currentNick;
                    color = Color.White;
                    break;
            }
            #endregion

            e.Graphics.DrawString(currentNick,
                                  new Font(FontFamily.GenericMonospace, 10, FontStyle.Regular),
                                  new SolidBrush(color),
                                  e.Bounds);
        }
        #endregion

    }
}