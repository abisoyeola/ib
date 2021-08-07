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
    public partial class Search_Product : Form
    {
        private General gclass = new General();
        public static string bcode;
        public static string qty_sold;
        public static string ncp;
        public static string qty_sold_projection;
        public static string fifo_qty;
        public static string fifo_cp;
        public static string fifo_order1;
        public static string qty_sold1;
        public static string fifo_cp1;
        public static string fifo_order2;
        public static string qty_sold2;
        public static string fifo_cp2;
        public static string fifo_order3;
        public static string qty_sold3;
        public static string fifo_cp3;
        public static string fifo_order4;
        public static string qty_sold4;
        public static string fifo_cp4;
        public static string code;
        public static string descptn;
        public static string stock;
        public static string cont;
        public static string stock_empty;
        public static string status;
        public static string cat;
        public static string cp;
        public static string sp;
        public static string pack_price;
        public static string minimum_qty;
        public static string discount;
        public static string lpc;
        public static string qtyin_pack;
        public static string enter;
        public static string tab;
        public Search_Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.search();
                this.dataGridView1.Focus();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            enter = e.KeyCode.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.F4) && (e.KeyCode != Keys.Escape))
            {
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                tab = e.KeyCode.ToString();
                if (tab != "Return")
                {
                    if (tab == "Escape")
                    {
                        base.Close();
                    }
                }
                else if (this.dataGridView1.Rows.Count <= 0)
                {
                    this.desc.SelectAll();
                    this.desc.Focus();
                }
                else
                {
                    bcode = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    code = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    descptn = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    cp = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    pack_price = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    sp = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    stock = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    stock_empty = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    lpc = this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    qtyin_pack = this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    cont = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    cat = this.dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    minimum_qty = this.dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    discount = this.dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    status = this.dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                    fifo_qty = this.dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
                    fifo_cp = this.dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
                    qty_sold = this.dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
                    qty_sold_projection = this.dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
                    ncp = this.dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
                    fifo_order1 = this.dataGridView1.SelectedRows[0].Cells[20].Value.ToString();
                    qty_sold1 = this.dataGridView1.SelectedRows[0].Cells[21].Value.ToString();
                    fifo_cp1 = this.dataGridView1.SelectedRows[0].Cells[22].Value.ToString();
                    fifo_order2 = this.dataGridView1.SelectedRows[0].Cells[23].Value.ToString();
                    qty_sold2 = this.dataGridView1.SelectedRows[0].Cells[24].Value.ToString();
                    fifo_cp2 = this.dataGridView1.SelectedRows[0].Cells[25].Value.ToString();
                    fifo_order3 = this.dataGridView1.SelectedRows[0].Cells[26].Value.ToString();
                    qty_sold3 = this.dataGridView1.SelectedRows[0].Cells[27].Value.ToString();
                    fifo_cp3 = this.dataGridView1.SelectedRows[0].Cells[28].Value.ToString();
                    fifo_order4 = this.dataGridView1.SelectedRows[0].Cells[29].Value.ToString();
                    qty_sold4 = this.dataGridView1.SelectedRows[0].Cells[30].Value.ToString();
                    fifo_cp4 = this.dataGridView1.SelectedRows[0].Cells[31].Value.ToString();
                    base.Close();
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
                this.desc.Visible = true;
                this.label2.Text = "Product Barcode";
                this.desc.Focus();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
        private string search()
        {
            try
            {
                if (this.radioButton3.Checked)
                {
                    this.gclass.DGVTable2("SELECT  barcode as 'BarCode',code as 'Product Code',description as 'Product Description',cp as 'Cost Price',ws as 'Empty Bottle Price',s_p as 'Selling Price',stk as 'Stock LQD',stk_empty as 'Stock Empty',lpc as 'LPC',wp_qty as 'Pack Quantity',container as 'Container',dept as 'Dept',minimum_qty as 'Minimum Qty',discount as 'Discount',status as 'STATUS',fifo_qty as 'Fifo Qty',fifo_cp as 'Fifo CP',qty_sold as 'Qty Sold',qty_sold_projection as 'Qty Sold Projection',ncp as 'New Cp',fifo_order1 as 'Fifo Order1',qty_sold1 as 'Qty Sold1',fifo_cp1 as 'Fifo Cp1',fifo_order2 as 'Fifo Order2',qty_sold2 as 'Qty Sold2',fifo_cp2 as 'Fifo Cp2',fifo_order3 as 'Fifo Order3',qty_sold3 as 'Qty Sold3',fifo_cp3 as 'Fifo Cp3',fifo_order4 as 'Fifo Order4',qty_sold4 as 'Qty Sold4',fifo_cp4 as 'Fifo Cp4' FROM product WHERE barcode ='" + this.desc.Text + "' ORDER BY id ASC ", this.dataGridView1);
                }
                else
                {
                    this.gclass.DGVTable2("SELECT  barcode as 'BarCode',code as 'Product Code',description as 'Product Description',cp as 'Cost Price',ws as 'Empty Bottle Price',s_p as 'Selling Price',stk as 'Stock LQD',stk_empty as 'Stock Empty',lpc as 'LPC',wp_qty as 'Pack Quantity',container as 'Container',dept as 'Dept',minimum_qty as 'Minimum Qty',discount as 'Discount',status as 'STATUS',fifo_qty as 'Fifo Qty',fifo_cp as 'Fifo CP',qty_sold as 'Qty Sold',qty_sold_projection as 'Qty Sold Projection',ncp as 'New Cp',fifo_order1 as 'Fifo Order1',qty_sold1 as 'Qty Sold1',fifo_cp1 as 'Fifo Cp1',fifo_order2 as 'Fifo Order2',qty_sold2 as 'Qty Sold2',fifo_cp2 as 'Fifo Cp2',fifo_order3 as 'Fifo Order3',qty_sold3 as 'Qty Sold3',fifo_cp3 as 'Fifo Cp3',fifo_order4 as 'Fifo Order4',qty_sold4 as 'Qty Sold4',fifo_cp4 as 'Fifo Cp4' FROM product WHERE description LIKE '%" + this.desc.Text + "%' ORDER BY id ASC ", this.dataGridView1);
                }
                this.dataGridView1.Columns[2].Width = 200;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[3].Visible = false;
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[9].Visible = false;
                this.dataGridView1.Columns[10].Visible = false;
                this.dataGridView1.Columns[11].Visible = false;
                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[13].Visible = false;
                this.dataGridView1.Columns[14].Visible = false;
                this.dataGridView1.Columns[15].Visible = false;
                this.dataGridView1.Columns[16].Visible = false;
                this.dataGridView1.Columns[17].Visible = false;
                this.dataGridView1.Columns[18].Visible = false;
                this.dataGridView1.Columns[19].Visible = false;
                this.dataGridView1.Columns[20].Visible = false;
                this.dataGridView1.Columns[21].Visible = false;
                this.dataGridView1.Columns[22].Visible = false;
                this.dataGridView1.Columns[23].Visible = false;
                this.dataGridView1.Columns[24].Visible = false;
                this.dataGridView1.Columns[25].Visible = false;
                this.dataGridView1.Columns[26].Visible = false;
                this.dataGridView1.Columns[27].Visible = false;
                this.dataGridView1.Columns[28].Visible = false;
                this.dataGridView1.Columns[29].Visible = false;
                this.dataGridView1.Columns[30].Visible = false;
                this.dataGridView1.Columns[31].Visible = false;

            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
            return "ola";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.desc.Visible = true;
                this.label2.Text = "Product Description";
                this.desc.Focus();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Search_Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Search_Product_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormName.Text = Program.formname;
                this.desc.Focus();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void desc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (enter == "Return")
                {
                    this.button1_Click(sender, e);
                }
                else if (enter == "Escape")
                {
                    base.Close();
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void desc_KeyDown(object sender, KeyEventArgs e)
        {
            enter = e.KeyCode.ToString();
        }

        private void dataGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FormName_Click(object sender, EventArgs e)
        {

        }
    }
}
