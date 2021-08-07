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
    public partial class Search_Product_Empty : Form
    {
        private General gclass = new General();
        public static string bcode;
        public static string post8;
        public static string code;
        public static string descptn;
        public static string dept;
        public static string stock;
        public static string cont;
        public static string stock_empty;
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
        public Search_Product_Empty()
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
                    stock_empty = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    stock = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    lpc = this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    qtyin_pack = this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    cont = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    cat = this.dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    minimum_qty = this.dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    discount = this.dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    dept = this.dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
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
                    this.gclass.DGVTable2("SELECT  barcode as 'BarCode',code as 'Product Code',description as 'Product Description',cp as 'Cost Price',ws as 'Empty Bottle Price',s_p as 'Selling Price',stk as 'Stock Liquid',stk_empty as 'Stock Empties',lpc as 'LPC',wp_qty as 'Pack Quantity',container as 'Container',dept as 'Dept',minimum_qty as 'Minimum Qty',discount as 'Discount',dept as 'Dept' FROM product WHERE barcode ='" + this.desc.Text + "' ORDER BY id ASC ", this.dataGridView1);
                }
                else
                {
                    this.gclass.DGVTable2("SELECT  barcode as 'BarCode',code as 'Product Code',description as 'Product Description',cp as 'Cost Price',ws as 'Empty Bottle Price',s_p as 'Selling Price',stk as 'Stock Liquid',stk_empty as 'Stock Empties',lpc as 'LPC',wp_qty as 'Pack Quantity',container as 'Container',dept as 'Dept',minimum_qty as 'Minimum Qty',discount as 'Discount',dept as 'Dept' FROM product WHERE description LIKE '%" + this.desc.Text + "%' ORDER BY id ASC ", this.dataGridView1);
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
