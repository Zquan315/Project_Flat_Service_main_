using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Mail;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net;
using System.Xml.Linq;
using Flat_Services_Application.tenant;

namespace Flat_Services_Application
{
    public partial class Login : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Login()
        {
            InitializeComponent();
        }
        public Login(string s)
        {
            InitializeComponent();
            tbPhoneNumber.Text = s;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void llbSign_up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Sign_up s = new Sign_up();
            s.Show();
                
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tbPhoneNumber.Text == "")
                return;
            if(!rdbtnLessor.Checked && !rdbtnTenant.Checked )
            {
                MessageBox.Show("Please choose Tenant or Lessor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(rdbtnLessor.Checked)
            {
                FirebaseResponse Response = await client.GetAsync("Account Lessor/" + tbPhoneNumber.Text);
                if (Response.Body == "null")
                {
                    lbps1.Text = "Account is not existed";
                    lbps1.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    Data dt = Response.ResultAs<Data>();
                    lbps1.Text = "";
                    this.Hide();
                    ForgotPass forgotPass = new ForgotPass(dt.email,tbPhoneNumber.Text);
                    forgotPass.Show();
                   
                }
            }
               
            if(rdbtnTenant.Checked)
            {
                FirebaseResponse Response = await client.GetAsync("Account Tenant/" + tbPhoneNumber.Text);
                if (Response.Body == "null")
                {
                    lbps1.Text = "Account is not existed";
                    lbps1.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    Data dt = Response.ResultAs<Data>();
                    lbps1.Text = "";
                    this.Hide();
                    ForgotPass forgotPass = new ForgotPass(dt.email, tbPhoneNumber.Text);
                    forgotPass.Show();
                   
                }
            }
               
             
            
        }

        public bool IsNumberPhone(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ' || (a[i] < '0' && a[i] > '9'))
                    return false;
            }
            if (a.Length < 10 || a.Length > 11)
                return false;
            return true;
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

        public static string Decode(string input, int shift)
        {
            // Decoding is simply encoding with the negative shift
            return Encode(input, -shift);
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!rdbtnLessor.Checked && !rdbtnTenant.Checked)
            {
                MessageBox.Show("Please choose Tenant or Lessor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbPhoneNumber.Text == "" || !IsNumberPhone(tbPhoneNumber.Text))
            {
                lbps1.Text = "*";
                lbps1.ForeColor = Color.Red;
                return;
            }
            if(tbPass.Text == "")
            {
                lbps2.Text = "*";
                lbps2.ForeColor = Color.Red;
                return;
            }
            
            
            

            if(rdbtnTenant.Checked)
            {
                FirebaseResponse Response = await client.GetAsync("Account Tenant/" + tbPhoneNumber.Text);
                if (Response.Body == "null")
                {
                    lbps1.Text = "Account is not existed";
                    lbps1.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    lbps1.Text = "";

                }
                Data dt = Response.ResultAs<Data>();


                if (tbPass.Text != Decode(dt.pass,3))
                {
                    lbps2.Text = "Wrong";
                    lbps2.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    lbps2.Text = "";

                }

                if (cbRemember.Checked)
                {
                    var data = new Data()
                    {
                        name = dt.name,
                        email = dt.email,
                        pass = dt.pass,
                        phone = dt.phone,
                        ID = dt.ID,
                        date = dt.date,
                        objects = dt.objects,
                        status = dt.status,
                        remember = 1,
                        room = dt.room,
                    };
                    FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + tbPhoneNumber.Text, data);
                    Data result = ud.ResultAs<Data>();
                }
                if (dt.status == 0)
                {
                    this.Hide();
                    SelectRoom s = new SelectRoom(tbPhoneNumber.Text);
                    s.Show();
                }
                else if (dt.status == 1)
                    MessageBox.Show("Please wait to be browsed by lessor!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    this.Hide();
                    homenavigation h = new homenavigation(tbPhoneNumber.Text, dt.room);
                    h.StartPosition = FormStartPosition.CenterScreen;
                    h.Show();
                }
                //them luong hien thi form login

            }
            if (rdbtnLessor.Checked)
            {
                FirebaseResponse Response = await client.GetAsync("Account Lessor/" + tbPhoneNumber.Text);
                if (Response.Body == "null")
                {
                    lbps1.Text = "Account is not existed";
                    lbps1.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    lbps1.Text = "";

                }
                Data obj = Response.ResultAs<Data>();



                if (tbPass.Text != Decode(obj.pass,3))
                {
                    lbps2.Text = "Wrong";
                    lbps2.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    lbps2.Text = "";
                }
                if (cbRemember.Checked)
                {
                    var data = new Data()
                    {
                        name = obj.name,
                        email = obj.email,
                        pass = obj.pass,
                        phone = obj.phone,
                        ID = obj.ID,
                        date = obj.date,
                        objects = obj.objects,
                        status = obj.status,
                        remember = 1,
                        room = obj.room,
                    };
                    FirebaseResponse ud = await client.UpdateAsync("Account Lessor/" + tbPhoneNumber.Text, data);
                    Data result = ud.ResultAs<Data>();
                }
                this.Hide();
                Home_Lessor a = new Home_Lessor(tbPhoneNumber.Text);
                a.StartPosition = FormStartPosition.CenterScreen;
                a.Show();

                //them luong hien thi form login
            }




        }
       
        private void Eye_Click(object sender, EventArgs e)
        {
            Hidden.BringToFront();
            tbPass.PasswordChar = '\0';
        }

        private void Hidden_Click(object sender, EventArgs e)
        {
            Eye.BringToFront();
            tbPass.PasswordChar = '*';
        }

        
        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {
            
        }
       

        private void Login_Load_1(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
                MessageBox.Show("Connected isn't Successful!");
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lbps1_Click(object sender, EventArgs e)
        {

        }

        private void phone_tc(object sender, EventArgs e)
        {
            
        }

        private void pass_tc(object sender, EventArgs e)
        {
           
        }

        private void tc_number(object sender, EventArgs e)
        {
            if (tbPhoneNumber.Text != "")
                lbps1.Text = "";
            else
            {
                lbps1.Text = "*";
                lbps1.ForeColor = Color.Red;
            }
        }

        private void tc_pass(object sender, EventArgs e)
        {
            if (tbPass.Text != "")
                lbps2.Text = "";
            else
            {
                lbps2.Text = "*";
                lbps2.ForeColor = Color.Red;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            
        }

        private async void click_rmb(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnLessor.Checked)
                {

                    FirebaseResponse Response = await client.GetAsync("Account Lessor/" + tbPhoneNumber.Text);
                    if (Response.Body != "null")
                    {
                        Data obj = Response.ResultAs<Data>();
                        if (obj.remember == 1)
                        {
                            tbPass.Text = Decode(obj.pass, 3);
                        }
                    }

                }

                if (rdbtnTenant.Checked)
                {

                    FirebaseResponse Response = await client.GetAsync("Account Tenant/" + tbPhoneNumber.Text);
                    if (Response.Body != "null")
                    {
                        Data obj = Response.ResultAs<Data>();
                        if (obj.remember == 1)
                        {
                            tbPass.Text = Decode(obj.pass, 3);
                            //hello
                        }
                    }


                }
            }
            catch { return; }
        }
    }
}
