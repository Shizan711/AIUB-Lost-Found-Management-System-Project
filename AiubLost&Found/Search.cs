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
    public partial class Search : UserControl
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public Search()
        {
            InitializeComponent();
            LoadData();
        }
       

        // Load data into the DataGridView
        private void LoadData()
        {
            try
            {
                // Query to retrieve all records from the Item table
                string query = "SELECT * FROM Item";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    searchitemdataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Show an error message if loading data fails
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void searchbtn2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM Item WHERE 
                            (@ItemName = '' OR ItemName LIKE @ItemName) AND
                            (@Category = '' OR Category LIKE @Category) AND
                            (@Status = '' OR Status LIKE @Status) AND
                            (@Location = '' OR Location LIKE @Location) AND
                            (@Description = '' OR Description LIKE @Description) AND
                            (@ReportedBy = '' OR ReportedBy LIKE @ReportedBy) AND
                            (@Contact = '' OR Contact LIKE @Contact)";

            try
            {
                using (SqlCommand scmd = new SqlCommand(query, con))
                {
                    // Add parameters for search fields
                    scmd.Parameters.AddWithValue("@ItemName", "%" + itembox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Category", "%" + CategorycomboBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Status", "%" + LfcomboBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Location", "%" + LocBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Description", "%" + descBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@ReportedBy", "%" + namebox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Contact", "%" + contactbox.Text.Trim() + "%");

                    con.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind search results to DataGridView
                        searchitemdataGridView.DataSource = dt;

                        // Display a message based on the number of matching items found
                        int matchCount = dt.Rows.Count;
                        if (matchCount > 0)
                        {
                            MessageBox.Show($"{matchCount} matching item(s) found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            resetbtn.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("No matching items found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
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
            if (searchitemdataGridView.DataSource != null)
            {
                searchitemdataGridView.ClearSelection();
            }
        }
    }
}
