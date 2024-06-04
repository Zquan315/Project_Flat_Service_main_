using FireSharp.Response;
using Flat_Services_Application.Class;
using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Flat_Services_Application.tenant
{
    public partial class homeservices : Form
    {
        FirestoreDb db;
        public homeservices()
        {
            InitializeComponent();
        }
        public homeservices(string s, string p)
        {
            InitializeComponent();
            tbAccount.Text = s;
            tbroom.Text = p;
        }
        private void homeservices_Load(object sender, EventArgs e)
        {
            this.servicesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.servicesBtn.ForeColor = Color.White;

            

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
            // load listview2
            load_data2();

            // load listview 1
            load_data1();
        }
        async void load_data1()
        {
            DocumentReference d = db.Collection("ListAwaitService").Document(tbroom.Text);
            DocumentSnapshot snapsss = await d.GetSnapshotAsync();
            if (snapsss.Exists)
            {
                Dictionary<string, object> awaitService = snapsss.ToDictionary();

                foreach (var field in awaitService)
                {
                    if (field.Value is List<object> arrayData)
                    {
                        // Convert List<object> to List<string>
                        List<string> arrayValues = arrayData.ConvertAll(x => x.ToString());

                        // Check if the array has exactly 5 elements
                        ListViewItem data = new ListViewItem(field.Key);
                        for (int i=0; i<arrayValues.Count; i++)
                        {
                           
                            data.SubItems.Add(arrayValues[i]); 
                            
                            
                        }
                        listView1.Items.Add(data);
                    }
                }
            }
        }
        async void load_data2()
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
                    listView2.Items.Add(data);
                    

                }
            }
        }
        private void homeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homenavigation homenavigation = new homenavigation(tbAccount.Text, tbroom.Text);
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

        private void button6_Click(object sender, EventArgs e)
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

        private void chatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homechating homechating = new homechating(tbAccount.Text, tbroom.Text);
            homechating.StartPosition = FormStartPosition.CenterScreen;
            homechating.Show();
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (tbTime.Text == "")
            {
                lbTime.Text = "*";
                lbTime.ForeColor = Color.Red;
            }
            else
                lbTime.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void enrollBtn_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (tbID.Text == "" || !exits_service(tbID.Text.ToUpper()))
            {

                lbID.Text = "Service isn't exists";
                lbID.ForeColor = Color.Red;
                return;
            }
            else
                lbID.Text = "";
            if (exits_enroll(tbID.Text.ToUpper()))
            {

                lbID.Text = "Service is enrolled";
                lbID.ForeColor = Color.Red;
                return;
            }
            else
                lbID.Text = "";
            if (tbTime.Text == "" || !int.TryParse(tbTime.Text.Trim(), out num) || Convert.ToInt32(tbTime.Text) > 24 || Convert.ToInt32(tbTime.Text) <= 0)
            {
                
                lbTime.Text = "invalid";
                lbTime.ForeColor = Color.Red;
                return ;
            }
            else
                lbTime.Text = "";

            if (tbTimestart.Text == "" || !IsValidTimeFormat(tbTimestart.Text))
            {
                lb4.Text = "*";
                lb4.ForeColor = Color.Red;
                return;
            }
            else
                lb4.Text = "";
            // dang ki service
            add_data_listAwaitService();
            lbID.Text = "Enroll successfully";
            lbID.ForeColor = Color.Green;
            await Task.Delay(3000);
            reset();
            //
        }

        async void add_data_listAwaitService()
        {
            DocumentReference DOC = db.Collection("ListAwaitService").Document(tbroom.Text);
            DocumentSnapshot snapshot = await DOC.GetSnapshotAsync();
            Dictionary<string, object> maindt = new Dictionary<string, object>();
            
            DateTime selectedDate = datetime.Value;
            string formattedDate = selectedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            ArrayList arr = new ArrayList();
            arr.Add(nameService(tbID.Text.ToUpper()));// them ten 
            arr.Add(formattedDate);
            arr.Add(tbTime.Text);
            arr.Add("wait");
            arr.Add(tbTimestart.Text);
            maindt.Add(tbID.Text.ToUpper(), arr);
            if(snapshot != null) 
                await DOC.UpdateAsync(maindt);
            else
                await DOC.SetAsync(maindt);
        }
        void reset()
        {
            tbID.Text = tbTime.Text = "";
        }
        string nameService(string s)
        {
            string a = "";
            foreach (ListViewItem item in listView2.Items)
            {
                if(item.Text == s)
                {
                    a = item.SubItems[1].Text;
                    break;
                }
            }
            return a;

        }
        bool exits_service(string s)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.Text == s)
                    return true;
            }
            return false;
        }

        bool exits_enroll(string s)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == s && item.SubItems[4].Text == "wait")
                    return true;
            }
            return false;
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(tbID.Text == "")
            {
                lbID.Text = "*";
                lbID.ForeColor = Color.Red;
            }
            else
            {
                lbID.Text = "";
                if(exits_enroll(tbID.Text.ToUpper()))
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Text == tbID.Text.ToUpper() )
                        {
                            DateTime dateTime = DateTime.ParseExact(item.SubItems[2].Text, "MM/dd/yyyy", null);
                            datetime.Value = dateTime;
                            tbTime.Text = item.SubItems[3].Text;
                            tbTimestart.Text = item.SubItems[5].Text;
                            return;
                        }
                            
                    }
                }
            }    
               
        }

       
        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (tbID.Text == "" || !exits_enroll(tbID.Text.ToUpper()))
            {
                lbID.Text = "This serrvice haven't been enrolled";
                lbID.ForeColor = Color.Red;
                return;
            }
            else
                lbID.Text = "";
            int num = 0;
            if (tbTime.Text == "" || !int.TryParse(tbTime.Text.Trim(), out num) || Convert.ToInt32(tbTime.Text) > 24 || Convert.ToInt32(tbTime.Text) <= 0)
            {

                lbTime.Text = "invalid";
                lbTime.ForeColor = Color.Red;
                return;
            }
            else
                lbTime.Text = "";
            if (tbTimestart.Text == "" || !IsValidTimeFormat(tbTimestart.Text))
            {
                lb4.Text = "*";
                lb4.ForeColor = Color.Red;
                return;
            }
            else
                lb4.Text = "";
            // cap nhat service
            update_enroll();
            lbID.Text = "Update successfully";
            lbID.ForeColor = Color.Green;
            await Task.Delay(3000);
            reset();
        }

        async void update_enroll()
        {
            DocumentReference DOC = db.Collection("ListAwaitService").Document(tbroom.Text);
            DocumentSnapshot snapshot = await DOC.GetSnapshotAsync();
            Dictionary<string, object> maindt = new Dictionary<string, object>();

            DateTime selectedDate = datetime.Value;
            string formattedDate = selectedDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            ArrayList arr = new ArrayList();
            arr.Add(nameService(tbID.Text.ToUpper()));// them ten 
            arr.Add(formattedDate);
            arr.Add(tbTime.Text);          
            arr.Add("wait");
            arr.Add(tbTimestart.Text);
            maindt.Add(tbID.Text.ToUpper(), arr);
            if (snapshot != null)
                await DOC.UpdateAsync(maindt);
            else
                await DOC.SetAsync(maindt);
        }
        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one object", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            while (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string id = selectedItem.SubItems[0].Text;
                DocumentReference docRef = db.Collection("ListAwaitService").Document(tbroom.Text);
                Dictionary<string, object> updates = new Dictionary<string, object>
                    {
                        { id, FieldValue.Delete }
                    };

                await docRef.UpdateAsync(updates);
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        bool IsValidTimeFormat(string time)
        {
            string pattern = @"^(0[0-9]|1[0-9]|2[0-3]|24 )h([0-5][0-9])?$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(time);
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (tbTimestart.Text == "" || !IsValidTimeFormat(tbTimestart.Text))
            {
                lb4.Text = "*";
                lb4.ForeColor = Color.Red;
            }
            else
                lb4.Text = "";
        }

        private void tbroom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
