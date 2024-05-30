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
    public partial class Add_Service_Lessor : Form
    {
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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
