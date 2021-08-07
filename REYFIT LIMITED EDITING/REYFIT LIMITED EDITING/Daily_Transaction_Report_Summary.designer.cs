namespace POS_SALES
{
    partial class Daily_Transaction_Report_Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daily_Transaction_Report_Summary));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.fullname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTransfer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPOS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bottle_purchased = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.total_amt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(10, 395);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(619, 252);
            this.dataGridView2.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Cashier Name:";
            // 
            // fullname
            // 
            this.fullname.AutoSize = true;
            this.fullname.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullname.Location = new System.Drawing.Point(126, 35);
            this.fullname.Name = "fullname";
            this.fullname.Size = new System.Drawing.Size(49, 16);
            this.fullname.TabIndex = 14;
            this.fullname.Text = "Cash:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cashier Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cash:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Coral;
            this.label9.Location = new System.Drawing.Point(149, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Note:  Total Amount = Grand Total - Total Discount";
            // 
            // txtCheque
            // 
            this.txtCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCheque.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(153, 153);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.ReadOnly = true;
            this.txtCheque.Size = new System.Drawing.Size(267, 27);
            this.txtCheque.TabIndex = 12;
            this.txtCheque.Text = "0.00";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(85, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Cheque:";
            // 
            // txtTransfer
            // 
            this.txtTransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTransfer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransfer.Location = new System.Drawing.Point(153, 120);
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.ReadOnly = true;
            this.txtTransfer.Size = new System.Drawing.Size(267, 27);
            this.txtTransfer.TabIndex = 10;
            this.txtTransfer.Text = "0.00";
            this.txtTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Daily Transaction Summary Report";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Transfer:";
            // 
            // txtPOS
            // 
            this.txtPOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPOS.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOS.Location = new System.Drawing.Point(154, 87);
            this.txtPOS.Name = "txtPOS";
            this.txtPOS.ReadOnly = true;
            this.txtPOS.Size = new System.Drawing.Size(267, 27);
            this.txtPOS.TabIndex = 8;
            this.txtPOS.Text = "0.00";
            this.txtPOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(107, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "POS:";
            // 
            // txtCash
            // 
            this.txtCash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCash.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(154, 54);
            this.txtCash.Name = "txtCash";
            this.txtCash.ReadOnly = true;
            this.txtCash.Size = new System.Drawing.Size(267, 27);
            this.txtCash.TabIndex = 6;
            this.txtCash.Text = "0.00";
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cash:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(451, 268);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 30);
            this.listBox1.TabIndex = 16;
            this.listBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(447, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 67);
            this.button1.TabIndex = 15;
            this.button1.Text = "Print";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bottle_purchased);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.total_amt);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtCredit);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.fullname);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCheque);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTransfer);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.txtPOS);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCash);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(5, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 358);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Overall Report";
            // 
            // txtCredit
            // 
            this.txtCredit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCredit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(154, 186);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(267, 27);
            this.txtCredit.TabIndex = 17;
            this.txtCredit.Text = "0.00";
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(55, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "Credit Sales:";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(154, 219);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(267, 27);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 384);
            this.panel1.TabIndex = 11;
            // 
            // bottle_purchased
            // 
            this.bottle_purchased.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bottle_purchased.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottle_purchased.Location = new System.Drawing.Point(154, 252);
            this.bottle_purchased.Name = "bottle_purchased";
            this.bottle_purchased.ReadOnly = true;
            this.bottle_purchased.Size = new System.Drawing.Size(267, 27);
            this.bottle_purchased.TabIndex = 25;
            this.bottle_purchased.Text = "0.00";
            this.bottle_purchased.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Bottle Purchased:";
            // 
            // total_amt
            // 
            this.total_amt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.total_amt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_amt.Location = new System.Drawing.Point(154, 284);
            this.total_amt.Name = "total_amt";
            this.total_amt.ReadOnly = true;
            this.total_amt.Size = new System.Drawing.Size(267, 27);
            this.total_amt.TabIndex = 23;
            this.total_amt.Text = "0.00";
            this.total_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Total Sales Amount:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "Sub Total Amount:";
            // 
            // Daily_Transaction_Report_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 384);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Daily_Transaction_Report_Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily_Transaction_Report_Summary";
            this.Load += new System.EventHandler(this.Daily_Transaction_Report_Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label fullname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTransfer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPOS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox bottle_purchased;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox total_amt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}