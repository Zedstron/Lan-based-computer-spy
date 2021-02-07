using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ChatForm : Form
    {
        public delegate void SetTextCallback(string s);

        public ChatForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoteClient.SendMessage(new global::DataObject
            {
                CommandType = "Chat",
                CommandName = "Message",
                CommandData = textBox1.Text
            });
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                RemoteClient.SendMessage(new global::DataObject
                {
                    CommandType = "Chat",
                    CommandName = "Message",
                    CommandData = textBox1.Text
                });
                textBox1.Text = "";
            }
        }

        /// <summary>
        /// This function is used to display Chat data in Rich Text Box.
        /// </summary>
        /// <param name="text"></param>
        public void SetChatText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetChatText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.SelectionColor = Color.DarkGray;
                // this.rtbChat.AppendText(text);
                this.richTextBox1.SelectedText = text + "\n";
                this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
                //this.rtbChat.HideSelection = false;
                this.richTextBox1.ScrollToCaret();
            }
        }
    }
}
