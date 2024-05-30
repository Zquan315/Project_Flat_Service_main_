using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net;
using System.Xml.Linq;
using System.Net.Mail;

namespace Flat_Services_Application
{
    public partial class ForgotPass : Form
    {
        Random random = new Random();
        int otp;
        public ForgotPass()
        {
            InitializeComponent();
        }

        string dt_phone;
        public ForgotPass(String s, string p)
        {
            InitializeComponent();
            tbMail.Text = s;
            dt_phone = p;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //neu sdt ton tai, otp gui ve may dung thi dang hap thanh cong
            if (tbOTP.Text == "" || tbMail.Text == "")
                return;
            if (!IsEmail(tbMail.Text))
            {
                lb1.Text = "!";
                lb1.ForeColor = Color.Red;
                return;
            }
            //dieu kien otp
            if (tbOTP.Text != otp.ToString())
            {
                lb2.Text = "!";
                lb2.ForeColor = Color.Red;
                return;
            }
            else
            {
                this.Hide();
                changePass_forgot c = new changePass_forgot(dt_phone);
                c.Show();
            }

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
        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (tbMail.Text == "")
            {
                lb1.Text = "*";
                lb1.ForeColor = Color.Red;
            }
            else
                lb1.Text = "";
        }

        private void tbOTP_TextChanged(object sender, EventArgs e)
        {
            if (tbOTP.Text == "")
            {
                lb2.Text = "*";
                lb2.ForeColor = Color.Red;
            }
            else
                lb2.Text = "";
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

        private void ForgotPass_Load(object sender, EventArgs e)
        {

        }

        private void GetBtn_Click(object sender, EventArgs e)
        {
            try
            {


                otp = random.Next(100000, 999999);
                var fromAddress = new MailAddress("flatservicesapp@gmail.com");
                var toAdddress = new MailAddress(tbMail.Text);
                const string fromPass = "tstkbzqeorjvozsn";
                const string subject = "OTP Code From Flat Service";
                string body = "Your OTP code is: " + otp.ToString() + ". Please don't share with anyone!";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPass),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddress, toAdddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
