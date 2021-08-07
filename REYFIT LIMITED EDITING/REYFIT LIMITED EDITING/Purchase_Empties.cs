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
    public partial class Purchase_Empties : Form
    {
        public static string identify = "28";
        private string wp_qty = null;
        private Font myfont2 = new Font("Courier New", 9f, FontStyle.Bold);
        private Font myfont7 = new Font("Courier New", 15f, FontStyle.Bold);
        private Font myfont3 = new Font("Courier New", 9f, FontStyle.Bold);
        private Font myHead = new Font("Courier New", 14f, FontStyle.Bold);
        private Font myHead7 = new Font("Courier New", 30f, FontStyle.Bold);
        private Font myHead2 = new Font("Courier New", 16f, FontStyle.Bold);
        private Font myHead3 = new Font("Courier New", 10f, FontStyle.Bold);
        private bool nonNumberEntered = false;
        private string key = "";
        private string tab = "";
        private string key2 = "";
        private General gclass = new General();
        //Class1 ib = new Class1();
        public static string id = "";
        // private string[] strArray;

        public Purchase_Empties()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = this.dataGridView1.Rows.Count;
            int num2 = 0;
         //   int i = this.dataGridView1.Rows.Count; 
            while (true)
            {
                if (num2 >= count)
                {
                    this.dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                    int num4 = 0;
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Total Amount: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(this.txtTotal.Text):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Cashier: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = Program.user.ToString();
                    this.dataGridView2.Columns[0].Width = 100;
                    this.dataGridView2.Columns[1].Width = 40;
                    this.dataGridView2.Columns[2].Width = 50;
                    this.dataGridView2.Columns[3].Width = 100;
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
                //this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[1].Value;
                //this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[3].Value;
                //this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView1.Rows[num2].Cells[4].Value:N}";
                //this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                //num2++;

                if (!((bool)this.dataGridView1.Rows[num3].Cells[5].Value))
                {
                    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[1].Value;
                    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[3].Value;
                    this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView1.Rows[num2].Cells[4].Value:N}";
                    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                    num2++;
                }

                else
                {
                    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[1].Value;
                    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[3].Value;
                    this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView1.Rows[num2].Cells[6].Value:N}";
                    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                    num2++;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

    

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (Convert.ToDecimal(this.textBox1.Text) != 0M) || (Convert.ToDecimal(this.textBox2.Text) != 0M);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (Convert.ToDecimal(this.textBox1.Text) != 0M) || (Convert.ToDecimal(this.textBox2.Text) != 0M);
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
                    this.textBox1.Text = reader.GetString("balance");
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
                    decimal num22 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[14].Value);
                    decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[11].Value);
                    decimal num12 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[10].Value);
                   
                    //  decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[14].Value);
                    if (!((bool)this.dataGridView1.Rows[num6].Cells[5].Value))
                    {
                        this.dataGridView1.Rows[num6].Cells[14].Value = num8 * 1;
                        //this.dataGridView1.Rows[num6].Cells[14].Value = num8 * num7;
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
                        this.dataGridView1.Rows[num6].Cells[8].Value = num8 * num9;
                        //this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product_Empty.cp;
                        this.dataGridView1.Rows[num6].Cells[7].Value = num8 * num11;
                        this.dataGridView1.Rows[num6].Cells[14].Value = num8 * 1;
                        this.dataGridView1.Rows[num6].Cells[12].Value = num10 * num7;
                        this.dataGridView1.Rows[num6].Cells[13].Value = num10 * num12;
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

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
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
                new Search_Product_Empty().ShowDialog();
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
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        this.amtDue.Text = (num - Convert.ToDecimal(this.txtDiscount.Text)).ToString();
                        this.txtTendered.Text = "0.00";
                        break;
                    }
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                    decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[3].Value);
                    decimal num5 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[9].Value);
                    //decimal num15 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[7].Value);
                    if (!((bool)this.dataGridView1.Rows[num2].Cells[5].Value))
                    {
                        this.dataGridView1.Rows[num2].Cells[8].Value = num3 * num4;
                    }
                    else
                    {
                        this.dataGridView1.Rows[num2].Cells[7].Value = num4 * num5;
                        //this.dataGridView1.Rows[num2].Cells[12].Value = num15 * num4;
                        this.dataGridView1.Rows[num2].Cells[8].Value = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[6].Value) * num4;
                    }
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[8].Value);
                    num2++;
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

        private void POS_Sales_Activated(object sender, EventArgs e)
        {
            if (this.label3.Text == "0")
            {
                this.label3.Text = "label3";
                if (!string.IsNullOrWhiteSpace(Search_Product_Empty.descptn))
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
                            if (Search_Product_Empty.code != this.dataGridView1.Rows[num2].Cells[0].Value.ToString())
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
                    this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product_Empty.code;
                    this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product_Empty.descptn;
                    this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product_Empty.stock_empty;
                    this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                    this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product_Empty.sp;
                    this.dataGridView1.Rows[num3].Cells[5].Value = false;
                    this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product_Empty.pack_price;
                    this.dataGridView1.Rows[num3].Cells[11].Value = Search_Product_Empty.qtyin_pack;
                    this.dataGridView1.Rows[num3].Cells[8].Value = "0";
                    this.dataGridView1.Rows[num3].Cells[10].Value = Search_Product_Empty.cp;
                    this.dataGridView1.Rows[num3].Cells[15].Value = Search_Product_Empty.post8;
                    this.dataGridView1.Rows[num3].Cells[16].Value = Search_Product_Empty.dept;
                    this.dataGridView1.Focus();
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                    Search_Product_Empty.bcode = null;
                    Search_Product_Empty.post8 = null;
                    Search_Product_Empty.dept = null;
                    Search_Product_Empty.code = null;
                    Search_Product_Empty.descptn = null;
                    Search_Product_Empty.cp = null;
                    Search_Product_Empty.pack_price = null;
                    Search_Product_Empty.sp = null;
                    Search_Product_Empty.stock_empty = null;
                    Search_Product_Empty.lpc = null;
                    Search_Product_Empty.qtyin_pack = null;
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
            e.HasMorePages = printer.EmbeddedPrint(this.dataGridView2, e.Graphics, new Rectangle(5, y, 0x12e, 0x186a0));
            return "";
        }
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
            int num3 = 0;
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            Bitmap resized = new Bitmap(myBitmap1, new Size(50, 50));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
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
            if (Program.msg1 == "")
            {
               
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
                        this.dataGridView1.Rows[num3].Cells[2].Value = reader.GetString("stk_empty");
                        this.dataGridView1.Rows[num3].Cells[3].Value = "1";
                        this.dataGridView1.Rows[num3].Cells[4].Value = reader.GetString("s_p");
                        this.dataGridView1.Rows[num3].Cells[5].Value = false;
                        this.dataGridView1.Rows[num3].Cells[6].Value = reader.GetString("ws");
                        this.dataGridView1.Rows[num3].Cells[11].Value = reader.GetString("wp_qty");
                        this.dataGridView1.Rows[num3].Cells[15].Value = reader.GetString("post8");
                        this.dataGridView1.Rows[num3].Cells[16].Value = reader.GetString("dept");
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
                this.amtDue.Text = (Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text)).ToString();
                this.NetPay.Text = this.amtDue.Text;
                this.txtTendered.Text = this.amtDue.Text;
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
                this.changeDue.Text = $"{Convert.ToDecimal(this.txtTendered.Text) - Convert.ToDecimal(this.amtDue.Text):N}";
                this.NetPay.Text = this.amtDue.Text;
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
                this.NetPay.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtDiscount.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Search_Product_Empty dc = new Search_Product_Empty();
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
                            //this.gclass.error("Product Has Already Been Added");
                            this.dataGridView1.Focus();
                            this.dataGridView1.Rows[num2].Selected = true;
                            return;
                        }
                    }
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM Sales_Summary WHERE recieptno = '" + this.textBox3.Text + "'", this.gclass.conn()).ExecuteReader();
                    if (!reader.Read())
                    {
                        this.gclass.error("Invoice No. Not Correct...");
                        reader.Close();
                    }
                    else
                    {
                        this.gclass.success("Invoice No. Confirmed...");
                        reader.Close();
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

            MySqlConnection cn = gclass.conn();
            try
            {
                if (this.button3.Text == "&Print Copy")
                {
                    this.button3.Text = "&Post";
                    this.printDocument2.Print();
                    this.listBox1.Items.Clear();
                    this.listBox2.Items.Clear();
                    this.dataGridView2.Rows.Clear();
                    this.dataGridView1.Rows.Clear();
                    this.mode.SelectedIndex = 0;
                    this.txtTotal.Text = "0.00";
                    this.txtDiscount.Text = "0.00";
                    this.txtTendered.Text = "0.00";
                    this.changeDue.Text = "0.00";
                    this.recieptno.Text = "AUTO";
                    this.txtRefno.Text = null;
                    this.cName.SelectedIndex = 0;
                }
                else
                {
                    if (this.dataGridView1.Rows.Count < 1)
                    {
                        this.gclass.error("Invalid Command...\n Select a Product  ");
                    }
                    else
                    {
                        string[] strArray = new string[] { DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), Program.user_id.ToString() };
                        this.recieptno.Text = string.Concat(strArray);
                        decimal num = 0M;
                        num = (Convert.ToDecimal(this.changeDue.Text) >= 0M) ? Convert.ToDecimal(this.textBox1.Text) : (Convert.ToDecimal(this.changeDue.Text) + Convert.ToDecimal(this.textBox1.Text));
                        //if (Math.Abs(num) > Convert.ToDecimal(this.textBox2.Text))
                        //{
                        //    MessageBox.Show("Sorry!, Amount Tendered Not Correct. \n\t Check It...", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        //}
                       
                         if (MessageBox.Show("Are You Sure ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {  
                                for (int tt = 0; tt < dataGridView1.Rows.Count; tt++)
                                {
                                    MySqlCommand jhg = new MySqlCommand("insert into product_profile_empties (pdate,entry_type,code,description,current_stock,qty,purpose,postedby)VALUES('" + label18.Text + "','" + source.Text + "','" + dataGridView1.Rows[tt].Cells[0].Value + "','" + dataGridView1.Rows[tt].Cells[1].Value + "','" + dataGridView1.Rows[tt].Cells[2].Value + "','" + dataGridView1.Rows[tt].Cells[3].Value + "','" + source.Text + "','" + Program.user + "')", cn);
                                    jhg.ExecuteNonQuery();
                                }
                                for (int dd = 0; dd < dataGridView1.Rows.Count; dd++)
                                    if (!((bool)this.dataGridView1.Rows[dd].Cells[5].Value))
                                    {

                                    }
                                    else

                                    {
                                        MySqlCommand yy = new MySqlCommand("UPDATE product SET stk_empty = '" + (Convert.ToInt32(dataGridView1.Rows[dd].Cells[2].Value) + Convert.ToInt32(dataGridView1.Rows[dd].Cells[3].Value)) + "' WHERE code = '" + dataGridView1.Rows[dd].Cells[0].Value + "'", cn);
                                        yy.ExecuteNonQuery();
                                        MySqlCommand jhg = new MySqlCommand("insert into post_empty_stock (pdate,post8,category,postedby)VALUES('" + label18.Text + "','" + dataGridView1.Rows[dd].Cells[3].Value + "','" + dataGridView1.Rows[dd].Cells[16].Value + "','" + Program.user + "')", cn);
                                        jhg.ExecuteNonQuery();
                                        //MySqlCommand button4fd = new MySqlCommand(@"UPDATE product SET post8 = '" + (Convert.ToDecimal(dataGridView1.Rows[dd].Cells[3].Value) + Convert.ToDecimal(dataGridView1.Rows[dd].Cells[15].Value)) + "' WHERE dept = '" + dataGridView1.Rows[dd].Cells[16].Value + "'", cn);
                                        //button4fd.ExecuteNonQuery();
                                        //MySqlCommand button4f = new MySqlCommand(@"UPDATE post_empty_stock SET post8 = '" + (Convert.ToDecimal(dataGridView1.Rows[dd].Cells[3].Value) + Convert.ToDecimal(dataGridView1.Rows[dd].Cells[15].Value)) + "' WHERE category = '" + dataGridView1.Rows[dd].Cells[16].Value + "'", cn);
                                        //button4f.ExecuteNonQuery();
                                        MySqlCommand jj = new MySqlCommand(@"INSERT INTO sales_detail_purchase_empties(pdate,mode,recieptno,prod_code,description,stock,qty,unit,total,pack,pack_price,qty_pack_db,cppl,qty_pack,cp,postedby)VALUES('" + label18.Text + "','" + mode.Text + "','" + recieptno.Text + "','" + dataGridView1.Rows[dd].Cells[0].Value + "','" + dataGridView1.Rows[dd].Cells[1].Value + "','" + dataGridView1.Rows[dd].Cells[2].Value + "','" + dataGridView1.Rows[dd].Cells[3].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[8].Value + "','" + dataGridView1.Rows[dd].Cells[5].Value + "','" + dataGridView1.Rows[dd].Cells[6].Value + "','" + dataGridView1.Rows[dd].Cells[11].Value + "','" + dataGridView1.Rows[dd].Cells[13].Value + "','" + dataGridView1.Rows[dd].Cells[7].Value + "','" + dataGridView1.Rows[dd].Cells[12].Value + "','" + Program.user + "')", cn);
                                        jj.ExecuteNonQuery();
                                    }
                                MessageBox.Show("Posted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (this.checkBox1.Checked)
                                {
                                    this.button1_Click(sender, e);
                                 
                                    System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                                  
                                    printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                                    this.listBox1.Items.Add("\n");
                                    this.listBox1.Items.Add(Program.companyNameRcpt1.ToString());
                                    this.listBox1.Items.Add(Program.companyAddressPos.ToString());
                                    this.listBox1.Items.Add("\nPhone: " + Program.companyPhone.ToString());
                                    this.listBox1.Items.Add("Email: " + Program.companyEmail.ToString());
                                    this.listBox1.Items.Add("========================================");
                                    this.listBox1.Items.Add("REFUND INVOICE - INV. NO:" + recieptno.Text);
                                    this.listBox1.Items.Add("Date: " + this.today.Value.ToString("dd/MM/yyyy").ToString() + "  Time: " + label19.Text.ToString());

                                    this.listBox1.Items.Add("Sold To : " + cName.Text);


                                    //this.printPreviewDialog1.Document = this.printDocument1;
                                    //this.printPreviewDialog1.WindowState = FormWindowState.Normal;
                                    //this.printPreviewDialog1.ShowDialog();
                                    this.printDocument1.Print();
                                }
                                this.dataGridView2.Rows.Clear();
                                this.dataGridView1.Rows.Clear();
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
                                textBox3.Text = null;
                                this.txtRefno.Visible = false;
                                this.txtRefno.SelectedIndex = -1;
                                this.comboBox1.SelectedIndex = -1;
                                this.comboBox1.Visible = false;
                                this.cName.SelectedIndex = 0;
                            }
                        }
                    }
                }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
          
          private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {

            }

        private void button4_Click(object sender, EventArgs e)
        {
            this.listBox3.Items.Add(Program.companyNameRcpt1.ToString());
            this.listBox3.Items.Add("\nReceipt Printer Ok !!! ");
            //this.printPreviewDialog3.Document = this.printDocument5;
            //this.printPreviewDialog3.WindowState = FormWindowState.Normal;
            //this.printPreviewDialog3.ShowDialog();
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
    }
}
