using Flat_Services_Application.Class;
using Flat_Services_Application.tenant;
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

namespace Flat_Services_Application.lessor
{
    public partial class Payment_Lessor : Form
    {
        FirestoreDb db;
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            lvData.Items.Clear();
            if(cbbSearch.Text == "" || cbbSearch.Text == "All")
            {
                cbbSearch.Text = "All";
                load_all_data();
            }    
            else
                load_a_data();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSearch.Text == "")
                cbbSearch.Text = "All";
        }

        private void Payment_Lessor_Load(object sender, EventArgs e)
        {
            cbbSearch.Text = "All";
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
            load_all_data();
        }

        async void load_all_data()
        {
            Query doc = db.Collection("Bill");
            QuerySnapshot snap = await doc.GetSnapshotAsync();

            foreach (DocumentSnapshot sn in snap)
            {
                
                if (sn.Exists)
                {
                    Bill t = sn.ConvertTo<Bill>();
                    string id = sn.Id.ToString();
                    ListViewItem data = new ListViewItem(id);
                    data.SubItems.Add(t.Room_price);
                    data.SubItems.Add(t.elec);
                    data.SubItems.Add(t.amount_Elec.ToString());
                    data.SubItems.Add(t.water);
                    data.SubItems.Add(t.amount_water.ToString());
                    data.SubItems.Add(t.clean);
                    data.SubItems.Add(t.secu);
                    data.SubItems.Add(t.service);
                    data.SubItems.Add(t.debit);
                    data.SubItems.Add(t.total);
                    lvData.Items.Add(data);
                }
            }
        }
        async void load_a_data()
        {
            Query doc = db.Collection("Bill");
            QuerySnapshot snap = await doc.GetSnapshotAsync();

            foreach (DocumentSnapshot sn in snap)
            {

                if (sn.Exists)
                {
                    Bill t = sn.ConvertTo<Bill>();
                    string id = sn.Id.ToString();
                    if(id == cbbSearch.Text)
                    {
                        ListViewItem data = new ListViewItem(id);
                        data.SubItems.Add(t.Room_price);
                        data.SubItems.Add(t.elec);
                        data.SubItems.Add(t.amount_Elec.ToString());
                        data.SubItems.Add(t.water);
                        data.SubItems.Add(t.amount_water.ToString());
                        data.SubItems.Add(t.clean);
                        data.SubItems.Add(t.secu);
                        data.SubItems.Add(t.service);
                        data.SubItems.Add(t.debit);
                        data.SubItems.Add(t.total);
                        lvData.Items.Add(data);
                        return;
                    }    
                    
                }
            }
        }
    }
}
