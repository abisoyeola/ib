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
    public partial class Stock_Position_Summary : Form
    {
        private string report = "EMPTIES STOCK POSITION SUMMARY";
        General gclass = new General();
        public Stock_Position_Summary()
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
            MySqlConnection cn = gclass.conn();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT CODE AS 'PRODUCT CODE', dept AS 'PRODUCT CATEGORY', SUM(stk_empty) AS 'STOCK EMPTY', ws AS 'EMPTY BOTTLE PRICE' FROM product GROUP BY dept", cn);
            MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
            DataSet DTS = new DataSet();
            ADPO.Fill(DTS);
            dataGridView1.DataSource = DTS.Tables[0].DefaultView;
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
