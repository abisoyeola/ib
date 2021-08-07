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
    public partial class Inventory_Profile_Empty : Form
    {
        private General gclass = new General();
        public Inventory_Profile_Empty()
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
                this.gclass.DGVTable2("SELECT pdate as 'POSTING DATE',code as 'CODE',description as 'DESCRIPTION',current_stock as 'CURRENT STOCK',qty as 'QUANTITY',entry_type as 'ENTRY TYPE',purpose as 'PURPOSE',postedby as 'POSTED BY' FROM product_profile_empties WHERE code = '" + this.label2.Text + "'", this.dataGridView1);
                //cmd.ExecuteNonQuery();
                int num = 0;
                while (true)
                {
                    if (num >= this.dataGridView1.Rows.Count)
                    {
                        break;
                    }
                    decimal num2 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[3].Value.ToString());
                    //if (num2 < 0M)
                    //{
                    //    string str = "(" + Math.Abs(num2).ToString() + ")";
                    //    this.dataGridView1.Rows[num].Cells[3].Value = str;
                    //}
                    decimal num3 = Convert.ToDecimal(this.dataGridView1.Rows[num].Cells[4].Value.ToString());
                    //if (num3 < 0M)
                    //{
                    //    string str2 = "(" + Math.Abs(num3).ToString() + ")";
                    //    this.dataGridView1.Rows[num].Cells[4].Value = str2;
                    //}
                    num++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
    }

