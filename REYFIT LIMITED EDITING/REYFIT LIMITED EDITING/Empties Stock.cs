using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
using System.Collections;

namespace POS_SALES
{
    
    public partial class Empties_Stock : Form
    {
        public static string code = "";
        public static string date = "1";
        //public static string identify = "1";
        private General gclass = new General();
        public static string identify = "2";
        public Empties_Stock()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //base.Hide();
            //date = "1";
            //new Post_Empties().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //base.Hide();
            //date = "1";
            //new Post_Empties().ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.export_to_excell(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.ToString() + "\n Try Again...");
            }
        }

        private void Empties_Stock_Load(object sender, EventArgs e)
        {
            try
            {
                this.gclass.LoadCombo(this.desc, "SELECT * FROM prod_category", "category");
                this.gclass.autocomplete("SELECT * FROM prod_category", 1, this.desc);
                this.desc.SelectedIndex = -1;
                this.dataGridView1.Columns[0].Width = 40;
                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[2].Width = 90;
                this.dataGridView1.Columns[3].Width = 90;
                this.dataGridView1.Columns[4].Width = 90;
                this.dataGridView1.Columns[5].Width = 90;
                this.dataGridView1.Columns[6].Width = 80;
                this.dataGridView1.Columns[7].Width = 90;
                this.dataGridView1.Columns[8].Width = 90;
                this.dataGridView1.Columns[9].Width = 120;
                this.dataGridView1.Columns[10].Width = 70;
                this.dataGridView1.Columns[11].Width = 100;
                this.dataGridView1.Columns[12].Width = 70;
                this.dataGridView1.Columns[13].Width = 100;
                string[] strArray = new string[] { "SELECT id as 'S/N',pdate as 'Posting Date',post1 as 'Opening Balance(Empties Outside)',post2 as 'Opening Balance (Empties containing Liquid)',SUM(post3) as ' Purchased Empties containing Liquid from Major Suppliers (INFLOW)',SUM(post4) as 'Empties Outside Returned to Major Suppliers (OUTFLOW)',SUM(post5) as 'Empties Brought by Customers (INFLOW)',SUM(post6) as 'Empties containing Liquid  equivalent to Empties Brought by Customers (OUTFLOW)',SUM(post7) as 'Empties containing Liquid purchased by Customers (OUTFLOW)',SUM(post8) as 'Empties purchased from Outside/Empties containing Liquid earlier sold to Customers Returned to us (INFLOW)',post9 as 'Balance (Empties Outside)',post10 as 'Balance (Empties containing Liquid)',total_empties as 'Total Empties',category as 'Product Category' FROM post_empty_stock WHERE pdate BETWEEN '", this.dateTimePicker1.Value.ToString("yyyy/MM/dd"), "' AND '", this.dateTimePicker2.Value.ToString("yyyy/MM/dd"), "' GROUP BY CATEGORY " };
                string cmdText = string.Concat(strArray);
                string query = string.Concat(strArray);
                decimal num = 0M;
                decimal num2 = 0M;
                this.gclass.DGVTable2(query, this.dataGridView2);
                int num3 = 0;
                while (true)
                {
                    bool flag = num3 < this.dataGridView2.Rows.Count;
                    if (!flag)
                    {
                        MySqlDataReader reader = new MySqlCommand(cmdText, this.gclass.conn()).ExecuteReader();
                        this.dataGridView1.Rows.Clear();
                        while (true)
                        {
                            flag = reader.Read();
                            if (!flag)
                            {
                                reader.Close();
                                this.dataGridView1.Rows.Add();
                                int num5 = this.dataGridView1.Rows.Count - 1;
                                int add1 = 0;
                                int add2 = 0;
                                int add3 = 0;
                                int add4 = 0;
                                int add5 = 0;
                                int add6 = 0;
                                int add7 = 0;
                                int add8 = 0;
                                int add9 = 0;
                                int add10 = 0;
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    add1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                                    add2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                                    add3 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                    add4 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                    add5 += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                                    add6 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                                    add7 += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                                    add8 += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                                    add9 += Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                                    add10 += Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                                   
                                }
                                dataGridView1.Rows[num5].Cells[1].Value = "TOTAL";
                                dataGridView1.Rows[num5].Cells[2].Value = add1.ToString();
                                dataGridView1.Rows[num5].Cells[3].Value = add2.ToString();
                                dataGridView1.Rows[num5].Cells[4].Value = add3.ToString();
                                dataGridView1.Rows[num5].Cells[5].Value = add4.ToString();
                                dataGridView1.Rows[num5].Cells[6].Value = add5.ToString();
                                dataGridView1.Rows[num5].Cells[7].Value = add6.ToString();
                                dataGridView1.Rows[num5].Cells[8].Value = add7.ToString();
                                dataGridView1.Rows[num5].Cells[9].Value = add8.ToString();
                                dataGridView1.Rows[num5].Cells[10].Value = add9.ToString();
                                dataGridView1.Rows[num5].Cells[11].Value = add10.ToString();

                                //this.dataGridView1.Rows.Add();
                                //int num56 = this.dataGridView1.Rows.Count - 1;
                                //dataGridView1.Rows[num56].Cells[1].Value = "TOTAL EMPTIES";
                                ////dataGridView1.Rows[num56].Cells[2].Value = Convert.ToDecimal(add1 + add2).ToString();
                                //dataGridView1.Rows[num56].Cells[11].Value = Convert.ToDecimal(add9 + add10).ToString();
                                break;
                            
                            }
                          
                            this.dataGridView1.Rows.Add();
                            int num4 = this.dataGridView1.Rows.Count - 1;
                            this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                            this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("Posting Date");
                            this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("Opening Balance(Empties Outside)");
                            this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("Opening Balance (Empties containing Liquid)");
                            this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("Purchased Empties containing Liquid from Major Suppliers (INFLOW)");
                            this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("Empties Outside Returned to Major Suppliers (OUTFLOW)");
                            this.dataGridView1.Rows[num4].Cells[6].Value = reader.GetString("Empties Brought by Customers (INFLOW)");
                            this.dataGridView1.Rows[num4].Cells[7].Value = reader.GetString("Empties containing Liquid  equivalent to Empties Brought by Customers (OUTFLOW)");
                            this.dataGridView1.Rows[num4].Cells[8].Value = reader.GetString("Empties containing Liquid purchased by Customers (OUTFLOW)");
                            this.dataGridView1.Rows[num4].Cells[9].Value = reader.GetString("Empties purchased from Outside/Empties containing Liquid earlier sold to Customers Returned to us (INFLOW)");
                            this.dataGridView1.Rows[num4].Cells[10].Value = reader.GetString("Balance (Empties Outside)");
                            this.dataGridView1.Rows[num4].Cells[11].Value = reader.GetString("Balance (Empties containing Liquid)");
                            this.dataGridView1.Rows[num4].Cells[12].Value = reader.GetString("Total Empties");
                            this.dataGridView1.Rows[num4].Cells[13].Value = reader.GetString("Product Category");
                            decimal num22 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[2].Value);
                            decimal num33 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[3].Value);
                            decimal num44 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                            decimal num55 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                            decimal num66 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                            decimal num77 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value);
                            decimal num88 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value);
                            decimal num99 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                            this.dataGridView1.Rows[num4].Cells[10].Value = num22 - num55 + num66 + num99;
                            this.dataGridView1.Rows[num4].Cells[11].Value = num33 + num44 - num77 - num88;
                            this.dataGridView1.Rows[num4].Cells[12].Value = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[10].Value) + Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[11].Value);
                        }
                        break;
                    }
                    num2 += Convert.ToDecimal(this.dataGridView2.Rows[num3].Cells[0].Value);
                    num3++;
                }
                decimal sumd = 0;
                decimal sumd1 = 0;
                decimal sumd2 = 0;
                decimal sumd3 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sumd += Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    sumd1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    sumd2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                    sumd3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                }
                decimal txt1 = 0;
                decimal txt2 = 0;
                decimal txt3 = 0;
                decimal txt4 = 0;
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    txt1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    txt2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    txt3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                    txt4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                }

                if (txt1 == 0)
                {

                }
                if (txt2 == 0)
                {

                }
                if (txt3 == 0)
                {

                }
                if (txt4 == 0)
                {

                }
                textBox1.Text = txt1.ToString();
                textBox2.Text = txt2.ToString();
                textBox3.Text = txt3.ToString();
                textBox4.Text = txt4.ToString();
                tot_open.Text = (txt1 + txt2).ToString();
                tot_close.Text = (txt3 + txt4).ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            date = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            base.Hide();
            new Post_Empties().ShowDialog();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int num444 = 0;
            if (num444 >= this.dataGridView1.Rows.Count)
            {

            }
            else
            { 
                decimal num22 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[2].Value);
                decimal num33 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[3].Value);
                decimal num44 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[4].Value);
                decimal num55 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[5].Value);
                decimal num66 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[6].Value);
                decimal num77 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[7].Value);
                decimal num88 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[8].Value);
                decimal num99 = Convert.ToDecimal(this.dataGridView1.Rows[num444].Cells[9].Value);
                this.dataGridView1.Rows[num444].Cells[10].Value = num22 - num55 + num66 + num99 - num88;
                this.dataGridView1.Rows[num444].Cells[11].Value = num33 + num44 - num77 - num88;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.LoadCombo(this.desc, "SELECT * FROM prod_category", "category");
                this.gclass.autocomplete("SELECT * FROM prod_category", 1, this.desc);
                this.desc.SelectedIndex = -1;
                this.dataGridView1.Columns[0].Width = 40;
                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[2].Width = 90;
                this.dataGridView1.Columns[3].Width = 90;
                this.dataGridView1.Columns[4].Width = 90;
                this.dataGridView1.Columns[5].Width = 90;
                this.dataGridView1.Columns[6].Width = 80;
                this.dataGridView1.Columns[7].Width = 90;
                this.dataGridView1.Columns[8].Width = 90;
                this.dataGridView1.Columns[9].Width = 120;
                this.dataGridView1.Columns[10].Width = 70;
                this.dataGridView1.Columns[11].Width = 100;
                this.dataGridView1.Columns[12].Width = 70;
                this.dataGridView1.Columns[13].Width = 100;
                string[] strArray = new string[] { "SELECT id as 'S/N',pdate as 'Posting Date',post1 as 'Opening Balance(Empties Outside)',post2 as 'Opening Balance (Empties containing Liquid)',SUM(post3) as ' Purchased Empties containing Liquid from Major Suppliers (INFLOW)',SUM(post4) as 'Empties Outside Returned to Major Suppliers (OUTFLOW)',SUM(post5) as 'Empties Brought by Customers (INFLOW)',SUM(post6) as 'Empties containing Liquid  equivalent to Empties Brought by Customers (OUTFLOW)',SUM(post7) as 'Empties containing Liquid purchased by Customers (OUTFLOW)',SUM(post8) as 'Empties purchased from Outside/Empties containing Liquid earlier sold to Customers Returned to us (INFLOW)',post9 as 'Balance (Empties Outside)',post10 as 'Balance (Empties containing Liquid)',total_empties as 'Total Empties',category as 'Product Category' FROM post_empty_stock WHERE pdate >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' AND  pdate <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' GROUP BY CATEGORY "};
                    string cmdText = string.Concat(strArray);
                    string query = string.Concat(strArray);
                    decimal num2 = 0M;
                    this.gclass.DGVTable2(query, this.dataGridView2);
                    int num3 = 0;
                    while (true)
                    {
                        bool flag = num3 < this.dataGridView2.Rows.Count;
                        if (!flag)
                        {
                            MySqlDataReader reader = new MySqlCommand(cmdText, this.gclass.conn()).ExecuteReader();
                            this.dataGridView1.Rows.Clear();
                            while (true)
                            {
                                flag = reader.Read();
                                if (!flag)
                                {
                                    reader.Close();
                                    this.dataGridView1.Rows.Add();
                                    int num5 = this.dataGridView1.Rows.Count - 1;
                                    int add1 = 0;
                                    int add2 = 0;
                                    int add3 = 0;
                                    int add4 = 0;
                                    int add5 = 0;
                                    int add6 = 0;
                                    int add7 = 0;
                                    int add8 = 0;
                                    int add9 = 0;
                                    int add10 = 0;
                                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                    {
                                        add1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                                        add2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                                        add3 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                        add4 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                                        add5 += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                                        add6 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                                        add7 += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                                        add8 += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                                        add9 += Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                                        add10 += Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);

                                    }
                                    dataGridView1.Rows[num5].Cells[1].Value = "TOTAL";
                                    dataGridView1.Rows[num5].Cells[2].Value = add1.ToString();
                                    dataGridView1.Rows[num5].Cells[3].Value = add2.ToString();
                                    dataGridView1.Rows[num5].Cells[4].Value = add3.ToString();
                                    dataGridView1.Rows[num5].Cells[5].Value = add4.ToString();
                                    dataGridView1.Rows[num5].Cells[6].Value = add5.ToString();
                                    dataGridView1.Rows[num5].Cells[7].Value = add6.ToString();
                                    dataGridView1.Rows[num5].Cells[8].Value = add7.ToString();
                                    dataGridView1.Rows[num5].Cells[9].Value = add8.ToString();
                                    dataGridView1.Rows[num5].Cells[10].Value = add9.ToString();
                                    dataGridView1.Rows[num5].Cells[11].Value = add10.ToString();

                                    this.dataGridView1.Rows.Add();
                                    int num56 = this.dataGridView1.Rows.Count - 1;
                                    dataGridView1.Rows[num56].Cells[1].Value = "TOTAL EMPTIES";
                                    //dataGridView1.Rows[num56].Cells[2].Value = Convert.ToDecimal(add1 + add2).ToString();
                                    dataGridView1.Rows[num56].Cells[11].Value = Convert.ToDecimal(add9 + add10).ToString();
                                    break;

                                }

                                this.dataGridView1.Rows.Add();
                                int num4 = this.dataGridView1.Rows.Count - 1;
                                this.dataGridView1.Rows[num4].Cells[0].Value = num4 + 1;
                                this.dataGridView1.Rows[num4].Cells[1].Value = reader.GetString("Posting Date");
                                this.dataGridView1.Rows[num4].Cells[2].Value = reader.GetString("Opening Balance(Empties Outside)");
                                this.dataGridView1.Rows[num4].Cells[3].Value = reader.GetString("Opening Balance (Empties containing Liquid)");
                                this.dataGridView1.Rows[num4].Cells[4].Value = reader.GetString("Purchased Empties containing Liquid from Major Suppliers (INFLOW)");
                                this.dataGridView1.Rows[num4].Cells[5].Value = reader.GetString("Empties Outside Returned to Major Suppliers (OUTFLOW)");
                                this.dataGridView1.Rows[num4].Cells[6].Value = reader.GetString("Empties Brought by Customers (INFLOW)");
                                this.dataGridView1.Rows[num4].Cells[7].Value = reader.GetString("Empties containing Liquid  equivalent to Empties Brought by Customers (OUTFLOW)");
                                this.dataGridView1.Rows[num4].Cells[8].Value = reader.GetString("Empties containing Liquid purchased by Customers (OUTFLOW)");
                                this.dataGridView1.Rows[num4].Cells[9].Value = reader.GetString("Empties purchased from Outside/Empties containing Liquid earlier sold to Customers Returned to us (INFLOW)");
                                this.dataGridView1.Rows[num4].Cells[10].Value = reader.GetString("Balance (Empties Outside)");
                                this.dataGridView1.Rows[num4].Cells[11].Value = reader.GetString("Balance (Empties containing Liquid)");
                                this.dataGridView1.Rows[num4].Cells[12].Value = reader.GetString("Total Empties");
                                this.dataGridView1.Rows[num4].Cells[13].Value = reader.GetString("Product Category");
                                decimal num22 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[2].Value);
                                decimal num33 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[3].Value);
                                decimal num44 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[4].Value);
                                decimal num55 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[5].Value);
                                decimal num66 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[6].Value);
                                decimal num77 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[7].Value);
                                decimal num88 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[8].Value);
                                decimal num99 = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[9].Value);
                                this.dataGridView1.Rows[num4].Cells[10].Value = num22 - num55 + num66 + num99;
                                this.dataGridView1.Rows[num4].Cells[11].Value = num33 + num44 - num77 - num88;
                                this.dataGridView1.Rows[num4].Cells[12].Value = Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[10].Value) + Convert.ToDecimal(this.dataGridView1.Rows[num4].Cells[11].Value);
                        }
                            break;
                        }
                        num2 += Convert.ToDecimal(this.dataGridView2.Rows[num3].Cells[0].Value);
                        num3++;
                    }
                
                
                decimal sumd = 0;
                decimal sumd1 = 0;
                decimal sumd2 = 0;
                decimal sumd3 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sumd += Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    sumd1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    sumd2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                    sumd3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                }
                decimal txt1 = 0;
                decimal txt2 = 0;
                decimal txt3 = 0;
                decimal txt4 = 0;
                for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                    txt1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                    txt2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    txt3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                    txt4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                }

                if (txt1 == 0)
                {

                }
                if (txt2 == 0)
                {

                }
                if (txt3 == 0)
                {

                }
                if (txt4 == 0)
                {

                }
                textBox1.Text = txt1.ToString();
                textBox2.Text = txt2.ToString();
                textBox3.Text = txt3.ToString();
                textBox4.Text = txt4.ToString();
                tot_open.Text = (txt1 + txt2).ToString();
                tot_close.Text = (txt3 + txt4).ToString();
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.ForeColor = Color.Maroon;
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                this.dataGridView1.DefaultCellStyle.Font = new Font("verdana", 10f);
                this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
                IEnumerator enumerator = ((IEnumerable)this.dataGridView1.Rows).GetEnumerator();
                try
                {
                    while (true)
                    {
                        if (!enumerator.MoveNext())
                        {
                            break;
                        }
                        DataGridViewRow current = (DataGridViewRow)enumerator.Current;
                        current.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                finally
                {
                    IDisposable objA = enumerator as IDisposable;
                    if (!ReferenceEquals(objA, null))
                    {
                        objA.Dispose();
                    }
                }
                DGVPrinter printer = new DGVPrinter
                {
                    TitleColor = Color.Maroon,
                    SubTitleColor = Color.Maroon,
                    Title = Program.companyName + "\n"
                };
                printer.TitleFont = new Font("verdana", 16f, FontStyle.Bold);
                printer.Title = printer.Title + Program.companyAddressA4;
                printer.Title = printer.Title + "\n" + Program.companyPhone + "\n Empties Stock Inflow/Outflow Analysis Report";
                printer.SubTitle = "\nFrom :   " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "\t   To :   " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
                printer.SubTitle += "\n\n";
                printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
                printer.PageNumbers = true;
                printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
                printer.PrintMargins.Left = 15;
                printer.PrintMargins.Right = 15;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.SubTitleAlignment = StringAlignment.Near;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = DateTime.Now.ToString("yyyy/MM/dd") + "          " + $"{DateTime.Now:T}";
                printer.FooterSpacing = 15f;
                printer.PageSettings.Landscape = true;
                printer.PrintPreviewDataGridView(this.dataGridView1);
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
    }

