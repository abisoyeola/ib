namespace POS_SALES
{
    using MySql.Data.MySqlClient;
    using System;
    using System.IO;
    using System.Windows.Forms;

    internal static class Program
    {
        public static string user = "";
        public static string IVPG = "IVPG";
        public static string purpose = "SALES";
        public static string RETURN = "RETURN";
        public static string purchase = "PURCHASE";
        public static string CREDITSALES = "CREDIT SALES";
        public static string Zero = "0";
        public static string PAYMENT = "PAYMENT";
        public static string DEBIT = "DEBIT";
        public static string status = "";
        public static string user_id = "";
        public static string msg1 = "";
        public static string msg2 = "";
        public static string mess1 = "";
        public static string mess2 = "";
        public static string mess3 = "";
         public static string vendor_status = "ACTIVE";
        public static string companyNameRcpt1 = "REYFIT LIMITED";
        public static string companyNameRcpt2 = " ";
        public static string companyName = "REYFIT LIMITED";
        public static string companyAddressA4 = "Plot 5A/5B, Olabande Abogun Area, Ayegun-Oleyo Road, Odo Ona Elewe, Ibadan.";
        public static string companyAddressPos = "Plot 5A/5B, Olabande Abogun Area,\nAyegun-Oleyo Road, Odo Ona Elewe,\n\t\tIbadan.";
        public static string companyEmail = "";
        public static string companyPhone = "08166445349, 08122832257";
        public static string companylogo = "";
        public static string formname = "";

        [STAThread]
        private static void Main()
        {
            General general = new General();
            if (!Directory.Exists(@"C:\REYFIT DB"))
            {
                string filePath = Application.StartupPath + "/backup.sql";
                try
                {
                    MySqlConnection connection = new MySqlConnection("server=localhost;user=root;pwd=;");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlBackup backup = new MySqlBackup(cmd);
                    cmd.Connection = connection;
                    backup.ImportFromFile(filePath);
                    Directory.CreateDirectory(@"C:\REYFIT DB");
                    MessageBox.Show("Database Successfully Created! ", " Message Center ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new User_Login());
        }
    }
}

