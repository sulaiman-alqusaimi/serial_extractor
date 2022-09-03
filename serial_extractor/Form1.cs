using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace serial_extractor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                ProcessStartInfo info = new ProcessStartInfo();

                info.FileName = "wmic";
                info.Arguments = "bios get serialnumber";
                info.UseShellExecute = false;
                info.RedirectStandardOutput = true;
                info.CreateNoWindow = true;
                p.StartInfo = info;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                txtSerial.Text = output.Split('\n')[1];
            }
            catch (Exception exc)
            {

                MessageBox.Show("حدث خطأ غير معروف أثناء محاولة استخراج الرقم التسلسلي لجهازك", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSerial.Text);
            MessageBox.Show("تم النسخ بنجاح", "نجاح");
            txtSerial.Focus();
        }
    }
}
