using Flat_Services_Application.tenant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Flat_Services_Application.Class;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Web.UI;
using System.Collections;

namespace Flat_Services_Application.lessor
{
    public partial class Requests_Lessor : Form
    {
        FirestoreDb db;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Requests_Lessor()
        {
            InitializeComponent();
        }
        string sdt;
        public Requests_Lessor(string sdt)
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

        private void Setting_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings_Lessor settings_Lessor = new Settings_Lessor(sdt);
            settings_Lessor.StartPosition=FormStartPosition.CenterScreen;
            settings_Lessor.Show();
        }

        private void Services_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_Lessor services_Lessor = new Services_Lessor(sdt);
            services_Lessor.StartPosition = FormStartPosition.CenterScreen;
            services_Lessor.Show();
        }

        private void Requests_Lessor_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Connected isn't Successful!");
                return;
            }
               
            // ket noi firestore
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"flatservice-a087e-firebase-adminsdk-e8i8j-118340432f.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("flatservice-a087e");
                Get_Data();
            }
            catch
            {
                MessageBox.Show("Cann't connect to firestore!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        async void Get_Data()
        {
            //them vao listview
              Query doc = db.Collection("ListAwaitBrowse");
              QuerySnapshot snap = await doc.GetSnapshotAsync();

              foreach (DocumentSnapshot sn in snap)
              {
                    listRequest t = sn.ConvertTo<listRequest>();
                    if (sn.Exists)
                    {
                    string id = sn.Id.ToString();
                    if(id != "Y2ei5yHeMvo1vfa96Gfz")
                    {
                        ListViewItem data = new ListViewItem(id);
                        data.SubItems.Add(t.Name);
                        data.SubItems.Add(t.Room);
                        lvRequest.Items.Add(data);
                    }    
                    
                }
              }
        }

        private async void btnBrowse_Click(object sender, EventArgs e)
        {
            if (lvRequest.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select account that you want to browse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            while (lvRequest.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvRequest.SelectedItems[0];
                string phone_num = selectedItem.SubItems[0].Text;  
                string room = selectedItem.SubItems[2].Text;
                string name = "" , id = "", date = "";
                // cap nhat lai status cua user
                FirebaseResponse responds = await client.GetAsync("Account Tenant/" + phone_num);
                if (responds.Body != "null")
                {
                    Data dt = responds.ResultAs<Data>();
                    name = dt.name;
                    id = dt.ID;
                    date = dt.date;
                    var data = new Data()
                    {
                        name = dt.name,
                        email = dt.email,
                        pass = dt.pass,
                        phone = dt.phone,
                        ID = dt.ID,
                        date = dt.date,
                        objects = dt.objects,
                        status = 2,
                        remember = dt.remember,
                        room = dt.room,
                    };

                    FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + phone_num, data);
                    Data result = ud.ResultAs<Data>();
                }

                // xoa 1 docment trong list
                delete_Document(phone_num);

                // them vao room info
                add_data_roomInfo(phone_num, room, name, id, date);
                //xoa ra khoi listview
                lvRequest.Items.RemoveAt(lvRequest.SelectedItems[0].Index);

            }
        }

        void add_data_roomInfo(string p, string r, string n, string i, string d)
        {
            DocumentReference DOC = db.Collection("RoomInfo").Document(r);
            Dictionary<string, object> maindt = new Dictionary<string, object>();
            
            ArrayList arr = new ArrayList();
            arr.Add(n);
            arr.Add(i);
            arr.Add("");
            arr.Add(d);
            arr.Add("");
            maindt.Add(p, arr);
            DOC.SetAsync(maindt);
        }
        void delete_Document(string s)
        {
            DocumentReference dr = db.Collection("ListAwaitBrowse").Document(s);
            dr.DeleteAsync();
        }

        async void update_room_status(string s)
        {
            DocumentReference docref = db.Collection("SelectRoom").Document(s);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            {
                dict.Add("Status", 0);
            }
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.UpdateAsync(dict);
            }
        }
        private async void btnNoBrowse_Click(object sender, EventArgs e)
        {
            if(lvRequest.SelectedItems.Count<= 0)
            {
                MessageBox.Show("Please select account that you don't want to browse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            while (lvRequest.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvRequest.SelectedItems[0];
                string phone_num = selectedItem.SubItems[0].Text;
                string room = selectedItem.SubItems[2].Text;

                // cap nhat lai status = 0, xoa phong cua user
                FirebaseResponse responds = await client.GetAsync("Account Tenant/" + phone_num);
                if (responds.Body != "null")
                {
                    Data dt = responds.ResultAs<Data>();
                    var data = new Data()
                    {
                        name = dt.name,
                        email = dt.email,
                        pass = dt.pass,
                        phone = dt.phone,
                        ID = dt.ID,
                        date = dt.date,
                        objects = dt.objects,
                        status = 0,
                        remember = dt.remember,
                        room = "",
                    };

                    FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + phone_num, data);
                    Data result = ud.ResultAs<Data>();
                }

                // xoa 1 docment trong list
                delete_Document(phone_num);
                // cap nhat lai trang thai phong
                update_room_status(room);
                //xoa ra khoi listview
                lvRequest.Items.RemoveAt(lvRequest.SelectedItems[0].Index);
            }
        }

        private void lvRequest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Requests_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Requests_Lessor requests_Lessor = new Requests_Lessor(sdt);
            requests_Lessor.StartPosition = FormStartPosition.CenterParent;
            requests_Lessor.Show();
        }
    }
}
