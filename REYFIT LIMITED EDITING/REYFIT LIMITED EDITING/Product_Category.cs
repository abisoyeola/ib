using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SALES
{
    public partial class Product_Category : Form
    {
        public static string identify = "7";
        private General gclass = new General();
        public Product_Category()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string text;
                if (this.button6.Text != "&Save")
                {
                    text = this.TXTCODE.Text;
                    if (!string.IsNullOrWhiteSpace(this.txtName.Text) && !string.IsNullOrWhiteSpace(text))
                    {
                        string[] strArray = new string[] { "UPDATE prod_category SET category = '", this.txtName.Text, "' WHERE code = '", text.ToString(), "'" };
                        this.gclass.INSERT(string.Concat(strArray));
                    }
                    else
                    {
                        this.gclass.error("Empty Fields Cannot Be saved... \n Try Again");
                        return;
                    }
                }
                else
                {
                    text = this.gclass.cat(this.dataGridView1.Rows.Count);
                    if (!string.IsNullOrWhiteSpace(this.txtName.Text) && !string.IsNullOrWhiteSpace(text))
                    {
                        this.gclass.INSERT(" INSERT INTO prod_category VALUES (id,'" + text.ToString() + "','" + this.txtName.Text + "') ");
                    }
                    else
                    {
                        this.gclass.error("Empty Fields Cannot Be saved... \n Try Again");
                        return;
                    }
                }
                this.gclass.DGVTable("SELECT ID AS 'S/N',code as 'CODE', category as 'CATEGORY NAME' FROM prod_category", this.dataGridView1);
                this.txtName.Text = null;
                this.button6.Text = "&Save";
                this.TXTCODE.Text = "AUTO";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TXTCODE.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.txtName.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                this.button6.Text = "&Update";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void Product_Category_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.DGVTable("SELECT ID AS 'S/N',code as 'CODE', category as 'CATEGORY NAME' FROM prod_category", this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }
    }
}
