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
    public partial class Bank : Form
    {
        public static string rs = "&Save";
        public static string id = "";
        private string code;
        private string num;
        public static string identify = "2";
        private General gclass = new General();
        public Bank()
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
                if (Bank_Card.code == "1")
                {
                    this.button6.Text = "&Save";
                }
                else
                {
                    this.button6.Text = "&Update";
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM bank WHERE code ='" + Bank_Card.code.ToString() + "'", this.gclass.conn()).ExecuteReader();
                    if (reader.Read())
                    {
                        this.TXTCODE.Text = reader.GetString("code");
                        this.name.Text = reader.GetString("name");
                        this.address1.Text = reader.GetString("add2");
                        this.phone.Text = reader.GetString("email");
                        this.acctype.Text = reader.GetString("acct_type");
                    }
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void Bank_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Bank_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Hide();
            new Bank_Card().ShowDialog();
        }

       
        private void gg(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = this.gclass.conn();
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM bank ", connection);
                this.num = command.ExecuteScalar().ToString();
                string str = (Convert.ToInt32(this.num) + 1).ToString();
                if (str.ToString().Length == 1)
                {
                    this.code = this.lblCat.Text + "000" + str;
                }
                else if (str.ToString().Length == 2)
                {
                    this.code = this.lblCat.Text + "00" + str;
                }
                else if (str.ToString().Length == 3)
                {
                    this.code = this.lblCat.Text + "0" + str;
                }
                else if (str.ToString().Length == 4)
                {
                    this.code = this.lblCat.Text + str;
                }
                if ((string.IsNullOrWhiteSpace(this.name.Text) || string.IsNullOrWhiteSpace(this.code)) || (this.acctype.SelectedIndex == -1))
                {
                    this.gclass.error("Empty Fields Cannot Be saved... \n Try Again");
                }
                if (button6.Text == rs)
                {
                    MySqlConnection ibb = gclass.conn();

                    MySqlCommand button1 = new MySqlCommand("insert into bank(code,name,add2,email,acct_type)VALUES('" + code.ToString() + "','" + name.Text + "','" + address1.Text + "','" + phone.Text + "','" + acctype.Text + "')", ibb);
                    button1.ExecuteNonQuery();

                    MessageBox.Show("Record Posted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.name.Text = null;
                    this.acctype.SelectedIndex = -1;
                    this.button6.Text = "&Save";
                    this.TXTCODE.Text = "AUTO";
                    this.address1.Text = null;
                    this.phone.Text = null;
                }
                else if (button6.Text == "&Update")
                {
                    MySqlConnection ibb = gclass.conn();
                    //cnq.Open();
                    MySqlCommand button2 = new MySqlCommand("Update  bank set name='" + name.Text + "', add2='" + address1.Text + "', email='" + phone.Text + "', acct_type='" + acctype.Text + "'  where code='" + Bank_Card.code + "'", ibb);
                    button2.ExecuteNonQuery();
                    this.name.Text = null;
                    this.acctype.SelectedIndex = -1;
                    this.button6.Text = "&Save";
                    this.TXTCODE.Text = "AUTO";
                    this.address1.Text = null;
                    this.phone.Text = null;
                    //Product_Inventory.id = "";
                    MessageBox.Show("Record Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
    }
