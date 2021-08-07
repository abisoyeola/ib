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
    public partial class Product_Disposal_Detail : Form
    {
        private General gclass = new General();
        public Product_Disposal_Detail()
        {
            InitializeComponent();
        }

        private void Product_Disposal_Detail_Load(object sender, EventArgs e)
        {
            try
            {
                this.label2.Text = Product_Disposal.date1;
                this.label6.Text = Product_Disposal.docno;
                this.label4.Text = Product_Disposal.ven;
                this.gclass.DGVTable("SELECT id as 'S/N',code as 'PRODUCT CODE',description as 'DESCRIPTION',qty as 'QUANTITY',cp as 'COST PRICE',total as 'TOTAL' FROM dispose_detail WHERE doc_no = '" + Product_Disposal.docno + "'", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    this.dataGridView1.Rows[num].Cells[1].Value = num + 1;
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
