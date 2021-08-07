using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
namespace POS_SALES
{
    public partial class User_Account_Form : Form
    {
        public static string u = "Save";
        public static string id = "";
        private General gclass = new General();
        public static string identify = "17";
        public User_Account_Form()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.password.PasswordChar = this.checkBox1.Checked ? '\0' : Convert.ToChar("*");
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.checkBox2.Text = this.checkBox2.Checked ? "ACTIVE" : "IN-ACTIVE";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.vc.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.fullname.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.add1.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                this.add2.Text = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                this.phone.Text = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                this.email.Text = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                this.category.Text = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                this.username.Text = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                this.username.ReadOnly = true;
                this.password.Text = this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                this.button6.Text = "Update";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void User_Account_Form_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.LoadCombo(this.category, "SELECT * FROM acct_category", "category");
                this.gclass.DGVTable("SELECT id as 'USER ID',fn as 'FULL NAME',ADD1 as 'ADDRESS1',ADD2 AS 'ADDRESS2',PHONE as 'PHONE NUMBER',EMAIL as 'EMAIL ADDRESS',role as 'DESIGNATION',username as 'USERNAME',status as 'STATUS' FROM user_reg ORDER BY ID ASC", this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.button6.Text == "Save")
                {
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM user_reg WHERE username='" + this.username.Text + "'", this.gclass.conn()).ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                    }
                    else
                    {
                        this.gclass.error("Username Already Exist... \n\t Please Use Another");
                        reader.Close();
                        this.username.Focus();
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void ff(object sender, EventArgs e)
        {
            if (button6.Text == u)
            {
                MySqlConnection cn = gclass.conn();
              //  cn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into user_reg(fn,add1,add2,phone,email,role,username,password,status)VALUES('" + fullname.Text + "','" + add1.Text + "','" + add2.Text + "','" + phone.Text + "','" + email.Text + "','" + category.Text + "','" + username.Text + "','" + password.Text + "','" + checkBox2.Text + "')", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MySqlDataAdapter adp = new MySqlDataAdapter("select * from user_reg", cn);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0].DefaultView;
                this.vc.Text = "AUTO";
                this.fullname.Text = null;
                this.add1.Text = null;
                this.add2.Text = null;
                this.phone.Text = null;
                this.email.Text = null;
                this.username.Text = null;
                this.password.Text = null;
                this.checkBox1.Checked = false;
                this.checkBox2.Checked = true;
                this.category.SelectedIndex = -1;
              //  this.username.ReadOnly = false;
                cn.Close();
            }

            else if (button6.Text == "Update")
            {
                MySqlConnection cnq = gclass.conn();
             //   cnq.Open();
                MySqlCommand cmdq = new MySqlCommand("update user_reg set fn ='" + fullname.Text + "' , add1='" + add1.Text + "', add2='" + add2.Text + "', phone='" + phone.Text + "', email='" + email.Text + "', role='" + category.Text + "', username='" + username.Text + "', password='" + password.Text + "', status='" + checkBox2.Text + "' where id='" + vc.Text + "'", cnq);
                cmdq.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MySqlDataAdapter adp = new MySqlDataAdapter("select * from user_reg", cnq);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                this.vc.Text = "AUTO";
                this.fullname.Text = null;
                this.add1.Text = null;
                this.add2.Text = null;
                this.phone.Text = null;
                this.email.Text = null;
                this.username.Text = null;
                this.password.Text = null;
                this.checkBox1.Checked = false;
                this.checkBox2.Checked = true;
                this.category.SelectedIndex = -1;
                this.username.ReadOnly = false;
                //cnq.Close();
            }
        }
    }
}
