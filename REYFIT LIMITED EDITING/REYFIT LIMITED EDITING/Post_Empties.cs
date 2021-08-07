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
    public partial class Post_Empties : Form
    {
        public static string rs = "&Save";
        public static string id = "";
        private string date;
        private string num;
        public static string identify = "27";
        private General gclass = new General();
        public Post_Empties()
        {
            InitializeComponent();
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                if (Product_Inventory.code == "")
                {
                    this.gclass.LoadCombo(this.cat, "SELECT * FROM prod_category", "category");
                    //this.label4.Text = null;
                }
            }
            catch (Exception ex)
            {
                //this.gclass.error(exception.ToString() + "\n Try Again...");
                MessageBox.Show("Continue");
            }
        }

        private void Bank_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Bank_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Close();
        }


        private void gg(object sender, EventArgs e)
        {
            if (Convert.ToInt16(new MySqlCommand("SELECT COUNT(*) FROM post_empty_stock WHERE pdate = '" + DateTime.Now.ToString("yyyy/MM/dd") + "' AND category = '" + cat.Text + "'", this.gclass.conn()).ExecuteScalar()) != 0)
            {
                this.gclass.error("Warning, Already Posted.");
            }
            else
            {
                MySqlConnection connection = this.gclass.conn();
                MySqlConnection ibb = gclass.conn();
                MySqlCommand button1 = new MySqlCommand("insert into post_empty_stock(pdate,category,post1,post2,post3,post4,post5,post6,post7,post8,post9,post10,postedby)VALUES('" + pdate.Value.ToString("yyyy/MM/dd") + "','" + cat.Text + "','" + post1.Text + "','" + post2.Text + "','" + post3.Text + "','" + post4.Text + "','" + post5.Text + "','" + post6.Text + "','" + post7.Text + "','" + post8.Text + "','" + post9.Text + "','" + post10.Text + "','" + Program.user + "')", ibb);
                button1.ExecuteNonQuery();
                MessageBox.Show("Record Posted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.post1.Text = "0";
                this.post2.Text = "0";
                this.post3.Text = "0";
                this.post4.Text = "0";
                this.post5.Text = "0";
                this.post6.Text = "0";
                this.post7.Text = "0";
                this.post8.Text = "0";
                this.post9.Text = "0";
                this.post10.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

       private void cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string constring = "datasource=localhost;username = root;password = ''";
                //string constring = "datasource=SERVER;port = 3306;username = pos;password = 'pos'";
                string Query = "select SUM(stk_empty), SUM(stk) from bottle_sales_pos.product where dept ='" + cat.Text + "';";
                MySqlConnection ConDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, ConDataBase);
                MySqlDataReader myReader;
                try
                {
                    ConDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string spost1 = myReader.GetInt32("SUM(stk_empty)").ToString();
                        string spost2 = myReader.GetInt32("SUM(stk)").ToString();
                        post1.Text = spost1;
                        post2.Text = spost2;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void cat_Click(object sender, EventArgs e)
        {
            
        }
    }
  }
