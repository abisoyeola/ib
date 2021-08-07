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
namespace POS_SALES
{
    public partial class Generate_Stock_List : Form
    {
        public static string identify = "22";
        private General gclass = new General();
        public Generate_Stock_List()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(new MySqlCommand("SELECT COUNT(*) FROM tbl_stock_code WHERE status = 'ACTIVE'", this.gclass.conn()).ExecuteScalar()) != 0)
                {
                    this.gclass.error("Invalid Command, There is an Active List.");
                }
                else
                {
                    MySqlCommand command2 = new MySqlCommand("SELECT COUNT(*) FROM tbl_stock_code", this.gclass.conn());
                    this.label2.Text = this.gclass.cat(Convert.ToInt16(command2.ExecuteScalar()));
                    this.gclass.INSERT2("INSERT INTO tbl_stock_code VALUES(id,'" + this.label2.Text + "','ACTIVE')");
                    this.gclass.INSERT2("INSERT INTO `bottle_sales_pos`.`tbl_stock_list`(code,description,stk) SELECT code,description,stk FROM `bottle_sales_pos`.`product`");
                    this.gclass.INSERT2("UPDATE tbl_stock_list SET qty = '0', status= 'UNPOSTED',Listcode = '" + this.label2.Text + "' ");
                    this.gclass.success("List Generated successfully...");
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Generate_Stock_List_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.gclass.access(identify)) != 1)
            {
                this.gclass.error("Access Denied...");
                base.Close();
            }
        }
    }
}
