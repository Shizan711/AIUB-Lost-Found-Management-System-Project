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
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;

                label6.Text=progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();

                this.Hide();
                Start f1 = new Start();
                f1.ShowDialog();
                this.Show();
            }
        }

        private void exitpicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
