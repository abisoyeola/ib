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
using System.Collections;

namespace POS_SALES
{
    public partial class Stock_Report : Form
    {
        private General gclass = new General();
        private rpt Column = new rpt();
        public Stock_Report()
        {
            InitializeComponent();
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
                    SubTitleColor = Color.Black,
                    Title = Program.companyName + "\n",
                    SubTitle = Program.companyAddressA4
                };
                string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                printer.SubTitle = string.Concat(strArray);
                printer.SubTitle = printer.SubTitle + "\n\n" + Report.reportTitle.ToUpper() + " \n\n";
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
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void Stock_Report_Load(object sender, EventArgs e)
        {
            try
            {
                int count;
                if (Report.reportid == "rp7")
                {
                    this.Column.rp7(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    count = this.dataGridView1.Rows.Count;
                    this.dataGridView1.Columns[0].Width = 50;
                    this.dataGridView1.Columns[2].Width = 200;
                    this.dataGridView1.Columns[3].Width = 100;
                }
                else if (Report.reportid == "rp29")
                {
                    this.Column.rp29(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    count = this.dataGridView1.Rows.Count;
                    this.dataGridView1.Columns[0].Width = 50;
                    this.dataGridView1.Columns[2].Width = 200;
                    this.dataGridView1.Columns[3].Width = 100;
                }
                else if (Report.reportid == "rp8")
                {
                    this.Column.rp8(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    count = this.dataGridView1.Rows.Count;
                    this.dataGridView1.Columns[0].Width = 70;
                    this.dataGridView1.Columns[2].Width = 200;
                    this.dataGridView1.Columns[3].Width = 100;
                }
                else if (Report.reportid == "rp30")
                {
                    this.Column.rp30(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    count = this.dataGridView1.Rows.Count;
                    this.dataGridView1.Columns[0].Width = 70;
                    this.dataGridView1.Columns[2].Width = 200;
                    this.dataGridView1.Columns[3].Width = 100;
                }
                else if (Report.reportid == "rp9")
                {
                    this.Column.rp9(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    count = this.dataGridView1.Rows.Count;
                    this.dataGridView1.Columns[0].Width = 70;
                    this.dataGridView1.Columns[2].Width = 200;
                    this.dataGridView1.Columns[3].Width = 100;
                }
                else if (Report.reportid == "rp11")
                {
                    this.Column.rp11(this.dataGridView1, Report.reportquery, this.gclass.conn());
                    count = this.dataGridView1.Rows.Count;
                    this.dataGridView1.Columns[0].Width = 70;
                    this.dataGridView1.Columns[2].Width = 200;
                    this.dataGridView1.Columns[3].Width = 100;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Stock_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                base.Hide();
                new Report().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
