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
namespace POS_SALES
{
    public partial class Sales_Analysis_Profile : Form
    {
        private General gclass = new General();
        public Sales_Analysis_Profile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.ForeColor = Color.Black;
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 10f);
                this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
                DGVPrinter printer = new DGVPrinter
                {
                    TitleColor = Color.Black,
                    SubTitleColor = Color.Black,
                    Title = Program.companyName + "\n",
                    SubTitle = Program.companyAddressA4
                };
                string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                printer.SubTitle = string.Concat(strArray);
                printer.SubTitle = printer.SubTitle + "\n" + this.textBox1.Text + "\n";
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

        private void Sales_Analysis_Profile_Load(object sender, EventArgs e)
        {
            try
            {
                if (Report.iden == "0")
                {
                    this.gclass.DGVTable("SELECT * FROM sales_detail ", this.dataGridView2);
                }
                else
                {
                    this.gclass.DGVTable("SELECT * FROM sales_detail WHERE pdate BETWEEN '" + Report.reportfrom + "' AND '" + Report.reportto + "' ", this.dataGridView2);
                }
                this.textBox1.Text = Report.reportTitle;
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM prod_category", this.gclass.conn()).ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Read();
                        int count = this.dataGridView1.Rows.Count;
                        decimal num3 = 0M;
                        decimal num4 = 0M;
                        decimal num5 = 0M;
                        int num6 = 0;
                        while (true)
                        {
                            if (num6 >= count)
                            {
                                this.dataGridView1.Rows.Add();
                                int num12 = this.dataGridView1.Rows.Count - 1;
                                this.dataGridView1.Rows[num12].Cells[0].Value = "GRAND TOTAL";
                                this.dataGridView1.Rows[num12].Cells[1].Value = $"{num3:N}";
                                this.dataGridView1.Rows[num12].Cells[2].Value = $"{num4:N}";
                                this.dataGridView1.Rows[num12].Cells[3].Value = $"{num5:N}";
                                this.dataGridView1.Rows[num12].Cells[4].Value = "-";
                                this.dataGridView1.Rows[num12].Cells[5].Value = "-";
                                this.dataGridView1.Rows[num12].Cells[6].Value = ".00";
                                Color color = Color.FromArgb(0xff, 0xe0, 0xc0);
                                this.dataGridView1.Rows[num12].DefaultCellStyle.BackColor = color;
                                this.dataGridView1.Rows[num12].DefaultCellStyle.Font = new Font("verdana", 8f, FontStyle.Bold);
                                break;
                            }
                            decimal num7 = 0M;
                            decimal num8 = 0M;
                            int num10 = 0;
                            while (true)
                            {
                                flag = num10 < this.dataGridView2.Rows.Count;
                                if (!flag)
                                {
                                    num3 += num8;
                                    num4 += num7;
                                    num5 += Convert.ToDecimal(this.dataGridView1.Rows[num6].Cells[3].Value);
                                    num6++;
                                    break;
                                }
                                if (this.dataGridView2.Rows[num10].Cells[4].Value.ToString().Substring(0, 1) == this.dataGridView1.Rows[num6].Cells[0].Value.ToString().Substring(0, 1))
                                {
                                    if (this.dataGridView2.Rows[num10].Cells[13].Value.ToString().Length == 0)
                                    {
                                        this.dataGridView2.Rows[num10].Cells[13].Value = 0;
                                    }
                                    num7 += Convert.ToDecimal(this.dataGridView2.Rows[num10].Cells[9].Value.ToString());
                                    num8 += Convert.ToDecimal(this.dataGridView2.Rows[num10].Cells[13].Value.ToString());
                                }
                                this.dataGridView1.Rows[num6].Cells[1].Value = $"{num8:N}";
                                this.dataGridView1.Rows[num6].Cells[2].Value = $"{num7:N}";
                                this.dataGridView1.Rows[num6].Cells[3].Value = $"{num7 - num8:N}";
                                decimal num11 = (num7 - num8) * 100M;
                                this.dataGridView1.Rows[num6].Cells[6].Value = ".00";
                                num10++;
                            }
                        }
                        break;
                    }
                    this.listBox1.Items.Add(reader.GetString("code"));
                    this.dataGridView1.Rows.Add();
                    int num = this.dataGridView1.Rows.Count - 1;
                    this.dataGridView1.Rows[num].Cells[0].Value = reader.GetString("code") + "-" + reader.GetString("category");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
