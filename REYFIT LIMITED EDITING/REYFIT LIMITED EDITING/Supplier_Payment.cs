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
    public partial class Supplier_Payment : Form
    {
        Font myfont2 = new Font("Arial", 10);
        Font myHead = new Font("Arial", 12, FontStyle.Bold);
        private string code = "";
        private General gclass = new General();
        private bool nonNumberEntered = false;
        public Supplier_Payment()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = gclass.conn();
                string str2 = (Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM supplier_account", this.gclass.conn()).ExecuteScalar().ToString()) + 1).ToString();
                this.code = (str2.ToString().Length != 1) ? ((str2.ToString().Length != 2) ? ((str2.ToString().Length != 3) ? ((str2.ToString().Length != 4) ? ((str2.ToString().Length != 5) ? (this.label1.Text + str2) : (this.label1.Text + "0" + str2)) : (this.label1.Text + "00" + str2)) : (this.label1.Text + "000" + str2)) : (this.label1.Text + "0000" + str2)) : (this.label1.Text + "00000" + str2);
                MySqlCommand jh = new MySqlCommand("insert into supplier_account (pdate,supplierid,supplier_name,mode,recieptno,paymentno,entry_type,credit,balance,postedby)VALUES('" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + customer_id.Text + "','" + customer_name.Text + "','" + mode.Text + "','" + code.ToString() + "','" + code.ToString() + "','" + Program.PAYMENT + "','" + txtAmtpaid.Text + "','" + lblBalance.Text + "','" + Program.user + "')", cn);
                jh.ExecuteNonQuery();
                this.gclass.INSERT2("UPDATE vendor SET bal = '" + this.lblBalance.Text + "' WHERE vn = '" + this.customer_name.Text + "' ");
                this.gclass.success("Supplier Account Updated Successfully");
                listBox1.Items.Add(Program.companyNameRcpt1.ToString());
                listBox1.Items.Add(Program.companyAddressPos.ToString());
                listBox1.Items.Add("\n\n");
                listBox1.Items.Add("Phone: " + Program.companyPhone.ToString());
                listBox1.Items.Add("PAYMENT RECIEPT");
                listBox1.Items.Add("Date: " + lblSession.Text);
                listBox1.Items.Add("Time: " + lblTerm.Text);

                for (int x = 0; x < dataGridView1.Rows.Count; x++)

                {

                }
                listBox1.Items.Add("          Receipt No: " + str2.ToString());
                listBox1.Items.Add("         Customer Id: " + customer_id.Text);
                listBox1.Items.Add("       Customer Name: " + customer_name.Text);
                listBox1.Items.Add("  Oustanding Balance: " + lblOutstandingbalance.Text);
                listBox1.Items.Add("         Amount Paid: " + txtAmtpaid.Text);
                listBox1.Items.Add("     Current Balance: " + lblBalance.Text);
                listBox1.Items.Add("        Payment Mode: " + mode.Text);
                listBox1.Items.Add("           Issued By: " + Program.user);
                listBox1.Items.Add("Thank You For Your Patronage....");
                listBox1.Items.Add("");
                listBox1.Items.Add(DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:t}", dateTimePicker1.Text));


                printPreviewDialog1.Document = printDocument1;
                ((Form)printPreviewDialog1).WindowState = FormWindowState.Normal;
                printPreviewDialog1.ShowDialog();
                base.Close();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblOutstandingbalance.Text = Supplier_Inventory.balance.ToString();
                this.customer_id.Text = Supplier_Inventory.code.ToString();
                this.customer_name.Text = Supplier_Inventory.name.ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
       private void button6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.lblSession.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.lblTerm.Text = DateTime.Now.ToString("T");
        }

        private void txtAmtpaid_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                this.nonNumberEntered = false;
                if ((((e.KeyCode < Keys.D0) || (e.KeyCode > Keys.D9)) && ((e.KeyCode < Keys.NumPad0) || (e.KeyCode > Keys.NumPad9))) && (e.KeyCode != Keys.Back))
                {
                    this.nonNumberEntered = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtAmtpaid_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = this.nonNumberEntered;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void txtAmtpaid_Leave_1(object sender, EventArgs e)
        {
            this.txtAmtpaid.Text = $"{Convert.ToDecimal(this.txtAmtpaid.Text):N}";
        }

        private void txtAmtpaid_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                this.lblBalance.Text = $"{Convert.ToDecimal(this.lblOutstandingbalance.Text) + Convert.ToDecimal(this.txtAmtpaid.Text):N}";
            }
            catch (Exception)
            {
                this.txtAmtpaid.SelectAll();
                this.txtAmtpaid.Text = "0.00";
                this.txtAmtpaid.Focus();
                this.lblBalance.Text = (Convert.ToDecimal(this.lblOutstandingbalance.Text) + Convert.ToDecimal(this.txtAmtpaid.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str2 = (Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM supplier_account", this.gclass.conn()).ExecuteScalar().ToString()) + 1).ToString();
            this.code = (str2.ToString().Length != 1) ? ((str2.ToString().Length != 2) ? ((str2.ToString().Length != 3) ? ((str2.ToString().Length != 4) ? ((str2.ToString().Length != 5) ? (this.label1.Text + str2) : (this.label1.Text + "0" + str2)) : (this.label1.Text + "00" + str2)) : (this.label1.Text + "000" + str2)) : (this.label1.Text + "0000" + str2)) : (this.label1.Text + "00000" + str2);
            listBox1.Items.Add(Program.companyNameRcpt1.ToString());
            listBox1.Items.Add(Program.companyAddressPos.ToString());
            //listBox1.Items.Add("Email: " + Program.companyEmail.ToString());
            listBox1.Items.Add("Phone: " + Program.companyPhone.ToString());
            listBox1.Items.Add("====================================================================");
            listBox1.Items.Add("PAYMENT RECIEPT");
            listBox1.Items.Add("Date: " + lblSession.Text);
            listBox1.Items.Add("Time :" + lblTerm.Text);

            for (int x = 0; x < dataGridView1.Rows.Count; x++)

            {

            }
            listBox1.Items.Add("          Receipt No: " + str2.ToString());
            listBox1.Items.Add("         Customer Id: " + customer_id.Text);
            listBox1.Items.Add("       Customer Name: " + customer_name.Text);
            listBox1.Items.Add("  Oustanding Balance: " + lblOutstandingbalance.Text);
            listBox1.Items.Add("         Amount Paid: " + txtAmtpaid.Text);
            listBox1.Items.Add("     Current Balance: " + lblBalance.Text);
            listBox1.Items.Add("        Payment Mode: " + mode.Text);
            listBox1.Items.Add("           Issued By: " + Program.user);
            listBox1.Items.Add("Thank You For Your Patronage....");
            listBox1.Items.Add("");
            listBox1.Items.Add(DateTime.Now.ToString("dd/MM/yyyy") + " " + String.Format("{0:t}", dateTimePicker1.Text));


            printPreviewDialog1.Document = printDocument1;
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Normal;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 20, y = 20, i = 0;
            foreach (string str in listBox1.Items)
            {
                if (str == "REYFIT LIMITED")
                {
                    e.Graphics.DrawString(str, myHead, Brushes.Black, x, y);
                }
                else
                {
                    e.Graphics.DrawString(str, myfont2, Brushes.Black, x, y);
                }
                y += 25;
                i++;
            }
        }
    }
}

