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

        List<AnimeList> currentDisplayedAnimeList;
        bool sortNameAscending = true;

        public AnimeListForm()
        {
            InitializeComponent();
            UpdateUserAndAnimeCount();
        }

        public void DisplayGrid(List<AnimeList> animeList)
        {
            currentDisplayedAnimeList = animeList;

            if (currentDisplayedAnimeList == null || currentDisplayedAnimeList.Count == 0)
            {
                MessageBox.Show("List is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridAllAnime.DataSource = null;
                dataGridAllAnime.DataSource = currentDisplayedAnimeList;

                dataGridAllAnime.Columns["IsWatched"].FillWeight = 50;
                dataGridAllAnime.Columns["DateAndTime"].FillWeight = 150;

                dataGridAllAnime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridAllAnime.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridAllAnime.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridAllAnime.Columns["Name"].HeaderText = "Title";
                dataGridAllAnime.Columns["IsWatched"].HeaderText = "Status";
                dataGridAllAnime.Columns["ReleaseYear"].HeaderText = "Release Year";
                dataGridAllAnime.Columns["DateAndTime"].HeaderText = "Date & Time";
                dataGridAllAnime.Columns["Ratings"].HeaderText = "Ratings ★";

                dataGridAllAnime.Columns["AnimeID"].Visible = false;
                dataGridAllAnime.Columns["AccountID"].Visible = false;
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

        private void bttnManageAccount_Click(object sender, EventArgs e)
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

        private void bttnViewAllAnime_Click(object sender, EventArgs e)
        {
            var animeList = LogIn.businessLogic.GetUserAnimeList(LogIn.currentUser);

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList);
        }

        private void bttnViewFinished_Click(object sender, EventArgs e)
        {
            var animeList = LogIn.businessLogic.GetAnimeWatchedList(LogIn.currentUser);

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList);
        }

        private void bttnViewPending_Click(object sender, EventArgs e)
        {
            var animeList = LogIn.businessLogic.GetAnimeToWatchedList(LogIn.currentUser);

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList);
        }

        //EditGrid
        private void dataGridAllAnime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                animeID = Convert.ToInt32(dataGridAllAnime.Rows[e.RowIndex].Cells["AnimeID"].Value);

                //edit bttn
                if (dataGridAllAnime.Columns[e.ColumnIndex].Name == "bttnEdit")
                {
                    HideAnimeListFrame();
                    panelAddAnime.Visible = false;

                    //edit Watched Anime
                    if (LogIn.businessLogic.GetAnimeStatusIsWatched(LogIn.currentUser, animeID) == true)
                    {
                        panelEditWatched.BringToFront();
                        panelEditWatched.Visible = true;

                        for (int i = 0; i < checkedListBoxEditWatchedGenre.Items.Count; i++)
                        {
                            checkedListBoxEditWatchedGenre.SetItemChecked(i, false);
                        }

                        string genreData = dataGridAllAnime.Rows[e.RowIndex].Cells["Genre"].Value?.ToString();

                        if (!string.IsNullOrEmpty(genreData))
                        {
                            string[] selectedGenres = genreData.Split("\n", StringSplitOptions.RemoveEmptyEntries);

                            foreach (string genre in selectedGenres)
                            {
                                string trimmedGenre = genre.Trim();

                                for (int i = 0; i < checkedListBoxEditWatchedGenre.Items.Count; i++)
                                {
                                    if (string.Equals(checkedListBoxEditWatchedGenre.Items[i].ToString(), trimmedGenre, StringComparison.OrdinalIgnoreCase))
                                    {
                                        checkedListBoxEditWatchedGenre.SetItemChecked(i, true);
                                        break;
                                    }
                                }
                            }
                        }
                        txtBoxEditWatchedTitle.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                        txtBoxEditWatchedReleaseYear.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["ReleaseYear"].Value.ToString();
                        txtBoxEditWatchedDateAndTime.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["DateAndTime"].Value.ToString();
                        txtBoxEditWatchedRatings.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Ratings"].Value.ToString();
                    }

                    //edit ToWatch Anime
                    else
                    {
                        panelEditToWatch.BringToFront();
                        panelEditToWatch.Visible = true;

                        for (int i = 0; i < checkedListBoxEditWatchedGenre.Items.Count; i++)
                        {
                            checkedListBoxEditWatchedGenre.SetItemChecked(i, false);
                        }

                        string genreData = dataGridAllAnime.Rows[e.RowIndex].Cells["Genre"].Value?.ToString();

                        if (!string.IsNullOrEmpty(genreData))
                        {
                            string[] selectedGenres = genreData.Split("\n", StringSplitOptions.RemoveEmptyEntries);

                            foreach (string genre in selectedGenres)
                            {
                                string trimmedGenre = genre.Trim();

                                for (int i = 0; i < checkedListBoxEditAnimeGenre.Items.Count; i++)
                                {
                                    if (string.Equals(checkedListBoxEditAnimeGenre.Items[i].ToString(), trimmedGenre, StringComparison.OrdinalIgnoreCase))
                                    {
                                        checkedListBoxEditAnimeGenre.SetItemChecked(i, true);
                                        break;
                                    }
                                }
                            }
                        }
                        txtBoxEditAnimeTitle.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                        txtBoxEditAnimeReleaseYear.Text = dataGridAllAnime.Rows[e.RowIndex].Cells["ReleaseYear"].Value.ToString();
                    }
                }


                if (dataGridAllAnime.Columns[e.ColumnIndex].Name == "IsWatched")
                {
                    //Mark as UnWatched bttn
                    if (LogIn.businessLogic.GetAnimeStatusIsWatched(LogIn.currentUser, animeID) == true)
                    {
                        if (MessageBox.Show("Do you want to mark anime as UnWatched?", "Mark Anime as UnWatched", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var markAsUnWatchedAnime = new AnimeList
                            {
                                AccountID = LogIn.currentUser.AccountID,
                                AnimeID = animeID
                            };

                            LogIn.businessLogic.MarkAnimeAsUnWatched(markAsUnWatchedAnime);
                            MessageBox.Show(dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString() + " has been Marked as UnWatched", "UnWatched", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReturnToAnimeListFrame();
                        }
                        return;
                    }

                    //Mark as Watched bttn
                    else
                    {
                        if (MessageBox.Show("Do you want to mark anime as Watched?", "Mark Anime as Watched", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DateTime dateTime = DateTime.Now;
                            string formattedDate = dateTime.ToString("MMMM d, yyyy h:mm tt");
                            string rating = Interaction.InputBox("Enter your Rating for " + dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString() + " (1-5):", "Rating", "5");

                            if (string.IsNullOrWhiteSpace(rating) || !int.TryParse(rating, out int ratingValue) || ratingValue < 1 || ratingValue > 5)
                            {
                                MessageBox.Show("Please enter a valid rating between 1 and 5.", "Invalid Rating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            var markAsWatchedAnime = new AnimeList
                            {
                                AccountID = LogIn.currentUser.AccountID,
                                AnimeID = animeID,
                                IsWatched = true,
                                DateAndTime = formattedDate,
                                Ratings = ratingValue.ToString()
                            };

                            LogIn.businessLogic.MarkAnimeAsWatched(markAsWatchedAnime);
                            MessageBox.Show(dataGridAllAnime.Rows[e.RowIndex].Cells["Name"].Value.ToString() + " has been Marked as Watched", "Watched", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ReturnToAnimeListFrame();
                        }
                        return;
                    }
                }
            }
        }

        private void dataGridAllAnime_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Sort Name Column
            if (dataGridAllAnime.Columns[e.ColumnIndex].Name == "Name")
            {
                if (sortNameAscending)
                {
                    dataGridAllAnime.DataSource = currentDisplayedAnimeList.OrderBy(Title => Title.Name).ToList();
                }
                else
                {
                    dataGridAllAnime.DataSource = currentDisplayedAnimeList.OrderByDescending(Title => Title.Name).ToList();
                }
                sortNameAscending = !sortNameAscending;
            }

            //Filter Genre Column
            if (dataGridAllAnime.Columns[e.ColumnIndex].Name == "Genre")
            {
                panelFilterGenre.Visible = true;
                panelFilterGenre.BringToFront();
            }

            //Sort Release Year Column
            if (dataGridAllAnime.Columns[e.ColumnIndex].Name == "ReleaseYear")
            {
                if (sortNameAscending)
                {
                    dataGridAllAnime.DataSource = currentDisplayedAnimeList.OrderBy(Year => Year.ReleaseYear).ToList();
                }
                else
                {
                    dataGridAllAnime.DataSource = currentDisplayedAnimeList.OrderByDescending(Year => Year.ReleaseYear).ToList();
                }
                sortNameAscending = !sortNameAscending;
            }
        }

        private void bttnEditAnimeDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this Anime?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var deleteAnime = new AnimeList
                {
                    AnimeID = animeID,
                    AccountID = LogIn.currentUser.AccountID,
                };

                LogIn.businessLogic.DeleteAnime(deleteAnime);
                MessageBox.Show("Anime Deleted successfully", "Anime Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReturnToAnimeListFrame();
            }
            else
            {
                ReturnToAnimeListFrame();
            }
        }

        private void bttnEditAnimeCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void bttnEditAnimeSavee_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBoxEditAnimeTitle.Text) || checkedListBoxEditAnimeGenre.CheckedItems.Count == 0 || string.IsNullOrEmpty(txtBoxEditAnimeReleaseYear.Text))
            {
                MessageBox.Show("Please Enter Title, Genre and Release Year", "Field is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(txtBoxEditAnimeReleaseYear.Text, out int releaseYear) || releaseYear < 1900 || releaseYear > DateTime.Now.Year)
            {
                MessageBox.Show("Please Enter a valid Release Year", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var updatedAnime = new AnimeList
                {
                    AnimeID = animeID,
                    AccountID = LogIn.currentUser.AccountID,
                    Name = txtBoxEditAnimeTitle.Text,
                    Genre = string.Join("\n", checkedListBoxEditAnimeGenre.CheckedItems.Cast<string>()),
                    ReleaseYear = txtBoxEditAnimeReleaseYear.Text
                };

                LogIn.businessLogic.UpdateToWatchAnime(updatedAnime);

                MessageBox.Show("Anime updated successfully", "Anime Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReturnToAnimeListFrame();
            }
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

            panel2.Hide();
            dataGridAllAnime.Hide();

            DisplayGrid(animeList);
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
                MessageBox.Show(txtBoxAddAnimeTitle.Text + " is already in the List", "Anime Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTxtBoxesInAddAnimePanel();
                return;
            }

            if (string.IsNullOrEmpty(txtBoxAddAnimeTitle.Text) || checklistboxAddAnimeGenre.CheckedItems.Count == 0 || string.IsNullOrEmpty(txtBoxAddAnimeReleaseYear.Text))
            {
                MessageBox.Show("Please Enter Anime, Genre and Release Year", "Field is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTxtBoxesInAddAnimePanel();
                return;
            }
            else if (!int.TryParse(txtBoxAddAnimeReleaseYear.Text, out int releaseYear) || releaseYear < 1900 || releaseYear > DateTime.Now.Year)
            {
                MessageBox.Show("Please Enter a valid Release Year", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTxtBoxesInAddAnimePanel();
                return;
            }
            else
            {
                var addAnime = new AnimeList
                {
                    AccountID = LogIn.currentUser.AccountID,
                    Name = txtBoxAddAnimeTitle.Text,
                    Genre = string.Join("\n", checklistboxAddAnimeGenre.CheckedItems.Cast<string>()),
                    ReleaseYear = txtBoxAddAnimeReleaseYear.Text,
                    IsWatched = false
                };

                LogIn.businessLogic.AddAnime(addAnime);
                MessageBox.Show(txtBoxAddAnimeTitle.Text + " Added", "Anime Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTxtBoxesInAddAnimePanel();
                ReturnToAnimeListFrame();
                return;
            }
        }

        public void ClearTxtBoxesInAddAnimePanel()
        {
            txtBoxAddAnimeTitle.Text = string.Empty;
            for (int i = 0; i < checklistboxAddAnimeGenre.Items.Count; i++)
            {
                checklistboxAddAnimeGenre.SetItemChecked(i, false);
            }
            txtBoxAddAnimeReleaseYear.Text = string.Empty;
        }

        private void bttnEditAnimeMarkAsWatched_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("MMMM d, yyyy h:mm tt");

            string rating = Interaction.InputBox("Enter your Rating for " + txtBoxEditAnimeTitle.Text + " (1-5):", "Rating", "5");

            if (!int.TryParse(rating, out int ratingValue) || ratingValue < 1 || ratingValue > 5)
            {
                MessageBox.Show("Please enter a valid rating between 1 and 5.", "Invalid Rating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var markAsWatchedAnime = new AnimeList
            {
                AccountID = LogIn.currentUser.AccountID,
                AnimeID = animeID,
                IsWatched = true,
                DateAndTime = formattedDate,
                Ratings = ratingValue.ToString()
            };

            LogIn.businessLogic.MarkAnimeAsWatched(markAsWatchedAnime);
            MessageBox.Show(txtBoxEditAnimeTitle.Text + " has been Marked as Watched");

            ReturnToAnimeListFrame();
        }

        private void bttnEditWatchedCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void bttnEditWatchedDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete this Anime?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var deleteAnime = new AnimeList
                {
                    AnimeID = animeID,
                    AccountID = LogIn.currentUser.AccountID,
                };

                LogIn.businessLogic.DeleteAnime(deleteAnime);
                MessageBox.Show("Anime Deleted successfully");

                ReturnToAnimeListFrame();
            }
            else
            {
                ReturnToAnimeListFrame();
            }
        }

        private void bttnEditWatchedSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBoxEditWatchedTitle.Text) || checkedListBoxEditWatchedGenre.CheckedItems.Count == 0 || string.IsNullOrEmpty(txtBoxEditWatchedReleaseYear.Text) || string.IsNullOrEmpty(txtBoxEditWatchedDateAndTime.Text) || string.IsNullOrEmpty(txtBoxEditWatchedRatings.Text))
            {
                MessageBox.Show("Please Enter Title, Genre, Release Year, Date & Time and Ratings", "Field is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(txtBoxEditWatchedReleaseYear.Text, out int releaseYear) || releaseYear < 1900 || releaseYear > DateTime.Now.Year)
            {
                MessageBox.Show("Please Enter a valid Release Year", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(txtBoxEditWatchedRatings.Text, out int ratingValue) || ratingValue < 1 || ratingValue > 5)
            {
                MessageBox.Show("Please enter a valid rating between 1 and 5.", "Invalid Rating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var updatedAnime = new AnimeList
                {
                    AnimeID = animeID,
                    AccountID = LogIn.currentUser.AccountID,
                    Name = txtBoxEditWatchedTitle.Text,
                    Genre = string.Join("\n", checkedListBoxEditWatchedGenre.CheckedItems.Cast<string>()),
                    ReleaseYear = txtBoxEditWatchedReleaseYear.Text,
                    DateAndTime = txtBoxEditWatchedDateAndTime.Text,
                    Ratings = txtBoxEditWatchedRatings.Text
                };

                LogIn.businessLogic.UpdateWatchedAnime(updatedAnime);

                MessageBox.Show("Anime updated successfully");

                ReturnToAnimeListFrame();
            }
        }

        private void bttnEditWatchedMarkAsUnWatched_Click(object sender, EventArgs e)
        {
            var markAsUnWatchedAnime = new AnimeList
            {
                AccountID = LogIn.currentUser.AccountID,
                AnimeID = animeID
            };

            LogIn.businessLogic.MarkAnimeAsUnWatched(markAsUnWatchedAnime);
            MessageBox.Show(txtBoxEditAnimeTitle.Text + " has been Marked as UnWatched");

            ReturnToAnimeListFrame();
        }

        private void bttnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log Out?", "Log Out", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LogIn logIn = new LogIn();
                logIn.Show();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void bttnManageAccCancel_Click(object sender, EventArgs e)
        {
            ReturnToAnimeListFrame();
        }

        private void bttnAccountSeePass_Click(object sender, EventArgs e)
        {
            txtBoxAccountPassword.UseSystemPasswordChar = !txtBoxAccountPassword.UseSystemPasswordChar;

            if (!txtBoxAccountPassword.UseSystemPasswordChar)
            {
                bttnAccountSeePass.BackgroundImage = Properties.Resources.EyeClose;
            }
            else
            {
                bttnAccountSeePass.BackgroundImage = Properties.Resources.EyeOpen;
            }
        }

        private void bttnEditAccountName_Click(object sender, EventArgs e)
        {
            if (txtBoxAccountName.Enabled != true)
            {
                txtBoxAccountName.Enabled = true;
                txtBoxAccountName.ReadOnly = false;
                bttnAccountNameSave.Enabled = true;
            }
            else
            {
                txtBoxAccountName.Enabled = false;
                txtBoxAccountName.ReadOnly = true;
                bttnAccountNameSave.Enabled = false;
            }
        }

        private void bttnAccountNameSave_Click(object sender, EventArgs e)
        {
            if (txtBoxAccountName.Text.Equals(LogIn.currentUser.Name.Trim()))
            {
                MessageBox.Show("You have not changed your Name", "No Changes Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxAccountName.Enabled = false;
                txtBoxAccountName.ReadOnly = true;
                bttnAccountNameSave.Enabled = false;
                return;
            }
            else
            {
                var updatedUser = new AccountFrame.Accounts
                {
                    AccountID = LogIn.currentUser.AccountID,
                    Name = txtBoxAccountName.Text,
                    Email = txtBoxAccountEmail.Text,
                    Password = txtBoxAccountPassword.Text
                };

                LogIn.businessLogic.UpdateAccount(updatedUser);
                LogIn.currentUser = updatedUser;

                MessageBox.Show("Account Updated", "Account Name Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBoxAccountName.Enabled = false;
                txtBoxAccountName.ReadOnly = true;
                bttnAccountNameSave.Enabled = false;
            }
        }

        private void bttnEditAccountEmail_Click(object sender, EventArgs e)
        {
            if (txtBoxAccountEmail.Enabled != true)
            {
                txtBoxAccountEmail.Enabled = true;
                txtBoxAccountEmail.ReadOnly = false;
                bttnAccountEmailSave.Enabled = true;
            }
            else
            {
                txtBoxAccountEmail.Enabled = false;
                txtBoxAccountEmail.ReadOnly = true;
                bttnAccountEmailSave.Enabled = false;
            }
        }

        private void bttnAccountEmailSave_Click(object sender, EventArgs e)
        {
            if (txtBoxAccountEmail.Text.Equals(LogIn.currentUser.Email.Trim()))
            {
                MessageBox.Show("You have not changed your Email", "No Changes Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxAccountEmail.Enabled = false;
                txtBoxAccountEmail.ReadOnly = true;
                bttnAccountEmailSave.Enabled = false;
                return;
            }
            else
            {
                var updatedUser = new AccountFrame.Accounts
                {
                    AccountID = LogIn.currentUser.AccountID,
                    Name = txtBoxAccountName.Text,
                    Email = txtBoxAccountEmail.Text,
                    Password = txtBoxAccountPassword.Text
                };

                LogIn.businessLogic.UpdateAccount(updatedUser);
                LogIn.currentUser = updatedUser;

                MessageBox.Show("Account Updated", "Account Email Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBoxAccountEmail.Enabled = false;
                txtBoxAccountEmail.ReadOnly = true;
                bttnAccountEmailSave.Enabled = false;
            }
        }

        private void bttnEditAccountPassword_Click(object sender, EventArgs e)
        {
            if (txtBoxAccountPassword.Enabled != true)
            {
                txtBoxAccountPassword.Enabled = true;
                txtBoxAccountPassword.ReadOnly = false;
                bttnAccountPasswordSave.Enabled = true;
            }
            else
            {
                txtBoxAccountPassword.Enabled = false;
                txtBoxAccountPassword.ReadOnly = true;
                bttnAccountPasswordSave.Enabled = false;
            }
        }

        private void bttnAccountPasswordSave_Click(object sender, EventArgs e)
        {
            if (txtBoxAccountPassword.Text.Equals(LogIn.currentUser.Password.Trim()))
            {
                MessageBox.Show("You have not changed your Pasword", "No Changes Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxAccountPassword.Enabled = false;
                txtBoxAccountPassword.ReadOnly = true;
                bttnAccountPasswordSave.Enabled = false;
                return;
            }
            else
            {
                var updatedUser = new AccountFrame.Accounts
                {
                    AccountID = LogIn.currentUser.AccountID,
                    Name = txtBoxAccountName.Text,
                    Email = txtBoxAccountEmail.Text,
                    Password = txtBoxAccountPassword.Text
                };

                LogIn.businessLogic.UpdateAccount(updatedUser);
                LogIn.currentUser = updatedUser;

                MessageBox.Show("Account Updated", "Account Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBoxAccountPassword.Enabled = false;
                txtBoxAccountPassword.ReadOnly = true;
                bttnAccountPasswordSave.Enabled = false;
            }
        }

        private void bttnDeleteAccount_Click(object sender, EventArgs e)
        {
            panelDeleteAccount.Visible = true;
            panelDeleteAccount.BringToFront();
        }

        private void bttnDeleteAccountDelete_Click(object sender, EventArgs e)
        {
            if (txtboxEmailDelConfirm.Text != LogIn.currentUser.Email || txtboxPasswordDelConfirm.Text != LogIn.currentUser.Password)
            {
                if (MessageBox.Show("Account Details Mismatched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    txtboxEmailDelConfirm.Clear();
                    txtboxPasswordDelConfirm.Clear();
                    panelDeleteConfirmation.Visible = false;
                    panelDeleteAccount.Visible = false;
                }
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LogIn.businessLogic.DeleteAccount(LogIn.currentUser);

                MessageBox.Show("Account successfully deleted. Redirecting to the LogIn screen...", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogIn logIn = new LogIn();
                logIn.Show();

                this.Close();
            }
            else
            {
                ReturnToAnimeListFrame();
                return;
            }
        }

        private void bttnDeleteAccountCancel_Click(object sender, EventArgs e)
        {
            panelDeleteConfirmation.Visible = false;
            panelDeleteAccount.Visible = false;
        }

        private void bttnCancelFilter_Click(object sender, EventArgs e)
        {
            panelFilterGenre.Visible = false;
        }

        private void bttnFilterGenre_Click(object sender, EventArgs e)
        {
            var selectedGenres = checkedListBoxFilterGenre.CheckedItems.Cast<string>().Select(genre => genre.Trim().ToLower()).ToList();

            if (selectedGenres.Count == 0)
            {
                MessageBox.Show("Please select at least one genre to filter.", "No Genre Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var filteredList = currentDisplayedAnimeList.Where(anime =>
            {
                List<string> genresInAnime = anime.Genre.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries).Select(genre => genre.Trim().ToLower()).ToList();

                foreach (string selectedGenre in selectedGenres)
                {
                    if (genresInAnime.Contains(selectedGenre))
                    {
                        return true;
                    }
                }

                return false;

            }).ToList();

            if (filteredList.Count == 0)
            {
                MessageBox.Show("No anime found for the selected genre(s).", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            panelFilterGenre.Visible = false;
            DisplayGrid(filteredList);
        }

        private void bttnSearchAnime_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxSearchAnime.Text))
            {
                MessageBox.Show("Please enter an anime name to search.", "Empty Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var anime = LogIn.businessLogic.GetAnimeByName(LogIn.currentUser, txtBoxSearchAnime.Text.Trim());

            if (anime != null)
            {
                List<AnimeListFrame.AnimeList> animeList = new List<AnimeListFrame.AnimeList>();
                animeList.Add(anime);
                DisplayGrid(animeList);
                txtBoxSearchAnime.Clear();
            }
            else
            {
                MessageBox.Show("Anime not found", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxSearchAnime.Clear();
            }
        }

        private void bttnDeleteAcc_Click(object sender, EventArgs e)
        {
            panelDeleteConfirmation.Visible = true;
        }
    }
}
