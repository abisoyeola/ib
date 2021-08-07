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
    public partial class Vendor : Form
    {
        private General gclass = new General();
        public static string u = "Save";
        public static string id = "";
        public static string identify = "20";
        public Vendor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (button6.Text == u)
            {
                MySqlConnection cn = gclass.conn();
                //  cn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into vendor(vn,add1,add2,phone,email,bal,status)VALUES('" + company.Text + "','" + add1.Text + "','" + add2.Text + "','" + phone.Text + "','" + email.Text + "','" + bal.Text + "','" + Program.vendor_status + "')", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vendor Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MySqlDataAdapter adp = new MySqlDataAdapter("select * from vendor", cn);
                //DataSet dt = new DataSet();
                //adp.Fill(dt);
                //dataGridView1.DataSource = dt.Tables[0].DefaultView;
                this.vc.Text = "AUTO";
                this.company.Text = null;
                this.add1.Text = null;
                this.add2.Text = null;
                this.phone.Text = null;
                this.email.Text = null;
                //cn.Close();
            }
            
            else if (button6.Text == "Update")
            {
                MySqlConnection cnq = gclass.conn();
               // cnq.Open();

                MySqlCommand cmdq = new MySqlCommand("update  vendor set vn ='" + company.Text + "', add1='" + add1.Text + "', add2='" + add2.Text + "', phone='" + phone.Text + "', email='" + email.Text + "', bal='" + bal.Text + "' where id='" + Vendor.id + "'", cnq);
                cmdq.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MySqlDataAdapter adp = new MySqlDataAdapter("select * from vendor", cnq);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                this.vc.Text = "AUTO";
                this.company.Text = null;
                this.add1.Text = null;
                this.add2.Text = null;
                this.phone.Text = null;
                this.email.Text = null;
              //  cnq.Close();
            }
        }
    }
}

       