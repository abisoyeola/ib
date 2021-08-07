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
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
namespace POS_SALES
{
    public partial class Profit_Projection : Form
    {
        private string report = null;
        private General gclass = new General();
        public static string identify = "26";
        public Profit_Projection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void Sales_Report_Qty_By_Total_Load(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',category AS 'PRODUCT CATEGORY',QTY AS 'QTY SOLD',CP AS 'COST PRICE',SP AS 'SELLING PRICE' FROM sales_detail_qty" };
                string cmdText = string.Concat(strArray);
                string query = string.Concat(strArray);
                decimal num = 0M;
                decimal num2 = 0M;
                this.gclass.DGVTable2(query, this.dataGridView2);
                int num3 = 0;
                while (true)
                {
                    bool flag = num3 < this.dataGridView2.Rows.Count;
                    if (!flag)
                    {
                        MySqlDataReader reader = new MySqlCommand(cmdText, this.gclass.conn()).ExecuteReader();
                        this.dataGridView1.Rows.Clear();
                        while (true)
                        {
                            flag = reader.Read();
                            if (!flag)
                            {
                                reader.Close();
                                this.dataGridView1.Rows.Add();
                                int num5 = this.dataGridView1.Rows.Count - 1;
                                int sum = 0;
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                                }
                                this.dataGridView1.Rows[num5].Cells[1].Value = "TOTAL PROFIT:";
                                this.dataGridView1.Rows[num5].Cells[9].Value = sum.ToString();
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("PRODUCT CODE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("PRODUCT DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("PRODUCT CATEGORY");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("QTY SOLD");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("COST PRICE");
                            this.dataGridView1.Rows[num4].Cells[6].Value = reader.GetString("SELLING PRICE");
                            //decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            //decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            //decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            //decimal num10 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value);
                            //decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value);
                            //this.dataGridView1.Rows[num4].Cells[7].Value = num7 * num8;
                            //this.dataGridView1.Rows[num4].Cells[8].Value = num7 * num9;
                            //this.dataGridView1.Rows[num4].Cells[9].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value));
                            decimal sum1 = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                            }
                            decimal tot_profit = 0;
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                tot_profit += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                            }

                            if (tot_profit == 0)
                            {

                            }
                            //total_profit.Text = tot_profit.ToString();
                            //this.total_profit.Text = $"{Convert.ToDecimal(this.total_profit.Text):N}";
                        }
                        break;
                    }
                    num2 += Convert.ToDecimal(this.dataGridView2.Rows[num3].Cells[0].Value);
                    num3++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.ForeColor = Color.Maroon;
            this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 12f);
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
            IEnumerator enumerator = ((IEnumerable)this.dataGridView1.Rows).GetEnumerator();
            try
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
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
            string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
            printer.SubTitle = string.Concat(strArray);
            printer.SubTitle = printer.SubTitle + "\n" + this.report + " \n\n";
            printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            printer.PageNumbers = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
            printer.PrintMargins.Left = 10;
            printer.PrintMargins.Right = 10;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
            printer.FooterSpacing = 15f;
            printer.TitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            printer.SubTitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            if (this.dataGridView1.Columns.Count > 7)
            {
                printer.PageSettings.Landscape = true;
            }
            printer.PrintPreviewDataGridView(this.dataGridView1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.ForeColor = Color.Maroon;
            this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 9f);
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
            IEnumerator enumerator = ((IEnumerable)this.dataGridView1.Rows).GetEnumerator();
            try
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
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
            string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
            printer.SubTitle = string.Concat(strArray);
            printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \n\n";
            printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            printer.PageNumbers = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
            printer.PrintMargins.Left = 10;
            printer.PrintMargins.Right = 10;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
            printer.FooterSpacing = 15f;
            printer.TitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            printer.SubTitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            if (this.dataGridView1.Columns.Count > 7)
            {
                printer.PageSettings.Landscape = true;
            }
            printer.PrintPreviewDataGridView(this.dataGridView1);
        }

        private void label1_Click_1(object sender, EventArgs e)
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
    }
}
