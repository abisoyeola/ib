using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
namespace POS_SALES
{
    public partial class Sales_Invoice_Report : Form
    {
        public static string doc_no;
        public static string pdate;
        public static string rptn;
        public static string kashier;
        public static string total_amount;
        //public static string identify = "15";
        private General gclass = new General();
        private string reportTitle = null;
        public Sales_Invoice_Report()
        {
            InitializeComponent();
        }

        private void Sales_Invoice_Report_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                //{
                //    this.gclass.error("Access Denied...");
                //    base.Close();
                //}
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM sales_invoice_summary", this.gclass.conn()).ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Close();
                        int count = this.dataGridView1.Rows.Count;
                        decimal num3 = 0M;
                        int num4 = 0;
                        while (true)
                        {
                            string str;
                            flag = num4 < count;
                            if (!flag)
                            {
                                this.dataGridView1.Rows.Add(2);
                                int num5 = this.dataGridView1.Rows.Count - 1;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Font = new Font("verdana", 12f);
                                this.dataGridView1.Rows[num5].Cells[1].Value = "S/N";
                                this.dataGridView1.Rows[num5].Cells[2].Value = "CASHIER";
                                this.dataGridView1.Rows[num5].Cells[3].Value = "AMOUNT";
                                int num6 = this.listBox1.Items.Count;
                                decimal num7 = 0M;
                                string str2 = null;
                                int num8 = 0;
                                while (true)
                                {
                                    if (num8 >= num6)
                                    {
                                        this.dataGridView1.Rows.Add();
                                        int num10 = this.dataGridView1.Rows.Count - 1;
                                        this.dataGridView1.Rows[num10].DefaultCellStyle.Font = new Font("verdana", 8f);
                                        //this.dataGridView1.Rows[num10].Cells[1].Value = "TOTAL AMOUNT";
                                        //this.dataGridView1.Rows[num10].Cells[3].Value = $"{num3:N}";
                                        //this.lbltotalAmt.Text = $"{num3:N}";
                                        this.reportTitle = "Sales Invoice Analysis Report Summary Till Date (" + this.dateTimePicker1.Value.ToString("yyyy/MM/dd") + ")";
                                        break;
                                    }
                                    str = this.listBox1.Items[num8].ToString();
                                    num4 = 0;
                                    while (true)
                                    {
                                        flag = num4 < count;
                                        if (!flag)
                                        {
                                            this.dataGridView1.Rows.Add();
                                            int num9 = this.dataGridView1.Rows.Count - 1;
                                            this.dataGridView1.Rows[num9].Cells[1].Value = num8 + 1;
                                            this.dataGridView1.Rows[num9].Cells[2].Value = str.ToString();
                                            this.dataGridView1.Rows[num9].Cells[3].Value = $"{num7:N}";
                                            num7 = 0M;
                                            num8++;
                                            break;
                                        }
                                        str2 = this.dataGridView1.Rows[num4].Cells[3].Value.ToString();
                                        if (str == str2)
                                        {
                                            num7 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                                        }
                                        num4++;
                                    }
                                }
                                break;
                            }
                            num3 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            this.dataGridView1.Rows[num4].Cells[0].Value = (num4 + 1).ToString();
                            str = this.dataGridView1.Rows[num4].Cells[3].Value.ToString();
                            if (!this.listBox1.Items.Contains(str.ToString()))
                            {
                                this.listBox1.Items.Add(str);
                            }
                            num4++;
                        }
                        break;
                    }
                    this.dataGridView1.Rows.Add();
                    int num = this.dataGridView1.Rows.Count - 1;
                    this.dataGridView1.Rows[num].Cells[0].Value = reader.GetString("id");
                    //this.dataGridView1.Rows[num].Cells[1].Value = reader.GetString("doc_no");
                    this.dataGridView1.Rows[num].Cells[1].Value = reader.GetString("pdate");
                    //this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("entry_type");
                    this.dataGridView1.Rows[num].Cells[2].Value = reader.GetString("recieptno");
                    this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("postedby");
                    this.dataGridView1.Rows[num].Cells[4].Value = reader.GetString("total");
                    //this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("total");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new Sales_Invoice().ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                //doc_no = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                pdate = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                rptn = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                kashier = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                total_amount = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                new Sales_Invoice_Detail().ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.ForeColor = Color.Maroon;
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 10f);
                this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
                DGVPrinter printer = new DGVPrinter
                {
                    TitleColor = Color.Maroon,
                    SubTitleColor = Color.Black,
                    Title = Program.companyName + "\n",
                    SubTitle = Program.companyAddressA4
                };
                string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                printer.SubTitle = string.Concat(strArray);
                printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \nSALES INVOICE REPORT\n ";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.PrintMargins.Left = 10;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Right = 10;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                printer.FooterSpacing = 15f;
                if (this.dataGridView1.Columns.Count > 7)
                {
                    printer.PageSettings.Landscape = true;
                }
                printer.PrintPreviewDataGridView(this.dataGridView1);
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
                this.listBox1.Items.Clear();
                this.dataGridView1.Rows.Clear();
                string[] strArray = new string[] { "SELECT * FROM sales_invoice_summary WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'  " };
                MySqlDataReader reader = new MySqlCommand(string.Concat(strArray), this.gclass.conn()).ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Close();
                        int count = this.dataGridView1.Rows.Count;
                        decimal num3 = 0M;
                        int num4 = 0;
                        while (true)
                        {
                            string str;
                            flag = num4 < count;
                            if (!flag)
                            {
                                this.dataGridView1.Rows.Add(2);
                                int num5 = this.dataGridView1.Rows.Count - 1;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Font = new Font("verdana", 12f);
                                this.dataGridView1.Rows[num5].Cells[1].Value = "S/N";
                                this.dataGridView1.Rows[num5].Cells[2].Value = "CASHIER";
                                this.dataGridView1.Rows[num5].Cells[3].Value = "AMOUNT";
                                int num6 = this.listBox1.Items.Count;
                                decimal num7 = 0M;
                                string str2 = null;
                                int num8 = 0;
                                while (true)
                                {
                                    if (num8 >= num6)
                                    {
                                        this.dataGridView1.Rows.Add();
                                        int num10 = this.dataGridView1.Rows.Count - 1;
                                        this.dataGridView1.Rows[num10].DefaultCellStyle.Font = new Font("verdana", 8f);
                                        //this.dataGridView1.Rows[num10].Cells[1].Value = "TOTAL AMOUNT";
                                        //this.dataGridView1.Rows[num10].Cells[3].Value = $"{num3:N}";
                                        //this.lbltotalAmt.Text = $"{num3:N}";
                                        strArray = new string[] { "Sales Invoice Analysis Report Summary From (", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), ") To (", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), ")" };
                                        this.reportTitle = string.Concat(strArray);
                                        break;
                                    }
                                    str = this.listBox1.Items[num8].ToString();
                                    num4 = 0;
                                    while (true)
                                    {
                                        flag = num4 < count;
                                        if (!flag)
                                        {
                                            this.dataGridView1.Rows.Add();
                                            int num9 = this.dataGridView1.Rows.Count - 1;
                                            this.dataGridView1.Rows[num9].Cells[1].Value = num8 + 1;
                                            this.dataGridView1.Rows[num9].Cells[2].Value = str.ToString();
                                            this.dataGridView1.Rows[num9].Cells[3].Value = $"{num7:N}";
                                            num7 = 0M;
                                            num8++;
                                            break;
                                        }
                                        str2 = this.dataGridView1.Rows[num4].Cells[3].Value.ToString();
                                        if (str == str2)
                                        {
                                            num7 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                                        }
                                        num4++;
                                    }
                                }
                                break;
                            }
                            num3 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[2].Value);
                            this.dataGridView1.Rows[num4].Cells[0].Value = (num4 + 1).ToString();
                            str = this.dataGridView1.Rows[num4].Cells[3].Value.ToString();
                            if (!this.listBox1.Items.Contains(str.ToString()))
                            {
                                this.listBox1.Items.Add(str);
                            }
                            num4++;
                        }
                        break;
                    }
                    this.dataGridView1.Rows.Add();
                    int num = this.dataGridView1.Rows.Count - 1;
                    this.dataGridView1.Rows[num].Cells[0].Value = reader.GetString("id");
                    //this.dataGridView1.Rows[num].Cells[1].Value = reader.GetString("doc_no");
                    this.dataGridView1.Rows[num].Cells[1].Value = reader.GetString("pdate");
                    //this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("entry_type");
                    this.dataGridView1.Rows[num].Cells[2].Value = reader.GetString("recieptno");
                    this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("postedby");
                    this.dataGridView1.Rows[num].Cells[4].Value = reader.GetString("total");
                    //this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("total");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                doc_no = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                pdate = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                rptn = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                kashier = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                total_amount = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                new Sales_Invoice_Detail().ShowDialog();
            }
            catch (Exception)
            {
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
