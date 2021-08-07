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
    public partial class Transction_Report_Summary : Form
    {
        private General gclass = new General();
        private Font myfont2 = new Font("Arial", 8f);
        private Font myHead = new Font("Arial", 11f, FontStyle.Bold);
        public Transction_Report_Summary()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int num = 5;
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
            e.Graphics.DrawString("           ", this.myHead, Brushes.Black, (float)num, (float)num2);
        }

        private void Transction_Report_Summary_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Hide();
          
        }

        private void Transction_Report_Summary_Load(object sender, EventArgs e)
        {
            try
            {
                string str = null;
                decimal num = 0M;
                decimal num2 = 0M;
                decimal num3 = 0M;
                decimal num4 = 0M;
                decimal num5 = 0M;
                string str2 = null;
                decimal num6 = 0M;
                decimal num7 = 0M;
                decimal num8 = 0M;
                decimal num9 = 0M;
                decimal num10 = 0M;
                decimal num11 = 0M;
                decimal num12 = 0M;
                decimal num133 = 0M;
                decimal num144 = 0M;
                decimal num155 = 0M;
                decimal num166 = 0M;
                decimal num177 = 0M;
                decimal num188 = 0M;
                
                this.label5.Text = Report.reportTitle;
                this.gclass.DGVTable(Report.reportquery, this.dataGridView2);
                string[] source = new string[this.dataGridView2.Rows.Count];
                int count = this.dataGridView2.Rows.Count;
                int index = 0;
                while (true)
                {
                    bool flag = index < count;
                    if (!flag)
                    {
                        using (List<string>.Enumerator enumerator = source.Distinct<string>().ToList<string>().GetEnumerator())
                        {
                            while (true)
                            {
                                flag = enumerator.MoveNext();
                                if (!flag)
                                {
                                    break;
                                }
                                string current = enumerator.Current;
                                if (current.Length > 0)
                                {
                                    int num13 = 0;
                                    while (true)
                                    {
                                        flag = num13 < this.dataGridView2.Rows.Count;
                                        if (!flag)
                                        {
                                            this.dataGridView1.Rows.Add();
                                            int num14 = this.dataGridView1.Rows.Count - 1;
                                            this.dataGridView1.Rows[num14].Cells[0].Value = num14 + 1;
                                            this.dataGridView1.Rows[num14].Cells[1].Value = str2.ToString();
                                            this.dataGridView1.Rows[num14].Cells[2].Value = $"{num6:N}";
                                            this.dataGridView1.Rows[num14].Cells[3].Value = $"{num133:N}";
                                            this.dataGridView1.Rows[num14].Cells[4].Value = $"{num144:N}";
                                            this.dataGridView1.Rows[num14].Cells[5].Value = $"{num155:N}";
                                            this.dataGridView1.Rows[num14].Cells[6].Value = $"{num10:N}";
                                            this.dataGridView1.Rows[num14].Cells[7].Value = $"{num166:N}";
                                            this.dataGridView1.Rows[num14].Cells[8].Value = $"{num12:N}";
                                            this.dataGridView1.Rows[num14].Cells[9].Value = $"{num177:N}";
                                            this.dataGridView1.Rows[num14].Cells[10].Value = $"{num188:N}";
                                            //this.bottle_purchased.Text = $"{num12:N}";
                                            num6 = 0M;
                                            num7 = 0M;
                                            num10 = 0M;
                                            num11 = 0M;
                                            num12 = 0M;
                                            num133 = 0M;
                                            num144 = 0M;
                                            num155 = 0M;
                                            num166 = 0M;
                                            num177 = 0M;
                                            num188 = 0M;
                                            num8 = 0M;
                                            num9 = 0M;
                                            dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[7].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[10].DefaultCellStyle.Format = "N2";
                                            break;
                                        }
                                        string str4 = Convert.ToString(this.dataGridView2.Rows[num13].Cells[4].Value);
                                        string str5 = Convert.ToString(this.dataGridView2.Rows[num13].Cells[3].Value);
                                        str2 = current.ToString();
                                        if (str2 == str4)
                                        {
                                            num6  += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[2].Value);
                                            num12 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[5].Value);
                                            num133 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[6].Value);
                                            num144 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[7].Value);
                                            num155 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[8].Value);
                                            num166 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[9].Value);
                                            num177 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[10].Value);
                                            num188 += Convert.ToDecimal(this.dataGridView2.Rows[num13].Cells[11].Value);
                                            dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[7].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                                            dataGridView1.Columns[10].DefaultCellStyle.Format = "N2";
                                        }
                                        num13++;
                                    }
                                }
                            }
                        }
                        index = 0;
                        while (true)
                        {
                            flag = index < this.dataGridView2.Rows.Count;
                            if (!flag)
                            {
                                this.txtTotal.Text = $"{num:N}";
                                this.txtCash.Text = $"{num133:N}";
                                this.txtPOS.Text = $"{num144:N}";
                                this.txtTransfer.Text = $"{num155:N}";
                                this.txtCheque.Text = $"{num5:N}";
                                this.txtCredit.Text = $"{num166:N}";
                                this.bottle_purchased.Text = $"{num12:N}";
                                break;
                            }
                            num += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[2].Value);
                            num12 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[5].Value);
                            num133 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[6].Value);
                            num144 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[7].Value);
                            num155 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[8].Value);
                            num166 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[9].Value);
                            num177 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[10].Value);
                            num188 += Convert.ToDecimal(this.dataGridView2.Rows[index].Cells[11].Value);
                            str = Convert.ToString(this.dataGridView2.Rows[index].Cells[3].Value);
                            index++;
                            dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[7].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                            dataGridView1.Columns[10].DefaultCellStyle.Format = "N2";
                        }
                        break;
                    }
                    source[index] = Convert.ToString(this.dataGridView2.Rows[index].Cells[4].Value).ToString();
                    index++;
                }
                this.total_amt.Text = $"{(Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.bottle_purchased.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add(Program.companyName.ToString());
                string[] strArray = new string[] { Program.companyAddressPos.ToString(), "\nEmail: ", Program.companyEmail, "\nPhone: ", Program.companyPhone, "\n" };
                this.listBox1.Items.Add(string.Concat(strArray));
                this.listBox1.Items.Add(" ");
                this.listBox1.Items.Add(" ");
                this.listBox1.Items.Add("====================================================================");
                this.listBox1.Items.Add(Report.reportTitle.ToUpper());
                this.listBox1.Items.Add("\n      Total Cash Amount :\t" + this.txtCash.Text);
                this.listBox1.Items.Add("\n       Total POS Amount :\t" + this.txtPOS.Text);
                this.listBox1.Items.Add("\n  Total Transfer Amount :\t" + this.txtTransfer.Text);
                this.listBox1.Items.Add("\n    Total Cheque Amount :\t" + this.txtCheque.Text);
                this.listBox1.Items.Add("\n    Total Credit Amount :\t" + this.txtCredit.Text);
                this.listBox1.Items.Add("\n     Total Sales Amount :\t" + this.txtTotal.Text);
                this.listBox1.Items.Add("====================================================================");
                this.listBox1.Items.Add("         Bottle Purchased :\t" + this.bottle_purchased.Text);
                this.listBox1.Items.Add("       Total Sales Liquid :\t" + this.total_amt.Text);
                this.listBox1.Items.Add("====================================================================");
                this.listBox1.Items.Add("CASHIER ANALYSIS");
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        this.printPreviewDialog1.Document = this.printDocument1;
                        this.printPreviewDialog1.WindowState = FormWindowState.Normal;
                        this.printPreviewDialog1.ShowDialog();
                        break;
                    }
                    dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[7].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[8].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
                    dataGridView1.Columns[10].DefaultCellStyle.Format = "N2";
                    this.listBox1.Items.Add("\n        Cashier Name :\t" + this.dataGridView1.Rows[num].Cells[1].Value.ToString());
                    this.listBox1.Items.Add("\n         Cash Amount :\t" + $"{this.dataGridView1.Rows[num].Cells[3].Value.ToString():N}");
                    this.listBox1.Items.Add("\n          POS Amount :\t" + $"{this.dataGridView1.Rows[num].Cells[4].Value.ToString():N}");
                    this.listBox1.Items.Add("\n     Transfer Amount :\t" + $"{this.dataGridView1.Rows[num].Cells[5].Value.ToString():N}");
                    this.listBox1.Items.Add("\n       Cheque Amount :\t" + $"{this.dataGridView1.Rows[num].Cells[6].Value.ToString():N}");
                    this.listBox1.Items.Add("\n       Credit Amount :\t" + $"{this.dataGridView1.Rows[num].Cells[7].Value.ToString():N}");
                    this.listBox1.Items.Add("\n  Total Sales Liquid :\t" + $"{this.dataGridView1.Rows[num].Cells[9].Value.ToString():N}");
                    this.listBox1.Items.Add("\n    Bottle Purchased :\t" + $"{this.dataGridView1.Rows[num].Cells[8].Value.ToString():N}");
                    this.listBox1.Items.Add("\n  Total Sales Amount :\t" + $"{this.dataGridView1.Rows[num].Cells[10].Value.ToString():N}");
                    //this.listBox1.Items.Add("\n====================================================================");
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int num = 5;
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
            e.Graphics.DrawString("           ", this.myHead, Brushes.Black, (float)num, (float)num2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
