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
    public partial class Allitems : UserControl
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        
        public Allitems()
        {
            InitializeComponent();
            LoadData();
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
                alldataGridView.DataSource = dt;

                // Ensure the DataGridView refreshes
                alldataGridView.Refresh();
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
    }
}
