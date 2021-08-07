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
    public partial class Product_Disposal : Form
    {
        public static string docno = "";
        public static string ordn = "";
        public static string identify = "8";
        public static string date1 = "";
        public static string ven = "";
        private General gclass = new General();
        public Product_Disposal()
        {
            InitializeComponent();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            base.Hide();
            new Product_Dispose_New().ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                docno = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                date1 = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                ven = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                new Product_Disposal_Detail().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Product_Disposal_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.DGVTable("SELECT id as 'S/N',doc_no as 'DOCUMENT NO',p_date as 'POSTING DATE',PURPOSE AS 'PURPOSE OF DISPOSE',TOTAL AS 'TOTAL VALUE',postedby as 'POSTED BY' FROM dispose_summary", this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
