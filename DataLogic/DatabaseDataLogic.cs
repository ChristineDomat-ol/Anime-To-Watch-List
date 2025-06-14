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
            string selectStatement = "SELECT AccountName, AccountEmail, AccountPassword FROM AccountDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Accounts> AnimeAccount = new List<Accounts>();

            while (reader.Read())
            {
                Accounts AnimeAccounts = new Accounts();
                AnimeAccounts.Name = reader["AccountName"].ToString();
                AnimeAccounts.Email = reader["AccountEmail"].ToString();
                AnimeAccounts.Password = reader["AccountPassword"].ToString();
                AnimeAccount.Add(AnimeAccounts);
            }

            sqlConnection.Close();
            return AnimeAccount;
        }

        public void AddAccount(Accounts accounts)
        {
            var insertStatement = "INSERT INTO AccountDetails VALUES (@AccountName, @AccountEmail, @AccountPassword)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AccountName", accounts.Name);
            insertCommand.Parameters.AddWithValue("@AccountEmail", accounts.Email);
            insertCommand.Parameters.AddWithValue("@AccountPassword", accounts.Password);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteAccount(Accounts account)
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM AccountDetails WHERE AccountEmail = @AccountEmail AND AccountPassword = @AccountPassword";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@AccountEmail", account.Email);
            updateCommand.Parameters.AddWithValue("@AccountPassword", account.Password);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<AnimeList> GetUserAnimeList(Accounts Email)
        {
            string selectStatement = @"
            SELECT AnimeID, AnimeName, AnimeGenre, AnimeReleaseYear, AnimeIsWatched, AnimeDateAndTime, AnimeRatings
            FROM AnimeListDetails
            WHERE AccountEmail = @AccountEmail";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            selectCommand.Parameters.AddWithValue("@AccountEmail", Email.Email);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<AnimeList> Animelist = new List<AnimeList>();

            while (reader.Read())
            {
                AnimeList animelist = new AnimeList();
                animelist.AnimeID = Convert.ToInt32(reader["AnimeID"]); 
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
            SELECT AccountEmail, AnimeName, AnimeGenre, AnimeReleaseYear, AnimeIsWatched, AnimeDateAndTime, AnimeRatings
            FROM AnimeListDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            List<AnimeList> Animelist = new List<AnimeList>();

            while (reader.Read())
            {
                AnimeList animelist = new AnimeList();
                animelist.Email = reader["AccountEmail"].ToString();
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

        public void AddAnime(AnimeList animeList)
        {
            var insertStatement = "INSERT INTO AnimeListDetails VALUES (@AccountEmail, @AnimeName, @AnimeGenre, @AnimeReleaseYear, @AnimeIsWatched, @AnimeDateAndTime, @AnimeRatings)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AccountEmail", animeList.Email);
            insertCommand.Parameters.AddWithValue("@AnimeName", animeList.Name);
            insertCommand.Parameters.AddWithValue("@AnimeGenre", animeList.Genre);
            insertCommand.Parameters.AddWithValue("@AnimeReleaseYear", animeList.ReleaseYear);
            insertCommand.Parameters.AddWithValue("@AnimeIsWatched", false);
            insertCommand.Parameters.AddWithValue("@AnimeDateAndTime", DBNull.Value);
            insertCommand.Parameters.AddWithValue("@AnimeRatings", DBNull.Value);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteAnime(AnimeList animeList)
        {
            string deleteStatement = @"DELETE FROM AnimeListDetails WHERE AccountEmail = @Email AND AnimeID = @AnimeID";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@AnimeID", animeList.AnimeID);
            deleteCommand.Parameters.AddWithValue("@Email", animeList.Email);
            
            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void UpdateToWatchAnime(AnimeList animeList)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE AnimeListDetails SET AnimeName = @AnimeName, AnimeGenre = @AnimeGenre, AnimeReleaseYear = @AnimeReleaseYear WHERE AnimeID = @AnimeID AND AccountEmail = @AccountEmail";

            SqlCommand insertCommand = new SqlCommand(updateStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AnimeID", animeList.AnimeID);
            insertCommand.Parameters.AddWithValue("@AccountEmail", animeList.Email);
            insertCommand.Parameters.AddWithValue("@AnimeName", animeList.Name);
            insertCommand.Parameters.AddWithValue("@AnimeGenre", animeList.Genre);
            insertCommand.Parameters.AddWithValue("@AnimeReleaseYear", animeList.ReleaseYear);

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateWatchedAnime(AnimeList animeList)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE AnimeListDetails SET AnimeName = @AnimeName, AnimeGenre = @AnimeGenre, AnimeReleaseYear = @AnimeReleaseYear, AnimeDateAndTime = @AnimeDateAndTime, AnimeRatings = @AnimeRatings WHERE AnimeID = @AnimeID AND AccountEmail = @AccountEmail";

            SqlCommand insertCommand = new SqlCommand(updateStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AnimeID", animeList.AnimeID);
            insertCommand.Parameters.AddWithValue("@AccountEmail", animeList.Email);
            insertCommand.Parameters.AddWithValue("@AnimeName", animeList.Name);
            insertCommand.Parameters.AddWithValue("@AnimeGenre", animeList.Genre);
            insertCommand.Parameters.AddWithValue("@AnimeReleaseYear", animeList.ReleaseYear);
            insertCommand.Parameters.AddWithValue("@AnimeDateAndTime", animeList.DateAndTime);
            insertCommand.Parameters.AddWithValue("@AnimeRatings", animeList.Ratings);

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void MarkAnimeAsWatched(AnimeList animeList)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE AnimeListDetails SET AnimeIsWatched = @AnimeIsWatched, AnimeDateAndTime = @AnimeDateAndTime, AnimeRatings = @AnimeRatings WHERE AccountEmail = @AccountEmail AND AnimeID = @AnimeID";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@AccountEmail", animeList.Email);
            updateCommand.Parameters.AddWithValue("@AnimeID", animeList.AnimeID);
            updateCommand.Parameters.AddWithValue("@AnimeIsWatched", true);
            updateCommand.Parameters.AddWithValue("@AnimeDateAndTime", animeList.DateAndTime);
            updateCommand.Parameters.AddWithValue("@AnimeRatings", animeList.Ratings);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void MarkAnimeAsUnWatched(AnimeList animeList)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE AnimeListDetails SET AnimeIsWatched = @AnimeIsWatched, AnimeDateAndTime = @AnimeDateAndTime, AnimeRatings = @AnimeRatings WHERE AccountEmail = @AccountEmail AND AnimeID = @AnimeID";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@AccountEmail", animeList.Email);
            updateCommand.Parameters.AddWithValue("@AnimeID", animeList.AnimeID);
            updateCommand.Parameters.AddWithValue("@AnimeIsWatched", false);
            updateCommand.Parameters.AddWithValue("@AnimeDateAndTime", DBNull.Value);
            updateCommand.Parameters.AddWithValue("@AnimeRatings", DBNull.Value);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
