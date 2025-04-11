using AccountFrame;
using BusinessLogic;
using DataLogic;

namespace Anime_To_Watch_List
{
    public class Program
    {
        static string[] actions = new string[] {
            "[1] Add Anime",
            "[2] Delete Anime",
            "[3] Search Anime",
            "[4] View Anime List",
            "[5] Mark as Watched",
            "[6] Log Out",
            "[7] EXIT"
        };

        static string[] accountActions = new string[] {
            "[1] Log In",
            "[2] Sign Up"
        };

        static BusinessLogic.AnimeBusinessLogic businessLogic = new BusinessLogic.AnimeBusinessLogic();
        static Accounts currentUser;
        static bool isLoggedIn = false;

        static void Main(string[] args)
        {
            Console.WriteLine("\tMy Anime Manager");

            SignUpOrLogIn();

            while (isLoggedIn == true)
            {
                ShowActions();
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
                            Search();
                            break;
                        case "4":
                            View();
                            break;
                        case "5":
                            MarkasWatched();
                            break;
                        case "6":
                            Console.WriteLine("Logging Out...");
                            SignUpOrLogIn();
                            break;
                        default:
                            Console.WriteLine("Invalid Input\nPlease Enter 1-6");
                            break;
                    }
                    ShowActions();
                    useraction = GetUserActionInput();
                }
                Console.WriteLine("\nThank you for using the Program\nDomat-ol, Christine L.\nBSIT 2-1");
                Environment.Exit(0);
            }
        }

        static void ShowActions()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("MENU");

            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static void ShowAccountActions()
        {
            Console.WriteLine("\n-------------------");

            foreach (string accountAction in accountActions)
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
                Console.Write("Anime to Add: ");
                string UserAnimeInput = GetUserAnimeInput();
                Console.Write("Genre: ");
                string Genre = Console.ReadLine();
                Console.Write("Release Year: ");
                string ReleaseDate = Console.ReadLine();

                if (!string.IsNullOrEmpty(UserAnimeInput))
                {
                    if (AnimeBusinessLogic.IsAnimeInList(currentUser, UserAnimeInput))
                    {
                        Console.WriteLine(UserAnimeInput + " is already in the List");
                    }

                    else
                    {
                        businessLogic.AddAnime(currentUser, UserAnimeInput, Genre, ReleaseDate);
                        Console.WriteLine(UserAnimeInput + " Added");
                        View();
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }
            } while (Again(action));
        }

        static void DeleteAnime()
        {
            if (businessLogic.IsAnimeListEmpty(currentUser))
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            else
            {
                string action = "Delete";
                do
                {
                    Console.Write("Anime to Delete: ");
                    string UserAnimeInput = GetUserAnimeInput();

                    if (!string.IsNullOrEmpty(UserAnimeInput))
                    {
                        if (AnimeBusinessLogic.IsAnimeInList(currentUser, UserAnimeInput))
                        {
                            businessLogic.DeleteAnime(currentUser, UserAnimeInput);
                            Console.WriteLine(UserAnimeInput + " Deleted");
                            View();
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
        }

        static void MarkasWatched()
        {
            if (businessLogic.IsAnimeListEmpty(currentUser))
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }

            string action = "Mark as Watched";
            do
            {
                View();
                Console.Write("Mark as Watched: ");
                string watchanime = GetUserAnimeInput();

                if (!string.IsNullOrEmpty(watchanime))
                {
                    if (AnimeBusinessLogic.IsAnimeInList(currentUser, watchanime))
                    {
                        businessLogic.MarkAnimeAsWatched(currentUser, watchanime);
                        Console.WriteLine(watchanime + " has been Marked as Watched");
                        View();
                    }
                    else
                    {
                        Console.WriteLine("\n" + watchanime + " is not in the list");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }
            }
            while (Again(action));

        }

        static void View()
        {
            if (businessLogic.IsAnimeListEmpty(currentUser))
            {
                Console.WriteLine("\nList is Empty");
            }
            else
            {
                Console.WriteLine("\nAnime List:");
                foreach (var anime in businessLogic.GetUserAnimeList(currentUser))
                {
                    string watchedStatus;
                    if (anime.IsWatched)
                    {
                        watchedStatus = "[Watched]";
                    }
                    else
                    {
                        watchedStatus = "[Not Watched]";
                    }
                    Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ") " + watchedStatus);
                }
            }
        }

        static void Search()
        {
            if (businessLogic.IsAnimeListEmpty(currentUser))
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            string action = "Search";
            do
            {
                Console.Write("Search Anime: ");
                string AnimeName = GetUserAnimeInput();
                if (!string.IsNullOrEmpty(AnimeName))
                {
                    if (AnimeBusinessLogic.IsAnimeInList(currentUser, AnimeName))
                    {
                        Console.WriteLine("\n" + AnimeName + " is IN the List");
                        foreach (var anime in businessLogic.GetUserAnimeList(currentUser))
                        {
                            if (anime.Name == AnimeName)
                            {
                                Console.WriteLine("- " + anime.Name + " (" + anime.Genre + ", " + anime.ReleaseYear + ")");
                            }
                        }
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
                ShowAccountActions();
                useraccountAction = GetUserActionInput();

                switch (useraccountAction)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        SignUp();
                        break;
                    default:
                        Console.WriteLine("Invalid Input\nPlease Enter 1 or 2");
                        break;
                }
            } while (useraccountAction != "1" && useraccountAction != "2");
        }

        static void LogIn()
        {
            string UserName;
            string Password;

            Console.Write("Enter UserName: ");
            UserName = Console.ReadLine();

            Console.Write("Enter Password: ");
            Password = Console.ReadLine();
                
                Accounts account = businessLogic.ValidateAccount(UserName, Password); 
                if (account != null)
                {
                    currentUser = account;
                    isLoggedIn = true;
                    Console.WriteLine("Log In Successful");
                }
                else
                {
                    Console.WriteLine("FAILED: Incorrect UserName or Password. Please try again.");
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
                Console.Write("Enter UserName: ");
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
                else if (businessLogic.DoesUserNameExists(UserName))
                {
                    Console.WriteLine("FAILED: UserName already exists. Please try again.\n");
                }
                else
                {
                    businessLogic.AddAccount(Name, UserName, Password);
                    Console.WriteLine("Account Created Successfully");
                    Console.WriteLine("Please Log In\n");
                    LogIn();
                    return;
                }
            } while (true);
        }
    }
}
