using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Proiect
{

    public partial class MenuForm : Form
    {
        DataSet dsDestinatii;
        DataSet dsCazari;
        DataSet dsZboruri;
        private string username;

        //for dgv:
        DataTable dt = new DataTable();

        /// <summary>
        /// Connection to the database
        /// </summary>
        SqlConnection sqlConnection = new SqlConnection();

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


        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }


        public MenuForm()
        {
            InitializeComponent();
            dsDestinatii = new DataSet();
            dsZboruri = new DataSet();

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
                    comboBox_ShowCityFlights.Items.Add(name);
                    comboBox_displayDestination.Items.Add(name);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }


            sqlConnection.Close();
            dataGridView_Filters.RowHeadersVisible = false;
            dataGridView_userTrips.RowHeadersVisible = false;
            MyDataGridView();

            //adaugam date in combobox
            var dataSource = new List<Language>();
            dataSource.Add(new Language() { Name = "Cheapest accomodations", Value = "1" });
            dataSource.Add(new Language() { Name = "Expensive accomodations", Value = "2" });
            dataSource.Add(new Language() { Name = "Cheapest flights", Value = "3" });
            dataSource.Add(new Language() { Name = "Expensive flights", Value = "4" });

            //Setup data binding
            this.comboBox_Filters.DataSource = dataSource;
            this.comboBox_Filters.DisplayMember = "Name";
            this.comboBox_Filters.ValueMember = "Value";

            // make it readonly
            this.comboBox_Filters.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        /// <summary>
        /// display in datagridview using a temp table
        /// </summary>

        public void MyDataGridView()
        {
            //sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";
            string userIdLoggedIn = Account.userid;

            sqlConnection.Open();

            FileInfo file = new FileInfo(@"C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\CreateTemporaryDashboard.sql");
            string script = file.OpenText().ReadToEnd();
            try
            {
                Server server = new Server(new ServerConnection(sqlConnection));
                server.ConnectionContext.ExecuteNonQuery(script);
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM #Dashboard WHERE UserId=@userIdLoggedIn", sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@userIdLoggedIn", userIdLoggedIn);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        dataGridView_userTrips.DataSource = dt;
                        dataGridView_userTrips.Refresh();
                        this.dataGridView_userTrips.Columns["UserId"].Visible = false;
                        labelNoTripsBooked.Visible = false;
                        if (dataGridView_userTrips.Rows.Count == 0)
                        {
                            dataGridView_userTrips.Visible = false;
                            rjButton_DeletePlanUser.Visible = false;
                            labelNoTripsBooked.Visible = true;
                        }
                        else
                        {
                            dataGridView_userTrips.Visible = true;
                            rjButton_DeletePlanUser.Visible = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception: " + exp.Message);
            }

            sqlConnection.Close();
        }
        /// <summary>
        /// Delete user plan from datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_DeletePlanUser_Click(object sender, EventArgs e)
        {
            //  sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";
            sqlConnection.Open();
            FileInfo file = new FileInfo(@"C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\CreateTemporaryDashboard.sql");
            string script = file.OpenText().ReadToEnd();
            try
            {
                Server server = new Server(new ServerConnection(sqlConnection));
                server.ConnectionContext.ExecuteNonQuery(script);
                int selectedIndex = dataGridView_userTrips.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridView_userTrips.Rows[selectedIndex];

                string destinatie = Convert.ToString(row.Cells["Destination"].Value);
                int userId = Convert.ToInt32(row.Cells["UserId"].Value);
                int currentRowIndex = dataGridView_userTrips.CurrentRow.Index;
                SqlCommand command = new SqlCommand("DELETE FROM #Dashboard WHERE [Destination] = @destinatie", sqlConnection);
                SqlCommand command1 = new SqlCommand("DELETE P FROM Planificari as P INNER JOIN Destinatii ON P.Destinatie_id = Destinatii.Destinatie_id  " +
                    "WHERE CONVERT(varchar,Destinatii.NumeDestinatie) = @destinatie " +
                    "AND P.Destinatie_id = Destinatii.Destinatie_id AND P.User_id = @userId", sqlConnection);
                command.Parameters.AddWithValue("@destinatie", destinatie);
                command1.Parameters.AddWithValue("@destinatie", destinatie);
                command1.Parameters.AddWithValue("@userId", userId);
                DialogResult resultCorrect = MessageBox.Show("Are you sure you want to delete your plan?", "Attention!", MessageBoxButtons.YesNo);
                if (resultCorrect == DialogResult.Yes)
                {
                    command1.ExecuteNonQuery();
                    dt.Rows[currentRowIndex].Delete();
                    command.ExecuteNonQuery();
                    dataGridView_userTrips.Refresh();
                    DialogResult resultCorrect2 = MessageBox.Show("Plan deleted succesfully!", "Succes!", MessageBoxButtons.OK);

                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception: " + exp.Message);
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

            if (Account.FirstName == "")
            {
                label_Welcome.Text = "Welcome, " + Account.username + "!";
            }
            else
            {
                label_Welcome.Text = "Welcome, " + Account.FirstName + "!";
            }
            panel_Dashboard.Visible = true;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Flights.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Offers.Visible = false;
            panel_myPlans.Visible = false;

            ///Initializing rounded corners for the labels
            panel_Name.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_Name.Width, panel_Name.Height, 30, 30));
            panel_EditContactInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_EditContactInfo.Width, panel_EditContactInfo.Height, 30, 30));
            panel_ChangeUsername.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_EditContactInfo.Width, panel_EditContactInfo.Height, 30, 30));
            panel_ChangePassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_ChangePassword.Width, panel_ChangePassword.Height, 30, 30));
            panel_DeleteAccount.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_DeleteAccount.Width, panel_DeleteAccount.Height, 30, 30));


        }

        // CHANGE COLOR WHEN MOUSE GOES OVER BUTTON
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

        // TODO: color the other buttons
        private void rjButton_Destinations_MouseHover(object sender, EventArgs e)
        {
            rjButton_Destinations.BackColor = Color.FromArgb(185, 244, 224, 255);
        }

        private void rjButton_Destinations_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Destinations.BackColor = Color.FromArgb(30, 194, 139);
        }

        private void rjButton_Accomodations_MouseHover(object sender, EventArgs e)
        {
            rjButton_Accomodations.BackColor = Color.FromArgb(185, 244, 224, 255);
        }

        private void rjButton_Accomodations_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Accomodations.BackColor = Color.FromArgb(30, 194, 139);
        }

        private void rjButton_Flights_MouseHover(object sender, EventArgs e)
        {
            rjButton_Flights.BackColor = Color.FromArgb(185, 244, 224, 255);
        }
        private void rjButton_Flights_MouseLeave(object sender, EventArgs e)
        {
            rjButton_Flights.BackColor = Color.FromArgb(30, 194, 139);

        }

        /// <summary>
        /// CHANGING PANELS THROUGH CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 


        private void rjButton_Logout_Click(object sender, EventArgs e)
        {
            Account.username = "";
            Account.password = "";
            Program.OpenDetailFormMenu = false;
            Program.OpenDetailFormRegister = false;
            Program.OpenDetailFormLogin = true;
            this.Close();

        }
        /// <summary>
        /// dashboard panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_Dashboard_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = true;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            panel_Offers.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = false;
            panel_AccountInformation.Visible = false;


        }
        int passLength = Account.password.Length;
        string hiddenPass = "";
        /// <summary>
        /// Fill account informations on account panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_Account_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = true;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            panel_Offers.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = false;
            panel_AccountInformation.Visible = true;

            //display username and password in panel account info:
            label_infoUsername.Text = Account.username;

            for (int i = 1; i <= passLength; i++)
            {
                hiddenPass += "*";
            }
            label_infoPassword.Text = hiddenPass;

        }
        /// <summary>
        /// Hidden password button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_HideShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            label_infoPassword.Text = Account.password;
        }

        private void rjButton_HideShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            label_infoPassword.Text = hiddenPass;
        }
        /// <summary>
        /// settings panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_Settings_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = true;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            panel_Offers.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = false;
            panel_AccountInformation.Visible = false;


            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = false;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = false;
        }

        private void rjButton_changeName_Click(object sender, EventArgs e)
        {

            panel_Name.Visible = true;
            panel_EditContactInfo.Visible = false;
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
            label_DisplayFirstName.Text = Account.FirstName;
            label_DisplayLastName.Text = Account.LastName;

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
            textBox_CheckCurrentPassword.UseSystemPasswordChar = true;
            textBox_SaveNewPassword.UseSystemPasswordChar = true;
        }

        private void rjButton_DeleteAccount_Click(object sender, EventArgs e)
        {
            panel_Name.Visible = false;
            panel_EditContactInfo.Visible = false;
            panel_ChangeUsername.Visible = false;
            panel_ChangePassword.Visible = false;
            panel_DeleteAccount.Visible = true;
            textBox_deletedPassword.UseSystemPasswordChar = true;
        }
        /// <summary>
        /// Execution of queries in the Settings labels
        /// </summary>

        /// <summary>
        /// Update name of the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_SaveName_Click(object sender, EventArgs e)
        {
            String firstName = textBox_FirstName.Text;
            String lastName = textBox_LastName.Text;
            String username = Account.username;
            String password = Account.password;
            String queryChangeName = "UPDATE Users SET FirstName=@firstName, LastName=@lastName WHERE UserName=@username AND Password=@password";

            try
            {

                //sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(queryChangeName, sqlConnection);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                //merge
                Account.FirstName = firstName;
                Account.LastName = lastName;
                cmd.ExecuteNonQuery();
                label_Welcome.Text = "Welcome, " + Account.FirstName + "!";

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
        /// Delete user account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                // sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

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
        /// Change user password
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

                // sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                sqlConnection.Open();
                SqlCommand cmdCheck = new SqlCommand(queryGetPass, sqlConnection);
                cmdCheck.Parameters.AddWithValue("@username", username);

                cmdCheck.Connection = sqlConnection;

                string actualPasswordCurrent = (string)cmdCheck.ExecuteScalar();


                if (actualPasswordCurrent != passwordCurrentUser)
                {
                    DialogResult resultWrong1 = MessageBox.Show("Password incorrect!", "Try again!", MessageBoxButtons.OK);
                    textBox_SaveNewPassword.Text = textBox_CheckCurrentPassword.Text = "";

                }
                else
                {
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
        /// Change user username
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

                // sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

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
        /// Destination panel
        private void rjButton_Destinations_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = true;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            pictureBox_Destination.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = false;


            panel_Destinations.BackgroundImage = Properties.Resources.exploredes;
            comboBox_Destinations.Text = "See available destinations:";

        }
        /// <summary>
        /// Accomodation panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_Accomodations_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = true;
            panel_Flights.Visible = false;
            panel_Offers.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = false;
            comboBox_DestinationAccomodation.Text = "Select your dream destination";

            panel_Accomodation.BackgroundImage = Properties.Resources.exploreacc;
        }
        /// <summary>
        /// Flights panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_Flights_Click(object sender, EventArgs e)
        {
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = true;
            panel_Flights.BackgroundImage = Properties.Resources.exploreflights;
            panel_DisplayFlights.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = false;
            comboBox_ShowCityFlights.Text = "Select your next destination";

        }
        /// <summary>
        /// Booking panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_Book_Click(object sender, EventArgs e)
        {
            panel_CitySearch.Visible = true;
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            panel_DisplayFlights.Visible = false;
            panel_BookYourTrip.Visible = true;
            panel_myPlans.Visible = false;

            panel_CitySearch.Visible = false;
            panel_cheapestOffer.Visible = false;
        }
        /// <summary>
        /// Planification panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_MyPlans_Click(object sender, EventArgs e)
        {
            panel_CitySearch.Visible = true;
            panel_Dashboard.Visible = false;
            panel_Account.Visible = false;
            panel_Settings.Visible = false;
            panel_Destinations.Visible = false;
            panel_Accomodation.Visible = false;
            panel_Flights.Visible = false;
            panel_DisplayFlights.Visible = false;
            panel_BookYourTrip.Visible = false;
            panel_myPlans.Visible = true;
            dataGridView_userTrips.Update();
            dataGridView_userTrips.Refresh();


        }

        /// <summary>
        /// Select destination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Destinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedDestination = comboBox_Destinations.SelectedItem.ToString();
            panel_Destinations.BackgroundImage = Properties.Resources.exploreaccafter;

            pictureBox_Destination.Visible = true;
            foreach (DataRow dr in dsDestinatii.Tables["Destinatii"].Rows)
            {
                if (selectedDestination == dr.ItemArray.GetValue(1).ToString())
                {
                    pictureBox_Destination.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_Destination.ImageLocation = @"C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Resources\" + dr.ItemArray.GetValue(2).ToString();
                }
            }
        }


        /// <summary>
        /// Select accomodation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        //  sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Cazari WHERE Destinatie_id=@destinatieid", sqlConnection);
                        cmd.Parameters.AddWithValue("@destinatieid", destinatieid);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter daCazari = new SqlDataAdapter(cmd);
                        daCazari.Fill(dsCazari, "Cazari");
                        foreach (DataRow dr2 in dsCazari.Tables["Cazari"].Rows)
                        {
                            label_StartDate.Text = dr2.ItemArray.GetValue(2).ToString();
                            label_EndDate.Text = dr2.ItemArray.GetValue(3).ToString();
                            label_DisplayPrice.Text = dr2.ItemArray.GetValue(4).ToString();
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


        /// <summary>
        /// Select flights
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ShowCityFlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedDestination = comboBox_ShowCityFlights.SelectedItem.ToString();
            Console.WriteLine(selectedDestination);

            String destinatieid;
            panel_Flights.BackgroundImage = Properties.Resources.exploreaccafter;


            foreach (DataRow dr in dsDestinatii.Tables["Destinatii"].Rows)
            {
                if (selectedDestination == dr.ItemArray.GetValue(1).ToString())
                {
                    destinatieid = dr.ItemArray.GetValue(0).ToString();
                    label_FlightDestination.Text = dr.ItemArray.GetValue(1).ToString().ToUpper();
                    dsZboruri = new DataSet();
                    try
                    {
                        // sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Zboruri WHERE Destinatie_id=@destinatieid", sqlConnection);
                        cmd.Parameters.AddWithValue("@destinatieid", destinatieid);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter daZboruri = new SqlDataAdapter(cmd);
                        daZboruri.Fill(dsZboruri, "Zboruri");
                        foreach (DataRow dr2 in dsZboruri.Tables["Zboruri"].Rows)
                        {

                            label_FlightStart.Text = dr2.ItemArray.GetValue(2).ToString();
                            label_FlightEnd.Text = dr2.ItemArray.GetValue(3).ToString();
                            label_displayAirport.Text = dr2.ItemArray.GetValue(4).ToString();
                            label_FlightPrice.Text = dr2.ItemArray.GetValue(5).ToString();
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
            panel_DisplayFlights.Visible = true;
        }


        /// <summary>
        /// Display destination then display accomodation price and airplane price with date also
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comboBox_displayDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedDestination = comboBox_displayDestination.SelectedItem.ToString();

            String destinatieid;


            foreach (DataRow dr in dsDestinatii.Tables["Destinatii"].Rows)
            {
                if (selectedDestination == dr.ItemArray.GetValue(1).ToString())
                {
                    destinatieid = dr.ItemArray.GetValue(0).ToString();
                    Plan.destinatieid = dr.ItemArray.GetValue(0).ToString();
                    dsZboruri = new DataSet();
                    dsCazari = new DataSet();
                    try
                    {
                        //  sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";

                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Zboruri WHERE Destinatie_id=@destinatieid", sqlConnection);
                        cmd.Parameters.AddWithValue("@destinatieid", destinatieid);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter daZboruri = new SqlDataAdapter(cmd);
                        daZboruri.Fill(dsZboruri, "Zboruri");
                        foreach (DataRow dr2 in dsZboruri.Tables["Zboruri"].Rows)
                        {
                            label_displayTotalPrice.Text = dr2.ItemArray.GetValue(5).ToString();
                            label_displayDeparture.Text = dr2.ItemArray.GetValue(2).ToString();
                            label_displayReturn.Text = dr2.ItemArray.GetValue(3).ToString();
                            label_displayDetailsAirport.Text = dr2.ItemArray.GetValue(4).ToString();

                            Plan.zborid = dr2.ItemArray.GetValue(0).ToString();
                            Plan.datastart = dr2.ItemArray.GetValue(2).ToString();
                            Plan.datastop = dr2.ItemArray.GetValue(3).ToString();

                        }

                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM Cazari WHERE Destinatie_id=@destinatieid", sqlConnection);
                        cmd2.Parameters.AddWithValue("@destinatieid", destinatieid);
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter daCazari = new SqlDataAdapter(cmd2);
                        daCazari.Fill(dsCazari, "Cazari");
                        foreach (DataRow dr3 in dsCazari.Tables["Cazari"].Rows)
                        {
                            label_displayAccPrice.Text = dr3.ItemArray.GetValue(4).ToString();
                            Plan.cazareid = dr3.ItemArray.GetValue(0).ToString();
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
            panel_BookYourTrip.Visible = true;
        }
        /// <summary>
        /// add user plan in planification 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_BookYourTripUser_Click(object sender, EventArgs e)
        {
            //   sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chris\Documents\Facultate\SEM2\ProjectII\Proiect\Turism.mdf;Integrated Security=True";
            sqlConnection.Open();
            String userId = Account.userid;
            String destinatieId = Plan.destinatieid;
            String zborId = Plan.zborid;
            String cazareId = Plan.cazareid;
            String dataStart = Plan.datastart;
            String dataStop = Plan.datastop;
            String queryInsertPlan = "INSERT INTO Planificari(User_id, Destinatie_id, Zbor_id, Cazare_id, Data_Start, Data_Stop) VALUES (@userId, @destinatieId, @zborId, @cazareId, @dataStart, @dataStop)";
            if (!(string.IsNullOrEmpty(destinatieId)))
            {
                try
                {
                    DialogResult resultCorrect = MessageBox.Show("Are you sure you want to book this trip?", "Attention!", MessageBoxButtons.YesNo);
                    if (resultCorrect == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand(queryInsertPlan, sqlConnection);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@destinatieId", destinatieId);
                        cmd.Parameters.AddWithValue("@zborId", zborId);
                        cmd.Parameters.AddWithValue("@cazareId", cazareId);
                        cmd.Parameters.AddWithValue("@dataStart", dataStart);
                        cmd.Parameters.AddWithValue("@dataStop", dataStop);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plan added succesfuly!");
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
            else { MessageBox.Show("Please select destination!"); }
        }

        /// <summary>
        /// Choose between booking option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rjButton_userInputTrip_Click(object sender, EventArgs e)
        {
            panel_CitySearch.Visible = true;
            panel_cheapestOffer.Visible = false;
        }

        private void rjButton_cheapestOffer_Click(object sender, EventArgs e)
        {
            panel_CitySearch.Visible = false;
            panel_cheapestOffer.Visible = true;

        }
        /// <summary>
        /// Select between offer filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox_Filters.GetItemText(this.comboBox_Filters.SelectedValue);
            DataTable dt = new DataTable();
            //todo add just 2 columns
            sqlConnection.Open();

            dataGridView_Filters.Visible = false;
            if (selected == "1")
            {
                dataGridView_Filters.Visible = true;

                using (SqlCommand cmd = new SqlCommand("SELECT D.NumeDestinatie, C.Pret FROM  Destinatii D JOIN Cazari C ON D.Destinatie_id = C.Destinatie_id ORDER BY C.Pret ASC", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        dataGridView_Filters.DataSource = dt;
                        dataGridView_Filters.Columns[0].HeaderText = "Destination";
                        dataGridView_Filters.Columns[1].HeaderText = "Accomodation price per night";

                        dataGridView_Filters.Refresh();
                    }
                }
            }
            else if (selected == "2")
            {
                dataGridView_Filters.Visible = true;

                using (SqlCommand cmd = new SqlCommand("SELECT D.NumeDestinatie, C.Pret FROM  Destinatii D JOIN Cazari C ON D.Destinatie_id = C.Destinatie_id ORDER BY C.Pret DESC", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        dataGridView_Filters.DataSource = dt;
                        dataGridView_Filters.Columns[0].HeaderText = "Destination";
                        dataGridView_Filters.Columns[1].HeaderText = "Accomodation price per night";

                        dataGridView_Filters.Refresh();
                    }
                }
            }
            else if (selected == "3")
            {
                dataGridView_Filters.Visible = true;

                using (SqlCommand cmd = new SqlCommand("SELECT D.NumeDestinatie, Z.Pret FROM  Destinatii D JOIN Zboruri Z ON D.Destinatie_id = Z.Destinatie_id ORDER BY Z.Pret ASC", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        dataGridView_Filters.DataSource = dt;
                        dataGridView_Filters.Columns[0].HeaderText = "Destination";
                        dataGridView_Filters.Columns[1].HeaderText = "Flight price";
                        dataGridView_Filters.Refresh();
                    }
                }

            }
            else if (selected == "4")
            {
                dataGridView_Filters.Visible = true;

                using (SqlCommand cmd = new SqlCommand("SELECT D.NumeDestinatie, C.Pret FROM  Destinatii D JOIN Cazari C ON D.Destinatie_id = C.Destinatie_id ORDER BY C.Pret DESC", sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        dataGridView_Filters.DataSource = dt;
                        dataGridView_Filters.Columns[0].HeaderText = "Destination";
                        dataGridView_Filters.Columns[1].HeaderText = "Flight price";
                        dataGridView_Filters.Refresh();
                    }
                }

            }
            sqlConnection.Close();
        }

    }
}
