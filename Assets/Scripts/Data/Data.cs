

namespace XmlDataSave
{
    public static class Data
    {
        public static int Score { get; private set; } = 0;

        public static void CollectScore()
        {
            Score++;
        }
    }
}
