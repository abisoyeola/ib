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
using System.Collections;

namespace POS_SALES
{
    public partial class Stock_Valuation_Summary : Form
    {
        private string report = "EMPTIES STOCK VALUATION SUMMARY";
        General gclass = new General();
        public Stock_Valuation_Summary()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Stock_Position_Summary_Load(object sender, EventArgs e)
        {
         try
            {
                string[] strArray = new string[] { "SELECT ID AS 'S/N', CODE AS 'CATEGORY CODE', dept AS 'PRODUCT CATEGORY', SUM(stk_empty) AS 'STOCK EMPTIES', ws AS 'EMPTIES BOTTLE PRICE' FROM product GROUP BY dept" };
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
                                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                }
                                this.dataGridView1.Rows[num5].Cells[0].Value = "TOTAL:";
                                //this.dataGridView1.Rows[num5].Cells[5].Value = $"{sum.ToString():N}";
                                this.dataGridView1.Rows[num5].Cells[5].Value = sum.ToString();
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("CATEGORY CODE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("PRODUCT CATEGORY");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("STOCK EMPTIES");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("EMPTIES BOTTLE PRICE");
                            decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[3].Value);
                            //this.dataGridView1.Rows[num4].Cells[5].Value = $"{num7 * num8:N}";
                            this.dataGridView1.Rows[num4].Cells[5].Value = num7 * num8;

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

        private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
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
    }
}
