using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BusinessLogic;
using AccountFrame;


namespace AnimeList_Desktop
{
    public partial class LogIn : Form
    {

        public static AnimeBusinessLogic businessLogic = new BusinessLogic.AnimeBusinessLogic();
        public static AccountFrame.Accounts currentUser;
        public LogIn()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblWelcomeBack;
        }

        private void bttnLogIn_Click(object sender, EventArgs e)
        {
            var Email = txtboxEmail.Text;
            var Password = txtboxPassword.Text;

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter both email and password.", "Field is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxEmail.Clear();
                txtboxPassword.Clear();
                return;
            }

            AccountFrame.Accounts account = businessLogic.ValidateAccount(Email, Password);

            if (account != null)
            {
                currentUser = account;
                MessageBox.Show("Log In Successful! Welcome", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AnimeListForm animeList = new AnimeListForm();
                animeList.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("FAILED: Account Doesn't Exist or Incorrect Password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtboxEmail.Clear();
                txtboxPassword.Clear();
                return;
            }

        }

        private void bttnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bttnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();

            this.Hide();
        }

        private void bttnSeePassword_Click(object sender, EventArgs e)
        {
            txtboxPassword.UseSystemPasswordChar = !txtboxPassword.UseSystemPasswordChar;

            if (!txtboxPassword.UseSystemPasswordChar)
            {
                bttnSeePassword.BackgroundImage = Properties.Resources.EyeClose;
            }
            else
            {
                bttnSeePassword.BackgroundImage = Properties.Resources.EyeOpen;
            }
        }
    }
}
