using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_Services_Application
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }
        string sdt;
        public ChangePass(string sdt)
        {
            InitializeComponent();
            this.sdt = sdt; 
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // dieu kien xet day phai la mat khau hien tai hay k -> kiem tra trong database, truy xuat bnag hien thi std
            
            if(!IsPass(tbNewPass.Text))
            {
                lb2.Text = "!";
                lb2.ForeColor = Color.Red;
                return;
            }
            if(tbConfirmNew.Text != tbNewPass.Text)
            {
                lb3.Text = "!";
                lb3.ForeColor = Color.Red;
                return;
            }
            MessageBox.Show("Change Password successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //dieu kien de confirm
            this.Hide();
            Login login = new Login();  
            login.Show();
        }

        public bool IsPass(string pass)
        {
            if (pass.Length < 8)
                return false;
            return true;
        }

        private void Hidden1_Click(object sender, EventArgs e)
        {
            tbCurrPass.PasswordChar = '*';
            Eye1.BringToFront();
        }

        private void Hidden2_Click(object sender, EventArgs e)
        {
            tbNewPass.PasswordChar = '*';
            Eye2.BringToFront();
        }

        private void Hidden3_Click(object sender, EventArgs e)
        {
            tbConfirmNew.PasswordChar = '*';
            Eye3.BringToFront();
        }

        private void Eye1_Click(object sender, EventArgs e)
        {
            tbCurrPass.PasswordChar = '\0';
            Eye1.SendToBack();
        }

        private void Eye2_Click(object sender, EventArgs e)
        {
            tbNewPass.PasswordChar = '\0';
            Eye2.SendToBack();
        }

        private void Eye3_Click(object sender, EventArgs e)
        {
            tbConfirmNew.PasswordChar = '\0';
            Eye3.SendToBack();
        }

        private void tbNewPass_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPass.Text == "")
            {
                lb2.Text = "*";
                lb2.ForeColor = Color.Red;
            }
            else
                lb2.Text = "";
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void tbCurrPass_TextChanged(object sender, EventArgs e)
        {
            if (tbCurrPass.Text == "")
            {
                lb1.Text = "*";
                lb1.ForeColor = Color.Red;
            }
            else
                lb1.Text = "";
        }

        private void tbConfirmNew_TextChanged(object sender, EventArgs e)
        {
            if (tbConfirmNew.Text == "")
            {
                lb3.Text = "*";
                lb3.ForeColor = Color.Red;
            }
            else
                lb3.Text = "";
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            //test
            // test lan 2
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("You must log out!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Hide();
                    Login l = new Login();
                    l.Show();
                }
        }
    }
}
