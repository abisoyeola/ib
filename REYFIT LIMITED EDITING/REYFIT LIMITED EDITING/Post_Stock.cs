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
    public partial class Post_Stock : Form
    {
        private General gclass = new General();
        public static string identify = "23";
        private string tab = null;
        private string newstk;

        public Post_Stock()
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
                if (MessageBox.Show("Are You Sure ?\n Posted Record cannot Be Edited...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int num = 0;
                    while (true)
                    {
                        if (num >= this.dataGridView1.Rows.Count)
                        {
                            this.gclass.success("Record successfully Saved...");
                            this.dataGridView1.Rows.Clear();
                            break;
                        }
                        if (Convert.ToString(this.dataGridView1.Rows[num].Cells[3].Value) == "")
                        {
                            this.dataGridView1.Rows[num].Cells[3].Value = "0";
                        }
                        num++;
                        for (int x = 0; x < dataGridView1.Rows.Count; x++)
                        { 
                        this.newstk = (Convert.ToDecimal(this.dataGridView1.Rows[x].Cells[2].Value) - Convert.ToDecimal(this.dataGridView1.Rows[x].Cells[3].Value)).ToString();
                        MySqlConnection tt = gclass.conn();
                        MySqlCommand yy = new MySqlCommand("UPDATE tbl_stock_list SET qty = '" + dataGridView1.Rows[x].Cells[3].Value.ToString() + "',status = 'POSTED' WHERE code = '" + this.dataGridView1.Rows[x].Cells[0].Value.ToString() + "'", tt);
                        yy.ExecuteNonQuery();
                        //this.gclass.success("Record successfully Saved...");
                        //this.dataGridView1.Rows.Clear();

                      
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

            this.dataGridView1.CurrentRow.Cells[5].Value = (Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[2].Value) + Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[3].Value)).ToString();
            this.dataGridView1.Focus();
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1_CellEndEdit(sender, e);
        }
        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                new Search_Stock().ShowDialog();
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

        private void Post_Stock_Activated(object sender, EventArgs e)
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
                        Search_Product.stock = null;
                        Search_Product.code = null;
                        Search_Product.descptn = null;
                        Search_Product.qtyin_pack = null;
                    }
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Post_Stock_Load(object sender, EventArgs e)
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

        private void Post_Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.dataGridView1.Focus();
                Program.formname = base.Name;
                this.label3.Text = "0";
                button1.PerformClick();
                //new Search_Stock().ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Search_Product().ShowDialog();
            
        }
    }
}
