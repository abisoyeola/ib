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
using System.IO;
namespace POS_SALES
{
    public partial class MDIParent1 : Form
    {
        public static string pic_id = User_Login.sendfull_name.ToString();
        private int childFormNumber = 0;
        private General gclass = new General();
        public MDIParent1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accountRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new User_Account_Role().ShowDialog();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void accountCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seasonGreeetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creditorBalancePaymentSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void postPurchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewMenu_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void report_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_DisplayStyleChanged(object sender, EventArgs e)
        {

        }

        private void productDisposaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void postSalesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionReportSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesReportQtyWithTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createCreditorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailySalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateStockSheetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void enterStockCountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void postStockCountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Product_Inventory().ShowDialog();
        }

        private void cardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Bank_Card().ShowDialog();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Expenditure_category().ShowDialog();
        }

        private void expensesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Expenditure().ShowDialog();
        }

        private void productCardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Product_Inventory().ShowDialog();
        }

        private void productJournalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Product_Journal_Empties().ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new POS_Sales1().ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new Purchase_Invoice().ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Are You Sure You Want To Close This Application ?", "Exit Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center");
            }
        }

        private void stockDisposalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Product_Disposal().ShowDialog();
        }

        private void generateStockSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Generate_Stock_List().ShowDialog();
        }

        private void viewAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new View_Stock().ShowDialog();
        }

        private void enterStockSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Post_Stock().ShowDialog();
        }

        private void postStockCountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Activate_Physical_Stock().ShowDialog();
        }

        private void salesPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new POS_Sales1().ShowDialog();
        }

        private void cashierSalesReportSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Daily_Transaction_Report_Summary().ShowDialog();
        }

        private void postSalesReturnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Sales_Return().ShowDialog();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sales_Return_Report().ShowDialog();
        }

        private void customerAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customer_Inventory().ShowDialog();
        }

        private void salesReportQtyWithTotalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Sales_Report_Qty_By_Total().ShowDialog();
        }

        private void transactionReportSummaryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Transction_Report_Summary2().ShowDialog();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Supplier_Inventory().ShowDialog();
        }

        private void postPurchaseInvoiceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Purchase_Invoice().ShowDialog();
        }

        private void postPurchaseInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Purchase().ShowDialog();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Report().ShowDialog();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Product_Category().ShowDialog();
        }

        private void accountCategoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new User_Account().ShowDialog();
        }

        private void userToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new User_Account_Form().ShowDialog();
        }

        private void accountRoleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new User_Account_Role().ShowDialog();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Backup().ShowDialog();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            this.Text = "PACK SALES & STOCK MANAGEMENT SYSTEM - Version 2.0";
            this.toolStripMenuItem1.Text = "Powered By : Microgold Computers  (08038402421).";
            this.Text = this.Text + "  (" + Program.companyName + ")";
            this.user.Text = Program.user.ToString();
            this.sendgrp.Text = User_Login.sendgrp;
            this.fullname.Text = User_Login.sendfull_name;
            this.timer1.Start();
            string path = Application.StartupPath + "/images/bground.png";
            string str2 = Application.StartupPath + "/images/bground.jpg";
            if (File.Exists(path))
            {
                this.pictureBox1.Image = Image.FromFile(path);
            }
            else if (File.Exists(str2))
            {
                this.pictureBox1.Image = Image.FromFile(str2);
            }
            MySqlDataReader reader = new MySqlCommand("SELECT * FROM tbl_greeting", this.gclass.conn()).ExecuteReader();
            if (reader.Read())
            {
                Program.msg1 = reader.GetString("message1");
                Program.msg2 = reader.GetString("message2");
            }
            reader.Close();
        }

        private void seasonGreetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Greetings().ShowDialog();
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Are You Sure You Want To Close This Application ?", "Exit Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Sales_Invoice().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Report().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new Product_Inventory().ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new POS_Sales1().ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Purchase_Invoice().ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Report().ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Are You Sure You Want To Close This Application ?", "Exit Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center");
            }
        }

        private void productQtySaleReportOldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sales_Report_Qty_By_Total_Old().ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new Discount_Markup().ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Post_Empties().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Purchase_Empties().ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Purchase_Empties().ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            new Product_Journal().ShowDialog();
        }

        private void emptiesOutsideReturnedToMajorSuppliersOUTFLOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Return_Supplier().ShowDialog();
        }

        private void postInflowAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Inflow().ShowDialog();
        }

        private void postOutflowAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Outflow().ShowDialog();
        }

        private void viewCashAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new View_Cash_Account().ShowDialog();
        }

        private void productProfitAnalysisReportByProjectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sales_Report_Qty_By_Total_Old().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Post_Empties().ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Post_Empties().ShowDialog();
        }

        private void fifoOrderJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Fifo_Order_Journal().ShowDialog();
        }
    }
}
