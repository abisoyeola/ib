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
    public partial class Expenditure : Form
    {
        public static string identify = "4";
        private General gclass = new General();
        public Expenditure()
        {
            InitializeComponent();
        }

        private void Expenditure_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                this.gclass.DGVTable("SELECT * FROM expenditure", this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    base.Hide();
                    new Expense().ShowDialog();
                }
                catch (Exception exception)
                {
                    this.gclass.error(exception.Message.ToString());
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
