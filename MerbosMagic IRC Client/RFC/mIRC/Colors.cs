using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

namespace MerbosMagic_IRC_Client.RFC
{
    enum Formatting
    {
        Bold=0x02,
        Italic=0x1d,
        Underlined=0x1f
    }

    class RFC_mIRC_Colors : RFC //TODO: Get colors to use chars. Shouldn't be hard, but we *need* this in order to see bold. :<
    {
        // Formatting constants
        public const string
            FormatBold            = "\x02",
            FormatItalic          = "\x1D", // The specification is fucked up here. This has been found out by testing.
            FormatUnderlined      = "\x1F",
            FormatReversed        = "\x16",
            FormatReset           = "\x0F",
            FormatColor           = "\x03";
        public const char
            FormatBoldC           = (char)2,
            FormatItalicC         = (char)29, //No longer fucked up, because doing it this way wins the game (ASCII)
            FormatUnderlinedC     = (char)31,
            FormatReversedC       = (char)22,
            FormatResetC          = (char)15,
            FormatColorC          = (char)3;

        public static void ParseIrcToRtf(string ircText, RichTextBox rtfCtl)
        {
            ircText = ircText.Replace("\t", "\\tab");

            Font stdfont = rtfCtl.Font;
            Color stdbg = rtfCtl.BackColor;
            Color stdfg = rtfCtl.ForeColor;

            rtfCtl.SelectionFont = stdfont;
            rtfCtl.SelectionColor = stdfg;
            rtfCtl.SelectionBackColor = stdbg;


            string t = "";

            for (int a = 0; a < ircText.Length; a++)
            {
                string c = ircText.Substring(a, 1);

                // Bold formatting
                if (c == FormatBold)
                {
                    rtfCtl.AppendText(t); t = "";
                    if (rtfCtl.SelectionFont.Style.HasFlag(FontStyle.Bold)) // bold set
                        rtfCtl.SelectionFont = new Font(rtfCtl.SelectionFont, rtfCtl.SelectionFont.Style & ~FontStyle.Bold);
                    else
                        rtfCtl.SelectionFont = new Font(rtfCtl.SelectionFont, rtfCtl.SelectionFont.Style | FontStyle.Bold);
                }
                // Italic formatting
                else if (c == FormatItalic)
                {
                    rtfCtl.AppendText(t); t = "";
                    if (rtfCtl.SelectionFont.Style.HasFlag(FontStyle.Italic)) // italic set
                        rtfCtl.SelectionFont = new Font(rtfCtl.SelectionFont, rtfCtl.SelectionFont.Style & ~FontStyle.Italic);
                    else
                        rtfCtl.SelectionFont = new Font(rtfCtl.SelectionFont, rtfCtl.SelectionFont.Style | FontStyle.Italic);
                }
                // Underline formatting
                else if (c == FormatUnderlined)
                {
                    rtfCtl.AppendText(t); t = "";
                    if (rtfCtl.SelectionFont.Style.HasFlag(FontStyle.Underline)) // underline set
                        rtfCtl.SelectionFont = new Font(rtfCtl.SelectionFont, rtfCtl.SelectionFont.Style & ~FontStyle.Underline);
                    else
                        rtfCtl.SelectionFont = new Font(rtfCtl.SelectionFont, rtfCtl.SelectionFont.Style | FontStyle.Underline);
                }
                // Reversed formatting
                else if (c == FormatReversed)
                {
                    rtfCtl.AppendText(t); t = "";
                    rtfCtl.SelectionColor = Color.FromArgb(Int32.MaxValue - rtfCtl.SelectionColor.ToArgb());
                    rtfCtl.SelectionBackColor = Color.FromArgb(Int32.MaxValue - rtfCtl.SelectionBackColor.ToArgb());

                }
                // Color formatting
                else if (c == FormatColor)
                {
                    int offset = a + 1;
                    rtfCtl.AppendText(t); t = "";
                    int color1 = -1, color2 = -1;
                    Color c1, c2;
                    try
                    {
                        if (int.TryParse(ircText.Substring(offset, 2), out color1)
                            || int.TryParse(ircText.Substring(offset, 1), out color1))
                        {
                            c1 = GetColorFromIrcColor(color1);
                            if (c1 != Color.Transparent) // Valid color?
                            {
                                rtfCtl.SelectionColor = c1;

                                int offsett = offset + 2;
                                while (offset < offsett && int.TryParse(ircText.Substring(offset, 1), out color1)) // jump all digits already used
                                {
                                    offset++;
                                }


                                if (ircText.Substring(offset, 1) == ","
                                    && (
                                        int.TryParse(ircText.Substring(offset + 1, 2), out color2)
                                        || int.TryParse(ircText.Substring(offset + 1, 1), out color2)
                                        )
                                    )
                                {
                                    offset++;

                                    c2 = GetColorFromIrcColor(color2);
                                    if (c2 != Color.Transparent) // Again, valid color?
                                    {
                                        rtfCtl.SelectionBackColor = c2;
                                        offsett = offset + 2;
                                        while (offset < offsett && int.TryParse(ircText.Substring(offset, 1), out color2)) // jump all digits already used
                                        {
                                            offset++;
                                        }
                                    }
                                }
                            }
                        }
                        a = offset - 1;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        //lolfail
                    }
                }

                // Formatting reset control byte
                else if (c == FormatReset)
                {
                    rtfCtl.AppendText(t); t = "";
                    rtfCtl.SelectionFont = stdfont;
                    rtfCtl.SelectionBackColor = stdbg;
                    rtfCtl.SelectionColor = stdfg;
                }

                // Standard text
                else
                {
                    t += c;
                }
            }
            rtfCtl.AppendText(t); t = "";
        }

        public static Color GetColorFromIrcColor(int color)
        {
            switch (color)
            {
                case 0: return Color.White;
                case 1: return Color.Black;
                case 2: return Color.Navy; // return Color.Blue;
                case 3: return Color.Green;
                case 4: return Color.Red;
                case 5: return Color.Maroon; // return Color.Brown;
                case 6: return Color.Purple;
                case 7: return Color.Orange; // return Color.Olive;
                case 8: return Color.Yellow;
                case 9: return Color.Lime; // return Color.LightGreen;
                case 10: return Color.Teal; // green-blue cyan
                case 11: return Color.LightCyan; // return Color.Cyan; // return Color.Aqua;
                case 12: return Color.RoyalBlue; // return Color.LightBlue;
                case 13: return Color.Pink; // return Color.LightPurple; // return Color.Fuchsia;
                case 14: return Color.Gray;
                case 15: return Color.LightGray; // return Color.Silver;
                default: return Color.Transparent;
            }
        }

        public static string ParseRtfToIrc(RichTextBox rtfCtl)
        {
            return rtfCtl.Text;
        }
    }
}
