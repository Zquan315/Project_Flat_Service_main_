using Flat_Services_Application.tenant;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_Services_Application.lessor
{
    public partial class Chat_Lessor : Form
    {
        FirestoreDb db;
        private delegate void SafeCallDelegate(string text);
        TcpClient tcp_Client;
        NetworkStream ns;
        bool isConnected = false;

        public Chat_Lessor()
        {
            InitializeComponent();
        }
        string sdt;
        public Chat_Lessor(string sdt)
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
            Requests_Lessor requests_Lessor = new Requests_Lessor(sdt);
            requests_Lessor.StartPosition = FormStartPosition.CenterScreen;
            requests_Lessor.Show();
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

        private void Chat_Lessor_Load(object sender, EventArgs e)
        {
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
            get_Data();
            connect();
        }

        private void Chat_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat_Lessor chat_Lessor = new Chat_Lessor(sdt);
            chat_Lessor.StartPosition = FormStartPosition.CenterScreen;
            chat_Lessor.Show();
        }

        void connect()
        {
            try
            {
                if (isConnected == false)
                {
                    tcp_Client = new TcpClient();
                    IPAddress ip = IPAddress.Parse("127.0.0.1");
                    IPEndPoint iPEndPoint = new IPEndPoint(ip, 8080);

                    tcp_Client.Connect(iPEndPoint);
                    ns = tcp_Client.GetStream();
                    isConnected = true;
                    Task.Run(() => ReceiveMessageFromServer());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void get_Data()
        {
            DocumentReference doc = db.Collection("Chat").Document("Chat");
            DocumentSnapshot snap = await doc.GetSnapshotAsync();
            if (snap.Exists)
            {
                Dictionary<string, object> not = snap.ToDictionary();

                foreach (var field in not)
                {
                    if (field.Value is List<object> arrayData)
                    {
                        // Convert List<object> to List<string>
                        List<string> arrayValues = arrayData.ConvertAll(x => x.ToString());

                        // Check if the array has exactly 5 elements
                        for (int i = 0; i < arrayValues.Count; i++)
                        {
                            string[] s = arrayValues[i].Split('-');
                            ListViewItem item1 = new ListViewItem(s[0]);
                            ListViewItem item2 = new ListViewItem(s[1]);
                            item1.Font = new Font(item1.Font.FontFamily, 11, FontStyle.Bold);
                            item1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
                            item2.Font = new Font(item2.Font.FontFamily, 8);
                            item2.ForeColor = Color.Gray;
                            lvMess.Items.Add(item1);
                            lvMess.Items.Add(item2);

                        }

                    }
                }

            }
        }
        private void ReceiveMessageFromServer()
        {
            Task.Run(() =>
            {
                try
                {
                    while (isConnected == true)
                    {


                        try
                        {
                            byte[] data = new byte[4096];
                            int bytesRead = ns.Read(data, 0, data.Length);

                            if (bytesRead > 0)
                            {
                                string message = Encoding.UTF8.GetString(data, 0, bytesRead);
                                AddMessageToListView(message);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error receiving message from server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void AddMessageToListView(string message)
        {
            if (lvMess.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddMessageToListView);
                lvMess.Invoke(d, new object[] { message });

            }
            else
            {
                ListViewItem item = new ListViewItem();
                item.Text = message;
                lvMess.Items.Add(item);
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            tbChat.Text = tbSearch.Text = "";
            lvSearch.Items.Clear();
            int i = 0;
            foreach (ListViewItem item in lvMess.Items)
            {
                if (i % 2 == 0)
                {
                    item.BackColor = Color.White;
                }
                i++;
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (tbChat.Text != "")
            {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes("Lessor: " + tbChat.Text + '\n');
                ns.Write(data, 0, data.Length);
                tbChat.Text = "";

            }
        }

        private void Close_Form(object sender, FormClosedEventArgs e)
        {
            if (isConnected == true)
            {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes("00110001000000010010000000000100\n");
                ns.Write(data, 0, data.Length);
                ns.Close();
                ns = null;
                tcp_Client.Close();
                tcp_Client = null;
                isConnected = false;
            }
        }

        private void ChangeColorBtn_Click(object sender, EventArgs e)
        {
            System.Drawing.Color def = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            System.Drawing.Color[] colors = { def, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DeepPink, System.Drawing.Color.DarkOrange, 
                System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.AliceBlue, 
                System.Drawing.Color.Aquamarine, System.Drawing.Color.Cornsilk };

            Random r = new Random();
            int rand = r.Next(0, colors.Length);
            int i = 0;
            foreach (ListViewItem item in lvMess.Items)
            {
                if (i % 2 == 0)
                {
                    item.ForeColor = colors[rand];
                }
                i++;
            }
        }
        bool check_exits(string s)
        {
            foreach (ListViewItem it in lvSearch.Items)
            {
                if (it.Text == s)
                    return true;
            }
            return false;
        }

        private async void FindBtn_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {

                lvSearch.Items.Clear();
                DocumentReference doc = db.Collection("Chat").Document("Chat");
                DocumentSnapshot snap = await doc.GetSnapshotAsync();
                if (snap.Exists)
                {
                    Dictionary<string, object> roomInfo = snap.ToDictionary();

                    foreach (var field in roomInfo)
                    {
                        if (field.Value is List<object> arrayData)
                        {
                            List<string> arrayValues = arrayData.ConvertAll(x => x.ToString());


                            for (int i = 0; i < arrayValues.Count; i++)
                            {
                                string[] s = arrayValues[i].ToString().Split('-');
                                if (s[0].IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0 && !check_exits(s[0]))
                                {
                                    lvSearch.Items.Add(s[0]);
                                }
                            }
                        }
                    }
                }
                if (lvSearch.Items.Count == 0)
                {
                    lvSearch.Items.Add("Empty");
                }

            }
        }

        private void Chat_Lessor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void MoveSearch(object sender, MouseEventArgs e)
        {
            ListViewItem selectItem = lvSearch.SelectedItems[0];
            string s = selectItem.Text;
            foreach (ListViewItem it in lvMess.Items)
            {
                it.BackColor = System.Drawing.Color.White;
                if (s == it.Text)
                {
                    it.BackColor = System.Drawing.Color.LightGreen;

                }
            }
        }
    }
}
