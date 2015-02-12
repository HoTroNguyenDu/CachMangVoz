using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CachMangVoz
{
    public static class TextBoxExtensions
    {
        public static string GetTextThreadSafe(this TextBox textbox)
        {
            return GetTextBoxText(textbox);
        }

        public static void SetTextThreadSafe(this TextBox textbox, string text)
        {
            SetTextBoxText(textbox, text);
        }

        public static string GetTextBoxText(TextBox textbox)
        {
            if (textbox.InvokeRequired)
            {
                Func<TextBox, string> delegation = new Func<TextBox, string>(GetTextBoxText);
                return textbox.Invoke(delegation, new object[] { textbox }).ToString();
            }
            else
            {
                return textbox.Text;
            }
        }

        public static void SetTextBoxText(TextBox textbox, string text)
        {
            if (textbox.InvokeRequired)
            {
                Action<TextBox, string> deleg = new Action<TextBox, string>(SetTextBoxText);
                textbox.Invoke(deleg, new object[] { textbox, text });
            }
            else
            {
                textbox.Text = text;
            }
        }
    }
}
