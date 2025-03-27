namespace AnimeListProcesses
{
    public class BusinessDataLogic
    {
        public static List<string> list = new List<string>();

        //Searches if the anime is in the list
        public static bool AnimeIsInList(string AnimeName)
        {
            return list.Contains(AnimeName);
        }

        //Adds the Anime in the List
        public static void AddAnime(string AnimeName)
        {
            list.Add(AnimeName);
        }

        //Deletes the Anime in the List
        public static void DeleteAnime(string AnimeName)
        {
            list.Remove(AnimeName);
        }

        //Marks the Anime as "Watched"
        public static void MarkAnimeAsWatched(string AnimeName)
        {
            int index = list.IndexOf(AnimeName);
            list[index] = AnimeName + " - Watched";
        }
    }
}
