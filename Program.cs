using AccountFrame;
using AnimeListFrame;
using BusinessLogic;
using DataLogic;
using System.Xml.Linq;

namespace Anime_To_Watch_List
{
    public class Program
    {
        static string[] MenuActions = new string[] {
            "[1] Add Anime",
            "[2] Delete Anime",
            "[3] Search Anime",
            "[4] View Anime List",
            "[5] Mark as Watched",
            "[6] Delete Account",
            "[7] Log Out"
        };

        static string[] ViewActions = new string[] {
            "[1] View All",
            "[2] View To-Watched List",
            "[3] View Watched List",
            "[4] Back"
        };

        static string[] AccountActions = new string[] {
            "[1] Log In",
            "[2] Sign Up",
            "[3] EXIT"
        };

        static string[] SearchActions = new string[] {
            "[1] Search by Anime Name",
            "[2] Search by Genre",
            "[3] Search by Release Year",
            "[4] Back"
        };

        static AnimeBusinessLogic businessLogic = new BusinessLogic.AnimeBusinessLogic();

        static Accounts currentUser;
        static bool isLoggedIn = false;

        static void Main(string[] args)
        {
            Console.WriteLine("\tMy Anime Manager");

            SignUpOrLogIn();

            while (isLoggedIn == true)
            {
                ShowMenuActions();
                string useraction = GetUserActionInput();

                while (useraction != "7")
                {
                    switch (useraction)
                    {
                        case "1":
                            AddAnime();
                            break;
                        case "2":
                            DeleteAnime();
                            break;
                        case "3":

                            if (businessLogic.GetUserAnimeList(currentUser) == null)
                            {
                                Console.WriteLine("\nList is Empty");
                                break;
                            }

                            ShowSearchMenuActions();
                            string searchAction = GetUserActionInput();

                            while (searchAction != "4")
                            {
                                if (searchAction == "1")
                                {
                                    SearchByName();
                                }
                                else if (searchAction == "2")
                                {
                                    SearchByGenre();
                                }
                                else if (searchAction == "3")
                                {
                                    SearchByReleaseYear();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input\nPlease Enter 1-4");
                                }
                                ShowSearchMenuActions();
                                searchAction = GetUserActionInput();
                            }
                            break;

                        case "4":

                            if (businessLogic.GetUserAnimeList(currentUser) == null)
                            {
                                Console.WriteLine("\nList is Empty");
                                break;
                            }

                            ShowViewMenuActions();
                            string viewAction = GetUserActionInput();

                            while (viewAction != "4")
                            {
                                if (viewAction == "1")
                                {
                                    ViewList();
                                }
                                else if (viewAction == "2")
                                {
                                    ViewToWatchedList();
                                }
                                else if (viewAction == "3")
                                {
                                    ViewWatchedList();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input\nPlease Enter 1-3");
                                }
                                ShowViewMenuActions();
                                viewAction = GetUserActionInput();
                            }
                            break;
                        case "5":
                            MarkasWatched();
                            break;
                        case "6":
                            DeleteAccount();
                            break;
                        default:
                            Console.WriteLine("Invalid Input\nPlease Enter 1-7");
                            break;
                    }
                    ShowMenuActions();
                    useraction = GetUserActionInput();
                }
                Console.WriteLine("Logging Out...");
                SignUpOrLogIn();
            }
        }

        static void ShowMenuActions()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("MENU");

            foreach (string action in MenuActions)
            {
                Console.WriteLine(action);
            }
        }

        static void ShowViewMenuActions()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("VIEW");
            foreach (string action in ViewActions)
            {
                Console.WriteLine(action);
            }
        }

        static void ShowSearchMenuActions()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("SEARCH");
            foreach (string action in SearchActions)
            {
                Console.WriteLine(action);
            }
        }

        static void ShowLogInOrSignUpActions()
        {
            Console.WriteLine("\n-------------------");

            foreach (string accountAction in AccountActions)
            {
                Console.WriteLine(accountAction);
            }
        }

        static string GetUserActionInput()
        {
            Console.Write("\nACTION: ");
            string userAction = Console.ReadLine();
            return userAction;
        }

        static string GetUserAnimeInput()
        {
            string UserAnime = Console.ReadLine();
            return UserAnime;
        }

        static void AddAnime()
        {
            string action = "Add";
            do
            {
                string UserAnimeInput = string.Empty;
                string Genre = string.Empty;
                string ReleaseDate = string.Empty;
                bool isValidInput = false;

                do
                {
                    Console.Write("\nAnime to Add: ");
                    UserAnimeInput = GetUserAnimeInput();

                    if (businessLogic.GetAnimeByName(currentUser, UserAnimeInput) != null)
                    {
                        Console.WriteLine(UserAnimeInput + " is already in the List");
                        ViewList();
                        break;
                    }

                    Console.Write("Genre: ");
                    Genre = Console.ReadLine();
                    Console.Write("Release Year: ");
                    ReleaseDate = Console.ReadLine();

                    if (string.IsNullOrEmpty(UserAnimeInput) || string.IsNullOrEmpty(Genre) || string.IsNullOrEmpty(ReleaseDate))
                    {
                        Console.WriteLine("\nPlease Enter Anime, Genre and Release Year");
                        return;
                    }
                    else
                    {
                        AnimeList newAnime = new AnimeListFrame.AnimeList
                        {
                            AccountID = currentUser.AccountID,
                            Name = UserAnimeInput.Trim(),
                            Genre = Genre.Trim(),
                            ReleaseYear = ReleaseDate.Trim(),
                            IsWatched = false,
                        };

                        businessLogic.AddAnime(newAnime);
                        Console.WriteLine(UserAnimeInput + " Added");

                        isValidInput = true;
                        ViewList();
                    }
                } while (isValidInput == false);

            } while (Again(action));
        }

        static void DeleteAnime()
        {
            var animeList = businessLogic.GetUserAnimeList(currentUser);

            if (animeList == null || animeList.Count == 0)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }

            string action = "Delete";
            do
            {
                ViewList();

                Console.Write("\nAnime to Delete: ");
                string UserAnimeInput = GetUserAnimeInput();

                if (!string.IsNullOrEmpty(UserAnimeInput))
                {
                    var anime = businessLogic.GetAnimeByName(currentUser, UserAnimeInput);
                    
                    if (anime != null)
                    {
                        businessLogic.DeleteAnime(anime);
                        Console.WriteLine(UserAnimeInput + " Deleted");
                        ViewList();
                    }
                    else
                    {
                        Console.WriteLine("\n" + UserAnimeInput + " is not in the list");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }
            } while (Again(action));
        }

        static void MarkasWatched()
        {
            if (businessLogic.GetUserAnimeList(currentUser) == null)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }

            string action = "Mark as Watched";
            do
            {

                if (businessLogic.GetAnimeToWatchedList(currentUser) == null)
                {
                    Console.WriteLine("\nAll Anime has been Marked as Watched");
                    return;
                }

                Console.Write("\nMark as Watched: ");
                string UserAnimeInput = GetUserAnimeInput().Trim();

                if (!string.IsNullOrEmpty(UserAnimeInput))
                {
                    var anime = businessLogic.GetAnimeByName(currentUser, UserAnimeInput);

                    var animeID = anime.AnimeID;

                    if (anime != null)
                    {
                        if (businessLogic.GetAnimeStatusIsWatched(currentUser, animeID))
                        {
                            Console.WriteLine(UserAnimeInput + " is already in your Watched List");
                        }
                        else
                        {
                            DateTime dateTime = DateTime.Now;
                            string formattedDate = dateTime.ToString("MMMM d, yyyy h:mm tt");

                            string rating = GetRating();
                            var markAsWatchedAnime = new AnimeListFrame.AnimeList
                            {
                                AnimeID = animeID,
                                AccountID = currentUser.AccountID,
                                Name = UserAnimeInput.Trim(),
                                IsWatched = true,
                                DateAndTime = formattedDate,
                                Ratings = rating
                            };

                            businessLogic.MarkAnimeAsWatched(markAsWatchedAnime);
                            Console.WriteLine("\n" + UserAnimeInput + " has been Marked as Watched");
                            ViewList();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n" + UserAnimeInput + " is not in the list");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }
            }
            while (Again(action));

        }

        static string GetRating()
        {
            string rating;
            Console.Write("\nRate the Anime from 1-5" +
                "\n1 Lowest\t5 Highest" +
                "\nRating: ");
            rating = Console.ReadLine();

            while (string.IsNullOrEmpty(rating) || (rating != "1" && rating != "2" && rating != "3" && rating != "4" && rating != "5"))
            {

                Console.WriteLine("\n-------------------------------" +
                    "\nPlease Enter a Rating from 1-5");
                rating = GetRating();

            }

            return rating;
        }

        static void ViewList()
        {
            if (businessLogic.GetUserAnimeList(currentUser) == null)
            {
                Console.WriteLine("\nAnime List is Empty");
            }
            else
            {
                Console.WriteLine("\nAnime List:");
                foreach (var anime in businessLogic.GetUserAnimeList(currentUser))
                {
                    string watchedStatus;
                    if (anime.IsWatched)
                    {
                        watchedStatus = "[Watched - " + anime.DateAndTime + "] Rating: " + anime.Ratings + " stars";
                    }
                    else
                    {
                        watchedStatus = "[Not Watched]";
                    }
                    Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ") " + watchedStatus);
                }
            }

        }

        static void ViewToWatchedList()
        {
            if (businessLogic.GetAnimeToWatchedList(currentUser) == null)
            {
                Console.WriteLine("\nTo-Watch List is Empty");
            }
            else
            {
                Console.WriteLine("\nTo-Watch List:");
                foreach (var anime in businessLogic.GetAnimeToWatchedList(currentUser))
                {

                    Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ")" + " [Not Watched]");

                }
            }
        }

        static void ViewWatchedList()
        {
            if (businessLogic.GetAnimeWatchedList(currentUser) == null)
            {
                Console.WriteLine("Watched List is Empty");
            }
            else
            {
                Console.WriteLine("\nWatched List:");
                foreach (var anime in businessLogic.GetAnimeWatchedList(currentUser))
                {

                    Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ") [Watched  - " + anime.DateAndTime + "] Rating: " + anime.Ratings + " stars");

                }
            }
        }

        static void SearchByName()
        {
            if (businessLogic.GetUserAnimeList(currentUser) == null)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            string action = "Search";
            do
            {
                Console.Write("Search Anime By Name: ");
                string AnimeName = GetUserAnimeInput();
                if (!string.IsNullOrEmpty(AnimeName))
                {
                    if (businessLogic.GetAnimeByName(currentUser, AnimeName) != null)
                    {
                        var anime = businessLogic.GetAnimeByName(currentUser, AnimeName);

                        string watchedStatus;
                        if (anime.IsWatched)
                        {
                            watchedStatus = "[Watched - " + anime.DateAndTime + "] Rating: " + anime.Ratings + " stars";
                        }
                        else
                        {
                            watchedStatus = "[Not Watched]";
                        }
                        Console.WriteLine("\n- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ") " + watchedStatus);

                    }
                    else
                    {
                        Console.WriteLine("\n" + AnimeName + " is NOT in the List");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }

            } while (Again(action));
        }

        static void SearchByGenre()
        {
            if (businessLogic.GetUserAnimeList(currentUser) == null)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            string action = "Search";
            do
            {
                Console.Write("Search Anime By Genre: ");
                string AnimeGenre = GetUserAnimeInput();
                if (!string.IsNullOrEmpty(AnimeGenre))
                {
                    if (businessLogic.GetAnimeByGenre(currentUser, AnimeGenre) != null)
                    {
                        foreach (var anime in businessLogic.GetAnimeByGenre(currentUser, AnimeGenre))
                        {
                            string watchedStatus;
                            if (anime.IsWatched)
                            {
                                watchedStatus = "[Watched - " + anime.DateAndTime + "] Rating: " + anime.Ratings + " stars";
                            }
                            else
                            {
                                watchedStatus = "[Not Watched]";
                            }
                            Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ") " + watchedStatus);

                        }

                    }
                    else
                    {
                        Console.WriteLine("\nThere is NO " + AnimeGenre + " Genre in the List");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }

            } while (Again(action));
        }

        static void SearchByReleaseYear()
        {
            if (businessLogic.GetUserAnimeList(currentUser) == null)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            string action = "Search";
            do
            {
                Console.Write("Search Anime By Release Year: ");
                string AnimeGenre = GetUserAnimeInput();
                if (!string.IsNullOrEmpty(AnimeGenre))
                {
                    if (businessLogic.GetAnimeByReleaseYear(currentUser, AnimeGenre) != null)
                    {
                        foreach (var anime in businessLogic.GetAnimeByReleaseYear(currentUser, AnimeGenre))
                        {
                            string watchedStatus;
                            if (anime.IsWatched)
                            {
                                watchedStatus = "[Watched - " + anime.DateAndTime + "] Rating: " + anime.Ratings + " stars";
                            }
                            else
                            {
                                watchedStatus = "[Not Watched]";
                            }
                            Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ") " + watchedStatus);

                        }

                    }
                    else
                    {
                        Console.WriteLine("\nThere is NO " + AnimeGenre + " Release Year in the List");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }

            } while (Again(action));
        }

        static bool Again(string action)
        {
            while (true)
            {
                Console.Write("\n[Y/N] " + action + " Again? ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    return true;
                }
                else if (choice == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please Enter Y/N");
                }
            }
        }

        static void SignUpOrLogIn()
        {
            string useraccountAction;
            do
            {
                ShowLogInOrSignUpActions();
                useraccountAction = GetUserActionInput();

                switch (useraccountAction)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        SignUp();
                        break;
                    case "3":
                        Console.WriteLine("\nThank you for using the Program\nDomat-ol, Christine L.\nBSIT 2-1");
                        Console.WriteLine("\nExiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input\nPlease Enter 1 - 3");
                        break;
                }
            } while (useraccountAction != "1" && useraccountAction != "2");
        }

        static void LogIn()
        {
            Console.Write("Enter Email: ");
            string UserName = Console.ReadLine();

            Console.Write("Enter Password: ");
            string Password = Console.ReadLine();

            Accounts account = businessLogic.ValidateAccount(UserName, Password);

            if (account != null)
            {
                currentUser = account;
                isLoggedIn = true;
                Console.WriteLine("Log In Successful");
            }
            else
            {
                Console.WriteLine("FAILED: Account Doesn't Exist or Incorrect Password. Please try again.");
                SignUpOrLogIn();
            }

        }

        static void SignUp()
        {
            string UserName;
            string Password;
            string Name;

            do
            {
                Console.Write("Enter Name: ");
                Name = Console.ReadLine().Trim();
                Console.Write("Enter Email: ");
                UserName = Console.ReadLine().Trim();
                Console.Write("Enter Password: ");
                Password = Console.ReadLine().Trim();

                Accounts account = businessLogic.ValidateAccount(UserName, Password);

                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                {
                    Console.WriteLine("Please Enter Name, UserName and Password\n");
                }
                else if (account != null)
                {
                    Console.WriteLine("FAILED: Account already exists. Please Log In.\n");
                    LogIn();
                    return;
                }
                else
                {
                    Accounts newAccount = new Accounts
                    {
                        Name = Name,
                        Email = UserName,
                        Password = Password
                    };

                    businessLogic.AddAccount(newAccount);
                    Console.WriteLine("Account Created Successfully");
                    Console.WriteLine("Please Log In\n");
                    LogIn();
                    return;
                }
            } while (true);
        }

        static void DeleteAccount()
        {
            string UserName;
            string Password;
            Console.Write("Enter Email: ");
            UserName = Console.ReadLine();
            Console.Write("Enter Password: ");
            Password = Console.ReadLine();

            Accounts account = businessLogic.ValidateAccount(UserName, Password);

            if (account != null)
            {
                Console.Write("[Yes/No] Are you sure? ");
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "no")
                {
                    Console.WriteLine("Account Deletion Cancelled");
                    return;
                }
                else if (confirm == "yes")
                {
                    businessLogic.DeleteAccount(account);
                    Console.WriteLine("Account Deleted Successfully");
                    SignUpOrLogIn();
                }
                else
                {
                    Console.WriteLine("Invalid Input\nPlease Enter Yes/No");
                    DeleteAccount();
                    return;
                }
            }
            else
            {
                Console.WriteLine("FAILED: Account Doesn't Exist or Incorrect Password. Please try again.");
                return;
            }
        }
    }
}

