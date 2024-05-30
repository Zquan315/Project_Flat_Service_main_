using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net;

namespace Flat_Services_Application
{
    public partial class Sign_up : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Sign_up()
        {
            InitializeComponent();
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void btnSign_up_Click(object sender, EventArgs e)
        {
            if (!cbTerm.Checked)
            {
                MessageBox.Show("Please accept our term!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tbName.Text == "")
            {
                lb1.Text = "!";
                lb1.ForeColor = Color.Red;
                return;
            }
            else lb1.Text = "";

            if (!IsEmail(tbEmail.Text.Trim()) || tbEmail.Text == "")
            {
                lb2.Text = "!";
                lb2.ForeColor = Color.Red;
                return;
            }
            else lb2.Text = "";
            if (!IsPass(tbPass.Text) || tbPass.Text == "")
            {
                lb3.Text = "!";
                lb3.ForeColor = Color.Red;
                return;
            }
            else lb3.Text = "";

            if (tbconfirmPass.Text != tbPass.Text || tbconfirmPass.Text == "")
            {
                lb4.Text = "!";
                lb4.ForeColor = Color.Red;
                return;
            }
            else
            {

                lb4.Text = "";
            }
            if (!IsNumberPhone(tbPhone.Text.Trim()) || tbPhone.Text == "")
            {
                lb5.Text = "!";
                lb5.ForeColor = Color.Red;
                return;
            }
            else
            {

                lb5.Text = "";
            }
            if (tbID.Text.Length != 12 || tbID.Text == "")
            {
                lb6.Text = "!";
                lb6.ForeColor = Color.Red;
                return;
            }
            else
            {

                lb6.Text = "";
            }
            if (!IsDate(tbDate.Text.Trim()) || tbDate.Text == "")
            {
                lb7.Text = "!";
                lb7.ForeColor = Color.Red;
                return;
            }
            else
            {

                lb7.Text = "";
            }

            if (cbbObj.Text == "")
            {
                lb8.Text = "!";
                lb8.ForeColor = Color.Red;
                return;
            }
            else
            {
                lb8.Text = "";
            }


            //Them du lieu vao database

            this.Hide();
            OTPSignUp f = new OTPSignUp(tbName.Text, tbEmail.Text, tbPass.Text, tbPhone.Text, tbID.Text, tbDate.Text, cbbObj.Text);
            f.Show();

            //MessageBox.Show("Sign-up successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //tbEmail.Text = "";
            //tbName.Text =   "";
            //tbPass.Text = "";
            //tbconfirmPass.Text = "";
            //tbPhone.Text = "";
            //tbID.Text = "";
            //tbDate.Text = "";
            //cbbObj.Text = "";
            //cbTerm.Checked = false;
            //dieu kien de quay lai login


        }

        public bool IsEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsPass(string pass)
        {
            if (pass.Length < 8)
                return false;
            return true;
        }

        public bool IsNumberPhone(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ' || (a[i] < '0' || a[i] > '9'))
                    return false;
            }
            if (a.Length < 10 || a.Length > 11)
                return false;
            return true;
        }

        public bool IsDate(string a)
        {
            int dem = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '/')
                    dem++;
            }
            if (dem != 2)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ')
                    return false;
            }
            if (a.Length != 10)
                return false;
            string[] s = a.Split('/');
            for (int i = 0; i < s.Length; i++)
            {
                if (!int.TryParse(s[i], out dem))
                {
                    return false;
                }
            }
            int day = int.Parse(s[1]);
            int month = int.Parse(s[0]);
            int year = int.Parse(s[2]);
            if (!laNgayHopLe(day, month, year))
                return false;
            return true;
        }

        


        // Hàm kiểm tra năm nhuận
        bool laNamNhuan(int nYear)
        {
            if ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0)
            {
                return true;
            }
            return false;

            // <=> return ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0);
        }

        // Hàm trả về số ngày trong tháng thuộc năm cho trước
        int tinhSoNgayTrongThang(int nMonth, int nYear)
        {
            int nNumOfDays = 0;

            switch (nMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    nNumOfDays = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    nNumOfDays = 30;
                    break;
                case 2:
                    if (laNamNhuan(nYear))
                    {
                        nNumOfDays = 29;
                    }
                    else
                    {
                        nNumOfDays = 28;
                    }
                    break;
            }

            return nNumOfDays;
        }

        // Hàm kiểm tra ngày dd/mm/yyyy cho trước có phải là ngày hợp lệ
        bool laNgayHopLe(int nDay, int nMonth, int nYear)
        {
            // Kiểm tra năm
            if (nYear < 0)
            {
                return false; // Ngày không còn hợp lệ nữa!
            }

            // Kiểm tra tháng
            if (nMonth < 1 || nMonth > 12)
            {
                return false; // Ngày không còn hợp lệ nữa!
            }

            // Kiểm tra ngày
            if (nDay < 1 || nDay > tinhSoNgayTrongThang(nMonth, nYear))
            {
                return false; // Ngày không còn hợp lệ nữa!
            }

            return true; // Trả về trạng thái cuối cùng...
        }

        private void Eye1_Click(object sender, EventArgs e)
        {
            Hidden1.BringToFront();
            tbPass.PasswordChar = '\0';
        }

        private void Hidden1_Click(object sender, EventArgs e)
        {
            Eye1.BringToFront();
            tbPass.PasswordChar = '*';
        }

        private void Eye2_Click(object sender, EventArgs e)
        {
            Hidden2.BringToFront();
            tbconfirmPass.PasswordChar = '\0';
        }

        private void Hidden2_Click(object sender, EventArgs e)
        {
            Eye2.BringToFront();
            tbconfirmPass.PasswordChar = '*';
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }

        private void tc1(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 0)
                lb1.Text = "";
            else
            {
                lb1.Text = "*";
                lb1.ForeColor = Color.Red;
            }

        }

        private void tc2(object sender, EventArgs e)
        {
            if (tbEmail.Text.Length > 0)
                lb2.Text = "";
            else
            {
                lb2.Text = "*";
                lb2.ForeColor = Color.Red;
            }
        }

        private void tc3(object sender, EventArgs e)
        {
            if (tbPass.Text.Length > 0)
                lb3.Text = "";
            else
            {
                lb3.Text = "*";
                lb3.ForeColor = Color.Red;
            }
        }

        private void tc4(object sender, EventArgs e)
        {
            if (tbconfirmPass.Text.Length > 0)
                lb4.Text = "";
            else
            {
                lb4.Text = "*";
                lb4.ForeColor = Color.Red;
            }
        }

        private void tc5(object sender, EventArgs e)
        {
            if (tbPhone.Text.Length > 0)
                lb5.Text = "";
            else
            {
                lb5.Text = "*";
                lb4.ForeColor = Color.Red;
            }
        }

        private void tc6(object sender, EventArgs e)
        {
            if (tbID.Text.Length > 0)
                lb6.Text = "";
            else
            {
                lb6.Text = "*";
                lb6.ForeColor = Color.Red;
            }
        }

        private void tc7(object sender, EventArgs e)
        {
            if (tbDate.Text.Length > 0)
                lb7.Text = "";
            else
            {
                lb7.Text = "*";
                lb7.ForeColor = Color.Red;
            }
        }

        private void tc8(object sender, EventArgs e)
        {
            if (cbbObj.Text.Length > 0)
                lb8.Text = "";
            else
            {
                lb8.Text = "*";
                lb8.ForeColor = Color.Red;
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void llbTerm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            term t = new term();    
            t.Show();
        }
    }
}
