namespace POS_SALES
{
    partial class Bank
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.acctype = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.address1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTCODE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.acctype);
            this.panel1.Controls.Add(this.lblCat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.phone);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.address1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TXTCODE);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 238);
            this.panel1.TabIndex = 10;
            // 
            // acctype
            // 
            this.acctype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.acctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.acctype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acctype.FormattingEnabled = true;
            this.acctype.Items.AddRange(new object[] {
            "SAVINGS",
            "CURRENT",
            "CREDIT"});
            this.acctype.Location = new System.Drawing.Point(129, 152);
            this.acctype.Name = "acctype";
            this.acctype.Size = new System.Drawing.Size(319, 28);
            this.acctype.TabIndex = 22;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCat.Location = new System.Drawing.Point(461, 16);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(45, 18);
            this.lblCat.TabIndex = 9;
            this.lblCat.Text = "BNK";
            this.lblCat.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(43, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bank Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(23, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Account Type";
            // 
            // phone
            // 
            this.phone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phone.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone.Location = new System.Drawing.Point(128, 119);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(369, 27);
            this.phone.TabIndex = 1;
            this.phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Account No";
            // 
            // name
            // 
            this.name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(129, 48);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(369, 27);
            this.name.TabIndex = 1;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // address1
            // 
            this.address1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.address1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1.Location = new System.Drawing.Point(128, 81);
            this.address1.Name = "address1";
            this.address1.Size = new System.Drawing.Size(369, 27);
            this.address1.TabIndex = 1;
            this.address1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Branch";
            // 
            // TXTCODE
            // 
            this.TXTCODE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TXTCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTCODE.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTCODE.Location = new System.Drawing.Point(128, 13);
            this.TXTCODE.Name = "TXTCODE";
            this.TXTCODE.ReadOnly = true;
            this.TXTCODE.Size = new System.Drawing.Size(240, 27);
            this.TXTCODE.TabIndex = 7;
            this.TXTCODE.Text = "AUTO";
            this.TXTCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(46, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bank Code";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(285, 192);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 32);
            this.button5.TabIndex = 4;
            this.button5.Text = "&Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(176, 192);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 32);
            this.button6.TabIndex = 3;
            this.button6.Text = "&Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.gg);
            // 
            // Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 238);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Bank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bank_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bank_FormClosed);
            this.Load += new System.EventHandler(this.Bank_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox acctype;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox address1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTCODE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}