﻿using AnimeListProcesses;

namespace Anime_To_Watch_List
{
    //UI Logic
    public class Program
    {
        static string[] actions = new string[] {
            "[1] Add Anime",
            "[2] Delete Anime",
            "[3] Search Anime",
            "[4] View Anime List",
            "[5] Mark as Watched",
            "[6] EXIT"
        };

        static void Main(string[] args)
        {
            //add anime, delete anime, mark anime as watched, search anime, view anime list, exit
            Console.WriteLine("My Anime Manager");

            ShowActions();
            string useraction = GetUserActionInput();

            while (useraction != "6")
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
                    default:
                        Console.WriteLine("Invalid Input\nPlease Enter 1-6");
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
        static string GetUserActionInput()
        {
            Console.Write("\nACTION: ");
            string userAction = Console.ReadLine();
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
            string action = "Add";
            do
            {
                Console.Write("Anime to Add: ");
                string UserAnimeInput = GetUserAnimeInput();

                if (!string.IsNullOrEmpty(UserAnimeInput))
                {
                    if (AnimeBusinessDataLogic.AnimeIsInList(UserAnimeInput))
                    {
                        Console.WriteLine(UserAnimeInput + " is already in the List");
                    }

                    else
                    {
                        AnimeBusinessDataLogic.AddAnime(UserAnimeInput);
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

        //Delete
        static void DeleteAnime()
        {
            if (AnimeBusinessDataLogic.EmptyList())
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
                        if (AnimeBusinessDataLogic.AnimeIsInList(UserAnimeInput))
                        {
                            AnimeBusinessDataLogic.DeleteAnime(UserAnimeInput);
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

        //Mark as Watched
        static void MarkasWatched()
        {
            if (AnimeBusinessDataLogic.EmptyList())
            {
                Console.WriteLine("List is Empty, Please Add an Anime First");
                return;
            }

            string action = "Mark as Watched";
            do
            {
                Console.Write("Mark as Watched: ");
                string watchanime = GetUserAnimeInput();

                if (!string.IsNullOrEmpty(watchanime))
                {
                    if (AnimeBusinessDataLogic.AnimeIsInList(watchanime))
                    {
                        AnimeBusinessDataLogic.MarkAnimeAsWatched(watchanime);
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

        //View List
        static void View()
        {
            if (AnimeBusinessDataLogic.EmptyList())
            {
                Console.WriteLine("\nList is Empty");
            }
            else
            {
                Console.WriteLine("\nAnime List:");
                foreach (string AnimeName in AnimeBusinessDataLogic.animelist)
                {
                    Console.WriteLine(AnimeName);
                }
            }
        }

        //Search
        static void Search()
        {
            if (AnimeBusinessDataLogic.EmptyList())
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
                    if (AnimeBusinessDataLogic.AnimeIsInList(AnimeName))
                    {
                        Console.WriteLine("\n" + AnimeName + " is IN the List");
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

        //Ask the user to repeat the action
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
    }
}
