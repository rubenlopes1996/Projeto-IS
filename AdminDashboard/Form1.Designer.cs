namespace AdminDashboard
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.endTimeSpecificPark = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.endDateSpecificPark = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.parkSpecificParkData = new System.Windows.Forms.ComboBox();
            this.spotsSpecificParkData = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.startTimeParks = new System.Windows.Forms.DateTimePicker();
            this.startDateSpecificPark = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBoxListBelongingPark = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxSpotsSpecificPark = new System.Windows.Forms.ComboBox();
            this.buttonListBelongingPark = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.datePickerFreeParkingSpots = new System.Windows.Forms.DateTimePicker();
            this.timePickerFreeParkingSpots = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxFreeParkingSpot = new System.Windows.Forms.RichTextBox();
            this.buttonFreeParkingSpots = new System.Windows.Forms.Button();
            this.comboBoxFreeParks = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Dashboard";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1153, 618);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1145, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All Parks Available";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1143, 536);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.dateTimePicker3);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1145, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "All Parking Spots in a Specific Park for a Given moment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Time: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 160);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(190, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.TabStop = false;
            this.dateTimePicker1.Value = new System.DateTime(2018, 12, 17, 17, 18, 34, 0);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.Location = new System.Drawing.Point(35, 186);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1066, 378);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Data: ";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dateTimePicker3.Location = new System.Drawing.Point(80, 127);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker3.Size = new System.Drawing.Size(190, 20);
            this.dateTimePicker3.TabIndex = 4;
            this.dateTimePicker3.Value = new System.DateTime(2018, 12, 13, 9, 56, 0, 0);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(80, 81);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(190, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(536, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Status of All Parking Spots in a Specific Park For a Given Moment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Park: ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.endTimeSpecificPark);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.endDateSpecificPark);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.parkSpecificParkData);
            this.tabPage3.Controls.Add(this.spotsSpecificParkData);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.startTimeParks);
            this.tabPage3.Controls.Add(this.startDateSpecificPark);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1145, 592);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "List of Parking Spots in a Specific Park For a Given Moment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // endTimeSpecificPark
            // 
            this.endTimeSpecificPark.CustomFormat = "HH:mm:ss tt";
            this.endTimeSpecificPark.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimeSpecificPark.Location = new System.Drawing.Point(414, 153);
            this.endTimeSpecificPark.Name = "endTimeSpecificPark";
            this.endTimeSpecificPark.ShowUpDown = true;
            this.endTimeSpecificPark.Size = new System.Drawing.Size(200, 20);
            this.endTimeSpecificPark.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(335, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "End Time:";
            // 
            // endDateSpecificPark
            // 
            this.endDateSpecificPark.Location = new System.Drawing.Point(109, 154);
            this.endDateSpecificPark.Name = "endDateSpecificPark";
            this.endDateSpecificPark.Size = new System.Drawing.Size(200, 20);
            this.endDateSpecificPark.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "End Date: ";
            // 
            // parkSpecificParkData
            // 
            this.parkSpecificParkData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parkSpecificParkData.FormattingEnabled = true;
            this.parkSpecificParkData.Location = new System.Drawing.Point(109, 83);
            this.parkSpecificParkData.Name = "parkSpecificParkData";
            this.parkSpecificParkData.Size = new System.Drawing.Size(200, 21);
            this.parkSpecificParkData.TabIndex = 9;
            // 
            // spotsSpecificParkData
            // 
            this.spotsSpecificParkData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spotsSpecificParkData.BackColor = System.Drawing.SystemColors.Control;
            this.spotsSpecificParkData.Location = new System.Drawing.Point(33, 185);
            this.spotsSpecificParkData.Name = "spotsSpecificParkData";
            this.spotsSpecificParkData.Size = new System.Drawing.Size(1075, 379);
            this.spotsSpecificParkData.TabIndex = 8;
            this.spotsSpecificParkData.Text = "";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1033, 156);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // startTimeParks
            // 
            this.startTimeParks.CustomFormat = "HH:mm:ss tt";
            this.startTimeParks.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimeParks.Location = new System.Drawing.Point(414, 123);
            this.startTimeParks.Name = "startTimeParks";
            this.startTimeParks.ShowUpDown = true;
            this.startTimeParks.Size = new System.Drawing.Size(200, 20);
            this.startTimeParks.TabIndex = 6;
            // 
            // startDateSpecificPark
            // 
            this.startDateSpecificPark.Location = new System.Drawing.Point(109, 122);
            this.startDateSpecificPark.Name = "startDateSpecificPark";
            this.startDateSpecificPark.Size = new System.Drawing.Size(200, 20);
            this.startDateSpecificPark.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(335, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Start Time: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Start Date: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Park: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(487, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "List of Parking Spots in a Specific Park For a Given Moment";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1090, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonListBelongingPark);
            this.tabPage4.Controls.Add(this.comboBoxSpotsSpecificPark);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.richTextBoxListBelongingPark);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1145, 592);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Parking Spots Belonging to a Specific Park";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(386, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "List Parking Spots Belonging to a Specific Park";
            // 
            // richTextBoxListBelongingPark
            // 
            this.richTextBoxListBelongingPark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxListBelongingPark.Location = new System.Drawing.Point(18, 132);
            this.richTextBoxListBelongingPark.Name = "richTextBoxListBelongingPark";
            this.richTextBoxListBelongingPark.Size = new System.Drawing.Size(1121, 457);
            this.richTextBoxListBelongingPark.TabIndex = 1;
            this.richTextBoxListBelongingPark.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(36, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Park: ";
            // 
            // comboBoxSpotsSpecificPark
            // 
            this.comboBoxSpotsSpecificPark.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBoxSpotsSpecificPark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpotsSpecificPark.FormattingEnabled = true;
            this.comboBoxSpotsSpecificPark.Location = new System.Drawing.Point(83, 92);
            this.comboBoxSpotsSpecificPark.Name = "comboBoxSpotsSpecificPark";
            this.comboBoxSpotsSpecificPark.Size = new System.Drawing.Size(186, 21);
            this.comboBoxSpotsSpecificPark.TabIndex = 3;
            // 
            // buttonListBelongingPark
            // 
            this.buttonListBelongingPark.Location = new System.Drawing.Point(325, 90);
            this.buttonListBelongingPark.Name = "buttonListBelongingPark";
            this.buttonListBelongingPark.Size = new System.Drawing.Size(75, 23);
            this.buttonListBelongingPark.TabIndex = 4;
            this.buttonListBelongingPark.Text = "Search";
            this.buttonListBelongingPark.UseVisualStyleBackColor = true;
            this.buttonListBelongingPark.Click += new System.EventHandler(this.buttonListBelongingPark_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.comboBoxFreeParks);
            this.tabPage5.Controls.Add(this.buttonFreeParkingSpots);
            this.tabPage5.Controls.Add(this.richTextBoxFreeParkingSpot);
            this.tabPage5.Controls.Add(this.timePickerFreeParkingSpots);
            this.tabPage5.Controls.Add(this.datePickerFreeParkingSpots);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1145, 592);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Free Parking Spots Specific Park for a Given Moment ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(521, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "List of Free Parking Spots in a specific Park for a Given Moment";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(38, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Park: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(37, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Date: ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(37, 149);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Time: ";
            // 
            // datePickerFreeParkingSpots
            // 
            this.datePickerFreeParkingSpots.Location = new System.Drawing.Point(85, 120);
            this.datePickerFreeParkingSpots.Name = "datePickerFreeParkingSpots";
            this.datePickerFreeParkingSpots.Size = new System.Drawing.Size(200, 20);
            this.datePickerFreeParkingSpots.TabIndex = 5;
            // 
            // timePickerFreeParkingSpots
            // 
            this.timePickerFreeParkingSpots.CustomFormat = "HH:mm:ss tt";
            this.timePickerFreeParkingSpots.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerFreeParkingSpots.Location = new System.Drawing.Point(85, 149);
            this.timePickerFreeParkingSpots.Name = "timePickerFreeParkingSpots";
            this.timePickerFreeParkingSpots.Size = new System.Drawing.Size(200, 20);
            this.timePickerFreeParkingSpots.TabIndex = 6;
            // 
            // richTextBoxFreeParkingSpot
            // 
            this.richTextBoxFreeParkingSpot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxFreeParkingSpot.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxFreeParkingSpot.ForeColor = System.Drawing.Color.Black;
            this.richTextBoxFreeParkingSpot.Location = new System.Drawing.Point(40, 175);
            this.richTextBoxFreeParkingSpot.Name = "richTextBoxFreeParkingSpot";
            this.richTextBoxFreeParkingSpot.Size = new System.Drawing.Size(1068, 399);
            this.richTextBoxFreeParkingSpot.TabIndex = 7;
            this.richTextBoxFreeParkingSpot.Text = "";
            // 
            // buttonFreeParkingSpots
            // 
            this.buttonFreeParkingSpots.Location = new System.Drawing.Point(324, 146);
            this.buttonFreeParkingSpots.Name = "buttonFreeParkingSpots";
            this.buttonFreeParkingSpots.Size = new System.Drawing.Size(75, 23);
            this.buttonFreeParkingSpots.TabIndex = 8;
            this.buttonFreeParkingSpots.Text = "Search";
            this.buttonFreeParkingSpots.UseVisualStyleBackColor = true;
            this.buttonFreeParkingSpots.Click += new System.EventHandler(this.buttonFreeParkingSpots_Click);
            // 
            // comboBoxFreeParks
            // 
            this.comboBoxFreeParks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFreeParks.FormattingEnabled = true;
            this.comboBoxFreeParks.Location = new System.Drawing.Point(85, 84);
            this.comboBoxFreeParks.Name = "comboBoxFreeParks";
            this.comboBoxFreeParks.Size = new System.Drawing.Size(200, 21);
            this.comboBoxFreeParks.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 697);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSource1;
        public System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox spotsSpecificParkData;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker startTimeParks;
        private System.Windows.Forms.DateTimePicker startDateSpecificPark;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker endDateSpecificPark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox parkSpecificParkData;
        private System.Windows.Forms.DateTimePicker endTimeSpecificPark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonListBelongingPark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTextBoxListBelongingPark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxSpotsSpecificPark;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonFreeParkingSpots;
        private System.Windows.Forms.RichTextBox richTextBoxFreeParkingSpot;
        private System.Windows.Forms.DateTimePicker timePickerFreeParkingSpots;
        private System.Windows.Forms.DateTimePicker datePickerFreeParkingSpots;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxFreeParks;
    }
}

