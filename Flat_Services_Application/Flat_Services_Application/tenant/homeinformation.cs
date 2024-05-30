
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Flat_Services_Application.Class;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Flat_Services_Application.tenant
{
    public partial class homeinformation : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "KR5gPtgHXbYV0t9jMOeKDN3UvRaXulbgAD4aijeN",
            BasePath = "https://account-ac0cc-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        FirestoreDb db;
        public homeinformation()
        {
            InitializeComponent();
        }
        public homeinformation(string s, string p)
        {
            InitializeComponent();
            tbAccount.Text = s;
            tbroom.Text = p;
        }
       

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void homeinformation_Load(object sender, EventArgs e)
        {
            this.infoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.infoBtn.ForeColor = Color.White;

            //ket noi firebase
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
            DocumentReference doc = db.Collection("RoomInfo").Document(tbroom.Text);
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
    


private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homenavigation homenavigation = new homenavigation(tbAccount.Text, tbroom.Text );
            homenavigation.StartPosition = FormStartPosition.CenterScreen;
            homenavigation.Show();
        }

        private void costsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homecostsing homecostsing = new homecostsing(tbAccount.Text, tbroom.Text);
            homecostsing.StartPosition = FormStartPosition.CenterScreen;
            homecostsing.Show();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeinformation homeinformation = new homeinformation(tbAccount.Text, tbroom.Text);
            homeinformation.StartPosition = FormStartPosition.CenterScreen;
            homeinformation.Show();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homeservices homeservices = new homeservices(tbAccount.Text, tbroom.Text); 
            homeservices.StartPosition = FormStartPosition.CenterScreen;
            homeservices.Show();
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homechating homechating = new homechating(tbAccount.Text, tbroom.Text);    
            homechating.StartPosition = FormStartPosition.CenterScreen;
            homechating.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting differencesfee = new Setting(tbAccount.Text, tbroom.Text);
            differencesfee.StartPosition = FormStartPosition.CenterScreen;
            differencesfee.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbVehical_TextChanged(object sender, EventArgs e)
        {
            if (txbVehical.Text == "")
            {
                lbIDvehical.Text = "*";
                lbIDvehical.ForeColor = Color.Red;
            }
            else
                lbIDvehical.Text = "";
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if(tbPhone.Text == "")
            {
                lbphone.Text = "*";
                lbphone.ForeColor = Color.Red;
            }
            else
            {
                lbphone.Text = "";
                if(exits_phone(tbPhone.Text))
                {
                    foreach (ListViewItem item in lvData.Items)
                    {
                        if (item.Text == tbPhone.Text)
                        {
                            DateTime dateTime = DateTime.ParseExact(item.SubItems[4].Text, "MM/dd/yyyy", null);

                            // Tạo chuỗi định dạng mới "dd-month-yy"
                            
                            tbName.Text = item.SubItems[1].Text;
                            tbID.Text = item.SubItems[2].Text;
                            datetime.Value = dateTime;
                            tbID.Enabled =  tbPhone.Enabled = datetime.Enabled = false;
                            break;
                        }
                    }
                }
                else
                {
                    tbID.Text = tbName.Text = "";
                    tbID.Enabled= tbPhone.Enabled = datetime.Enabled = true;
                }
            }
                
        }
        public bool IsNumberPhone(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ' || (a[i] < '0' || a[i] > '9'))
                    return false;
            }
            if (a.Length < 10 || a.Length > 11)
                return false;
            return true;
        }
        public bool isIDvehical(string s)
        {
            int num = 0;

            // Kiểm tra độ dài của chuỗi phải là 9 hoặc 10 (bao gồm cả dấu '-')
            if (s.Length != 9 && s.Length != 10) return false;

            // Kiểm tra 2 ký tự đầu tiên phải là số
            char a = s[0], b = s[1];
            if (!int.TryParse(a.ToString(), out num) || !int.TryParse(b.ToString(), out num)) return false;

            // Kiểm tra ký tự thứ 3 phải là chữ cái
            char c = s[2];
            if (!char.IsLetter(c)) return false;

            // Kiểm tra ký tự thứ 4 phải là số hoac chu cai
            char d = s[3];
            if (!int.TryParse(d.ToString(), out num) && (!char.IsLetter(c))) return false;

            // Kiểm tra ký tự thứ 5 phải là dấu '-'
            if (s[4] != '-') return false;

            // Kiểm tra các ký tự còn lại phải là số
            for (int i = 5; i < s.Length; i++)
            {
                if (!int.TryParse(s[i].ToString(), out num)) return false;
            }

            // Kiểm tra độ dài phần số cuối cùng phải là 4 hoặc 5
            string lastPart = s.Substring(5);
            if (lastPart.Length != 4 && lastPart.Length != 5) return false;

            return true;
        }
        public bool check2so(char c, char d)
        {
            int num = 0;
            if (int.TryParse(c.ToString(), out num) || int.TryParse(d.ToString(), out num) || (c >= 'A' && c <= 'Z') || (d >= 'A' && d <= 'Z'))
                return true;
            return false;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(!IsNumberPhone(tbPhone.Text) || tbPhone.Text == "")
            {
                lbphone.Text = "*";
                lbphone.ForeColor = Color.Red;
                return;
            }
            else
                lbphone.Text = "";
            if (tbName.Text == "")
            {
                lbname.Text = "*";
                lbname.ForeColor = Color.Red;
                return;
            }
            else
                lbname.Text = "";
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                lbSex.Text = "*";
                lbSex.ForeColor = Color.Red;
                return;
            }
            else
                lbname.Text = "";
            if (!isIDvehical(txbVehical.Text))
            {
                lbIDvehical.Text = "*";
                lbIDvehical.ForeColor = Color.Red;
                return;
            }
            else
                lbIDvehical.Text = "";
            if (tbID.Text.Length != 12)
            {
                lbID.Text = "*";
                lbID.ForeColor = Color.Red;
                return;
            }
            else
                lbID.Text = "";
            // neu sdt do da o trong phong thi khong duoc them nua
            if(exits_phone(tbPhone.Text))
            {
                lbphone.Text = "This phone is exists";
                lbphone.ForeColor = Color.Red;
                return;
            }

            // them thong tin ban vao phong
            add_Data();
            
        }

        async void add_Data()
        {

            DocumentReference DOC = db.Collection("RoomInfo").Document(tbroom.Text);
            Dictionary<string, object> maindt = new Dictionary<string, object>();
            DateTime selectedDate = datetime.Value;
            string formattedDate = selectedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            
            ArrayList arr = new ArrayList();
            arr.Add(tbName.Text);
            arr.Add(tbID.Text);
            if(rbFemale.Checked) 
                arr.Add("Female");
            if (rbMale.Checked)
                arr.Add("Male");
            arr.Add(formattedDate);
            arr.Add(txbVehical.Text.ToUpper());
            maindt.Add(tbPhone.Text, arr);
            await DOC.UpdateAsync(maindt);
            lbphone.Text = "Add account successfully";
            lbphone.ForeColor = Color.Green;
            await Task.Delay(3000);
            reset();
        }

        void reset()
        {
            tbPhone.Text = tbName.Text = txbVehical.Text = tbID.Text = "";
            rbFemale.Checked = rbMale.Checked = false;
        }
        bool exits_phone(string s)
        {
            foreach (ListViewItem item in lvData.Items)
            {
                if (item.Text == s)
                    return true;
            }
            return false;
        }
        private async void UpgradeBtn_Click(object sender, EventArgs e)
        {
            if (!IsNumberPhone(tbPhone.Text) || tbPhone.Text == "")
            {
                lbphone.Text = "*";
                lbphone.ForeColor = Color.Red;
                return;
            }
            else
                lbphone.Text = "";
            if (tbName.Text == "")
            {
                lbname.Text = "*";
                lbname.ForeColor = Color.Red;
                return;
            }
            else
                lbname.Text = "";
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                lbSex.Text = "*";
                lbSex.ForeColor = Color.Red;
                return;
            }
            else
                lbname.Text = "";
            if (!isIDvehical(txbVehical.Text))
            {
                lbIDvehical.Text = "*";
                lbIDvehical.ForeColor = Color.Red;
                return;
            }
            else
                lbIDvehical.Text = "";
            if (tbID.Text.Length != 12)
            {
                lbID.Text = "*";
                lbID.ForeColor = Color.Red;
                return;
            }
            else
                lbID.Text = "";
            if (!exits_phone(tbPhone.Text))
            {
                lbphone.Text = "This phone isn't exists";
                lbphone.ForeColor = Color.Red;
                return;
            }
            update_data();
            //update user
            FirebaseResponse responds = await client.GetAsync("Account Tenant/" + tbPhone.Text);
            if (responds.Body != "null")
            {
                Data dt = responds.ResultAs<Data>();
                var data = new Data()
                {
                    name = tbName.Text,
                    email = dt.email,
                    pass = dt.pass,
                    phone = dt.phone,
                    ID = dt.ID,
                    date = dt.date,
                    objects = dt.objects,
                    status = dt.status,
                    remember = dt.remember,
                    room = dt.room,
                };

                FirebaseResponse ud = await client.UpdateAsync("Account Tenant/" + tbPhone.Text, data);
                Data result = ud.ResultAs<Data>();
            }

            //
            lbphone.Text = "Update account successfully";
            lbphone.ForeColor = Color.Green;
            await Task.Delay(3500);
            reset();
        }
        async void update_data()
        {

            DocumentReference DOC = db.Collection("RoomInfo").Document(tbroom.Text);
            Dictionary<string, object> maindt = new Dictionary<string, object>();
            DateTime selectedDate = datetime.Value;
            string formattedDate = selectedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            ArrayList arr = new ArrayList();
            arr.Add(tbName.Text);
            arr.Add(tbID.Text);
            if (rbFemale.Checked)
                arr.Add("Female");
            if (rbMale.Checked)
                arr.Add("Male");
            arr.Add(formattedDate);
            arr.Add(txbVehical.Text.ToUpper());
            maindt.Add(tbPhone.Text, arr);
            await DOC.UpdateAsync(maindt);

            


            //
            
        }

        
        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(lvData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one object", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            while(lvData.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvData.SelectedItems[0];
                string phone_num = selectedItem.SubItems[0].Text;
                FirebaseResponse responds = await client.GetAsync("Account Tenant/" + phone_num);
                if (responds.Body == "null")
                {
                    DocumentReference docRef = db.Collection("RoomInfo").Document(tbroom.Text);


                    Dictionary<string, object> updates = new Dictionary<string, object>
                    {
                        { phone_num, FieldValue.Delete }
                    };

                    await docRef.UpdateAsync(updates);
                    lvData.Items.RemoveAt(lvData.SelectedItems[0].Index);
                }
                else
                    lvData.Items.RemoveAt(lvData.SelectedItems[0].Index);
            }    
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                lbname.Text = "*";
                lbname.ForeColor = Color.Red;
            }
            else
                lbname.Text = "";
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            if (tbID.Text == "")
            {
                lbID.Text = "*";
                lbID.ForeColor = Color.Red;
            }
            else
                lbID.Text = "";
        }

        private void sex_change(object sender, EventArgs e)
        {
            lbSex.Text = "";

        }

        private void male_check(object sender, EventArgs e)
        {
            lbSex.Text = "";
        }
    }
}
