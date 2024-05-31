using Bunifu.UI.WinForms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Flat_Services_Application.lessor
{
    public partial class Flat_Info_Lessor : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        FirestoreDb db;
        public Flat_Info_Lessor()
        {
            InitializeComponent();
        }

        public Flat_Info_Lessor(string room)
        {
            InitializeComponent();
            IDRoomLb.Text = room;
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Flat_Management_2 flat_Management_2 = new Flat_Management_2();
            flat_Management_2.StartPosition = FormStartPosition.CenterScreen;
            flat_Management_2.Show();
        }

        private void Flat_Info_Lessor_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Connected isn't Successful!");
                return;
            }

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
            // load data len listview
            get_Data();
        }

        async void get_Data()
        {
            DocumentReference doc = db.Collection("RoomInfo").Document(IDRoomLb.Text);
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

                        // Check if the array has exactly 5 elements
                        if (arrayValues.Count == 5)
                        {
                            ListViewItem data = new ListViewItem(field.Key); // Phone number as the first column
                            data.SubItems.Add(arrayValues[0]); // Name
                            data.SubItems.Add(arrayValues[1]); // ID
                            data.SubItems.Add(arrayValues[2]); // Sex
                            data.SubItems.Add(arrayValues[3]); // Date of birth
                            data.SubItems.Add(arrayValues[4]); // ID vehical
                            lvData.Items.Add(data);
                        }
                        else
                        {
                            MessageBox.Show($"Array {field.Key} does not have exactly 5 elements.");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Field {field.Key} is not an array.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Document does not exist");
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure reset this room?", "Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                DocumentReference docRef = db.Collection("RoomInfo").Document(IDRoomLb.Text);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> updates = new Dictionary<string, object>();

                    foreach (var field in snapshot.ToDictionary())
                    {
                        if (field.Value is IList<object>)
                        {
                            updates[field.Key] = FieldValue.Delete;
                            // cap nhat lai user
                            FirebaseResponse responds = await client.GetAsync("Account Tenant/" + field.Key.ToString());
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

                                FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + field.Key.ToString(), data);
                                Data result = ud.ResultAs<Data>();
                            }

                            //cap nhat lai phong
                            DocumentReference docref = db.Collection("SelectRoom").Document(IDRoomLb.Text);
                            Dictionary<string, object> dict = new Dictionary<string, object>();
                            {
                                dict.Add("Status", 0);
                            }
                            DocumentSnapshot snap = await docref.GetSnapshotAsync();
                            if (snap.Exists)
                            {
                                await docref.UpdateAsync(dict);

                            }
                            // Reset notification
                            ResetNoti(IDRoomLb.Text);

                            // Reset debit
                            ResetDebit(IDRoomLb.Text);

                            // Reset ListAwaitService
                            ResetAwaitService(IDRoomLb.Text);

                            // Reset ServiceMoney
                            ResetServiceMoney(IDRoomLb.Text);

                            // Reset bill
                        }
                    }

                    if (updates.Count > 0)
                    {
                        await docRef.UpdateAsync(updates);
                        MessageBox.Show("Reset successfully", "Inforrmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                lvData.Items.Clear();
            }
            else
                DialogResult = DialogResult.Cancel;


        }

        async void ResetNoti(string s)
        {
            DocumentReference docRef = db.Collection("Notification").Document(s);


            Dictionary<string, object> updates = new Dictionary<string, object>
                    {
                        { "notification", new List<object>() }
                    };

            await docRef.UpdateAsync(updates);
        }

        async void ResetDebit(string s)
        {
            DocumentReference docref = db.Collection("ListDebit").Document(s);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            {
                dict.Add("debit", 0);
            }
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.UpdateAsync(dict);

            }
        }

        async void ResetAwaitService(string s)
        {
            DocumentReference docRef = db.Collection("ListAwaitService").Document(s);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> updates = new Dictionary<string, object>();

                foreach (var field in snapshot.ToDictionary())
                {
                    if (field.Value is IList<object>)
                    {
                        updates[field.Key] = FieldValue.Delete;
                    }
                }

                if (updates.Count > 0)
                {
                    await docRef.UpdateAsync(updates);

                }
            }
        }

        async void ResetServiceMoney(string s)
        {
            DocumentReference docref = db.Collection("ServiceMoney").Document(s);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            {
                dict.Add("Money", 0);
            }
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.UpdateAsync(dict);

            }
        }
    }
}
