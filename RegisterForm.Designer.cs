
namespace Proiect
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeftLogin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelRightLogin = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rjButton_ExitRegister = new Proiect.RJControls.RJButton();
            this.rjButton_LoginPage = new Proiect.RJControls.RJButton();
            this.rjButton_CreateAccount = new Proiect.RJControls.RJButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_PasswordCheck = new System.Windows.Forms.TextBox();
            this.textBox_newPassword = new System.Windows.Forms.TextBox();
            this.textBox_newUsername = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.rjButton_GoToLogin = new Proiect.RJControls.RJButton();
            this.rjButton_Register = new Proiect.RJControls.RJButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.rjButton_HiddenPass = new Proiect.RJControls.RJButton();
            this.panelLeftLogin.SuspendLayout();
            this.panelRightLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftLogin
            // 
            this.panelLeftLogin.BackColor = System.Drawing.Color.GhostWhite;
            this.panelLeftLogin.BackgroundImage = global::Proiect.Properties.Resources.login_pana;
            this.panelLeftLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLeftLogin.Controls.Add(this.label1);
            this.panelLeftLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLeftLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLeftLogin.Name = "panelLeftLogin";
            this.panelLeftLogin.Size = new System.Drawing.Size(450, 484);
            this.panelLeftLogin.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(51)))), ((int)(((byte)(251)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(39, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME, TRAVELLER!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRightLogin
            // 
            this.panelRightLogin.BackColor = System.Drawing.Color.GhostWhite;
            this.panelRightLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelRightLogin.Controls.Add(this.panel1);
            this.panelRightLogin.Controls.Add(this.panel2);
            this.panelRightLogin.Controls.Add(this.rjButton_GoToLogin);
            this.panelRightLogin.Controls.Add(this.rjButton_Register);
            this.panelRightLogin.Controls.Add(this.label6);
            this.panelRightLogin.Controls.Add(this.label7);
            this.panelRightLogin.Controls.Add(this.label5);
            this.panelRightLogin.Controls.Add(this.textBox2);
            this.panelRightLogin.Controls.Add(this.textBox1);
            this.panelRightLogin.Controls.Add(this.textBox_Username);
            this.panelRightLogin.Controls.Add(this.label4);
            this.panelRightLogin.Controls.Add(this.label3);
            this.panelRightLogin.Controls.Add(this.label2);
            this.panelRightLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(93)))), ((int)(((byte)(119)))));
            this.panelRightLogin.Location = new System.Drawing.Point(0, 0);
            this.panelRightLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRightLogin.Name = "panelRightLogin";
            this.panelRightLogin.Size = new System.Drawing.Size(836, 484);
            this.panelRightLogin.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.rjButton_HiddenPass);
            this.panel1.Controls.Add(this.rjButton_ExitRegister);
            this.panel1.Controls.Add(this.rjButton_LoginPage);
            this.panel1.Controls.Add(this.rjButton_CreateAccount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBox_PasswordCheck);
            this.panel1.Controls.Add(this.textBox_newPassword);
            this.panel1.Controls.Add(this.textBox_newUsername);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(93)))), ((int)(((byte)(119)))));
            this.panel1.Location = new System.Drawing.Point(450, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 484);
            this.panel1.TabIndex = 18;
            // 
            // rjButton_ExitRegister
            // 
            this.rjButton_ExitRegister.BackColor = System.Drawing.Color.Gainsboro;
            this.rjButton_ExitRegister.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.rjButton_ExitRegister.BorderColor = System.Drawing.Color.Transparent;
            this.rjButton_ExitRegister.BorderRadius = 20;
            this.rjButton_ExitRegister.BorderSize = 0;
            this.rjButton_ExitRegister.FlatAppearance.BorderSize = 0;
            this.rjButton_ExitRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_ExitRegister.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 10F, System.Drawing.FontStyle.Bold);
            this.rjButton_ExitRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rjButton_ExitRegister.Image = global::Proiect.Properties.Resources.sign_out_alt_free_icon_font;
            this.rjButton_ExitRegister.Location = new System.Drawing.Point(322, 3);
            this.rjButton_ExitRegister.Name = "rjButton_ExitRegister";
            this.rjButton_ExitRegister.Size = new System.Drawing.Size(52, 52);
            this.rjButton_ExitRegister.TabIndex = 19;
            this.rjButton_ExitRegister.TextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rjButton_ExitRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rjButton_ExitRegister.UseVisualStyleBackColor = false;
            this.rjButton_ExitRegister.Click += new System.EventHandler(this.rjButton_ExitRegister_Click);
            // 
            // rjButton_LoginPage
            // 
            this.rjButton_LoginPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_LoginPage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_LoginPage.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.rjButton_LoginPage.BorderRadius = 20;
            this.rjButton_LoginPage.BorderSize = 0;
            this.rjButton_LoginPage.FlatAppearance.BorderSize = 0;
            this.rjButton_LoginPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_LoginPage.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.rjButton_LoginPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_LoginPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rjButton_LoginPage.Location = new System.Drawing.Point(127, 400);
            this.rjButton_LoginPage.Name = "rjButton_LoginPage";
            this.rjButton_LoginPage.Size = new System.Drawing.Size(150, 40);
            this.rjButton_LoginPage.TabIndex = 16;
            this.rjButton_LoginPage.Text = "Login";
            this.rjButton_LoginPage.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_LoginPage.UseVisualStyleBackColor = false;
            this.rjButton_LoginPage.Click += new System.EventHandler(this.rjButton_LoginPage_Click);
            // 
            // rjButton_CreateAccount
            // 
            this.rjButton_CreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_CreateAccount.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_CreateAccount.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.rjButton_CreateAccount.BorderRadius = 20;
            this.rjButton_CreateAccount.BorderSize = 0;
            this.rjButton_CreateAccount.FlatAppearance.BorderSize = 0;
            this.rjButton_CreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_CreateAccount.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.rjButton_CreateAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_CreateAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rjButton_CreateAccount.Location = new System.Drawing.Point(127, 290);
            this.rjButton_CreateAccount.Name = "rjButton_CreateAccount";
            this.rjButton_CreateAccount.Size = new System.Drawing.Size(150, 40);
            this.rjButton_CreateAccount.TabIndex = 15;
            this.rjButton_CreateAccount.Text = "Register";
            this.rjButton_CreateAccount.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_CreateAccount.UseVisualStyleBackColor = false;
            this.rjButton_CreateAccount.Click += new System.EventHandler(this.rjButton_CreateAccount_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(23, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "Already a traveller?";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(23, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 30);
            this.label9.TabIndex = 1;
            this.label9.Text = "Sign up now!";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Fax", 13.8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(51)))), ((int)(((byte)(251)))));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(5, 283);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 27);
            this.label10.TabIndex = 8;
            // 
            // textBox_PasswordCheck
            // 
            this.textBox_PasswordCheck.BackColor = System.Drawing.Color.Lavender;
            this.textBox_PasswordCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PasswordCheck.Font = new System.Drawing.Font("Lucida Fax", 12F);
            this.textBox_PasswordCheck.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_PasswordCheck.Location = new System.Drawing.Point(74, 251);
            this.textBox_PasswordCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_PasswordCheck.Name = "textBox_PasswordCheck";
            this.textBox_PasswordCheck.Size = new System.Drawing.Size(236, 24);
            this.textBox_PasswordCheck.TabIndex = 7;
            // 
            // textBox_newPassword
            // 
            this.textBox_newPassword.BackColor = System.Drawing.Color.Lavender;
            this.textBox_newPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_newPassword.Font = new System.Drawing.Font("Lucida Fax", 12F);
            this.textBox_newPassword.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_newPassword.Location = new System.Drawing.Point(74, 201);
            this.textBox_newPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_newPassword.Name = "textBox_newPassword";
            this.textBox_newPassword.Size = new System.Drawing.Size(236, 24);
            this.textBox_newPassword.TabIndex = 6;
            // 
            // textBox_newUsername
            // 
            this.textBox_newUsername.BackColor = System.Drawing.Color.Lavender;
            this.textBox_newUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_newUsername.Font = new System.Drawing.Font("Lucida Fax", 12F);
            this.textBox_newUsername.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_newUsername.Location = new System.Drawing.Point(74, 151);
            this.textBox_newUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_newUsername.Name = "textBox_newUsername";
            this.textBox_newUsername.Size = new System.Drawing.Size(236, 24);
            this.textBox_newUsername.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Fax", 11.2F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(74, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 22);
            this.label11.TabIndex = 3;
            this.label11.Text = "Re-enter password:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Fax", 11.2F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(74, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 22);
            this.label12.TabIndex = 2;
            this.label12.Text = "Password:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Fax", 11.2F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(74, 127);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 22);
            this.label13.TabIndex = 1;
            this.label13.Text = "Username:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.BackgroundImage = global::Proiect.Properties.Resources.login_pana;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 484);
            this.panel2.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(51)))), ((int)(((byte)(251)))));
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(21, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(379, 50);
            this.label14.TabIndex = 0;
            this.label14.Text = "WELCOME, TRAVELLER!";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rjButton_GoToLogin
            // 
            this.rjButton_GoToLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_GoToLogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_GoToLogin.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.rjButton_GoToLogin.BorderRadius = 20;
            this.rjButton_GoToLogin.BorderSize = 0;
            this.rjButton_GoToLogin.FlatAppearance.BorderSize = 0;
            this.rjButton_GoToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_GoToLogin.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.rjButton_GoToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_GoToLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rjButton_GoToLogin.Location = new System.Drawing.Point(118, 372);
            this.rjButton_GoToLogin.Name = "rjButton_GoToLogin";
            this.rjButton_GoToLogin.Size = new System.Drawing.Size(150, 40);
            this.rjButton_GoToLogin.TabIndex = 16;
            this.rjButton_GoToLogin.Text = "Login";
            this.rjButton_GoToLogin.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_GoToLogin.UseVisualStyleBackColor = false;
            // 
            // rjButton_Register
            // 
            this.rjButton_Register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_Register.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_Register.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.rjButton_Register.BorderRadius = 20;
            this.rjButton_Register.BorderSize = 0;
            this.rjButton_Register.FlatAppearance.BorderSize = 0;
            this.rjButton_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_Register.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.rjButton_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_Register.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rjButton_Register.Location = new System.Drawing.Point(118, 222);
            this.rjButton_Register.Name = "rjButton_Register";
            this.rjButton_Register.Size = new System.Drawing.Size(150, 40);
            this.rjButton_Register.TabIndex = 15;
            this.rjButton_Register.Text = "Register";
            this.rjButton_Register.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.rjButton_Register.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(17, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 30);
            this.label6.TabIndex = 14;
            this.label6.Text = "Already a traveller?";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(226)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(17, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sign up now!";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(51)))), ((int)(((byte)(251)))));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(5, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 27);
            this.label5.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Lavender;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Lucida Fax", 12F);
            this.textBox2.ForeColor = System.Drawing.Color.DimGray;
            this.textBox2.Location = new System.Drawing.Point(70, 178);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(236, 24);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Lavender;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Lucida Fax", 12F);
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(70, 128);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(236, 24);
            this.textBox1.TabIndex = 6;
            // 
            // textBox_Username
            // 
            this.textBox_Username.BackColor = System.Drawing.Color.Lavender;
            this.textBox_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Username.Font = new System.Drawing.Font("Lucida Fax", 12F);
            this.textBox_Username.ForeColor = System.Drawing.Color.DimGray;
            this.textBox_Username.Location = new System.Drawing.Point(70, 78);
            this.textBox_Username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(236, 24);
            this.textBox_Username.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 11.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(66, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Re-enter password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(66, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 11.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(66, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // rjButton_HiddenPass
            // 
            this.rjButton_HiddenPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_HiddenPass.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(233)))));
            this.rjButton_HiddenPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rjButton_HiddenPass.BorderColor = System.Drawing.Color.Transparent;
            this.rjButton_HiddenPass.BorderRadius = 10;
            this.rjButton_HiddenPass.BorderSize = 0;
            this.rjButton_HiddenPass.FlatAppearance.BorderSize = 0;
            this.rjButton_HiddenPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton_HiddenPass.Font = new System.Drawing.Font("Fira Sans Extra Condensed Black", 10F, System.Drawing.FontStyle.Bold);
            this.rjButton_HiddenPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rjButton_HiddenPass.Image = global::Proiect.Properties.Resources.eyepassnew;
            this.rjButton_HiddenPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rjButton_HiddenPass.Location = new System.Drawing.Point(316, 199);
            this.rjButton_HiddenPass.Name = "rjButton_HiddenPass";
            this.rjButton_HiddenPass.Size = new System.Drawing.Size(30, 30);
            this.rjButton_HiddenPass.TabIndex = 22;
            this.rjButton_HiddenPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rjButton_HiddenPass.TextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rjButton_HiddenPass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rjButton_HiddenPass.UseVisualStyleBackColor = false;
            this.rjButton_HiddenPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rjButton_HiddenPass_MouseDown);
            this.rjButton_HiddenPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rjButton_HiddenPass_MouseUp);
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.rjButton_CreateAccount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(836, 484);
            this.Controls.Add(this.panelLeftLogin);
            this.Controls.Add(this.panelRightLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginChild";
            this.panelLeftLogin.ResumeLayout(false);
            this.panelLeftLogin.PerformLayout();
            this.panelRightLogin.ResumeLayout(false);
            this.panelRightLogin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelLeftLogin;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelRightLogin;
        private RJControls.RJButton rjButton_GoToLogin;
        private RJControls.RJButton rjButton_Register;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private RJControls.RJButton rjButton_LoginPage;
        private RJControls.RJButton rjButton_CreateAccount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_PasswordCheck;
        private System.Windows.Forms.TextBox textBox_newPassword;
        private System.Windows.Forms.TextBox textBox_newUsername;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private RJControls.RJButton rjButton_ExitRegister;
        private RJControls.RJButton rjButton_HiddenPass;
    }
}