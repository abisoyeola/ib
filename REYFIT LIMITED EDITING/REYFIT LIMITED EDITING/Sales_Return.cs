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
    public partial class Sales_Return : Form
    {
        private bool nonNumberEntered = false;
        public static string identify = "16";
        private General gclass = new General();
        private string enter = null;
        private string tab = null;
        public Sales_Return()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = gclass.conn();
            // MessageBox.Show("Success");
         
                    try
            {
                int count = this.dataGridView1.Rows.Count;
                int num2 = 0;
                //while (true)
                //{
                    //bool flag = num2 < count;
                   // if (flag)
                    //{
                        decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[2].Value);
                        decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[7].Value);
                        if (num3 < num4)
                        {
                            this.gclass.error(("Invalid Input \n Quantity Return Cannot be greater than Quantity Bought\n\t Check Row " + (num2 + 1) + " ").ToString());
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num2].Cells[7];
                        }
                        //else
                        //{
                            if (Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[7].Value) >= 0M)
                            {
                                num2++;
                                //continue;
                            }
                            this.gclass.error("Invalid Input \n Quantity Return Cannot be Less than Zero");
                            this.dataGridView1.Focus();
                            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num2].Cells[7];
                       
                    //}
                    //else if ((this.receiptNo.Text == "") || (this.dataGridView1.Rows.Count == 0))
                    //{
                    //    this.gclass.error("Invalid Command. Enter Reciept No to Return Product");

                    //}

                    //else
                    //{
                        if (MessageBox.Show("Are you sure ? \n Return Posted Cannot be Modified.", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string[] strArray = new string[] { "SR", DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), Program.user_id.ToString() };
                            string str2 = string.Concat(strArray);
                            int num6 = this.dataGridView1.Rows.Count;

                            for (int x = 0; x < dataGridView1.Rows.Count; x++)
                            {

                                MySqlCommand jh = new MySqlCommand("insert into product_profile (pdate,entry_type,code,description,current_stock,qty,purpose,postedby)VALUES('" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + pstgrp.Text + "','" + dataGridView1.Rows[x].Cells[0].Value + "','" + dataGridView1.Rows[x].Cells[1].Value + "','" + dataGridView1.Rows[x].Cells[9].Value + "','" + dataGridView1.Rows[x].Cells[7].Value + "','" + pstgrp.Text + "','" + Program.user + "')", cn);
                                MySqlCommand hh = new MySqlCommand("insert into sales_return_detail (doc_no,entry_type,code,description,stock,qty,amount)VALUES('" + str2 + "','" + pstgrp.Text + "','" + dataGridView1.Rows[x].Cells[0].Value + "','" + dataGridView1.Rows[x].Cells[1].Value + "','" + dataGridView1.Rows[x].Cells[9].Value + "','" + dataGridView1.Rows[x].Cells[7].Value + "','" + dataGridView1.Rows[x].Cells[10].Value + "')", cn);
                                MySqlCommand yy = new MySqlCommand(@"UPDATE product SET stk = '" + (Convert.ToInt32(this.dataGridView1.Rows[x].Cells[7].Value) + Convert.ToInt32(this.dataGridView1.Rows[x].Cells[9].Value)) + "' WHERE code = '" + dataGridView1.Rows[x].Cells[0].Value + "'", cn);
                                yy.ExecuteNonQuery();
                                jh.ExecuteNonQuery();
                                hh.ExecuteNonQuery();
                            }
                            MySqlCommand button1 = new MySqlCommand(@"INSERT INTO sales_return_summary(doc_no,pdate,entry_type,total,customer,recieptno,cashier,postedby)VALUES('" + str2 + "','" + today.Value.ToString("yyyy/MM/dd") + "','" + pstgrp.Text + "','" + txtTotal.Text + "','" + lblCustomer.Text + "','" + SalesRcpt.Text + "','" + lblPostedBy.Text + "','" + Program.user + "')", cn);
                            button1.ExecuteNonQuery();
                            this.gclass.success("Record successfully Posted...");
                       
                            receiptNo.Text = null;
                            this.dataGridView1.Rows.Clear();
                                this.txtTotal.Text = null;
                                this.lblAmtDue.Text = "0.00";
                                this.lblCustomer.Text = "AUTO";
                                this.lblDate.Text = "AUTO";
                                this.lblDiscount.Text = "0.00";
                                this.lblMode.Text = "AUTO";
                                this.lblPostedBy.Text = "AUTO";
                                this.lblTotal.Text = "0.00";
                                this.SalesRcpt.Text = "AUTO";
                    }
               // }

                   // }
                 // }
         
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
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        break;
                    }
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[2].Value);
                    decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[3].Value);
                  //string str = this.dataGridView1.Rows[num2].Cells[3].Value.ToString();
                    decimal num5 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[7].Value);
                    decimal num6 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[5].Value);
                    //if (str == "True")
                    //{
                        this.dataGridView1.Rows[num2].Cells[10].Value = num5 * num4;
                        //this.dataGridView1.Rows[num2].Cells[11].Value = num5 * num4;
                    //}
                    //else
                    //{
                    //    //this.dataGridView1.Rows[num2].Cells[7].Value = this.dataGridView1.Rows[num2].Cells[9].Value;
                    //  //  this.dataGridView1.Rows[num2].Cells[11].Value = num5 * num4;
                    //}
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[10].Value);
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
                int num;
                if ((e.ColumnIndex == 7) && !int.TryParse(Convert.ToString(e.FormattedValue), out num))
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
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
            }
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

        private void receiptNo_Enter(object sender, EventArgs e)
        {
            this.receiptNo.Clear();
            this.dataGridView1.Rows.Clear();
        }

        private void receiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                this.enter = e.KeyCode.ToString();
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

        private void receiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.enter == "Return")
                {
                    this.Search_Sales(this.receiptNo.Text);
                }
                else
                {
                    e.Handled = this.nonNumberEntered;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void receiptNo_MouseClick(object sender, MouseEventArgs e)
        {
            this.receiptNo.Clear();
            this.dataGridView1.Rows.Clear();
        }
        private string Search_Sales(string rpn)
        {
            try
            {
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM Sales_Summary WHERE recieptno = '" + rpn + "'", this.gclass.conn()).ExecuteReader();
                if (reader.Read())
                {
                    this.lblAmtDue.Text = reader.GetString("net_pay");
                    this.lblCustomer.Text = reader.GetString("customer");
                    this.lblDate.Text = reader.GetString("pdate");
                    this.lblDiscount.Text = reader.GetString("discount");
                    this.lblMode.Text = reader.GetString("mode");
                    this.lblPostedBy.Text = reader.GetString("postedby");
                    this.lblTotal.Text = reader.GetString("total");
                    this.SalesRcpt.Text = reader.GetString("recieptno");
                }
                else
                {
                    this.gclass.error("Receipt Number is Not Valid...\n Try Again");
                    this.lblAmtDue.Text = "0.00";
                    this.lblCustomer.Text = "AUTO";
                    this.lblDate.Text = "AUTO";
                    this.lblDiscount.Text = "0.00";
                    this.lblMode.Text = "AUTO";
                    this.lblPostedBy.Text = "AUTO";
                    this.lblTotal.Text = "0.00";
                    this.SalesRcpt.Text = "AUTO";
                }
                reader.Close();
                MySqlDataReader reader2 = new MySqlCommand("SELECT * FROM Sales_detail WHERE recieptno = '" + rpn + "'", this.gclass.conn()).ExecuteReader();
                while (true)
                {
                    bool flag = reader2.Read();
                    if (!flag)
                    {
                        reader2.Close();
                        int count = this.dataGridView1.Rows.Count;
                        int num3 = 0;
                        while (true)
                        {
                            flag = num3 < count;
                            if (!flag)
                            {
                                this.dataGridView1.Focus();
                                this.dataGridView1.CurrentCell = this.dataGridView1.CurrentRow.Cells[7];
                                break;
                            }
                            this.dataGridView1.Rows[num3].Cells[9].Value = new MySqlCommand("SELECT stk FROM product WHERE code = '" + this.dataGridView1.Rows[num3].Cells[0].Value.ToString() + "' ", this.gclass.conn()).ExecuteScalar();
                            num3++;
                        }
                        break;
                    }
                    this.dataGridView1.Rows.Add();
                    int num = this.dataGridView1.Rows.Count - 1;
                    this.dataGridView1.Rows[num].Cells[0].Value = reader2.GetString("prod_code");
                    this.dataGridView1.Rows[num].Cells[1].Value = reader2.GetString("description");
                    this.dataGridView1.Rows[num].Cells[2].Value = reader2.GetString("qty");
                    this.dataGridView1.Rows[num].Cells[3].Value = reader2.GetString("unit");
                    this.dataGridView1.Rows[num].Cells[4].Value = reader2.GetString("pack_price");
                    this.dataGridView1.Rows[num].Cells[5].Value = reader2.GetString("total");
                    //this.dataGridView1.Rows[num].Cells[6].Value = reader2.GetString("pack");
                    this.dataGridView1.Rows[num].Cells[7].Value = "0";
                    this.dataGridView1.Rows[num].Cells[8].Value = reader2.GetString("qty_pack");
                    this.dataGridView1.Rows[num].Cells[9].Value = reader2.GetString("stock");
                    //this.dataGridView1.Rows[num].Cells[9].Value = this.dataGridView1.Rows[num].Cells[7].Value;
                    this.dataGridView1.Rows[num].Cells[10].Value = "0";
                   //this.dataGridView1.Rows[num].Cells[11].Value = reader2.GetString("stk");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
            return "ola";
        }
        private void Sales_Return_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.receiptNo.Focus();
                this.timer1.Start();
                this.label18.Text = this.today.Value.ToString("yyyy/MM/dd");
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.label19.Text = $"{DateTime.Now:T}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
