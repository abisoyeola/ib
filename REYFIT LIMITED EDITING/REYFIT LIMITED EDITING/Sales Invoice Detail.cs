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
    public partial class Sales_Invoice_Detail : Form
    {
        private General gclass = new General();
        public Sales_Invoice_Detail()
        {
            InitializeComponent();
        }

        private void Sales_Invoice_Detail_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblCashier.Text = Sales_Invoice_Report.kashier;
                this.lbldate.Text = Sales_Invoice_Report.pdate;
                //this.lbldoc_no.Text = Sales_Invoice_Report.doc_no;
                this.lblrpn.Text = Sales_Invoice_Report.rptn;
                this.lblTotal.Text = Sales_Invoice_Report.total_amount;
                this.gclass.DGVTable("SELECT id as 'S/N',prod_code as 'PRODUCT CODE',description as 'PRODUCT DESCRIPTION',qty as 'QUANTITY BOUGHT',unit as 'UNIT PRICE',total as 'AMOUNT' FROM sales_invoice_detail WHERE recieptno = '" + this.lblrpn.Text + "'", this.dataGridView1);
                int count = this.dataGridView1.Rows.Count;
                int num2 = 0;
                while (true)
                {
                    if (num2 >= count)
                    {
                        this.dataGridView1.Columns[2].Width = 200;
                        break;
                    }
                    this.dataGridView1.Rows[num2].Cells[0].Value = num2 + 1;
                    num2++;
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
                printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \nSALES INVOICE DETAIL\n ";
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
    }
}
