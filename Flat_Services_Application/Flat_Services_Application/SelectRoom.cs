using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Flat_Services_Application.Class;
using Google.Cloud.Firestore;
using static System.Net.Mime.MediaTypeNames;

namespace Flat_Services_Application
{
    public partial class SelectRoom : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        FirestoreDb db;
        string sdt;
        public SelectRoom()
        {
            InitializeComponent();
        }
        public SelectRoom(string s)
        {
            InitializeComponent();
            this.sdt = s;
        }
        private void SelectRoom_Load(object sender, EventArgs e)
        {
            int[] room = { 101, 102, 103, 104, 105, 201, 202, 203, 204, 205, 301, 302, 303, 304, 305 };
            RadioButton[] IDroom = { rdb101, rdb102, rdb103, rdb104, rdb105, rdb201, rdb202, rdb203, rdb204, rdb205, rdb301, rdb302, rdb303, rdb304, rdb305 };
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Connected isn't Successful!");
                return;
            }

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"flatservice-a087e-firebase-adminsdk-e8i8j-118340432f.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("flatservice-a087e");
                Get_a_Data(room, IDroom);
            }
            catch
            {
                MessageBox.Show("Cann't connect to firestore!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        async void Get_a_Data(int[] room, RadioButton[] IDroom)
        {

            for (int i = 0; i < room.Length; i++)
            {
                DocumentReference doc = db.Collection("SelectRoom").Document(room[i].ToString());
                DocumentSnapshot snap = await doc.GetSnapshotAsync();
                if (snap.Exists)
                {
                    room1 t = snap.ConvertTo<room1>();
                    if (t.Status == 1)
                    {
                        IDroom[i].Enabled = false;
                        IDroom[i].Checked = false;
                        IDroom[i].Text = IDroom[i].Text + " - hired";
                    }
                    else
                        IDroom[i].Enabled = true;

                }
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login(sdt);
            login.Show();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            int[] room = { 101, 102, 103, 104, 105, 201, 202, 203, 204, 205, 301, 302, 303, 304, 305 };
            RadioButton[] IDroom = { rdb101, rdb102, rdb103, rdb104, rdb105, rdb201, rdb202, rdb203, rdb204, rdb205, rdb301, rdb302, rdb303, rdb304, rdb305 };
            if(check_select(IDroom))
            {
                try
                {
                    if (MessageBox.Show("Are you sure select this room?", "Select room", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        UpdateStatusRoom(room, IDroom);
                        MessageBox.Show("Please wait to be browsed by lessor!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        Login l = new Login();
                        l.Show();
                    }
                    else DialogResult = DialogResult.Cancel;
                }
                catch
                {
                    MessageBox.Show("Cann't connect to firestore!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select at least one!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }
        bool check_select(RadioButton[] IDroom)
        {
            foreach(RadioButton r in IDroom)
            {
                if (r.Checked)
                    return true;
            }
            return false;
        }
        
        async void UpdateStatusRoom(int[] room, RadioButton[] IDroom)
        {
            for (int i = 0; i < IDroom.Length; i++)
            {
                if (IDroom[i].Checked)
                {
                    DocumentReference docref = db.Collection("SelectRoom").Document(room[i].ToString());
                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    {
                        dict.Add("Status", 1);
                    }
                    DocumentSnapshot snap = await docref.GetSnapshotAsync();
                    if (snap.Exists)
                    {
                        await docref.UpdateAsync(dict);
                    }
                    FirebaseResponse res = await client.GetAsync("Account Tenant/" + sdt);
                    if (res.Body != "null")
                    {
                        Data dt = res.ResultAs<Data>();
                        var data = new Data()
                        {
                            name = dt.name,
                            email = dt.email,
                            pass = dt.pass,
                            phone = dt.phone,
                            ID = dt.ID,
                            date = dt.date,
                            objects = dt.objects,
                            status = 1,
                            remember = dt.remember,
                            room = room[i].ToString(),

                        };
                        FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + sdt, data);
                        Data result = ud.ResultAs<Data>();

                        // them list cho duyet boi lessor
                        DocumentReference DOC = db.Collection("ListAwaitBrowse").Document(sdt);
                        
                        Dictionary<string, object> dta = new Dictionary<string, object>();
                        {
                            dta.Add("Name",dt.name );
                            dta.Add("Room", room[i].ToString());
                        };
                        await DOC.SetAsync(dta);
                    }

                   
                   
                    return;
                }
            }
        }
    }
}
