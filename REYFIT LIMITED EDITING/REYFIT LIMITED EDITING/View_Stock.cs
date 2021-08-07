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
    public partial class View_Stock : Form
    {
        public static string identify = "25";
        private General gclass = new General();
        public View_Stock()
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
                    Title = Program.companyName,
                    SubTitle = Program.companyAddressA4
                };
                string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                printer.SubTitle = string.Concat(strArray);
                printer.SubTitle = printer.SubTitle + "\nPHYSICAL STOCK COUNT\n";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Left = 15;
                printer.PrintMargins.Right = 15;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = false;
                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "     p     " + $"{DateTime.Now:T}";
                printer.FooterSpacing = 15f;
                printer.PageSettings.Landscape = true;
                printer.PrintPreviewDataGridView(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void View_Stock_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.DGVTable("SELECT id AS 'S/N',code AS 'PRODUCT CODE',description AS 'PRODUCT DESCRIPTION',stk AS 'STOCK',qty AS 'PHYSICAL STOCK QTY',qty AS 'VARIANCE',status AS 'STATUS' FROM tbl_stock_list ", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[5].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[3].Value) + Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[4].Value)).ToString();
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.gclass.DGVTable("SELECT id AS 'S/N',code AS 'PRODUCT CODE',description AS 'PRODUCT DESCRIPTION',stk AS 'STOCK',qty AS 'PHYSICAL STOCK QTY',qty AS 'VARIANCE',status AS 'STATUS' FROM tbl_stock_list ", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[5].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[3].Value) + Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[4].Value)).ToString();
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.gclass.DGVTable("SELECT id AS 'S/N',code AS 'PRODUCT CODE',description AS 'PRODUCT DESCRIPTION',stk AS 'STOCK',qty AS 'PHYSICAL STOCK QTY',qty AS 'VARIANCE',status AS 'STATUS' FROM tbl_stock_list WHERE status = 'POSTED' ", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[5].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[3].Value) + Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[4].Value)).ToString();
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.gclass.DGVTable("SELECT id AS 'S/N',code AS 'PRODUCT CODE',description AS 'PRODUCT DESCRIPTION',stk AS 'STOCK',qty AS 'PHYSICAL STOCK QTY',qty AS 'VARIANCE',status AS 'STATUS' FROM tbl_stock_list WHERE status = 'UNPOSTED' ", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[5].Value = (Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[3].Value) + Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[4].Value)).ToString();
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
