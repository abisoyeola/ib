using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
namespace POS_SALES
{
    public partial class Bank_Card : Form
    {
        public static string code = "1";
        public static string identify = "1";
        private General gclass = new General();
        public Bank_Card()
        {
            InitializeComponent();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView2);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            base.Hide();
            code = "1";
            new Bank().ShowDialog();
        }

        private void Bank_Card_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                MySqlConnection cm = gclass.conn();
                //cm.Open();
                this.gclass.DGVTable("SELECT * FROM bank", dataGridView2);
                this.gclass.DGVTable("SELECT id as 'S/N',code as 'BANK CODE',name as 'BANK NAME',add2 as 'BRANCH',email as 'Account No',ACCT_TYPE as 'ACCOUNT TYPE'  FROM BANK ORDER BY code ASC", this.dataGridView2);
                this.dataGridView2.Columns[0].Width = 50;
                this.dataGridView2.Columns[2].Width = 250;
                this.dataGridView2.Columns[3].Width = 150;
                this.dataGridView2.Columns[4].Width = 150;
                //MySqlConnection cm = gclass.conn();
                //MySqlDataAdapter adp = new MySqlDataAdapter("Select * from bank", cm);
                //DataSet das = new DataSet();
                //adp.Fill(das);
                ////dataGridView1.DataSource = das.Tables[0].DefaultView;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView2);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            code = this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            base.Hide();
            new Bank().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            base.Hide();
            code = "1";
            new Bank().ShowDialog();
        }

        private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView2);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            code = this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            base.Hide();
            new Bank().ShowDialog();
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
