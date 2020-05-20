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
        private string messageToSend;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DiscordLogging.GetLoggedInfos();
            if (DiscordLogging.isLogged == false)
            {
                this.Close();
            }
            loggedUser.Text = DiscordLogging.loggedUserAndDiscrim;
            this.BackColor = Color.FromArgb(54, 57, 63);
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
                    Thread.Sleep(500);
                }
            });
        }

        private void channelMsgsTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (messageTextBox.Text.Contains("/delete"))
                {
                    try
                    {
                        int position = messageTextBox.Text.IndexOf(" ");
                        int amountOfMsgsToDelete = Convert.ToInt32(messageTextBox.Text.Substring(position+1));
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        messageTextBox.Text = "";
                        new Thread(() => DeleteMessages(amountOfMsgsToDelete)).Start();
                    }
                    catch (Exception)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        this.messageToSend = messageTextBox.Text;
                        messageTextBox.Text = "";
                        new Thread(() => DiscordChannel.SendMessage(messageToSend)).Start();
                    }
                }
                else
                { 
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    this.messageToSend = messageTextBox.Text;
                    messageTextBox.Text = "";
                    new Thread(() => DiscordChannel.SendMessage(messageToSend)).Start();
                }
            }
        }

        private void messageTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }


        private void CheckMessages()
        {
            channelMsgsTextBox.Text = "";
            for (int i = DiscordChannel.messages.Count - 1; i >= 0; i--)
            {
                channelMsgsTextBox.Text += DiscordChannel.messages[i].author.username + "#" + DiscordChannel.messages[i].author.discriminator + " : " + DiscordChannel.messages[i].content + Environment.NewLine;
            }
            channelMsgsTextBox.AppendText(" ");
        }

        private void DeleteMessages(int amountToDelete)
        {
            if (amountToDelete > DiscordChannel.messages.Count)
            {
                amountToDelete = DiscordChannel.messages.Count;
            }
            
            for (int i = 0; i < amountToDelete ; i++)
            {
                DiscordChannel.DeleteMessage(DiscordChannel.messages[0].id);
                Thread.Sleep(500);
            }
        }

        private void loggedUser_Click(object sender, EventArgs e)
        {

        }
    }
}
