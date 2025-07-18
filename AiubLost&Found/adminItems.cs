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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AiubLost_Found
{
    public partial class adminItems : UserControl
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public adminItems()
        {
            InitializeComponent();
            ItemLoadData();
        }
        private void ItemLoadData()
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
        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(itemnamebox.Text) ||
                string.IsNullOrWhiteSpace(CategorycomboBox.Text) ||
                string.IsNullOrWhiteSpace(StatuscomboBox.Text) ||
                string.IsNullOrWhiteSpace(LocBox.Text) ||
                string.IsNullOrWhiteSpace(LFdateTimePicker.Text)||
                string.IsNullOrWhiteSpace(DescBox.Text) ||
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
        private void ADDbutton_Click(object sender, EventArgs e)
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
                scmd.Parameters.AddWithValue("@ItemName", itemnamebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Category", CategorycomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Status", StatuscomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Location", LocBox.Text.Trim());
                scmd.Parameters.AddWithValue("@Date", LFdateTimePicker.Value);
                scmd.Parameters.AddWithValue("@Description", DescBox.Text.Trim());
                scmd.Parameters.AddWithValue("@ReportedBy", namebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Contact", contactbox.Text.Trim());


                int rowsAffected = scmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show(" Item Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ItemLoadData(); // Refresh DataGridView after success
                    resetbtn.PerformClick();
                }
                else
                {
                    MessageBox.Show("Failed to Add Item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void UPDATEbutton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (LFitemdataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate input fields
            if (!Authenticate())
            {
                MessageBox.Show("All fields must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve values from the selected row
            string originalItemName = LFitemdataGridView.SelectedRows[0].Cells["ItemName"].Value.ToString();
            DateTime originalDate = Convert.ToDateTime(LFitemdataGridView.SelectedRows[0].Cells["Date"].Value);

            // Update query with WHERE clause to match the original record
            string query = "UPDATE Item SET ItemName = @NewItemName,Category = @Category,Status = @Status, Location = @Location,Date = @NewDate,Description = @Description, ReportedBy = @ReportedBy, Contact = @Contact WHERE ItemName = @OriginalItemName AND Date = @OriginalDate";

            try
            {
                con.Open();
                scmd = new SqlCommand(query, con);

                // Adding parameters for the updated values
                scmd.Parameters.AddWithValue("@NewItemName", itemnamebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Category", CategorycomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Status", StatuscomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Location", LocBox.Text.Trim());
                scmd.Parameters.AddWithValue("@NewDate", LFdateTimePicker.Value);
                scmd.Parameters.AddWithValue("@Description", DescBox.Text.Trim());
                scmd.Parameters.AddWithValue("@ReportedBy", namebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Contact", contactbox.Text.Trim());

                // Adding parameters to identify the original record
                scmd.Parameters.AddWithValue("@OriginalItemName", originalItemName);
                scmd.Parameters.AddWithValue("@OriginalDate", originalDate);

                int rowsAffected = scmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ItemLoadData(); // Refresh DataGridView after successful update
                    resetbtn.PerformClick(); // Clear input fields
                }
                else
                {
                    MessageBox.Show("Failed to update the item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); // Ensure the connection is closed
            }
        }

       


        private void SEARCHbutton_Click(object sender, EventArgs e)
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
                    scmd.Parameters.AddWithValue("@ItemName", "%" + itemnamebox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Category", "%" + CategorycomboBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Status", "%" + StatuscomboBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Location", "%" + LocBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Description", "%" + DescBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@ReportedBy", "%" + namebox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Contact", "%" + contactbox.Text.Trim() + "%");

                    con.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind search results to DataGridView
                        LFitemdataGridView.DataSource = dt;

                        // Display a message based on the number of matching items found
                        int matchCount = dt.Rows.Count;
                        if (matchCount > 0)
                        {
                            MessageBox.Show($"{matchCount} matching item(s) found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ItemLoadData();
                            resetbtn.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("No matching items found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ItemLoadData();
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
    

        private void DELETEbutton_Click(object sender, EventArgs e)
        {

                // Check if a row is selected in the DataGridView
                if (LFitemdataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected Item ID or other unique identifier from the DataGridView
                string itemName = LFitemdataGridView.SelectedRows[0].Cells["ItemName"].Value.ToString();
                DateTime itemDate = Convert.ToDateTime(LFitemdataGridView.SelectedRows[0].Cells["Date"].Value);

                // Confirmation prompt
                DialogResult confirmResult = MessageBox.Show($"Are you sure you want to delete the item '{itemName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM Item WHERE ItemName = @ItemName AND Date = @Date";

                    try
                    {
                        con.Open();
                        using (SqlCommand scmd = new SqlCommand(query, con))
                        {
                            // Add parameters for the DELETE query
                            scmd.Parameters.AddWithValue("@ItemName", itemName);
                            scmd.Parameters.AddWithValue("@Date", itemDate);

                            int rowsAffected = scmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ItemLoadData(); // Refresh DataGridView after deletion
                                resetbtn.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete the item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close(); // Ensure the connection is closed
                        }
                    }
                }
            }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            itemnamebox.Clear();
            CategorycomboBox.SelectedIndex = -1; // Deselect any selected item in ComboBox
            StatuscomboBox.SelectedIndex = -1;  // Deselect any selected item in ComboBox
            LocBox.Clear();
            LFdateTimePicker.Value = DateTime.Now; // Reset to the current date and time
            DescBox.Clear();
            namebox.Clear();
            contactbox.Clear();

            // Optionally set focus to the first input field
            itemnamebox.Focus();

            // Clear DataGridView selection
            if (LFitemdataGridView.DataSource != null)
            {
                LFitemdataGridView.ClearSelection();
            }
        }


        private void LFitemdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row is selected
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = LFitemdataGridView.Rows[e.RowIndex];

                // Populate the textboxes and other fields with the selected row's data
                itemnamebox.Text = selectedRow.Cells["ItemName"].Value?.ToString();
                CategorycomboBox.SelectedItem = selectedRow.Cells["Category"].Value?.ToString();
                StatuscomboBox.SelectedItem = selectedRow.Cells["Status"].Value?.ToString();
                LocBox.Text = selectedRow.Cells["Location"].Value?.ToString();
                LFdateTimePicker.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value ?? DateTime.Now);
                DescBox.Text = selectedRow.Cells["Description"].Value?.ToString();
                namebox.Text = selectedRow.Cells["ReportedBy"].Value?.ToString();
                contactbox.Text = selectedRow.Cells["Contact"].Value?.ToString();
            }
        }
    }
} 

