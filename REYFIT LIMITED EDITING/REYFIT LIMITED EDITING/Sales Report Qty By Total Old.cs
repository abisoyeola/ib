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
    public partial class Sales_Report_Qty_By_Total_Old : Form
    {
        private string report = null;
        private General gclass = new General();
        public static string identify = "26";
        public Sales_Report_Qty_By_Total_Old()
        {
            InitializeComponent();
        }

        private void Sales_Report_Qty_By_Total_Old_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.LoadCombo(this.desc, "SELECT * FROM prod_category", "category");

                //string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',SUM(QTY) AS 'QTY SOLD', UNIT AS 'UNIT'  FROM sales_detail WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY prod_code " };
                string[] strArray = new string[] { "SELECT recieptno AS 'S/N',PDATE AS 'POSTING DATE',PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',category AS 'PRODUCT CATEGORY',QTY AS 'QTY SOLD',CP AS 'COST PRICE',SP AS 'SELLING PRICE',DISCOUNT AS 'DISCOUNT' FROM sales_detail_qty" };
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
                                int sum1 = 0;
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                                    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                                }
                                this.dataGridView1.Rows[num5].Cells[3].Value = "TOTAL GROSS/NET PROFIT";
                                this.dataGridView1.Rows[num5].Cells[12].Value =  $"{sum:N}";
                                this.dataGridView1.Rows[num5].Cells[13].Value = $"{sum1:N}";
                                //this.dataGridView1.Rows[num5].Cells[3].Value = "NET SALES: " + $"{(num - num2):N}";
                                //this.report = "Quantity Sales Report For All Cashier Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = reader.GetString("S/N");
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("PRODUCT CODE");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("PRODUCT DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("PRODUCT CATEGORY");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("QTY SOLD");
                            this.dataGridView1.Rows[num4].Cells[6].Value = reader.GetString("COST PRICE");
                            this.dataGridView1.Rows[num4].Cells[7].Value = reader.GetString("SELLING PRICE");
                            this.dataGridView1.Rows[num4].Cells[10].Value = reader.GetString("DISCOUNT");
                            decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value);
                            decimal num10 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value);
                            decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                            decimal num12 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[10].Value);
                            decimal num13 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[11].Value);
                            decimal num14 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[12].Value);
                            this.dataGridView1.Rows[num4].Cells[8].Value = num7 * num8;
                            this.dataGridView1.Rows[num4].Cells[9].Value = num7 * num9;
                            this.dataGridView1.Rows[num4].Cells[12].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value));
                            this.dataGridView1.Rows[num4].Cells[11].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[10].Value));
                            this.dataGridView1.Rows[num4].Cells[13].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[11].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value));

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.LoadCombo(this.desc, "SELECT * FROM prod_category", "category");

                //string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',SUM(QTY) AS 'QTY SOLD', UNIT AS 'UNIT'  FROM sales_detail WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY prod_code " };
                string[] strArray = new string[] { "SELECT recieptno AS 'S/N',PDATE AS 'POSTING DATE',PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',category AS 'PRODUCT CATEGORY',QTY AS 'QTY SOLD',CP AS 'COST PRICE',SP AS 'SELLING PRICE',DISCOUNT AS 'DISCOUNT' FROM sales_detail_qty WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"),"'" };
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
                                int sum1 = 0;
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                                    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                                }
                                this.dataGridView1.Rows[num5].Cells[3].Value = "TOTAL GROSS/NET PROFIT";
                                this.dataGridView1.Rows[num5].Cells[12].Value = $"{sum:N}";
                                this.dataGridView1.Rows[num5].Cells[13].Value = $"{sum1:N}";
                                //this.dataGridView1.Rows[num5].Cells[3].Value = "NET SALES: " + $"{(num - num2):N}";
                                //this.report = "Quantity Sales Report For All Cashier Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("PRODUCT CODE");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("PRODUCT DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("PRODUCT CATEGORY");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("QTY SOLD");
                            this.dataGridView1.Rows[num4].Cells[6].Value = reader.GetString("COST PRICE");
                            this.dataGridView1.Rows[num4].Cells[7].Value = reader.GetString("SELLING PRICE");
                            this.dataGridView1.Rows[num4].Cells[10].Value = reader.GetString("DISCOUNT");
                            decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value);
                            decimal num10 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value);
                            decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                            decimal num12 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[10].Value);
                            decimal num13 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[11].Value);
                            decimal num14 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[12].Value);
                            this.dataGridView1.Rows[num4].Cells[8].Value = num7 * num8;
                            this.dataGridView1.Rows[num4].Cells[9].Value = num7 * num9;
                            this.dataGridView1.Rows[num4].Cells[12].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value));
                            this.dataGridView1.Rows[num4].Cells[11].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[10].Value));
                            this.dataGridView1.Rows[num4].Cells[13].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[11].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value));

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

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.LoadCombo(this.desc, "SELECT * FROM user_reg", "username");

                //string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',SUM(QTY) AS 'QTY SOLD', UNIT AS 'UNIT'  FROM sales_detail WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY prod_code " };
                string[] strArray = new string[] { "SELECT recieptno AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',category AS 'PRODUCT CATEGORY',QTY AS 'QTY SOLD',CP AS 'COST PRICE',SP AS 'SELLING PRICE' FROM sales_detail_qty WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
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
                                //this.dataGridView1.Rows[num5].Cells[1].Value = "TOTAL SALES: " + $"{num:N}";
                                //this.dataGridView1.Rows[num5].Cells[2].Value = "DISCOUNT SALES: " + $"{num2:N}";
                                //this.dataGridView1.Rows[num5].Cells[3].Value = "NET SALES: " + $"{(num - num2):N}";
                                this.report = "Quantity Sales Report For All Cashier Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
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
                            decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            decimal num10 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value);
                            decimal num11 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value);
                            this.dataGridView1.Rows[num4].Cells[7].Value = num7 * num8;
                            this.dataGridView1.Rows[num4].Cells[8].Value = num7 * num9;
                            this.dataGridView1.Rows[num4].Cells[9].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value));

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
            try
            {
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.ForeColor = Color.Maroon;
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
                    TitleColor = Color.Maroon,
                    SubTitleColor = Color.Maroon,
                    Title = Program.companyName + "\n"
                };
                printer.TitleFont = new Font("verdana", 16f, FontStyle.Bold);
                printer.Title = printer.Title + Program.companyAddressA4;
                printer.Title = printer.Title + "\n" + Program.companyPhone + "\n Product Profit Analysis Report By Projection";
                printer.SubTitle = "\nFrom :   " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "\t   To :   " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                printer.SubTitle += "\n\n";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Left = 15;
                printer.PrintMargins.Right = 15;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.SubTitleAlignment = StringAlignment.Near;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                printer.FooterSpacing = 15f;
                printer.PageSettings.Landscape = true;
                printer.PrintPreviewDataGridView(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }
    }
}