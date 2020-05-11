using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(54, 57, 63);
            if (DiscordLogging.isLogged == false)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void watchBtn_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    DiscordChannel channel = new DiscordChannel(channelIdTextBox.Text);
                    BeginInvoke(new Action(CheckMessages));
                }
            });
        }

        private void channelMsgsTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        // check every 5 seconds for new messages & place them in the textbox
        private void CheckMessages()
        {
            channelMsgsTextBox.Text = "";
            for (int i = DiscordChannel.messages.Count -1; i >= 0; i--)
            {
                channelMsgsTextBox.Text += DiscordChannel.messages[i].author.username + " : " + DiscordChannel.messages[i].content + Environment.NewLine;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                messageTextBox.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void messageTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
