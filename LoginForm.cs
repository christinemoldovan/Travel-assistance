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
    public partial class LoginForm : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        public LoginForm()
        {
           
            InitializeComponent();
            try
            {
                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlConnection.Close();

        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
          
        }
        

        private void rjButton_RegisterPage_Click(object sender, EventArgs e)
        {
            Program.CheckExit = true;
            Program.OpenDetailFormRegister = true;
            this.Close();
        }

        private void rjButton_ExitLogin_Click(object sender, EventArgs e)
        {
            Program.CheckExit = false;
            Application.Exit();

        }

        private void rjButton_Login_Click(object sender, EventArgs e)
        {

            String username = textBox_Username.Text;
            String password = textBox_Password.Text;
            textBox_Username.MaxLength = 21;
            String queryLogin = "SELECT * FROM Users WHERE UserName=@username AND Password=@password COLLATE SQL_Latin1_General_CP1_CS_AS ";
            try
            {
               

                SqlCommand cmd = new SqlCommand(queryLogin, sqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
               
                if (dt.Rows.Count > 0)
                {
                    
                    Account.username = username;
                    Account.password = password;
                    Program.OpenDetailFormMenu = true;
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Incorrect credentials");
                    textBox_Password.Text = textBox_Username.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            sqlConnection.Close();

        }

        
    }
}
