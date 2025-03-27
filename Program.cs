using AnimeListProcesses;
using System.Threading.Channels;

namespace Anime_To_Watch_List
{
    //UI Logic
    public class Program
    {
        static string[] actions = new string[] { "[1] Add Anime", "[2] Delete Anime", "[3] Mark as Watched", "[4] View Anime List", "[5] Search Anime", "[6] EXIT" };

        static void Main(string[] args)
        {

            //add anime, delete anime, mark anime as watched, search anime, view anime list, exit

            Console.WriteLine("My Anime List");

            ShowActions();
            int useraction = GetUserActionInput();

            while (useraction != 6)
            {
                switch (useraction)
                {
                    case 1:
                        AddAnime();
                        break;
                    case 2:
                        DeleteAnime();
                        break;
                    case 3:
                        MarkasWatched();
                        break;
                    case 4:
                        View();
                        break;
                    case 5:
                        Search();
                        break;
                    default:
                        Console.WriteLine("Invalid Input\nPlease Enter 1-5");
                        break;
                }
                ShowActions();
                useraction = GetUserActionInput();
            }
            Console.WriteLine("\nThank you for using the Program\nDomat-ol, Christine L.\nBSIT 2-1");
        }

        // Menu
        static void ShowActions()
        {
            Console.WriteLine("\n-------------------");
            Console.WriteLine("MENU");

            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }
        }

        //Gets user action input
        static int GetUserActionInput()
        {
            Console.Write("\nACTION: ");
            int userAction = Convert.ToInt16(Console.ReadLine());
            return userAction;
        }

        //Gets user anime title input
        static string GetUserAnimeInput()
        {
            string UserAnime = Console.ReadLine();
            return UserAnime;
        }

        //Add
        static void AddAnime()
        {
            do
            {
                Console.Write("Anime to Add: ");
                string UserAnimeInput = GetUserAnimeInput();
                    
                if (!string.IsNullOrEmpty(UserAnimeInput))
                {
                    if (BusinessDataLogic.AnimeIsInList(UserAnimeInput))
                    {
                        Console.WriteLine(UserAnimeInput + " is already in the List");
                    }   

                    else
                    {
                        BusinessDataLogic.AddAnime(UserAnimeInput);
                        Console.WriteLine(UserAnimeInput + " Added");
                        View();
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Anime");
                }
            } while (Again());
        }

        //Delete
        static void DeleteAnime()
        {
            if (BusinessDataLogic.list.Count == 0)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            else
            {
                do
                {
                    Console.Write("Anime to Delete: ");
                    string UserAnimeInput = GetUserAnimeInput();

                    if (!string.IsNullOrEmpty(UserAnimeInput))
                    {
                        if (BusinessDataLogic.AnimeIsInList(UserAnimeInput))
                        {
                            BusinessDataLogic.DeleteAnime(UserAnimeInput);
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
                } while (Again());
            }
        }

        //Mark as Watched
        static void MarkasWatched()
        {
            if (BusinessDataLogic.list.Count == 0)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }

            do
            {
                Console.Write("Mark as Watched: ");
                string watchanime = GetUserAnimeInput();

                if (!string.IsNullOrEmpty(watchanime))
                {
                    if (BusinessDataLogic.AnimeIsInList(watchanime))
                    {
                        BusinessDataLogic.MarkAnimeAsWatched(watchanime);
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
            while (Again());

        }

        //View List
        static void View()
        {
            if (BusinessDataLogic.list.Count == 0)
            {
                Console.WriteLine("\nList is Empty");
            }
            else
            {
                Console.WriteLine("\nAnime List:");
                foreach (string AnimeName in BusinessDataLogic.list)
                {
                    Console.WriteLine(AnimeName);
                }
            }
        }

        //Search
        static void Search()
        {            
            Console.Write("Search Anime: ");
            string AnimeName = GetUserAnimeInput();

            if (BusinessDataLogic.AnimeIsInList(AnimeName))
            {
                Console.WriteLine("\n" + AnimeName + " Is in the List");
            }
            else
            {
                Console.WriteLine("\n" + AnimeName + " Is Not in the List");
            }
        }

        //Ask the user to repeat the action
        static bool Again()
        {
            while (true)
            {
                Console.Write("\n[Y/N] Again? ");
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
    }
}
