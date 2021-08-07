using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
namespace POS_SALES
{
    public partial class Sales_Analysis_Report : Form
    {
        private Font myfont2 = new Font("Courier New", 8f);
        private Font myfont3 = new Font("Courier New", 7f, FontStyle.Italic);
        private Font myHead = new Font("Courier New", 14f, FontStyle.Bold);
        private Font myfont4 = new Font("Courier New", 8f, FontStyle.Bold);
        private string about = "";
        private decimal total = 0M;
        private General gclass = new General();
        private rpt Column = new rpt();
        public Sales_Analysis_Report()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strArray;
                bool flag = Report.reportid == "rp15";
                if (flag)
                {
                    this.gclass.DGVTable("SELECT * FROM sales_detail WHERE recieptno = '" + this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString().ToString() + "'", this.dataGridView12);
                    this.button2_Click(sender, e);
                   
                    this.listBox1.Items.Add(Program.companyNameRcpt1.ToString());
                    this.listBox1.Items.Add(Program.companyAddressPos.ToString());
                    this.listBox1.Items.Add("\nPhone: " + Program.companyPhone.ToString());
                    this.listBox1.Items.Add("\nEmail: " + Program.companyEmail.ToString());
                    this.listBox1.Items.Add("========================================");
                    this.listBox1.Items.Add("CASH RECEIPT     -     RN: " + this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    this.listBox1.Items.Add("Date: " + this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "  Time: " + $"{ DateTime.Now:T}");
                    //this.listBox1.Items.Add("Date: " + this.today.Value.ToString("yyyy/MM/dd").ToString() + "  Time: " + label19.Text.ToString());
                    this.listBox1.Items.Add("Sold To : " + this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
                 
                    this.printPreviewDialog1.Document = this.printDocument1;
                    this.printPreviewDialog1.WindowState = FormWindowState.Normal;
                    this.printPreviewDialog1.ShowDialog();
                    this.listBox1.Items.Clear();
                    this.dataGridView2.Rows.Clear();
                }
                else
                {
                    this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                    this.dataGridView1.ForeColor = Color.Black;
                    this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 10f);
                    this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
                    IEnumerator enumerator = ((IEnumerable)this.dataGridView1.Rows).GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            DataGridViewRow current = (DataGridViewRow)enumerator.Current;
                            current.DefaultCellStyle.BackColor = Color.White;
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
                    DGVPrinter printer = new DGVPrinter
                    {
                        TitleColor = Color.Black,
                        SubTitleColor = Color.Black,
                        Title = Program.companyName + "\n",
                        SubTitle = Program.companyAddressA4
                    };
                    strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                    printer.SubTitle = string.Concat(strArray);
                    printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \n\n";
                    printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                    printer.PageNumbers = true;
                    printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                    printer.PrintMargins.Left = 10;
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
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Report.reportid != "rp2") && ((Report.reportid == "rp16") && (this.toolStripComboBox1.SelectedIndex == 0)))
            {
                string query = null;
                query = !Report.reportquery.Contains("WHERE") ? (Report.reportquery + " WHERE category = '" + this.desc.Text + "'") : (Report.reportquery + " AND category = '" + this.desc.Text + "'");
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();
                this.Column.rp16(this.dataGridView1, query, this.gclass.conn());
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
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
            e.HasMorePages = printer.EmbeddedPrint(this.dataGridView2, e.Graphics, new Rectangle(5, y, 0x12e, 400));
            return "";
        }
        private void button2_Click(object sender, EventArgs e)
        {

            string str = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string str2 = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string str3 = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string str4 = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string str5 = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            string str6 = this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            string str7 = this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            string str8 = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            int count = this.dataGridView12.Rows.Count;
            int num2 = 0;
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
                    this.dataGridView2.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(str):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Discount: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(str2):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Net Pay: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(str3):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Amt Tendered: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(str4):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Change Due: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = $"{Convert.ToDecimal(str5):N}";
                    this.dataGridView2.Rows.Add();
                    num4 = this.dataGridView2.Rows.Count - 1;
                    this.dataGridView2.Rows[num4].DefaultCellStyle.Font = new Font("Courier New", 8f, FontStyle.Bold);
                    this.dataGridView2.Rows[num4].Cells[0].Value = "Cashier: ";
                    this.dataGridView2.Rows[num4].Cells[3].Value = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
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
                //if (num2 >= count)
                //{ 
                this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView12.Rows[num2].Cells[5].Value;
                this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView12.Rows[num2].Cells[7].Value;
                this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView12.Rows[num2].Cells[8].Value:N}";
                this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView12.Rows[num2].Cells[9].Value:N}";
                num2++;
                //}
                //else
                //{
                //    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView12.Rows[num2].Cells[5].Value;
                //    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView12.Rows[num2].Cells[7].Value;
                //    this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView12.Rows[num2].Cells[8].Value:N}";
                //    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView12.Rows[num2].Cells[9].Value:N}";
                //    num2++;
                //}

                //if (!((bool)this.dataGridView1.Rows[num3].Cells[5].Value))
                //{
                //    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[5].Value;
                //    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[7].Value;
                //    this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                //    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[9].Value:N}";
                //    num2++;
                //}

                //else
                //{
                //    this.dataGridView2.Rows[num3].Cells[0].Value = this.dataGridView1.Rows[num2].Cells[5].Value;
                //    this.dataGridView2.Rows[num3].Cells[1].Value = this.dataGridView1.Rows[num2].Cells[7].Value;
                //    this.dataGridView2.Rows[num3].Cells[2].Value = $"{this.dataGridView1.Rows[num2].Cells[8].Value:N}";
                //    this.dataGridView2.Rows[num3].Cells[3].Value = $"{this.dataGridView1.Rows[num2].Cells[9].Value:N}";
                //    num2++;
                //}
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (Report.reportid == "rp2")
            {
                this.button1.Text = "Filter";
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();
                this.Column.rp2(this.dataGridView1, Report.reportquery, this.gclass.conn());
            }
            else if (Report.reportid == "rp16")
            {
                this.button1.Text = "Filter";
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();
                this.Column.rp16(this.dataGridView1, Report.reportquery, this.gclass.conn());
            }
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (((Report.reportid != "rp2") && (Report.reportid == "rp16")) && (this.toolStripComboBox1.SelectedIndex == 0))
                {
                    this.gclass.LoadCombo(this.desc, "SELECT * FROM expense_cat ", "name");
                    this.gclass.autocomplete("SELECT * FROM expense_cat ", 2, this.desc);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void Sales_Analysis_Report_Load(object sender, EventArgs e)
        {
            try
            {
                if (Report.reportid == "rp1")
                {
                    this.Column.rp1(this.dataGridView1, Report.reportquery, this.gclass.conn());
                }
                else if (Report.reportid == "rp35")
                {
                    this.Column.rp35(this.dataGridView1, Report.reportquery, this.gclass.conn());
                }
                else if (Report.reportid == "rp2")
                {
                    this.Column.rp2(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    this.Column.rp2Filter(this.dataGridView1, this.toolStripComboBox1);
                }
                else if (Report.reportid == "rp32")
                {
                    this.Column.rp32(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    this.Column.rp32Filter(this.dataGridView1, this.toolStripComboBox1);
                }
                else if (Report.reportid == "rp33")
                {
                    this.Column.rp33(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    this.Column.rp33Filter(this.dataGridView1, this.toolStripComboBox1);
                }
                else if (Report.reportid == "rp26")
                {
                    this.Column.rp26(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    this.Column.rp26Filter(this.dataGridView1, this.toolStripComboBox1);
                }
                else if (Report.reportid == "rp3")
                {
                    this.Column.rp3(this.dataGridView1, Report.reportquery, this.gclass.conn());
                }
                else if (Report.reportid == "rp4")
                {
                    this.Text = Report.reportTitle;
                    this.Column.rp4(this.dataGridView1, Report.reportquery, this.gclass.conn());
                }
                else if (Report.reportid == "rp5")
                {
                    this.Text = Report.reportTitle;
                    this.Column.rp5(this.dataGridView1, Report.reportquery, this.gclass.conn());
                }
                else if (Report.reportid == "rp15")
                {
                    this.Text = "Customer Receipt Re-Print.";
                    this.Column.rp15(this.dataGridView1, Report.reportquery, this.gclass.conn());
                }
                else if (Report.reportid == "rp16")
                {
                    this.Text = "Daily Expenditure Report";
                    this.label1.Text = "Expenditure";
                    this.Column.rp16(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    this.Column.rp16Filter(this.dataGridView1, this.toolStripComboBox1);
                }
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[0].Value = num + 1;
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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
                        if (current == Program.companyName)
                        {
                            e.Graphics.DrawString(current, this.myHead, Brushes.Black, 55f, (float)y);
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
                e.Graphics.DrawString("Thank You for your patronage.\nNote: Goods bought are not returnable", this.myfont3, Brushes.Black, (float)num, (float)y);
                e.Graphics.DrawString("*****REPRINT COPY*****", this.myfont4, Brushes.Black, (float)num, (float)(y + 0x19));
            }

        }
    }

