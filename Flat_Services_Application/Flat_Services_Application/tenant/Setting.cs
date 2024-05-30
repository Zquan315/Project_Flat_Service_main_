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

namespace Flat_Services_Application.tenant
{
    public partial class Setting : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Setting()
        {
            InitializeComponent();
        }
        string room;
        public Setting(string s, string p)
        {
            InitializeComponent();
            Phone_tb.Text = s;
            room = p;
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void differencesfee_Load(object sender, EventArgs e)
        {
            this.differBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.differBtn.ForeColor = System.Drawing.Color.White;

            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
                MessageBox.Show("Connected isn't Successful!");
                return;
            }
            FirebaseResponse Response = await client.GetAsync("Account Tenant/" + Phone_tb.Text);
            if (Response.Body != "null")
            {
                Data dt = Response.ResultAs<Data>();
                Name_tb.Text = dt.name;
                Email_tb.Text = dt.email;
                ID_tb.Text = dt.ID;
            }
           
           
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homenavigation homenavigation = new homenavigation(Phone_tb.Text,room );
            homenavigation.StartPosition = FormStartPosition.CenterScreen;
            homenavigation.Show();
        }

        private void costsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homecostsing homecostsing = new homecostsing(Phone_tb.Text, room);
            homecostsing.StartPosition = FormStartPosition.CenterScreen;
            homecostsing.Show();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeinformation homeinformation = new homeinformation(Phone_tb.Text, room);   
            homeinformation.StartPosition = FormStartPosition.CenterScreen;
            homeinformation.Show();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeservices homeservices = new homeservices(Phone_tb.Text, room); 
            homeservices.StartPosition = FormStartPosition.CenterScreen;
            homeservices.Show();
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homechating homechating = new homechating(Phone_tb.Text, room);
            homechating.StartPosition = FormStartPosition.CenterScreen;
            homechating.Show();
        }

        private void differBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting differencesfee = new Setting(Phone_tb.Text, room);
            differencesfee.StartPosition = FormStartPosition.CenterScreen;
            differencesfee.Show();  
        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tbChangePass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePass p = new ChangePass(Phone_tb.Text);
            p.Show();
        }
    }
}
