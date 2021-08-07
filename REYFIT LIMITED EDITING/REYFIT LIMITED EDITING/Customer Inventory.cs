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
    public partial class Customer_Inventory : Form
    {
        public static string code;
        public static string balance;
        public static string name = "";
        private General gclass = new General();
        public Customer_Inventory()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Inventory_Activated(object sender, EventArgs e)
        {
            if (this.label2.Text == "0")
            {
                try
                {
                    code = null;
                    this.gclass.DGVTable("SELECT id as 'S/N', customerid as 'CUSTOMER CODE',full_name as 'CUSTOMER NAME',phone as 'PHONE NO',add1 as 'ADDRESS', balance_limit as 'BALANCE LIMIT',balance as 'BALANCE AMOUNT' FROM customer_card", this.dataGridView1);
                    this.label2.Text = "label2";
                    this.dataGridView1.Columns[0].Width = 50;
                    this.dataGridView1.Columns[2].Width = 250;
                    this.dataGridView1.Columns[4].Width = 350;
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message.ToString());
                }
            }
        }

        private void Customer_Inventory_Load(object sender, EventArgs e)
        {
            try
            {
                this.label2.Text = "0";
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                code = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.label2.Text = "0";
                new Customer_Card().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.label2.Text = "0";
            new Customer_Card().ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            try
            {
                code = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.label2.Text = "0";
                new Customer_Card().ShowDialog();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            code = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            balance = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            name = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            this.label2.Text = "0";
            new Form1().ShowDialog();
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.ForeColor = Color.Maroon;
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 10f);
                this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
                DGVPrinter printer = new DGVPrinter
                {
                    TitleColor = Color.Maroon,
                    SubTitleColor = Color.Black,
                    Title = Program.companyName + "\n",
                    SubTitle = Program.companyAddressA4
                };
                string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
                printer.SubTitle = string.Concat(strArray);
                printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \nCUSTOMER LIST\n ";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.PrintMargins.Left = 10;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Right = 10;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                printer.FooterSpacing = 15f;
                if (this.dataGridView1.Columns.Count > 7)
                {
                    printer.PageSettings.Landscape = true;
                }
                printer.PrintPreviewDataGridView(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            code = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            balance = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            name = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            this.label2.Text = "0";
            new Form1().ShowDialog();
        }
    }
}
