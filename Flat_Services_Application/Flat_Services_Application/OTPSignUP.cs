using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Flat_Services_Application
{

    public partial class OTPSignUp : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        Random random = new Random();
        int otp;
        string name, email, pass, sdt, id, date, obj;

        public OTPSignUp()
        {
            InitializeComponent();
        }
        public OTPSignUp(string name, string email, string pass, string sdt, string id, string date, string obj)
        {
            InitializeComponent();
            tbMail.Text = email;
            this.name = name;
            this.email = email;
            this.pass = pass;
            this.sdt = sdt;
            this.id = id;
            this.date = date;
            this.obj = obj;
        }

        private void OTPSignUp_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
                MessageBox.Show("Connected isn't Successful!");
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {

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
                var data = new Data
                {
                    name = this.name,
                    email = this.email,
                    pass = Encode(this.pass,3),
                    phone = this.sdt,
                    ID = this.id,
                    date = this.date,
                    objects = this.obj,
                    status = 0,
                    remember = 0,
                    room = ""

                };
                FirebaseResponse respond = await client.GetAsync("Account Lessor/" + this.sdt);
                if (respond.Body != "null")
                {
                    MessageBox.Show("This phone number is used!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    FirebaseResponse responds = await client.GetAsync("Account Tenant/" + this.sdt);
                    if (responds.Body != "null")
                    {
                        MessageBox.Show("This phone number is used!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        lb1.Text = "";
                    }
                }
                if (obj == "Tenant")
                {
                    SetResponse Response = await client.SetAsync("Account Tenant/" + this.sdt, data);
                    Data result = Response.ResultAs<Data>();
                }

                if (obj == "Lessor")
                {
                    SetResponse Response = await client.SetAsync("Account Lessor/" + this.sdt, data);
                    Data result = Response.ResultAs<Data>();
                }
                MessageBox.Show("Sign-up successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Sign_up s = new Sign_up();
                s.Show();
            }
        }

        public static string Encode(string input, int shift)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char letterOffset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)((letter + shift - letterOffset + 26) % 26 + letterOffset);
                }
                else if (char.IsDigit(letter))
                {
                    char digitOffset = '0';
                    letter = (char)((letter + shift - digitOffset + 10) % 10 + digitOffset);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        private void tbOTP_TextChanged_1(object sender, EventArgs e)
        {
            if (tbOTP.Text == "")
            {
                lb2.Text = "*";
                lb2.ForeColor = Color.Red;
            }
            else
                lb2.Text = "";
        }

        private void lb2_Click(object sender, EventArgs e)
        {

        }

        public static string Decode(string input, int shift)
        {
            // Decoding is simply encoding with the negative shift
            return Encode(input, -shift);
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_up s = new Sign_up();
            s.Show();
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

        private void tbMail_TextChanged(object sender, EventArgs e)
        {
            if (tbMail.Text == "")
            {
                lb1.Text = "*";
                lb1.ForeColor = Color.Red;
            }
            else
                lb1.Text = "";
        }
    }
}
