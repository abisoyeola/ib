namespace POS_SALES
{
    partial class Fifo_Order_Journal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button5 = new System.Windows.Forms.Button();
            this.discount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.invoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.orderno = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.pstgrp = new System.Windows.Forms.TextBox();
            this.today = new System.Windows.Forms.DateTimePicker();
            this.puchno = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.amtDue = new System.Windows.Forms.Label();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(548, 453);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 32);
            this.button5.TabIndex = 14;
            this.button5.Text = "&Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // discount
            // 
            this.discount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.discount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount.Location = new System.Drawing.Point(548, 43);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(153, 27);
            this.discount.TabIndex = 9;
            this.discount.Text = "0.00";
            this.discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.discount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.discount_MouseClick);
            this.discount.TextChanged += new System.EventHandler(this.discount_TextChanged);
            this.discount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.discount_KeyDown);
            this.discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discount_KeyPress);
            this.discount.Leave += new System.EventHandler(this.discount_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(475, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Discount :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Invoice Number :";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(448, 453);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 32);
            this.button6.TabIndex = 2;
            this.button6.Text = "&Post";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(904, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // invoiceDate
            // 
            this.invoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.invoiceDate.Location = new System.Drawing.Point(361, 46);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.Size = new System.Drawing.Size(102, 22);
            this.invoiceDate.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Invoice Date :";
            // 
            // orderno
            // 
            this.orderno.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderno.Location = new System.Drawing.Point(123, 46);
            this.orderno.Name = "orderno";
            this.orderno.Size = new System.Drawing.Size(134, 27);
            this.orderno.TabIndex = 13;
            this.orderno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderno_KeyDown);
            this.orderno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.orderno_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(930, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 46);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(128, 15);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "CREDIT";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(27, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "CASH";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(305, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Time:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(176, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "Date:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column16,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23});
            this.dataGridView1.Location = new System.Drawing.Point(4, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(962, 410);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 528);
            this.panel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 497);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(972, 31);
            this.panel5.TabIndex = 135;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(21, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 20);
            this.label8.TabIndex = 132;
            this.label8.Text = "Press F4 to Select Product";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.invoiceDate);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.orderno);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.discount);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.pstgrp);
            this.panel3.Controls.Add(this.today);
            this.panel3.Controls.Add(this.puchno);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.amtDue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 36);
            this.panel3.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(962, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 10);
            this.button2.TabIndex = 136;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(448, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 16);
            this.label16.TabIndex = 6;
            this.label16.Text = "Posting Group :";
            // 
            // pstgrp
            // 
            this.pstgrp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pstgrp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pstgrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pstgrp.Location = new System.Drawing.Point(560, 4);
            this.pstgrp.Name = "pstgrp";
            this.pstgrp.ReadOnly = true;
            this.pstgrp.Size = new System.Drawing.Size(195, 24);
            this.pstgrp.TabIndex = 7;
            this.pstgrp.Text = "FIFO ORDER JOURNAL";
            this.pstgrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // today
            // 
            this.today.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.today.Location = new System.Drawing.Point(1003, 11);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(102, 20);
            this.today.TabIndex = 4;
            // 
            // puchno
            // 
            this.puchno.AutoSize = true;
            this.puchno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puchno.ForeColor = System.Drawing.Color.Red;
            this.puchno.Location = new System.Drawing.Point(115, 9);
            this.puchno.Name = "puchno";
            this.puchno.Size = new System.Drawing.Size(50, 16);
            this.puchno.TabIndex = 1;
            this.puchno.Text = "AUTO";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(359, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "AUTO";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(221, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "AUTO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Document No:";
            // 
            // amtDue
            // 
            this.amtDue.AutoSize = true;
            this.amtDue.ForeColor = System.Drawing.Color.Maroon;
            this.amtDue.Location = new System.Drawing.Point(1019, 38);
            this.amtDue.Name = "amtDue";
            this.amtDue.Size = new System.Drawing.Size(13, 13);
            this.amtDue.TabIndex = 125;
            this.amtDue.Text = "0";
            this.amtDue.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "AMOUNT";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PRODUCT CODE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DESCRIPTION";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 290;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "STOCK";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "LAST COST PRICE";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "QUANTITY";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "CURRENT COST PRICE";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "SELLING PRICE";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "EMPTY BOTTLE PRICE";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "QUANTITY IN PACK";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            this.Column10.Width = 70;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "AMOUNT";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "category";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "fifo_qty";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "qty_sold";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "FIFO ORDER 1";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "QTY SOLD 1";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Visible = false;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "FIFO ORDER 2";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "QTY SOLD 2";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Visible = false;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "FIFO ORDER 3";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Visible = false;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "QTY SOLD 3";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Visible = false;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "FIFO ORDER 4";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Visible = false;
            // 
            // Column23
            // 
            this.Column23.HeaderText = "QTY SOLD 4";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Visible = false;
            // 
            // Fifo_Order_Journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 528);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Fifo_Order_Journal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fifo Order Journal";
            this.Activated += new System.EventHandler(this.Purchase_Invoice_Activated);
            this.Load += new System.EventHandler(this.Purchase_Invoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Purchase_Invoice_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox discount;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker invoiceDate;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox orderno;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox pstgrp;
        public System.Windows.Forms.DateTimePicker today;
        public System.Windows.Forms.Label puchno;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label amtDue;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
    }
}