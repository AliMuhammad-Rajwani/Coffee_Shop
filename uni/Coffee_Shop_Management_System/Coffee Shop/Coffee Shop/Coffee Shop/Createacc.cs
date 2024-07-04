using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System. Data .Sql;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Runtime.Remoting.Lifetime;

namespace Coffee_Shop
{
    public partial class Createacc : Form
    {
        public Createacc()
        {
            InitializeComponent();
        }
        SqlConnection obj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\alimu\Desktop\uni\Coffee_Shop_Management_System\Coffee Shop\Coffee Shop\Coffee Shop\createacc.mdf"";Integrated Security=True");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Createacc_Load(object sender, EventArgs e)
        {

        }

        

        private void btn_signin_Click_1(object sender, EventArgs e)
        {

            new LoginForm().Show();
            this.Hide();
        }
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\alimu\\Desktop\\uni\\Coffee_Shop_Management_System\\Coffee Shop\\Coffee Shop\\Coffee Shop\\createacc.mdf\";Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection obj = new SqlConnection(connectionString))
                {
                    obj.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Table] (ID, Password, Confirmpassword) VALUES (@ID, @Password, @Confirmpassword)", obj);
                    cmd.Parameters.AddWithValue("@ID", txt_username.Text);
                    cmd.Parameters.AddWithValue("@Password", txt_password.Text);
                    cmd.Parameters.AddWithValue("@Confirmpassword", txt_confirmpassword.Text);

                    cmd.ExecuteNonQuery();
                  
                 MessageBox.Show("Create account successfully");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_confirmpassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
