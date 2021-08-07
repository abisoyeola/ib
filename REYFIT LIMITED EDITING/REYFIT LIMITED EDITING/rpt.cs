namespace POS_SALES
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class rpt
    {
        public string DGColum(DataGridView DGVTable, string name, string header)
        {
            DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn {
                CellTemplate = new DataGridViewTextBoxCell(),
                Name = name,
                HeaderText = header
            };
            DGVTable.Columns.Add(dataGridViewColumn);
            return header;
        }

        public string rp1(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "RN", "CASH AMOUNT");
            this.DGColum(DGVTable, "RN", "POS AMOUNT");
            this.DGColum(DGVTable, "RN", "TRANSFER AMOUNT");
            this.DGColum(DGVTable, "RN", "CREDIT AMOUNT");
            this.DGColum(DGVTable, "TOTAL", "TOTAL AMOUNT");
            this.DGColum(DGVTable, "MODE", "PAYMENT MODE");
            this.DGColum(DGVTable, "reciept", "POSTED BY");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    decimal num4 = 0M;
                    decimal num5 = 0M;
                    decimal num66 = 0M;
                    decimal num7 = 0M;
                    decimal num8 = 0M;
                    decimal num9 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[1].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[3].Value = $"{num66:N}";
                            DGVTable.Rows[num6].Cells[4].Value = $"{num7:N}";
                            DGVTable.Rows[num6].Cells[5].Value = $"{num8:N}";
                            DGVTable.Rows[num6].Cells[6].Value = $"{num9:N}";
                            DGVTable.Rows[num6].Cells[7].Value = $"{num2:N}";
                            return "ola";
                        }
                        num66 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[3].Value);
                        num7 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[4].Value);
                        num8 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[5].Value);
                        num9 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[6].Value);
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[7].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("pdate");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("recieptno");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("cash");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("pos");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("transfer");
                DGVTable.Rows[num].Cells[6].Value = reader.GetString("credit");
                DGVTable.Rows[num].Cells[7].Value = reader.GetString("net_pay");
                DGVTable.Rows[num].Cells[8].Value = reader.GetString("mode");
                DGVTable.Rows[num].Cells[9].Value = reader.GetString("postedby");
            }
        }
        public string rp35(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "CASH AMOUNT");
            this.DGColum(DGVTable, "RN", "POS AMOUNT");
            this.DGColum(DGVTable, "RN", "TRANSFER AMOUNT");
            this.DGColum(DGVTable, "RN", "CREDIT AMOUNT");
            this.DGColum(DGVTable, "TOTAL", "TOTAL AMOUNT");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    decimal num66 = 0M;
                    decimal num7 = 0M;
                    decimal num8 = 0M;
                    decimal num9 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[1].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[2].Value = $"{num66:N}";
                            DGVTable.Rows[num6].Cells[3].Value = $"{num7:N}";
                            DGVTable.Rows[num6].Cells[4].Value = $"{num8:N}";
                            DGVTable.Rows[num6].Cells[5].Value = $"{num9:N}";
                            DGVTable.Rows[num6].Cells[6].Value = $"{num2:N}";
                            return "ola";
                        }
                        num66 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[2].Value);
                        num7 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[3].Value);
                        num8 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[4].Value);
                        num9 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[5].Value);
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[6].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;

                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("pdate");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("cash").ToString();
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("pos").ToString();
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("transfer").ToString();
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("credit").ToString();
                DGVTable.Rows[num].Cells[6].Value = reader.GetString("net_pay").ToString();
            }
        }

        public string rp11(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "PRODUCT CODE");
            this.DGColum(DGVTable, "RN", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "TOTAL", "INVENTORY");
            this.DGColum(DGVTable, "AMT", "RE-ORDER QTY");
            this.DGColum(DGVTable, "pn", "COST PRICE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    int num2 = 0;
                    while (true)
                    {
                        flag = num2 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            reader.Close();
                            return "ola";
                        }
                        DGVTable.Rows[num2].Cells[0].Value = num2 + 1;
                        num2++;
                    }
                }
                if (Convert.ToDecimal(reader.GetString("odr_limit")) >= Convert.ToDecimal(reader.GetString("stk")))
                {
                    DGVTable.Rows.Add();
                    int num = DGVTable.Rows.Count - 1;
                    DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                    DGVTable.Rows[num].Cells[1].Value = reader.GetString("code");
                    DGVTable.Rows[num].Cells[2].Value = reader.GetString("description");
                    DGVTable.Rows[num].Cells[3].Value = reader.GetString("stk");
                    DGVTable.Rows[num].Cells[4].Value = reader.GetString("odr_limit");
                    DGVTable.Rows[num].Cells[5].Value = reader.GetString("cp");
                    //if (Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString()) < 0M)
                    //{
                    //    DGVTable.Rows[num].Cells[3].Value = ("(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString())) + ")").ToString();
                    //}
                }
            }
        }

        public string rp15(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "TOTAL", "TOTAL AMOUNT");
            this.DGColum(DGVTable, "pn", "DISCOUNT AMOUNT");
            this.DGColum(DGVTable, "AMT", "AMOUNT LESS DISCOUNT");
            this.DGColum(DGVTable, "AMT1", "AMOUNT TENDERED");
            this.DGColum(DGVTable, "AMT2", "CHANGE DUE");
            this.DGColum(DGVTable, "AMTf", "SOLD TO");
            this.DGColum(DGVTable, "MODE", "PAYMENT MODE");
            this.DGColum(DGVTable, "reciept", "POSTED BY");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    decimal num4 = 0M;
                    decimal num5 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[1].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[3].Value = $"{num2:N}";
                            DGVTable.Rows[num6].Cells[4].Value = $"{num4:N}";
                            DGVTable.Rows[num6].Cells[5].Value = $"{num5:N}";
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[3].Value);
                        num4 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[4].Value);
                        num5 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[5].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("pdate");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("recieptno");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("net_pay");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("discount");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("amt_less_discount");
                DGVTable.Rows[num].Cells[6].Value = reader.GetString("amt_tender");
                DGVTable.Rows[num].Cells[7].Value = reader.GetString("change_due");
                DGVTable.Rows[num].Cells[8].Value = reader.GetString("customer");
                DGVTable.Rows[num].Cells[9].Value = reader.GetString("mode");
                DGVTable.Rows[num].Cells[10].Value = reader.GetString("postedby");
            }
        }

        public string rp16(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "EXPENDITURE CATEGORY");
            this.DGColum(DGVTable, "TOTAL", "DISCRIPTION");
            this.DGColum(DGVTable, "pn", "AMOUNT");
            this.DGColum(DGVTable, "AMT", "COMMENT");
            this.DGColum(DGVTable, "reciept", "POSTED BY");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num4 = num3 + 1;
                            DGVTable.Rows[num4].Cells[3].Value = "TOTAL ";
                            DGVTable.Rows[num4].Cells[4].Value = $"{num2:N}";
                            DGVTable.Rows[num4].DefaultCellStyle.Font = new Font("verdana", 8f, FontStyle.Bold);
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[4].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("pdate");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("CATEGORY");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("DESCRIPTION");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("AMOUNT");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("COMMENT");
                DGVTable.Rows[num].Cells[6].Value = reader.GetString("POSTEDBY");
            }
        }

        public string rp16Filter(DataGridView DGVTable, ToolStripComboBox filter)
        {
            filter.Items.Add(DGVTable.Columns[2].HeaderText.ToString());
            return "ola";
        }

        public string rp2(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "pdc", "PRODUCT CODE");
            this.DGColum(DGVTable, "desp", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "AMT", "QUANTITY SOLD");
            this.DGColum(DGVTable, "MODE1", "UNIT PRICE");
            this.DGColum(DGVTable, "MODE", "TOTAL");
            this.DGColum(DGVTable, "MODE1", "DISCOUNT");
            this.DGColum(DGVTable, "MODE1", "NET AMOUNT");
            this.DGColum(DGVTable, "datee", "PAYMENT MODE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    decimal num33 = 0M;
                    decimal num44 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[3].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[7].Value = $"{num2:N}";
                            DGVTable.Rows[num6].Cells[8].Value = $"{num33:N}";
                            DGVTable.Rows[num6].Cells[9].Value = $"{num44:N}";

                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[7].Value);
                        num33 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[8].Value);
                        num44 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[9].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetValue(0);
                DGVTable.Rows[num].Cells[1].Value = reader.GetValue(1);
                DGVTable.Rows[num].Cells[2].Value = reader.GetValue(3);
                DGVTable.Rows[num].Cells[3].Value = reader.GetValue(4);
                DGVTable.Rows[num].Cells[4].Value = reader.GetValue(5);
                DGVTable.Rows[num].Cells[5].Value = reader.GetValue(7);
                DGVTable.Rows[num].Cells[6].Value = reader.GetValue(8);
                DGVTable.Rows[num].Cells[7].Value = reader.GetValue(9);
                DGVTable.Rows[num].Cells[8].Value = reader.GetValue(16);
                DGVTable.Rows[num].Cells[9].Value = reader.GetValue(17);
                DGVTable.Rows[num].Cells[10].Value = reader.GetValue(2);
            }
        }
        public string rp32(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "pdc", "PRODUCT CODE");
            this.DGColum(DGVTable, "desp", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "AMT", "QUANTITY EMPTIES PURCHASE");
            this.DGColum(DGVTable, "MODE1", "EMPTIES PRICE");
            this.DGColum(DGVTable, "MODE", "TOTAL");
            this.DGColum(DGVTable, "datee", "PAYMENT MODE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[3].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[7].Value = $"{num2:N}";
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[7].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetValue(0);
                DGVTable.Rows[num].Cells[1].Value = reader.GetValue(1);
                DGVTable.Rows[num].Cells[2].Value = reader.GetValue(3);
                DGVTable.Rows[num].Cells[3].Value = reader.GetValue(4);
                DGVTable.Rows[num].Cells[4].Value = reader.GetValue(5);
                DGVTable.Rows[num].Cells[5].Value = reader.GetValue(7);
                DGVTable.Rows[num].Cells[6].Value = reader.GetValue(8);
                DGVTable.Rows[num].Cells[7].Value = reader.GetValue(9);
                DGVTable.Rows[num].Cells[8].Value = reader.GetValue(2);
            }
        }
        public string rp33(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "pdc", "PRODUCT CODE");
            this.DGColum(DGVTable, "desp", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "AMT", "QUANTITY EMPTIES REFUND");
            this.DGColum(DGVTable, "MODE1", "EMPTIES PRICE");
            this.DGColum(DGVTable, "MODE", "TOTAL");
            this.DGColum(DGVTable, "datee", "PAYMENT MODE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[3].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[7].Value = $"{num2:N}";
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[7].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetValue(0);
                DGVTable.Rows[num].Cells[1].Value = reader.GetValue(1);
                DGVTable.Rows[num].Cells[2].Value = reader.GetValue(3);
                DGVTable.Rows[num].Cells[3].Value = reader.GetValue(4);
                DGVTable.Rows[num].Cells[4].Value = reader.GetValue(5);
                DGVTable.Rows[num].Cells[5].Value = reader.GetValue(7);
                DGVTable.Rows[num].Cells[6].Value = reader.GetValue(8);
                DGVTable.Rows[num].Cells[7].Value = reader.GetValue(9);
                DGVTable.Rows[num].Cells[8].Value = reader.GetValue(2);
            }
        }
        public string rp26(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "pdc", "PRODUCT CODE");
            this.DGColum(DGVTable, "desp", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "AMT", "QUANTITY SOLD");
            this.DGColum(DGVTable, "MODE1", "UNIT PRICE");
            this.DGColum(DGVTable, "MODE", "TOTAL");
            this.DGColum(DGVTable, "datee", "PAYMENT MODE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[3].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[7].Value = $"{num2:N}";
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[7].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetValue(0);
                DGVTable.Rows[num].Cells[1].Value = reader.GetValue(1);
                DGVTable.Rows[num].Cells[2].Value = reader.GetValue(3);
                DGVTable.Rows[num].Cells[3].Value = reader.GetValue(4);
                DGVTable.Rows[num].Cells[4].Value = reader.GetValue(5);
                DGVTable.Rows[num].Cells[5].Value = reader.GetValue(7);
                DGVTable.Rows[num].Cells[6].Value = reader.GetValue(8);
                DGVTable.Rows[num].Cells[7].Value = reader.GetValue(9);
                DGVTable.Rows[num].Cells[8].Value = reader.GetValue(2);
            }
        }

        public string rp2Filter(DataGridView DGVTable, ToolStripComboBox filter)
        {
            filter.Items.Add(DGVTable.Columns[4].HeaderText.ToString());
            filter.Items.Add(DGVTable.Columns[8].HeaderText.ToString());
            return "ola";
        }
        public string rp26Filter(DataGridView DGVTable, ToolStripComboBox filter)
        {
            filter.Items.Add(DGVTable.Columns[4].HeaderText.ToString());
            filter.Items.Add(DGVTable.Columns[8].HeaderText.ToString());
            return "ola";
        }
        public string rp32Filter(DataGridView DGVTable, ToolStripComboBox filter)
        {
            filter.Items.Add(DGVTable.Columns[4].HeaderText.ToString());
            filter.Items.Add(DGVTable.Columns[8].HeaderText.ToString());
            return "ola";
        }
        public string rp33Filter(DataGridView DGVTable, ToolStripComboBox filter)
        {
            filter.Items.Add(DGVTable.Columns[4].HeaderText.ToString());
            filter.Items.Add(DGVTable.Columns[8].HeaderText.ToString());
            return "ola";
        }

        public string rp3(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "TOTAL", "TOTAL AMOUNT");
            this.DGColum(DGVTable, "pn", "DISCOUNT AMOUNT");
            this.DGColum(DGVTable, "AMT", "AMOUNT LESS DISCOUNT");
            this.DGColum(DGVTable, "MODE", "PAYMENT MODE");
            this.DGColum(DGVTable, "reciept", "POSTED BY");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    decimal num4 = 0M;
                    decimal num5 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num6 = num3 + 1;
                            DGVTable.Rows[num6].Cells[1].Value = "TOTAL ";
                            DGVTable.Rows[num6].Cells[3].Value = $"{num2:N}";
                            DGVTable.Rows[num6].Cells[4].Value = $"{num4:N}";
                            DGVTable.Rows[num6].Cells[5].Value = $"{num5:N}";
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[3].Value);
                        num4 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[4].Value);
                        num5 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[5].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("pdate");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("recieptno");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("total");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("discount");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("amt_less_discount");
                DGVTable.Rows[num].Cells[6].Value = reader.GetString("mode");
                DGVTable.Rows[num].Cells[7].Value = reader.GetString("postedby");
            }
        }

        public string rp4(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "refDoc", "REFERRED DOCTOR NAME");
            this.DGColum(DGVTable, "amount", "TOTAL TEST AMOUNT");
            this.DGColum(DGVTable, "REBATE", "DOCTOR TOTAL REBATE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                if (!reader.Read())
                {
                    reader.Close();
                    return "ola";
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetValue(0);
                DGVTable.Rows[num].Cells[1].Value = reader.GetValue(1);
                DGVTable.Rows[num].Cells[2].Value = reader.GetValue(2);
                DGVTable.Rows[num].Cells[3].Value = reader.GetValue(3);
            }
        }

        public string rp4b(DataGridView DGVTable)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "INVOICE NO");
            this.DGColum(DGVTable, "reciept", "INVOICE NO");
            this.DGColum(DGVTable, "pn", "PATIENT NAME");
            this.DGColum(DGVTable, "bamt", "BILL AMOUNT");
            this.DGColum(DGVTable, "AMT", "REBATE AMOUNT");
            return "ola";
        }

        public string rp5(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "DATE");
            this.DGColum(DGVTable, "RN", "BILL NO");
            this.DGColum(DGVTable, "reciept", "INVOICE NO");
            this.DGColum(DGVTable, "pn", "PATIENT NAME");
            this.DGColum(DGVTable, "bamt", "BILL AMOUNT");
            this.DGColum(DGVTable, "AMT", "REBATE AMOUNT");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    reader.Close();
                    decimal num2 = 0M;
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            DGVTable.Rows.Add(2);
                            int num4 = num3 + 1;
                            DGVTable.Rows[num4].Cells[6].Value = $"{num2:N}";
                            return "ola";
                        }
                        num2 += Convert.ToDecimal(DGVTable.Rows[num3].Cells[6].Value);
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetValue(0);
                DGVTable.Rows[num].Cells[1].Value = reader.GetValue(1);
                DGVTable.Rows[num].Cells[2].Value = reader.GetValue(2);
                DGVTable.Rows[num].Cells[3].Value = reader.GetValue(3);
                DGVTable.Rows[num].Cells[4].Value = reader.GetValue(4);
                DGVTable.Rows[num].Cells[5].Value = reader.GetValue(5);
                DGVTable.Rows[num].Cells[6].Value = reader.GetValue(6);
            }
        }

        public string rp7(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "PRODUCT CODE");
            this.DGColum(DGVTable, "RN", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "RN", "CATEGORY");
            this.DGColum(DGVTable, "TOTAL", "INVENTORY LIQUID");
            this.DGColum(DGVTable, "pn", "COST PRICE");
            this.DGColum(DGVTable, "AMT", "RETAIL SELLING PRICE");
            
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    int num2 = 0;
                    while (true)
                    {
                        flag = num2 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            reader.Close();
                            return "ola";
                        }
                        DGVTable.Rows[num2].Cells[0].Value = num2 + 1;
                        num2++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("code");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("description");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("dept");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("stk");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("cp");
                DGVTable.Rows[num].Cells[6].Value = reader.GetString("s_p");
                //if (Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString()) < 0M)
                //{
                //    DGVTable.Rows[num].Cells[3].Value = ("(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString())) + ")").ToString();
                //}
            }
        }
        public string rp29(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "PRODUCT CODE");
            this.DGColum(DGVTable, "RN", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "RN", "CATEGORY");
            this.DGColum(DGVTable, "TOTAL", "INVENTORY EMPTY");
           this.DGColum(DGVTable, "AMT2", "EMPTY BOTTLE PRICE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    int num2 = 0;
                    while (true)
                    {
                        flag = num2 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            reader.Close();
                            return "ola";
                        }
                        DGVTable.Rows[num2].Cells[0].Value = num2 + 1;
                        num2++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("code");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("description");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("dept");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("stk_empty");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("ws");
                //if (Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString()) < 0M)
                //{
                //    DGVTable.Rows[num].Cells[3].Value = ("(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString())) + ")").ToString();
                //}
            }
        }
        public string rp8(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "PRODUCT CODE");
            this.DGColum(DGVTable, "RN", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "TOTAL", "INVENTORY LIQUID");
            this.DGColum(DGVTable, "pn", "COST PRICE");
            this.DGColum(DGVTable, "AMT", "AMOUNT");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            decimal num = 0M;
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            reader.Close();
                            DGVTable.Rows.Add();
                            int num4 = DGVTable.Rows.Count - 1;
                            DGVTable.Rows[num4].DefaultCellStyle.ForeColor = Color.Crimson;
                            DGVTable.Rows[num4].DefaultCellStyle.Font = new Font("verdana", 10f);
                            DGVTable.Rows[num4].Cells[0].Value = "TOTAL AMOUNT";
                            DGVTable.Rows[num4].Cells[5].Value = (num >= 0M) ? $"{num:N}" : $"{num:N}";
                            return "ola";
                        }
                        DGVTable.Rows[num3].Cells[0].Value = num3 + 1;
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num2 = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num2].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num2].Cells[1].Value = reader.GetString("code");
                DGVTable.Rows[num2].Cells[2].Value = reader.GetString("description");
                DGVTable.Rows[num2].Cells[3].Value = reader.GetString("stk");
                DGVTable.Rows[num2].Cells[4].Value = reader.GetString("cp");
                DGVTable.Rows[num2].Cells[5].Value = $"{Convert.ToDecimal(reader.GetString("stk")) * Convert.ToDecimal(reader.GetString("cp")):N}";
                num += Convert.ToDecimal(DGVTable.Rows[num2].Cells[5].Value.ToString());
                //if (Convert.ToDecimal(DGVTable.Rows[num2].Cells[3].Value.ToString()) < 0M)
                //{
                //    string str = "(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num2].Cells[5].Value.ToString())) + ")";
                //    DGVTable.Rows[num2].Cells[3].Value = ("(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num2].Cells[3].Value.ToString())) + ")").ToString();
                //    DGVTable.Rows[num2].Cells[5].Value = str.ToString();
                //}
            }
        }
        public string rp30(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "PRODUCT CODE");
            this.DGColum(DGVTable, "RN", "PRODUCT CATEGORY");
            this.DGColum(DGVTable, "TOTAL", "INVENTORY EMPTIES");
            this.DGColum(DGVTable, "pn", "EMPTY BOTTLE PRICE");
            this.DGColum(DGVTable, "AMT", "AMOUNT");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            decimal num = 0M;
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    int num3 = 0;
                    while (true)
                    {
                        flag = num3 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            reader.Close();
                            DGVTable.Rows.Add();
                            int num4 = DGVTable.Rows.Count - 1;
                            DGVTable.Rows[num4].DefaultCellStyle.ForeColor = Color.Crimson;
                            DGVTable.Rows[num4].DefaultCellStyle.Font = new Font("verdana", 10f);
                            DGVTable.Rows[num4].Cells[0].Value = "TOTAL AMOUNT";
                            DGVTable.Rows[num4].Cells[5].Value = (num >= 0M) ? $"{num:N}" : $"{num:N}";
                            return "ola";
                        }
                        DGVTable.Rows[num3].Cells[0].Value = num3 + 1;
                        num3++;
                    }
                }
                DGVTable.Rows.Add();
                int num2 = DGVTable.Rows.Count - 1;
                //DGVTable.Rows[num2].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num2].Cells[1].Value = reader.GetString("code");
                DGVTable.Rows[num2].Cells[2].Value = reader.GetString("dept");
                DGVTable.Rows[num2].Cells[3].Value = reader.GetString("stk_empty");
                DGVTable.Rows[num2].Cells[4].Value = reader.GetString("ws");
                DGVTable.Rows[num2].Cells[5].Value = $"{Convert.ToDecimal(reader.GetString("stk_empty")) * Convert.ToDecimal(reader.GetString("ws")):N}";
                num += Convert.ToDecimal(DGVTable.Rows[num2].Cells[5].Value.ToString());
                //if (Convert.ToDecimal(DGVTable.Rows[num2].Cells[3].Value.ToString()) < 0M)
                //{
                //    string str = "(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num2].Cells[5].Value.ToString())) + ")";
                //    DGVTable.Rows[num2].Cells[3].Value = ("(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num2].Cells[3].Value.ToString())) + ")").ToString();
                //    DGVTable.Rows[num2].Cells[5].Value = str.ToString();
                //}
            }
        }
        public string rp9(DataGridView DGVTable, string query, MySqlConnection conn)
        {
            this.DGColum(DGVTable, "sn", "S/N");
            this.DGColum(DGVTable, "date", "PRODUCT CODE");
            this.DGColum(DGVTable, "RN", "PRODUCT DESCRIPTION");
            this.DGColum(DGVTable, "TOTAL", "INVENTORY");
            this.DGColum(DGVTable, "AMT", "RETAIL SELLING PRICE");
            this.DGColum(DGVTable, "AMT2", "EMPTY BOTTLE PRICE");
            MySqlDataReader reader = new MySqlCommand(query, conn).ExecuteReader();
            while (true)
            {
                bool flag = reader.Read();
                if (!flag)
                {
                    int num2 = 0;
                    while (true)
                    {
                        flag = num2 < DGVTable.Rows.Count;
                        if (!flag)
                        {
                            reader.Close();
                            return "ola";
                        }
                        DGVTable.Rows[num2].Cells[0].Value = num2 + 1;
                        num2++;
                    }
                }
                DGVTable.Rows.Add();
                int num = DGVTable.Rows.Count - 1;
                DGVTable.Rows[num].Cells[0].Value = reader.GetString("id");
                DGVTable.Rows[num].Cells[1].Value = reader.GetString("code");
                DGVTable.Rows[num].Cells[2].Value = reader.GetString("description");
                DGVTable.Rows[num].Cells[3].Value = reader.GetString("stk");
                DGVTable.Rows[num].Cells[4].Value = reader.GetString("s_p");
                DGVTable.Rows[num].Cells[5].Value = reader.GetString("ws");
                //if (Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString()) < 0M)
                //{
                //    DGVTable.Rows[num].Cells[3].Value = ("(" + Math.Abs(Convert.ToDecimal(DGVTable.Rows[num].Cells[3].Value.ToString())) + ")").ToString();
                //}
            }
        }
    }
}

