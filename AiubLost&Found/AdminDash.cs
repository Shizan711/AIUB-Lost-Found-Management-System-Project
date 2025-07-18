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
    public partial class AdminDash : Form
    {
        private welcomeAdminDash welcomeAdminDash= new welcomeAdminDash();
        private student student= new student();
        private faculty faculty = new faculty();
        private employee employee = new employee();
        private adminItems adminItems = new adminItems();
        public AdminDash()
        {
            InitializeComponent();
            InitializeUserControls();
        }
        private void InitializeUserControls()
        {
            // Set docking and add the controls to the Dashboard
            welcomeAdminDash.Dock = DockStyle.Fill;
            student.Dock = DockStyle.Fill;
            faculty.Dock = DockStyle.Fill;
            employee.Dock = DockStyle.Fill;
            adminItems.Dock = DockStyle.Fill;

            // Add UserControls to the form's Controls collection
            this.Controls.Add(welcomeAdminDash);
            this.Controls.Add(student);
            this.Controls.Add(faculty);
            this.Controls.Add(employee);
            this.Controls.Add(adminItems);


            // Initially hide all UserControls Except Welcome
            welcomeAdminDash.Show();
            student.Hide();
            faculty.Hide();
            employee.Hide();
            adminItems.Hide();

        }
        private void ExitpicBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to Exit?", "Exit",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out?", "Logout",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                AdminLog adLog = new AdminLog();
                adLog.ClearInputs();
                adLog.ShowDialog();
                this.Show();

            }

        }

        private void stubtn_Click(object sender, EventArgs e)
        {
            // Show Student UserControl
            student.Show();
            welcomeAdminDash.Hide();
            faculty.Hide();
            employee.Hide();
            adminItems.Hide();

            student.BringToFront();
        }

        private void facbtn_Click(object sender, EventArgs e)
        {
            // Show Faculty UserControl
            faculty.Show();
            welcomeAdminDash.Hide();
            student.Hide();
            employee.Hide();
            adminItems.Hide();

            faculty.BringToFront();
        }

        private void empbtn_Click(object sender, EventArgs e)
        {
            // Show Employee UserControl
            employee.Show();
            welcomeAdminDash.Hide();
            student.Hide();
            faculty.Hide();
            adminItems.Hide();

            employee.BringToFront();

           
        }

        private void itemsbtn_Click(object sender, EventArgs e)
        {
            // Show AdminItems UserControl
            adminItems.Show();
            welcomeAdminDash.Hide();
            student.Hide();
            employee.Hide();
            faculty.Hide();

            adminItems.BringToFront();
        }

        private void AdminDash_Load(object sender, EventArgs e)
        {
            // Initially hide all UserControls Except Welcome
            welcomeAdminDash.Show();
            student.Hide();
            faculty.Hide();
            employee.Hide();
            adminItems.Hide();
        }
        private void AdminDashLabel_Click(object sender, EventArgs e)
        {
            // Initially hide all UserControls Except Welcome
            welcomeAdminDash.Show();
            student.Hide();
            faculty.Hide();
            employee.Hide();
            adminItems.Hide();
        }
    }
}
