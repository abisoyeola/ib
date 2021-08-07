namespace POS_SALES
{
    using Microsoft.Office.Interop.Excel;
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Net.NetworkInformation;
    internal class General
    {
        public string access(string identify)
        {
            int num = -1;
            if ((Program.user == "IBRAHIM") && (User_Login.sendgrp == "DEVELOPER"))
            {
                num = 1;
            }
            else
            {
                string[] strArray = new string[] { "SELECT * FROM tbl_subject_allocation WHERE staff_id='", Program.user, "' AND subject_id ='", identify, "'" };
                MySqlDataReader reader = new MySqlCommand(string.Concat(strArray), this.conn()).ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    num = 1;
                }
                else
                {
                    reader.Close();
                    num = 0;
                }
            }
            return num.ToString();
        }

        public string autocomplete(string query, int num, ComboBox cmb)
        {
            AutoCompleteStringCollection strings = new AutoCompleteStringCollection();
            MySqlDataReader reader = new MySqlCommand(query, this.conn()).ExecuteReader();
            while (true)
            {
                if (!reader.Read())
                {
                    cmb.AutoCompleteCustomSource = strings;
                    return num.ToString();
                }
                strings.Add(reader.GetString(num));
            }
        }

        public string backup(string location)
        {
            string str;
            MySqlConnection connection;
            MySqlCommand command;
            MySqlBackup backup;
            if (Directory.Exists(location + "STK-BKUP"))
            {
                Directory.CreateDirectory(location + @"STK-BKUP\" + DateTime.Today.ToString("dd-MM-yyyy"));
                str = location + @"STK-BKUP\" + DateTime.Today.ToString("dd-MM-yyyy") + "/backup.sql";
                connection = this.conn();
                try
                {
                    command = new MySqlCommand();
                    try
                    {
                        backup = new MySqlBackup(command);
                        try
                        {
                            command.Connection = connection;
                            backup.ExportToFile(str);
                            connection.Close();
                        }
                        finally
                        {
                            if (!ReferenceEquals(backup, null))
                            {
                                backup.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (!ReferenceEquals(command, null))
                        {
                            command.Dispose();
                        }
                    }
                }
                finally
                {
                    if (!ReferenceEquals(connection, null))
                    {
                        connection.Dispose();
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(location + "STK-BKUP");
                Directory.CreateDirectory(location + @"STK-BKUP\" + DateTime.Today.ToString("dd-MM-yyyy"));
                str = location + @"STK-BKUP\" + DateTime.Today.ToString("dd-MM-yyyy") + "/backup.sql";
                connection = this.conn();
                try
                {
                    command = new MySqlCommand();
                    try
                    {
                        backup = new MySqlBackup(command);
                        try
                        {
                            command.Connection = connection;
                            backup.ExportToFile(str);
                            connection.Close();
                        }
                        finally
                        {
                            if (!ReferenceEquals(backup, null))
                            {
                                backup.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (!ReferenceEquals(command, null))
                        {
                            command.Dispose();
                        }
                    }
                }
                finally
                {
                    if (!ReferenceEquals(connection, null))
                    {
                        connection.Dispose();
                    }
                }
            }
            return "ola";
        }

        public string cat(int query)
        {
            string str = null;
            switch (query)
            {
                case 0:
                    str = "A";
                    break;

                case 1:
                    str = "B";
                    break;

                case 2:
                    str = "C";
                    break;

                case 3:
                    str = "D";
                    break;

                case 4:
                    str = "E";
                    break;

                case 5:
                    str = "F";
                    break;

                case 6:
                    str = "G";
                    break;

                case 7:
                    str = "H";
                    break;

                case 8:
                    str = "I";
                    break;

                case 9:
                    str = "J";
                    break;

                case 10:
                    str = "K";
                    break;

                case 11:
                    str = "L";
                    break;

                case 12:
                    str = "M";
                    break;

                case 13:
                    str = "N";
                    break;

                case 14:
                    str = "O";
                    break;

                case 15:
                    str = "P";
                    break;

                case 0x10:
                    str = "Q";
                    break;

                case 0x11:
                    str = "R";
                    break;

                case 0x12:
                    str = "S";
                    break;

                case 0x13:
                    str = "T";
                    break;

                case 20:
                    str = "U";
                    break;

                case 0x15:
                    str = "V";
                    break;

                case 0x16:
                    str = "W";
                    break;

                case 0x17:
                    str = "X";
                    break;

                case 0x18:
                    str = "Y";
                    break;

                case 0x19:
                    str = "Z";
                    break;

                default:
                    break;
            }
            return str;
        }

        public MySqlConnection conn()
        {
            //MySqlConnection connection = new MySqlConnection("Server=SERVER;Uid=pos;Password='pos';Database= bottle_sales_pos;");
            MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Password='';Database= bottle_sales_pos;");
            connection.Open();
            return connection;
        }

        public string DGVTable(string query, DataGridView dataGridView1)
        {
            DataSet dataSet = new DataSet();
            new MySqlDataAdapter(new MySqlCommand(query, this.conn())).Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
            return query;
        }

        public string DGVTable2(string query, DataGridView dataGridView1)
        {
            DataSet dataSet = new DataSet();
            new MySqlDataAdapter(new MySqlCommand(query, this.conn())).Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
            return query;
        }

        public string error(string err)
        {
            MessageBox.Show(err, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return err;
        }

        public string export_to_excell(DataGridView dataGridView1)
        {
            try
            {
                dataGridView1.SelectAll();
                DataObject clipboardContent = dataGridView1.GetClipboardContent();
                if (!ReferenceEquals(clipboardContent, null))
                {
                    Clipboard.SetDataObject(clipboardContent);
                }
                object template = Missing.Value;
                Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(System.Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
                application.Visible = true;
                Workbook workbook = application.Workbooks.Add(template);
                Worksheet worksheet = (Worksheet) workbook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range format = (Microsoft.Office.Interop.Excel.Range) worksheet.Cells[1, 1];
                format.Select();
                worksheet.PasteSpecial(format, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
            return "sola";
        }

        public string getcode(string query) => 
            query;

        public string INSERT(string query)
        {
            new MySqlCommand(query, this.conn()).ExecuteNonQuery();
            this.success("Record Posted Succesfully.");
            return query;
        }

        public string INSERT2(string query)
        {
            new MySqlCommand(query, this.conn()).ExecuteNonQuery();
            return query;
        }

        public string LoadCombo(ComboBox cmb, string query, string field)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            new MySqlDataAdapter(new MySqlCommand(query, this.conn())).Fill(dataTable);
            cmb.DataSource = dataTable;
            cmb.ValueMember = field;
            cmb.SelectedIndex = -1;
            return query.ToString();
        }

        public string LoadListBox(System.Windows.Forms.ListBox cmb, string query, string field)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            new MySqlDataAdapter(new MySqlCommand(query, this.conn())).Fill(dataTable);
            cmb.DataSource = dataTable;
            cmb.ValueMember = field;
            return query.ToString();
        }

        public string print(PrintDocument printDocument1)
        {
            if (new PrintDialog().ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            return "Sola";
        }

        public string printdocument(DataGridView dgv_to_print, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(dgv_to_print.Width, dgv_to_print.Height);
            dgv_to_print.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, dgv_to_print.Width, dgv_to_print.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
            if (1 <= 12)
            {
                e.HasMorePages = false;
            }
            return "Sola";
        }

        public string success(string err)
        {
            MessageBox.Show(err, "Message Center", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return err;
        }
    }
}

