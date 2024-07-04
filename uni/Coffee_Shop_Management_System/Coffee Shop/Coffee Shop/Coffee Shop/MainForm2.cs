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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Coffee_Shop
{
    public partial class MainForm2 : Form
    {
        private object dataTable;
        private string username;

        public MainForm2(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cup Cake");
            comboBox1.Items.Add("Chocolate Chip cookie");
            comboBox1.Items.Add("Sandwich");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Cappuccino")
            {
                textBox1.Text = "100";
            }
            else if (comboBox1.SelectedItem.ToString() == "Cold Coffee")
            {
                {
                    textBox1.Text = "200";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Latte")
            {
                {
                    textBox1.Text = "500";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Cup Cake")
            {
                {
                    textBox1.Text = "300";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Chocolate Chip cookie")
            {
                {
                    textBox1.Text = "500";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Sandwich")
            {
                {
                    textBox1.Text = "700";
                }
            }
            else
            {
                textBox1.Text = "0";
            }
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cappuccino");
            comboBox1.Items.Add("Cold Coffee");
            comboBox1.Items.Add("Latte");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox3.Text = (Convert.ToInt64(textBox1.Text) * Convert.ToInt64(textBox2.Text)).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text);

            textBox4.Text = (Convert.ToInt16(textBox4.Text) + Convert.ToInt16(textBox3.Text)).ToString();
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        textBox4.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value)).ToString();
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
            MessageBox.Show("Logout successfully");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Createacc().Show();
            this.Hide();
        }




        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();

            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();
            comboBox1.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";

        }


        private void SaveDataToDatabase()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\alimu\\Desktop\\uni\\Coffee_Shop_Management_System\\Coffee Shop\\Coffee Shop\\Coffee Shop\\order.mdf\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue; // Skip the last empty new row

                        string itemName = row.Cells[0].Value.ToString();
                        string unitPrice = row.Cells[1].Value.ToString();
                        string quantity = row.Cells[2].Value.ToString();
                        string total = row.Cells[3].Value.ToString();
                        string dateTime = row.Cells[4].Value.ToString();

                        string query = "INSERT INTO [Orders] (Username, ItemName, UnitPrice, Quantity, Total, DateTime) VALUES (@Username, @ItemName, @UnitPrice, @Quantity, @Total, @DateTime)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", this.username);
                            command.Parameters.AddWithValue("@ItemName", itemName);
                            command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Total", total);
                            command.Parameters.AddWithValue("@DateTime", dateTime);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Order saved successfully!", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void yes_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;

            if (yes.Checked)
            {
                if (Int16.TryParse(textBox5.Text, out Int16 tipAmount) &&
                    Int16.TryParse(textBox4.Text, out Int16 subtotal))
                {
                    textBox6.Text = (subtotal + tipAmount).ToString();
                }
                else
                {
                    // Handle the case when the conversion fails
                    textBox6.Text = "Invalid input";
                }
            }
        }

        private void No_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox5.Text = "0";
            textBox6.Text = textBox4.Text;
            textBox6.Enabled = false;
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
  