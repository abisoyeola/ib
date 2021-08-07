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
    public partial class Purchase : Form
    {
        public static string doc_no;
        public static string tot;
        public static string pdate;
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
        public Purchase()
        {
            InitializeComponent();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            purid = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ordn = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            date1 = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ven = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            tot = this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            new Purchase_Invoice_Detail().ShowDialog();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.ForeColor = Color.Black;
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
                TitleColor = Color.Black,
                SubTitleColor = Color.Black,
                Title = Program.companyName + "\n",
                SubTitle = Program.companyAddressA4
            };
            string[] strArray = new string[] { printer.SubTitle, "\n", Program.companyPhone, "|Email:", Program.companyEmail };
            printer.SubTitle = string.Concat(strArray);
            reportTitle = ("Purchase Sales Analysis Report From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            printer.SubTitle = printer.SubTitle + "\n" + Report.reportTitle + " \n\n";
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
            if (this.dataGridView1.Columns.Count > 7)
            {
                printer.PageSettings.Landscape = true;
            }
            printer.PrintPreviewDataGridView(this.dataGridView1);
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] strArray;
                this.listBox1.Items.Clear();
                this.dataGridView1.Rows.Clear();
                if (this.toolStripComboBox1.SelectedIndex != 0)
                {
                    if (this.toolStripComboBox1.SelectedIndex != 1)
                    {
                        if (this.toolStripComboBox1.SelectedIndex != 2)
                        {
                            return;
                        }
                        else
                        {
                            this.cmd = new MySqlCommand("SELECT * FROM purchase_invoice WHERE vendor_name = '" + this.desc.Text + "'", this.gclass.conn());
                        }
                    }
                    else
                    {
                        strArray = new string[] { "SELECT * FROM purchase_invoice WHERE invoice_date BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                        this.cmd = new MySqlCommand(string.Concat(strArray), this.gclass.conn());
                    }
                }
                else
                {
                    strArray = new string[] { "SELECT * FROM purchase_invoice WHERE p_date BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "'" };
                    this.cmd = new MySqlCommand(string.Concat(strArray), this.gclass.conn());
                }
                MySqlDataReader reader = this.cmd.ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Close();
                        int count = this.dataGridView1.Rows.Count;
                        decimal num3 = 0M;
                        int num4 = 0;
                        while (true)
                        {
                            string str;
                            flag = num4 < count;
                            if (!flag)
                            {
                                this.dataGridView1.Rows.Add(2);
                                int num5 = this.dataGridView1.Rows.Count - 1;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Font = new Font("verdana", 12f);
                                this.dataGridView1.Rows[num5].Cells[1].Value = "S/N";
                                this.dataGridView1.Rows[num5].Cells[2].Value = "VENDOR";
                                this.dataGridView1.Rows[num5].Cells[3].Value = "AMOUNT";
                                int num6 = this.listBox1.Items.Count;
                                decimal num7 = 0M;
                                string str2 = null;
                                int num8 = 0;
                                while (true)
                                {
                                    if (num8 >= num6)
                                    {
                                        this.dataGridView1.Rows.Add();
                                        int num10 = this.dataGridView1.Rows.Count - 1;
                                        this.dataGridView1.Rows[num10].DefaultCellStyle.Font = new Font("verdana", 8f);
                                        this.dataGridView1.Rows[num10].Cells[1].Value = "TOTAL AMOUNT";
                                        this.dataGridView1.Rows[num10].Cells[3].Value = $"{num3:N}";
                                        this.lbltotalAmt.Text = $"{num3:N}";
                                        this.reportTitle = "Purchase Analysis Report Summary Till Date (" + this.dateTimePicker1.Value.ToString("yyyy/MM/dd") + ")";
                                        break;
                                    }
                                    str = this.listBox1.Items[num8].ToString();
                                    num4 = 0;
                                    while (true)
                                    {
                                        flag = num4 < count;
                                        if (!flag)
                                        {
                                            this.dataGridView1.Rows.Add();
                                            int num9 = this.dataGridView1.Rows.Count - 1;
                                            this.dataGridView1.Rows[num9].Cells[1].Value = num8 + 1;
                                            this.dataGridView1.Rows[num9].Cells[2].Value = str.ToString();
                                            this.dataGridView1.Rows[num9].Cells[3].Value = $"{num7:N}";
                                            num7 = 0M;
                                            num8++;
                                            break;
                                        }
                                        str2 = this.dataGridView1.Rows[num4].Cells[6].Value.ToString();
                                        if (str == str2)
                                        {
                                            num7 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                                        }
                                        num4++;
                                    }
                                }
                                break;
                            }
                            num3 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                            this.dataGridView1.Rows[num4].Cells[0].Value = (num4 + 1).ToString();
                            str = this.dataGridView1.Rows[num4].Cells[6].Value.ToString();
                            if (!this.listBox1.Items.Contains(str.ToString()))
                            {
                                this.listBox1.Items.Add(str);
                            }
                            num4++;
                        }
                        break;
                    }
                    this.dataGridView1.Rows.Add();
                    int num = this.dataGridView1.Rows.Count - 1;
                    this.dataGridView1.Rows[num].Cells[0].Value = reader.GetString("id");
                    this.dataGridView1.Rows[num].Cells[1].Value = reader.GetString("code");
                    this.dataGridView1.Rows[num].Cells[2].Value = reader.GetString("p_date");
                    this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("odrn");
                    this.dataGridView1.Rows[num].Cells[4].Value = reader.GetString("invoice_date");
                    this.dataGridView1.Rows[num].Cells[5].Value = reader.GetString("vendor_code");
                    this.dataGridView1.Rows[num].Cells[6].Value = reader.GetString("vendor_name");
                    this.dataGridView1.Rows[num].Cells[7].Value = reader.GetString("vendor_add");
                    this.dataGridView1.Rows[num].Cells[8].Value = reader.GetString("post_grp");
                    this.dataGridView1.Rows[num].Cells[9].Value = reader.GetString("total");
                    this.dataGridView1.Rows[num].Cells[10].Value = reader.GetString("discount");
                    this.dataGridView1.Rows[num].Cells[11].Value = reader.GetString("amt_less_discount");
                    this.dataGridView1.Rows[num].Cells[12].Value = reader.GetString("postedby");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.gclass.export_to_excell(this.dataGridView1);
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM purchase_invoice", this.gclass.conn()).ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Close();
                        int count = this.dataGridView1.Rows.Count;
                        decimal num3 = 0M;
                        int num4 = 0;
                        while (true)
                        {
                            string str;
                            flag = num4 < count;
                            if (!flag)
                            {
                                this.dataGridView1.Rows.Add(2);
                                int num5 = this.dataGridView1.Rows.Count - 1;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.dataGridView1.Rows[num5].DefaultCellStyle.Font = new Font("verdana", 12f);
                                this.dataGridView1.Rows[num5].Cells[1].Value = "S/N";
                                this.dataGridView1.Rows[num5].Cells[2].Value = "VENDOR";
                                this.dataGridView1.Rows[num5].Cells[3].Value = "AMOUNT";
                                int num6 = this.listBox1.Items.Count;
                                decimal num7 = 0M;
                                string str2 = null;
                                int num8 = 0;
                                while (true)
                                {
                                    if (num8 >= num6)
                                    {
                                        this.dataGridView1.Rows.Add();
                                        int num10 = this.dataGridView1.Rows.Count - 1;
                                        this.dataGridView1.Rows[num10].DefaultCellStyle.Font = new Font("verdana", 8f);
                                        this.dataGridView1.Rows[num10].Cells[1].Value = "TOTAL AMOUNT";
                                        this.dataGridView1.Rows[num10].Cells[3].Value = $"{num3:N}";
                                        this.lbltotalAmt.Text = $"{num3:N}";
                                        this.reportTitle = "Purchase Analysis Report Summary Till Date (" + this.dateTimePicker1.Value.ToString("yyyy/MM/dd") + ")";
                                        break;
                                    }
                                    str = this.listBox1.Items[num8].ToString();
                                    num4 = 0;
                                    while (true)
                                    {
                                        flag = num4 < count;
                                        if (!flag)
                                        {
                                            this.dataGridView1.Rows.Add();
                                            int num9 = this.dataGridView1.Rows.Count - 1;
                                            this.dataGridView1.Rows[num9].Cells[1].Value = num8 + 1;
                                            this.dataGridView1.Rows[num9].Cells[2].Value = str.ToString();
                                            this.dataGridView1.Rows[num9].Cells[3].Value = $"{num7:N}";
                                            num7 = 0M;
                                            num8++;
                                            break;
                                        }
                                        str2 = this.dataGridView1.Rows[num4].Cells[6].Value.ToString();
                                        if (str == str2)
                                        {
                                            num7 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                                        }
                                        num4++;
                                    }
                                }
                                break;
                            }
                            num3 += Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                            this.dataGridView1.Rows[num4].Cells[0].Value = (num4 + 1).ToString();
                            str = this.dataGridView1.Rows[num4].Cells[6].Value.ToString();
                            if (!this.listBox1.Items.Contains(str.ToString()))
                            {
                                this.listBox1.Items.Add(str);
                            }
                            num4++;
                        }
                        break;
                    }
                    this.dataGridView1.Rows.Add();
                    int num = this.dataGridView1.Rows.Count - 1;
                    this.dataGridView1.Rows[num].Cells[0].Value = reader.GetString("id");
                    this.dataGridView1.Rows[num].Cells[1].Value = reader.GetString("code");
                    this.dataGridView1.Rows[num].Cells[2].Value = reader.GetString("p_date");
                    this.dataGridView1.Rows[num].Cells[3].Value = reader.GetString("odrn");
                    this.dataGridView1.Rows[num].Cells[4].Value = reader.GetString("invoice_date");
                    this.dataGridView1.Rows[num].Cells[5].Value = reader.GetString("vendor_code");
                    this.dataGridView1.Rows[num].Cells[6].Value = reader.GetString("vendor_name");
                    this.dataGridView1.Rows[num].Cells[7].Value = reader.GetString("vendor_add");
                    this.dataGridView1.Rows[num].Cells[8].Value = reader.GetString("post_grp");
                    this.dataGridView1.Rows[num].Cells[9].Value = reader.GetString("total");
                    this.dataGridView1.Rows[num].Cells[10].Value = reader.GetString("discount");
                    this.dataGridView1.Rows[num].Cells[11].Value = reader.GetString("amt_less_discount");
                    this.dataGridView1.Rows[num].Cells[12].Value = reader.GetString("postedby");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void desc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                this.Purchase_Load(sender, e);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((this.toolStripComboBox1.SelectedIndex == 0) || (this.toolStripComboBox1.SelectedIndex == 1))
                {
                    this.panel5.Enabled = true;
                    this.panel5.Visible = true;
                    this.desc.Visible = false;
                }
                else
                {
                    this.panel5.Enabled = false;
                    this.panel5.Visible = false;
                    this.desc.Visible = true;
                    this.gclass.LoadCombo(this.desc, "SELECT * FROM vendor", "vn");
                    this.gclass.autocomplete("SELECT * FROM vendor", 1, this.desc);
                    this.desc.SelectedIndex = -1;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
