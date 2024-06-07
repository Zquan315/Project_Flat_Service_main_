using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Type;
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
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public ChangePass()
        {
            InitializeComponent();
        }
        string sdt, obj;
        public ChangePass(string sdt, string obj)
        {
            InitializeComponent();
            this.sdt = sdt; 
            this.obj = obj;
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
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            string s = "";
            if(obj == "Lessor")
            {
                FirebaseResponse Response = await client.GetAsync("Account Lessor/" + sdt);
                if (Response.Body != "null")
                {
                    Data dt = Response.ResultAs<Data>();
                    s = Decode(dt.pass,3);
                }
            }    
            else if(obj == "Tenant")
            {
                FirebaseResponse Response = await client.GetAsync("Account Tenant/" + sdt);
                if (Response.Body != "null")
                {
                    Data dt = Response.ResultAs<Data>();
                    s = Decode(dt.pass, 3);
                }
            }    

            // dieu kien xet day phai la mat khau hien tai hay k -> kiem tra trong database, truy xuat bnag hien thi std
            if (tbCurrPass.Text == "" || !IsPass(tbCurrPass.Text))
            {
                lb1.Text = "!";
                lb1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                if(tbCurrPass.Text != s)
                {
                    lb1.Text = "!";
                    lb1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    lb1.Text = "";
                }
            }

            if(!IsPass(tbNewPass.Text) || tbNewPass.Text == "")
            {
                lb2.Text = "!";
                lb2.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lb2.Text = "";
            }

            if(tbConfirmNew.Text != tbNewPass.Text)
            {
                lb3.Text = "!";
                lb3.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lb3.Text = "";
            }
            if(obj == "Lessor")
            {
                FirebaseResponse respond = await client.GetAsync("Account Lessor/" + sdt);
                if (respond.Body != "null")
                {
                    Data dt = respond.ResultAs<Data>();
                    var data = new Data()
                    {
                        name = dt.name,
                        email = dt.email,
                        pass = Encode(tbNewPass.Text,3),
                        phone = dt.phone,
                        ID = dt.ID,
                        date = dt.date,
                        objects = dt.objects,
                        status = dt.status,
                        remember = dt.remember,
                        room = dt.room,
                    };
                    FirebaseResponse ud = await client.UpdateAsync("Account Lessor/" + sdt, data);
                    Data result = ud.ResultAs<Data>();
                }
            }    
            else if(obj == "Tenant")
            {
                FirebaseResponse respond = await client.GetAsync("Account Tenant/" + sdt);
                if (respond.Body != "null")
                {
                    Data dt = respond.ResultAs<Data>();
                    var data = new Data()
                    {
                        name = dt.name,
                        email = dt.email,
                        pass = Encode(tbNewPass.Text,3),
                        phone = dt.phone,
                        ID = dt.ID,
                        date = dt.date,
                        objects = dt.objects,
                        status = dt.status,
                        remember = dt.remember,
                        room = dt.room,
                    };
                    FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + sdt, data);
                    Data result = ud.ResultAs<Data>();
                }
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
                lb2.ForeColor = System.Drawing.Color.Red;
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
                lb1.ForeColor = System.Drawing.Color.Red;
            }
            else
                lb1.Text = "";
        }

        private void tbConfirmNew_TextChanged(object sender, EventArgs e)
        {
            if (tbConfirmNew.Text == "")
            {
                lb3.Text = "*";
                lb3.ForeColor = System.Drawing.Color.Red;
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

        private void ChangePass_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
                MessageBox.Show("Connected isn't Successful!");
        }
    }
}
