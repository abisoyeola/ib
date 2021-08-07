namespace POS_SALES
{
    partial class Debit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Debit));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customer_name = new System.Windows.Forms.Label();
            this.customer_id = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtAmtpaid = new System.Windows.Forms.TextBox();
            this.lblOutstandingbalance = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // customer_name
            // 
            this.customer_name.AutoSize = true;
            this.customer_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customer_name.Location = new System.Drawing.Point(109, 71);
            this.customer_name.Name = "customer_name";
            this.customer_name.Size = new System.Drawing.Size(134, 18);
            this.customer_name.TabIndex = 99;
            this.customer_name.Text = "Oustanding Payment";
            // 
            // customer_id
            // 
            this.customer_id.AutoSize = true;
            this.customer_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customer_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customer_id.Location = new System.Drawing.Point(109, 45);
            this.customer_id.Name = "customer_id";
            this.customer_id.Size = new System.Drawing.Size(134, 18);
            this.customer_id.TabIndex = 99;
            this.customer_id.Text = "Oustanding Payment";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerm.ForeColor = System.Drawing.Color.Red;
            this.lblTerm.Location = new System.Drawing.Point(186, 12);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(57, 16);
            this.lblTerm.TabIndex = 96;
            this.lblTerm.Text = "Session";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(149, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 95;
            this.label9.Text = "Time:";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.ForeColor = System.Drawing.Color.Red;
            this.lblSession.Location = new System.Drawing.Point(56, 12);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(57, 16);
            this.lblSession.TabIndex = 94;
            this.lblSession.Text = "Session";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 93;
            this.label6.Text = "Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(221, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 22);
            this.dateTimePicker1.TabIndex = 43;
            this.dateTimePicker1.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(208, 237);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(92, 29);
            this.button6.TabIndex = 42;
            this.button6.Text = "&Cancel";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(33, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Amount Debited";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Red;
            this.lblBalance.Location = new System.Drawing.Point(164, 92);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(58, 25);
            this.lblBalance.TabIndex = 36;
            this.lblBalance.Text = "0.00";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(83, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "Balance";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(2, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(140, 15);
            this.label20.TabIndex = 32;
            this.label20.Text = "Outstanding Balance";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(16, 237);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 29);
            this.button7.TabIndex = 41;
            this.button7.Text = "&Save";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(1, 73);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(108, 16);
            this.name.TabIndex = 37;
            this.name.Text = "Customer Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Customer Id :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.txtAmtpaid);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lblBalance);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.lblOutstandingbalance);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Location = new System.Drawing.Point(4, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(317, 130);
            this.panel4.TabIndex = 33;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(207, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(89, 42);
            this.dataGridView1.TabIndex = 87;
            this.dataGridView1.Visible = false;
            // 
            // txtAmtpaid
            // 
            this.txtAmtpaid.BackColor = System.Drawing.Color.Black;
            this.txtAmtpaid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmtpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtpaid.ForeColor = System.Drawing.Color.Blue;
            this.txtAmtpaid.Location = new System.Drawing.Point(169, 48);
            this.txtAmtpaid.Name = "txtAmtpaid";
            this.txtAmtpaid.Size = new System.Drawing.Size(140, 24);
            this.txtAmtpaid.TabIndex = 41;
            this.txtAmtpaid.Text = "0.00";
            this.txtAmtpaid.TextChanged += new System.EventHandler(this.txtAmtpaid_TextChanged_1);
            this.txtAmtpaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmtpaid_KeyDown_1);
            this.txtAmtpaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmtpaid_KeyPress_1);
            this.txtAmtpaid.Leave += new System.EventHandler(this.txtAmtpaid_Leave_1);
            // 
            // lblOutstandingbalance
            // 
            this.lblOutstandingbalance.AutoSize = true;
            this.lblOutstandingbalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingbalance.ForeColor = System.Drawing.Color.Red;
            this.lblOutstandingbalance.Location = new System.Drawing.Point(164, 13);
            this.lblOutstandingbalance.Name = "lblOutstandingbalance";
            this.lblOutstandingbalance.Size = new System.Drawing.Size(58, 25);
            this.lblOutstandingbalance.TabIndex = 31;
            this.lblOutstandingbalance.Text = "0.00";
            this.lblOutstandingbalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.customer_name);
            this.panel1.Controls.Add(this.customer_id);
            this.panel1.Controls.Add(this.lblTerm);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblSession);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 284);
            this.panel1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(245, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(76, 52);
            this.listBox1.TabIndex = 102;
            this.listBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(110, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 29);
            this.button1.TabIndex = 101;
            this.button1.Text = "&Print";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 100;
            this.label1.Text = "PAY";
            this.label1.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Debit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 284);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Debit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debit Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label customer_name;
        private System.Windows.Forms.Label customer_id;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtAmtpaid;
        private System.Windows.Forms.Label lblOutstandingbalance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

