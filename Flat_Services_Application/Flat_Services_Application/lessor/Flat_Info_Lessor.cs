using Bunifu.UI.WinForms;
using FireSharp.Config;
using FireSharp.Interfaces;
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
    }
}
