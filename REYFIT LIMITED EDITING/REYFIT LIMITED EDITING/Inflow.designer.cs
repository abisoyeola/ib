namespace POS_SALES
{
    partial class Inflow
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
            this.ref_no = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.amt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.desc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.today = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ref_no);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.amt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.desc);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 195);
            this.panel1.TabIndex = 1;
            // 
            // ref_no
            // 
            this.ref_no.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ref_no.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ref_no.Location = new System.Drawing.Point(104, 53);
            this.ref_no.Name = "ref_no";
            this.ref_no.Size = new System.Drawing.Size(246, 27);
            this.ref_no.TabIndex = 60;
            this.ref_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 59;
            this.label6.Text = "Refrence No";
            // 
            // amt
            // 
            this.amt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.amt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amt.Location = new System.Drawing.Point(105, 119);
            this.amt.Name = "amt";
            this.amt.Size = new System.Drawing.Size(267, 27);
            this.amt.TabIndex = 57;
            this.amt.Text = "0.00";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Amount";
            // 
            // desc
            // 
            this.desc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.desc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.Location = new System.Drawing.Point(105, 86);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(360, 27);
            this.desc.TabIndex = 57;
            this.desc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Description";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.today);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 37);
            this.panel2.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Posting Date";
            // 
            // today
            // 
            this.today.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.today.Location = new System.Drawing.Point(142, 8);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(108, 20);
            this.today.TabIndex = 42;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(224, 154);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 32);
            this.button5.TabIndex = 46;
            this.button5.Text = "&Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(125, 154);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 32);
            this.button6.TabIndex = 45;
            this.button6.Text = "&Save";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Inflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 195);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Inflow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post Inflow Account";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Expense_FormClosed);
            this.Load += new System.EventHandler(this.Expense_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox amt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox desc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker today;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox ref_no;
        private System.Windows.Forms.Label label6;
    }
}