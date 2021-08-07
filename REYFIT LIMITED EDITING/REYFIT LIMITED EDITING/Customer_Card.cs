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
namespace POS_SALES
{
    public partial class Customer_Card : Form
    {
        public static string rs = "Post";

        public static string id = "";
      private string num = "";
        private string code = "";
       private string keys = null;
        private bool nonNumberEntered = false;
        private General gclass = new General();
        public Customer_Card()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Card_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Customer_Inventory.code.ToString()))
                {
                    //MySqlDataReader reader = new MySqlCommand("SELECT * FROM customer_card WHERE customerid = '" + Customer_Inventory.code.ToString() + "' ", this.gclass.conn()).ExecuteReader();
                    MySqlConnection connection = this.gclass.conn();
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM customer_card WHERE customerid = '" + Customer_Inventory.code.ToString() + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.TXTCODE.Text = Customer_Inventory.code.ToString();
                        this.txtfn.Text = reader.GetString("full_name");
                        this.txtphone.Text = reader.GetString("phone");
                        this.txtaddress.Text = reader.GetString("add1");
                        this.txtBalance.Text = reader.GetString("balance");
                        this.txtLimit.Text = reader.GetString("balance_limit");
                        this.button3.Text = "Update";
                    }
                    reader.Close();
                }
                base.KeyUp += new KeyEventHandler(this.KeyEvent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Continue");
            }
        }
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.button3.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void txtLimit_Click(object sender, EventArgs e)
        {
            this.txtLimit.SelectAll();
        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                if ((((e.KeyCode < Keys.D0) || (e.KeyCode > Keys.D9)) && ((e.KeyCode < Keys.NumPad0) || (e.KeyCode > Keys.NumPad9))) && (e.KeyCode != Keys.Back))
                {
                    this.nonNumberEntered = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtLimit_Leave(object sender, EventArgs e)
        {
            this.txtLimit.Text = $"{Convert.ToDecimal(this.txtLimit.Text):N}";
        }

        private void txtphone_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                if ((((e.KeyCode < Keys.D0) || (e.KeyCode > Keys.D9)) && ((e.KeyCode < Keys.NumPad0) || (e.KeyCode > Keys.NumPad9))) && (e.KeyCode != Keys.Back))
                {
                    this.nonNumberEntered = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        try
            {
                if (button3.Text == rs)
                {
                    string str2 = (Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM customer_card", this.gclass.conn()).ExecuteScalar().ToString()) + 1).ToString();
                    this.code = (str2.ToString().Length != 1) ? ((str2.ToString().Length != 2) ? ((str2.ToString().Length != 3) ? ((str2.ToString().Length != 4) ? ((str2.ToString().Length != 5) ? (this.lblCat.Text + str2) : (this.lblCat.Text + "0" + str2)) : (this.lblCat.Text + "00" + str2)) : (this.lblCat.Text + "000" + str2)) : (this.lblCat.Text + "0000" + str2)) : (this.lblCat.Text + "00000" + str2);
                    MySqlConnection ibb = gclass.conn();
                    //ibb.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into customer_card(customerid,full_name,phone,add1,balance,balance_limit,postedby)VALUES('" + code.ToString() + "','" + txtfn.Text + "','" + txtphone.Text + "','" + txtaddress.Text + "','" + txtBalance.Text + "','" + txtLimit.Text + "','" + Program.user + "')", ibb);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.TXTCODE.Text = "AUTO";
                    this.txtfn.Text = null;
                    this.txtLimit.Text = "0.00";
                    this.txtBalance.Text = "0.00";
                    this.txtphone.Text = "";
                    this.txtaddress.Text = "";
                    Customer_Inventory.code = "";
                }

                else if (button3.Text == "Update")
                {
                    MySqlConnection jj = gclass.conn();
                    //cnq.Open();
                    MySqlCommand button2 = new MySqlCommand("update  customer_card set full_name='" + txtfn.Text + "', add1='" + txtaddress.Text + "', phone='" + txtphone.Text + "', balance_limit='" + txtLimit.Text + "'  where customerid='" + TXTCODE.Text + "'", jj);
                    button2.ExecuteNonQuery();
                    this.TXTCODE.Text = "AUTO";
                    this.txtfn.Text = null;
                    this.txtLimit.Text = "0.00";
                    this.txtBalance.Text = "0.00";
                    this.txtphone.Text = "";
                    this.txtaddress.Text = "";
                    Product_Inventory.code = "";
                    //Product_Inventory.id = "";

                }

            }
            catch (Exception yy)
            {
                MessageBox.Show(yy.Message);
                //throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    }

