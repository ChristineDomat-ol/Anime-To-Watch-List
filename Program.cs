﻿using System.Linq;
    
namespace Anime_To_Watch_List
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //add anime, delete anime, mark anime as watched, view anime list, exit

            Console.WriteLine("Welcome to To-Watch Anime List");

            List<string> list = new List<string>();
            string transactionchoice;
            do
            {
                Console.WriteLine("\n[1] Add Anime\n[2] Delete Anime\n[3] Mark as Watched\n[4] View Anime List\n[5] EXIT");

                Console.Write("\nACTIONS: ");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    string addchoice;

                    do
                    {
                        Console.Write("\nAdd Anime: ");
                        string addanime = Console.ReadLine();

                        if (list.Contains(addanime))
                        {
                            Console.WriteLine(addanime + " is already in the List");

                        }

                        else
                        {
                            list.Add(addanime);
                            Console.WriteLine(addanime + " Added");
                        }

                        do
                        {
                            Console.Write("\n[Y/N] Add again?: ");
                            addchoice = Console.ReadLine().ToLower();
                        } while (addchoice != "y" && addchoice != "n");

                        

                    } while (addchoice == "y");


                }
                else if (action == "2")
                {
                    string delchoice;
                    do
                    {
                        Console.Write("\nDelete Anime: ");
                        string delanime = Console.ReadLine();
                        if (list.Contains(delanime))
                        {
                            list.Remove(delanime);
                            Console.WriteLine(delanime + " Deleted");
                        }
                        else
                        {
                            Console.WriteLine("\n" + delanime + " is not in the list");
                        }

                        do
                        {
                            Console.Write("\n[Y/N] Delete Again?: ");
                            delchoice = Console.ReadLine().ToLower();
                        } while (delchoice != "y" && delchoice != "n");

                    } while (delchoice == "y");
                }
                else if (action == "3")
                {
                    string watchoice;
                    do
                    {
                        Console.Write("\nMark as Watched: ");
                        string watchanime = Console.ReadLine();
                        if (list.Contains(watchanime))
                        {
                            list.Remove(watchanime);
                            list.Add(watchanime + " - Watched");
                            Console.WriteLine(watchanime + " has been Marked as Watched");
                        }
                        else
                        {
                            Console.WriteLine("\n" + watchanime + " is not in the list");
                        }
                        do
                        {
                            Console.Write("\n[Y/N] Mark as Watched Again?: ");
                            watchoice = Console.ReadLine().ToLower();
                        } while (watchoice != "y" && watchoice != "n");

                    } while (watchoice == "y");
                }
                else if (action == "4")
                {
                    if (list.Count == 0)
                    {
                        Console.WriteLine("List is Empty");
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
                else if (action == "5")
                {
                    Console.WriteLine("\nThank you for using the Program\nDomat-ol, Christine L.\nBSIT 2-1");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                do
                {
                    Console.Write("\n[Y/N] Do another transaction?: ");
                    transactionchoice = Console.ReadLine().ToLower();
                } while (transactionchoice != "y" && transactionchoice != "n");

            } while (transactionchoice == "y");

            Console.WriteLine("\nThank you for using the Program\nDomat-ol, Christine L.\nBSIT 2-1");


        }
    }
}
