using Flat_Services_Application.Class;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Flat_Services_Application.tenant
{
    public partial class homenavigation : Form
    {
        FirestoreDb db;
        public homenavigation()
        {
            InitializeComponent();
        }
        public homenavigation(string s, string p)
        {
            InitializeComponent();
            tbAccount.Text = s;
            tbroom.Text = p;    
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void chatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homechating homechating = new homechating(tbAccount.Text, tbroom.Text);
            homechating.StartPosition = FormStartPosition.CenterScreen;
            homechating.Show();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeservices homeservices = new homeservices(tbAccount.Text, tbroom.Text);
            homeservices.StartPosition = FormStartPosition.CenterScreen;
            homeservices.Show();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeinformation homeinformation = new homeinformation(tbAccount.Text, tbroom.Text);   
            homeinformation.StartPosition = FormStartPosition.CenterScreen;
            homeinformation.Show();
        }

        private void costsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homecostsing homecostsing = new homecostsing(tbAccount.Text, tbroom.Text);
            homecostsing.StartPosition = FormStartPosition.CenterScreen;
            homecostsing.Show();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homenavigation homenavigation = new homenavigation(tbAccount.Text, tbroom.Text);
            homenavigation.StartPosition = FormStartPosition.CenterScreen;
            homenavigation.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void homenavigation_Load(object sender, EventArgs e)
        {
            this.homeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.homeBtn.ForeColor = Color.White;
            //ket noi firestore
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"flatservice-a087e-firebase-adminsdk-e8i8j-118340432f.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("flatservice-a087e");
            }
            catch
            {
                MessageBox.Show("Cann't connect to firestore!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            get_Data();
        }

        async void get_Data()
        {
            DocumentReference doc = db.Collection("Notification").Document(tbroom.Text);
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> not = snap.ToDictionary();

                foreach (var field in not)
                {
                    if (field.Value is List<object> arrayData)
                    {
                        // Convert List<object> to List<string>
                        List<string> arrayValues = arrayData.ConvertAll(x => x.ToString());

                        // Check if the array has exactly 5 elements
                        for(int i=0; i< arrayValues.Count; i++)
                        {
                            listView1.Items.Add(arrayValues[i]);
                        }                          

                    }
                }

            }
        }
            private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting differencesfee = new Setting(tbAccount.Text, tbroom.Text);
            differencesfee.StartPosition = FormStartPosition.CenterScreen;
            differencesfee.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void DelBtn_Click(object sender, EventArgs e)
        {
            DocumentReference docRef = db.Collection("Notification").Document(tbroom.Text);


            Dictionary<string, object> updates = new Dictionary<string, object>
                    {
                        { "notification", new List<object>() }
                    };

            await docRef.UpdateAsync(updates);
            listView1.Items.Clear();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
