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
    public partial class Dashboard : Form
    {
        private WelcomeDash welcomeDash= new WelcomeDash();
        private Report report = new Report();
        private Allitems allitems = new Allitems();
        private Search search = new Search();

        public Dashboard()
        {
            InitializeComponent();
            InitializeUserControls();
        }

        // Method to initialize and add UserControls to the form
        private void InitializeUserControls()
        {
            // Set docking and add the controls to the Dashboard
            welcomeDash.Dock = DockStyle.Fill;
            report.Dock = DockStyle.Fill;
            allitems.Dock = DockStyle.Fill;
            search.Dock = DockStyle.Fill;


            // Add UserControls to the form's Controls collection
            this.Controls.Add(welcomeDash);
            this.Controls.Add(report);
            this.Controls.Add(allitems);
            this.Controls.Add(search);
           

            // Initially hide all UserControls
            welcomeDash.Show();
            report.Hide();
            allitems.Hide();
            search.Hide();
            
        }

        private void exitpicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string GetUserRole()
        {
            if (StuLog.CurrentUserRole != null)
            {
                return StuLog.CurrentUserRole;
            }
            else if (TeaLog.CurrentUserRole != null)
            {
                return TeaLog.CurrentUserRole;
            }
            else if (EmpLog.CurrentUserRole != null)
            {
                return EmpLog.CurrentUserRole;
            }
            else
            {
                return null; // Default case
            }
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string currentUserRole = GetUserRole();

                // Clear user role
                StuLog.CurrentUserRole = null;
                TeaLog.CurrentUserRole = null;
                EmpLog.CurrentUserRole = null;

                MessageBox.Show("Logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                // Redirect to the respective login form based on the stored role
                if (currentUserRole == "Student")
                {
                    StuLog stuLog = new StuLog();
                    stuLog.ClearInputs();
                    stuLog.ShowDialog();
                }
                else if (currentUserRole == "Faculty")
                {
                    TeaLog teaLog = new TeaLog();
                    teaLog.ClearInputs();
                    teaLog.ShowDialog();
                }
                else if (currentUserRole == "Employee")
                {
                    EmpLog empLog = new EmpLog();
                    empLog.ClearInputs();
                    empLog.ShowDialog();
                }

                this.Close();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            // Show Report UserControl
            report.Show();
            welcomeDash.Hide();
            allitems.Hide();
            search.Hide();
            report.BringToFront();
        }

        private void itemsbtn_Click(object sender, EventArgs e)
        {
            // Show All Items UserControl
            allitems.Show();
            welcomeDash.Hide();
            report.Hide();
            search.Hide();
            allitems.BringToFront();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            // Show Search UserControl
            search.Show();
            welcomeDash.Hide();
            report.Hide();
            allitems.Hide();
            search.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Initially hide all UserControls except welcome
            welcomeDash.Show();
            report.Hide();
            allitems.Hide();
            search.Hide();
        }

        private void DashboardLabel_Click(object sender, EventArgs e)
        {
            // Initially hide all UserControls except welcome
            welcomeDash.Show();
            report.Hide();
            allitems.Hide();
            search.Hide();
            welcomeDash.BringToFront();
        }
    }
}
