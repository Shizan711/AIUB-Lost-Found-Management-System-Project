using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiubLost_Found
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void stubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StuReg stuReg = new StuReg();
            stuReg.ShowDialog();
            this.Show();
        }

        private void fbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeaReg teaReg = new TeaReg();
            teaReg.ShowDialog();
            this.Show();
        }

        private void empbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpReg empReg = new EmpReg();
            empReg.ShowDialog();
            this.Show();
        }

        private void stubtn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StuLog stuLog = new StuLog();
            stuLog.ShowDialog();
            this.Show();
        }

        private void fbtn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeaLog teaLog = new TeaLog();
            teaLog.ShowDialog();
            this.Show();
        }

        private void empbtn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpLog empLog = new EmpLog();
            empLog.ShowDialog();
            this.Show();
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLog adLog = new AdminLog();
            adLog.ShowDialog();
            this.Show();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit",
              MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void exitpicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
    }
}
