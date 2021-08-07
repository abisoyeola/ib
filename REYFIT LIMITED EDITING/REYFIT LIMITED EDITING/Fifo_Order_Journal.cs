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
using System.Collections;

namespace POS_SALES
{
    public partial class Fifo_Order_Journal : Form
    {
        public static string status = null;
        public static string identify = "11";
        private string tab = null;
        private General gclass = new General();
        private bool nonNumberEntered = true;
        public Fifo_Order_Journal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                status = "PURCHASE";  
                new Add_Product().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = gclass.conn();
            // MessageBox.Show("Success");
            for (int x = 0; x < dataGridView1.Rows.Count - 0; x++)
                    try
            {
                int num2 = 0;
                while (true)
                {
                    bool flag = num2 < this.dataGridView1.Rows.Count;
                    if (flag)
                    {
                        decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                        decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[5].Value);
                        decimal num5 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                        if (num5 >= 0M)
                        {
                            num2++;
                            continue;
                        }
                        this.gclass.error("Invalid Input \n Quantity Return Cannot be Less than Zero");
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num2].Cells[4];
                    }
                    else
                    {
                        decimal num6 = 0M;
                       
                        if (MessageBox.Show("Are You Sure ?\n Posted Record cannot Be Edited...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                                int num7 = 0;
                                string[] strArray = new string[] { "PUR", DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), Program.user_id.ToString() };
                                string str = string.Concat(strArray);
                                num6 = (this.dataGridView1.Rows[num7].Cells[3].Value.ToString() != "") ? ((Convert.ToDecimal(this.dataGridView1.Rows[num7].Cells[3].Value.ToString()) + Convert.ToDecimal(this.dataGridView1.Rows[num7].Cells[5].Value)) / 2M) : Convert.ToDecimal(this.dataGridView1.Rows[num7].Cells[5].Value);
                                decimal fifo_order1 = Convert.ToDecimal(Search_Product.fifo_order1);
                                decimal qty_sold1 = Convert.ToDecimal(Search_Product.qty_sold1);
                                decimal fifo_cp1 = Convert.ToDecimal(Search_Product.fifo_cp1);

                                decimal fifo_order2 = Convert.ToDecimal(Search_Product.fifo_order2);
                                decimal qty_sold2 = Convert.ToDecimal(Search_Product.qty_sold2);
                                decimal fifo_cp2 = Convert.ToDecimal(Search_Product.fifo_cp2);

                                decimal fifo_order3 = Convert.ToDecimal(Search_Product.fifo_order3);
                                decimal qty_sold3 = Convert.ToDecimal(Search_Product.qty_sold3);
                                decimal fifo_cp3 = Convert.ToDecimal(Search_Product.fifo_cp3);

                                decimal fifo_order4 = Convert.ToDecimal(Search_Product.fifo_order4);
                                decimal qty_sold4 = Convert.ToDecimal(Search_Product.qty_sold4);
                                decimal fifo_cp4 = Convert.ToDecimal(Search_Product.fifo_cp4);

                                for (int ttx = 0; ttx < dataGridView1.Rows.Count; ttx++)
                                {
                                   MySqlCommand yy = new MySqlCommand(@"UPDATE product SET fifo_order1 = '" + dataGridView1.Rows[ttx].Cells[4].Value + "',qty_sold1 = '" + 0 + "',fifo_cp1 = '" + dataGridView1.Rows[ttx].Cells[5].Value + "' WHERE code = '" + dataGridView1.Rows[ttx].Cells[0].Value + "'", cn);
                                   yy.ExecuteNonQuery();
                                    
                                }
                                this.gclass.success("Record Posted Successfully...");

                                
                                {
                                DateTime time;
                                {
                                    //this.orderno.Text = null;
                                    //this.discount.Text = "0.00";
                                    //this.discount2.Text = "0.00";
                                    //this.address.Text = null;
                                    //this.address.Text = null;
                                    //this.dataGridView1.Rows.Clear();
                                    //this.txtTotal.Text = "0.00";
                                    //this.due.Text = "0.00";
                                    //this.name.SelectedIndex = -1;
                                    break;
                                }
                               time = this.today.Value;
                            }
                        }
                    }
                    break;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal num = 0M;
                decimal num1 = 0M;
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.dataGridView1.Rows.Count)
                    {
                        //this.txtTotal.Text = $"{num:N}";
                        //this.tot_qty.Text = num1.ToString();
                        //this.discount2.Text = this.discount.Text;
                        //this.due.Text = (num - Convert.ToDecimal(this.discount.Text)).ToString();
                        break;
                    }
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                    decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[5].Value);
                    this.dataGridView1.Rows[num2].Cells[9].Value = num3 * num4;
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[9].Value);
                    num1 += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                    num2++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                decimal num;
                if ((((e.ColumnIndex == 4) || ((e.ColumnIndex == 5) || ((e.ColumnIndex == 6) || (e.ColumnIndex == 7)))) || (e.ColumnIndex == 8)) && !decimal.TryParse(Convert.ToString(e.FormattedValue), out num))
                {
                    e.Cancel = true;
                    this.gclass.error("please enter numeric Value\n Format:80");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            this.tab = e.KeyCode.ToString();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.tab == "Return")
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void discount_KeyDown(object sender, KeyEventArgs e)
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

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.nonNumberEntered;
        }

        private void discount_Leave(object sender, EventArgs e)
        {
            decimal num = Convert.ToDecimal(this.discount.Text);
            this.discount.Text = $"{num:N}";
        }

        private void discount_MouseClick(object sender, MouseEventArgs e)
        {
            this.discount.SelectAll();
        }
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                new Search_Product().ShowDialog();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.button6.Focus();
            }
        }
        private void discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.discount2.Text = this.discount.Text;
                //this.due.Text = (Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.discount2.Text)).ToString();
                //this.due.Text = $"{Convert.ToDecimal(this.due.Text):N}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //MySqlDataReader reader = new MySqlCommand("SELECT * FROM VENDOR WHERE vn = '" + this.name.Text + "'", this.gclass.conn()).ExecuteReader();
                //if (reader.Read())
                //{
                //    //this.code.Text = "VND" + reader.GetString("id");
                //    //this.address.Text = reader.GetString("add1") + " " + reader.GetString("add2");
                //    //this.bal.Text = reader.GetString("bal");
                //}
                //reader.Close();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void orderno_KeyDown(object sender, KeyEventArgs e)
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

        private void orderno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = this.nonNumberEntered;
        }

        private void Purchase_Invoice_Activated(object sender, EventArgs e)
        {
            try
            {
                if (this.label3.Text == "0")
                {
                    this.label3.Text = "label3";
                    if (!string.IsNullOrWhiteSpace(Search_Product.descptn))
                    {
                        int count = this.dataGridView1.Rows.Count;
                        if (count > 0)
                        {
                            int num2 = 0;
                            while (true)
                            {
                                if (num2 >= count)
                                {
                                    break;
                                }
                                if (Search_Product.code != this.dataGridView1.Rows[num2].Cells[0].Value.ToString())
                                {
                                    num2++;
                                    continue;
                                }
                                this.gclass.error("Product Has Already Been Added");
                                this.dataGridView1.Focus();
                                this.dataGridView1.Rows[num2].Selected = true;
                                return;
                            }
                        }
                        this.dataGridView1.Rows.Add();
                        int num3 = this.dataGridView1.Rows.Count - 1;
                        decimal fifo_order1 = Convert.ToDecimal(Search_Product.fifo_order1);
                        decimal qty_sold1 = Convert.ToDecimal(Search_Product.qty_sold1);
                        decimal fifo_cp1 = Convert.ToDecimal(Search_Product.fifo_cp1);

                        decimal fifo_order2 = Convert.ToDecimal(Search_Product.fifo_order2);
                        decimal qty_sold2 = Convert.ToDecimal(Search_Product.qty_sold2);
                        decimal fifo_cp2 = Convert.ToDecimal(Search_Product.fifo_cp2);

                        decimal fifo_order3 = Convert.ToDecimal(Search_Product.fifo_order3);
                        decimal qty_sold3 = Convert.ToDecimal(Search_Product.qty_sold3);
                        decimal fifo_cp3 = Convert.ToDecimal(Search_Product.fifo_cp3);

                        decimal fifo_order4 = Convert.ToDecimal(Search_Product.fifo_order4);
                        decimal qty_sold4 = Convert.ToDecimal(Search_Product.qty_sold4);
                        decimal fifo_cp4 = Convert.ToDecimal(Search_Product.fifo_cp4);
                        if (qty_sold1 < fifo_order1)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp1;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp1;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        else if (qty_sold1 == fifo_order1)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp2;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp2;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        else if (qty_sold1 > fifo_order1)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp2;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp2;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }

                        else if (qty_sold2 < fifo_order2)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp2;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.cp;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        if (qty_sold2 == fifo_order2)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp3;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp3;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        else if (qty_sold2 > fifo_order2)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp3;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp3;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        else if (qty_sold3 < fifo_order3)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp3;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp3;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        if (qty_sold3 == fifo_order3)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp1;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp1;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        else if (qty_sold3 > fifo_order3)
                        {
                            this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                            this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                            this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                            this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.fifo_cp1;
                            this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.fifo_cp1;
                            this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                            this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                            this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                            this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                            this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                            this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                            this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                            this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                            this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                            this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                            this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                            this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                            this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                            this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                            this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        }
                        //this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        //this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        //this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        //this.dataGridView1.Rows[num3].Cells[3].Value = Search_Product.cp;
                        //this.dataGridView1.Rows[num3].Cells[4].Value = "0";
                        //this.dataGridView1.Rows[num3].Cells[5].Value = Search_Product.cp;
                        //this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.sp;
                        //this.dataGridView1.Rows[num3].Cells[7].Value = Search_Product.pack_price;
                        //this.dataGridView1.Rows[num3].Cells[8].Value = Search_Product.qtyin_pack;
                        //this.dataGridView1.Rows[num3].Cells[9].Value = "0";
                        //this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.cat;
                        //this.dataGridView1.Rows[num3].Cells[12].Value = Search_Product.fifo_qty;
                        //this.dataGridView1.Rows[num3].Cells[13].Value = Search_Product.qty_sold;
                        //this.dataGridView1.Rows[num3].Cells[14].Value = Search_Product.fifo_order1;
                        //this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product.qty_sold1;
                        //this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.fifo_order2;
                        //this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.qty_sold2;
                        //this.dataGridView1.Rows[num3].Cells[18].Value = Search_Product.fifo_order3;
                        //this.dataGridView1.Rows[num3].Cells[19].Value = Search_Product.qty_sold3;
                        //this.dataGridView1.Rows[num3].Cells[20].Value = Search_Product.fifo_order4;
                        //this.dataGridView1.Rows[num3].Cells[21].Value = Search_Product.qty_sold4;
                        //this.dataGridView1.Focus();
                        //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[4];
                        //Search_Product.bcode = null;
                        //Search_Product.code = null;
                        //Search_Product.descptn = null;
                        //Search_Product.cat = null;
                        //Search_Product.cp = null;
                        //Search_Product.pack_price = null;
                        //Search_Product.sp = null;
                        //Search_Product.stock = null;
                        //Search_Product.stock_empty = null;
                        //Search_Product.lpc = null;
                        //Search_Product.qtyin_pack = null;
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Purchase_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.label18.Text = this.today.Value.ToString("yyyy/MM/dd");
                //this.gclass.LoadCombo(this.name, "SELECT * FROM vendor", "vn");
                //this.address.Text = "AUTO";
                //this.code.Text = "AUTO";
                this.dataGridView1.Rows.Clear();
                this.timer1.Start();
                base.KeyUp += new KeyEventHandler(this.KeyEvent);
                this.KeyPreview = true;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label19.Text = DateTime.Now.ToString("T");
        }

        private void Purchase_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                //this.txtTendered.Text = "0.00";
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                button2.PerformClick();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_Product dc = new Search_Product();
            dc.ShowDialog();
        }

        private void due_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    this.due.Text = $"{(Convert.ToDecimal(this.due.Text)):N}".ToString();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Input Figures");
            //}
        }
    }
}
