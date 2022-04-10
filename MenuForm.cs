using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
   
    public partial class MenuForm : Form
    {
        private string username;

        /// <summary>
        /// Makes rounded corners for the labels
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
       );

        DataSet dsDestinatii;
        DataSet dsCazari;
        DataSet dsUser;
        public MenuForm()
        {
            InitializeComponent();
            dsDestinatii = new DataSet();
            try
            {
                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();

                SqlDataAdapter daDestinatii = new SqlDataAdapter("SELECT * FROM Destinatii", sqlConnection);
                daDestinatii.Fill(dsDestinatii, "Destinatii");
                foreach (DataRow dr in dsDestinatii.Tables["Destinatii"].Rows)
                {
                    String name = dr.ItemArray.GetValue(1).ToString();
                    comboBox_Destinations.Items.Add(name);
                    comboBox_DestinationAccomodation.Items.Add(name);
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            sqlConnection.Close();
          



        }

        public MenuForm(string username)
        {
            this.username = username;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            label_Welcome.Text = "";
           //de facut numele
               
                label_Welcome.Text = "Welcome, " + Account.username + "!";
            
            panel_Dashboard.Visible = true;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            ///Initializing rounded corners for the labels
            panel_Name.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_Name.Width, panel_Name.Height, 30, 30));
            panel_EditContactInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_EditContactInfo.Width, panel_EditContactInfo.Height, 30, 30));
            panel_ChangeUsername.Region= Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_EditContactInfo.Width, panel_EditContactInfo.Height, 30, 30));
            panel_ChangePassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_ChangePassword.Width, panel_ChangePassword.Height, 30, 30));
            panel_DeleteAccount.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_DeleteAccount.Width, panel_DeleteAccount.Height, 30, 30));


        }

      



        private void rjButton_Dashboard_MouseHover(object sender, EventArgs e)
        {
            rjButton_Dashboard.BackColor = Color.FromArgb(185, 244, 224, 255);
          
        }

        private void rjButton_Dashboard_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Dashboard.BackColor = Color.FromArgb(30, 194, 139); 
        }

        private void rjButton_Account_MouseHover(object sender, EventArgs e)
        {
            rjButton_Account.BackColor = Color.FromArgb(185, 244, 224, 255);
        }

        private void rjButton_Account_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Account.BackColor = Color.FromArgb(30, 194, 139);
        }

        private void rjButton_Settings_MouseHover(object sender, EventArgs e)
        {
            rjButton_Settings.BackColor = Color.FromArgb(185, 244, 224, 255);
        }

        private void rjButton_Settings_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Settings.BackColor = Color.FromArgb(30, 194, 139);
        }

        private void rjButton_Logout_MouseHover(object sender, EventArgs e)
        {
            rjButton_Logout.BackColor = Color.FromArgb(185, 244, 224, 255);
        }

        private void rjButton_Logout_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Logout.BackColor = Color.FromArgb(30, 194, 139);
        }

        private void rjButton_Logout_Click(object sender, EventArgs e)
        {
            Account.username = "";
            Account.password = "";
            Program.OpenDetailFormMenu = false;
            Program.OpenDetailFormRegister = false;
            Program.OpenDetailFormLogin = true;
            this.Close();

            /*LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();*/
        }

        private void rjButton_Dashboard_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = true;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;

        }

        private void rjButton_Account_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = true;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;

        }

        private void rjButton_Settings_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = true;
            panel_Destinations.Visible = false;

            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = false;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = false;
        }

        private void rjButton_changeName_Click(object sender, EventArgs e)
        {
           
            panel_Name.Visible = true;
            panel_EditContactInfo.Visible= false;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = false;
        }

        private void rjButton_ChangeContactInfo_Click(object sender, EventArgs e)
        {
            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = true;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = false;
            //de facut numele
      /*      label_DisplayFirstName.Text = ;
            label_DisplayLastName.Text = ;*/
        }

        private void rjButton_ChangeUsername_Click(object sender, EventArgs e)
        {
            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = false;
            panel_ChangeUsername.Visible = true;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = false;
        }

        private void rjButton_ChangePassword_Click(object sender, EventArgs e)
        {
            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = false;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = true;
            panel_DeleteAccount.Visible = false;
        }

        private void rjButton_DeleteAccount_Click(object sender, EventArgs e)
        {
            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = false;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = true;
        }

        private void rjButton_SaveName_Click(object sender, EventArgs e)
        {
            String firstName = textBox_FirstName.Text;
            String lastName = textBox_LastName.Text;
            String username = Account.username;
            String password = Account.password;
            String queryChangeName = "UPDATE Users SET FirstName=@firstName, LastName=@lastName WHERE UserName=@username AND Password=@password";

            try
            {

                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(queryChangeName, sqlConnection);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                //de facut numele 
                Account.FirstName = firstName;
                Account.LastName = lastName;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Name changed succesfuly!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        /// <summary>
        /// Connection to the database
        /// </summary>
        SqlConnection sqlConnection = new SqlConnection();

        /// <summary>
        /// Execution of queries in the Settings labels
        /// </summary>
      
        private void rjButton_SaveDeletedAccount_Click(object sender, EventArgs e)
        {
            String usernameEntered = textBox_deletedUsername.Text;
            String passwordEntered = textBox_deletedPassword.Text;
            String queryDeleteUser = "DELETE FROM Users WHERE UserName=@usernameEntered AND Password=@passwordEntered";


            String username = Account.username;
            String password = Account.password;
            String queryGetPass = "SELECT Password FROM Users WHERE UserName=@username";
            String queryGetUsername = "SELECT Username FROM Users WHERE Password=@password";
            try
            {
                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();


                //for same pass check user
                SqlCommand cmdCheckUser = new SqlCommand(queryGetUsername, sqlConnection);
                cmdCheckUser.Parameters.AddWithValue("@password", password);

                cmdCheckUser.Connection = sqlConnection;

                string actualUsernameCurrent = (string)cmdCheckUser.ExecuteScalar();


                //for same user check pass
                SqlCommand cmdCheckPass = new SqlCommand(queryGetPass, sqlConnection);
                cmdCheckPass.Parameters.AddWithValue("@username", username);

                cmdCheckPass.Connection = sqlConnection;

                string actualPasswordCurrent = (string)cmdCheckPass.ExecuteScalar();




                if (actualPasswordCurrent != passwordEntered)
                {
                    DialogResult resultWrong1 = MessageBox.Show("Password incorrect!", "Try again!", MessageBoxButtons.OK);
                    textBox_deletedPassword.Text = textBox_deletedUsername.Text = "";
                }
                else if (actualUsernameCurrent != usernameEntered)
                {
                    DialogResult resultWrong2 = MessageBox.Show("Username incorrect!", "Try again!", MessageBoxButtons.OK);
                    textBox_deletedPassword.Text = textBox_deletedUsername.Text = "";
                }
                else
                {
                    DialogResult resultCorrect = MessageBox.Show("Are you sure you want to delete your account?", "Attention!", MessageBoxButtons.YesNo);
                    if (resultCorrect == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand(queryDeleteUser, sqlConnection);

                        cmd.Parameters.AddWithValue("@usernameEntered", usernameEntered);
                        cmd.Parameters.AddWithValue("@passwordEntered", passwordEntered);
                        cmd.ExecuteNonQuery();

                        DialogResult resultCorrect2 = MessageBox.Show("Account deleted succesfully! You will be redirected to the register page.", "Succes!", MessageBoxButtons.OK);
                        Account.username = "";
                        Account.password = "";

                        Program.OpenDetailFormMenu = false;
                        Program.OpenDetailFormRegister = true;
                        Program.OpenDetailFormLogin = false;
                        this.Close();

                    }
                }
             

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// CHANGE PASSWORD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_SaveNewPassword_Click(object sender, EventArgs e)
        {
            String passwordCurrentUser = textBox_CheckCurrentPassword.Text;
            String passwordNew = textBox_SaveNewPassword.Text;
            
            String username = Account.username;
            String queryChangePass = "UPDATE Users SET Password=@passwordNew WHERE Password=@passwordCurrent AND UserName=@username";
            String queryGetPass = "SELECT Password FROM Users WHERE UserName=@username";
            try
            {

                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();
                SqlCommand cmdCheck = new SqlCommand(queryGetPass, sqlConnection);
                cmdCheck.Parameters.AddWithValue("@username", username);

                cmdCheck.Connection = sqlConnection;

                string actualPasswordCurrent = (string)cmdCheck.ExecuteScalar();
   

                if (actualPasswordCurrent!=passwordCurrentUser)
                {
                    DialogResult resultWrong1= MessageBox.Show("Password incorrect!", "Try again!", MessageBoxButtons.OK);
                    textBox_SaveNewPassword.Text = textBox_CheckCurrentPassword.Text = "";

                }
                else { 
                    DialogResult resultCorrect = MessageBox.Show("Are you sure you want to change your password?", "Attention!", MessageBoxButtons.YesNo);
                     if (resultCorrect == DialogResult.Yes)
                     {
                        SqlCommand cmd = new SqlCommand(queryChangePass, sqlConnection);

                        cmd.Parameters.AddWithValue("@passwordCurrent", passwordCurrentUser);
                        cmd.Parameters.AddWithValue("@passwordNew", passwordNew);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                        textBox_SaveNewPassword.Text = textBox_CheckCurrentPassword.Text = "";
                        DialogResult resultCorrect2 = MessageBox.Show("Password changed succesfully!", "Succes!", MessageBoxButtons.OK);
                        Account.password = passwordNew;

                     } 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// CHANGE USERNAME
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_SaveNewUsername_Click(object sender, EventArgs e)
        {
            String usernameCurrentUser = textBox_CheckCurrentUsername.Text;
            String usernameNew = textBox_SaveNewUsername.Text;

            String password = Account.password;
            String queryChangeUsername = "UPDATE Users SET UserName=@usernameNew WHERE UserName=@usernameCurrentUser AND Password=@password";

            String queryGetUsername = "SELECT Username FROM Users WHERE Password=@password";
            try
            {

                sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();
                SqlCommand cmdCheck = new SqlCommand(queryGetUsername, sqlConnection);
                cmdCheck.Parameters.AddWithValue("@password", password);

                cmdCheck.Connection = sqlConnection;

                string actualUsernameCurrent = (string)cmdCheck.ExecuteScalar();


                if (actualUsernameCurrent != usernameCurrentUser)
                {
                    DialogResult resultWrong1 = MessageBox.Show("Username incorrect!", "Try again!", MessageBoxButtons.OK);
                    textBox_CheckCurrentUsername.Text = textBox_SaveNewUsername.Text = "";

                }
                else
                {
                    DialogResult resultCorrect = MessageBox.Show("Are you sure you want to change your username?", "Attention!", MessageBoxButtons.YesNo);
                    if (resultCorrect == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand(queryChangeUsername, sqlConnection);

                        cmd.Parameters.AddWithValue("@usernameCurrentUser", usernameCurrentUser);
                        cmd.Parameters.AddWithValue("@usernameNew", usernameNew);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                        textBox_CheckCurrentUsername.Text = textBox_SaveNewUsername.Text = "";
                        DialogResult resultCorrect2 = MessageBox.Show("Username changed succesfully!", "Succes!", MessageBoxButtons.OK);
                        Account.username = username;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// RIGHT PANEL
        /// </summary>
     
        private void rjButton_Destinations_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = true;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            pictureBox_Destination.Visible = false;
            panel_Destinations.BackgroundImage = Properties.Resources.exploredes;
            comboBox_Destinations.Text = "See available destinations:";

        }

   

        private void comboBox_Destinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedDestination = comboBox_Destinations.SelectedItem.ToString();
            panel_Destinations.BackgroundImage = Properties.Resources.exploreaccafter;

            pictureBox_Destination.Visible = true;
            foreach(DataRow dr in dsDestinatii.Tables["Destinatii"].Rows)
            {
                if (selectedDestination == dr.ItemArray.GetValue(1).ToString())
                {
                    pictureBox_Destination.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Destination.ImageLocation= @"C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Resources\"+ dr.ItemArray.GetValue(2).ToString();
                }
            }
        }

        private void rjButton_Accomodations_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = true;
            panel_Flights.Visible = false;
            panel_Offers.Visible = false;
            panel_Accomodation.BackgroundImage = Properties.Resources.exploreacc;
        }

        private void rjButton_Flights_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = true;
        }

        
        private void comboBox_DestinationAccomodation_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedDestination = comboBox_DestinationAccomodation.SelectedItem.ToString();
            String destinatieid;
            panel_Accomodation.BackgroundImage = Properties.Resources.exploreaccafter;


            foreach (DataRow dr in dsDestinatii.Tables["Destinatii"].Rows)
            {
                if (selectedDestination == dr.ItemArray.GetValue(1).ToString())
                {
                    destinatieid = dr.ItemArray.GetValue(0).ToString();
                    label_DisplayDestination.Text = dr.ItemArray.GetValue(1).ToString().ToUpper();
                    dsCazari = new DataSet();
                    try
                    {
                        sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Cazari WHERE Destinatie_id=@destinatieid", sqlConnection);
                        cmd.Parameters.AddWithValue("@destinatieid", destinatieid);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter daCazari = new SqlDataAdapter(cmd);
                        daCazari.Fill(dsCazari, "Cazari");
                        foreach (DataRow dr2 in dsCazari.Tables["Cazari"].Rows)
                        {

                            label_StartDate.Text = dr2.ItemArray.GetValue(2).ToString();
                            label_EndDate.Text= dr2.ItemArray.GetValue(3).ToString();
                            label_DisplayPrice.Text= dr2.ItemArray.GetValue(4).ToString();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                    sqlConnection.Close();
                }
            }
            panel_Offers.Visible = true;
        }

       
    }
}
