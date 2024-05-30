using Flat_Services_Application.tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_Services_Application.lessor
{
    public partial class Payment_Lessor : Form
    {
        public Payment_Lessor()
        {
            InitializeComponent();
        }
        string sdt;
        public Payment_Lessor(string sdt)
        {
            InitializeComponent();
            this.sdt = sdt;
        }
        private void Home_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Lessor home_Lessor = new Home_Lessor(sdt);
            home_Lessor.StartPosition = FormStartPosition.CenterScreen;
            home_Lessor.Show();
        }

        private void Flat_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flat_Management_2 flat_Management_2 = new Flat_Management_2(sdt);
            flat_Management_2.StartPosition= FormStartPosition.CenterScreen;
            flat_Management_2.Show();
        }

        private void Requests_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Requests_Lessor requests_Lessor = new Requests_Lessor(sdt);
            requests_Lessor.StartPosition= FormStartPosition.CenterScreen;
            requests_Lessor.Show();
        }

        private void Chat_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat_Lessor chat_Lessor = new Chat_Lessor(sdt);
            chat_Lessor.StartPosition= FormStartPosition.CenterScreen;
            chat_Lessor.Show();
        }

        private void LogOut_btn_Click(object sender, EventArgs e)
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

        private void Setting_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings_Lessor settings_Lessor = new Settings_Lessor(sdt);
            settings_Lessor.StartPosition = FormStartPosition.CenterScreen;
            settings_Lessor.Show();
        }

        private void Charge_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Services_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_Lessor services_Lessor = new Services_Lessor(sdt);
            services_Lessor.StartPosition = FormStartPosition.CenterScreen;
            services_Lessor.Show();
        }

        private void Pay_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment_Lessor payment_Lessor = new Payment_Lessor(sdt);
            payment_Lessor.StartPosition = FormStartPosition.CenterScreen;
            payment_Lessor.Show();
        }
    }
}
