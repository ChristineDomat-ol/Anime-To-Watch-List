namespace AnimeListProcesses
{
    public class AnimeBusinessDataLogic
    {
        public static List<string> animelist = new List<string>();

        //Searches if the anime is in the list
        public static bool AnimeIsInList(string AnimeName)
        {
            return animelist.Contains(AnimeName);
        }

        //Adds the Anime in the List
        public static void AddAnime(string AnimeName)
        {
            animelist.Add(AnimeName);
        }

        //Deletes the Anime in the List
        public static void DeleteAnime(string AnimeName)
        {
            animelist.Remove(AnimeName);
        }

        //Marks the Anime as "Watched"
        public static void MarkAnimeAsWatched(string AnimeName)
        {
            int index = animelist.IndexOf(AnimeName);
            animelist[index] = AnimeName + " - Watched";
        }

        //checks if the list is empty
        public static bool EmptyList()
        {
            return animelist.Count == 0;
        }
    }
}
