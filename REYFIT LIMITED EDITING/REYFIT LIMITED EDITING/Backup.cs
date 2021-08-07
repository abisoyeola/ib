using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace POS_SALES
{
    public partial class Backup : Form
    {
        public static string identify = "0";
        private General gclass = new General();
        private DriveInfo[] allDrives = DriveInfo.GetDrives();
        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(this.gclass.access(identify)) != 1)
                {
                    this.gclass.error("Access Denied...");
                    base.Close();
                }
                DriveInfo[] allDrives = this.allDrives;
                int index = 0;
                while (true)
                {
                    if (index >= allDrives.Length)
                    {
                        this.desc.SelectedIndex = -1;
                        break;
                    }
                    DriveInfo info = allDrives[index];
                    this.desc.Items.Add(info.Name.ToString());
                    index++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.gclass.backup(this.desc.Text);
                this.gclass.success("Backup Finished Successfully...");
                this.desc.SelectedIndex = -1;
                this.dname.Text = null;
                this.dtype.Text = null;
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }

        private void desc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DriveInfo[] allDrives = this.allDrives;
                int index = 0;
                while (true)
                {
                    if (index >= allDrives.Length)
                    {
                        break;
                    }
                    DriveInfo info = allDrives[index];
                    if ((info.Name == this.desc.Text) && info.IsReady)
                    {
                        this.dname.Text = info.VolumeLabel;
                        this.dtype.Text = info.DriveType.ToString();
                    }
                    index++;
                }
            }
            catch (Exception exception)
            {
                this.gclass.error(exception.Message.ToString());
            }
        }
    }
}
