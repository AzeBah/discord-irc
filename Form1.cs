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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(54, 57, 63);
            StreamManip.LoadToken();
            CheckToken();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                DiscordLogging discordUser = new DiscordLogging(emailTextBox.Text, passwordTextBox.Text);
            });

            if (DiscordLogging.isLogged == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong credentials ;u");
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void CheckToken()
        {
            if (DiscordLogging.isLogged == true)
            {
                this.Close();
            }
        }
    }
}
