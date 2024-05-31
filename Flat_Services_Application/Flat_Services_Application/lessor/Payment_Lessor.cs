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
using static Google.Rpc.Context.AttributeContext.Types;

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

        private async void Charge_btn_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (tbElec.Text == "" || !int.TryParse(tbElec.Text.Trim(), out num) || Convert.ToInt32(tbElec.Text) < 1) 
            {
                lbElec.Text = "*";
                lbElec.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbElec.Text = "";
            }

            if (tbWater.Text == "" || !int.TryParse(tbWater.Text.Trim(), out num) || Convert.ToInt32(tbWater.Text) < 1)
            {
                lbwater.Text = "*";
                lbwater.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbwater.Text = "";
            }

            string r = lvData.SelectedItems[0].Text;
            ListViewItem selectedItem = lvData.SelectedItems[0];
            int money_debit = 0;
            int money_service = 0;
            int money_total = 0;

            // Truy xuat debit
            DocumentReference doc = db.Collection("ListDebit").Document(r);
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            if (snap.Exists)
            {
                Debit t = snap.ConvertTo<Debit>();
                money_debit = t.debit;

            }

            // Truy xuat money service
            DocumentReference doc2 = db.Collection("ServiceMoney").Document(r);
            DocumentSnapshot snap2 = await doc2.GetSnapshotAsync();
            if (snap2.Exists)
            {
                Money_Service t = snap2.ConvertTo<Money_Service>();
                money_service = t.Money;

            }

            // Tinh total
            //DocumentReference doc3 = db.Collection("Bill").Document(r);
            //DocumentSnapshot snap3 = await doc.GetSnapshotAsync();
            //if (snap3.Exists)
            //{
            //    Bill t = snap3.ConvertTo<Bill>();
            //    int room_price = Convert.ToInt32(t.Room_price);
            //    int clean = Convert.ToInt32(t.clean);
            //    int elec = Convert.ToInt32(t.elec);
            //    int secu = Convert.ToInt32(t.secu);
            //    int water = Convert.ToInt32(t.water);
            //    money_total = room_price + (elec * Convert.ToInt32(tbElec.Text)) + (water * Convert.ToInt32(tbWater.Text)) + clean + secu + money_service + money_debit;
            //}

            int room_price = Convert.ToInt32(selectedItem.SubItems[1].Text);
            int elec = Convert.ToInt32(selectedItem.SubItems[2].Text);
            int water = Convert.ToInt32(selectedItem.SubItems[4].Text);
            int clean = Convert.ToInt32(selectedItem.SubItems[6].Text);
            int secu = Convert.ToInt32(selectedItem.SubItems[7].Text);
   
            money_total = room_price + (elec * Convert.ToInt32(tbElec.Text)) + (water * Convert.ToInt32(tbWater.Text)) + clean + secu + money_service + money_debit;
            Charge(r, tbElec.Text, tbWater.Text, money_debit, money_service, money_total);
            lbCharge.Text = "Charge successfully";
            lbCharge.ForeColor = Color.Green;
            await Task.Delay(3000);
            tbElec.Text = tbWater.Text = lbCharge.Text = "";
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
            lvDebit.Items.Clear();
            if(cbbSearch.Text == "" || cbbSearch.Text == "All")
            {
                cbbSearch.Text = "All";
                load_all_data();
                load_all_data_debit();
            }
            else
            {
                load_a_data();
                load_a_data_debit();
            }

                
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSearch.Text == "")
                cbbSearch.Text = "All";
        }

        private void Payment_Lessor_Load(object sender, EventArgs e)
        {
            cbbSearch.Text = "All";
            tbElec.Enabled = tbWater.Enabled = false;
            lbElec.Text = lbwater.Text = "";
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
            load_all_data_debit();
        }

        async void load_all_data_debit()
        {
            Query doc = db.Collection("ListDebit");
            QuerySnapshot snap = await doc.GetSnapshotAsync();

            foreach (DocumentSnapshot sn in snap)
            {

                if (sn.Exists)
                {
                    Debit t = sn.ConvertTo<Debit>();
                    string id = sn.Id.ToString();
                    ListViewItem data = new ListViewItem(id);
                    data.SubItems.Add(t.debit.ToString());                   
                    lvDebit.Items.Add(data);
                }
            }
        }
        async void load_a_data_debit()
        {
            Query doc = db.Collection("ListDebit");
            QuerySnapshot snap = await doc.GetSnapshotAsync();

            foreach (DocumentSnapshot sn in snap)
            {

                if (sn.Exists)
                {
                    Debit t = sn.ConvertTo<Debit>();
                    string id = sn.Id.ToString();
                    if(id == cbbSearch.Text)
                    {
                        ListViewItem data = new ListViewItem(id);
                        data.SubItems.Add(t.debit.ToString());
                        lvDebit.Items.Add(data);
                        return;
                    }
                    
                }
            }
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

        private void lvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvData.SelectedItems.Count != 1)
            {
                tbElec.Enabled = tbWater.Enabled = false;
                lbElec.Text = lbwater.Text = "";
                Charge_btn.Enabled = false;
            }
            else
            {
                tbElec.Enabled = tbWater.Enabled = true;
                lbElec.Text = lbwater.Text = "*";
                lbElec.ForeColor = lbwater.ForeColor = Color.Red;
                Charge_btn.Enabled = true;
            }
            
        }

        private void tbElec_TextChanged(object sender, EventArgs e)
        {
            if (tbElec.Enabled == true)
                if (tbElec.Text == "")
                {
                    lbElec.Text = "*";
                    lbElec.ForeColor = Color.Red;
                }
                else
                {
                    lbElec.Text = "";
                }
        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }

        private void tbWater_TextChanged(object sender, EventArgs e)
        {
            if (tbWater.Enabled == true)
                if (tbWater.Text == "")
                {
                    lbwater.Text = "*";
                    lbwater.ForeColor = Color.Red;
                }
                else
                {
                    lbwater.Text = "";
                }
        }

        async void Charge(string s, string e, string w, int m, int sv, int tt)
        {
            DocumentReference docref = db.Collection("Bill").Document(s);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            {
                dict.Add("Room_price", "4500000");
                dict.Add("amount_Elec", Convert.ToInt32(e));
                dict.Add("amount_water", Convert.ToInt32(w));
                dict.Add("clean", "30000");
                dict.Add("debit", m.ToString());
                dict.Add("elec", "4000");
                dict.Add("secu", "30000");
                dict.Add("service", sv.ToString());
                dict.Add("total", tt.ToString());
                dict.Add("water", "15000");
            }
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.UpdateAsync(dict);

            }
        }

        private async void Reset_BillBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvData.Items)
            {
                DocumentReference docref = db.Collection("Bill").Document(item.Text);
                Dictionary<string, object> dict = new Dictionary<string, object>();
                {
                    dict.Add("Room_price", "4500000");
                    dict.Add("amount_Elec", 0);
                    dict.Add("amount_water", 0);
                    dict.Add("clean", "30000");
                    dict.Add("debit", "");
                    dict.Add("elec", "4000");
                    dict.Add("secu", "30000");
                    dict.Add("service","");
                    dict.Add("total", "");
                    dict.Add("water", "15000");
                    ResetDebit(item.Text);
                    ResetService(item.Text);
                }
                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    await docref.UpdateAsync(dict);

                }

                lbReset.Text = "Reset successfully";
                lbReset.ForeColor = Color.Green;
                await Task.Delay(3000);
                lbReset.Text = "";

                
            }
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

        async void ResetService(string s)
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

        private void tbMoney_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (tbMoney.Text == "" || !int.TryParse(tbMoney.Text.Trim(), out num) || Convert.ToInt32(tbMoney.Text) < 1000)
            {
                lbMoney.Text = "*";
                lbMoney.ForeColor = Color.Red;
            }
            else
            {
                lbMoney.Text = "";
            }
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (tbMoney.Text == "" || !int.TryParse(tbMoney.Text.Trim(), out num) || Convert.ToInt32(tbMoney.Text) < 1000)
            {
                lbMoney.Text = "*";
                lbMoney.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbMoney.Text = "";
            }

            if (cbbSearch.Text != "All")
            {
                DocumentReference docref = db.Collection("ListDebit").Document(cbbSearch.Text);
                Dictionary<string, object> dict = new Dictionary<string, object>();
                {
                    dict.Add("debit", Convert.ToInt32(tbMoney.Text));
                    
                }
                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    await docref.UpdateAsync(dict);

                }

                lbAdd.Text = "Add debit money for room " + cbbSearch.Text + " successfully";
                lbAdd.ForeColor = Color.Green;
                await Task.Delay(3000);
                lbAdd.Text = tbMoney.Text = "";
            }
        }
    }
}
