using System;
using System.Collections;
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
    public partial class Daily_Transaction_Report_Summary : Form
    {
        public static string identify = "2";
        private General gclass = new General();
        private Font myfont2 = new Font("Arial", 8f);
        private Font myHead = new Font("Arial", 11f, FontStyle.Bold);
        public Daily_Transaction_Report_Summary()
        {
            InitializeComponent();
        }

       

        private void Daily_Transaction_Report_Summary_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.label1.Text = Program.user;
                this.label5.Text = "A Cashier Daily General Sales Transaction Summary Report For " + DateTime.Now.ToString("dd/MM/yyyy");
                this.fullname.Text = User_Login.sendfull_name;
                string str = null;
                decimal num = 0M;
                decimal num2 = 0M;
                decimal num3 = 0M;
                decimal num4 = 0M;
                decimal num5 = 0M;
                decimal num11 = 0M;
                decimal num12 = 0M;
                this.gclass.DGVTable("SELECT id,pdate,amt_less_discount,mode,postedby,bottle_purchased FROM sales_summary WHERE pdate='" + DateTime.Now.ToString("dd/MM/yyyy") + "' AND postedby='" + Program.user + "' ", this.dataGridView2);
                int num6 = 0;
                while (true)
                {
                    if (num6 >= this.dataGridView2.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        this.txtCash.Text = $"{num2:N}";
                        this.txtPOS.Text = $"{num3:N}";
                        this.txtTransfer.Text = $"{num4:N}";
                        this.txtCheque.Text = $"{num5:N}";
                        this.txtCredit.Text = $"{num11:N}";
                        this.bottle_purchased.Text = $"{num12:N}";
                        break;
                    }
                    num += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[2].Value);
                    num12 += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[5].Value);
                    str = Convert.ToString(this.dataGridView2.Rows[num6].Cells[3].Value);
                    if (str == "CASH")
                    {
                        num2 += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[2].Value);
                    }
                    else if (str == "POS")
                    {
                        num3 += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[2].Value);
                    }
                    else if (str == "TRANSFER")
                    {
                        num4 += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[2].Value);
                    }
                    else if (str == "CHEQUE")
                    {
                        num5 += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[2].Value);
                    }
                    else if (str == "CREDIT SALES")
                    {
                        num11 += Convert.ToDecimal(this.dataGridView2.Rows[num6].Cells[2].Value);
                    }
                    num6++;
                }
                this.total_amt.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.bottle_purchased.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.listBox1.Items.Add(Program.companyName.ToString());
                this.listBox1.Items.Add(Program.companyAddressPos.ToString());
                this.listBox1.Items.Add("");
                this.listBox1.Items.Add("Email: " + Program.companyEmail);
                this.listBox1.Items.Add("Phone: " + Program.companyPhone);
                this.listBox1.Items.Add("====================================================================");
                this.listBox1.Items.Add("CASHIER SALES TRANSACTION SUMMARY REPORT");
                this.listBox1.Items.Add("Date:  " + DateTime.Now.ToString("yyyy/MM/dd"));
                this.listBox1.Items.Add("       CASHIER ID:" + this.label1.Text);
                this.listBox1.Items.Add("CASHIER NAME:" + this.fullname.Text + "\n");
                this.listBox1.Items.Add("\n\n      Total Cash Amount :\t" + this.txtCash.Text);
                this.listBox1.Items.Add("\n\n       Total POS Amount :\t" + this.txtPOS.Text);
                this.listBox1.Items.Add("\n\n  Total Transfer Amount :\t" + this.txtTransfer.Text);
                this.listBox1.Items.Add("\n\n    Total Cheque Amount :\t" + this.txtCheque.Text);
                this.listBox1.Items.Add("\n\n    Total Credit Amount :\t" + this.txtCredit.Text);
                this.listBox1.Items.Add("\n\n     Total Sales Amount :\t" + this.txtTotal.Text);
                this.listBox1.Items.Add("\n\n====================================================================");
                this.listBox1.Items.Add("\n\n       Bottle Purchased :\t" + this.bottle_purchased.Text);
                this.listBox1.Items.Add("\n\n     Total Sales Liquid :\t" + this.total_amt.Text);
                this.listBox1.Items.Add("\n\n====================================================================");
                this.listBox1.Items.Add(DateTime.Now.ToString("dd/MM/yyyy") + "\t" + $"{DateTime.Now:T}");
                this.printDocument1.Print();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
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
                    if (current == Program.companyName)
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
    }
}

    
