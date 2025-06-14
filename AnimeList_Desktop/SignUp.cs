using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AnimeList_Desktop
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblWelcome;
        }

        private void bttnLogIn_Click(object sender, EventArgs e)
        {
            var Name = txtboxName.Text;
            var email = txtboxEmail.Text;
            var password = txtboxPassword.Text;
            var confirmPassword = txtboxConfirmPassword.Text;

            AnimeBusinessLogic businessLogic = new AnimeBusinessLogic();

            AccountFrame.Accounts account = businessLogic.ValidateAccount(email, password);

            LogIn logIn = new LogIn();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please Enter Name, Email and Password\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (account != null)
            {
                MessageBox.Show("Sign Up Successful! Please log in with your new account.");
                logIn.Show();

                this.Close();
            }
            else
            {
                AccountFrame.Accounts newAccount = new AccountFrame.Accounts
                {
                    Name = Name,
                    Email = email,
                    Password = password
                };

                businessLogic.AddAccount(newAccount);

                MessageBox.Show("Sign Up Successful! Please log in with your new account.");
                logIn.Show();

                this.Close();
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void txtboxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?",
                    "Exit Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bttnSignUp_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();

            this.Close();
        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnSeePassword_Click(object sender, EventArgs e)
        {
            txtboxPassword.UseSystemPasswordChar = !txtboxPassword.UseSystemPasswordChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtboxConfirmPassword.UseSystemPasswordChar = !txtboxConfirmPassword.UseSystemPasswordChar;
        }
    }
}
