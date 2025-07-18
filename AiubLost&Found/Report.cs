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
    public partial class Report : UserControl
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public Report()
        {
            InitializeComponent();
            LoadData();
        }

        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(itembox.Text) ||
                string.IsNullOrWhiteSpace(CategorycomboBox.Text) ||
                string.IsNullOrWhiteSpace(LfcomboBox.Text) ||
                string.IsNullOrWhiteSpace(LocBox.Text) ||
                string.IsNullOrWhiteSpace(LFdateTimePicker.Text) ||
                string.IsNullOrWhiteSpace(descBox.Text) ||
                string.IsNullOrWhiteSpace(namebox.Text) ||
                string.IsNullOrWhiteSpace(contactbox.Text) 
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void regbtn_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("All informations must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Item VALUES(@ItemName,@Category,@Status,@Location,@Date,@Description,@ReportedBy,@Contact)";

            try
            {
                con.Open();
                scmd = new SqlCommand(query, con);

                // Adding parameters
                scmd.Parameters.AddWithValue("@ItemName", itembox.Text.Trim());
                scmd.Parameters.AddWithValue("@Category", CategorycomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Status", LfcomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Location", LocBox.Text.Trim());
                scmd.Parameters.AddWithValue("@Date", LFdateTimePicker.Value);
                scmd.Parameters.AddWithValue("@Description", descBox.Text.Trim());
                scmd.Parameters.AddWithValue("@ReportedBy", namebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Contact", contactbox.Text.Trim());

                int rowsAffected = scmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show(" Items Registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh DataGridView after successful registration
                    resetbtn.PerformClick();
                }
                else
                {
                    MessageBox.Show("Registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        // Load data into the DataGridView
        private void LoadData()
        {
            try
            {
                // Check if the connection is already open, and if so, close it
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                // Open the database connection
                con.Open();

                // Query to retrieve all records from the Item table
                string query = "SELECT * FROM Item";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dt);

                // Bind the DataTable to the DataGridView
                LFitemdataGridView.DataSource = dt;

                // Ensure the DataGridView refreshes
                LFitemdataGridView.Refresh();
            }
            catch (Exception ex)
            {
                // Show an error message if loading data fails
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            itembox.Clear();
            LocBox.Clear();
            descBox.Clear();
            namebox.Clear();
            contactbox.Clear();

            // Reset ComboBoxes
            CategorycomboBox.SelectedIndex = -1;
            LfcomboBox.SelectedIndex = -1;

            // Reset DateTimePicker to today's date
            LFdateTimePicker.Value = DateTime.Now;

            // Optionally set focus to the first input field
            itembox.Focus();

            // Clear DataGridView selection
            if (LFitemdataGridView.DataSource != null)
            {
                LFitemdataGridView.ClearSelection();
            }
        }
    }
}
