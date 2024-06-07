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

namespace Flat_Services_Application
{
    public partial class changePass_forgot : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        string data_phone = "";
        public changePass_forgot()
        {
            InitializeComponent();
        }
        public changePass_forgot(string s)
        {
            InitializeComponent();
            data_phone = s;
        }
        private void Eye2_Click(object sender, EventArgs e)
        {
            Hidden2.BringToFront();
            tbNewPass.PasswordChar = '\0';
        }

        private void Eye3_Click(object sender, EventArgs e)
        {
            Hidden3.BringToFront();
            tbConfirmNew.PasswordChar = '\0';
        }

        private void Hidden2_Click(object sender, EventArgs e)
        {
            Eye2.BringToFront();
            tbNewPass.PasswordChar = '*';
        }

        private void Hidden3_Click(object sender, EventArgs e)
        {
            Eye3.BringToFront();
            tbConfirmNew.PasswordChar = '*';
        }

        private void tbNewPass_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPass.Text == "")
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
                lb2.Text = "*";
                lb2.ForeColor = Color.Red;
            }
            else
                lb2.Text = "";
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


            if (tbNewPass.Text == "" || tbConfirmNew.Text == "")
            {
                return;
            }
            if (!IsPass(tbNewPass.Text))
            {
                lb1.Text = "!";
                lb1.ForeColor = Color.Red;
                return;
            }
            if (tbConfirmNew.Text != tbNewPass.Text)
            {
                lb2.Text = "!";
                lb2.ForeColor = Color.Red;
                return;
            }
            // truy xuat sdt de cap nhat

            FirebaseResponse respond = await client.GetAsync("Account Lessor/" + data_phone);
            if (respond.Body != "null")
            {
                Data dt = respond.ResultAs<Data>();
                var data = new Data()
                {
                    name = dt.name,
                    email = dt.email,
                    pass = Encode(tbNewPass.Text, 3),
                    phone = dt.phone,
                    ID = dt.ID,
                    date = dt.date,
                    objects = dt.objects,
                    status = dt.status,
                    remember = dt.remember,
                    room = dt.room,
                };
                FirebaseResponse ud = await client.UpdateAsync("Account Lessor/" + data_phone, data);
                Data result = ud.ResultAs<Data>();


            }
            else
            {
                FirebaseResponse responds = await client.GetAsync("Account Tenant/" + data_phone);
                if (responds.Body != "null")
                {
                    Data dt = responds.ResultAs<Data>();
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

                    FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + data_phone, data);
                    Data result = ud.ResultAs<Data>();
                }
                else
                    return;

            }
            MessageBox.Show("Change password successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Login l = new Login();
            l.Show();

        }
        public bool IsPass(string pass)
        {
            if (pass.Length < 8)
                return false;
            return true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f = new Login();
            f.Show();
        }

        private void changePass_forgot_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
                MessageBox.Show("Connected isn't Successful!");
        }
    }
}
