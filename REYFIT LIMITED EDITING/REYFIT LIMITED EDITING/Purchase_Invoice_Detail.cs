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
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
namespace POS_SALES
{
    public partial class Purchase_Invoice_Detail : Form
    {
        private General gclass = new General();
        public Purchase_Invoice_Detail()
        {
            InitializeComponent();
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
                printer.Title = printer.Title + Program.companyAddressA4;
                printer.Title = printer.Title + "\n" + Program.companyPhone + "\n DETAIL PURCHASE INVOICE REPORT";
                //string[] strArray = new string[] { printer.SubTitle, "     Date :   ", this.label2.Text, "\n     Vendor :    ", this.label4.Text, "\n     Invoice No:    ", this.label6.Text.ToUpper(), "\n Total Invoice Amount :    ", $"{Convert.ToDecimal(this.label7.Text):N}" };
                //strArray[9] = "\n\n";
                printer.SubTitle =  "\n Date :   " + label2.Text;
                printer.SubTitle += "\n Vendor :  " + label4.Text.ToUpper();
                printer.SubTitle += "\n Invoice No:    " + label6.Text.ToUpper();
                printer.SubTitle += "\n Total Invoice Amount :    " + label7.Text;
                printer.SubTitle += "\n\n";
                //printer.SubTitle = string.Concat(strArray);
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

        private void Purchase_Invoice_Detail_Load(object sender, EventArgs e)
        {
            try
            {
                this.label7.Text = Purchase.tot;
                this.label2.Text = Purchase.date1;
                this.label6.Text = Purchase.ordn;
                this.label4.Text = Purchase.ven;
                this.gclass.DGVTable("SELECT id as 'S/N',code as 'PRODUCT CODE',description as 'DESCRIPTION',qty as 'QUANTITY',cp as 'COST PRICE',total as 'TOTAL' FROM invoice_detail WHERE purcase_id = '" + Purchase.purid + "'", this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
