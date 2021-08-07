namespace POS_SALES
{
    partial class Backup
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dsize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtype = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.desc = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.desc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 232);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(74, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 50);
            this.button1.TabIndex = 104;
            this.button1.Text = "Backup";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dsize);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dlabel);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dtype);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dname);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(10, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 119);
            this.panel2.TabIndex = 103;
            // 
            // dsize
            // 
            this.dsize.AutoSize = true;
            this.dsize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsize.ForeColor = System.Drawing.Color.RosyBrown;
            this.dsize.Location = new System.Drawing.Point(107, 88);
            this.dsize.Name = "dsize";
            this.dsize.Size = new System.Drawing.Size(34, 16);
            this.dsize.TabIndex = 102;
            this.dsize.Text = "null";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.RosyBrown;
            this.label8.Location = new System.Drawing.Point(10, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 102;
            this.label8.Text = "Drive Size :";
            // 
            // dlabel
            // 
            this.dlabel.AutoSize = true;
            this.dlabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dlabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.dlabel.Location = new System.Drawing.Point(107, 61);
            this.dlabel.Name = "dlabel";
            this.dlabel.Size = new System.Drawing.Size(34, 16);
            this.dlabel.TabIndex = 102;
            this.dlabel.Text = "null";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.RosyBrown;
            this.label6.Location = new System.Drawing.Point(3, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 102;
            this.label6.Text = "Drive Label :";
            // 
            // dtype
            // 
            this.dtype.AutoSize = true;
            this.dtype.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtype.ForeColor = System.Drawing.Color.RosyBrown;
            this.dtype.Location = new System.Drawing.Point(107, 36);
            this.dtype.Name = "dtype";
            this.dtype.Size = new System.Drawing.Size(34, 16);
            this.dtype.TabIndex = 102;
            this.dtype.Text = "null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RosyBrown;
            this.label4.Location = new System.Drawing.Point(7, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 102;
            this.label4.Text = "Drive Type :";
            // 
            // dname
            // 
            this.dname.AutoSize = true;
            this.dname.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dname.ForeColor = System.Drawing.Color.RosyBrown;
            this.dname.Location = new System.Drawing.Point(107, 12);
            this.dname.Name = "dname";
            this.dname.Size = new System.Drawing.Size(34, 16);
            this.dname.TabIndex = 102;
            this.dname.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RosyBrown;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "Drive Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 102;
            this.label1.Text = "Select Drive";
            // 
            // desc
            // 
            this.desc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.desc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.desc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.FormattingEnabled = true;
            this.desc.Location = new System.Drawing.Point(97, 10);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(204, 36);
            this.desc.TabIndex = 101;
            this.desc.SelectedIndexChanged += new System.EventHandler(this.desc_SelectedIndexChanged);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 232);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.Backup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dsize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox desc;
    }
}