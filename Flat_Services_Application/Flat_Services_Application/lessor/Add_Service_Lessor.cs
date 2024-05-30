using Flat_Services_Application.Class;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_Services_Application.lessor
{
    public partial class Add_Service_Lessor : Form
    {
        FirestoreDb db;
        public Add_Service_Lessor()
        {
            InitializeComponent();
        }
        string sdt;
        public Add_Service_Lessor(string sdt)
        {
            InitializeComponent();
            this.sdt = sdt;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_Lessor services_Lessor = new Services_Lessor();
            services_Lessor.StartPosition = FormStartPosition.CenterScreen;
            services_Lessor.Show();
        }

        private void Add_Service_Lessor_Load(object sender, EventArgs e)
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void tbIDService_TextChanged(object sender, EventArgs e)
        {
            if (tbIDService.Text == "")
            {
                lbID.Text = "*";
                lbID.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbID.Text = "";

                Query dc = db.Collection("ListServiceForRent");
                QuerySnapshot snp = await dc.GetSnapshotAsync();

                foreach (DocumentSnapshot sn in snp)
                {
                    ListServiceForRent t = sn.ConvertTo<ListServiceForRent>();
                    if (sn.Exists)
                    {
                        string idd = sn.Id.ToString();
                        if (idd == tbIDService.Text.ToUpper())
                        {
                            tbNote.Text = t.Note;
                            tbName.Text = t.Name;
                            tbPrice.Text = t.Price.ToString();
                            break;
                        }
                        else
                        {
                            tbNote.Text = "";
                            tbName.Text = "";
                            tbPrice.Text = "";
                        }

                    }
                }
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                lbName.Text = "*";
                lbName.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbName.Text = "";
            }
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbPrice.Text == "")
            {
                lbPrice.Text = "*";
                lbPrice.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbPrice.Text = "";
            }
        }

        bool check_Space(string str)
        {
            string pattern = "^[a-zA-Z0-9]+$";
            return Regex.IsMatch(str, pattern);
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (tbIDService.Text == "" || check_Space(tbIDService.Text) == false)
            {
                lbID.Text = "Invalid";
                lbID.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lbID.Text = "";
            }

            if (tbName.Text == "" || check_Space(tbName.Text) == false)
            {
                lbName.Text = "Invalid";
                lbName.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lbName.Text = "";
            }

            int num = 0;
            if (!int.TryParse(tbPrice.Text.Trim(), out num) || Convert.ToInt32(tbPrice.Text.Trim()) < 1000)
            {
                lbPrice.Text = "Invalid";
                lbPrice.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lbPrice.Text = "";
            }

            // them dich vu
            AddService(tbIDService.Text, tbName.Text, tbNote.Text, tbPrice.Text);

            lbID.Text = "Add service successfully";
            lbID.ForeColor = System.Drawing.Color.Green;
            await Task.Delay(3000);

            // reset
            reset();
        }

        void reset()
        {
            tbIDService.Text = tbName.Text = tbPrice.Text = tbNote.Text = "";
        }

        async void AddService(string s, string name, string note, string price)
        {
            var docData = new
            {
                Name = name,
                Note = note,
                Price = Convert.ToInt32(price),
            };

            // Thêm document vào collection
            DocumentReference docRef = db.Collection("ListServiceForRent").Document(s.ToUpper());
            await docRef.SetAsync(docData);
        }
    }
}
