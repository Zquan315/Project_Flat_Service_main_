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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Flat_Services_Application.tenant
{
    public partial class homechating : Form
    {
        public homechating()
        {
            InitializeComponent();
        }
        FirestoreDb db;
        private delegate void SafeCallDelegate(string text);
        TcpClient tcp_Client;
        NetworkStream ns;
        bool isConnected = false;
        public homechating(string s, string p)
        {
            InitializeComponent();
            tbAccount.Text = s;
            tbroom.Text = p;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void homechating_Load(object sender, EventArgs e)
        {
            this.chatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.chatBtn.ForeColor = Color.White;
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
                            item2.ForeColor = System.Drawing.Color.Gray;
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

        private void chatBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            homechating homechating = new homechating(tbAccount.Text, tbroom.Text);
            homechating.StartPosition = FormStartPosition.CenterScreen;
            homechating.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setting homenavigation = new Setting(tbAccount.Text, tbroom.Text);
            homenavigation.StartPosition = FormStartPosition.CenterScreen;
            homenavigation.Show();
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

        private void lvSearch_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void homechating_FormClosed(object sender, FormClosedEventArgs e)
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
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(tbroom.Text + ": " + tbChat.Text + '\n');
                ns.Write(data, 0, data.Length);
                tbChat.Text = "";

            }
        }

        private void ChangeColorBtn_Click(object sender, EventArgs e)
        {
            System.Drawing.Color def = System.Drawing.Color.FromArgb(((int)(((byte)41))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            System.Drawing.Color[] colors = { def, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DeepPink, System.Drawing.Color.DarkOrange, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.AliceBlue, System.Drawing.Color.Aquamarine, System.Drawing.Color.Cornsilk };
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
    }
}
