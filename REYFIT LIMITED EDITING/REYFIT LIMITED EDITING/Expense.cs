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
    public partial class Expense : Form
    {
        private General gclass = new General();
        public Expense()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection ibb = gclass.conn();
               // ibb.Open();
                MySqlCommand button1 = new MySqlCommand("insert into expenditure(pdate,category,reference_no,description,amount,comment,postedby)VALUES('" + today.Text + "','" + category.Text + "','" + ref_no.Text + "','" + desc.Text + "','" + amt.Text + "','" + comment.Text + "','" +Program.user + "')", ibb);
                button1.ExecuteNonQuery();

                MessageBox.Show("Expenses Successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.category.SelectedIndex = -1;
                this.desc.Text = null;
                this.ref_no.Text = null;
                this.amt.Text = "0.00";
                this.comment.Text = null;
              //  ibb.Close();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        private void Expense_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Expenditure().ShowDialog();
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            try
            {
                this.gclass.LoadCombo(this.category, "SELECT * FROM expense_cat", "name");
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
