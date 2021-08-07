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
using System.Collections;

namespace POS_SALES
{
    public partial class Income_Expenses : Form
    {
        public static string identify = "4";
        private General gclass = new General();

        void Fillcombo1()
        {
            string constring = "datasource=localhost;port=3306;username=root;password = ''";
            //string constring = "datasource=localhost;port=3306;username=hms;password = 'hms'";
            string Query = "select * from bottle_sales_pos.income_expenses;";
            MySqlConnection ConDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sdescription = myReader.GetString("description");
                    combobox1.Items.Add(sdescription);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void Fillcombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password = ''";
            //string constring = "datasource=localhost;port=3306;username=hms;password = 'hms'";
            string Query = "select * from bottle_sales_pos.expense_cat;";
            MySqlConnection ConDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, ConDataBase);
            MySqlDataReader myReader;
            try
            {
                ConDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string scategory = myReader.GetString("name");
                    desc.Items.Add(scategory);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public Income_Expenses()
        {
            InitializeComponent();
            Fillcombo();
            Fillcombo1();
            //Fillcombos();
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
                this.gclass.DGVTable("SELECT id as 'S/N',pdate as 'POSTING DATE',category as 'CATEGORY',reference_no as 'REFERENCE NO',description as 'DESCRIPTION',comment as 'EXPENSE TYPE',amount as 'EXPENSES',postedby as 'POSTEDBY' FROM expenditure", this.dataGridView1);
                decimal sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    //sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                }
                decimal tot_expenses = 0;
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    //tot_income += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                    tot_expenses += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                }
              
                if (tot_expenses == 0)
                {

                }
                //total_credit.Text = tot_income.ToString();
                total_expenses.Text = tot_expenses.ToString();
                //this.total_credit.Text = $"{Convert.ToDecimal(this.total_credit.Text):N}";
                this.total_expenses.Text = $"{Convert.ToDecimal(this.total_expenses.Text):N}";
                //this.balance.Text = $"{(Convert.ToDecimal(this.total_credit.Text) - Convert.ToDecimal(this.total_debit.Text)):N}".ToString();
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
                    //new Post_Income().ShowDialog();
                }
                catch (Exception exception)
                {
                    this.gclass.error(exception.Message.ToString());
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.ForeColor = Color.Maroon;
            this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 9f);
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
            IEnumerator enumerator = ((IEnumerable)this.dataGridView1.Rows).GetEnumerator();
            try
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    DataGridViewRow current = (DataGridViewRow)enumerator.Current;
                    current.DefaultCellStyle.BackColor = Color.White;
                }
            }
            finally
            {
                IDisposable objA = enumerator as IDisposable;
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
            DGVPrinter printer = new DGVPrinter
            {
                TitleColor = Color.Black,
                SubTitleColor = Color.Black,
                Title = Program.companyName + "\n",
                //SubTitle = Program.companyAddressA4
            };
            printer.TitleFont = new Font("verdana", 12f, FontStyle.Bold);
            printer.SubTitleFont = new Font("verdana", 10f, FontStyle.Bold);
            printer.FooterAlignment = StringAlignment.Center;
            printer.Title = printer.Title + Program.companyAddressA4;
            printer.Title = printer.Title + "\n" + Program.companyPhone + "\n" + Report.reportTitle + "\n\n";
            printer.SubTitle += "\n Total Expenses Amount:   " + total_expenses.Text;
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
            printer.FooterSpacing = 15f;
            printer.TitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            printer.SubTitlePrint = DGVPrinter.PrintLocation.FirstOnly;
            if (this.dataGridView1.Columns.Count > 7)
            {
                printer.PageSettings.Landscape = true;
            }
            printer.PrintPreviewDataGridView(this.dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = gclass.conn();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT id as 'S/N',pdate as 'POSTING DATE',category as 'CATEGORY',reference_no as 'REFERENCE NO',description as 'DESCRIPTION',comment as 'EXPENSE TYPE',amount as 'EXPENSES',postedby as 'POSTEDBY' FROM expenditure WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' OR category ='" + desc.Text + "' OR description ='" + combobox1.Text + "'", con);
            MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
            DataSet DTS = new DataSet();
            ADPO.Fill(DTS);
            dataGridView1.DataSource = DTS.Tables[0].DefaultView;
            //this.dataGridView1.Columns[1].Visible = false;
            decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                //sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }

            //decimal tot_income = 0;
            decimal tot_expenses = 0;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                //tot_income += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                tot_expenses += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }
            //if (tot_income == 0)
            //{

            //}
            if (tot_expenses == 0)
            {

            }
            //total_credit.Text = tot_income.ToString();
            total_expenses.Text = tot_expenses.ToString();
            //this.total_credit.Text = $"{Convert.ToDecimal(this.total_credit.Text):N}";
            this.total_expenses.Text = $"{Convert.ToDecimal(this.total_expenses.Text):N}";
            //this.balance.Text = $"{(Convert.ToDecimal(this.total_credit.Text) - Convert.ToDecimal(this.total_debit.Text)):N}".ToString();
        }

        private void desc_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = gclass.conn();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT id as 'S/N',pdate as 'POSTING DATE',category as 'CATEGORY',reference_no as 'REFERENCE NO',description as 'DESCRIPTION',comment as 'EXPENSE TYPE',amount as 'EXPENSES',postedby as 'POSTEDBY' FROM expenditure WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' OR category ='" + desc.Text + "'", con);
            MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
            DataSet DTS = new DataSet();
            ADPO.Fill(DTS);
            dataGridView1.DataSource = DTS.Tables[0].DefaultView;
            //this.dataGridView1.Columns[1].Visible = false;
            decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                //sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }

            //decimal tot_income = 0;
            decimal tot_expenses = 0;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                //tot_income += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                tot_expenses += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
            }
            //if (tot_income == 0)
            //{

            //}
            if (tot_expenses == 0)
            {

            }
            //total_credit.Text = tot_income.ToString();
            total_expenses.Text = tot_expenses.ToString();
            //this.total_credit.Text = $"{Convert.ToDecimal(this.total_credit.Text):N}";
            this.total_expenses.Text = $"{Convert.ToDecimal(this.total_expenses.Text):N}";
            //this.balance.Text = $"{(Convert.ToDecimal(this.total_credit.Text) - Convert.ToDecimal(this.total_debit.Text)):N}".ToString();
        }
    }
}
