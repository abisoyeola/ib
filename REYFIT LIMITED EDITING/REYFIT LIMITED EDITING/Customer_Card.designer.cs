namespace POS_SALES
{
    partial class Customer_Card
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfn = new System.Windows.Forms.TextBox();
            this.TXTCODE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "&Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(347, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "HOW";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBalance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(130, 223);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(212, 27);
            this.txtBalance.TabIndex = 6;
            this.txtBalance.Text = "0.00";
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLimit
            // 
            this.txtLimit.BackColor = System.Drawing.Color.White;
            this.txtLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLimit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLimit.Location = new System.Drawing.Point(129, 190);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(212, 27);
            this.txtLimit.TabIndex = 3;
            this.txtLimit.Text = "0.00";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLimit.Click += new System.EventHandler(this.txtLimit_Click);
            this.txtLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLimit_KeyDown);
            this.txtLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimit_KeyPress);
            this.txtLimit.Leave += new System.EventHandler(this.txtLimit_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Balance Amount : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(32, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Credit Limit : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(67, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Phone Number";
            // 
            // txtaddress
            // 
            this.txtaddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtaddress.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.Location = new System.Drawing.Point(128, 112);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(303, 70);
            this.txtaddress.TabIndex = 2;
            this.txtaddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtphone
            // 
            this.txtphone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtphone.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.Location = new System.Drawing.Point(128, 79);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(303, 27);
            this.txtphone.TabIndex = 1;
            this.txtphone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtphone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtphone_KeyDown);
            this.txtphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtphone_KeyPress);
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCat.Location = new System.Drawing.Point(402, 16);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(44, 18);
            this.lblCat.TabIndex = 15;
            this.lblCat.Text = "CUS";
            this.lblCat.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(56, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Full Name";
            // 
            // txtfn
            // 
            this.txtfn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfn.Location = new System.Drawing.Point(127, 46);
            this.txtfn.Name = "txtfn";
            this.txtfn.Size = new System.Drawing.Size(355, 27);
            this.txtfn.TabIndex = 0;
            this.txtfn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.TXTCODE.TabIndex = 14;
            this.TXTCODE.Text = "AUTO";
            this.TXTCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(40, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Customer Id";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Controls.Add(this.txtLimit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtaddress);
            this.panel1.Controls.Add(this.txtphone);
            this.panel1.Controls.Add(this.lblCat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtfn);
            this.panel1.Controls.Add(this.TXTCODE);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 310);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 29);
            this.button3.TabIndex = 16;
            this.button3.Text = "Post";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Customer_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 310);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Customer_Card";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer_Card";
            this.Load += new System.EventHandler(this.Customer_Card_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfn;
        private System.Windows.Forms.TextBox TXTCODE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
    }
}