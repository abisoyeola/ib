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
    public partial class Product_Dispose_New : Form
    {
        public static List<string> _list;
        private string tab = null;
        private General gclass = new General();
        public Product_Dispose_New()
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
                if (string.IsNullOrWhiteSpace(this.Others.Text) || (this.dataGridView1.Rows.Count < 1))
                {
                    this.gclass.error("Empty Fields Cannot Be Saved.\n Try Again...");
                }
                else if (MessageBox.Show("Are You Sure ?\n Posted Record cannot Be Edited...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] strArray = new string[] { DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), Program.user_id.ToString() };
                    string str = string.Concat(strArray);

                    for (int x = 0; x < dataGridView1.Rows.Count; x++)
                    {
                        decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[x].Cells[2].Value) - Convert.ToDecimal(this.dataGridView1.Rows[x].Cells[3].Value);
                       
                        MySqlCommand button2 = new MySqlCommand(@"INSERT INTO dispose_detail(doc_no,entry_type,code,description,current_stock,qty,purpose,postedby,cp,total)VALUES('" + str + "','" + pstgrp.Text + "','" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[x].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[x].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[x].Cells[3].Value.ToString() + "','" + Others.Text + "','" + Program.user + "','" + dataGridView1.Rows[x].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[x].Cells[5].Value.ToString() + "')", cn);
                        button2.ExecuteNonQuery();
                        MySqlCommand jh = new MySqlCommand("insert into product_profile (pdate,entry_type,code,description,current_stock,qty,purpose,postedby)VALUES('" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + pstgrp.Text + "','" + dataGridView1.Rows[x].Cells[0].Value + "','" + dataGridView1.Rows[x].Cells[1].Value + "','" + dataGridView1.Rows[x].Cells[2].Value + "','" + dataGridView1.Rows[x].Cells[3].Value + "','" + Others.Text + "','" + Program.user + "')", cn);
                        jh.ExecuteNonQuery();
                        MySqlCommand yy = new MySqlCommand("UPDATE product SET stk = '" + num2 + "' WHERE code = '" + dataGridView1.Rows[x].Cells[0].Value + "'", cn);
                        yy.ExecuteNonQuery();

                        
                    }
                    MySqlCommand button1 = new MySqlCommand("INSERT INTO dispose_summary(doc_no,p_date,purpose,total,postedby,entry_type,other_no)VALUES('" + str + "','" + this.today.Value.ToString("yyyy/MM/dd") + "','" + Others.Text + "','" + txtTotal.Text + "','" + Program.user + "','" + pstgrp.Text + "','" + otherno.Text + "')", cn);
                    button1.ExecuteNonQuery();
                    this.gclass.success("Record successfully Posted...");
                    this.dataGridView1.Rows.Clear();
                        this.otherno.Text = null;
                        }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal num = 0M;
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        break;
                    }
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[3].Value);
                    decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                    this.dataGridView1.Rows[num2].Cells[5].Value = num3 * num4;
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[5].Value);
                    num2++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
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
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            this.tab = e.KeyCode.ToString();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.tab == "Return")
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
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
            else if (e.KeyCode == Keys.F5)
            {
                this.button6.Focus();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                decimal num = 0M;
                int num2 = 0;
                while (true)
                {
                    if (num2 >= this.dataGridView1.Rows.Count)
                    {
                        this.txtTotal.Text = $"{num:N}";
                        break;
                    }
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[3].Value);
                    decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[4].Value);
                    this.dataGridView1.Rows[num2].Cells[5].Value = num3 * num4;
                    num += Convert.ToDecimal(this.dataGridView1.Rows[num2].Cells[5].Value);
                    num2++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Others_MouseClick(object sender, MouseEventArgs e)
        {
            this.Others.SelectAll();
        }

        private void Product_Dispose_New_Activated(object sender, EventArgs e)
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
                        this.dataGridView1.Rows[num3].Cells[4].Value = Search_Product.cp;
                        this.dataGridView1.Rows[num3].Cells[6].Value = Search_Product.bcode;
                        decimal num4 = Convert.ToDecimal(this.dataGridView1.Rows[num3].Cells[4].Value);
                        this.dataGridView1.Rows[num3].Cells[5].Value = num4 * Convert.ToDecimal(this.dataGridView1.Rows[num3].Cells[3].Value);
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

        private void Product_Dispose_New_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Hide();
            new Product_Disposal().ShowDialog();
        }

        private void Product_Dispose_New_Load(object sender, EventArgs e)
        {
            Exception exception;
            try
            {
                this.label18.Text = DateTime.Today.ToString("yyyy/MM/dd");
                try
                {
                    this.dataGridView1.Rows.Clear();
                    base.KeyUp += new KeyEventHandler(this.KeyEvent);
                    this.KeyPreview = true;
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    this.gclass.error(exception.Message.ToString());
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.Text = "Expiration";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.Text = "Damaged Product";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.Text = "Staff Welfare";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.Text = "Public Relations";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.Others.Text = "Others";
            this.Others.Visible = this.radioButton5.Checked;
        }

        private void Product_Dispose_New_KeyDown(object sender, KeyEventArgs e)
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
