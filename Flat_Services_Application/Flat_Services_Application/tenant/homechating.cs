using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_Services_Application.tenant
{
    public partial class homechating : Form
    {
        public homechating()
        {
            InitializeComponent();
        }
        public homechating(string s, string p)
        {
            InitializeComponent();
            tbAccount.Text = s;
            tbroom.Text = p;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void homechating_Load(object sender, EventArgs e)
        {
            this.chatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.chatBtn.ForeColor = Color.White;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homenavigation homenavigation = new homenavigation(tbAccount.Text, tbroom.Text);
            homenavigation.StartPosition = FormStartPosition.CenterScreen;
            homenavigation.Show();
        }

        private void costsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homecostsing homecostsing = new homecostsing(tbAccount.Text, tbroom.Text);
            homecostsing.StartPosition = FormStartPosition.CenterScreen;
            homecostsing.Show();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeinformation homeinformation = new homeinformation(tbAccount.Text, tbroom.Text);
            homeinformation.StartPosition = FormStartPosition.CenterScreen;
            homeinformation.Show();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeservices homeservices = new homeservices(tbAccount.Text, tbroom.Text);
            homeservices.StartPosition = FormStartPosition.CenterScreen;
            homeservices.Show();
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homechating homechating = new homechating(tbAccount.Text, tbroom.Text);
            homechating.StartPosition = FormStartPosition.CenterScreen;
            homechating.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting homenavigation = new Setting(tbAccount.Text, tbroom.Text);
            homenavigation.StartPosition = FormStartPosition.CenterScreen;
            homenavigation.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
