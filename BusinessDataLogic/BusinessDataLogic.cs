namespace AnimeListProcesses
{
    public class BusinessDataLogic
    {
        public static List<string> list = new List<string>();


        public static bool AnimeIsInList(string AnimeName)
        {
            return list.Contains(AnimeName);
        }

        public static void AddAnime(string AnimeName)
        {
            list.Add(AnimeName);
        }

        public static void DeleteAnime(string AnimeName)
        {
            list.Remove(AnimeName);
        }

        public static void MarkAnimeAsWatched(string AnimeName)
        {
            list.Remove(AnimeName);
            list.Add(AnimeName + " - Watched");
        }
    }
}
