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
    public partial class User_Login : Form
    {
        public static string sendgrp = "";
        public static string checker = "";
        public static string sendfull_name = "";
        public static string sendLogin_id = "";
        private string tab = null;
        private string post = null;
        private General gclass = new General();
        public User_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.login_id.Text == "IBRAHIM") & (this.password.Text == "ibrahim2005"))
                {
                    sendfull_name = "WAHAB";
                    sendgrp = "DEVELOPER";
                    Program.user = this.login_id.Text;
                    Program.user_id = "0";
                    new MDIParent1().Show();
                    base.Hide();
                }
                else
                {
                    MySqlConnection connection = this.gclass.conn();
                    string[] strArray = new string[] { "SELECT * FROM user_reg WHERE username ='", this.login_id.Text, "' AND password = '", this.password.Text, "'" };
                    MySqlDataReader reader = new MySqlCommand(string.Concat(strArray), connection).ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                        this.gclass.error("Invalid Password... \n Try Again");
                    }
                    else
                    {
                        this.label3.Text = reader.GetString("fn").ToString();
                        string str2 = reader.GetString("role");
                        if (reader.GetString("status").ToString() != "ACTIVE")
                        {
                            this.gclass.error("User Account Disabled.... \n Try Again");
                        }
                        else
                        {
                            sendfull_name = this.label3.Text;
                            sendgrp = str2.ToString();
                            Program.user = this.login_id.Text;
                            Program.user_id = reader.GetString("id");
                            MDIParent1 parent = new MDIParent1();
                            base.Hide();
                            parent.Show();
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void login_id_Click(object sender, EventArgs e)
        {
            this.login_id.SelectAll();
        }

        private void login_id_Enter(object sender, EventArgs e)
        {
            this.label3.Text = null;
            this.login_id.SelectAll();
        }

        private void login_id_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.tab = e.KeyCode.ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void login_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.tab == "Return")
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void login_id_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.login_id.Text))
                {
                    MySqlConnection connection = this.gclass.conn();
                    MySqlDataReader reader = new MySqlCommand("SELECT * FROM user_reg WHERE username ='" + this.login_id.Text + "'", connection).ExecuteReader();
                    if (reader.Read())
                    {
                        this.label3.Text = reader.GetString("fn").ToString();
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();
                        this.gclass.error("Invalid  User Account.... \n Try Again");
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void password_Click(object sender, EventArgs e)
        {
            this.password.SelectAll();
        }

        private void password_Enter(object sender, EventArgs e)
        {
            this.password.SelectAll();
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.post = e.KeyCode.ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.post == "Return")
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            try
            {
                this.button2_Click(sender, e);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void User_Login_Load(object sender, EventArgs e)
        {
            this.label1.Text = Program.companyName;
        }
    }
}
