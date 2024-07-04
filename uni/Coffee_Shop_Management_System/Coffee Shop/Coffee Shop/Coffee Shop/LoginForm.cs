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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Coffee_Shop
{
    public partial class LoginForm : Form
    {

        public string Username { get; private set; }





        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btn_signin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\alimu\\Desktop\\uni\\Coffee_Shop_Management_System\\Coffee Shop\\Coffee Shop\\Coffee Shop\\createacc.mdf\";Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string username = txt_username.Text;
                    string password = txt_password.Text;

                    string query = "SELECT COUNT(*) FROM [Table] WHERE ID  = @ID AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", username);
                        command.Parameters.AddWithValue("@Password", password);
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // Username and password match
                            // Login successful
                            Username = username;
                            MainForm2 mainForm = new MainForm2(Username);
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Username and password don't match
                            // Login failed
                            MessageBox.Show("Incorrect Username or password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Createacc().Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
