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

namespace Proiect
{
    public partial class RegisterForm : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
   
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void rjButton_LoginPage_Click(object sender, EventArgs e)
        {
            Program.CheckExit = true;
            Program.OpenDetailFormLogin = true;
            Program.OpenDetailFormMenu = false;
            this.Close();

        }
        
        private void rjButton_ExitRegister_Click(object sender, EventArgs e)
        {
            Program.CheckExit = false;
            Application.Exit();
        }


        private void rjButton_CreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                String username = textBox_newUsername.Text;
                String password = textBox_newPassword.Text;
                String passwordCheck = textBox_PasswordCheck.Text;
                textBox_newUsername.MaxLength = 21;
                String queryLogin = "SELECT * FROM Users WHERE UserName=@username AND Password=@password COLLATE SQL_Latin1_General_CP1_CS_AS ";
                String queryInsert = "INSERT INTO Users(UserName, Password) VALUES(@username, @password)";



                if ((username != string.Empty || password != string.Empty || passwordCheck != string.Empty) && password.Equals(passwordCheck))
                {
                    try
                    {
                        sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";
                        sqlConnection.Open();
                        SqlCommand cmdLogin = new SqlCommand(queryLogin, sqlConnection);
                        SqlDataAdapter sda = new SqlDataAdapter(cmdLogin);
                        DataTable dt = new DataTable();

                        cmdLogin.Parameters.AddWithValue("@username", username);
                        cmdLogin.Parameters.AddWithValue("@password", password);
                        cmdLogin.CommandType = CommandType.Text;

                        SqlDataReader dr = cmdLogin.ExecuteReader();

                        if (dr.Read())
                        {
                            dr.Close();
                            MessageBox.Show("Username already exists, try another!", "Error");
                            textBox_newPassword.Text = textBox_newUsername.Text = textBox_PasswordCheck.Text = "";
                        }
                        else
                        {
                            dr.Close();
                            SqlCommand cmdInsert = new SqlCommand(queryInsert, sqlConnection);
                            // SqlDataAdapter sda2 = new SqlDataAdapter();
                            cmdInsert.Parameters.AddWithValue("@username", username);
                            cmdInsert.Parameters.AddWithValue("@password", password);

                            cmdInsert.CommandType = CommandType.Text;

                            cmdInsert.ExecuteNonQuery();


                            DialogResult resultCorrect = MessageBox.Show("Account created succesfully! Log in?", "Welcome!", MessageBoxButtons.YesNo);
                            if (resultCorrect == DialogResult.Yes)
                            {
                                Account.username = username;
                                Account.password = password;
                                Account.FirstName = "";
                                Account.LastName = "";
                                Program.OpenDetailFormMenu = true ;
                                this.Close();
                               
                            }
                             textBox_newPassword.Text = textBox_newUsername.Text = textBox_PasswordCheck.Text = "";
                        }
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                } else if (password.Equals(passwordCheck) == false)
                {
                    MessageBox.Show("Passwords do not match!");
                    textBox_newPassword.Text = textBox_newUsername.Text = textBox_PasswordCheck.Text = "";
                }
                }catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
          

        }

        
    }
}
