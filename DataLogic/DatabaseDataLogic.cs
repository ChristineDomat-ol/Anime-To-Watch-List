using AccountFrame;
using AnimeListFrame;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLogic
{
    public class DatabaseDataLogic : IAnimeDataLogic
    {
        static string connectionString
            = "Data Source =DOMA\\SQLEXPRESS01; Initial Catalog = Anime-To-Watch-List; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DatabaseDataLogic()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Accounts> GetAccounts()
        {
            string selectStatement = "SELECT AccountName, AccountUserName, AccountPassword FROM AccountDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Accounts> AnimeAccount = new List<Accounts>();

            while (reader.Read())
            {
                Accounts AnimeAccounts = new Accounts();
                AnimeAccounts.Name = reader["AccountName"].ToString();
                AnimeAccounts.UserName = reader["AccountUserName"].ToString();
                AnimeAccounts.Password = reader["AccountPassword"].ToString();
                AnimeAccount.Add(AnimeAccounts);
            }

            sqlConnection.Close();
            return AnimeAccount;
        }

        public void AddAccount(Accounts accounts)
        {
            var insertStatement = "INSERT INTO AccountDetails VALUES (@AccountName, @AccountUserName, @AccountPassword)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AccountName", accounts.Name);
            insertCommand.Parameters.AddWithValue("@AccountUserName", accounts.UserName);
            insertCommand.Parameters.AddWithValue("@AccountPassword", accounts.Password);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteAccount(Accounts account)
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM AccountDetails WHERE AccountUserName = @AccountUserName AND AccountPassword = @AccountPassword";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@AccountUserName", account.UserName);
            updateCommand.Parameters.AddWithValue("@AccountPassword", account.Password);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<AnimeList> GetUserAnimeList(Accounts UserName)
        {
            List<AnimeList> animeList = new List<AnimeList>();

            string selectStatement = @"
            SELECT AnimeName, AnimeGenre, AnimeReleaseYear, AnimeIsWatched, AnimeDateAndTime, AnimeRatings
            FROM AnimeListDetails
            WHERE AccountUserName = @AccountUserName";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            selectCommand.Parameters.AddWithValue("@AccountUserName", UserName.UserName);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<AnimeList> Animelist = new List<AnimeList>();

            while (reader.Read())
            {
                AnimeList animelist = new AnimeList();
                animelist.Name = reader["AnimeName"].ToString();
                animelist.Genre = reader["AnimeGenre"].ToString();
                animelist.ReleaseYear = reader["AnimeReleaseYear"].ToString();
                animelist.IsWatched = Convert.ToBoolean(reader["AnimeIsWatched"]);
                animelist.DateAndTime = reader["AnimeDateAndTime"] is DBNull ? null : reader["AnimeDateAndTime"].ToString();
                animelist.Ratings = reader["AnimeRatings"] is DBNull ? null : reader["AnimeRatings"].ToString();
                Animelist.Add(animelist);
            }

            sqlConnection.Close();
            return Animelist;
        }

        public List<AnimeList> GetAllAnimeList()
        {

            string selectStatement = @"
            SELECT AccountUserName, AnimeName, AnimeGenre, AnimeReleaseYear, AnimeIsWatched, AnimeDateAndTime, AnimeRatings
            FROM AnimeListDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<AnimeList> Animelist = new List<AnimeList>();

            while (reader.Read())
            {
                AnimeList animelist = new AnimeList();
                animelist.UserName = reader["AccountUserName"].ToString();
                animelist.Name = reader["AnimeName"].ToString();
                animelist.Genre = reader["AnimeGenre"].ToString();
                animelist.ReleaseYear = reader["AnimeReleaseYear"].ToString();
                animelist.IsWatched = Convert.ToBoolean(reader["AnimeIsWatched"]);
                animelist.DateAndTime = reader["AnimeDateAndTime"] is DBNull ? null : reader["AnimeDateAndTime"].ToString();
                animelist.Ratings = reader["AnimeRatings"] is DBNull ? null : reader["AnimeRatings"].ToString();
                Animelist.Add(animelist);
            }

            sqlConnection.Close();
            return Animelist;
        }

        public void AddAnime(Accounts Username, string AnimeName, string Genre, string ReleaseDate)
        {
            var insertStatement = "INSERT INTO AnimeListDetails VALUES (@AccountUserName, @AnimeName, @AnimeGenre, @AnimeReleaseYear, @AnimeIsWatched, @AnimeDateAndTime, @AnimeRatings)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AccountUserName", Username.UserName);
            insertCommand.Parameters.AddWithValue("@AnimeName", AnimeName);
            insertCommand.Parameters.AddWithValue("@AnimeGenre", Genre);
            insertCommand.Parameters.AddWithValue("@AnimeReleaseYear", ReleaseDate);
            insertCommand.Parameters.AddWithValue("@AnimeIsWatched", false);
            insertCommand.Parameters.AddWithValue("@AnimeDateAndTime", DBNull.Value);
            insertCommand.Parameters.AddWithValue("@AnimeRatings", DBNull.Value);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteAnime(Accounts UserName, string anime)
        {
            string deleteStatement = @"DELETE FROM AnimeListDetails WHERE AccountUserName = @UserName AND AnimeName = @AnimeName";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@UserName", UserName.UserName);
            deleteCommand.Parameters.AddWithValue("@AnimeName", anime);
            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void MarkAnimeAsWatched(Accounts UserName, string AnimeName, string formattedDate, string Rate)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE AnimeListDetails SET AnimeIsWatched = @AnimeIsWatched, AnimeDateAndTime = @AnimeDateAndTime, AnimeRatings = @AnimeRatings WHERE AccountUserName = @AccountUserName AND AnimeName = @AnimeName";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@AccountUserName", UserName.UserName);
            updateCommand.Parameters.AddWithValue("@AnimeName", AnimeName);
            updateCommand.Parameters.AddWithValue("@AnimeIsWatched", true);
            updateCommand.Parameters.AddWithValue("@AnimeDateAndTime", formattedDate);
            updateCommand.Parameters.AddWithValue("@AnimeRatings", Rate);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
