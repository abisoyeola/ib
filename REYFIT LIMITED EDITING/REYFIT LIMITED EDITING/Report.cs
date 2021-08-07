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
    public partial class Report : Form
    {
        private General gclass = new General();
        public static string reportTitle = "";
        public static string identify = "13";
        public static string reportSubTitle = "";
        public static string reportid = "";
        public static string reportfrom = "";
        public static string reportto = "";
        public static string reportgroup = "";
        public static string reportquery = "";
        public static string reportquery2 = "";
        public static string reportsubquery = "";
        public static string iden = "0";
        public static DateTime from = DateTime.Now;
        public static DateTime to = DateTime.Now;
        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string[] strArray;
                if (!this.date.Checked)
                {
                    iden = "0";
                }
                else
                {
                    iden = "1";
                    reportfrom = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
                    reportto = this.dateTimePicker2.Value.ToString("yyyy/MM/dd");
                    strArray = new string[] { " WHERE pdate BETWEEN '", reportfrom, "' AND '", reportto, "' " };
                    reportsubquery = string.Concat(strArray);
                    reportquery = reportquery + reportsubquery;
                    from = this.dateTimePicker1.Value;
                    to = this.dateTimePicker1.Value;
                }
                if (reportid == "rp1")
                {
                    reportTitle = !this.date.Checked ? ("Sales Analysis Report Summary By Payment Modes Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Sales Analysis Report Summary By Payment Modes From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp2")
                {
                    reportTitle = !this.date.Checked ? ("Detail Sales Analysis Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Detail Sales Analysis Report From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp32")
                {
                    reportTitle = !this.date.Checked ? ("Detail Empties Purchase (Deposit) Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Detail Sales Analysis Report From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp33")
                {
                    reportTitle = !this.date.Checked ? ("Detail Empties Refund (Deposit) Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Detail Sales Analysis Report From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                    new Sales_Analysis_Report().ShowDialog();
                }
                //else if (reportid == "rp35")
                //{
                //    reportTitle = !this.date.Checked ? ("Daily Sales Analysis By Payment Modes Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Daily Sales Analysis By Payment Modes Report From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                //    new Sales_Analysis_Report().ShowDialog();
                //}
                else if (reportid == "rp36")
                {
                    reportTitle = !this.date.Checked ? ("Suppliers Statement of Account Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Suppliers Statement of Account Report From " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                    new Supplier_Account().ShowDialog();
                }
                else if (reportid == "rp3")
                {

                    if (this.date.Checked)
                    {
                        strArray = new string[] { "Detail Sales Analysis Report by Cashier From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\nCashier Name:\t", this.cmbgroup.Text };
                        reportTitle = string.Concat(strArray);
                        reportquery = reportquery + " AND postedby = '" + this.cmbgroup.Text + "'";
                    }
                    else
                    {
                        reportquery = reportquery + " WHERE postedby = '" + this.cmbgroup.Text + "'";
                        strArray = new string[] { "Detail Sales Analysis Report by Cashier ", this.cmbgroup.Text, "  Till Date (", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), ")\nCashier Name:\t", this.cmbgroup.Text };
                        reportTitle = string.Concat(strArray);
                    }

                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp6")
                {
                    if (this.date.Checked)
                    {
                        strArray = new string[] { "Showing Sales Analysis Report for ", this.cmbgroup.Text, " From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy") };
                        reportTitle = string.Concat(strArray);
                    }
                    else
                    {
                        strArray = new string[] { "Showing Sales Analysis Report for ", this.cmbgroup.Text, " Till Date (", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), ")" };
                        reportTitle = string.Concat(strArray);
                    }
                    reportquery = reportquery + " AND examination_detail.cd = '" + this.cmbgroup.Text + "'";
                    base.Hide();
                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp4")
                {
                    reportTitle = !this.date.Checked ? ("All Doctors Rebate Analysis Summary Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("All Doctors Rebate Analysis Summary Report from " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));
                    reportquery = reportquery + " GROUP BY patient_diagnosis.rdn";
                    base.Hide();
                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp5")
                {
                    if (!this.date.Checked)
                    {
                        reportTitle = "Detail Rebate Analysis Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")\n Doctor Name:\t " + this.cmbgroup.Text;
                    }
                    else
                    {
                        strArray = new string[] { "Detail Rebate Analysis Report from ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\n Doctor Name:\t ", this.cmbgroup.Text };
                        reportTitle = string.Concat(strArray);
                    }
                    reportquery = reportquery + " AND patient_diagnosis.rdn = '" + this.cmbgroup.Text + "' GROUP BY examination_summary.rn";
                    base.Hide();
                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp10")
                {
                    reportTitle = !this.date.Checked ? ("Sales Transaction Report Summary \n\nfrom Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")") : ("Sale Transaction Report Summary \n\nfrom " + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + " TO " + this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));

                    new Transction_Report_Summary().ShowDialog();
                }
                else if (reportid == "rp24")
                {
                    reportTitle = !this.date.Checked ? "Customer Statement of Account Report" : "Customer Statement of Account Report";
                    base.Hide();
                    new Customer_Account().ShowDialog();
                }
                else if (reportid == "rp26")
                {
                    reportTitle = !this.date.Checked ? "Customer Creditors Account Report" : "Customer Creditors Account Report";
                    base.Hide();
                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp27")
                {
                    reportTitle = !this.date.Checked ? "Expenses" : "Expenses";
                    base.Hide();
                    new Income_Expenses().ShowDialog();
                }
                else if (reportid == "rp28")
                {
                    reportTitle = !this.date.Checked ? "Empties Stock Inflow/Outflow Analysis" : "Empties Stock Inflow/Outflow Analysis";
                    base.Hide();
                    new Empties_Stock().ShowDialog();
                }
                else if (reportid == "rp7")
                {
                    reportTitle = !this.date.Checked ? "Stock Position" : "Stock Position";
                    base.Hide();
                    new Stock_Report().ShowDialog();
                }
                else if (reportid == "rp29")
                {
                    reportTitle = !this.date.Checked ? "Stock Position" : "Stock Position";
                    base.Hide();
                    new Stock_Report().ShowDialog();
                }
                else if (reportid == "rp20")
                {
                    reportTitle = !this.date.Checked ? "Sales Invoice Report" : "Sales Invoice Report";
                    base.Hide();
                    new Sales_Invoice_Report().ShowDialog();
                }
                else if (reportid == "rp34")
                {
                    reportTitle = !this.date.Checked ? "Stock Position Empties Summary" : "Stock Position Empties Summary";
                    base.Hide();
                    new Stock_Position_Summary().ShowDialog();
                }
                else if (reportid == "rp8")
                {
                    reportTitle = !this.date.Checked ? "Stock Valuation Liquid" : "Stock Valuation Liquid";
                    base.Hide();
                    new Stock_Report().ShowDialog();
                }
                else if (reportid == "rp30")
                {
                    reportTitle = !this.date.Checked ? "Stock Valuation Empties Summary" : "Stock Valuation Empties Summary";
                    base.Hide();
                    new Stock_Valuation_Summary().ShowDialog();
                }
                else if (reportid == "rp9")
                {
                    reportTitle = !this.date.Checked ? "PRODUCT LISTING" : "PRODUCT LISTING";
                    base.Hide();
                    new Stock_Report().ShowDialog();
                }
                else if (reportid == "rp11")
                {
                    reportTitle = !this.date.Checked ? "Out of Stock" : "Out of Stock";
                    base.Hide();
                    new Stock_Report().ShowDialog();
                }
                else if (reportid == "rp12")
                {
                    if (this.date.Checked)
                    {

                    }

                    new Sales_Return_Report().ShowDialog();
                }
                else if (reportid == "rp13")
                {

                    if (!this.date.Checked)
                    {
                        reportTitle = " DETAIL SALES && STOCK REPORT(" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")";
                        reportquery = "SELECT * FROM sales_detail ORDER BY id DESC";
                        reportquery2 = "SELECT * FROM product_profile ORDER BY id DESC";
                    }
                    else
                    {

                        strArray = new string[] { " DETAIL SALES && STOCK REPORT(", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), ")" };
                        reportTitle = string.Concat(strArray);
                        strArray = new string[] { "SELECT * FROM sales_detail WHERE pdate BETWEEN '", reportfrom, "' AND '", reportto, "' ORDER BY id DESC" };
                        reportquery = string.Concat(strArray);
                        strArray = new string[] { "SELECT * FROM product_profile WHERE pdate BETWEEN '", reportfrom, "' AND '", reportto, "' ORDER BY id DESC" };
                        reportquery2 = string.Concat(strArray);
                    }
                    base.Hide();
                    new Detail_Sales_and_Stock_Report().ShowDialog();
                }
                else if (reportid == "rp35")
                {

                    if (!this.date.Checked)
                    {
                        reportTitle = " DAILY SALES ANALYSIS BY PAYMENT MODES REPORT(" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")";
                        reportquery = "SELECT id,pdate,cash,pos,transfer,credit,total FROM sales_summary3";
                    }
                    else
                    {

                        strArray = new string[] { " DAILY SALES ANALYSIS BY PAYMENT MODES REPORT(", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), ")" };
                        reportTitle = string.Concat(strArray);
                        strArray = new string[] { "SELECT id,pdate,cash,pos,transfer,credit,total FROM sales_summary3 WHERE pdate BETWEEN '", reportfrom, "' AND '", reportto, "' ORDER BY pdate ASC" };
                        reportquery = string.Concat(strArray);
                        
                    }
                    base.Hide();
                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp14")
                {
                    if (!this.date.Checked)
                    {
                        reportTitle = "SALES REPORT PROFILE BY CATEGORY (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")";
                    }
                    else
                    {
                        strArray = new string[] { "SALES REPORT PROFILE BY CATEGORY (", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), ")" };
                        reportTitle = string.Concat(strArray);
                    }
                    new Sales_Analysis_Profile().ShowDialog();
                }
                else if (reportid == "rp15")
                {

                    if (this.date.Checked)
                    {
                        strArray = new string[] { "Sales Analysis Profile From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\nCashier Name:\t", this.cmbgroup.Text };
                        reportTitle = string.Concat(strArray);
                        reportquery = reportquery + " AND postedby = '" + this.cmbgroup.Text + "'";
                    }
                    else
                    {
                        reportquery = reportquery + " WHERE postedby = '" + this.cmbgroup.Text + "'";
                        strArray = new string[] { "Sales Analysis Profile ", this.cmbgroup.Text, "  Till Date (", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), ")\nCashier Name:\t", this.cmbgroup.Text };
                        reportTitle = string.Concat(strArray);
                    }

                    new Sales_Analysis_Report().ShowDialog();
                }

                else if (reportid == "rp16")
                {
                    if (!this.date.Checked)
                    {
                        reportTitle = "Daily Expenditure Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")\n";
                    }
                    else
                    {
                        strArray = new string[] { "Daily Expenditure Report From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\n" };
                        reportTitle = string.Concat(strArray);
                    }

                    new Sales_Analysis_Report().ShowDialog();
                }
                else if (reportid == "rp19")
                {
                    if (!this.date.Checked)
                    {
                        reportTitle = "Purchase Report Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")\n";
                    }
                    else
                    {
                        strArray = new string[] { "Purchase Report From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\n" };
                        reportTitle = string.Concat(strArray);
                    }

                    new Purchase_Report().ShowDialog();
                }
                else if (reportid == "rp21")
                {
                    if (!this.date.Checked)
                    {
                        reportTitle = "Product Profit Analysis Report By Projection Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")\n";
                    }
                    else
                    {
                        strArray = new string[] { "Product Profit Analysis Report By Projection From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\n" };
                        reportTitle = string.Concat(strArray);
                    }

                    new Sales_Report_Qty_By_Total_Old().ShowDialog();
                }
                else if (reportid == "rp31")
                {
                    if (!this.date.Checked)
                    {
                        reportTitle = " Detail Profit Analysis Report Using FIFO Till Date (" + this.dateTimePicker1.Value.ToString("dd/MM/yyyy") + ")\n";
                    }
                    else
                    {
                        strArray = new string[] { " Detail Profit Analysis Report Using FIFO  From ", this.dateTimePicker1.Value.ToString("dd/MM/yyyy"), " TO ", this.dateTimePicker2.Value.ToString("dd/MM/yyyy"), "\n" };
                        reportTitle = string.Concat(strArray);
                    }

                    new Profit_Product_Category().ShowDialog();
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void date_CheckedChanged(object sender, EventArgs e)
        {
            this.panel4.Visible = this.date.Checked;
        }

        private void rp15_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.rp15.Checked)
                {
                    this.panel5.Visible = false;
                }
                else
                {
                    reportSubTitle = this.rp15.Text;
                    reportid = this.rp15.Name;
                    reportquery = "SELECT * FROM sales_summary";
                    this.panel5.Visible = true;
                    this.label4.Text = "Select Cashier";
                    this.gclass.LoadCombo(this.cmbgroup, "SELECT * FROM user_reg", "username");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.gclass.access(identify)) != 1)
            {
                this.gclass.error("Access Denied...");
                base.Close();
            }
        }

        private void rp10_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.rp10.Checked)
            {
                this.panel5.Visible = false;
            }
            else
            {
                reportSubTitle = this.rp10.Text;
                reportid = this.rp10.Name;
                reportquery = "SELECT id,pdate,amt_less_discount,mode,postedby,bottle_purchased,cash,pos,transfer,credit,amt_less_discount,net_pay FROM sales_summary2 ";
            }
        }

        private void rp11_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp11.Text;
                reportid = this.rp11.Name;
                reportquery = "SELECT * FROM product";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp16_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void rp2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp2.Text;
                reportid = this.rp2.Name;
                reportquery = "SELECT * FROM sales_detail";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp7_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp7.Text;
                reportid = this.rp7.Name;
                reportquery = "SELECT * FROM product";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp8.Text;
                reportid = this.rp8.Name;
                reportquery = "SELECT * FROM product";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp9_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp9.Text;
                reportid = this.rp9.Name;
                reportquery = "SELECT * FROM product";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp1.Text;
                reportid = this.rp1.Name;
                reportquery = "SELECT * FROM sales_summary2";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp12_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                reportSubTitle = this.rp12.Text;
                reportid = this.rp12.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.rp3.Checked)
                {
                    this.panel5.Visible = false;
                }
                else
                {
                    reportSubTitle = this.rp3.Text;
                    reportid = this.rp3.Name;
                    reportquery = "SELECT * FROM sales_summary";
                    this.panel5.Visible = true;
                    this.label4.Text = "Select Cashier";
                    this.gclass.LoadCombo(this.cmbgroup, "SELECT * FROM user_reg", "username");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp14_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp14.Text;
                reportid = this.rp14.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp13_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp13.Text;
                reportid = this.rp13.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp20_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp20.Text;
                reportid = this.rp20.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp19_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp19.Text;
                reportid = this.rp19.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp21_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp21.Text;
                reportid = this.rp21.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rp23_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rp27_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp27.Text;
                reportid = this.rp27.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp24_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp24.Text;
                reportid = this.rp24.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp26_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp26.Text;
                reportid = this.rp26.Name;
                reportquery = "SELECT * FROM sales_detail where mode = '" + mode.Text + "'";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp28_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp28.Text;
                reportid = this.rp28.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp29_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp29.Text;
                reportid = this.rp29.Name;
                reportquery = "SELECT * FROM product";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp30_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp30.Text;
                reportid = this.rp30.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp31_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp31.Text;
                reportid = this.rp31.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp32_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp32.Text;
                reportid = this.rp32.Name;
                reportquery = "SELECT * FROM sales_detail_empties";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp33_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp33.Text;
                reportid = this.rp33.Name;
                reportquery = "SELECT * FROM sales_detail_purchase_empties";
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp34_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp34.Text;
                reportid = this.rp34.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp35_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp35.Text;
                reportid = this.rp35.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void rp36_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                reportSubTitle = this.rp36.Text;
                reportid = this.rp36.Name;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
