﻿using System;
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
    public partial class TeaReg : Form
    {
        static SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=AiubLost&Found;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public TeaReg()
        {
            InitializeComponent();
        }

        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(namebox.Text) ||
                string.IsNullOrWhiteSpace(fidbox.Text) ||
                string.IsNullOrWhiteSpace(fmailbox.Text) ||
                string.IsNullOrWhiteSpace(fdeptcomboBox.Text) ||
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
        private void signbtn_Click(object sender, EventArgs e)
        {

            if (!Authenticate())
            {
                MessageBox.Show("Please provide all informations!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TermscheckBox.Checked)
            {
                MessageBox.Show("You must accept the Terms and Conditions to proceed.", "Terms and Conditions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if the ID already exists
            string checkQuery = "SELECT COUNT(*) FROM Faculty WHERE Id = @Id";

            string query = "INSERT INTO Faculty VALUES(@Name,@Id,@Mail,@Department,@Password)";

            try
            {
                con.Open();

                // Check for duplicate ID
                scmd = new SqlCommand(checkQuery, con);
                scmd.Parameters.AddWithValue("@Id", fidbox.Text.Trim());
                int count = (int)scmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("A Faculty with this ID already exists. Please use a different ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                scmd = new SqlCommand(query, con);

                // Adding parameters
                scmd.Parameters.AddWithValue("@Name", namebox.Text.Trim());
                scmd.Parameters.AddWithValue("@Id", fidbox.Text.Trim());
                scmd.Parameters.AddWithValue("@Mail", fmailbox.Text.Trim());
                scmd.Parameters.AddWithValue("@Department", fdeptcomboBox.SelectedItem?.ToString().Trim());
                scmd.Parameters.AddWithValue("@Password", passbox.Text.Trim());

                int rowsAffected = scmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    var result = MessageBox.Show("Faculty Registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Hide();
                        TeaLog teaLog = new TeaLog();
                        teaLog.ShowDialog();
                        this.Show();
                    }
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

        private void logbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeaLog teaLog = new TeaLog();
            teaLog.ShowDialog();
            this.Show();
        }

        private void exitpicbox_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
