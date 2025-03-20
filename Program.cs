
namespace Anime_To_Watch_List
{

    internal class Program
    {
        static List<string> list = new List<string>();
        static string[] actions = new string[] { "[1] Add Anime", "[2] Delete Anime", "[3] Mark as Watched", "[4] View Anime List", "[5] EXIT" };

        static void Main(string[] args)
        {

            //add anime, delete anime, mark anime as watched, view anime list, exit

            Console.WriteLine("Welcome to To-Watch Anime List");

            ShowActions();
            int action = GetUserInput();

            while (action != 5)
            {
                if (action == 1)
                {
                    AddorDelAnime(1);
                }
                else if (action == 2)
                {
                    AddorDelAnime(2);
                }
                else if (action == 3)
                {
                    MarkasWatched();
                }
                else if (action == 4)
                {
                    View();
                }
                else
                {
                    Console.WriteLine("Invalid Input\nPlease Enter 1-5");
                }
                ShowActions();
                action = GetUserInput();
            }
            Console.WriteLine("\nThank you for using the Program\nDomat-ol, Christine L.\nBSIT 2-1");
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

        static int GetUserInput()
        {
            Console.Write("\nACTION: ");
            int action = Convert.ToInt16(Console.ReadLine());
            return action;
        }

        static void AddorDelAnime(int userAction)
        {
            if (userAction == 1)
            {
                do
                {
                    Console.Write("Enter Anime to Add: ");
                    string useranimeinput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(useranimeinput))
                    {
                        if (list.Contains(useranimeinput))
                        {
                            Console.WriteLine(useranimeinput + " is already in the List");
                        }

                        else
                        {
                            list.Add(useranimeinput);
                            Console.WriteLine(useranimeinput + " Added");
                            View();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Enter Anime");
                    }
                } while (Again());
            }
            else if (userAction == 2)
            {
                if(list.Count == 0)
                {
                    Console.WriteLine("List is Empty, Please Add an Anime First");
                    return;
                }
                do
                {
                    Console.Write("Enter Anime to Delete: ");
                    string useranimeinput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(useranimeinput))
                    {
                        if (list.Contains(useranimeinput))
                        {
                            list.Remove(useranimeinput);
                            Console.WriteLine(useranimeinput + " Deleted");
                            View();
                        }
                        else
                        {
                            Console.WriteLine("\n" + useranimeinput + " is not in the list");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Enter Anime");
                    }
                } while (Again());
            }
        }

        static void MarkasWatched()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }
            do
            {
                Console.Write("\nMark as Watched: ");
                string watchanime = Console.ReadLine();
                if (!string.IsNullOrEmpty(watchanime))
                {
                    if (list.Contains(watchanime))
                    {
                        list.Remove(watchanime);
                        list.Add(watchanime + " - Watched");
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

        static void View()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\nList is Empty");
            }
            else
            {
                Console.WriteLine("\nAnime List:");
                foreach (string i in list)
                {
                    Console.WriteLine(i);
                }
            }
        }
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
