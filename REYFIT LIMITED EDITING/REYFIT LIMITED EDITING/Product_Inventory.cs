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
namespace POS_SALES
{
    public partial class Product_Inventory : Form
    {
        public static string id = "";
        public static string pro_co = "";
        public static string pro_de = "";
        public static string pro_ca = "";
        public static string exp_da = "";
        public static string qty_lim = "";
        public static string co_pr = "";
        public static string se_pr = "";
        public static string pa_pr = "";
        public static string qty_pri = "";
        public static string bar = "";
        public static string inve = "";
        public static string lpc = "";
        public static string lpd = "";
        public static string go = "";
        private General gclass = new General();
        public static string code = "";
        public static string identify = "9";
        public static string x = null;
        public Product_Inventory()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                base.Hide();
                new Add_Product().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                code = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                base.Hide();
                new Products_Card().ShowDialog();
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
                this.dataGridView1.Columns[11].Visible = false;
                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[13].Visible = false;
                this.dataGridView1.Columns[1].Width = 110;
                this.dataGridView1.Columns[2].Width = 110;
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
                printer.SubTitle = printer.SubTitle + "\nPRODUCT LISTING\n";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Left = 15;
                printer.PrintMargins.Right = 15;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = false;
                printer.HeaderCellAlignment = StringAlignment.Center;
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
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.toolStripComboBox1.SelectedIndex == 1)
                {
                    this.gclass.DGVTable("SELECT id as 'S/N',barcode as 'BARCODE',code as 'PRODUCT CODE',description as 'PRODUCT DESCRIPTION',DEPT AS 'PRODUCT CATEGORY',STK AS 'STOCK LIQUID',STK_EMPTY AS 'STOCK EMPTY',CP AS 'COST PRICE',S_P AS 'RETAIL SELLING PRICE',WS AS 'EMPTY BOTTLE PRICE',WP_QTY AS 'PACK QUANTITY',ODR_limit AS 'RE-ORDER QTY LIMIT',LPC AS 'LAST PURCHASE COST',LPD AS 'LAST PURCHASE DATE',EXP_DATE AS 'EXPIRY DATE' FROM product WHERE description LIKE '%" + this.desc.Text + "%' ", this.dataGridView1);
                    int num = 0;
                    while (true)
                    {
                        if (num >= this.dataGridView1.Rows.Count)
                        {
                            break;
                        }
                        this.dataGridView1.Rows[num].Cells[0].Value = num + 1;
                        decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[5].Value);
                        decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[10].Value);
                        if (num3 >= num2)
                        {
                            Color color = Color.FromArgb(0xff, 0xe0, 0xc0);
                            this.dataGridView1.Rows[num].DefaultCellStyle.BackColor = color;
                            this.dataGridView1.Rows[num].Cells[10].Style.BackColor = Color.Red;
                            this.dataGridView1.Rows[num].Cells[10].Style.ForeColor = Color.White;
                        }
                        //if (num2 < 0M)
                        //{
                        //    this.dataGridView1.Rows[num].Cells[5].Value = ("(" + Math.Abs(num2).ToString() + ")").ToString();
                        //}
                        num++;
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                code = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                base.Hide();
                new Products_Card().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void desc_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.toolStripComboBox1.SelectedIndex == 0)
            {
                this.label2.Text = "1";
            }
        }

        private void desc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int num;
                if (this.toolStripComboBox1.SelectedIndex != 0)
                {
                    num = 0;
                    while (true)
                    {
                        if (num >= this.dataGridView1.Rows.Count)
                        {
                            break;
                        }
                        if (this.desc.Text == this.dataGridView1.Rows[num].Cells[3].Value.ToString())
                        {
                            int num4 = 0;
                            while (true)
                            {
                                if (num4 >= this.dataGridView1.Rows.Count)
                                {
                                    this.dataGridView1.Rows[num].Selected = true;
                                    if (!this.dataGridView1.Rows[num].Displayed)
                                    {
                                        this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.RowCount - 1;
                                    }
                                    break;
                                }
                                this.dataGridView1.Rows[num4].Selected = false;
                                num4++;
                            }
                        }
                        num++;
                    }
                }
                else if (this.label2.Text == "1")
                {
                    this.gclass.DGVTable("SELECT id as 'S/N',barcode as 'BARCODE',code as 'PRODUCT CODE',description as 'PRODUCT DESCRIPTION',DEPT AS 'PRODUCT CATEGORY',STK AS 'STOCK LIQUID',STK_EMPTY AS 'STOCK EMPTY',CP AS 'COST PRICE',S_P AS 'RETAIL SELLING PRICE',WS AS 'EMPTY BOTTLE PRICE',WP_QTY AS 'PACK QUANTITY',ODR_limit AS 'RE-ORDER QTY LIMIT',LPC AS 'LAST PURCHASE COST',LPD AS 'LAST PURCHASE DATE',EXP_DATE AS 'EXPIRY DATE' FROM product WHERE dept = '" + this.desc.Text + "'", this.dataGridView1);
                    num = 0;
                    while (true)
                    {
                        if (num >= this.dataGridView1.Rows.Count)
                        {
                            break;
                        }
                        this.dataGridView1.Rows[num].Cells[0].Value = num + 1;
                        decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[5].Value);
                        decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[10].Value);
                        if (num3 >= num2)
                        {
                            Color color = Color.FromArgb(0xff, 0xe0, 0xc0);
                            this.dataGridView1.Rows[num].DefaultCellStyle.BackColor = color;
                            this.dataGridView1.Rows[num].Cells[10].Style.BackColor = Color.Red;
                            this.dataGridView1.Rows[num].Cells[10].Style.ForeColor = Color.White;
                        }
                        //if (num2 < 0M)
                        //{
                        //    this.dataGridView1.Rows[num].Cells[5].Value = ("(" + Math.Abs(num2).ToString() + ")").ToString();
                        //}
                        num++;
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Product_Inventory_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.DGVTable("SELECT id as 'S/N',barcode as 'BARCODE',code as 'PRODUCT CODE',description as 'PRODUCT DESCRIPTION',DEPT AS 'PRODUCT CATEGORY',STK AS 'STOCK LIQUID',STK_EMPTY AS 'STOCK EMPTY',CP AS 'COST PRICE',S_P AS 'RETAIL SELLING PRICE',WS AS 'EMPTY BOTTLE PRICE',WP_QTY AS 'PACK QUANTITY',ODR_limit AS 'RE-ORDER QTY LIMIT',LPC AS 'LAST PURCHASE COST',LPD AS 'LAST PURCHASE DATE',EXP_DATE AS 'EXPIRY DATE' FROM product", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        this.dataGridView1.Columns[0].Width = 50;
                        this.dataGridView1.Columns[3].Width = 250;
                        this.dataGridView1.Columns[1].Width = 70;
                        this.dataGridView1.Columns[2].Width = 70;
                        this.dataGridView1.Columns[5].Width = 70;
                        this.dataGridView1.Columns[6].Width = 70;
                        this.dataGridView1.Columns[7].Width = 70;
                        this.dataGridView1.Columns[8].Width = 70;
                        this.dataGridView1.Columns[9].Width = 70;
                        this.dataGridView1.Columns[10].Width = 70;
                        this.toolStripComboBox1.Items.Add("PRODUCT CATEGORY");
                        this.toolStripComboBox1.Items.Add("PRODUCT DESCRIPTION");
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[0].Value = num + 1;
                    decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[5].Value);
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[11].Value);
                    if (num3 >= num2)
                    {
                        Color color = Color.FromArgb(0xff, 0xe0, 0xc0);
                        this.dataGridView1.Rows[num].DefaultCellStyle.BackColor = color;
                        this.dataGridView1.Rows[num].Cells[11].Style.BackColor = Color.Red;
                        this.dataGridView1.Rows[num].Cells[11].Style.ForeColor = Color.White;
                    }
                    //if (num2 < 0M)
                    //{
                    //    this.dataGridView1.Rows[num].Cells[5].Value = ("(" + Math.Abs(num2).ToString() + ")").ToString();
                    //}
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.desc.Text = null;
                this.desc.SelectedIndex = -1;
                this.label2.Text = "0";
                this.gclass.DGVTable("SELECT id as 'S/N',barcode as 'BARCODE',code as 'PRODUCT CODE',description as 'PRODUCT DESCRIPTION',DEPT AS 'PRODUCT CATEGORY',STK AS 'STOCK LIQUID',STK_EMPTY AS 'STOCK EMPTY',CP AS 'COST PRICE',S_P AS 'RETAIL SELLING PRICE',WS AS 'EMPTY BOTTLE PRICE',WP_QTY AS 'PACK QUANTITY',ODR_limit AS 'RE-ORDER QTY LIMIT',LPC AS 'LAST PURCHASE COST',LPD AS 'LAST PURCHASE DATE',EXP_DATE AS 'EXPIRY DATE' FROM product", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        this.dataGridView1.Columns[0].Width = 50;
                        this.dataGridView1.Columns[3].Width = 250;
                        this.dataGridView1.Columns[1].Width = 70;
                        this.dataGridView1.Columns[2].Width = 70;
                        this.dataGridView1.Columns[5].Width = 70;
                        this.dataGridView1.Columns[6].Width = 70;
                        this.dataGridView1.Columns[7].Width = 70;
                        this.dataGridView1.Columns[8].Width = 70;
                        this.dataGridView1.Columns[9].Width = 70;
                        this.dataGridView1.Columns[10].Width = 70;
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[0].Value = num + 1;
                    decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[5].Value);
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[10].Value);
                    if (num3 >= num2)
                    {
                        Color color = Color.FromArgb(0xff, 0xe0, 0xc0);
                        this.dataGridView1.Rows[num].DefaultCellStyle.BackColor = color;
                        this.dataGridView1.Rows[num].Cells[10].Style.BackColor = Color.Red;
                        this.dataGridView1.Rows[num].Cells[10].Style.ForeColor = Color.White;
                    }
                    //if (num2 < 0M)
                    //{
                    //    this.dataGridView1.Rows[num].Cells[5].Value = ("(" + Math.Abs(num2).ToString() + ")").ToString();
                    //}
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.toolStripComboBox1.SelectedIndex == 0)
                {
                    this.gclass.LoadCombo(this.desc, "SELECT * FROM prod_category", "category");
                    this.gclass.autocomplete("SELECT * FROM prod_category", 2, this.desc);
                }
                else
                {
                    this.gclass.LoadCombo(this.desc, "SELECT * FROM product", "description");
                    this.gclass.autocomplete("SELECT * FROM product", 2, this.desc);
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
