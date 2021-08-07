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
    public partial class Greetings : Form
    {
        private General gclass = new General();
        public static string identify = "21";
        public Greetings()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.textBox1.Clear();
            //this.textBox2.Clear();
            //this.button6_Click(sender, e);

            MySqlConnection cnq = gclass.conn();

            MySqlCommand cmdq = new MySqlCommand("update  tbl_greeting set message1 ='" + textBox1.Text + "', message2='" + textBox2.Text + "' where id='" + 1 + "'", cnq);
            cmdq.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.INSERT("INSERT into tbl_greeting VALUES (id,'" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + this.textBox1.Text + "','" + this.textBox2.Text + "')");
                //MySqlDataReader reader = new MySqlCommand("SELECT * FROM tbl_greeting",  this.gclass.conn()).ExecuteReader();
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM tbl_greeting WHERE id = '" + 1 + "' ", this.gclass.conn()).ExecuteReader();
                if (reader.Read())
                {
                    Program.msg1 = reader.GetString("message1");
                    Program.msg2 = reader.GetString("message2");
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void Greetings_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.gclass.access(identify)) != 1)
            {
                this.gclass.error("Access Denied...");
                base.Close();
            }
            this.textBox1.Text = Program.msg1;
            this.textBox2.Text = Program.msg2;

        }
    }
}
