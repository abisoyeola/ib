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
    public partial class User_Account_Role : Form
    {
        public static string identify = "18";
        private General gclass = new General();
        public static string staff_id = "";
        public User_Account_Role()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = this.gclass.conn();
            try
            {
                if (this.listBox2.Items.Count == 0)
                {
                    MessageBox.Show("No Subject available to remove.\n List is empty.", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    object[] objArray = new object[] { "DELETE FROM tbl_subject_allocation WHERE staff_id='", this.listBox3.Items[this.comboBox1.SelectedIndex], "' AND subject_id='", this.listBox4.Items[this.listBox2.SelectedIndex], "'" };
                    new MySqlCommand(string.Concat(objArray), connection).ExecuteNonQuery();
                    MessageBox.Show("Role Successfully Removed", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.listBox2.Items.Clear();
                this.listBox4.Items.Clear();
                staff_id = this.listBox3.Items[this.comboBox1.SelectedIndex].ToString();
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM tbl_subject_allocation WHERE staff_id='" + staff_id.ToString() + "'  ", connection).ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Close();
                        int num = 0;
                        while (true)
                        {
                            flag = num < this.listBox4.Items.Count;
                            if (!flag)
                            {
                                break;
                            }
                            string str = this.listBox4.Items[num].ToString();
                            str = this.listBox1.Items[Convert.ToInt32(str)].ToString();
                            this.listBox2.Items.Add(str);
                            num++;
                        }
                        break;
                    }
                    this.listBox4.Items.Add(reader.GetString("subject_id"));
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = this.gclass.conn();
            try
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(this.listBox1.SelectedItem.ToString()))
                    {
                        if (this.comboBox1.SelectedIndex != -1)
                        {
                            int num;
                            bool flag;
                            object[] objArray;
                            if (this.listBox2.Items.Count <= 0)
                            {
                                objArray = new object[] { "INSERT iNTO tbl_subject_allocation(staff_id,subject_id)VALUES('", this.comboBox1.Text, "','", this.listBox1.SelectedIndex, "')" };
                                new MySqlCommand(string.Concat(objArray), connection).ExecuteNonQuery();
                                MessageBox.Show("Role Successfully Allocated to the Selected User...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                num = 0;
                                while (true)
                                {
                                    flag = num < this.listBox2.Items.Count;
                                    if (flag)
                                    {
                                        if (this.listBox2.Items[num].ToString() != this.listBox1.SelectedItem.ToString())
                                        {
                                            num++;
                                            continue;
                                        }
                                        MessageBox.Show("Role Already Selected", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        return;
                                    }
                                    else
                                    {
                                        objArray = new object[] { "INSERT iNTO tbl_subject_allocation(staff_id,subject_id)VALUES('", this.comboBox1.Text, "','", this.listBox1.SelectedIndex, "')" };
                                        new MySqlCommand(string.Concat(objArray), connection).ExecuteNonQuery();
                                        MessageBox.Show("Role Successfully Allocated to the Selected User...", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                    break;
                                }
                            }
                            this.listBox2.Items.Clear();
                            this.listBox4.Items.Clear();
                            staff_id = this.listBox3.Items[this.comboBox1.SelectedIndex].ToString();
                            MySqlDataReader reader = new MySqlCommand("SELECT * FROM tbl_subject_allocation WHERE staff_id='" + staff_id.ToString() + "'  ", connection).ExecuteReader();
                            while (true)
                            {
                                flag = reader.Read();
                                if (!flag)
                                {
                                    reader.Close();
                                    num = 0;
                                    while (true)
                                    {
                                        flag = num < this.listBox4.Items.Count;
                                        if (!flag)
                                        {
                                            break;
                                        }
                                        string str = this.listBox4.Items[num].ToString();
                                        str = this.listBox1.Items[Convert.ToInt32(str)].ToString();
                                        this.listBox2.Items.Add(str);
                                        num++;
                                    }
                                    break;
                                }
                                this.listBox4.Items.Add(reader.GetString("subject_id"));
                            }
                        }
                        else
                        {
                            MessageBox.Show("No User Selected", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Selection", "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception exception1)
                {
                    MessageBox.Show(exception1.Message, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            finally
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = this.gclass.conn();
            try
            {
                this.listBox2.Items.Clear();
                this.listBox4.Items.Clear();
                staff_id = this.listBox3.Items[this.comboBox1.SelectedIndex].ToString();
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM tbl_subject_allocation WHERE staff_id='" + staff_id.ToString() + "'  ", connection).ExecuteReader();
                while (true)
                {
                    bool flag = reader.Read();
                    if (!flag)
                    {
                        reader.Close();
                        int num = 0;
                        while (true)
                        {
                            flag = num < this.listBox4.Items.Count;
                            if (!flag)
                            {
                                break;
                            }
                            string str = this.listBox4.Items[num].ToString();
                            str = this.listBox1.Items[Convert.ToInt32(str)].ToString();
                            this.listBox2.Items.Add(str);
                            num++;
                        }
                        break;
                    }
                    this.listBox4.Items.Add(reader.GetString("subject_id"));
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                connection.Close();
            }
        }

        private void User_Account_Role_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = this.gclass.conn();
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                MySqlDataReader reader = new MySqlCommand("SELECT * FROM user_reg", connection).ExecuteReader();
                while (true)
                {
                    if (!reader.Read())
                    {
                        reader.Close();
                        break;
                    }
                    this.comboBox1.Items.Add(reader.GetString("username"));
                    this.listBox3.Items.Add(reader.GetString("username"));
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
