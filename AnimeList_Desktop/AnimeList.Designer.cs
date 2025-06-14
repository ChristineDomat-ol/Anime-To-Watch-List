namespace AnimeList_Desktop
{
    partial class AnimeListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeListForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblUserName = new Label();
            pictureBox2 = new PictureBox();
            bttnManageAccount = new PictureBox();
            panelDim = new Panel();
            panelManageAccount = new Panel();
            button2 = new Button();
            button1 = new Button();
            bttnEditAccountPassword = new Button();
            bttnEditAccountEmail = new Button();
            bttnEditAccountName = new Button();
            bttnDeleteAccount = new Button();
            bttnLogOut = new Button();
            txtBoxAccountPassword = new TextBox();
            txtBoxAccountEmail = new TextBox();
            txtBoxAccountName = new TextBox();
            lblPassword = new Label();
            lblEmail = new Label();
            lblName = new Label();
            lblManageAccount = new Label();
            panelEditWatched = new Panel();
            txtBoxEditWatchedRatings = new TextBox();
            lblEditWatchedRatings = new Label();
            txtBoxEditWatchedDateAndTime = new TextBox();
            lblEditWatchedDateAndTime = new Label();
            lblEditWatchedDelete = new Label();
            lblEditWatchedCancel = new Label();
            lblEditWatchedUnWatched = new Label();
            lblEditWatchedMarkAs = new Label();
            bttnEditWatchedMarkAsUnWatched = new Button();
            bttnEditWatchedDelete = new Button();
            bttnEditWatchedCancel = new Button();
            bttnEditWatchedSave = new Button();
            txtBoxEditWatchedReleaseYear = new TextBox();
            txtBoxEditWatchedGenre = new TextBox();
            txtBoxEditWatchedTitle = new TextBox();
            lblEditWatchedReleaseYear = new Label();
            lblEditWatchedGenre = new Label();
            lblEditWatchedTitle = new Label();
            lblEditWatched = new Label();
            panelEditToWatch = new Panel();
            lblEditAnimeDelete = new Label();
            lblEditAnimeCancel = new Label();
            lblEditAnimeWatched = new Label();
            lblEditAnimeMarkAs = new Label();
            bttnEditAnimeMarkAsWatched = new Button();
            bttnEditAnimeDelete = new Button();
            bttnEditAnimeCancel = new Button();
            bttnEditAnimeSave = new Button();
            txtBoxEditAnimeReleaseYear = new TextBox();
            txtBoxEditAnimeGenre = new TextBox();
            txtBoxEditAnimeTitle = new TextBox();
            lblEditAnimeReleaseYear = new Label();
            lblEditAnimeGenre = new Label();
            lblAnimeEditAnimeTitle = new Label();
            lblEditAnime = new Label();
            panelAddAnime = new Panel();
            checklistboxAddAnimeGenre = new CheckedListBox();
            label13 = new Label();
            bttnAddAnimeSave = new Button();
            txtBoxAddAnimeReleaseYear = new TextBox();
            txtBoxAddAnimeTitle = new TextBox();
            lblAddAnimeReleaseYear = new Label();
            lblAddAnimeGenre = new Label();
            lblAddAnimeTitle = new Label();
            lblAddAnime = new Label();
            bttnAddAnimeCancel = new Button();
            lblAdd = new Label();
            bttnViewAllAnime = new Button();
            label1 = new Label();
            bttnViewPending = new Button();
            bttnViewFinished = new Button();
            label2 = new Label();
            label3 = new Label();
            lblAllAnimeCount = new Label();
            lblToWatchAnimeCount = new Label();
            lblWatchedAnimeCount = new Label();
            dataGridAllAnime = new DataGridView();
            panel2 = new Panel();
            bttnAdd = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bttnManageAccount).BeginInit();
            panelDim.SuspendLayout();
            panelManageAccount.SuspendLayout();
            panelEditWatched.SuspendLayout();
            panelEditToWatch.SuspendLayout();
            panelAddAnime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAllAnime).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 170, 158);
            panel1.Controls.Add(lblUserName);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(bttnManageAccount);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1280, 90);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Trebuchet MS", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(796, 25);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(192, 43);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "User Name";
            lblUserName.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.AnimeLogo_NOCircleGreenBG;
            pictureBox2.Location = new Point(25, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(309, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // bttnManageAccount
            // 
            bttnManageAccount.AccessibleName = "bttnManageAccount";
            bttnManageAccount.Image = Properties.Resources.UserMenu;
            bttnManageAccount.Location = new Point(1169, 21);
            bttnManageAccount.Name = "bttnManageAccount";
            bttnManageAccount.Size = new Size(50, 50);
            bttnManageAccount.SizeMode = PictureBoxSizeMode.StretchImage;
            bttnManageAccount.TabIndex = 1;
            bttnManageAccount.TabStop = false;
            bttnManageAccount.Click += pictureBox1_Click;
            // 
            // panelDim
            // 
            panelDim.BackColor = Color.Transparent;
            panelDim.Controls.Add(panelManageAccount);
            panelDim.Controls.Add(panelEditWatched);
            panelDim.Controls.Add(panelEditToWatch);
            panelDim.Controls.Add(panelAddAnime);
            panelDim.Location = new Point(0, 88);
            panelDim.Name = "panelDim";
            panelDim.Size = new Size(1280, 706);
            panelDim.TabIndex = 4;
            panelDim.Visible = false;
            // 
            // panelManageAccount
            // 
            panelManageAccount.BackgroundImage = (Image)resources.GetObject("panelManageAccount.BackgroundImage");
            panelManageAccount.Controls.Add(button2);
            panelManageAccount.Controls.Add(button1);
            panelManageAccount.Controls.Add(bttnEditAccountPassword);
            panelManageAccount.Controls.Add(bttnEditAccountEmail);
            panelManageAccount.Controls.Add(bttnEditAccountName);
            panelManageAccount.Controls.Add(bttnDeleteAccount);
            panelManageAccount.Controls.Add(bttnLogOut);
            panelManageAccount.Controls.Add(txtBoxAccountPassword);
            panelManageAccount.Controls.Add(txtBoxAccountEmail);
            panelManageAccount.Controls.Add(txtBoxAccountName);
            panelManageAccount.Controls.Add(lblPassword);
            panelManageAccount.Controls.Add(lblEmail);
            panelManageAccount.Controls.Add(lblName);
            panelManageAccount.Controls.Add(lblManageAccount);
            panelManageAccount.Location = new Point(988, 3);
            panelManageAccount.Name = "panelManageAccount";
            panelManageAccount.Size = new Size(485, 535);
            panelManageAccount.TabIndex = 21;
            panelManageAccount.Visible = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(102, 210, 206);
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(433, 17);
            button2.Name = "button2";
            button2.Size = new Size(30, 30);
            button2.TabIndex = 15;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(102, 210, 206);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(363, 335);
            button1.Name = "button1";
            button1.Size = new Size(37, 37);
            button1.TabIndex = 14;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_2;
            // 
            // bttnEditAccountPassword
            // 
            bttnEditAccountPassword.BackColor = Color.FromArgb(102, 210, 206);
            bttnEditAccountPassword.FlatAppearance.BorderColor = Color.White;
            bttnEditAccountPassword.FlatStyle = FlatStyle.Flat;
            bttnEditAccountPassword.ForeColor = Color.Black;
            bttnEditAccountPassword.Location = new Point(399, 335);
            bttnEditAccountPassword.Name = "bttnEditAccountPassword";
            bttnEditAccountPassword.Size = new Size(37, 37);
            bttnEditAccountPassword.TabIndex = 13;
            bttnEditAccountPassword.Text = "✏️";
            bttnEditAccountPassword.UseVisualStyleBackColor = false;
            // 
            // bttnEditAccountEmail
            // 
            bttnEditAccountEmail.BackColor = Color.FromArgb(102, 210, 206);
            bttnEditAccountEmail.FlatAppearance.BorderColor = Color.White;
            bttnEditAccountEmail.FlatStyle = FlatStyle.Flat;
            bttnEditAccountEmail.ForeColor = Color.Black;
            bttnEditAccountEmail.Location = new Point(399, 231);
            bttnEditAccountEmail.Name = "bttnEditAccountEmail";
            bttnEditAccountEmail.Size = new Size(37, 37);
            bttnEditAccountEmail.TabIndex = 12;
            bttnEditAccountEmail.Text = "✏️";
            bttnEditAccountEmail.UseVisualStyleBackColor = false;
            // 
            // bttnEditAccountName
            // 
            bttnEditAccountName.BackColor = Color.FromArgb(102, 210, 206);
            bttnEditAccountName.FlatAppearance.BorderColor = Color.White;
            bttnEditAccountName.FlatStyle = FlatStyle.Flat;
            bttnEditAccountName.ForeColor = Color.Black;
            bttnEditAccountName.Location = new Point(400, 132);
            bttnEditAccountName.Name = "bttnEditAccountName";
            bttnEditAccountName.Size = new Size(37, 37);
            bttnEditAccountName.TabIndex = 11;
            bttnEditAccountName.Text = "✏️";
            bttnEditAccountName.UseVisualStyleBackColor = false;
            // 
            // bttnDeleteAccount
            // 
            bttnDeleteAccount.BackColor = Color.Transparent;
            bttnDeleteAccount.FlatAppearance.BorderSize = 0;
            bttnDeleteAccount.FlatStyle = FlatStyle.Flat;
            bttnDeleteAccount.Font = new Font("Trebuchet MS", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnDeleteAccount.ForeColor = Color.FromArgb(45, 170, 158);
            bttnDeleteAccount.Location = new Point(171, 459);
            bttnDeleteAccount.Name = "bttnDeleteAccount";
            bttnDeleteAccount.Size = new Size(143, 50);
            bttnDeleteAccount.TabIndex = 10;
            bttnDeleteAccount.TabStop = false;
            bttnDeleteAccount.Text = "Delete Account";
            bttnDeleteAccount.UseVisualStyleBackColor = false;
            // 
            // bttnLogOut
            // 
            bttnLogOut.BackColor = Color.FromArgb(102, 210, 206);
            bttnLogOut.FlatAppearance.BorderSize = 0;
            bttnLogOut.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnLogOut.ForeColor = Color.White;
            bttnLogOut.Location = new Point(183, 406);
            bttnLogOut.Name = "bttnLogOut";
            bttnLogOut.Size = new Size(118, 50);
            bttnLogOut.TabIndex = 8;
            bttnLogOut.TabStop = false;
            bttnLogOut.Text = "Log Out";
            bttnLogOut.UseVisualStyleBackColor = false;
            bttnLogOut.Click += button4_Click;
            // 
            // txtBoxAccountPassword
            // 
            txtBoxAccountPassword.BackColor = Color.Silver;
            txtBoxAccountPassword.Enabled = false;
            txtBoxAccountPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxAccountPassword.Location = new Point(54, 334);
            txtBoxAccountPassword.Name = "txtBoxAccountPassword";
            txtBoxAccountPassword.ReadOnly = true;
            txtBoxAccountPassword.Size = new Size(310, 38);
            txtBoxAccountPassword.TabIndex = 6;
            txtBoxAccountPassword.UseSystemPasswordChar = true;
            // 
            // txtBoxAccountEmail
            // 
            txtBoxAccountEmail.BackColor = Color.Silver;
            txtBoxAccountEmail.Enabled = false;
            txtBoxAccountEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxAccountEmail.Location = new Point(54, 230);
            txtBoxAccountEmail.Name = "txtBoxAccountEmail";
            txtBoxAccountEmail.ReadOnly = true;
            txtBoxAccountEmail.Size = new Size(346, 38);
            txtBoxAccountEmail.TabIndex = 5;
            // 
            // txtBoxAccountName
            // 
            txtBoxAccountName.BackColor = Color.Silver;
            txtBoxAccountName.Enabled = false;
            txtBoxAccountName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxAccountName.Location = new Point(54, 131);
            txtBoxAccountName.Name = "txtBoxAccountName";
            txtBoxAccountName.ReadOnly = true;
            txtBoxAccountName.Size = new Size(346, 38);
            txtBoxAccountName.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(45, 170, 158);
            lblPassword.Location = new Point(54, 304);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(105, 27);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(45, 170, 158);
            lblEmail.Location = new Point(54, 200);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(65, 27);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(45, 170, 158);
            lblName.Location = new Point(54, 101);
            lblName.Name = "lblName";
            lblName.Size = new Size(69, 27);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblManageAccount
            // 
            lblManageAccount.AutoSize = true;
            lblManageAccount.BackColor = Color.Transparent;
            lblManageAccount.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageAccount.ForeColor = Color.White;
            lblManageAccount.Location = new Point(14, 13);
            lblManageAccount.Name = "lblManageAccount";
            lblManageAccount.Size = new Size(280, 38);
            lblManageAccount.TabIndex = 0;
            lblManageAccount.Text = "👤‍Manage Account";
            // 
            // panelEditWatched
            // 
            panelEditWatched.BackgroundImage = (Image)resources.GetObject("panelEditWatched.BackgroundImage");
            panelEditWatched.Controls.Add(txtBoxEditWatchedRatings);
            panelEditWatched.Controls.Add(lblEditWatchedRatings);
            panelEditWatched.Controls.Add(txtBoxEditWatchedDateAndTime);
            panelEditWatched.Controls.Add(lblEditWatchedDateAndTime);
            panelEditWatched.Controls.Add(lblEditWatchedDelete);
            panelEditWatched.Controls.Add(lblEditWatchedCancel);
            panelEditWatched.Controls.Add(lblEditWatchedUnWatched);
            panelEditWatched.Controls.Add(lblEditWatchedMarkAs);
            panelEditWatched.Controls.Add(bttnEditWatchedMarkAsUnWatched);
            panelEditWatched.Controls.Add(bttnEditWatchedDelete);
            panelEditWatched.Controls.Add(bttnEditWatchedCancel);
            panelEditWatched.Controls.Add(bttnEditWatchedSave);
            panelEditWatched.Controls.Add(txtBoxEditWatchedReleaseYear);
            panelEditWatched.Controls.Add(txtBoxEditWatchedGenre);
            panelEditWatched.Controls.Add(txtBoxEditWatchedTitle);
            panelEditWatched.Controls.Add(lblEditWatchedReleaseYear);
            panelEditWatched.Controls.Add(lblEditWatchedGenre);
            panelEditWatched.Controls.Add(lblEditWatchedTitle);
            panelEditWatched.Controls.Add(lblEditWatched);
            panelEditWatched.Location = new Point(507, 20);
            panelEditWatched.Name = "panelEditWatched";
            panelEditWatched.Size = new Size(485, 535);
            panelEditWatched.TabIndex = 17;
            panelEditWatched.Visible = false;
            panelEditWatched.Paint += panel3_Paint;
            // 
            // txtBoxEditWatchedRatings
            // 
            txtBoxEditWatchedRatings.BackColor = Color.Silver;
            txtBoxEditWatchedRatings.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditWatchedRatings.Location = new Point(56, 381);
            txtBoxEditWatchedRatings.Name = "txtBoxEditWatchedRatings";
            txtBoxEditWatchedRatings.Size = new Size(382, 38);
            txtBoxEditWatchedRatings.TabIndex = 20;
            // 
            // lblEditWatchedRatings
            // 
            lblEditWatchedRatings.AutoSize = true;
            lblEditWatchedRatings.BackColor = Color.Transparent;
            lblEditWatchedRatings.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditWatchedRatings.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditWatchedRatings.Location = new Point(56, 351);
            lblEditWatchedRatings.Name = "lblEditWatchedRatings";
            lblEditWatchedRatings.Size = new Size(83, 27);
            lblEditWatchedRatings.TabIndex = 19;
            lblEditWatchedRatings.Text = "Ratings";
            // 
            // txtBoxEditWatchedDateAndTime
            // 
            txtBoxEditWatchedDateAndTime.BackColor = Color.Silver;
            txtBoxEditWatchedDateAndTime.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditWatchedDateAndTime.Location = new Point(54, 313);
            txtBoxEditWatchedDateAndTime.Name = "txtBoxEditWatchedDateAndTime";
            txtBoxEditWatchedDateAndTime.Size = new Size(382, 38);
            txtBoxEditWatchedDateAndTime.TabIndex = 18;
            // 
            // lblEditWatchedDateAndTime
            // 
            lblEditWatchedDateAndTime.AutoSize = true;
            lblEditWatchedDateAndTime.BackColor = Color.Transparent;
            lblEditWatchedDateAndTime.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditWatchedDateAndTime.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditWatchedDateAndTime.Location = new Point(54, 283);
            lblEditWatchedDateAndTime.Name = "lblEditWatchedDateAndTime";
            lblEditWatchedDateAndTime.Size = new Size(154, 27);
            lblEditWatchedDateAndTime.TabIndex = 17;
            lblEditWatchedDateAndTime.Text = "Date And Time";
            // 
            // lblEditWatchedDelete
            // 
            lblEditWatchedDelete.AutoSize = true;
            lblEditWatchedDelete.BackColor = Color.Transparent;
            lblEditWatchedDelete.ForeColor = SystemColors.ControlDarkDark;
            lblEditWatchedDelete.Location = new Point(205, 481);
            lblEditWatchedDelete.Name = "lblEditWatchedDelete";
            lblEditWatchedDelete.Size = new Size(53, 20);
            lblEditWatchedDelete.TabIndex = 16;
            lblEditWatchedDelete.Text = "Delete";
            // 
            // lblEditWatchedCancel
            // 
            lblEditWatchedCancel.AutoSize = true;
            lblEditWatchedCancel.BackColor = Color.Transparent;
            lblEditWatchedCancel.ForeColor = SystemColors.ControlDarkDark;
            lblEditWatchedCancel.Location = new Point(386, 481);
            lblEditWatchedCancel.Name = "lblEditWatchedCancel";
            lblEditWatchedCancel.Size = new Size(53, 20);
            lblEditWatchedCancel.TabIndex = 15;
            lblEditWatchedCancel.Text = "Cancel";
            // 
            // lblEditWatchedUnWatched
            // 
            lblEditWatchedUnWatched.AutoSize = true;
            lblEditWatchedUnWatched.BackColor = Color.Transparent;
            lblEditWatchedUnWatched.ForeColor = SystemColors.ControlDarkDark;
            lblEditWatchedUnWatched.Location = new Point(279, 499);
            lblEditWatchedUnWatched.Name = "lblEditWatchedUnWatched";
            lblEditWatchedUnWatched.Size = new Size(85, 20);
            lblEditWatchedUnWatched.TabIndex = 14;
            lblEditWatchedUnWatched.Text = "UnWatched";
            // 
            // lblEditWatchedMarkAs
            // 
            lblEditWatchedMarkAs.AutoSize = true;
            lblEditWatchedMarkAs.BackColor = Color.Transparent;
            lblEditWatchedMarkAs.ForeColor = SystemColors.ControlDarkDark;
            lblEditWatchedMarkAs.Location = new Point(290, 479);
            lblEditWatchedMarkAs.Name = "lblEditWatchedMarkAs";
            lblEditWatchedMarkAs.Size = new Size(62, 20);
            lblEditWatchedMarkAs.TabIndex = 13;
            lblEditWatchedMarkAs.Text = "Mark As";
            // 
            // bttnEditWatchedMarkAsUnWatched
            // 
            bttnEditWatchedMarkAsUnWatched.BackColor = Color.Transparent;
            bttnEditWatchedMarkAsUnWatched.BackgroundImage = (Image)resources.GetObject("bttnEditWatchedMarkAsUnWatched.BackgroundImage");
            bttnEditWatchedMarkAsUnWatched.BackgroundImageLayout = ImageLayout.Stretch;
            bttnEditWatchedMarkAsUnWatched.FlatAppearance.BorderSize = 0;
            bttnEditWatchedMarkAsUnWatched.FlatStyle = FlatStyle.Flat;
            bttnEditWatchedMarkAsUnWatched.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditWatchedMarkAsUnWatched.Location = new Point(303, 450);
            bttnEditWatchedMarkAsUnWatched.Name = "bttnEditWatchedMarkAsUnWatched";
            bttnEditWatchedMarkAsUnWatched.Size = new Size(30, 30);
            bttnEditWatchedMarkAsUnWatched.TabIndex = 11;
            bttnEditWatchedMarkAsUnWatched.TabStop = false;
            bttnEditWatchedMarkAsUnWatched.UseVisualStyleBackColor = true;
            bttnEditWatchedMarkAsUnWatched.Click += bttnEditWatchedMarkAsUnWatched_Click;
            // 
            // bttnEditWatchedDelete
            // 
            bttnEditWatchedDelete.BackColor = Color.Transparent;
            bttnEditWatchedDelete.FlatAppearance.BorderSize = 0;
            bttnEditWatchedDelete.FlatStyle = FlatStyle.Flat;
            bttnEditWatchedDelete.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditWatchedDelete.Location = new Point(206, 439);
            bttnEditWatchedDelete.Name = "bttnEditWatchedDelete";
            bttnEditWatchedDelete.Size = new Size(50, 50);
            bttnEditWatchedDelete.TabIndex = 10;
            bttnEditWatchedDelete.TabStop = false;
            bttnEditWatchedDelete.Text = "🗑️";
            bttnEditWatchedDelete.UseVisualStyleBackColor = false;
            bttnEditWatchedDelete.Click += bttnEditWatchedDelete_Click;
            // 
            // bttnEditWatchedCancel
            // 
            bttnEditWatchedCancel.BackColor = Color.Transparent;
            bttnEditWatchedCancel.FlatAppearance.BorderSize = 0;
            bttnEditWatchedCancel.FlatStyle = FlatStyle.Flat;
            bttnEditWatchedCancel.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditWatchedCancel.Location = new Point(388, 439);
            bttnEditWatchedCancel.Name = "bttnEditWatchedCancel";
            bttnEditWatchedCancel.Size = new Size(50, 50);
            bttnEditWatchedCancel.TabIndex = 9;
            bttnEditWatchedCancel.TabStop = false;
            bttnEditWatchedCancel.Text = "✖";
            bttnEditWatchedCancel.UseVisualStyleBackColor = false;
            bttnEditWatchedCancel.Click += bttnEditWatchedCancel_Click;
            // 
            // bttnEditWatchedSave
            // 
            bttnEditWatchedSave.BackColor = Color.FromArgb(102, 210, 206);
            bttnEditWatchedSave.FlatAppearance.BorderSize = 0;
            bttnEditWatchedSave.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditWatchedSave.ForeColor = Color.White;
            bttnEditWatchedSave.Location = new Point(54, 439);
            bttnEditWatchedSave.Name = "bttnEditWatchedSave";
            bttnEditWatchedSave.Size = new Size(118, 50);
            bttnEditWatchedSave.TabIndex = 8;
            bttnEditWatchedSave.TabStop = false;
            bttnEditWatchedSave.Text = "Save";
            bttnEditWatchedSave.UseVisualStyleBackColor = false;
            bttnEditWatchedSave.Click += bttnEditWatchedSave_Click;
            // 
            // txtBoxEditWatchedReleaseYear
            // 
            txtBoxEditWatchedReleaseYear.BackColor = Color.Silver;
            txtBoxEditWatchedReleaseYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditWatchedReleaseYear.Location = new Point(54, 243);
            txtBoxEditWatchedReleaseYear.Name = "txtBoxEditWatchedReleaseYear";
            txtBoxEditWatchedReleaseYear.Size = new Size(382, 38);
            txtBoxEditWatchedReleaseYear.TabIndex = 6;
            // 
            // txtBoxEditWatchedGenre
            // 
            txtBoxEditWatchedGenre.BackColor = Color.Silver;
            txtBoxEditWatchedGenre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditWatchedGenre.Location = new Point(54, 172);
            txtBoxEditWatchedGenre.Name = "txtBoxEditWatchedGenre";
            txtBoxEditWatchedGenre.Size = new Size(382, 38);
            txtBoxEditWatchedGenre.TabIndex = 5;
            // 
            // txtBoxEditWatchedTitle
            // 
            txtBoxEditWatchedTitle.BackColor = Color.Silver;
            txtBoxEditWatchedTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditWatchedTitle.Location = new Point(54, 101);
            txtBoxEditWatchedTitle.Name = "txtBoxEditWatchedTitle";
            txtBoxEditWatchedTitle.Size = new Size(382, 38);
            txtBoxEditWatchedTitle.TabIndex = 4;
            // 
            // lblEditWatchedReleaseYear
            // 
            lblEditWatchedReleaseYear.AutoSize = true;
            lblEditWatchedReleaseYear.BackColor = Color.Transparent;
            lblEditWatchedReleaseYear.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditWatchedReleaseYear.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditWatchedReleaseYear.Location = new Point(54, 213);
            lblEditWatchedReleaseYear.Name = "lblEditWatchedReleaseYear";
            lblEditWatchedReleaseYear.Size = new Size(135, 27);
            lblEditWatchedReleaseYear.TabIndex = 3;
            lblEditWatchedReleaseYear.Text = "Release Year";
            lblEditWatchedReleaseYear.Click += lblEditWatchedReleaseYear_Click;
            // 
            // lblEditWatchedGenre
            // 
            lblEditWatchedGenre.AutoSize = true;
            lblEditWatchedGenre.BackColor = Color.Transparent;
            lblEditWatchedGenre.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditWatchedGenre.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditWatchedGenre.Location = new Point(54, 142);
            lblEditWatchedGenre.Name = "lblEditWatchedGenre";
            lblEditWatchedGenre.Size = new Size(69, 27);
            lblEditWatchedGenre.TabIndex = 2;
            lblEditWatchedGenre.Text = "Genre";
            // 
            // lblEditWatchedTitle
            // 
            lblEditWatchedTitle.AutoSize = true;
            lblEditWatchedTitle.BackColor = Color.Transparent;
            lblEditWatchedTitle.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditWatchedTitle.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditWatchedTitle.Location = new Point(54, 71);
            lblEditWatchedTitle.Name = "lblEditWatchedTitle";
            lblEditWatchedTitle.Size = new Size(52, 27);
            lblEditWatchedTitle.TabIndex = 1;
            lblEditWatchedTitle.Text = "Title";
            // 
            // lblEditWatched
            // 
            lblEditWatched.AutoSize = true;
            lblEditWatched.BackColor = Color.Transparent;
            lblEditWatched.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditWatched.ForeColor = Color.White;
            lblEditWatched.Location = new Point(14, 13);
            lblEditWatched.Name = "lblEditWatched";
            lblEditWatched.Size = new Size(169, 38);
            lblEditWatched.TabIndex = 0;
            lblEditWatched.Text = "Edit Anime";
            // 
            // panelEditToWatch
            // 
            panelEditToWatch.BackgroundImage = (Image)resources.GetObject("panelEditToWatch.BackgroundImage");
            panelEditToWatch.Controls.Add(lblEditAnimeDelete);
            panelEditToWatch.Controls.Add(lblEditAnimeCancel);
            panelEditToWatch.Controls.Add(lblEditAnimeWatched);
            panelEditToWatch.Controls.Add(lblEditAnimeMarkAs);
            panelEditToWatch.Controls.Add(bttnEditAnimeMarkAsWatched);
            panelEditToWatch.Controls.Add(bttnEditAnimeDelete);
            panelEditToWatch.Controls.Add(bttnEditAnimeCancel);
            panelEditToWatch.Controls.Add(bttnEditAnimeSave);
            panelEditToWatch.Controls.Add(txtBoxEditAnimeReleaseYear);
            panelEditToWatch.Controls.Add(txtBoxEditAnimeGenre);
            panelEditToWatch.Controls.Add(txtBoxEditAnimeTitle);
            panelEditToWatch.Controls.Add(lblEditAnimeReleaseYear);
            panelEditToWatch.Controls.Add(lblEditAnimeGenre);
            panelEditToWatch.Controls.Add(lblAnimeEditAnimeTitle);
            panelEditToWatch.Controls.Add(lblEditAnime);
            panelEditToWatch.Location = new Point(920, 32);
            panelEditToWatch.Name = "panelEditToWatch";
            panelEditToWatch.Size = new Size(485, 535);
            panelEditToWatch.TabIndex = 1;
            panelEditToWatch.Visible = false;
            // 
            // lblEditAnimeDelete
            // 
            lblEditAnimeDelete.AutoSize = true;
            lblEditAnimeDelete.BackColor = Color.Transparent;
            lblEditAnimeDelete.ForeColor = SystemColors.ControlDarkDark;
            lblEditAnimeDelete.Location = new Point(205, 467);
            lblEditAnimeDelete.Name = "lblEditAnimeDelete";
            lblEditAnimeDelete.Size = new Size(53, 20);
            lblEditAnimeDelete.TabIndex = 16;
            lblEditAnimeDelete.Text = "Delete";
            // 
            // lblEditAnimeCancel
            // 
            lblEditAnimeCancel.AutoSize = true;
            lblEditAnimeCancel.BackColor = Color.Transparent;
            lblEditAnimeCancel.ForeColor = SystemColors.ControlDarkDark;
            lblEditAnimeCancel.Location = new Point(386, 467);
            lblEditAnimeCancel.Name = "lblEditAnimeCancel";
            lblEditAnimeCancel.Size = new Size(53, 20);
            lblEditAnimeCancel.TabIndex = 15;
            lblEditAnimeCancel.Text = "Cancel";
            lblEditAnimeCancel.Click += label7_Click;
            // 
            // lblEditAnimeWatched
            // 
            lblEditAnimeWatched.AutoSize = true;
            lblEditAnimeWatched.BackColor = Color.Transparent;
            lblEditAnimeWatched.ForeColor = SystemColors.ControlDarkDark;
            lblEditAnimeWatched.Location = new Point(288, 485);
            lblEditAnimeWatched.Name = "lblEditAnimeWatched";
            lblEditAnimeWatched.Size = new Size(67, 20);
            lblEditAnimeWatched.TabIndex = 14;
            lblEditAnimeWatched.Text = "Watched";
            // 
            // lblEditAnimeMarkAs
            // 
            lblEditAnimeMarkAs.AutoSize = true;
            lblEditAnimeMarkAs.BackColor = Color.Transparent;
            lblEditAnimeMarkAs.ForeColor = SystemColors.ControlDarkDark;
            lblEditAnimeMarkAs.Location = new Point(290, 465);
            lblEditAnimeMarkAs.Name = "lblEditAnimeMarkAs";
            lblEditAnimeMarkAs.Size = new Size(62, 20);
            lblEditAnimeMarkAs.TabIndex = 13;
            lblEditAnimeMarkAs.Text = "Mark As";
            // 
            // bttnEditAnimeMarkAsWatched
            // 
            bttnEditAnimeMarkAsWatched.BackColor = Color.Transparent;
            bttnEditAnimeMarkAsWatched.FlatAppearance.BorderSize = 0;
            bttnEditAnimeMarkAsWatched.FlatStyle = FlatStyle.Flat;
            bttnEditAnimeMarkAsWatched.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditAnimeMarkAsWatched.Location = new Point(298, 425);
            bttnEditAnimeMarkAsWatched.Name = "bttnEditAnimeMarkAsWatched";
            bttnEditAnimeMarkAsWatched.Size = new Size(50, 50);
            bttnEditAnimeMarkAsWatched.TabIndex = 11;
            bttnEditAnimeMarkAsWatched.Text = "▶";
            bttnEditAnimeMarkAsWatched.UseVisualStyleBackColor = false;
            bttnEditAnimeMarkAsWatched.Click += bttnEditAnimeMarkAsWatched_Click;
            // 
            // bttnEditAnimeDelete
            // 
            bttnEditAnimeDelete.BackColor = Color.Transparent;
            bttnEditAnimeDelete.FlatAppearance.BorderSize = 0;
            bttnEditAnimeDelete.FlatStyle = FlatStyle.Flat;
            bttnEditAnimeDelete.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditAnimeDelete.Location = new Point(206, 425);
            bttnEditAnimeDelete.Name = "bttnEditAnimeDelete";
            bttnEditAnimeDelete.Size = new Size(50, 50);
            bttnEditAnimeDelete.TabIndex = 10;
            bttnEditAnimeDelete.Text = "🗑️";
            bttnEditAnimeDelete.UseVisualStyleBackColor = false;
            bttnEditAnimeDelete.Click += bttnDelete_Click;
            // 
            // bttnEditAnimeCancel
            // 
            bttnEditAnimeCancel.BackColor = Color.Transparent;
            bttnEditAnimeCancel.FlatAppearance.BorderSize = 0;
            bttnEditAnimeCancel.FlatStyle = FlatStyle.Flat;
            bttnEditAnimeCancel.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditAnimeCancel.Location = new Point(388, 425);
            bttnEditAnimeCancel.Name = "bttnEditAnimeCancel";
            bttnEditAnimeCancel.Size = new Size(50, 50);
            bttnEditAnimeCancel.TabIndex = 9;
            bttnEditAnimeCancel.Text = "✖";
            bttnEditAnimeCancel.UseVisualStyleBackColor = false;
            bttnEditAnimeCancel.Click += bttnCancel_Click;
            // 
            // bttnEditAnimeSave
            // 
            bttnEditAnimeSave.BackColor = Color.FromArgb(102, 210, 206);
            bttnEditAnimeSave.FlatAppearance.BorderSize = 0;
            bttnEditAnimeSave.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnEditAnimeSave.ForeColor = Color.White;
            bttnEditAnimeSave.Location = new Point(54, 425);
            bttnEditAnimeSave.Name = "bttnEditAnimeSave";
            bttnEditAnimeSave.Size = new Size(118, 50);
            bttnEditAnimeSave.TabIndex = 8;
            bttnEditAnimeSave.Text = "Save";
            bttnEditAnimeSave.UseVisualStyleBackColor = false;
            bttnEditAnimeSave.Click += bttnSave_Click;
            // 
            // txtBoxEditAnimeReleaseYear
            // 
            txtBoxEditAnimeReleaseYear.BackColor = Color.Silver;
            txtBoxEditAnimeReleaseYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditAnimeReleaseYear.Location = new Point(54, 334);
            txtBoxEditAnimeReleaseYear.Name = "txtBoxEditAnimeReleaseYear";
            txtBoxEditAnimeReleaseYear.Size = new Size(382, 38);
            txtBoxEditAnimeReleaseYear.TabIndex = 6;
            // 
            // txtBoxEditAnimeGenre
            // 
            txtBoxEditAnimeGenre.BackColor = Color.Silver;
            txtBoxEditAnimeGenre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditAnimeGenre.Location = new Point(54, 230);
            txtBoxEditAnimeGenre.Name = "txtBoxEditAnimeGenre";
            txtBoxEditAnimeGenre.Size = new Size(382, 38);
            txtBoxEditAnimeGenre.TabIndex = 5;
            // 
            // txtBoxEditAnimeTitle
            // 
            txtBoxEditAnimeTitle.BackColor = Color.Silver;
            txtBoxEditAnimeTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEditAnimeTitle.Location = new Point(54, 128);
            txtBoxEditAnimeTitle.Name = "txtBoxEditAnimeTitle";
            txtBoxEditAnimeTitle.Size = new Size(382, 38);
            txtBoxEditAnimeTitle.TabIndex = 4;
            // 
            // lblEditAnimeReleaseYear
            // 
            lblEditAnimeReleaseYear.AutoSize = true;
            lblEditAnimeReleaseYear.BackColor = Color.Transparent;
            lblEditAnimeReleaseYear.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditAnimeReleaseYear.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditAnimeReleaseYear.Location = new Point(54, 304);
            lblEditAnimeReleaseYear.Name = "lblEditAnimeReleaseYear";
            lblEditAnimeReleaseYear.Size = new Size(135, 27);
            lblEditAnimeReleaseYear.TabIndex = 3;
            lblEditAnimeReleaseYear.Text = "Release Year";
            // 
            // lblEditAnimeGenre
            // 
            lblEditAnimeGenre.AutoSize = true;
            lblEditAnimeGenre.BackColor = Color.Transparent;
            lblEditAnimeGenre.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditAnimeGenre.ForeColor = Color.FromArgb(45, 170, 158);
            lblEditAnimeGenre.Location = new Point(54, 200);
            lblEditAnimeGenre.Name = "lblEditAnimeGenre";
            lblEditAnimeGenre.Size = new Size(69, 27);
            lblEditAnimeGenre.TabIndex = 2;
            lblEditAnimeGenre.Text = "Genre";
            // 
            // lblAnimeEditAnimeTitle
            // 
            lblAnimeEditAnimeTitle.AutoSize = true;
            lblAnimeEditAnimeTitle.BackColor = Color.Transparent;
            lblAnimeEditAnimeTitle.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAnimeEditAnimeTitle.ForeColor = Color.FromArgb(45, 170, 158);
            lblAnimeEditAnimeTitle.Location = new Point(54, 98);
            lblAnimeEditAnimeTitle.Name = "lblAnimeEditAnimeTitle";
            lblAnimeEditAnimeTitle.Size = new Size(52, 27);
            lblAnimeEditAnimeTitle.TabIndex = 1;
            lblAnimeEditAnimeTitle.Text = "Title";
            // 
            // lblEditAnime
            // 
            lblEditAnime.AutoSize = true;
            lblEditAnime.BackColor = Color.Transparent;
            lblEditAnime.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditAnime.ForeColor = Color.White;
            lblEditAnime.Location = new Point(14, 13);
            lblEditAnime.Name = "lblEditAnime";
            lblEditAnime.Size = new Size(169, 38);
            lblEditAnime.TabIndex = 0;
            lblEditAnime.Text = "Edit Anime";
            // 
            // panelAddAnime
            // 
            panelAddAnime.BackgroundImage = (Image)resources.GetObject("panelAddAnime.BackgroundImage");
            panelAddAnime.Controls.Add(checklistboxAddAnimeGenre);
            panelAddAnime.Controls.Add(label13);
            panelAddAnime.Controls.Add(bttnAddAnimeSave);
            panelAddAnime.Controls.Add(txtBoxAddAnimeReleaseYear);
            panelAddAnime.Controls.Add(txtBoxAddAnimeTitle);
            panelAddAnime.Controls.Add(lblAddAnimeReleaseYear);
            panelAddAnime.Controls.Add(lblAddAnimeGenre);
            panelAddAnime.Controls.Add(lblAddAnimeTitle);
            panelAddAnime.Controls.Add(lblAddAnime);
            panelAddAnime.Controls.Add(bttnAddAnimeCancel);
            panelAddAnime.Font = new Font("Segoe UI", 13.8F);
            panelAddAnime.Location = new Point(12, 20);
            panelAddAnime.Name = "panelAddAnime";
            panelAddAnime.Size = new Size(485, 535);
            panelAddAnime.TabIndex = 16;
            panelAddAnime.Visible = false;
            // 
            // checklistboxAddAnimeGenre
            // 
            checklistboxAddAnimeGenre.BackColor = Color.Silver;
            checklistboxAddAnimeGenre.FormattingEnabled = true;
            checklistboxAddAnimeGenre.Items.AddRange(new object[] { "Action", "Adventure", "Comedy", "Drama", "Fantasy", "Supernatural", "Romance", "Slice of Life", "Sci-Fi", "Mystery", "Psychological", "Horror", "Sports", "Music", "Isekai" });
            checklistboxAddAnimeGenre.Location = new Point(57, 210);
            checklistboxAddAnimeGenre.Name = "checklistboxAddAnimeGenre";
            checklistboxAddAnimeGenre.Size = new Size(379, 103);
            checklistboxAddAnimeGenre.TabIndex = 19;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.ForeColor = SystemColors.ControlDarkDark;
            label13.Location = new Point(203, 456);
            label13.Name = "label13";
            label13.Size = new Size(0, 31);
            label13.TabIndex = 16;
            // 
            // bttnAddAnimeSave
            // 
            bttnAddAnimeSave.BackColor = Color.FromArgb(102, 210, 206);
            bttnAddAnimeSave.FlatAppearance.BorderSize = 0;
            bttnAddAnimeSave.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnAddAnimeSave.ForeColor = Color.White;
            bttnAddAnimeSave.Location = new Point(318, 447);
            bttnAddAnimeSave.Name = "bttnAddAnimeSave";
            bttnAddAnimeSave.Size = new Size(118, 50);
            bttnAddAnimeSave.TabIndex = 8;
            bttnAddAnimeSave.Text = "Save";
            bttnAddAnimeSave.UseVisualStyleBackColor = false;
            bttnAddAnimeSave.Click += bttnAddAnimeSave_Click;
            // 
            // txtBoxAddAnimeReleaseYear
            // 
            txtBoxAddAnimeReleaseYear.BackColor = Color.Silver;
            txtBoxAddAnimeReleaseYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxAddAnimeReleaseYear.Location = new Point(54, 355);
            txtBoxAddAnimeReleaseYear.Name = "txtBoxAddAnimeReleaseYear";
            txtBoxAddAnimeReleaseYear.Size = new Size(382, 38);
            txtBoxAddAnimeReleaseYear.TabIndex = 6;
            // 
            // txtBoxAddAnimeTitle
            // 
            txtBoxAddAnimeTitle.BackColor = Color.Silver;
            txtBoxAddAnimeTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxAddAnimeTitle.Location = new Point(54, 111);
            txtBoxAddAnimeTitle.Name = "txtBoxAddAnimeTitle";
            txtBoxAddAnimeTitle.Size = new Size(382, 38);
            txtBoxAddAnimeTitle.TabIndex = 4;
            // 
            // lblAddAnimeReleaseYear
            // 
            lblAddAnimeReleaseYear.AutoSize = true;
            lblAddAnimeReleaseYear.BackColor = Color.Transparent;
            lblAddAnimeReleaseYear.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddAnimeReleaseYear.ForeColor = Color.FromArgb(45, 170, 158);
            lblAddAnimeReleaseYear.Location = new Point(54, 325);
            lblAddAnimeReleaseYear.Name = "lblAddAnimeReleaseYear";
            lblAddAnimeReleaseYear.Size = new Size(135, 27);
            lblAddAnimeReleaseYear.TabIndex = 3;
            lblAddAnimeReleaseYear.Text = "Release Year";
            // 
            // lblAddAnimeGenre
            // 
            lblAddAnimeGenre.AutoSize = true;
            lblAddAnimeGenre.BackColor = Color.Transparent;
            lblAddAnimeGenre.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddAnimeGenre.ForeColor = Color.FromArgb(45, 170, 158);
            lblAddAnimeGenre.Location = new Point(54, 167);
            lblAddAnimeGenre.Name = "lblAddAnimeGenre";
            lblAddAnimeGenre.Size = new Size(69, 27);
            lblAddAnimeGenre.TabIndex = 2;
            lblAddAnimeGenre.Text = "Genre";
            // 
            // lblAddAnimeTitle
            // 
            lblAddAnimeTitle.AutoSize = true;
            lblAddAnimeTitle.BackColor = Color.Transparent;
            lblAddAnimeTitle.Font = new Font("Tw Cen MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddAnimeTitle.ForeColor = Color.FromArgb(45, 170, 158);
            lblAddAnimeTitle.Location = new Point(54, 81);
            lblAddAnimeTitle.Name = "lblAddAnimeTitle";
            lblAddAnimeTitle.Size = new Size(52, 27);
            lblAddAnimeTitle.TabIndex = 1;
            lblAddAnimeTitle.Text = "Title";
            // 
            // lblAddAnime
            // 
            lblAddAnime.AutoSize = true;
            lblAddAnime.BackColor = Color.Transparent;
            lblAddAnime.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddAnime.ForeColor = Color.White;
            lblAddAnime.Location = new Point(14, 13);
            lblAddAnime.Name = "lblAddAnime";
            lblAddAnime.Size = new Size(168, 38);
            lblAddAnime.TabIndex = 0;
            lblAddAnime.Text = "Add Anime";
            // 
            // bttnAddAnimeCancel
            // 
            bttnAddAnimeCancel.BackColor = Color.White;
            bttnAddAnimeCancel.FlatAppearance.BorderSize = 0;
            bttnAddAnimeCancel.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnAddAnimeCancel.ForeColor = Color.Black;
            bttnAddAnimeCancel.Location = new Point(173, 448);
            bttnAddAnimeCancel.Name = "bttnAddAnimeCancel";
            bttnAddAnimeCancel.Size = new Size(116, 48);
            bttnAddAnimeCancel.TabIndex = 17;
            bttnAddAnimeCancel.Text = "Cancel";
            bttnAddAnimeCancel.UseVisualStyleBackColor = false;
            bttnAddAnimeCancel.Click += bttnAddAnimeCancel_Click;
            // 
            // lblAdd
            // 
            lblAdd.AutoSize = true;
            lblAdd.BackColor = Color.Transparent;
            lblAdd.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdd.ForeColor = Color.Black;
            lblAdd.Location = new Point(63, 124);
            lblAdd.Name = "lblAdd";
            lblAdd.Size = new Size(168, 38);
            lblAdd.TabIndex = 12;
            lblAdd.Text = "Add Anime";
            lblAdd.Click += label4_Click;
            // 
            // bttnViewAllAnime
            // 
            bttnViewAllAnime.BackgroundImage = Properties.Resources.AnimeStatusBttn;
            bttnViewAllAnime.BackgroundImageLayout = ImageLayout.Stretch;
            bttnViewAllAnime.FlatAppearance.BorderSize = 0;
            bttnViewAllAnime.FlatStyle = FlatStyle.Flat;
            bttnViewAllAnime.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnViewAllAnime.Location = new Point(63, 199);
            bttnViewAllAnime.Name = "bttnViewAllAnime";
            bttnViewAllAnime.Size = new Size(285, 58);
            bttnViewAllAnime.TabIndex = 9;
            bttnViewAllAnime.TabStop = false;
            bttnViewAllAnime.UseVisualStyleBackColor = true;
            bttnViewAllAnime.Click += bttnViewAllAnime_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(45, 170, 158);
            label1.Enabled = false;
            label1.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(113, 203);
            label1.Name = "label1";
            label1.Size = new Size(112, 28);
            label1.TabIndex = 10;
            label1.Text = "All Anime";
            label1.Click += label1_Click_2;
            // 
            // bttnViewPending
            // 
            bttnViewPending.BackgroundImage = Properties.Resources.AnimeStatusBttn;
            bttnViewPending.BackgroundImageLayout = ImageLayout.Stretch;
            bttnViewPending.FlatAppearance.BorderSize = 0;
            bttnViewPending.FlatStyle = FlatStyle.Flat;
            bttnViewPending.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnViewPending.Location = new Point(507, 199);
            bttnViewPending.Name = "bttnViewPending";
            bttnViewPending.Size = new Size(285, 58);
            bttnViewPending.TabIndex = 11;
            bttnViewPending.TabStop = false;
            bttnViewPending.UseVisualStyleBackColor = true;
            bttnViewPending.Click += bttnViewPending_Click;
            // 
            // bttnViewFinished
            // 
            bttnViewFinished.BackgroundImage = Properties.Resources.AnimeStatusBttn;
            bttnViewFinished.BackgroundImageLayout = ImageLayout.Stretch;
            bttnViewFinished.FlatAppearance.BorderSize = 0;
            bttnViewFinished.FlatStyle = FlatStyle.Flat;
            bttnViewFinished.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnViewFinished.Location = new Point(933, 199);
            bttnViewFinished.Name = "bttnViewFinished";
            bttnViewFinished.Size = new Size(285, 58);
            bttnViewFinished.TabIndex = 12;
            bttnViewFinished.TabStop = false;
            bttnViewFinished.UseVisualStyleBackColor = true;
            bttnViewFinished.Click += bttnViewFinished_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(45, 170, 158);
            label2.Enabled = false;
            label2.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(556, 202);
            label2.Name = "label2";
            label2.Size = new Size(95, 28);
            label2.TabIndex = 13;
            label2.Text = "Pending";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(45, 170, 158);
            label3.Enabled = false;
            label3.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(988, 202);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 14;
            label3.Text = "Finished";
            // 
            // lblAllAnimeCount
            // 
            lblAllAnimeCount.AutoSize = true;
            lblAllAnimeCount.BackColor = Color.FromArgb(45, 170, 158);
            lblAllAnimeCount.Enabled = false;
            lblAllAnimeCount.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAllAnimeCount.ForeColor = Color.White;
            lblAllAnimeCount.Location = new Point(148, 229);
            lblAllAnimeCount.Name = "lblAllAnimeCount";
            lblAllAnimeCount.Size = new Size(36, 26);
            lblAllAnimeCount.TabIndex = 15;
            lblAllAnimeCount.Text = "15";
            lblAllAnimeCount.Click += lblAllAnimeCount_Click;
            // 
            // lblToWatchAnimeCount
            // 
            lblToWatchAnimeCount.AutoSize = true;
            lblToWatchAnimeCount.BackColor = Color.FromArgb(45, 170, 158);
            lblToWatchAnimeCount.Enabled = false;
            lblToWatchAnimeCount.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToWatchAnimeCount.ForeColor = Color.White;
            lblToWatchAnimeCount.Location = new Point(587, 229);
            lblToWatchAnimeCount.Name = "lblToWatchAnimeCount";
            lblToWatchAnimeCount.Size = new Size(24, 26);
            lblToWatchAnimeCount.TabIndex = 16;
            lblToWatchAnimeCount.Text = "8";
            // 
            // lblWatchedAnimeCount
            // 
            lblWatchedAnimeCount.AutoSize = true;
            lblWatchedAnimeCount.BackColor = Color.FromArgb(45, 170, 158);
            lblWatchedAnimeCount.Enabled = false;
            lblWatchedAnimeCount.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWatchedAnimeCount.ForeColor = Color.White;
            lblWatchedAnimeCount.Location = new Point(1022, 229);
            lblWatchedAnimeCount.Name = "lblWatchedAnimeCount";
            lblWatchedAnimeCount.Size = new Size(24, 26);
            lblWatchedAnimeCount.TabIndex = 17;
            lblWatchedAnimeCount.Text = "7";
            // 
            // dataGridAllAnime
            // 
            dataGridAllAnime.AllowUserToAddRows = false;
            dataGridAllAnime.AllowUserToDeleteRows = false;
            dataGridAllAnime.AllowUserToResizeColumns = false;
            dataGridAllAnime.AllowUserToResizeRows = false;
            dataGridAllAnime.BackgroundColor = SystemColors.Control;
            dataGridAllAnime.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 170, 158);
            dataGridViewCellStyle1.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 170, 158);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridAllAnime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridAllAnime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridAllAnime.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridAllAnime.EnableHeadersVisualStyles = false;
            dataGridAllAnime.GridColor = SystemColors.GrayText;
            dataGridAllAnime.Location = new Point(0, 0);
            dataGridAllAnime.Name = "dataGridAllAnime";
            dataGridAllAnime.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridAllAnime.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridAllAnime.RowHeadersWidth = 30;
            dataGridAllAnime.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridAllAnime.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridAllAnime.Size = new Size(1155, 395);
            dataGridAllAnime.TabIndex = 0;
            dataGridAllAnime.Visible = false;
            dataGridAllAnime.CellContentClick += dataGridAllAnime_CellContentClick;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(255, 192, 192);
            panel2.Controls.Add(dataGridAllAnime);
            panel2.Location = new Point(63, 286);
            panel2.Name = "panel2";
            panel2.Size = new Size(1155, 395);
            panel2.TabIndex = 18;
            panel2.Visible = false;
            // 
            // bttnAdd
            // 
            bttnAdd.BackColor = Color.Transparent;
            bttnAdd.BackgroundImage = Properties.Resources.add;
            bttnAdd.BackgroundImageLayout = ImageLayout.Stretch;
            bttnAdd.FlatAppearance.BorderSize = 0;
            bttnAdd.FlatStyle = FlatStyle.Flat;
            bttnAdd.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bttnAdd.ForeColor = Color.White;
            bttnAdd.Location = new Point(237, 120);
            bttnAdd.Name = "bttnAdd";
            bttnAdd.Size = new Size(50, 50);
            bttnAdd.TabIndex = 16;
            bttnAdd.UseVisualStyleBackColor = false;
            bttnAdd.Click += bttnAdd_Click;
            // 
            // AnimeListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(102, 210, 206);
            ClientSize = new Size(1280, 720);
            Controls.Add(panelDim);
            Controls.Add(panel2);
            Controls.Add(lblAdd);
            Controls.Add(lblWatchedAnimeCount);
            Controls.Add(lblToWatchAnimeCount);
            Controls.Add(lblAllAnimeCount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(bttnViewFinished);
            Controls.Add(bttnViewPending);
            Controls.Add(label1);
            Controls.Add(bttnViewAllAnime);
            Controls.Add(panel1);
            Controls.Add(bttnAdd);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AnimeListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AnimeList";
            Load += AnimeList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bttnManageAccount).EndInit();
            panelDim.ResumeLayout(false);
            panelManageAccount.ResumeLayout(false);
            panelManageAccount.PerformLayout();
            panelEditWatched.ResumeLayout(false);
            panelEditWatched.PerformLayout();
            panelEditToWatch.ResumeLayout(false);
            panelEditToWatch.PerformLayout();
            panelAddAnime.ResumeLayout(false);
            panelAddAnime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridAllAnime).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox bttnManageAccount;
        private Label lblUserName;
        private PictureBox pictureBox2;
        private Button bttnViewAllAnime;
        private Label label1;
        private Button bttnViewPending;
        private Button bttnViewFinished;
        private Label label2;
        private Label label3;
        private Label lblAllAnimeCount;
        private Label lblToWatchAnimeCount;
        private Label lblWatchedAnimeCount;
        private DataGridView dataGridAllAnime;
        private Panel panel2;
        private Panel panelEditToWatch;
        private Label lblEditAnimeReleaseYear;
        private Label lblEditAnimeGenre;
        private Label lblAnimeEditAnimeTitle;
        private Label lblEditAnime;
        private TextBox txtBoxEditAnimeTitle;
        private TextBox txtBoxEditAnimeReleaseYear;
        private TextBox txtBoxEditAnimeGenre;
        private Button bttnEditAnimeSave;
        private Button bttnEditAnimeCancel;
        private Button bttnEditAnimeMarkAsWatched;
        private Button bttnEditAnimeDelete;
        private Label lblAdd;
        private Label lblEditAnimeMarkAs;
        private Label lblEditAnimeWatched;
        private Label lblEditAnimeCancel;
        private Panel panelDim;
        private Button bttnAdd;
        private Panel panelAddAnime;
        private Button bttnAddAnimeSave;
        private TextBox txtBoxAddAnimeReleaseYear;
        private TextBox txtBoxAddAnimeTitle;
        private Label lblAddAnimeReleaseYear;
        private Label lblAddAnimeGenre;
        private Label lblAddAnimeTitle;
        private Label lblAddAnime;
        private Label label13;
        private Label lblEditAnimeDelete;
        private Button bttnAddAnimeCancel;
        private Panel panelEditWatched;
        private Label lblEditWatchedDelete;
        private Label lblEditWatchedCancel;
        private Label lblEditWatchedUnWatched;
        private Label lblEditWatchedMarkAs;
        private Button bttnEditWatchedMarkAsUnWatched;
        private Button bttnEditWatchedDelete;
        private Button bttnEditWatchedCancel;
        private Button bttnEditWatchedSave;
        private TextBox txtBoxEditWatchedReleaseYear;
        private TextBox txtBoxEditWatchedGenre;
        private TextBox txtBoxEditWatchedTitle;
        private Label lblEditWatchedReleaseYear;
        private Label lblEditWatchedGenre;
        private Label lblEditWatchedTitle;
        private Label lblEditWatched;
        private TextBox txtBoxEditWatchedRatings;
        private Label lblEditWatchedRatings;
        private TextBox txtBoxEditWatchedDateAndTime;
        private Label lblEditWatchedDateAndTime;
        private Panel panelManageAccount;
        private Button bttnLogOut;
        private TextBox txtBoxAccountPassword;
        private TextBox txtBoxAccountEmail;
        private TextBox txtBoxAccountName;
        private Label lblPassword;
        private Label lblEmail;
        private Label lblName;
        private Label lblManageAccount;
        private Button bttnDeleteAccount;
        private Button bttnEditAccountName;
        private Button bttnEditAccountPassword;
        private Button bttnEditAccountEmail;
        private Button button1;
        private Button button2;
        private CheckedListBox checklistboxAddAnimeGenre;
    }
}