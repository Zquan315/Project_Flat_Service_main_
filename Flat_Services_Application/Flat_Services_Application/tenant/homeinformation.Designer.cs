namespace Flat_Services_Application.tenant
{
    partial class homeinformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(homeinformation));
            this.panelCenterInformation = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvData = new System.Windows.Forms.ListView();
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id_vehical = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbSex = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.lbphone = new System.Windows.Forms.Label();
            this.datetime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbID = new System.Windows.Forms.Label();
            this.lbIDvehical = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbVehical = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.UpgradeBtn = new System.Windows.Forms.Button();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tbroom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.chatBtn = new System.Windows.Forms.Button();
            this.servicesBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.costsBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelCenterInformation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenterInformation
            // 
            this.panelCenterInformation.BackColor = System.Drawing.Color.White;
            this.panelCenterInformation.Controls.Add(this.groupBox1);
            this.panelCenterInformation.Controls.Add(this.panel5);
            this.panelCenterInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterInformation.Location = new System.Drawing.Point(360, 159);
            this.panelCenterInformation.Name = "panelCenterInformation";
            this.panelCenterInformation.Size = new System.Drawing.Size(1398, 855);
            this.panelCenterInformation.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.groupBox1.Controls.Add(this.lvData);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1362, 428);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lvData
            // 
            this.lvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.phone,
            this.name,
            this.id,
            this.sex,
            this.date,
            this.id_vehical});
            this.lvData.FullRowSelect = true;
            this.lvData.GridLines = true;
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(9, 36);
            this.lvData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(1341, 384);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            this.lvData.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // phone
            // 
            this.phone.Text = "Phone number";
            this.phone.Width = 147;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 143;
            // 
            // id
            // 
            this.id.Text = "ID number";
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.id.Width = 162;
            // 
            // sex
            // 
            this.sex.Text = "Sex";
            this.sex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sex.Width = 116;
            // 
            // date
            // 
            this.date.Text = "Date of birth";
            this.date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.date.Width = 140;
            // 
            // id_vehical
            // 
            this.id_vehical.Text = "ID vehical";
            this.id_vehical.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.id_vehical.Width = 127;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel5.Controls.Add(this.lbSex);
            this.panel5.Controls.Add(this.lbname);
            this.panel5.Controls.Add(this.lbphone);
            this.panel5.Controls.Add(this.datetime);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.tbPhone);
            this.panel5.Controls.Add(this.rbFemale);
            this.panel5.Controls.Add(this.rbMale);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.tbName);
            this.panel5.Controls.Add(this.label2);
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(18, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1362, 366);
            this.panel5.TabIndex = 5;
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.ForeColor = System.Drawing.Color.Red;
            this.lbSex.Location = new System.Drawing.Point(76, 198);
            this.lbSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(20, 25);
            this.lbSex.TabIndex = 23;
            this.lbSex.Text = "*";
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.ForeColor = System.Drawing.Color.Red;
            this.lbname.Location = new System.Drawing.Point(106, 158);
            this.lbname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(20, 25);
            this.lbname.TabIndex = 22;
            this.lbname.Text = "*";
            // 
            // lbphone
            // 
            this.lbphone.AutoSize = true;
            this.lbphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbphone.ForeColor = System.Drawing.Color.Red;
            this.lbphone.Location = new System.Drawing.Point(244, 62);
            this.lbphone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbphone.Name = "lbphone";
            this.lbphone.Size = new System.Drawing.Size(20, 25);
            this.lbphone.TabIndex = 15;
            this.lbphone.Text = "*";
            // 
            // datetime
            // 
            this.datetime.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetime.Location = new System.Drawing.Point(8, 291);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(548, 33);
            this.datetime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date of birth";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbID);
            this.panel8.Controls.Add(this.lbIDvehical);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.txbVehical);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.tbID);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(580, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(576, 366);
            this.panel8.TabIndex = 14;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.ForeColor = System.Drawing.Color.Red;
            this.lbID.Location = new System.Drawing.Point(352, 275);
            this.lbID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(20, 25);
            this.lbID.TabIndex = 21;
            this.lbID.Text = "*";
            // 
            // lbIDvehical
            // 
            this.lbIDvehical.AutoSize = true;
            this.lbIDvehical.ForeColor = System.Drawing.Color.Red;
            this.lbIDvehical.Location = new System.Drawing.Point(412, 91);
            this.lbIDvehical.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIDvehical.Name = "lbIDvehical";
            this.lbIDvehical.Size = new System.Drawing.Size(20, 25);
            this.lbIDvehical.TabIndex = 16;
            this.lbIDvehical.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(4, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ex: 66PA-16815";
            // 
            // txbVehical
            // 
            this.txbVehical.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbVehical.Location = new System.Drawing.Point(9, 78);
            this.txbVehical.Multiline = true;
            this.txbVehical.Name = "txbVehical";
            this.txbVehical.Size = new System.Drawing.Size(394, 38);
            this.txbVehical.TabIndex = 19;
            this.txbVehical.TextChanged += new System.EventHandler(this.txbVehical_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "ID number:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 32);
            this.label9.TabIndex = 18;
            this.label9.Text = "ID vehical:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(9, 266);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(334, 38);
            this.tbID.TabIndex = 12;
            this.tbID.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 32);
            this.label7.TabIndex = 11;
            this.label7.Text = "Phone number:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.DeleteBtn);
            this.panel7.Controls.Add(this.AddBtn);
            this.panel7.Controls.Add(this.UpgradeBtn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1156, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(206, 366);
            this.panel7.TabIndex = 13;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DeleteBtn.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Black;
            this.DeleteBtn.Location = new System.Drawing.Point(10, 239);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(176, 64);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AddBtn.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddBtn.Location = new System.Drawing.Point(10, 28);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(176, 69);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // UpgradeBtn
            // 
            this.UpgradeBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.UpgradeBtn.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpgradeBtn.ForeColor = System.Drawing.Color.Black;
            this.UpgradeBtn.Location = new System.Drawing.Point(10, 139);
            this.UpgradeBtn.Name = "UpgradeBtn";
            this.UpgradeBtn.Size = new System.Drawing.Size(176, 69);
            this.UpgradeBtn.TabIndex = 1;
            this.UpgradeBtn.Text = "Update";
            this.UpgradeBtn.UseVisualStyleBackColor = false;
            this.UpgradeBtn.Click += new System.EventHandler(this.UpgradeBtn_Click);
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhone.Location = new System.Drawing.Point(249, 20);
            this.tbPhone.Multiline = true;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(307, 38);
            this.tbPhone.TabIndex = 10;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Century", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(249, 191);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(123, 29);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.sex_change);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Century", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(111, 191);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(97, 29);
            this.rbMale.TabIndex = 5;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.male_check);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sex:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Century Gothic", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(111, 108);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(446, 38);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(360, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1398, 159);
            this.panel2.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1398, 159);
            this.panel4.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tbroom);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label15);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Controls.Add(this.tbAccount);
            this.panel9.Location = new System.Drawing.Point(871, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(509, 150);
            this.panel9.TabIndex = 8;
            // 
            // tbroom
            // 
            this.tbroom.CausesValidation = false;
            this.tbroom.Enabled = false;
            this.tbroom.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbroom.Location = new System.Drawing.Point(194, 45);
            this.tbroom.Name = "tbroom";
            this.tbroom.Size = new System.Drawing.Size(234, 36);
            this.tbroom.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(33, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 33);
            this.label8.TabIndex = 16;
            this.label8.Text = "Room:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(16, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(496, 25);
            this.label15.TabIndex = 15;
            this.label15.Text = "© 2024 - Copyright by Group 5 NT106.O21.ANTT";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(33, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 33);
            this.label16.TabIndex = 13;
            this.label16.Text = "Account";
            // 
            // tbAccount
            // 
            this.tbAccount.CausesValidation = false;
            this.tbAccount.Enabled = false;
            this.tbAccount.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccount.Location = new System.Drawing.Point(194, 8);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(234, 36);
            this.tbAccount.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(370, 70);
            this.label11.TabIndex = 2;
            this.label11.Text = "Information";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 70);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.logoutBtn);
            this.panel1.Controls.Add(this.chatBtn);
            this.panel1.Controls.Add(this.servicesBtn);
            this.panel1.Controls.Add(this.infoBtn);
            this.panel1.Controls.Add(this.costsBtn);
            this.panel1.Controls.Add(this.homeBtn);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 1014);
            this.panel1.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 759);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(360, 120);
            this.button4.TabIndex = 7;
            this.button4.Text = "Setting";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logoutBtn.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.Location = new System.Drawing.Point(0, 894);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(360, 120);
            this.logoutBtn.TabIndex = 6;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // chatBtn
            // 
            this.chatBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatBtn.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBtn.Location = new System.Drawing.Point(0, 639);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(360, 120);
            this.chatBtn.TabIndex = 5;
            this.chatBtn.Text = "Chatting";
            this.chatBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chatBtn.UseVisualStyleBackColor = true;
            this.chatBtn.Click += new System.EventHandler(this.chatBtn_Click);
            // 
            // servicesBtn
            // 
            this.servicesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.servicesBtn.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servicesBtn.Location = new System.Drawing.Point(0, 519);
            this.servicesBtn.Name = "servicesBtn";
            this.servicesBtn.Size = new System.Drawing.Size(360, 120);
            this.servicesBtn.TabIndex = 4;
            this.servicesBtn.Text = "Service";
            this.servicesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.servicesBtn.UseVisualStyleBackColor = true;
            this.servicesBtn.Click += new System.EventHandler(this.servicesBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoBtn.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBtn.Location = new System.Drawing.Point(0, 399);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(360, 120);
            this.infoBtn.TabIndex = 3;
            this.infoBtn.Text = "Information";
            this.infoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // costsBtn
            // 
            this.costsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.costsBtn.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costsBtn.Location = new System.Drawing.Point(0, 279);
            this.costsBtn.Name = "costsBtn";
            this.costsBtn.Size = new System.Drawing.Size(360, 120);
            this.costsBtn.TabIndex = 2;
            this.costsBtn.Text = "Costing Fee";
            this.costsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.costsBtn.UseVisualStyleBackColor = true;
            this.costsBtn.Click += new System.EventHandler(this.costsBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.White;
            this.homeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeBtn.Font = new System.Drawing.Font("Century", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.Location = new System.Drawing.Point(0, 159);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(360, 120);
            this.homeBtn.TabIndex = 1;
            this.homeBtn.Text = "Home";
            this.homeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 159);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::Flat_Services_Application.Properties.Resources.Icon;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(360, 159);
            this.panel6.TabIndex = 1;
            this.panel6.Click += new System.EventHandler(this.panel6_Click);
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // homeinformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 1014);
            this.Controls.Add(this.panelCenterInformation);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "homeinformation";
            this.Text = "Flat Service";
            this.Load += new System.EventHandler(this.homeinformation_Load);
            this.panelCenterInformation.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCenterInformation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button chatBtn;
        private System.Windows.Forms.Button servicesBtn;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Button costsBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker datetime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbVehical;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpgradeBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox tbroom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader phone;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader sex;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader id_vehical;
        private System.Windows.Forms.Label lbphone;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbIDvehical;
        private System.Windows.Forms.Label lbSex;
    }
}