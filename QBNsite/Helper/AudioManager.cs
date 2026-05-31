namespace QBNsite.Helper
{
    public static class AudioManager
    {
        public static int GoodAnswerCount = 0;
        public static string GetAudioPathForCorrectAnswer(string homePath)
        {
            string baseAudioPath = "mp3/ValorantEvoriKill";

            if (GoodAnswerCount > 3)
            {
                return Path.Combine(homePath, baseAudioPath + "4.mp3");
            }
            else
            {
                return Path.Combine(homePath, baseAudioPath + GoodAnswerCount + ".mp3");
            }
        }

        public static string GetAudioPathForWrongAnswer(string homePath)
        {
            return Path.Combine(homePath, "mp3/ValorantVandal.mp3");
        }

    }
}
