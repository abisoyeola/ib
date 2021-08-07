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
    public partial class View_Cash_Account : Form
    {
        private string report = null;
        private General gclass = new General();
        public static string identify = "26";
        public View_Cash_Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strArray;
                string cmdText = "";
                string query = "";
                if (this.desc.SelectedIndex <= -1)
                {
                    strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                    cmdText = string.Concat(strArray);
                    this.report = "Inflow/Outflow Cash Account Report Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                    //strArray = new string[] { "SELECT discount  FROM sales_detail_qty WHERE postedby = '", this.desc.Text, "' AND pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
                    query = string.Concat(strArray);
                }
                else
                {
                    strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                    cmdText = string.Concat(strArray);
                    strArray = new string[] { "Inflow/Outflow Cash Account Report :  ", this.desc.Text, " Between ", this.dateTimePicker1.Text, "  To  ", this.dateTimePicker2.Text };
                    this.report = string.Concat(strArray);
                    //strArray = new string[] { "SELECT discount  FROM sales_detail_qty WHERE postedby = '", this.desc.Text, "' AND pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
                    query = string.Concat(strArray);
                }
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
                                //this.dataGridView1.Rows.Add();
                                //int num5 = this.dataGridView1.Rows.Count - 1;
                                //int sum = 0;
                                //int sum1 = 0;
                                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                //{
                                //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                //    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                //}
                                //this.dataGridView1.Rows[num5].Cells[1].Value = "TOTAL SALES:";
                                //this.dataGridView1.Rows[num5].Cells[4].Value = sum.ToString();
                                //this.dataGridView1.Rows[num5].Cells[5].Value = sum1.ToString();
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("REFERENCE NO");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("INFLOW AMT");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("OUTFLOW AMT");
                            decimal sum = 0;
                            decimal sum1 = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }
                            decimal tot_inflow = 0;
                            decimal tot_outflow = 0;
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                tot_inflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                tot_outflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }

                            if (tot_inflow == 0)
                            {

                            }
                            if (tot_outflow == 0)
                            {

                            }
                            inflow.Text = tot_inflow.ToString();
                            outflow.Text = tot_outflow.ToString();
                            this.inflow.Text = $"{Convert.ToDecimal(this.inflow.Text):N}";
                            this.outflow.Text = $"{Convert.ToDecimal(this.outflow.Text):N}";
                            this.balance.Text = $"{(Convert.ToDecimal(this.inflow.Text) - Convert.ToDecimal(this.outflow.Text)):N}".ToString();
                            //this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("UNIT");
                            //decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            //decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            //decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            //this.dataGridView1.Rows[num4].Cells[6].Value = num9 + num7 - num8;
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
                MySqlConnection connection = gclass.conn();

                //string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',SUM(QTY) AS 'QTY SOLD', UNIT AS 'UNIT'  FROM sales_detail WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY prod_code " };
                string[] strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                string cmdText = string.Concat(strArray);
                //strArray = new string[] { "SELECT discount  FROM sales_detail_qty WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
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
                                //this.dataGridView1.Rows.Add();
                                //int num5 = this.dataGridView1.Rows.Count - 1;
                                //int sum = 0;
                                //int sum1 = 0;
                                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                //{
                                //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                //    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                //}
                                //this.dataGridView1.Rows[num5].Cells[1].Value = "TOTAL SALES:";
                                //this.dataGridView1.Rows[num5].Cells[4].Value = sum.ToString();
                                //this.dataGridView1.Rows[num5].Cells[5].Value = sum1.ToString();
                                this.report = "Inflow/Outflow Cash Account Report Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("REFERENCE NO");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("INFLOW AMT");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("OUTFLOW AMT");
                            decimal sum = 0;
                            decimal sum1 = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }
                            decimal tot_inflow = 0;
                            decimal tot_outflow = 0;
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                tot_inflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                tot_outflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }

                            if (tot_inflow == 0)
                            {

                            }
                            if (tot_outflow == 0)
                            {

                            }
                            inflow.Text = tot_inflow.ToString();
                            outflow.Text = tot_outflow.ToString();
                            this.inflow.Text = $"{Convert.ToDecimal(this.inflow.Text):N}";
                            this.outflow.Text = $"{Convert.ToDecimal(this.outflow.Text):N}";
                            this.balance.Text = $"{(Convert.ToDecimal(this.inflow.Text) - Convert.ToDecimal(this.outflow.Text)):N}".ToString();
                            //decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            //decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            //decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            //this.dataGridView1.Rows[num4].Cells[6].Value = num9 + num7 - num8;
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

        private void Sales_Report_Qty_By_Total_Load(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.LoadCombo(this.desc, "SELECT * FROM user_reg", "username");

                //string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',SUM(QTY) AS 'QTY SOLD',unit AS 'UNIT'  FROM sales_detail WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY prod_code " };
                string[] strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                string cmdText = string.Concat(strArray);
                //strArray = new string[] { "SELECT discount  FROM sales_detail_qty_total WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };

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
                                this.report = "Inflow/Outflow Cash Account Report Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("REFERENCE NO");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("INFLOW AMT");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("OUTFLOW AMT");
                            //this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("UNIT");
                            //decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            //decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            //decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            //this.dataGridView1.Rows[num4].Cells[6].Value = num9 + num7 - num8;
                            decimal sum = 0;
                            decimal sum1 = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }
                            decimal tot_inflow = 0;
                            decimal tot_outflow = 0;
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                tot_inflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                tot_outflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }

                            if (tot_inflow == 0)
                            {

                            }
                            if (tot_outflow == 0)
                            {

                            }
                            inflow.Text = tot_inflow.ToString();
                            outflow.Text = tot_outflow.ToString();
                            this.inflow.Text = $"{Convert.ToDecimal(this.inflow.Text):N}";
                            this.outflow.Text = $"{Convert.ToDecimal(this.outflow.Text):N}";
                            this.balance.Text = $"{(Convert.ToDecimal(this.inflow.Text) - Convert.ToDecimal(this.outflow.Text)):N}".ToString();
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
            try
            {
                string[] strArray;
                string cmdText = "";
                string query = "";
                if (this.desc.SelectedIndex <= -1)
                {
                    strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                    cmdText = string.Concat(strArray);
                    this.report = "Inflow/Outflow Cash Account Report Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                    //strArray = new string[] { "SELECT discount  FROM sales_detail_qty_total WHERE postedby = '", this.desc.Text, "' AND pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
                    query = string.Concat(strArray);
                }
                else
                {
                    strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                    cmdText = string.Concat(strArray);
                    strArray = new string[] { "Inflow/Outflow Cash Account Report :  ", this.desc.Text, " Between ", this.dateTimePicker1.Text, "  To  ", this.dateTimePicker2.Text };
                    this.report = string.Concat(strArray);
                    //strArray = new string[] { "SELECT discount  FROM sales_detail_qty_total WHERE postedby = '", this.desc.Text, "' AND pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
                    query = string.Concat(strArray);
                }
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
                                //this.dataGridView1.Rows.Add();
                                //int num5 = this.dataGridView1.Rows.Count - 1;
                                //int sum = 0;
                                //int sum1 = 0;
                                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                //{
                                //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                //    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                //}
                                //this.dataGridView1.Rows[num5].Cells[1].Value = "TOTAL SALES:";
                                //this.dataGridView1.Rows[num5].Cells[4].Value = sum.ToString();
                                //this.dataGridView1.Rows[num5].Cells[5].Value = sum1.ToString();
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("REFERENCE NO");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("INFLOW AMT");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("OUTFLOW AMT");
                            decimal sum = 0;
                            decimal sum1 = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }
                            decimal tot_inflow = 0;
                            decimal tot_outflow = 0;
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                tot_inflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                tot_outflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }

                            if (tot_inflow == 0)
                            {

                            }
                            if (tot_outflow == 0)
                            {

                            }
                            inflow.Text = tot_inflow.ToString();
                            outflow.Text = tot_outflow.ToString();
                            this.inflow.Text = $"{Convert.ToDecimal(this.inflow.Text):N}";
                            this.outflow.Text = $"{Convert.ToDecimal(this.outflow.Text):N}";
                            this.balance.Text = $"{(Convert.ToDecimal(this.inflow.Text) - Convert.ToDecimal(this.outflow.Text)):N}".ToString();
                            //decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            //decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            //decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            //this.dataGridView1.Rows[num4].Cells[6].Value = num9 + num7 - num8;
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
                //SubTitle = Program.companyAddressA4
            };
            //string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
            //printer.SubTitle = string.Concat(strArray);
            //printer.SubTitle = printer.SubTitle + "\n" + this.report + " \n\n";
            printer.TitleFont = new Font("verdana", 12f, FontStyle.Bold);
            printer.SubTitleFont = new Font("verdana", 10f, FontStyle.Bold);
            printer.FooterAlignment = StringAlignment.Center;
            printer.Title = printer.Title + Program.companyAddressA4;
            printer.Title = printer.Title + "\n" + Program.companyPhone + "\n" + this.report + "\n\n";
            printer.SubTitle += "\n Total Inflow Amount:   " + inflow.Text;
            printer.SubTitle += "\n Total Outflow Amount:   " + outflow.Text;
            printer.SubTitle += "\n Total Balance Amount:   " + balance.Text;
            printer.SubTitle += "\n\n";
            printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            printer.PageNumbers = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
            printer.PrintMargins.Left = 10;
            printer.PrintMargins.Right = 10;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.SubTitleAlignment = StringAlignment.Near;
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

            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.LoadCombo(this.desc, "SELECT * FROM user_reg", "username");
                MySqlConnection connection = gclass.conn();

                //string[] strArray = new string[] { "SELECT ID AS 'S/N', PROD_CODE AS 'PRODUCT CODE',DESCRIPTION AS 'PRODUCT DESCRIPTION',SUM(QTY) AS 'QTY SOLD',unit AS 'UNIT'  FROM sales_detail WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY prod_code " };
                string[] strArray = new string[] { "SELECT ID AS 'S/N',PDATE AS 'POSTING DATE',REFERENCE_NO AS 'REFERENCE NO',DESCRIPTION AS 'DESCRIPTION',INFLOW AS 'INFLOW AMT',OUTFLOW AS 'OUTFLOW AMT' FROM cash_account WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                string cmdText = string.Concat(strArray);
                //strArray = new string[] { "SELECT discount  FROM sales_detail_qty_total WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' " };
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
                                //this.dataGridView1.Rows.Add();
                                //int num5 = this.dataGridView1.Rows.Count - 1;
                                //int sum = 0;
                                //int sum1 = 0;
                                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                //{
                                //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                //    sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                //}
                                //this.dataGridView1.Rows[num5].Cells[1].Value = "TOTAL SALES:";
                                //this.dataGridView1.Rows[num5].Cells[4].Value = sum.ToString();
                                //this.dataGridView1.Rows[num5].Cells[5].Value = sum1.ToString();
                                this.report = "Inflow/Outflow Cash Account Report Between " + this.dateTimePicker1.Text + "  To  " + this.dateTimePicker2.Text;
                                break;
                            }
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("POSTING DATE");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("REFERENCE NO");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("DESCRIPTION");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("INFLOW AMT");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("OUTFLOW AMT");
                            decimal sum = 0;
                            decimal sum1 = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }
                            decimal tot_inflow = 0;
                            decimal tot_outflow = 0;
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                tot_inflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                                tot_outflow += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            }

                            if (tot_inflow == 0)
                            {

                            }
                            if (tot_outflow == 0)
                            {

                            }
                            inflow.Text = tot_inflow.ToString();
                            outflow.Text = tot_outflow.ToString();
                            this.inflow.Text = $"{Convert.ToDecimal(this.inflow.Text):N}";
                            this.outflow.Text = $"{Convert.ToDecimal(this.outflow.Text):N}";
                            this.balance.Text = $"{(Convert.ToDecimal(this.inflow.Text) - Convert.ToDecimal(this.outflow.Text)):N}".ToString();
                            //decimal num7 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            //decimal num8 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            //decimal num9 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            //this.dataGridView1.Rows[num4].Cells[6].Value = num9 + num7 - num8;
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
