using System;
using System.Collections;
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
    public partial class Profit_Product_Category : Form
    {

        public static string doc_no;
        public static string tot;
        public static string p_date;
        public static string rptn;
        public static string kashier;
        public static string total_amount;
        public static string ven;
        public static string date1;
        public static string ordn;
        public static string purid;
        public static string identify = "12";
        private General gclass = new General();
        private string reportTitle = null;
        private MySqlCommand cmd;
        public Profit_Product_Category()
        {
            InitializeComponent();
            //Fillcombo();
        }

        private void Purchase_Report_Load(object sender, EventArgs e)
        {
            try
            {
                this.gclass.LoadCombo(this.desc, "SELECT * FROM prod_category", "category");
                this.gclass.autocomplete("SELECT * FROM prod_category", 1, this.desc);
                this.desc.SelectedIndex = -1;
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                MySqlConnection cn = gclass.conn();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT pdate as 'POSTING DATE',mode as 'PAYMENT MODE',recieptno as 'RECEIPT NO',product_code as 'PRODUCT CODE',description as 'DESCRIPTION',category as 'CATEGORY',qty as 'QTY',cp as 'COST PRICE',sp as 'SELLING PRICE',tot_sp as 'TOTAL SELLING PRICE',tot_cp as 'TOTAL COST PRICE',discount as 'DISCOUNT',discount_amount as 'NET AMOUNT',profit as 'PROFIT',postedby as 'POSTED BY' FROM profit_product", cn);
                MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
                DataSet DTS = new DataSet();
                ADPO.Fill(DTS);
                dataGridView2.DataSource = DTS.Tables[0].DefaultView;
                decimal sum = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(dataGridView2.Rows[i].Cells[13].Value);
                }
                decimal tot_profit = 0;
                for (int i = 0; i <= dataGridView2.RowCount - 1; i++)
                {
                    tot_profit += Convert.ToDecimal(dataGridView2.Rows[i].Cells[13].Value);
                }

                if (tot_profit == 0)
                {

                }
                total_profit.Text = tot_profit.ToString();
                this.total_profit.Text = $"{Convert.ToDecimal(this.total_profit.Text):N}";

            }

            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                this.Purchase_Report_Load(sender, e);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = gclass.conn();
            MySqlCommand cmd;
            if (!string.IsNullOrEmpty(desc.Text.Trim()))
            {
                cmd = new MySqlCommand("SELECT pdate as 'POSTING DATE',mode as 'PAYMENT MODE',recieptno as 'RECEIPT NO',product_code as 'PRODUCT CODE',description as 'DESCRIPTION',category as 'CATEGORY',qty as 'QTY',cp as 'COST PRICE',sp as 'SELLING PRICE',tot_sp as 'TOTAL SELLING PRICE',tot_cp as 'TOTAL COST PRICE',discount as 'DISCOUNT %',discount_amount as 'NET AMOUNT',profit as 'PROFIT',postedby as 'POSTED BY' FROM profit_product WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' AND category = '" + desc.Text + "'", cn);
            }
            else
            {
                cmd = new MySqlCommand("SELECT pdate as 'POSTING DATE',mode as 'PAYMENT MODE',recieptno as 'RECEIPT NO',product_code as 'PRODUCT CODE',description as 'DESCRIPTION',category as 'CATEGORY',qty as 'QTY',cp as 'COST PRICE',sp as 'SELLING PRICE',tot_sp as 'TOTAL SELLING PRICE',tot_cp as 'TOTAL COST PRICE',discount as 'DISCOUNT %',discount_amount as 'NET AMOUNT',profit as 'PROFIT',postedby as 'POSTED BY' FROM profit_product WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'", cn);
            }
            MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
            DataSet DTS = new DataSet();
            ADPO.Fill(DTS);
            dataGridView2.DataSource = DTS.Tables[0].DefaultView;
            decimal sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView2.Rows[i].Cells[13].Value);
            }
            decimal tot_profit = 0;
            for (int i = 0; i <= dataGridView2.RowCount - 1; i++)
            {
                tot_profit += Convert.ToDecimal(dataGridView2.Rows[i].Cells[13].Value);
            }

            if (tot_profit == 0)
            {

            }
            total_profit.Text = tot_profit.ToString();
            this.total_profit.Text = $"{Convert.ToDecimal(this.total_profit.Text):N}";
        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                this.Purchase_Report_Load(sender, e);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void desc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView2.ForeColor = Color.Black;
            this.dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.DefaultCellStyle.Font = new Font("verdana", 10f);
            this.dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.DefaultCellStyle.BackColor = Color.White;
            IEnumerator enumerator = ((IEnumerable)this.dataGridView2.Rows).GetEnumerator();
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
                SubTitle = Program.companyAddressA4
            };
            string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
            printer.SubTitle = string.Concat(strArray);
            printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + "";
            printer.SubTitle += "\nTotal Profit :    " + total_profit.Text;
            printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            printer.PageNumbers = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
            printer.PrintMargins.Left = 10;
            printer.PrintMargins.Right = 10;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
            printer.FooterSpacing = 15f;
            if (this.dataGridView2.Columns.Count > 7)
            {
                printer.PageSettings.Landscape = true;
            }
            printer.PrintPreviewDataGridView(this.dataGridView2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView2);
        }
    }
    }

