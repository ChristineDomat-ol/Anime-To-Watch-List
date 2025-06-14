using AnimeListFrame;
using BusinessLogic;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList_Desktop
{
    public partial class AnimeListForm : Form
    {
        static DataGridViewButtonColumn EditColumn;
        static int animeID;

        public AnimeListForm()
        {
            InitializeComponent();
            UpdateUserAndAnimeCount();
        }

        public void DisplayGrid(List<AnimeList> animeList, string Message)
        {
            if (animeList == null || animeList.Count == 0)
            {
                MessageBox.Show(Message);
            }
            else
            {
                dataGridAllAnime.DataSource = null;
                dataGridAllAnime.DataSource = animeList;

                dataGridAllAnime.Columns["IsWatched"].FillWeight = 80;
                dataGridAllAnime.Columns["DateAndTime"].FillWeight = 150;

                dataGridAllAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridAllAnime.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridAllAnime.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridAllAnime.Columns["Name"].HeaderText = "Title";
                dataGridAllAnime.Columns["IsWatched"].HeaderText = "Status";
                dataGridAllAnime.Columns["DateAndTime"].HeaderText = "Date & Time";
                dataGridAllAnime.Columns["Ratings"].HeaderText = "Ratings ★";

                dataGridAllAnime.Columns["AnimeID"].Visible = false;
                dataGridAllAnime.Columns["Email"].Visible = false;
                dataGridAllAnime.RowHeadersVisible = false;

                if (dataGridAllAnime.Columns.Contains("bttnEdit"))
                {
                    dataGridAllAnime.Columns.Remove("bttnEdit");
                }

                EditColumn = new DataGridViewButtonColumn();
                EditColumn.Name = "bttnEdit";
                EditColumn.HeaderText = "";
                EditColumn.Text = "✏";
                EditColumn.UseColumnTextForButtonValue = true;
                EditColumn.Width = 30;
                EditColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dataGridAllAnime.Columns.Add(EditColumn);

                panel2.Visible = true;
                dataGridAllAnime.Visible = true;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bttnManageAccount.Enabled = false;
            
            panelDim.Visible = true;
            panelDim.BringToFront();
            panelManageAccount.Visible = true;
            panelManageAccount.BringToFront();

            txtBoxAccountName.Text = LogIn.currentUser.Name;
            txtBoxAccountEmail.Text = LogIn.currentUser.Email;
            txtBoxAccountPassword.Text = LogIn.currentUser.Password;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("yow naclick mo na");
        }

        private void bttnViewAllAnime_Click(object sender, EventArgs e)
        {
            var animeList = LogIn.businessLogic.GetUserAnimeList(LogIn.currentUser);

            string Message = "You have no anime in your list. Please add some anime to your list.";

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList, Message);
        }

        private void bttnViewFinished_Click(object sender, EventArgs e)
        {
            var animeList = LogIn.businessLogic.GetAnimeWatchedList(LogIn.currentUser);

            string Message = "You have no anime in your Watched List. Please add some anime to your watched list.";

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList, Message);

            EditColumn.Visible = false;
        }

        private void bttnViewPending_Click(object sender, EventArgs e)
        {
            var animeList = LogIn.businessLogic.GetAnimeToWatchedList(LogIn.currentUser);

            string Message = "You have no anime in your To Watch List. Please add some anime to your to watch list.";

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList, Message);

            EditColumn.Visible = false;
        }

        private void AnimeList_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblAllAnimeCount_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        //bttnEdit
        private void dataGridAllAnime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridAllAnime.Columns[e.ColumnIndex].Name == "bttnEdit")
                {
                    animeID = Convert.ToInt32(dataGridAllAnime.Rows[e.RowIndex].Cells["AnimeID"].Value);

                    DataGridViewRow row = dataGridAllAnime.Rows[e.RowIndex];

                    HideAnimeListFrame();

                    panelAddAnime.Visible = false;

                    if (LogIn.businessLogic.GetAnimeStatusIsWatched(LogIn.currentUser, animeID) == true)
                    {
                        panelEditWatched.BringToFront();
                        panelEditWatched.Visible = true;

                        txtBoxEditWatchedTitle.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                        txtBoxEditWatchedGenre.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Genre"].Value.ToString();
                        txtBoxEditWatchedReleaseYear.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["ReleaseYear"].Value.ToString();
                        txtBoxEditWatchedDateAndTime.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["DateAndTime"].Value.ToString();
                        txtBoxEditWatchedRatings.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Ratings"].Value.ToString();
                    }
                    else
                    {
                        panelEditToWatch.BringToFront();
                        panelEditToWatch.Visible = true;

                        txtBoxEditAnimeTitle.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                        txtBoxEditAnimeGenre.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Genre"].Value.ToString();
                        txtBoxEditAnimeReleaseYear.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["ReleaseYear"].Value.ToString();
                    }



                }
            }
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            //if (LogIn.currentUser == null)
            //{
            //    MessageBox.Show("User not logged in.");
            //    return;
            //}

            var deleteAnime = new AnimeList
            {
                AnimeID = animeID,
                Email = LogIn.currentUser.Email,
            };

            if (MessageBox.Show("Are you sure you want to Delete this Anime?",
                    "Exit Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogIn.businessLogic.DeleteAnime(deleteAnime);
                MessageBox.Show("Anime Deleted successfully");

                ReturnToAnimeListFrame();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            //if (LogIn.currentUser == null)
            //{
            //    MessageBox.Show("User not logged in.");
            //    return;
            //}

            var updatedAnime = new AnimeList
            {
                AnimeID = animeID,
                Email = LogIn.currentUser.Email,
                Name = txtBoxEditAnimeTitle.Text,
                Genre = txtBoxEditAnimeGenre.Text,
                ReleaseYear = txtBoxEditAnimeReleaseYear.Text
            };

            LogIn.businessLogic.UpdateToWatchAnime(updatedAnime);

            MessageBox.Show("Anime updated successfully");

            ReturnToAnimeListFrame();
        }

        public void UpdateUserAndAnimeCount()
        {
            lblUserName.Text = LogIn.currentUser.Name;
            lblAllAnimeCount.Text = LogIn.businessLogic.GetUserAnimeList(LogIn.currentUser).Count.ToString();
            lblToWatchAnimeCount.Text = LogIn.businessLogic.GetUserAnimeList(LogIn.currentUser).Count(a => !a.IsWatched).ToString();
            lblWatchedAnimeCount.Text = LogIn.businessLogic.GetUserAnimeList(LogIn.currentUser).Count(a => a.IsWatched).ToString();
        }

        public void ReturnToAnimeListFrame()
        {
            UpdateUserAndAnimeCount();

            panelDim.Hide();
            panelEditToWatch.Hide();
            panelEditWatched.Hide();
            panelAddAnime.Hide();
            panelManageAccount.Hide();

            bttnManageAccount.Enabled = true;

            var animeList = LogIn.businessLogic.GetUserAnimeList(LogIn.currentUser);

            string Message = "You have no anime in your list. Please add some anime to your list.";

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList, Message);
        }

        public void HideAnimeListFrame()
        {
            panel2.Hide();
            dataGridAllAnime.Hide();
            bttnManageAccount.Enabled = false;

            panelDim.Visible = true;
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            HideAnimeListFrame();

            panelAddAnime.Visible = true;
            panelAddAnime.BringToFront();

        }

        private void bttnAddAnimeCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void bttnAddAnimeSave_Click(object sender, EventArgs e)
        {
            if (LogIn.businessLogic.GetAnimeByName(LogIn.currentUser, txtBoxAddAnimeTitle.Text) != null)
            {
                MessageBox.Show(txtBoxAddAnimeTitle.Text + " is already in the List");
                ClearTxtBoxesInAddAnimePanel();
                return;
            }

            if (string.IsNullOrEmpty(txtBoxAddAnimeTitle.Text) || checklistboxAddAnimeGenre.CheckedItems.Count == 0 || string.IsNullOrEmpty(txtBoxAddAnimeReleaseYear.Text))
            {
                MessageBox.Show("Please Enter Anime, Genre and Release Year", "Field is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTxtBoxesInAddAnimePanel();
                return;
            }
            else
            {
                var addAnime = new AnimeList
                {
                    Email = LogIn.currentUser.Email,
                    Name = txtBoxAddAnimeTitle.Text,
                    Genre = string.Join("\n", checklistboxAddAnimeGenre.CheckedItems.Cast<string>()),
                    ReleaseYear = txtBoxAddAnimeReleaseYear.Text,
                    IsWatched = false
                };

                LogIn.businessLogic.AddAnime(addAnime);
                MessageBox.Show(txtBoxAddAnimeTitle.Text + " Added", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTxtBoxesInAddAnimePanel();
                ReturnToAnimeListFrame();
                return;
            }
        }

        public void ClearTxtBoxesInAddAnimePanel()
        {
            txtBoxAddAnimeTitle.Text = string.Empty;
            for(int i = 0; i < checklistboxAddAnimeGenre.Items.Count; i++)
{
                checklistboxAddAnimeGenre.SetItemChecked(i, false);
            }
            txtBoxAddAnimeReleaseYear.Text = string.Empty;
        }

        private void bttnEditAnimeMarkAsWatched_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("MMMM d, yyyy h:mm tt");

            string rating = Interaction.InputBox("Enter your Rating for " + txtBoxEditAnimeTitle.Text + " (1-5):", "Rating", "5", -1, -1);

            if (string.IsNullOrEmpty(rating) || !int.TryParse(rating, out int ratingValue) || ratingValue < 1 || ratingValue > 5)
            {
                MessageBox.Show("Please enter a valid rating between 1 and 5.", "Invalid Rating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var markAsWatchedAnime = new AnimeList
            {
                Email = LogIn.currentUser.Email,
                AnimeID = animeID,
                IsWatched = true,
                DateAndTime = formattedDate,
                Ratings = ratingValue.ToString()
            };

            LogIn.businessLogic.MarkAnimeAsWatched(markAsWatchedAnime);
            MessageBox.Show(txtBoxEditAnimeTitle.Text + " has been Marked as Watched");

            ReturnToAnimeListFrame();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bttnEditWatchedCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void lblEditWatchedReleaseYear_Click(object sender, EventArgs e)
        {

        }

        private void bttnEditWatchedDelete_Click(object sender, EventArgs e)
        {
            var deleteAnime = new AnimeList
            {
                AnimeID = animeID,
                Email = LogIn.currentUser.Email,
            };

            if (MessageBox.Show("Are you sure you want to Delete this Anime?",
                    "Exit Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogIn.businessLogic.DeleteAnime(deleteAnime);
                MessageBox.Show("Anime Deleted successfully");

                ReturnToAnimeListFrame();
            }
        }

        private void bttnEditWatchedSave_Click(object sender, EventArgs e)
        {
            var updatedAnime = new AnimeList
            {
                AnimeID = animeID,
                Email = LogIn.currentUser.Email,
                Name = txtBoxEditWatchedTitle.Text,
                Genre = txtBoxEditWatchedGenre.Text,
                ReleaseYear = txtBoxEditWatchedReleaseYear.Text,
                DateAndTime = txtBoxEditWatchedDateAndTime.Text,
                Ratings = txtBoxEditWatchedRatings.Text
            };

            LogIn.businessLogic.UpdateWatchedAnime(updatedAnime);

            MessageBox.Show("Anime updated successfully");

            ReturnToAnimeListFrame();
        }

        private void bttnEditWatchedMarkAsUnWatched_Click(object sender, EventArgs e)
        {
            var markAsUnWatchedAnime = new AnimeList
            {
                Email = LogIn.currentUser.Email,
                AnimeID = animeID
            };

            LogIn.businessLogic.MarkAnimeAsUnWatched(markAsUnWatchedAnime);
            MessageBox.Show(txtBoxEditAnimeTitle.Text + " has been Marked as UnWatched");

            ReturnToAnimeListFrame();
        }

        private void bttnManageAccCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            txtBoxAccountPassword.UseSystemPasswordChar = !txtBoxAccountPassword.UseSystemPasswordChar;
        }
    }
}
