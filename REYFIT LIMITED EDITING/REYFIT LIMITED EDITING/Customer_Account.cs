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
    public partial class Customer_Account : Form
    {
        public static string identify = "4";
        private General gclass = new General();
        public Customer_Account()
        {
            InitializeComponent();
            Fillcombos();
        }
        void Fillcombos()
        {
            string constring = "datasource=localhost;port=3306;username=root;password = ''";
            //string constring = "datasource=localhost;port=3306;username=hms;password = 'hms'";
            string Query = "select * from bottle_sales_pos.customer_card;";
            MySqlConnection ConDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sfull_name = myReader.GetString("full_name");
                    desc.Items.Add(sfull_name);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                this.gclass.DGVTable("SELECT id as 'S/N',pdate as 'POSTING DATE',customerid as 'CUSTOMER ID',customer_name as 'CUSTOMER NAME',mode as 'PAYMENT MODE',recieptno as 'INVOICE NO',paymentno as 'PAYMENT NO',entry_type as 'ENTRY TYPE',debit as 'DEBIT',credit as 'CREDIT',discount as 'DISCOUNT',balance as 'BALANCE',postedby as 'POSTEDBY' FROM customer_account", this.dataGridView1);
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[10].Visible = false;
                this.dataGridView1.Columns[0].Visible = false;
                decimal sum = 0;
                decimal sum1 = 0;
                decimal sum2 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                }

                decimal tot_debit = 0;
                decimal tot_credit = 0;
                decimal tot_discount = 0;
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    tot_debit += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    tot_credit += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                    tot_discount += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                }
                if (tot_credit == 0)
                {

                }
                if (tot_debit == 0)
                {

                }
                if (tot_discount == 0)
                {

                }
                total_income.Text = tot_credit.ToString();
                total_expenses.Text = tot_debit.ToString();
                total_discount.Text = tot_discount.ToString();
                this.total_income.Text = $"{Convert.ToDecimal(this.total_income.Text):N}";
                this.total_expenses.Text = $"{Convert.ToDecimal(this.total_expenses.Text):N}";
                this.total_discount.Text = $"{Convert.ToDecimal(this.total_discount.Text):N}";
                this.new_balance.Text = $"{(Convert.ToDecimal(this.total_income.Text) - Convert.ToDecimal(this.total_expenses.Text)):N}".ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
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
                    
                };
                printer.TitleFont = new Font("verdana", 12f, FontStyle.Bold);
                printer.SubTitleFont = new Font("verdana", 10f, FontStyle.Bold);
                printer.FooterAlignment = StringAlignment.Center;
                printer.Title = printer.Title + Program.companyAddressA4;
                printer.Title = printer.Title + "\n" + Program.companyPhone + "\n" + Report.reportTitle + "\n\n";
                printer.SubTitle += ("\n\tTotal Credit   : " + total_income.Text);
                printer.SubTitle += ("\n\tTotal Debit    : " + total_expenses.Text);
                printer.SubTitle += ("\n\tTotal Discount : " + total_discount.Text);
                printer.SubTitle += ("\n\tTotal Balance  : " + balance.Text);
                printer.SubTitle += ("\n\tNet Balance    : " + new_balance.Text);
                printer.SubTitle += "\n\n";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.RowHeight = DGVPrinter.RowHeightSetting.DataHeight;
                printer.PrintMargins.Left = 10;
                printer.PrintMargins.Right = 10;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.SubTitleAlignment = StringAlignment.Near;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                printer.PageNumbers = true;
                printer.FooterSpacing = 15f;
                printer.TitlePrint = DGVPrinter.PrintLocation.FirstOnly;
                printer.SubTitlePrint = DGVPrinter.PrintLocation.FirstOnly;
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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = gclass.conn();
            MySqlCommand cmd;
            if (!string.IsNullOrEmpty(desc.Text.Trim()))
            {
                cmd = new MySqlCommand("SELECT id as 'S/N',pdate as 'POSTING DATE',customerid as 'CUSTOMER ID',customer_name as 'CUSTOMER NAME',mode as 'PAYMENT MODE',recieptno as 'INVOICE NO',paymentno as 'PAYMENT NO',entry_type as 'ENTRY TYPE',debit as 'DEBIT',credit as 'CREDIT',discount as 'DISCOUNT',balance as 'BALANCE',postedby as 'POSTEDBY' FROM customer_account WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' AND customer_name = '" + desc.Text + "'", cn);
            }
            else
            {
                cmd = new MySqlCommand("SELECT id as 'S/N',pdate as 'POSTING DATE',customerid as 'CUSTOMER ID',customer_name as 'CUSTOMER NAME',mode as 'PAYMENT MODE',recieptno as 'INVOICE NO',paymentno as 'PAYMENT NO',entry_type as 'ENTRY TYPE',debit as 'DEBIT',credit as 'CREDIT',discount as 'DISCOUNT',balance as 'BALANCE',postedby as 'POSTEDBY' FROM customer_account WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'", cn);
            }
            MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
            DataSet DTS = new DataSet();
            ADPO.Fill(DTS);
            dataGridView1.DataSource = DTS.Tables[0].DefaultView;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[10].Visible = false;
            this.dataGridView1.Columns[12].Visible = false;
            decimal sum = 0;
            decimal sum1 = 0;
            decimal sum2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
            }

            decimal tot_debit = 0;
            decimal tot_credit = 0;
            decimal tot_discount = 0;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                tot_debit += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                tot_credit += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                tot_discount += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
            }
            if (tot_credit == 0)
            {

            }
            if (tot_debit == 0)
            {

            }
            if (tot_discount == 0)
            {

            }
            total_income.Text = tot_credit.ToString();
            total_expenses.Text = tot_debit.ToString();
            total_discount.Text = tot_discount.ToString();
            this.total_income.Text = $"{Convert.ToDecimal(this.total_income.Text):N}";
            this.total_expenses.Text = $"{Convert.ToDecimal(this.total_expenses.Text):N}";
            this.total_discount.Text = $"{Convert.ToDecimal(this.total_discount.Text):N}";
            this.new_balance.Text = $"{(Convert.ToDecimal(this.total_income.Text) - Convert.ToDecimal(this.total_expenses.Text)):N}".ToString();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString());
            }
        }
    }
}
