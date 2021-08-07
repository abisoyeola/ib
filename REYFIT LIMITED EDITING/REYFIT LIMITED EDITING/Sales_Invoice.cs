using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace POS_SALES
{
    public partial class Sales_Invoice : Form
    {

        private string wp_qty = null;
        private Font myfont2 = new Font("Arial", 8f);
        private Font myHead = new Font("Arial", 11f, FontStyle.Bold);
        private bool nonNumberEntered = false;
        private string key = "";
        private string tab = "";
        public static string identify = "14";
        private string reportTitle;
        private General gclass = new General();
        public Sales_Invoice()
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
            try
                    {
                        //MySqlConnection connection = this.gclass.conn();
                        string[] strArray = new string[] { DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), Program.user_id.ToString() };
                        this.recieptno.Text = string.Concat(strArray);
                if (this.dataGridView1.Rows.Count < 1)
                {
                    this.gclass.error("Invalid Command...\n Select a Product  ");
                }
                else if (((Convert.ToDecimal(this.amtDue.Text) > Convert.ToDecimal(this.NetPay.Text)) || (Convert.ToDecimal(this.changeDue.Text) < 0M)) || (Convert.ToDecimal(this.amtDue.Text) > Convert.ToDecimal(this.txtTendered.Text)))
                {
                    MessageBox.Show("Bill Has Not Been Fully settled. \n\t Try Again...", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (MessageBox.Show("Are You Sure ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                for (int tt = 0; tt < dataGridView1.Rows.Count; tt++)
                    {
                        //MySqlCommand button1 = new MySqlCommand(@"INSERT INTO sales_detail(pdate,mode,recieptno,prod_code,description,stock,qty,unit,total,pack,pack_price,qty_pack_db,cppl,qty_pack,cp,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[tt].Cells[0].Value + "','" + dataGridView1.Rows[tt].Cells[1].Value + "','" + dataGridView1.Rows[tt].Cells[2].Value + "','" + dataGridView1.Rows[tt].Cells[3].Value + "','" + dataGridView1.Rows[tt].Cells[4].Value + "','" + dataGridView1.Rows[tt].Cells[8].Value + "','" + dataGridView1.Rows[tt].Cells[5].Value + "','" + dataGridView1.Rows[tt].Cells[6].Value + "','" + dataGridView1.Rows[tt].Cells[11].Value + "','" + dataGridView1.Rows[tt].Cells[13].Value + "','" + dataGridView1.Rows[tt].Cells[7].Value + "','" + dataGridView1.Rows[tt].Cells[12].Value + "','" + Program.user + "')", cn);
                        MySqlCommand button3 = new MySqlCommand(@"INSERT INTO sales_detail_qty(pdate,mode,recieptno,prod_code,description,stock,qty,pack,qty_pack_db,qty_pack,tot_qty_sold,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[tt].Cells[0].Value + "','" + dataGridView1.Rows[tt].Cells[1].Value + "','" + dataGridView1.Rows[tt].Cells[2].Value + "','" + dataGridView1.Rows[tt].Cells[3].Value + "','" + dataGridView1.Rows[tt].Cells[5].Value + "','" + dataGridView1.Rows[tt].Cells[11].Value + "','" + dataGridView1.Rows[tt].Cells[14].Value + "','" + dataGridView1.Rows[tt].Cells[14].Value + "','" + Program.user + "')", cn);
                        MySqlCommand jh = new MySqlCommand("insert into product_profile (pdate,entry_type,code,description,current_stock,qty,purpose,postedby)VALUES('" + label18.Text + "','" + Program.purpose + "','" + dataGridView1.Rows[tt].Cells[0].Value + "','" + dataGridView1.Rows[tt].Cells[1].Value + "','" + dataGridView1.Rows[tt].Cells[2].Value + "','" + dataGridView1.Rows[tt].Cells[3].Value + "','" + Program.purpose + "','" + Program.user + "')", cn);
                        MySqlCommand yy = new MySqlCommand(@"UPDATE product SET stk = '" + (Convert.ToInt32(dataGridView1.Rows[tt].Cells[2].Value) - Convert.ToInt32(dataGridView1.Rows[tt].Cells[3].Value)) + "' WHERE code = '" + dataGridView1.Rows[tt].Cells[0].Value + "'", cn);
                        yy.ExecuteNonQuery();
                        jh.ExecuteNonQuery();
                        //button1.ExecuteNonQuery();
                        button3.ExecuteNonQuery();
                    }
                    for (int xy = 0; xy < dataGridView1.Rows.Count; xy++)
                        if (!((bool)this.dataGridView1.Rows[xy].Cells[5].Value))
                        {

                        }
                        else

                        {
                            MySqlCommand yy = new MySqlCommand(@"UPDATE product SET stk = '" + (Convert.ToInt32(dataGridView1.Rows[xy].Cells[2].Value) - Convert.ToInt32(dataGridView1.Rows[xy].Cells[7].Value)) + "' WHERE code = '" + dataGridView1.Rows[xy].Cells[0].Value + "'", cn);
                            yy.ExecuteNonQuery();
                        }
                    for (int dd = 0; dd < dataGridView1.Rows.Count; dd++)
                        if (!((bool)this.dataGridView1.Rows[dd].Cells[5].Value))
                        {
                            MySqlCommand button1 = new MySqlCommand(@"INSERT INTO sales_detail(pdate,mode,recieptno,prod_code,description,stock,qty,unit,total,pack,pack_price,qty_pack_db,cppl,qty_pack,cp,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[dd].Cells[0].Value + "','" + dataGridView1.Rows[dd].Cells[1].Value + "','" + dataGridView1.Rows[dd].Cells[2].Value + "','" + dataGridView1.Rows[dd].Cells[3].Value + "','" + dataGridView1.Rows[dd].Cells[4].Value + "','" + dataGridView1.Rows[dd].Cells[8].Value + "','" + dataGridView1.Rows[dd].Cells[5].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[11].Value + "','" + dataGridView1.Rows[dd].Cells[13].Value + "','" + dataGridView1.Rows[dd].Cells[7].Value + "','" + dataGridView1.Rows[dd].Cells[12].Value + "','" + Program.user + "')", cn);
                            button1.ExecuteNonQuery();
                        }
                        else

                        {
                            MySqlCommand jj = new MySqlCommand(@"INSERT INTO sales_detail(pdate,mode,recieptno,prod_code,description,stock,qty,unit,total,pack,pack_price,qty_pack_db,cppl,qty_pack,cp,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[dd].Cells[0].Value + "','" + dataGridView1.Rows[dd].Cells[1].Value + "','" + dataGridView1.Rows[dd].Cells[2].Value + "','" + dataGridView1.Rows[dd].Cells[3].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[8].Value + "','" + dataGridView1.Rows[dd].Cells[5].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[11].Value + "','" + dataGridView1.Rows[dd].Cells[13].Value + "','" + dataGridView1.Rows[dd].Cells[7].Value + "','" + dataGridView1.Rows[dd].Cells[12].Value + "','" + Program.user + "')", cn);
                            jj.ExecuteNonQuery();
                        }
                    for (int dd = 0; dd < dataGridView1.Rows.Count; dd++)
                        if (!((bool)this.dataGridView1.Rows[dd].Cells[5].Value))
                        {
                            MySqlCommand button1 = new MySqlCommand(@"INSERT INTO sales_invoice_detail(pdate,mode,recieptno,prod_code,description,stock,qty,unit,total,pack,pack_price,qty_pack_db,cppl,qty_pack,cp,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[dd].Cells[0].Value + "','" + dataGridView1.Rows[dd].Cells[1].Value + "','" + dataGridView1.Rows[dd].Cells[2].Value + "','" + dataGridView1.Rows[dd].Cells[3].Value + "','" + dataGridView1.Rows[dd].Cells[4].Value + "','" + dataGridView1.Rows[dd].Cells[8].Value + "','" + dataGridView1.Rows[dd].Cells[5].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[11].Value + "','" + dataGridView1.Rows[dd].Cells[13].Value + "','" + dataGridView1.Rows[dd].Cells[7].Value + "','" + dataGridView1.Rows[dd].Cells[12].Value + "','" + Program.user + "')", cn);
                            button1.ExecuteNonQuery();
                        }
                        else

                        {
                            MySqlCommand jj = new MySqlCommand(@"INSERT INTO sales_invoice_detail(pdate,mode,recieptno,prod_code,description,stock,qty,unit,total,pack,pack_price,qty_pack_db,cppl,qty_pack,cp,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[dd].Cells[0].Value + "','" + dataGridView1.Rows[dd].Cells[1].Value + "','" + dataGridView1.Rows[dd].Cells[2].Value + "','" + dataGridView1.Rows[dd].Cells[3].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[8].Value + "','" + dataGridView1.Rows[dd].Cells[5].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[11].Value + "','" + dataGridView1.Rows[dd].Cells[13].Value + "','" + dataGridView1.Rows[dd].Cells[7].Value + "','" + dataGridView1.Rows[dd].Cells[12].Value + "','" + Program.user + "')", cn);
                            jj.ExecuteNonQuery();
                        }
                    for (int tj = 0; tj < dataGridView1.Rows.Count; tj++)
                        if (!((bool)this.dataGridView1.Rows[tj].Cells[5].Value))
                        {

                        }
                        else

                        {
                            MySqlCommand jh = new MySqlCommand("insert into product_profile (pdate,entry_type,code,description,current_stock,qty,purpose,postedby)VALUES('" + label18.Text + "','" + Program.purpose + "','" + dataGridView1.Rows[tj].Cells[0].Value + "','" + dataGridView1.Rows[tj].Cells[1].Value + "','" + dataGridView1.Rows[tj].Cells[2].Value + "','" + dataGridView1.Rows[tj].Cells[7].Value + "','" + Program.purpose + "','" + Program.user + "')", cn);
                            jh.ExecuteNonQuery();
                        }
                    MySqlCommand hh = new MySqlCommand("insert into sales_summary (pdate,mode,bank,refno,recieptno,total,discount,amt_less_discount,amt_tender,change_due,net_pay,postedby,customer)VALUES('" + label18.Text + "','" + mode.Text + "','" + comboBox1.Text + "','" + txtRefno.Text + "','" + recieptno.Text + "','" + txtTotal.Text + "','" + txtDiscount.Text + "','" + amtDue.Text + "','" + txtTendered.Text + "','" + changeDue.Text + "','" + NetPay.Text + "','" + Program.user + "','" + cName.Text + "')", cn);
                    hh.ExecuteNonQuery();
                    MySqlCommand hf = new MySqlCommand("insert into sales_invoice_summary (pdate,mode,bank,refno,recieptno,total,discount,amt_less_discount,amt_tender,change_due,net_pay,postedby,customer)VALUES('" + label18.Text + "','" + mode.Text + "','" + comboBox1.Text + "','" + txtRefno.Text + "','" + recieptno.Text + "','" + txtTotal.Text + "','" + txtDiscount.Text + "','" + amtDue.Text + "','" + txtTendered.Text + "','" + changeDue.Text + "','" + NetPay.Text + "','" + Program.user + "','" + cName.Text + "')", cn);
                    hf.ExecuteNonQuery();
                    MessageBox.Show("Posted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //for (int y = 0; y < dataGridView1.Rows.Count; y++)
                    //{
                    //    dataGridView2.Rows.Add((y + 1).ToString(), dataGridView1.Rows[y].Cells[0].Value, dataGridView1.Rows[y].Cells[1].Value, dataGridView1.Rows[y].Cells[3].Value, dataGridView1.Rows[y].Cells[4].Value, dataGridView1.Rows[y].Cells[8].Value);

                    //}
                    for (int xy = 0; xy < dataGridView1.Rows.Count; xy++)
                        if (!((bool)this.dataGridView1.Rows[xy].Cells[5].Value))
                    {

                            dataGridView2.Rows.Add((xy + 1).ToString(), dataGridView1.Rows[xy].Cells[0].Value, dataGridView1.Rows[xy].Cells[1].Value, dataGridView1.Rows[xy].Cells[3].Value, dataGridView1.Rows[xy].Cells[4].Value, dataGridView1.Rows[xy].Cells[8].Value);
                        }
                    else
                    {
                        dataGridView2.Rows.Add((xy + 1).ToString(), dataGridView1.Rows[xy].Cells[0].Value, dataGridView1.Rows[xy].Cells[1].Value, dataGridView1.Rows[xy].Cells[3].Value, dataGridView1.Rows[xy].Cells[6].Value, dataGridView1.Rows[xy].Cells[8].Value);
                    }
                    
                    if (this.checkBox1.Checked)
                    {
                        this.button2_Click(sender, e);
                        this.listBox1.Items.Add("\nPayment Mode |" + mode.Text);
                        this.listBox1.Items.Add("\nTotal Amount |" + txtTotal.Text);
                        this.listBox1.Items.Add("\nDiscount |" + txtDiscount);
                        this.listBox1.Items.Add("\nNetpay |" + NetPay.Text);
                        this.listBox1.Items.Add("\nAmount Tendered |" + txtTendered.Text);
                        this.listBox1.Items.Add("\nChange Due |" + changeDue.Text);
                        this.listBox1.Items.Add("\nCashier |" + Program.user);

                    }
                    this.dataGridView1.Rows.Clear();
                    this.dataGridView2.Rows.Clear();
                    this.txtTotal.Text = "0.00";
                    this.txtDiscount.Text = "0.00";
                    this.txtTendered.Text = "0.00";
                    this.NetPay.Text = "0.00";
                    this.Value.Value = this.Value.Minimum;
                    this.percent.Value = this.percent.Minimum;
                    this.groupBox7.Enabled = false;
                    this.listBox1.Items.Clear();
                    this.changeDue.Text = "0.00";
                    this.recieptno.Text = "AUTO";
                    this.amtDue.Text = "0";
                } 
                    }

                    catch (Exception exception)
                    {
                        this.gclass.error(exception.Message.ToString());
                    }
        }

        private void cName_MouseClick(object sender, MouseEventArgs e)
        {
            this.cName.SelectAll();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            this.tab = e.KeyCode.ToString();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.txtTendered.Text = "0.00";
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                new Search_Product().ShowDialog();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.txtTendered.Focus();
                this.txtTendered.SelectAll();
            }
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.gclass.LoadCombo(this.comboBox1, "SELECT * FROM BANK", "name");
                if (this.mode.SelectedIndex == 0)
                {
                    this.refno.Visible = false;
                    this.txtRefno.Visible = false;
                    this.refno.Text = "Ref No";
                    this.panel5.Enabled = true;
                    this.label26.Visible = false;
                    this.comboBox1.Visible = false;
                }
                else if (this.mode.SelectedIndex == 1)
                {
                    this.refno.Visible = true;
                    this.txtRefno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.panel5.Enabled = true;
                }
                else if (this.mode.SelectedIndex == 2)
                {
                    this.refno.Visible = true;
                    this.txtRefno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.panel5.Enabled = true;
                }
                else if (this.mode.SelectedIndex == 3)
                {
                    this.refno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.txtRefno.Visible = true;
                    this.panel5.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void percent_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal num = Convert.ToDecimal(this.txtTendered.Text);
                this.txtDiscount.Text = $"{((Convert.ToDecimal(this.percent.Value) / 100M) * Convert.ToDecimal(this.txtTotal.Text)):N}".ToString();
                this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void percent_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = Convert.ToDecimal(this.txtTendered.Text);
                this.txtDiscount.Text = $"{((Convert.ToDecimal(this.percent.Value) / 100M) * Convert.ToDecimal(this.txtTotal.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 20, y = 20, i = 0;
            foreach (string str in listBox1.Items)
            {
                if (str == "Sales And Stock")
                {
                    e.Graphics.DrawString(str, myHead, Brushes.Black, x, y);
                }
                else
                {
                    e.Graphics.DrawString(str, myfont2, Brushes.Black, x, y);
                }
                y += 25;
                i++;
            }
            int num = 20;
            int num2 = 20;
            int num3 = 0;
            IEnumerator enumerator = this.listBox1.Items.GetEnumerator();
            try
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    string current = (string)enumerator.Current;
                    if (current == "FITMOY SUPERMARKET")
                    {
                        e.Graphics.DrawString(current, this.myHead, Brushes.Black, (float)num, (float)num2);
                    }
                    else
                    {
                        e.Graphics.DrawString(current, this.myfont2, Brushes.Black, (float)num, (float)num2);
                    }
                    num2 += 0x19;
                    num3++;
                }
            }
            finally
            {
                IDisposable objA = enumerator as IDisposable;
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            this.Value.Visible = true;
            this.percent.Visible = false;
            this.percent.Value = this.percent.Minimum;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.percent.Visible = true;
            this.Value.Visible = false;
            this.Value.Value = this.Value.Minimum;
        }

        private void Sales_Invoice_Activated(object sender, EventArgs e)
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
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.cp;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                        Search_Product.bcode = null;
                        Search_Product.code = null;
                        Search_Product.descptn = null;
                        Search_Product.cp = null;
                        Search_Product.pack_price = null;
                        Search_Product.sp = null;
                        Search_Product.stock = null;
                        Search_Product.lpc = null;
                        Search_Product.qtyin_pack = null;
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Sales_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.label18.Text = this.today.Value.ToString("yyyy/MM/dd");
                this.mode.SelectedIndex = 0;
                this.gclass.LoadCombo(this.cName, "SELECT * FROM customer_card", "full_name");
                this.cName.SelectedIndex = 0;
                //this.label5.Text = "AUTO";
                //this.label7.Text = "AUTO";
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

        private void txtDiscount_Click(object sender, EventArgs e)
        {

            this.txtDiscount.Text = "0.00";
            this.changeDue.Text = "0.00";
            this.groupBox7.Enabled = true;
            this.percent.Value = this.percent.Minimum;
            this.Value.Value = this.Value.Minimum;
        }

        private void txtDiscount_Enter(object sender, EventArgs e)
        {
            try
            {
                this.groupBox7.Enabled = true;
                this.Value.Maximum = Convert.ToDecimal(this.txtTotal.Text);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtDiscount.Text = $"{Convert.ToDecimal(this.txtDiscount.Text):N}";
                this.NetPay.Text = $"{Convert.ToDecimal(this.amtDue.Text):N}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.amtDue.Text = (Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text)).ToString();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtDiscount.Text = "0.00";
            }
        }

        private void txtTendered_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.SelectAll();
                this.groupBox7.Enabled = false;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtTendered_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTendered_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.txtTendered_Leave(sender, e);
                    this.button6_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtTendered_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.Text = $"{Convert.ToDecimal(this.txtTendered.Text):N}";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtTendered_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtTendered.SelectAll();
        }

        private void txtTendered_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.changeDue.Text = (Convert.ToDecimal(this.txtTendered.Text) - Convert.ToDecimal(this.amtDue.Text)).ToString();
                this.NetPay.Text = this.amtDue.Text;
            }
            catch (Exception)
            {
                this.txtTendered.Text = "0.00";
                this.changeDue.Text = "0.00";
                this.txtTendered.Focus();
                this.txtTendered.SelectAll();
            }
        }

        private void Value_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.txtDiscount.Text = this.Value.Value.ToString();
                this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Value_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal num = Convert.ToDecimal(this.txtTendered.Text);
                this.txtDiscount.Text = this.Value.Value.ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Sales_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.txtTendered.Text = "0.00";
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                button1.PerformClick();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search_Product dc = new Search_Product();
            dc.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView2.GridColor = Color.WhiteSmoke;
            DGVPrinter printer = new DGVPrinter();

            printer.Title = (Program.companyNameRcpt1.ToString());//Header;
            printer.SubTitle = (Program.companyAddressPos.ToString());
            printer.SubTitle += ("\nEmail: " + Program.companyEmail.ToString());
            printer.SubTitle += ("\nPhone: " + Program.companyPhone.ToString());
            printer.SubTitle += ("\nSALES INVOICE/RECEIPT");
            printer.SubTitle += ("\n                                ");
            //printer.SubTitleAlignment = StringAlignment.Far;
            //printer.SubTitleAlignment = StringAlignment.Near;
            printer.SubTitle += ("\nInvoice No: " + recieptno.Text + "  Date: " + this.today.Value.ToString("yyyy/MM/dd").ToString() + "  Time: " + label19.Text.ToString());
            printer.SubTitle += ("\nCustomer Name: " + cName.Text.ToUpper());
            printer.SubTitle += ("\nAddress: " + label5.Text);
            printer.SubTitle += ("\nTel No: " + label7.Text);
            //printer.SubTitle += ("\nEmail: ");
            printer.SubTitle += ("\n                            ");

            {

                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                

                printer.PrintMargins.Left = 10;
                printer.PrintMargins.Right = 10;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.FooterAlignment = StringAlignment.Far;
                printer.FooterAlignment = StringAlignment.Near;
                printer.Footer = ("\nPayment Mode |" + mode.Text);
                printer.Footer += ("\nTotal Amount |" + txtTotal.Text);
                printer.Footer += ("\nDiscount |" + txtDiscount.Text);
                printer.Footer += ("\nNetpay |" + NetPay.Text);
                printer.Footer += ("\nAmount Tendered |" + txtTendered.Text);
                printer.Footer += ("\nChange Due |" + changeDue.Text);
                printer.Footer += ("\nCashier |" + Program.user);
                printer.Footer += "\n";
                printer.Footer += DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                // printer.PageNumbers = true;
                printer.FooterSpacing = 0f;
                if (dataGridView2.Columns.Count > 7)
                {
                    printer.PageSettings.Landscape = true;
                }
                printer.PrintPreviewDataGridView(dataGridView2);

                //printer.SubTitle += ("\nPayment Mode |" + mode.Text);
                //printer.SubTitle += ("\nTotal Amount |" + txtTotal.Text);
                //printer.SubTitle += ("\nDiscount |" + txtDiscount);
                //printer.SubTitle += ("\nNetpay |" + NetPay.Text);
                //printer.SubTitle += ("\nAmount Tendered |" + txtTendered.Text);
                //printer.SubTitle += ("\nChange Due |" + changeDue.Text);
                //printer.SubTitle += ("\nCashier |" + Program.user);

                this.dataGridView2.Rows.Clear();


            }


        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal num = 0M;
                if ((this.dataGridView1.CurrentCell.ColumnIndex == 4) || (this.dataGridView1.CurrentCell.ColumnIndex == 6))
                {
                    decimal num2 = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    // decimal num4 = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[0x10].Value.ToString());
                    //decimal num5 = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[0x11].Value.ToString());
                    bool flag = (bool)this.dataGridView1.CurrentRow.Cells[5].Value;
                }
                int num6 = 0;
                while (true)
                {
                    if (num6 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        this.amtDue.Text = (num - Convert.ToDecimal(this.txtDiscount.Text)).ToString();
                        break;
                    }
                    decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[4].Value);
                    decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[3].Value);
                    decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[6].Value);
                    decimal num10 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[7].Value);
                    decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[11].Value);
                    decimal num12 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[10].Value);
                    decimal num22 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[14].Value);
                    //  decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[14].Value);
                    if (!((bool)this.dataGridView1.Rows[num6].Cells[5].Value))
                    {
                        this.dataGridView1.Rows[num6].Cells[14].Value = num8 * 1;
                        this.dataGridView1.Rows[num6].Cells[8].Value = num7 * num8;
                        this.dataGridView1.Rows[num6].Cells[12].Value = num8 * num7;
                        this.dataGridView1.Rows[num6].Cells[13].Value = num8 * num12;
                        //  this.dataGridView1.Rows[num6].Cells[11].Value = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[2].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[3].Value);
                        // this.dataGridView1.Rows[num6].Cells[13].Value = this.dataGridView1.Rows[num6].Cells[4].Value.ToString();
                        //this.dataGridView1.Rows[num6].Cells[12].Value = this.dataGridView1.Rows[num6].Cells[3].Value.ToString();
                    }

                    else
                    {
                        this.dataGridView1.Rows[num6].Cells[8].Value = num8 * num9;
                        //this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.cp;
                        this.dataGridView1.Rows[num6].Cells[7].Value = num8 * num11;
                        this.dataGridView1.Rows[num6].Cells[12].Value = num10 * num7;
                        this.dataGridView1.Rows[num6].Cells[13].Value = num10 * num12;
                        this.dataGridView1.Rows[num6].Cells[14].Value = num8 * num11;
                        // this.dataGridView1.Rows[num6].Cells[11].Value = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[2].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[7].Value);
                        // this.dataGridView1.Rows[num6].Cells[13].Value = this.dataGridView1.Rows[num6].Cells[6].Value.ToString();
                        //this.dataGridView1.Rows[num6].Cells[12].Value = this.dataGridView1.Rows[num6].Cells[7].Value;
                    }

                    // this.dataGridView1.Rows[num6].Cells[15].Value = num11 * Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[12].Value);
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[8].Value);
                    num6++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void cName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "datasource=SERVER;username = pos;password = 'pos'";
            //string constring = "datasource=localhost;username = root;password = 'ib'";
            string Query = "select * from bottle_sales_pos.customer_card where full_name ='" + cName.Text + "';";
            MySqlConnection ConDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string scName = myReader.GetString("full_name");
                    string sAddress = myReader.GetString("add1");
                    string sTel = myReader.GetString("phone");
                    cName.Text = scName;
                    label5.Text = sAddress;
                    label7.Text = sTel;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}

