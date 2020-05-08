using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Discord discordUser = new Discord(emailTextBox.Text, passwordTextBox.Text);
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
