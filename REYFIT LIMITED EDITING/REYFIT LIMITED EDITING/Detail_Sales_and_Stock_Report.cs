using System;
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
    public partial class Detail_Sales_and_Stock_Report : Form
    {
        private General gclass = new General();
        private decimal TotalReceived = 0M;
        private decimal TotalReturned = 0M;
        private decimal TotalOthers = 0M;
        private decimal TotalSales = 0M;
        private decimal TotalSalesV = 0M;
        private decimal OSalesV = 0M;
        private decimal TotalTransfer = 0M;
        private decimal TotalDispose = 0M;
        private decimal TotalOthers2 = 0M;
        public Detail_Sales_and_Stock_Report()
        {
            InitializeComponent();
        }

        private void Detail_Sales_and_Stock_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Hide();
            new Report().ShowDialog();
        }

        private void Detail_Sales_and_Stock_Report_Load(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            new MySqlDataAdapter(new MySqlCommand(Report.reportquery.ToString(), this.gclass.conn())).Fill(dataSet);
            this.dataGridView3.DataSource = dataSet.Tables[0].DefaultView;
            DataSet set2 = new DataSet();
            new MySqlDataAdapter(new MySqlCommand(Report.reportquery2.ToString(), this.gclass.conn())).Fill(set2);
            this.dataGridView2.DataSource = set2.Tables[0].DefaultView;
            int num = 0;
            while (true)
            {
                bool flag = num < this.dataGridView2.Rows.Count;
                if (!flag)
                {
                    string[] source = new string[this.dataGridView2.Rows.Count];
                    int count = this.dataGridView2.Rows.Count;
                    int index = 0;
                    while (true)
                    {
                        flag = index < count;
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
                                        this.dataGridView1.Rows.Add();
                                        int num4 = this.dataGridView1.Rows.Count - 1;
                                        this.dataGridView1.Rows[num4].Cells[0].Value = this.dataGridView1.Rows.Count;
                                        this.dataGridView1.Rows[num4].Cells[1].Value = current.ToString();
                                        int num5 = 0;
                                        while (true)
                                        {
                                            flag = num5 < this.dataGridView2.Rows.Count;
                                            if (!flag)
                                            {
                                                index = 0;
                                                while (true)
                                                {
                                                    flag = index < this.dataGridView3.Rows.Count;
                                                    if (!flag)
                                                    {
                                                        this.dataGridView1.Rows[num4].Cells[5].Value = this.TotalReceived;
                                                        this.dataGridView1.Rows[num4].Cells[6].Value = this.TotalReturned;
                                                        this.dataGridView1.Rows[num4].Cells[7].Value = this.TotalOthers;
                                                        this.dataGridView1.Rows[num4].Cells[8].Value = ((this.TotalReceived + this.TotalReturned) + this.TotalOthers).ToString();
                                                        this.dataGridView1.Rows[num4].Cells[10].Value = this.TotalSales;
                                                        this.dataGridView1.Rows[num4].Cells[11].Value = this.TotalTransfer;
                                                        this.dataGridView1.Rows[num4].Cells[12].Value = this.TotalDispose;
                                                        this.dataGridView1.Rows[num4].Cells[13].Value = this.TotalOthers2;
                                                        this.dataGridView1.Rows[num4].Cells[14].Value = (((this.TotalSales + this.TotalTransfer) + this.TotalDispose) + this.TotalOthers2).ToString();
                                                        this.dataGridView1.Rows[num4].Cells[0x10].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[3].Value.ToString()) + Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value.ToString())) - Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[14].Value.ToString());
                                                        this.dataGridView1.Rows[num4].Cells[0x11].Value = $"{this.TotalSalesV:N}";
                                                        this.OSalesV += this.TotalSalesV;
                                                        this.TotalSalesV = 0M;
                                                        this.TotalDispose = 0M;
                                                        this.TotalOthers = 0M;
                                                        this.TotalOthers2 = 0M;
                                                        this.TotalReceived = 0M;
                                                        this.TotalReturned = 0M;
                                                        this.TotalSales = 0M;
                                                        this.TotalTransfer = 0M;
                                                        break;
                                                    }
                                                    if (this.dataGridView1.Rows[num4].Cells[1].Value.ToString() == this.dataGridView3.Rows[index].Cells[4].Value.ToString())
                                                    {
                                                        this.TotalSalesV += Convert.ToDecimal(this.dataGridView3.Rows[index].Cells[9].Value);
                                                    }
                                                    index++;
                                                }
                                                break;
                                            }
                                            string str2 = this.dataGridView2.Rows[num5].Cells[3].Value.ToString();
                                            string str3 = current.ToString();
                                            if (str3 == str2)
                                            {
                                                this.dataGridView1.Rows[num4].Cells[2].Value = this.dataGridView2.Rows[num5].Cells[4].Value.ToString();
                                                int num6 = 3;
                                                while (true)
                                                {
                                                    flag = num6 < 0x12;
                                                    if (!flag)
                                                    {
                                                        this.dataGridView1.Rows[num4].Cells[4].Value = "";
                                                        this.dataGridView1.Rows[num4].Cells[9].Value = "";
                                                        this.dataGridView1.Rows[num4].Cells[15].Value = "";
                                                        this.dataGridView1.Rows[num4].Cells[3].Value = this.dataGridView2.Rows[num5].Cells[5].Value.ToString();
                                                        string str4 = this.dataGridView2.Rows[num5].Cells[2].Value.ToString();
                                                        if ((str4 == "PURCHASE") || (str4 == "RECEIVED"))
                                                        {
                                                            this.TotalReceived += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        else if (str4 == "SALES RETURN")
                                                        {
                                                            this.TotalReturned += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        else if ((str4 == "STOCK BALANCE") || (str4 == "OPENING STOCK"))
                                                        {
                                                            this.TotalOthers += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        else if ((str4 == "SALES INVOICE") || (str4 == "POS"))
                                                        {
                                                            this.TotalSales += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        else if (str4 == "TRANSFERED")
                                                        {
                                                            this.TotalTransfer += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        else if (str4 == "DISPOSE")
                                                        {
                                                            this.TotalDispose += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        else if ((str4 == "STOCK BALANCE") || (str4 == "OPENING STOCK"))
                                                        {
                                                            this.TotalOthers2 += Convert.ToDecimal(this.dataGridView2.Rows[num5].Cells[6].Value);
                                                        }
                                                        break;
                                                    }
                                                    this.dataGridView1.Rows[num4].Cells[num6].Value = "0";
                                                    num6++;
                                                }
                                            }
                                            num5++;
                                        }
                                    }
                                }
                            }
                            return;
                        }
                        source[index] = Convert.ToString(this.dataGridView2.Rows[index].Cells[3].Value).ToString();
                        index++;
                    }
                }
                this.dataGridView2.Rows[num].Cells[0].Value = num + 1;
                num++;
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
                this.dataGridView1.Columns[4].Visible = false;
                this.dataGridView1.Columns[9].Visible = false;
                this.dataGridView1.Columns[15].Visible = false;
                this.dataGridView1.Columns[1].Visible = false;
                DGVPrinter printer = new DGVPrinter
                {
                    TitleColor = Color.Maroon,
                    SubTitleColor = Color.Black,
                    Title = Program.companyName + "\n",
                    SubTitle = Program.companyAddressA4
                };
                string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                printer.SubTitle = string.Concat(strArray);
                printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \nDETAIL SALES AND STOCK REPORT\n ";
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

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }
    }
}
