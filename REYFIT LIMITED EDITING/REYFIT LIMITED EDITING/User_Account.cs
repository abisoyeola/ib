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
    public partial class User_Account : Form
    {
        public static string code = "";
        public static string identify = "19";
        private General gclass = new General();
        public User_Account()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtName.Text))
                {
                    this.gclass.error("Empty Field Cannot Be Saved...");
                }
                else
                {
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM acct_category WHERE category = '" + this.txtName.Text + "'", this.gclass.conn()).ExecuteReader();
                    if (reader.Read())
                    {
                        this.gclass.error("User Category Alredy Exist...\n Try Again");
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();
                        this.gclass.INSERT("INSERT INTO acct_category VALUES(id,'" + this.txtName.Text + "')");
                        this.txtName.Text = null;
                        this.gclass.DGVTable("SELECT id as 'S/N',category as 'ACCOUNT CATEGORY' FROM acct_Category", this.dataGridView1);
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void User_Account_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.DGVTable("SELECT id as 'S/N',category as 'ACCOUNT CATEGORY' FROM acct_Category", this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                code = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                base.Hide();
                new User_Account().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
