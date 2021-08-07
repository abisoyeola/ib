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
using System.Drawing.Printing;
using System.Collections;
using System.IO;

namespace POS_SALES
{
    public partial class POS_Sales1 : Form
    {
        public static string identify = "5";
        private string wp_qty = null;
        private Font myfont2 = new Font("Courier New", 9f, FontStyle.Bold);
        private Font myfont7 = new Font("Courier New", 15f, FontStyle.Bold);
        private Font myfont3 = new Font("Courier New", 8.5f, FontStyle.Bold);
        private Font myHead = new Font("Courier New", 17f, FontStyle.Bold);
        private Font myHead7 = new Font("Courier New", 30f, FontStyle.Bold);
        private Font myHead2 = new Font("Courier New", 16f, FontStyle.Bold);
        private Font myHead3 = new Font("Courier New", 9f, FontStyle.Bold);
        private bool nonNumberEntered = false;
        private string key = "";
        private string tab = "";
        private string key2 = "";
        private General gclass = new General();
        public static string id = "";
        private string text;

        public POS_Sales1()
        {
            InitializeComponent();
        }
        Category cat;
        List<Category> categories = new List<Category>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            categories.Clear();
            int count = this.dataGridView1.Rows.Count;
            int num2 = 0;
            int num22 = 0;
            int num222 = 0;
            var counts = 0;
            while (true)
            {
                if (num2 >= count)
                {
                    this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                    this.dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView3.DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    this.dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                    this.dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView4.DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    this.dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                    int num4 = 0;
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 9f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "TOTAL";
                    this.dataGridView2.Rows[num4].Cells[1].Value = Convert.ToDecimal(this.total_can.Text);
                    this.dataGridView2.Rows[num4].Cells[2].Value = Convert.ToDecimal(this.total_bottle.Text);
                    this.dataGridView2.Rows[num4].Cells[4].Value = $"{Convert.ToDecimal(this.txtTotal.Text):N}";
                    this.dataGridView3.Rows.Add();
                    num4 = this.dataGridView3.Rows.Count - 1;
                    this.dataGridView3.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 9f, FontStyle.Bold);
                    this.dataGridView3.Rows[num4].Cells[0].Value = "TOTAL";
                    this.dataGridView3.Rows[num4].Cells[1].Value = Convert.ToDecimal(this.bal_qty_empty_purchase.Text);
                    this.dataGridView3.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(this.bottle_purchased.Text):N}";
                    this.dataGridView4.Rows.Add();
                    num4 = this.dataGridView4.Rows.Count - 1;
                    this.dataGridView4.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 9f, FontStyle.Bold);
                    this.dataGridView4.Rows[num4].Cells[0].Value = "TOTAL";
                    this.dataGridView4.Rows[num4].Cells[1].Value = Convert.ToDecimal(this.qty_empty_brought.Text);
                    this.dataGridView4.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(this.total_brought.Text):N}";

                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = ".";
                    this.dataGridView2.Rows[num4].Cells[1].Value = ".";
                    this.dataGridView2.Rows[num4].Cells[2].Value = ".";
                    this.dataGridView2.Rows[num4].Cells[3].Value = ".";
                    this.dataGridView2.Rows[num4].Cells[4].Value = ".";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Gross Amount: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = $"{Convert.ToDecimal(this.gross_amt.Text):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Less Discount: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = $"{Convert.ToDecimal(this.tot_discount.Text):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Net Pay: ";
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[4].Value = $"{Convert.ToDecimal(this.NetPay.Text):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Amount Tendered: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = $"{Convert.ToDecimal(this.txtTendered.Text):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Change Due: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = $"{Convert.ToDecimal(this.changeDue.Text):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Payment Mode: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = this.mode.Text;
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Cash Amount: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = this.cash_amt.Text;
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "POS Amount: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = this.pos_amt.Text;
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Transfer Amount: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = this.transfer_amt.Text;
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Cashier: ";
                    this.dataGridView2.Rows[num4].Cells[4].Value = Program.user.ToString();
                    
                    this.dataGridView2.Columns[0].Width = 100;
                    this.dataGridView2.Columns[1].Width = 40;
                    this.dataGridView2.Columns[2].Width = 50;
                    this.dataGridView2.Columns[3].Width = 100;

                    this.dataGridView2.Columns[0].Width = 82;
                    this.dataGridView2.Columns[1].Width = 30;
                    this.dataGridView2.Columns[2].Width = 30;
                    this.dataGridView2.Columns[3].Width = 60;
                    this.dataGridView2.Columns[4].Width = 90;

                    this.dataGridView3.Columns[0].Width = 110;
                    this.dataGridView3.Columns[1].Width = 30;
                    this.dataGridView3.Columns[2].Width = 60;
                    this.dataGridView3.Columns[3].Width = 90;

                    this.dataGridView4.Columns[0].Width = 110;
                    this.dataGridView4.Columns[1].Width = 30;
                    this.dataGridView4.Columns[4].Width = 60;
                    this.dataGridView4.Columns[5].Width = 90;
                    
                    DGVPrinter printer = new DGVPrinter
                    {
                        PrintMargins = {
                            Left = 0,
                            Right = 0,
                            Top = 5
                        },
                        SubTitleAlignment = StringAlignment.Center,
                        TitleAlignment = StringAlignment.Center,
                        TitleFont = new Font("Courier New", 10f),
                        SubTitleFont = new Font("Courier New", 6f),
                        PageNumberInHeader = false,
                        PorportionalColumns = true,
                        HeaderCellAlignment = StringAlignment.Center,
                        FooterSpacing = 0f,
                        PageSettings = { Landscape = false }
                    };
                    return;
                }
                this.dataGridView2.Rows.Add();
                int num3 = this.dataGridView2.Rows.Count - 1;
                int num7 = 0;
                decimal num19 = Convert.ToDecimal(this.dataGridView1.Rows[num7].Cells[19].Value);
                decimal num6 = Convert.ToDecimal(this.dataGridView1.Rows[num7].Cells[19].Value);

                //LIQUID PURCHASED
                if (this.dataGridView1.Rows[num3].Cells[17].Value.ToString() == "BOTTLE")
                    //if (!((bool)this.dataGridView1.Rows[num3].Cells[5].Value))
                {
                    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[1].Value;
                    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[18].Value;
                    this.dataGridView2.Rows[num3].Cells[2].Value = this.dataGridView1.Rows[num2].Cells[19].Value;
                    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[4].Value:N}";
                    this.dataGridView2.Rows[num3].Cells[4].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                    num2++;
                }

                else
                {
                    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[1].Value;
                    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[18].Value;
                    this.dataGridView2.Rows[num3].Cells[2].Value = this.dataGridView1.Rows[num2].Cells[19].Value;
                    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[4].Value:N}";
                    this.dataGridView2.Rows[num3].Cells[4].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                    num2++;
                }
                
                // EMPTY PURCHASED
                this.dataGridView3.Rows.Add();
                int num33 = this.dataGridView3.Rows.Count - 1;
                //Remove this condition from here 
                if (this.dataGridView1.Rows[num33].Cells[17].Value.ToString() == "BOTTLE") {
                    //if (!((bool)this.dataGridView1.Rows[num33].Cells[5].Value))
               //To here
                    cat  = new Category();
                    cat.Name = (string)this.dataGridView1.Rows[num22].Cells[22].Value;
                    cat.Count =Convert.ToInt32(this.dataGridView1.Rows[num22].Cells[28].Value);
                    cat.Price = Convert.ToDouble(this.dataGridView1.Rows[num22].Cells[6].Value);
                    cat.Amount = Convert.ToDouble(this.dataGridView1.Rows[num22].Cells[29].Value);

                    if (categories.Count == 0)
                    {
                        categories.Add(cat);
                    }
                    else
                    {
                        bool isExist = false;
                        foreach (var item in categories)
                        {
                            if (item.Name == cat.Name)
                            {
                                item.Count += cat.Count;
                                item.Amount += cat.Amount;
                                isExist = true;
                            }
                        }

                        if(!isExist)
                        {
                            categories.Add(cat);
                        }
                    }
                }// and this curly brace , then currect other errors.
                
                num22++;

                // EMPTY BROUGHT
                this.dataGridView4.Rows.Add();
                int num333 = this.dataGridView4.Rows.Count - 1;
                if (this.dataGridView1.Rows[num333].Cells[17].Value.ToString() == "BOTTLE")
                {
                    this.dataGridView4.Rows[num333].Cells[0].Value = this.dataGridView1.Rows[num222].Cells[22].Value;
                    this.dataGridView4.Rows[num333].Cells[1].Value = this.dataGridView1.Rows[num222].Cells[15].Value;
                    //this.dataGridView4.Rows[num333].Cells[2].Value = $"{this.dataGridView1.Rows[num222].Cells[6].Value:N}";
                    //this.dataGridView4.Rows[num333].Cells[3].Value = $"{this.dataGridView1.Rows[num222].Cells[21].Value:N}";
                    num222++;
                    
                }
               counts++;

                if (dataGridView1.Rows.Count == counts)
                {
                    foreach (var item in categories)
                    {
                        this.dataGridView3.Rows[num33].Cells[0].Value = item.Name; 
                        this.dataGridView3.Rows[num33].Cells[1].Value = item.Count;
                        this.dataGridView3.Rows[num33].Cells[2].Value = item.Price;
                        this.dataGridView3.Rows[num33].Cells[3].Value = item.Amount;
                        
                        
                    }
                }
              }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }



        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (Convert.ToDecimal(this.bal.Text) != 0M) || (Convert.ToDecimal(this.textBox2.Text) != 0M);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (Convert.ToDecimal(this.bal.Text) != 0M) || (Convert.ToDecimal(this.textBox2.Text) != 0M);
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            this.cName.SelectAll();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM customer_card WHERE full_name = '" + this.cName.Text + "'", this.gclass.conn()).ExecuteReader();
                if (reader.Read())
                {
                    this.bal.Text = reader.GetString("balance");
                    this.textBox2.Text = reader.GetString("balance_limit");
                    this.label16.Text = reader.GetString("customerid");
                }
                reader.Close();
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
                decimal numjj = 0M;
                decimal numjk = 0M;
                decimal numjl = 0M;
                decimal numjm = 0M;
                decimal numjn = 0M;
                decimal numjo = 0M;
                decimal numjp = 0M;
                decimal numjq = 0M;

                int num66 = 0;
                decimal num88 = Convert.ToDecimal(this.dataGridView1.Rows[num66].Cells[3].Value);
                decimal num566 = Convert.ToDecimal(this.dataGridView1.Rows[num66].Cells[8].Value);
                decimal num122 = Convert.ToDecimal(this.dataGridView1.Rows[num66].Cells[10].Value);
                this.dataGridView1.Rows[num66].Cells[23].Value = ((num566) - (num122 * num88));

                if ((this.dataGridView1.CurrentCell.ColumnIndex == 4) || (this.dataGridView1.CurrentCell.ColumnIndex == 6))
                {
                    decimal num2 = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    bool flag = (bool)this.dataGridView1.CurrentRow.Cells[5].Value;
                }
                int num6 = 0;
                while (true)
                {
                    if (num6 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        this.total_bought.Text = $"{numjj:N}";
                        this.total_brought.Text = $"{numjk:N}";
                        this.total_can.Text = numjl.ToString();
                        this.total_bottle.Text = numjm.ToString();
                        this.qty_empty_purchased.Text = numjn.ToString();
                        this.qty_empty_brought.Text = numjo.ToString();
                        this.tot_discount.Text = numjp.ToString();
                        this.bottle_purchased.Text = numjq.ToString();

                        this.amtDue.Text = ((num + Convert.ToDecimal(this.balance_bought.Text)) - Convert.ToDecimal(this.txtDiscount.Text)).ToString();
                        break;
                    }
                    decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[4].Value);
                    decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[3].Value);
                    decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[6].Value);
                    decimal num10 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[7].Value);
                    decimal num56 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[8].Value);
                    decimal num22 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[14].Value);
                    decimal num23 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[15].Value);
                    decimal num18 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[18].Value);
                    decimal num19 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[19].Value);
                    decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[11].Value);
                    decimal num12 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[10].Value);
                    decimal num25 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[25].Value);
                    decimal num26 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[26].Value);
                    decimal num27 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[27].Value);
                    decimal num28 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[28].Value);
                    decimal num24 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[24].Value);
                    if (num24 <= num8)
                    {
                        var dn = num25 * num8;
                        this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text) + Convert.ToDecimal(this.balance_bought.Text)):N}".ToString();
                        this.dataGridView1.Rows[num6].Cells[27].Value = $"{dn:N}".ToString();
                        this.dataGridView1.Rows[num6].Cells[26].Value = $"{(num56 - num27):N}".ToString();
                        this.dataGridView1.Rows[num6].Cells[23].Value = ((num26) - (num12 * num8));

                    }
                    else
                    {
                        this.dataGridView1.Rows[num6].Cells[26].Value = num7 * num8;
                        this.dataGridView1.Rows[num6].Cells[23].Value = ((num26) - (num12 * num8));
                        this.dataGridView1.Rows[num6].Cells[27].Value = 0.00;
                    }
                    if (this.dataGridView1.Rows[num6].Cells[17].Value.ToString()=="BOTTLE")
                    //if (!((bool)this.dataGridView1.Rows[num6].Cells[5].Value))
                    {
                        this.dataGridView1.Rows[num6].Cells[23].Value = ((num26) - (num12 * num8));
                        this.dataGridView1.Rows[num6].Cells[8].Value = num7 * num8;
                        this.dataGridView1.Rows[num6].Cells[18].Value = 0;
                        this.dataGridView1.Rows[num6].Cells[19].Value = num8 * 1;
                        this.dataGridView1.Rows[num6].Cells[20].Value = num19 * num9;
                        this.dataGridView1.Rows[num6].Cells[21].Value = num23 * num9;
                        this.dataGridView1.Rows[num6].Cells[28].Value = (num8 - num23);
                        this.dataGridView1.Rows[num6].Cells[29].Value = (num28 * num9);
                        this.dataGridView1.Rows[num6].Cells[7].Value = num8 * num11;
                        this.dataGridView1.Rows[num6].Cells[14].Value = num8 * num11;
                        this.dataGridView1.Rows[num6].Cells[12].Value = num10 * num7;
                        this.dataGridView1.Rows[num6].Cells[13].Value = num10 * num12;
                        //this.dataGridView1.Rows[num6].Cells[23].Value = ((num26) - (num12 * num8));
                    }
                 else
                    {
                        this.dataGridView1.Rows[num6].Cells[23].Value = ((num26) - (num12 * num8));
                        this.dataGridView1.Rows[num6].Cells[14].Value = num8 * 1;
                        this.dataGridView1.Rows[num6].Cells[8].Value = num7 * num8;
                        this.dataGridView1.Rows[num6].Cells[18].Value = 0;
                        this.dataGridView1.Rows[num6].Cells[12].Value = num8 * num7;
                        this.dataGridView1.Rows[num6].Cells[13].Value = num8 * num12;
                        this.dataGridView1.Rows[num6].Cells[18].Value = num8 * 1;
                        this.dataGridView1.Rows[num6].Cells[19].Value = 0;
                        //this.dataGridView1.Rows[num6].Cells[23].Value = ((num56) - (num12 * num8));
                        this.dataGridView1.Rows[num6].Cells[20].Value = 0;
                    }


                    num += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[8].Value);
                    numjj += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[20].Value);
                    numjk += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[21].Value);
                    numjl += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[18].Value);
                    numjm += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[19].Value);
                    numjn += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[19].Value);
                    numjo += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[15].Value);
                    numjp += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[27].Value);
                    numjq += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[29].Value);
                    num6++;

                }

            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int num6 = 0;
                //this.dataGridView1.Rows[num6].Cells[23].Value = ((num56) - (num12 * num8));
                this.dataGridView1_CellEndEdit(sender, e);
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
                if (e.ColumnIndex == 3)
                {
                    int num;
                    if (Convert.ToInt32(e.FormattedValue) < 0)
                    {
                        e.Cancel = true;
                        this.gclass.error("please enter numeric Value\n Format:80");
                    }
                    if (!int.TryParse(Convert.ToString(e.FormattedValue), out num))
                    {
                        e.Cancel = true;
                        this.gclass.error("please enter numeric Value\n Format:80");
                    }
                }
                int num6 = 0;
                decimal num23 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[15].Value);
                decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[3].Value);
                if (e.ColumnIndex == 15)
                {
                    int num;
                    if (Convert.ToInt32(e.FormattedValue) < 0)
                    {
                        e.Cancel = true;
                        this.gclass.error("please enter numeric Value\n Format:80");
                    }
                    if (!int.TryParse(Convert.ToString(e.FormattedValue), out num))
                    {
                        e.Cancel = true;
                        this.gclass.error("please enter numeric Value\n Format:80");
                    }
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
            if (this.tab == "Return")
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
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
            else if (e.KeyCode == Keys.F3)
            {
                this.textBox3.Clear();
                this.textBox3.Focus();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.txtTendered.Focus();
            }
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                decimal num = 0M;
                decimal numjj = 0M;
                decimal numjk = 0M;
                decimal numjl = 0M;
                decimal numjm = 0M;
                decimal numjn = 0M;
                decimal numjo = 0M;
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        this.total_bought.Text = $"{numjj:N}";
                        this.total_brought.Text = $"{numjk:N}";
                        this.total_can.Text = numjl.ToString();
                        this.total_bottle.Text = numjm.ToString();
                        this.qty_empty_purchased.Text = numjn.ToString();
                        this.qty_empty_brought.Text = numjo.ToString();
                        this.amtDue.Text = ((num + Convert.ToDecimal(this.balance_bought.Text)) - Convert.ToDecimal(this.txtDiscount.Text)).ToString();
                        this.txtTendered.Text = "0.00";
                        this.txtTotal.Text = "0.00";
                        break;
                    }
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                    decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[3].Value);
                    decimal num5 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[9].Value);
                    if (this.dataGridView1.Rows[num2].Cells[17].Value.ToString() == "BOTTLE")
                        //if (!((bool)this.dataGridView1.Rows[num2].Cells[5].Value))
                    {
                        this.dataGridView1.Rows[num2].Cells[7].Value = 1 * num5;
                        this.dataGridView1.Rows[num2].Cells[8].Value = num3 * num4;
                    }
                    else
                    {
                        this.dataGridView1.Rows[num2].Cells[8].Value = num3 * num4;
                    }
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[8].Value);
                    numjj += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[20].Value);
                    numjk += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[21].Value);
                    numjl += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[18].Value);
                    numjm += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[19].Value);
                    numjn += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[19].Value);
                    numjo += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[15].Value);
                    num2++;
                    this.balance_bought.Text = $"{(Convert.ToDecimal(this.total_bought.Text) - Convert.ToDecimal(this.total_brought.Text)):N}".ToString();
                    gross_amt.Text = $"{(Convert.ToDecimal(txtTotal.Text) + Convert.ToDecimal(balance_bought.Text)):N}".ToString();
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.gclass.LoadCombo(this.comboBox1, "SELECT * FROM BANK", "name");
                if (this.mode.SelectedIndex == 0)
                {
                    this.refno.Visible = false;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = false;
                    this.comboBox1.Visible = false;
                    this.txtRefno.Visible = false;
                    this.panel5.Enabled = false;
                    this.cashlbl.Visible = false;
                    this.cash_amt.Visible = false;
                    this.transferlbl.Visible = false;
                    this.transfer_amt.Visible = false;
                    this.poslbl.Visible = false;
                    this.pos_amt.Visible = false;
                    this.creditlbl.Visible = false;
                    this.credit_amt.Visible = false;
                }
                else if (this.mode.SelectedIndex == 1)
                {
                    this.refno.Visible = false;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = false;
                    this.comboBox1.Visible = false;
                    this.txtRefno.Visible = false;
                    this.panel5.Enabled = false;
                    this.cashlbl.Visible = true;
                    this.cash_amt.Visible = true;
                    this.transferlbl.Visible = false;
                    this.transfer_amt.Visible = false;
                    this.poslbl.Visible = false;
                    this.pos_amt.Visible = false;
                    this.creditlbl.Visible = false;
                    this.credit_amt.Visible = false;
                    this.cash_amt.Text = "0.00";
                    this.pos_amt.Text = "0.00";
                    this.transfer_amt.Text = "0.00";
                    this.credit_amt.Text = "0.00";
                }
                else if (this.mode.SelectedIndex == 2)
                {
                    this.refno.Visible = true;
                    this.txtRefno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.panel5.Enabled = true;
                    this.poslbl.Visible = true;
                    this.pos_amt.Visible = true;
                    this.transferlbl.Visible = false;
                    this.transfer_amt.Visible = false;
                    this.cashlbl.Visible = false;
                    this.cash_amt.Visible = false;
                    this.creditlbl.Visible = false;
                    this.credit_amt.Visible = false;
                    this.cash_amt.Text = "0.00";
                    this.pos_amt.Text = "0.00";
                    this.transfer_amt.Text = "0.00";
                    this.credit_amt.Text = "0.00";
                }
                else if (this.mode.SelectedIndex == 3)
                {
                    this.refno.Visible = true;
                    this.txtRefno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.panel5.Enabled = true;
                    this.transferlbl.Visible = true;
                    this.transfer_amt.Visible = true;
                    this.poslbl.Visible = false;
                    this.pos_amt.Visible = false;
                    this.cashlbl.Visible = false;
                    this.cash_amt.Visible = false;
                    this.creditlbl.Visible = false;
                    this.credit_amt.Visible = false;
                    this.cash_amt.Text = "0.00";
                    this.pos_amt.Text = "0.00";
                    this.transfer_amt.Text = "0.00";
                    this.credit_amt.Text = "0.00";
                }
                else if (this.mode.SelectedIndex == 4)
                {
                    this.refno.Visible = false;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = false;
                    this.comboBox1.Visible = false;
                    this.txtRefno.Visible = false;
                    this.panel5.Enabled = false;
                    this.creditlbl.Visible = true;
                    this.credit_amt.Visible = true;
                    this.cashlbl.Visible = false;
                    this.cash_amt.Visible = false;
                    this.transferlbl.Visible = false;
                    this.transfer_amt.Visible = false;
                    this.poslbl.Visible = false;
                    this.pos_amt.Visible = false;
                    this.cash_amt.Text = "0.00";
                    this.pos_amt.Text = "0.00";
                    this.transfer_amt.Text = "0.00";
                    this.credit_amt.Text = "0.00";
                }
                else if (this.mode.SelectedIndex == 5)
                {
                    this.refno.Visible = true;
                    this.txtRefno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.panel5.Enabled = true;
                    this.cashlbl.Visible = true;
                    this.cash_amt.Visible = true;
                    this.poslbl.Visible = true;
                    this.pos_amt.Visible = true;
                    this.creditlbl.Visible = false;
                    this.credit_amt.Visible = false;
                    this.transferlbl.Visible = false;
                    this.transfer_amt.Visible = false;
                    this.cash_amt.Text = "0.00";
                    this.pos_amt.Text = "0.00";
                    this.transfer_amt.Text = "0.00";
                    this.credit_amt.Text = "0.00";

                }
                else if (this.mode.SelectedIndex == 6)
                {
                    this.refno.Visible = true;
                    this.txtRefno.Visible = true;
                    this.refno.Text = "Ref No";
                    this.label26.Visible = true;
                    this.comboBox1.Visible = true;
                    this.panel5.Enabled = true;
                    this.cashlbl.Visible = true;
                    this.cash_amt.Visible = true;
                    this.transferlbl.Visible = true;
                    this.transfer_amt.Visible = true;
                    this.creditlbl.Visible = false;
                    this.credit_amt.Visible = false;
                    this.poslbl.Visible = false;
                    this.pos_amt.Visible = false;
                    this.cash_amt.Text = "0.00";
                    this.pos_amt.Text = "0.00";
                    this.transfer_amt.Text = "0.00";
                    this.credit_amt.Text = "0.00";
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
                this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text) + Convert.ToDecimal(this.balance_bought.Text)):N}".ToString();
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

        private void POS_Sales_Activated(object sender, EventArgs e)
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

                    if (qty_sold1 > fifo_order1)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp2;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    else if (qty_sold2 > fifo_order2)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp3;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    else if (qty_sold3 > fifo_order3)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp1;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    else if (qty_sold1 == fifo_order1)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp2;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    if (qty_sold2 == fifo_order2)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp3;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    if (qty_sold3 == fifo_order3)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp1;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    if (qty_sold1 < fifo_order1)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp1;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    else if (qty_sold2 < fifo_order2)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp2;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    else if (qty_sold3 < fifo_order3)
                    {
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product.stock_empty;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.sp;
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.pack_price;
                        this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product.qtyin_pack;
                        this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product.fifo_cp3;
                        this.dataGridView1.Rows[num3].Cells[15].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[17].Value = Search_Product.cont;
                        this.dataGridView1.Rows[num3].Cells[18].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[19].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[20].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[21].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[22].Value = Search_Product.cat;
                        this.dataGridView1.Rows[num3].Cells[23].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[24].Value = Search_Product.minimum_qty;
                        this.dataGridView1.Rows[num3].Cells[25].Value = Search_Product.discount;
                        this.dataGridView1.Rows[num3].Cells[26].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[28].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[29].Value = "0";
                        this.dataGridView1.Rows[num3].Cells[30].Value = Search_Product.fifo_order1;
                        this.dataGridView1.Rows[num3].Cells[31].Value = Search_Product.qty_sold1;
                        this.dataGridView1.Rows[num3].Cells[32].Value = Search_Product.qty_sold_projection;
                        this.dataGridView1.Rows[num3].Cells[33].Value = Search_Product.ncp;
                        this.dataGridView1.Rows[num3].Cells[34].Value = Search_Product.fifo_order2;
                        this.dataGridView1.Rows[num3].Cells[35].Value = Search_Product.qty_sold2;
                        this.dataGridView1.Rows[num3].Cells[36].Value = Search_Product.fifo_order3;
                        this.dataGridView1.Rows[num3].Cells[37].Value = Search_Product.qty_sold3;
                        this.dataGridView1.Rows[num3].Cells[38].Value = Search_Product.fifo_order4;
                        this.dataGridView1.Rows[num3].Cells[39].Value = Search_Product.qty_sold4;
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                }
            }
        }
        private string printDataGridView(object sender, PrintPageEventArgs e, int y)
        {
            DGVPrinter printer = new DGVPrinter
            {
                RowHeight = DGVPrinter.RowHeightSetting.CellHeight
            };
            printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
            printer.PrintMargins.Left = 0;
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Courier New", 10f);
            printer.SubTitleFont = new Font("Courier New", 6f);
            printer.PrintMargins.Right = 0;
            printer.PrintMargins.Top = 0;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            e.HasMorePages = printer.EmbeddedPrint(this.dataGridView4, e.Graphics, new Rectangle(5, y, 0x12e, 0x186a0));
            return "";
        }
        private string printDataGridView2(object sender, PrintPageEventArgs e, int y)
        {
            DGVPrinter printer = new DGVPrinter
            {
                RowHeight = DGVPrinter.RowHeightSetting.CellHeight
            };
            printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
            printer.PrintMargins.Left = 0;
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Courier New", 10f);
            printer.SubTitleFont = new Font("Courier New", 6f);
            printer.PrintMargins.Right = 0;
            printer.PrintMargins.Top = 0;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            y = ((this.dataGridView4.RowTemplate.Height * this.dataGridView4.Rows.Count) + y) - 20;
            e.HasMorePages = printer.EmbeddedPrint(this.dataGridView3, e.Graphics, new Rectangle(5, y+35, 0x12e, 0x186a0));
            return "";
        }
        
        private string printDataGridView1(object sender, PrintPageEventArgs e, int z)
        {
            DGVPrinter printer = new DGVPrinter
            {
                RowHeight = DGVPrinter.RowHeightSetting.CellHeight
            };
            printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
            printer.PrintMargins.Left = 0;
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Courier New", 10f);
            printer.SubTitleFont = new Font("Courier New", 6f);
            printer.PrintMargins.Right = 0;
            printer.PrintMargins.Top = 0;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            z = ((this.dataGridView3.RowTemplate.Height * this.dataGridView3.Rows.Count) + z) - 20;
            e.HasMorePages = printer.EmbeddedPrint(this.dataGridView2, e.Graphics, new Rectangle(5, z+160, 0x12e, 0x186a0));
            return "";
        }
        //private string printDataGridView3(object sender, PrintPageEventArgs e, int z)
        //{
        //    DGVPrinter printer = new DGVPrinter
        //    {
        //        RowHeight = DGVPrinter.RowHeightSetting.CellHeight
        //    };
        //    printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
        //    printer.PrintMargins.Left = 0;
        //    printer.SubTitleAlignment = StringAlignment.Center;
        //    printer.TitleAlignment = StringAlignment.Center;
        //    printer.TitleFont = new Font("Courier New", 10f);
        //    printer.SubTitleFont = new Font("Courier New", 6f);
        //    printer.PrintMargins.Right = 0;
        //    printer.PrintMargins.Top = 0;
        //    printer.PageNumberInHeader = false;
        //    printer.PorportionalColumns = true;
        //    z = ((this.dataGridView2.RowTemplate.Height * this.dataGridView2.Rows.Count) + z) - 20;
        //    e.HasMorePages = printer.EmbeddedPrint(this.dataGridView7, e.Graphics, new Rectangle(5, z, 0x12e, 0x186a0));
        //    return "";
        //}
        private void POS_Sales_Load(object sender, EventArgs e)
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
                this.dataGridView1.Rows.Clear();
                this.gclass.LoadCombo(this.cName, "SELECT * FROM customer_card", "full_name");
                this.cName.SelectedIndex = 0;
                this.timer1.Start();
                base.KeyUp += new KeyEventHandler(this.KeyEvent);
                this.KeyPreview = true;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int num = 2;
            int y = 20;
            int z = 160;
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
                    if (current == Program.companyNameRcpt1)
                    {
                        e.Graphics.DrawString(current, this.myHead, Brushes.Black, 15f, (float)y);
                    }
                    else if (current == Program.companyNameRcpt2)
                    {
                        e.Graphics.DrawString(current, this.myHead2, Brushes.Black, 15f, (float)y);
                    }
                    else if (current == Program.companyAddressPos)
                    {
                        e.Graphics.DrawString(current, this.myHead3, Brushes.Black, 0.5f, (float)y);
                    }
                    else
                    {
                        e.Graphics.DrawString(current, this.myfont2, Brushes.Black, (float)num, (float)y);
                    }
                    y += 0x19;
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
            this.printDataGridView1(sender, e, y);
            this.printDataGridView2(sender, e, y);
            this.printDataGridView(sender, e, y);
            //this.printDataGridView3(sender, e, y);
            y = ((this.dataGridView2.RowTemplate.Height * this.dataGridView2.Rows.Count) + y) - 20;
            //e.Graphics.DrawString("Thank You for your patronage.\nNote:Goods bought are not returnable", this.myfont3, Brushes.Black, (float)num, (float)z + 40);
            // STILL WORKING ON IT
            //y = ((this.dataGridView2.RowTemplate.Height * this.dataGridView2.Rows.Count) + y) - 20;
            //e.Graphics.DrawString("\nPlease check your goods.Goods taken\nout of the premises are not returnable.\nWe thank you for your patronage.", this.myfont3, Brushes.Black, (float)num, (float)y);
            if (Program.msg1 == "")
            {
                //e.Graphics.DrawString("\nPlease check your goods.Goods taken\nout of the premises are not returnable.", this.myfont3, Brushes.Black, (float)num, (float)(y + 180));
                //e.Graphics.DrawString("\nWe thank you for your patronage.", this.myfont3, Brushes.Black, (float)num, (float)(y + 210));
                //e.Graphics.DrawString("\nPlease check your goods.Goods taken\nout of the premises are not returnable.\nWe thank you for your patronage.", this.myfont3, Brushes.Black, (float)num, (float)(y + 200));
                e.Graphics.DrawString(" ", this.myfont3, Brushes.Black, (float)num, (float)(y + 60));
            }
            else
            {
                e.Graphics.DrawString(Program.msg1 + "\n" + Program.msg2, this.myfont3, Brushes.Black, (float)num, (float)(y + 30));

                e.Graphics.DrawString(" ", this.myfont3, Brushes.Black, (float)num, (float)(y + 90));
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int num = 2;
            int y = 20;
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
                    if (current == Program.companyNameRcpt1)
                    {
                        e.Graphics.DrawString(current, this.myHead, Brushes.Black, 15f, (float)y);
                    }
                    else if (current == Program.companyNameRcpt2)
                    {
                        e.Graphics.DrawString(current, this.myHead2, Brushes.Black, 15f, (float)y);
                    }
                    else if (current == Program.companyAddressPos)
                    {
                        e.Graphics.DrawString(current, this.myHead3, Brushes.Black, 0.5f, (float)y);
                    }
                    else
                    {
                        e.Graphics.DrawString(current, this.myfont2, Brushes.Black, (float)num, (float)y);
                    }
                    y += 0x19;
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
            this.printDataGridView(sender, e, y);
            y = ((this.dataGridView2.RowTemplate.Height * this.dataGridView2.Rows.Count) + y) - 20;
            e.Graphics.DrawString("Thank You for your patronage.\nNote:Goods bought are not returnable", this.myfont3, Brushes.Black, (float)num, (float)y);
            if (Program.msg1 == "")
            {

                e.Graphics.DrawString(Program.companyNameRcpt1.ToString() + "\nCOPY", this.myHead2, Brushes.Black, (float)num, (float)(y + 60));
                e.Graphics.DrawString(" ", this.myfont3, Brushes.Black, (float)num, (float)(y + 90));
            }
            else
            {
                e.Graphics.DrawString(Program.msg1 + "\n" + Program.msg2, this.myfont3, Brushes.Black, (float)num, (float)(y + 30));

                e.Graphics.DrawString(Program.companyNameRcpt1.ToString() + "\nCOPY", this.myHead2, Brushes.Black, (float)num, (float)(y + 60));
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            this.key2 = e.KeyCode.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((this.key2 == "Return") && !string.IsNullOrWhiteSpace(this.textBox3.Text))
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
                            if (this.textBox3.Text != this.dataGridView1.Rows[num2].Cells[0].Value.ToString())
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
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM product WHERE barcode = '" + this.textBox3.Text + "'", this.gclass.conn()).ExecuteReader();
                    if (!reader.Read())
                    {
                        this.gclass.error("Product Not Found...");
                        reader.Close();
                    }
                    else
                    {
                        this.dataGridView1.Rows.Add();
                        int num3 = this.dataGridView1.Rows.Count - 1;
                        this.dataGridView1.Rows[num3].Cells[0].Value = reader.GetString("code");
                        this.dataGridView1.Rows[num3].Cells[1].Value = reader.GetString("description");
                        this.dataGridView1.Rows[num3].Cells[2].Value = reader.GetString("stk");
                        this.dataGridView1.Rows[num3].Cells[15].Value = reader.GetString("stk_empty");
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = reader.GetString("s_p");
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = reader.GetString("ws");
                        this.dataGridView1.Rows[num3].Cells[10].Value = reader.GetString("cp");
                        this.dataGridView1.Rows[num3].Cells[11].Value = reader.GetString("wp_qty");
                        this.dataGridView1.Rows[num3].Cells[16].Value = reader.GetString("container");
                        this.dataGridView1.Rows[num3].Cells[22].Value = reader.GetString("dept");
                        this.dataGridView1.Rows[num3].Cells[24].Value = reader.GetString("minimum_qty");
                        this.dataGridView1.Rows[num3].Cells[25].Value = reader.GetString("discount");
                        this.dataGridView1.Rows[num3].Cells[36].Value = reader.GetString("purchase_supplier");
                        this.dataGridView1.Rows[num3].Cells[37].Value = reader.GetString("post5");
                        this.dataGridView1.Rows[num3].Cells[38].Value = reader.GetString("post7");
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    reader.Close();
                }
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
            this.txtTendered.Text = "0.00";
            this.NetPay.Text = "0.00";
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
                this.amtDue.Text = (Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text) + Convert.ToDecimal(this.balance_bought.Text)).ToString();
                this.NetPay.Text = this.amtDue.Text;
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.txtDiscount.Text = "0.00";
            }
        }

        private void txtTendered_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.SelectAll();
                this.groupBox7.Enabled = false;
                this.txtTendered_TextChanged(sender, e);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtTendered_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.SelectAll();
                this.groupBox7.Enabled = false;
                this.txtTendered_TextChanged(sender, e);
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
                    this.button3_Click(sender, e);
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
                this.balance_bought.Text = $"{(Convert.ToDecimal(this.total_bought.Text) - Convert.ToDecimal(this.total_brought.Text)):N}".ToString();
                gross_amt.Text = $"{(Convert.ToDecimal(txtTotal.Text) + Convert.ToDecimal(balance_bought.Text)):N}".ToString();
                balance_control.Text = (Convert.ToDecimal(qty_empty_purchased.Text) - Convert.ToDecimal(qty_empty_brought.Text)).ToString();
                control.Text = (Convert.ToDecimal(qty_empty_purchased.Text) - Convert.ToDecimal(qty_empty_brought.Text) - Convert.ToDecimal(balance_control.Text)).ToString();
                bal_qty_empty_purchase.Text = (Convert.ToDecimal(qty_empty_purchased.Text) - Convert.ToDecimal(qty_empty_brought.Text)).ToString();
                this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) + Convert.ToDecimal(this.balance_bought.Text) - Convert.ToDecimal(this.tot_discount.Text)):N}".ToString();
                this.changeDue.Text = $"{Convert.ToDecimal(this.txtTendered.Text) - Convert.ToDecimal(this.amtDue.Text):N}";
                this.amtDue.Text = this.NetPay.Text;
            }
            catch (Exception)
            {
                this.txtTendered.Text = "0.00";
                this.txtTendered.Focus();
                this.txtTendered.SelectAll();
            }
        }

        private void Value_ValueChanged_1(object sender, EventArgs e)
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

        private void Value_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                this.txtDiscount.Text = this.Value.Value.ToString();
                this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text) + Convert.ToDecimal(this.balance_bought.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Search_Product dc = new Search_Product();
            dc.ShowDialog();
        }

        private void POS_Sales_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void POS_Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.txtTendered.Text = "0.00";
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                button2.PerformClick();

            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((this.key2 == "Return") && !string.IsNullOrWhiteSpace(this.textBox3.Text))
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
                            if (this.textBox3.Text != this.dataGridView1.Rows[num2].Cells[0].Value.ToString())
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
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM product WHERE barcode = '" + this.textBox3.Text + "'", this.gclass.conn()).ExecuteReader();
                    if (!reader.Read())
                    {
                        this.gclass.error("Product Not Found...");
                        reader.Close();
                    }
                    else
                    {
                        this.dataGridView1.Rows.Add();
                        int num3 = this.dataGridView1.Rows.Count - 1;
                        this.dataGridView1.Rows[num3].Cells[0].Value = reader.GetString("code");
                        this.dataGridView1.Rows[num3].Cells[1].Value = reader.GetString("description");
                        this.dataGridView1.Rows[num3].Cells[2].Value = reader.GetString("stk");
                        this.dataGridView1.Rows[num3].Cells[15].Value = reader.GetString("stk_empty");
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = reader.GetString("s_p");
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = reader.GetString("ws");
                        this.dataGridView1.Rows[num3].Cells[10].Value = reader.GetString("cp");
                        this.dataGridView1.Rows[num3].Cells[11].Value = reader.GetString("wp_qty");
                        this.dataGridView1.Rows[num3].Cells[16].Value = reader.GetString("container");
                        this.dataGridView1.Rows[num3].Cells[22].Value = reader.GetString("dept");
                        this.dataGridView1.Rows[num3].Cells[24].Value = reader.GetString("minimum_qty");
                        this.dataGridView1.Rows[num3].Cells[25].Value = reader.GetString("discount");
                        this.dataGridView1.Rows[num3].Cells[36].Value = reader.GetString("purchase_supplier");
                        this.dataGridView1.Rows[num3].Cells[37].Value = reader.GetString("post5");
                        this.dataGridView1.Rows[num3].Cells[38].Value = reader.GetString("post7");
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    }
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            this.key2 = e.KeyCode.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.listBox3.Items.Add(Program.companyNameRcpt1.ToString());
            this.listBox3.Items.Add("\nReceipt Printer Ok !!! ");
            this.printDocument5.Print();
        }

        private void printDocument5_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = 20, y = 20, i = 0;
            foreach (string str in listBox3.Items)
            {
                if (str == "POS")
                {
                    e.Graphics.DrawString(str, myHead7, Brushes.Black, x, y);
                }
                else
                {
                    e.Graphics.DrawString(str, myfont7, Brushes.Black, x, y);
                }
                y += 25;
                i++;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void printDocument6_PrintPage(object sender, PrintPageEventArgs e)
        {
            int num = 2;
            int y = 20;
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
                    if (current == Program.companyNameRcpt1)
                    {
                        e.Graphics.DrawString(current, this.myHead, Brushes.Black, 15f, (float)y);
                    }
                    else if (current == Program.companyNameRcpt2)
                    {
                        e.Graphics.DrawString(current, this.myHead2, Brushes.Black, 15f, (float)y);
                    }
                    else if (current == Program.companyAddressPos)
                    {
                        e.Graphics.DrawString(current, this.myHead3, Brushes.Black, 0.5f, (float)y);
                    }
                    else
                    {
                        e.Graphics.DrawString(current, this.myfont2, Brushes.Black, (float)num, (float)y);
                    }
                    y += 0x19;
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
            this.printDataGridView(sender, e, y);
            y = ((this.dataGridView3.RowTemplate.Height * this.dataGridView3.Rows.Count) + y) - 20;
            e.Graphics.DrawString("Thank You for your patronage.\nNote:Goods bought are not returnable", this.myfont3, Brushes.Black, (float)num, (float)y);
            if (Program.msg1 == "")
            {

                e.Graphics.DrawString(Program.companyNameRcpt1.ToString() + "\nCOPY", this.myHead2, Brushes.Black, (float)num, (float)(y + 60));
                e.Graphics.DrawString(" ", this.myfont3, Brushes.Black, (float)num, (float)(y + 90));
            }
            else
            {
                e.Graphics.DrawString(Program.msg1 + "\n" + Program.msg2, this.myfont3, Brushes.Black, (float)num, (float)(y + 30));

                e.Graphics.DrawString(Program.companyNameRcpt1.ToString() + "\nCOPY", this.myHead2, Brushes.Black, (float)num, (float)(y + 60));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void transfer_amt_TextChanged(object sender, EventArgs e)
        {
            this.txtTendered.Text = $"{(Convert.ToDecimal(this.cash_amt.Text) + Convert.ToDecimal(this.pos_amt.Text) + Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();
        }

        private void cash_amt_TextChanged(object sender, EventArgs e)
        {
            this.txtTendered.Text = $"{(Convert.ToDecimal(this.cash_amt.Text) + Convert.ToDecimal(this.pos_amt.Text) + Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();
        }

        private void pos_amt_TextChanged(object sender, EventArgs e)
        {
            this.txtTendered.Text = $"{(Convert.ToDecimal(this.cash_amt.Text) + Convert.ToDecimal(this.pos_amt.Text) + Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();
        }

        private void credit_amt_TextChanged(object sender, EventArgs e)
        {
            this.txtTendered.Text = $"{(Convert.ToDecimal(this.credit_amt.Text)):N}".ToString();
        }

        private void credit_amt_KeyDown(object sender, KeyEventArgs e)
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

        private void credit_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.credit_amt_Leave(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void credit_amt_Leave(object sender, EventArgs e)
        {
            this.credit_amt.Text = $"{Convert.ToDecimal(this.credit_amt.Text):N}";
        }

        private void transfer_amt_Leave(object sender, EventArgs e)
        {
            this.transfer_amt.Text = $"{Convert.ToDecimal(this.transfer_amt.Text):N}";
        }

        private void cash_amt_Leave(object sender, EventArgs e)
        {
            this.cash_amt.Text = $"{Convert.ToDecimal(this.cash_amt.Text):N}";
        }

        private void pos_amt_Leave(object sender, EventArgs e)
        {
            this.pos_amt.Text = $"{Convert.ToDecimal(this.pos_amt.Text):N}";
        }

        private void transfer_amt_KeyDown(object sender, KeyEventArgs e)
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

        private void transfer_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.transfer_amt_Leave(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void cash_amt_KeyDown(object sender, KeyEventArgs e)
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

        private void cash_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.cash_amt_Leave(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void pos_amt_KeyDown(object sender, KeyEventArgs e)
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

        private void pos_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
                if (this.key == "Return")
                {
                    this.pos_amt_Leave(sender, e);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void cash_amt_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.Text = $"{(Convert.ToDecimal(this.cash_amt.Text) + Convert.ToDecimal(this.pos_amt.Text) + Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
            
        }

        private void pos_amt_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.Text = $"{(Convert.ToDecimal(this.cash_amt.Text) + Convert.ToDecimal(this.pos_amt.Text) + Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
            
        }

        private void transfer_amt_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.Text = $"{(Convert.ToDecimal(this.cash_amt.Text) + Convert.ToDecimal(this.pos_amt.Text) + Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
            
        }

        private void credit_amt_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.txtTendered.Text = $"{(Convert.ToDecimal(this.credit_amt.Text)):N}".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
        }

        private void cash_amt_Leave_1(object sender, EventArgs e)
        {
            try
            {
                this.cash_amt.Text = $"{(Convert.ToDecimal(this.cash_amt.Text)):N}".ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
        }

        private void pos_amt_Leave_1(object sender, EventArgs e)
        {
            try
            {
                this.pos_amt.Text = $"{(Convert.ToDecimal(this.pos_amt.Text)):N}".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
        }

        private void transfer_amt_Leave_1(object sender, EventArgs e)
        {
            try
            {
                this.transfer_amt.Text = $"{(Convert.ToDecimal(this.transfer_amt.Text)):N}".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
        }

        private void credit_amt_Leave_1(object sender, EventArgs e)
        {
            try
            {
                this.credit_amt.Text = $"{(Convert.ToDecimal(this.credit_amt.Text)):N}".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Input Figures");
            }
        }
    }
}
