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
    public partial class Inventory_Profile : Form
    {
        private General gclass = new General();
        public Inventory_Profile()
        {
            InitializeComponent();
        }

        private void Inventory_Profile_Load(object sender, EventArgs e)
        {
            try
            {
                this.label2.Text = Products_Card.code2.ToString();
                this.label4.Text = Products_Card.desct.ToString();
                MySqlConnection connection = gclass.conn();
                this.gclass.DGVTable2("SELECT pdate as 'POSTING DATE',code as 'CODE',description as 'DESCRIPTION',current_stock as 'CURRENT STOCK',qty as 'QUANTITY',entry_type as 'ENTRY TYPE',purpose as 'PURPOSE',postedby as 'POSTED BY' FROM product_profile WHERE code = '" + this.label2.Text + "'", this.dataGridView1);
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[3].Value.ToString());
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[4].Value.ToString());
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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
                    TitleColor = Color.Maroon,
                    SubTitleColor = Color.Maroon,
                    Title = Program.companyName + "\n"
                };
                printer.TitleFont = new Font("verdana", 16f, FontStyle.Bold);
                printer.Title = printer.Title + Program.companyAddressA4;
                printer.Title = printer.Title + "\n" + Program.companyPhone + "\n PRODUCT QTY IN & OUT AUDIT REPORT";
                printer.SubTitle = "\nFrom :   " + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "\t   To :   " + dateTimePicker2.Value.ToString("yyyy/MM/dd");
                printer.SubTitle += "\n Product Code :  " + label2.Text.ToUpper();
                printer.SubTitle += "\n Product Name:    " + label4.Text.ToUpper();
                printer.SubTitle += "\n\n";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Left = 15;
                printer.PrintMargins.Right = 15;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.SubTitleAlignment = StringAlignment.Near;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                printer.FooterSpacing = 15f;
                printer.PageSettings.Landscape = true;
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
            cmd = new MySqlCommand("SELECT pdate as 'POSTING DATE',code as 'CODE',description as 'DESCRIPTION',current_stock as 'CURRENT STOCK',qty as 'QUANTITY',entry_type as 'ENTRY TYPE',purpose as 'PURPOSE',postedby as 'POSTED BY' FROM product_profile WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'", cn);
            MySqlDataAdapter ADPO = new MySqlDataAdapter(cmd);
            DataSet DTS = new DataSet();
            ADPO.Fill(DTS);
            dataGridView1.DataSource = DTS.Tables[0].DefaultView;
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
    }
 }

