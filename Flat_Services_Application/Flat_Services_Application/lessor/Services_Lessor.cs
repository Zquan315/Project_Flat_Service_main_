using Bunifu.UI.WinForms;
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
    public partial class Services_Lessor : Form
    {
        FirestoreDb db;
        public Services_Lessor()
        {
            InitializeComponent();
        }
        string sdt;
        public Services_Lessor(string sdt)
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
            flat_Management_2.StartPosition = FormStartPosition.CenterScreen;
            flat_Management_2.Show();
        }

        private void Pay_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment_Lessor payment_Lessor = new Payment_Lessor(sdt);
            payment_Lessor.StartPosition = FormStartPosition.CenterScreen;
            payment_Lessor.Show();
        }

        private void Requests_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Requests_Lessor request_Lessor = new Requests_Lessor(sdt);
            request_Lessor.StartPosition = FormStartPosition.CenterScreen;
            request_Lessor.Show();
        }

        private void Chat_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat_Lessor chat_Lessor = new Chat_Lessor(sdt);
            chat_Lessor.StartPosition = FormStartPosition.CenterScreen;
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

        private void Add_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Service_Lessor add_Service_Lessor = new Add_Service_Lessor(sdt);
            add_Service_Lessor.StartPosition = FormStartPosition.CenterScreen;
            add_Service_Lessor.Show();
        }

        private void Setting_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings_Lessor settings_Lessor = new Settings_Lessor(sdt);
            settings_Lessor.StartPosition=FormStartPosition.CenterScreen;
            settings_Lessor.Show();
        }

        private void Services_Lessor_Load(object sender, EventArgs e)
        {
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
            // load listview1
            load_data1();

            //load listView2
            int[] room = { 101, 102, 103, 104, 105, 201, 202, 203, 204, 205, 301, 302, 303, 304, 305 };
            load_data2(room);
            
        }

        async void load_data1()
        {
            Query doc = db.Collection("ListServiceForRent");
            QuerySnapshot snap = await doc.GetSnapshotAsync();

            foreach (DocumentSnapshot sn in snap)
            {
                ListServiceForRent t = sn.ConvertTo<ListServiceForRent>();
                if (sn.Exists)
                {
                    string id = sn.Id.ToString();
                    ListViewItem data = new ListViewItem(id);
                    data.SubItems.Add(t.Name);
                    data.SubItems.Add(t.Price.ToString());
                    data.SubItems.Add(t.Note);
                    listView1.Items.Add(data);


                }
            }
        }

        async void load_data2(int [] room)
        {
            foreach(int roomId in room)
            {
                DocumentReference doc = db.Collection("ListAwaitService").Document(roomId.ToString());
                DocumentSnapshot snap = await doc.GetSnapshotAsync();
                if (snap.Exists)
                {
                    Dictionary<string, object> roomInfo = snap.ToDictionary();

                    foreach (var field in roomInfo)
                    {
                        if (field.Value is List<object> arrayData)
                        {
                            // Convert List<object> to List<string>
                            List<string> arrayValues = arrayData.ConvertAll(x => x.ToString());

                            ListViewItem data = new ListViewItem(roomId.ToString());
                            data.SubItems.Add(field.Key);
                            for (int i=0;i<arrayValues.Count;i++)
                            {
                                data.SubItems.Add(arrayValues[i]); 
                                
                            }

                            if (arrayValues[3].ToString() == "wait")
                                listView2.Items.Add(data);   
                                
                            
                        }
                    }
                }
            }
            
        }

        private void Services_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_Lessor services_Lessor = new Services_Lessor(sdt);
            services_Lessor.StartPosition=FormStartPosition.CenterScreen;
            services_Lessor.Show();
        }
    }
}
