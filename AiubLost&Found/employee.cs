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
    public partial class employee : UserControl
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public employee()
        {
            InitializeComponent();
            EmployeeLoadData();

        }
        private void EmployeeLoadData()
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

                // Query to retrieve all records from the EMPLOYEE table
                string query = "SELECT * FROM Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dt);

                // Bind the DataTable to the DataGridView
                EmpdataGridView.DataSource = dt;

                // Ensure the DataGridView refreshes
                EmpdataGridView.Refresh();
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
            if (string.IsNullOrWhiteSpace(empnamebox.Text) ||
                string.IsNullOrWhiteSpace(idbox.Text) ||
                string.IsNullOrWhiteSpace(phonenobox.Text) ||
                string.IsNullOrWhiteSpace(workcomboBox.Text) ||
                string.IsNullOrWhiteSpace(setPassbox.Text)

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
            // Check if the employee ID already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Employee WHERE Id = @Id";
            bool idExists = false;

            try
            {
                con.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@Id", idbox.Text.Trim());
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        idExists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking ID existence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                con.Close();
            }

            // If the ID already exists, show a message and exit
            if (idExists)
            {
                MessageBox.Show("Employee with this ID already exists!", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO Employee VALUES(@Name,@Id,@Phone,@WorkingAs,@Password)";

            try
            {
                con.Open();
                scmd = new SqlCommand(query, con);

                // Adding parameters
                scmd.Parameters.AddWithValue("@Name", empnamebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Id", idbox.Text.Trim());
                scmd.Parameters.AddWithValue("@Phone", phonenobox.Text.Trim());
                scmd.Parameters.AddWithValue("@WorkingAs", workcomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Password", setPassbox.Text.Trim());

                int rowsAffected = scmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show(" Employee Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeLoadData(); // Refresh DataGridView after success
                    resetbtn.PerformClick();
                }
                else
                {
                    MessageBox.Show("Failed to Add Employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (EmpdataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select an Employee to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Authenticate())
            {
                MessageBox.Show("All informations must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve values from the selected row
            string originalName = EmpdataGridView.SelectedRows[0].Cells["Name"].Value.ToString();

            string query = "UPDATE Employee SET Name = @NewName, Id = @Id , Phone= @Phone, WorkingAs = @WorkingAs, Password = @Password WHERE Name =@OriginalName ";

           

            try
            {
                con.Open();
                scmd = new SqlCommand(query, con);

                // Adding parameters
                scmd.Parameters.AddWithValue("@NewName", empnamebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Id", idbox.Text.Trim());
                scmd.Parameters.AddWithValue("@Phone", phonenobox.Text.Trim());
                scmd.Parameters.AddWithValue("@WorkingAs", workcomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Password", setPassbox.Text.Trim());

                // Adding parameters to identify the original record
                scmd.Parameters.AddWithValue("@OriginalName", originalName);


                int rowsAffected = scmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show(" Employee Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeLoadData(); // Refresh DataGridView after success
                    resetbtn.PerformClick();
                }
                else
                {
                    MessageBox.Show("Failed to Update Employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void SEARCHbutton_Click(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM Employee WHERE 
                            (@Name = '' OR Name LIKE @Name) AND
                            (@Id = '' OR Id LIKE @Id) AND
                            (@Phone = '' OR Phone LIKE @Phone) AND
                            (@WorkingAs = '' OR WorkingAs LIKE @WorkingAs) AND
                            (@Password = '' OR Password LIKE @Password)";

            try
            {
                using (SqlCommand scmd = new SqlCommand(query, con))
                {
                    // Add parameters for search fields
                    scmd.Parameters.AddWithValue("@Name", "%" + empnamebox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Id", "%" + idbox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Phone", "%" + phonenobox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@WorkingAs", "%" + workcomboBox.Text.Trim() + "%");
                    scmd.Parameters.AddWithValue("@Password", "%" + setPassbox.Text.Trim() + "%");


                    con.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind search results to DataGridView
                        EmpdataGridView.DataSource = dt;

                        // Display a message based on the number of matching items found
                        int matchCount = dt.Rows.Count;
                        if (matchCount > 0)
                        {
                            MessageBox.Show($"{matchCount} Employee(s) found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmployeeLoadData(); // Refresh DataGridView after success
                            resetbtn.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("No Employee found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmployeeLoadData(); // Refresh DataGridView after success
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
            if (EmpdataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Employee to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected Employee ID from the DataGridView
            string EmployeeId = EmpdataGridView.SelectedRows[0].Cells["Id"].Value.ToString();

            // Confirmation prompt
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this Employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM Employee WHERE Id = @Id";

                try
                {
                    con.Open();
                    using (SqlCommand scmd = new SqlCommand(query, con))
                    {
                        scmd.Parameters.AddWithValue("@Id", EmployeeId);

                        int rowsAffected = scmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EmployeeLoadData(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete Employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        con.Close();
                    }
                }
            }

        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            empnamebox.Clear();
            idbox.Clear();
            phonenobox.Clear();
            setPassbox.Clear();

            // Reset ComboBoxes
            workcomboBox.SelectedIndex = -1;


            // Optionally set focus to the first input field
            empnamebox.Focus();
            
            // Clear DataGridView selection
            if (EmpdataGridView.DataSource != null)
            {
                EmpdataGridView.ClearSelection();
            }
        }

        private void EmpdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = EmpdataGridView.Rows[e.RowIndex];

                // Populate the form fields with the selected row's data
                empnamebox.Text = row.Cells["Name"].Value.ToString();
                idbox.Text = row.Cells["Id"].Value.ToString();
                phonenobox.Text = row.Cells["Phone"].Value.ToString();
                workcomboBox.SelectedItem = row.Cells["WorkingAs"].Value.ToString();
                setPassbox.Text = row.Cells["Password"].Value.ToString();


            }
        }
    }
}
