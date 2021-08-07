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
namespace POS_SALES
{
    public partial class Product_Journal : Form
    {
        private General gclass = new General();
        public static string identify = "10";
        private string tab = null;
        private string newstk;
        public Product_Journal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = gclass.conn();
         try
            {
                if ((this.entry_type.SelectedIndex == -1) || (this.dataGridView1.Rows.Count < 1))
                {
                    this.gclass.error("Empty Fields Cannot Be Saved.\n Try Again...");
                }
                else if (MessageBox.Show("Are You Sure ?\n Posted Record cannot Be Edited...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int num = 0;
                    while (true)
                    {
                        if (num >= this.dataGridView1.Rows.Count)
                        {
                            this.gclass.success("Record successfully Posted...");
                            this.dataGridView1.Rows.Clear();
                            this.entry_type.SelectedIndex = -1;
                            break;
                        }
                        if (Convert.ToString(this.dataGridView1.Rows[num].Cells[3].Value) == "")
                        {
                            this.dataGridView1.Rows[num].Cells[3].Value = "0";
                        }
                                for (int tt = 0; tt < dataGridView1.Rows.Count; tt++)
                        {
                            this.newstk = (Convert.ToDecimal(this.dataGridView1.Rows[tt].Cells[2].Value) + Convert.ToDecimal(this.dataGridView1.Rows[tt].Cells[3].Value)).ToString();
                            MySqlCommand button1 = new MySqlCommand(@"INSERT INTO product_profile(pdate,entry_type,code,description,current_stock,qty,purpose,postedby)VALUES('" + today.Value.ToString("yyyy/MM/dd") + "','" + entry_type.Text + "','" + dataGridView1.Rows[tt].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[tt].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[tt].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[tt].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[tt].Cells[4].Value.ToString() + "','" + Program.user + "')", cn);
                            button1.ExecuteNonQuery();
                            MySqlCommand yy = new MySqlCommand("UPDATE product SET stk = '" + this.newstk + "' WHERE code = '" + dataGridView1.Rows[num].Cells[0].Value + "'", cn);
                            yy.ExecuteNonQuery();
                            num++;
                        }
                            }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Focus();
        }
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                new Search_Product().ShowDialog();
            }
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                int num;
                if ((e.ColumnIndex == 3) && !int.TryParse(Convert.ToString(e.FormattedValue), out num))
                {
                    e.Cancel = true;
                    this.gclass.error("please enter numeric Value\n Format:80");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void Product_Journal_Activated(object sender, EventArgs e)
        {
            try
            {
                if (this.label3.Text == "0")
                {
                    this.label3.Text = "label3";
                    if (!string.IsNullOrWhiteSpace(Search_Product.descptn))
                    {
                        int count = this.dataGridView1.Rows.Count;
                        if (count > 0)
                        {
                            int num2 = 0;
                            while (true)
                            {
                                if (num2 >= count)
                                {
                                    break;
                                }
                                if (Search_Product.code != this.dataGridView1.Rows[num2].Cells[0].Value.ToString())
                                {
                                    num2++;
                                    continue;
                                }
                                this.gclass.error("Product Has Already Been Added");
                                this.dataGridView1.Focus();
                                this.dataGridView1.Rows[num2].Selected = true;
                                return;
                            }
                        }
                        this.dataGridView1.Rows.Add();
                        int num3 = this.dataGridView1.Rows.Count - 1;
                        this.dataGridView1.Rows[num3].Cells[0].Value = Search_Product.code;
                        this.dataGridView1.Rows[num3].Cells[1].Value = Search_Product.descptn;
                        this.dataGridView1.Rows[num3].Cells[2].Value = Search_Product.stock;
                        this.dataGridView1.Rows[num3].Cells[3].Value = "0";
                        this.dataGridView1.Focus();
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[num3].Cells[3];
                        Search_Product.bcode = null;
                        Search_Product.code = null;
                        Search_Product.descptn = null;
                        Search_Product.cp = null;
                        Search_Product.pack_price = null;
                        Search_Product.sp = null;
                        Search_Product.stock = null;
                        Search_Product.lpc = null;
                        Search_Product.qtyin_pack = null;
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Product_Journal_Load(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                base.KeyUp += new KeyEventHandler(this.KeyEvent);
                this.KeyPreview = true;
                this.dataGridView1.Rows.Clear();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Product_Journal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                //this.txtTendered.Text = "0.00";
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                button1.PerformClick();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search_Product dc = new Search_Product();
            dc.ShowDialog();
        }
    }
}
