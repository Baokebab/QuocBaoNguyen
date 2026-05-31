namespace QBNsite.Helper
{
    public static class AudioManager
    {
        public static int GoodAnswerCount = 0;
        public static string baseAudioPath = "mp3/ValorantEvoriKill";
        public static string GetAudioPathForCorrectAnswer(string homePath)
        {
            if(GoodAnswerCount > 3)
            {
                return Path.Combine(homePath, baseAudioPath + "4.mp3");
            }
            else
            {
                return Path.Combine(homePath, baseAudioPath + GoodAnswerCount + ".mp3");
            }
        }

    }
}
