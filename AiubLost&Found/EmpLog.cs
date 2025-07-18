using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiubLost_Found
{
    public partial class EmpLog : Form
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public static string CurrentUserRole { get; set; }
        public EmpLog()
        {
            InitializeComponent();
        }
        private void eyebtn_Click(object sender, EventArgs e)
        {
            if (passbox.PasswordChar == '*')
            {
                passbox.PasswordChar = '\0';
                eyeslashbtn.BringToFront();
            }


        }

        private void eyeslashbtn_Click(object sender, EventArgs e)
        {
            if (passbox.PasswordChar == '\0')
            {
                passbox.PasswordChar = '*';
                eyebtn.BringToFront();
            }
        }

        bool Authenticate()
        {

            if (string.IsNullOrWhiteSpace(eidbox.Text) ||
                string.IsNullOrWhiteSpace(passbox.Text)
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void logbtn_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Please enter both Employee ID and Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT COUNT(1) FROM Employee WHERE Id = @Id AND Password = @Password";

            try
            {
                con.Open(); // Open database connection
                scmd = new SqlCommand(query, con);

                // Add parameters to avoid SQL injection
                scmd.Parameters.AddWithValue("@Id", eidbox.Text.Trim());
                scmd.Parameters.AddWithValue("@Password", passbox.Text.Trim());

                // Execute query
                int count = Convert.ToInt32(scmd.ExecuteScalar());

                if (count == 1)
                {
                   
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmpLog.CurrentUserRole = "Employee";

                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Employee ID or Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); // Close database connection
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start f1 = new Start();
            f1.ShowDialog();
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

        private void signbtn_Click(object sender, EventArgs e)
        {

            this.Hide();
            EmpReg empReg = new EmpReg();
            empReg.ShowDialog();
            this.Show();
        }
        public void ClearInputs()
        {
            eidbox.Clear();
            passbox.Clear();
        }

    }
}