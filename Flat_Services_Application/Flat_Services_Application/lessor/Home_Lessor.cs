using Flat_Services_Application.Class;
using Flat_Services_Application.lessor;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flat_Services_Application.tenant
{
    public partial class Home_Lessor : Form
    {
        FirestoreDb db;
        public Home_Lessor()
        {
            InitializeComponent();
        }
        string sdt;
        public Home_Lessor(string sdt)
        {
            InitializeComponent();
            this.sdt = sdt;
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
            settings_Lessor.StartPosition = FormStartPosition.CenterScreen;
            settings_Lessor.Show();
        }

        private void Services_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_Lessor services_Lessor = new Services_Lessor(sdt);
            services_Lessor.StartPosition = FormStartPosition.CenterScreen;
            services_Lessor.Show();
        }

        private void Home_Lessor_Load(object sender, EventArgs e)
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
            GetData();

            pieChart1.LegendLocation = LegendLocation.Left;
        }

        Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
        async void GetData()
        {
            SeriesCollection series = new SeriesCollection();
            Query data = db.Collection("SelectRoom");
            QuerySnapshot snap = await data.GetSnapshotAsync();

            int cnt1 = 0, cnt0 = 0;

            foreach (DocumentSnapshot snapshot in snap.Documents) 
            {
                if (snapshot.Exists)
                {
                    room1 dt = snapshot.ConvertTo<room1>();
                    if (dt.Status == 0)
                    {
                        Status_DataGridView.Rows.Add(snapshot.Id, "Empty");
                        cnt0++;
                    }
                    else
                    {
                        Status_DataGridView.Rows.Add(snapshot.Id, "Hired");
                        cnt1++;
                    }
                }
            }

            series.Add(new PieSeries()
            {
                Title = "Empty",
                Values = new ChartValues<int> { cnt0 },
                DataLabels = true,
                LabelPoint = labelPoint,
                //Fill = System.Windows.Media.Brushes.LightGreen,
            });

            series.Add(new PieSeries()
            {
                Title = "Hired",
                Values = new ChartValues<int> { cnt1 },
                DataLabels = true,
                LabelPoint = labelPoint,
                //Fill = System.Windows.Media.Brushes.Red,
                PushOut = 15,
            });

            pieChart1.Series = series;
        }

        private void Home_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Lessor home_Lessor = new Home_Lessor(sdt);
            home_Lessor.StartPosition = FormStartPosition.CenterScreen;
            home_Lessor.Show();
        }
    }
}
