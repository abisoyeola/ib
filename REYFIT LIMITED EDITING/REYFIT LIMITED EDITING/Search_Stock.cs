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
    public partial class Search_Stock : Form
    {
        private General gclass = new General();
        public static string bcode;
        public static string code;
        public static string descptn;
        public static string stock;
        public static string cp;
        public static string sp;
        public static string pack_price;
        public static string lpc;
        public static string qtyin_pack;
        public static string enter;
        public static string tab;
        public Search_Stock()
        {
            InitializeComponent();
        }
        private string search()
        {
            try
            {
                if (!this.radioButton3.Checked)
                {
                    this.gclass.DGVTable2("SELECT code AS 'PRODUCT CODE',description AS 'DESCRIPTION',stk AS 'STOCK',qty As 'QUANTITY' FROM tbl_stock_list WHERE description LIKE '%" + this.desc.Text + "%' ORDER BY id ASC ", this.dataGridView1);
                }
                this.dataGridView1.Columns[1].Width = 200;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
            return "ola";
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
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.F4) && (e.KeyCode != Keys.Escape))
            {
            }
        }
        private void Search_Stock_KeyDown(object sender, KeyEventArgs e)
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
                    code = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    descptn = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    stock = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    qtyin_pack = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
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

        private void Search_Stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Search_Stock_Load(object sender, EventArgs e)
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

        private void desc_KeyDown(object sender, KeyEventArgs e)
        {
            enter = e.KeyCode.ToString();
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
    }
}
