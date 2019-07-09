using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Act8_2
{
    public partial class frmLogger : Form
    {
        private delegate string AsyncReadLog(string filePath);
        private AsyncReadLog LogReader = new AsyncReadLog(Logger.LogRead);

        public void LogReadCallBack(IAsyncResult asyncResult)
        {
            MessageBox.Show(LogReader.EndInvoke(asyncResult));
        }


        public frmLogger()
        {
            InitializeComponent();
        }

        private void btnLogInfo_Click(object sender, EventArgs e)
        {
            this.Text = Logger.LogWrite(txtLogPath.Text, txtLogInfo.Text);
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void btnSyncRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Logger.LogRead(txtLogPath.Text));
        }

        private void btnAsyncRead_Click(object sender, EventArgs e)
        {
            AsyncCallback aCallBack = new AsyncCallback(LogReadCallBack);
            IAsyncResult aResult = LogReader.BeginInvoke(txtLogPath.Text, aCallBack, null);
        }
    }
}
