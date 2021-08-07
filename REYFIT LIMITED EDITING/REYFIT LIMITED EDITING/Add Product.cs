using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace POS_SALES
{
    public partial class Add_Product : Form
    {
        private string code = "";
        private bool nonNumberEntered = false;
        private string key = "";
        private string tab = "";
        public static string code2 = "";
        public static string identify = "6";
        public static string desct = "";
        public static string rs = "Save";
        private General gclass = new General();
        public static string id = "";
        public Add_Product()
        {
            InitializeComponent();
            Fillcombo();
        }
        void Fillcombo()
        {
            string constring = "Server=localhost;Uid=root;Password=''";
            //string constring = "Server=SERVER;Uid=pos;Password='pos'";
            string Query = "select * from bottle_sales_pos.prod_category;";
            MySqlConnection ConDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sCourse = myReader.GetString("category");


                    dept.Items.Add(sCourse);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.Text == rs)
                {
                    string str2 = (Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM product", this.gclass.conn()).ExecuteScalar().ToString()) + 1).ToString();
                    this.code = (str2.ToString().Length != 1) ? ((str2.ToString().Length != 2) ? ((str2.ToString().Length != 3) ? ((str2.ToString().Length != 4) ? ((str2.ToString().Length != 5) ? (this.label4.Text + str2) : (this.label4.Text + "0" + str2)) : (this.label4.Text + "00" + str2)) : (this.label4.Text + "000" + str2)) : (this.label4.Text + "0000" + str2)) : (this.label4.Text + "00000" + str2);
                    MySqlConnection ibb = gclass.conn();
                    //ibb.Open();
                    MySqlCommand button1 = new MySqlCommand("insert into product(code,description,container,dept,ivpg,ncp,cp,ws,s_p,stk,wp,lpc,lpd,status,barcode,wp_qty,exp_date,odr_limit,fifo_qty,minimum_qty,discount)VALUES('" + this.code.ToString() + "','" + desc.Text + "','" + cont.Text + "','" + dept.Text + "','" + Program.IVPG + "','" + cp.Text + "','" + cp.Text + "','" + ws.Text + "','" + s_p.Text + "','" + stk.Text + "','" + wp.Text + "','" + lpc.Text + "','" + lpd.Text + "','" + Program.status + "','" + barcode.Text + "','" + ws_qty.Text + "','" + dateTimePicker1.Text + "','" + ro.Text + "','" + fifo_qty.Text + "','" + minimum_qty.Text + "','" + discount.Text + "')", ibb);
                    button1.ExecuteNonQuery();

                    MessageBox.Show("Product Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.pdc.Text = "AUTO";
                    this.desc.Text = null;
                    this.dept.Text = null;
                    minimum_qty.Text = "0";
                    discount.Text = "0";
                    this.cont.Text = null;
                    this.cp.Text = "0.00";
                    this.ws.Text = "0.00";
                    this.s_p.Text = "0.00";
                    this.stk.Text = "0";
                    this.wp.Text = "0.00";
                    this.lpc.Text = "0.00";
                    this.lpd.Text = null;
                    this.ws_qty.Value = this.ws_qty.Minimum;
                    this.ro.Value = this.ro.Minimum;
                    this.fifo_qty.Value = this.fifo_qty.Minimum;
                    this.barcode.Text = null;
                    Product_Inventory.code = "";
                }

                else if (button2.Text == "Update")
                {
                    MySqlConnection jj = gclass.conn();
                    //cnq.Open();
                    MySqlCommand button2 = new MySqlCommand("update  product set description='" + desc.Text + "', container='" + cont.Text + "', dept='" + dept.Text + "', ivpg='" + Program.IVPG + "', cp='" + cp.Text + "', ws='" + ws.Text + "', s_p='" + s_p.Text + "', stk='" + stk.Text + "', wp='" + wp.Text + "', lpc='" + lpc.Text + "', lpd='" + lpd.Text + "', status='" + Program.status + "', barcode='" + barcode.Text + "', wp_qty='" + ws_qty.Text + "', exp_date='" + dateTimePicker1.Text + "', odr_limit='" + ro.Text + "', minimum_qty='" + minimum_qty.Text + "', discount='" + discount.Text + "' where code='" + Product_Inventory.code + "'", jj);
                    button2.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.pdc.Text = "AUTO";
                    this.desc.Text = null;
                    this.dept.Text = null;
                    this.cont.Text = null;
                    this.cp.Text = "0.00";
                    this.ws.Text = "0.00";
                    this.s_p.Text = "0.00";
                    this.stk.Text = "0";
                    this.wp.Text = "0.00";
                    this.lpc.Text = "0.00";
                    this.lpd.Text = null;
                    this.ws_qty.Value = this.ws_qty.Minimum;
                    this.ro.Value = this.ro.Minimum;
                    this.barcode.Text = null;
                    minimum_qty.Text = "0";
                    discount.Text = "0";
                    Product_Inventory.code = "";
                    //Product_Inventory.id = "";

                }

            }
            catch (Exception yy)
            {
                MessageBox.Show(yy.Message);
                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                base.Close();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
                if (Product_Inventory.code == "")
                {
                    this.gclass.LoadCombo(this.dept, "SELECT * FROM prod_category", "category");
                    this.label4.Text = null;
                }
             }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Product_Inventory.code != "")
                {
                    code2 = this.pdc.Text;
                    desct = this.desc.Text;
                    new Inventory_Profile().ShowDialog();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM prod_category WHERE category = '" + this.dept.Text + "'", this.gclass.conn()).ExecuteReader();
                if (reader.Read())
                {
                    this.label4.Text = reader.GetString("code");
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void cp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                this.key = e.KeyCode.ToString();
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

        private void cp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.cp_Leave(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void cp_Leave(object sender, EventArgs e)
        {

            try
            {
                this.cp.Text = $"{Convert.ToDecimal(this.cp.Text):N}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void s_p_Leave(object sender, EventArgs e)
        {
            try
            {
                this.s_p.Text = $"{Convert.ToDecimal(this.s_p.Text):N}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void s_p_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                this.key = e.KeyCode.ToString();
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

        private void s_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.s_p_Leave(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void ws_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                this.key = e.KeyCode.ToString();
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

        private void ws_qty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                this.key = e.KeyCode.ToString();
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

        private void ws_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
           try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.ws_qty_KeyPress(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void ws_Leave(object sender, EventArgs e)
        {
            try
            {
                this.ws.Text = $"{Convert.ToDecimal(this.ws.Text):N}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void ws_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.ws_KeyPress(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Product_Inventory.code != "")
                {
                    code2 = this.pdc.Text;
                    desct = this.desc.Text;
                    new Inventory_Profile().ShowDialog();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Product_Inventory.code != "")
                {
                    code2 = this.pdc.Text;
                    desct = this.desc.Text;
                    new Inventory_Profile_Empty().ShowDialog();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
