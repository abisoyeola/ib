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
    public partial class Activate_Physical_Stock : Form
    {
        private General gclass = new General();
        public static string identify = "24";
        public Activate_Physical_Stock()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            MySqlConnection connection = gclass.conn();
            //foreach (DataGridViewRow row in dataGridView1.Rows)

            //    for (int x = 0; x < dataGridView1.Rows.Count - 0; x++)
                    // cn.Open();
                    //if(connection.State == System.Data.ConnectionState.Open)
                    //  {
                    //      MessageBox.Show("Open");
                    //  }
                    //else if(connection.State == System.Data.ConnectionState.Closed)
                    //  {
                    //      MessageBox.Show("Closed");
                    //  }
                    try
            {
                //StringBuilder builder = new StringBuilder();
                //List<string> values = new List<string>();
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        //builder.Append(string.Join("", values));
                        //  new MySqlCommand(builder.ToString(), this.gclass.conn()).ExecuteNonQuery();
                        MySqlConnection gg = gclass.conn();
                        MySqlCommand zy = new MySqlCommand("UPDATE tbl_stock_code SET status = 'INACTIVE'  WHERE status = 'ACTIVE' ",gg);
                        zy.ExecuteNonQuery();
                        //this.gclass.INSERT2("UPDATE tbl_stock_code SET status = 'INACTIVE' WHERE status = 'ACTIVE' ");
                        MySqlConnection tt = gclass.conn();
                        MySqlCommand xy = new MySqlCommand("DELETE FROM tbl_stock_list", tt);
                        xy.ExecuteNonQuery();
                        //this.gclass.INSERT2("DELETE FROM tbl_stock_list");

                        this.gclass.success("Stock List Posted successfully...");
                        break;
                    }
                    MySqlConnection cm = gclass.conn();
                    MySqlCommand yy = new MySqlCommand("UPDATE product SET stk = '" + this.dataGridView1.Rows[num].Cells[1].Value.ToString() + "' WHERE code = '" + this.dataGridView1.Rows[num].Cells[0].Value.ToString() + "'", cm);
                    yy.ExecuteNonQuery();
                    //values.Add($"UPDATE product SET stk =  '{MySqlHelper.EscapeString(this.dataGridView1.Rows[num].Cells[1].Value.ToString())}' WHERE code = '{MySqlHelper.EscapeString(this.dataGridView1.Rows[num].Cells[0].Value.ToString())}' ;");
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
            new View_Stock().ShowDialog();
        }

        private void Activate_Physical_Stock_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.gclass.access(identify)) != 1)
            {
                this.gclass.error("Access Denied...");
                base.Close();
            }
            this.gclass.DGVTable2("SELECT code,qty FROM tbl_stock_list WHERE status = 'POSTED'", this.dataGridView1);
        }
    }
}