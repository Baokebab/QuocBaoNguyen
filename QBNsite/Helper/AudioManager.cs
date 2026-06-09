namespace QBNsite.Helper
{
    public static class AudioManager
    {
        const string Evori = "mp3/ValorantEvoriKill";
        const string Champions2024 = "mp3/Champions";
        const string Aemondir = "mpeg/Aemondir_Kill_";
        const string Arcane = "mpeg/Arcane_Kill_";
        const string Blackthron = "mpeg/Blackthorn";
        const string Champions = "mpeg/Champions_2023_Kill_";
        const string Champions2021 = "mpeg/Champions2021_";
        const string Chronovoid = "mpeg/ChronoVoid_Kill_";
        const string Elderflame = "mpeg/Elderflame_Kill_";
        const string Gaia = "mpeg/Gaia's_Vengeance_Kill_";
        const string Ion = "mpeg/Ion_Kill_";
        const string Kuronami = "mpeg/Kuronami_Kill_";
        const string Magepunk = "mpeg/Magepunk_Kill_";
        const string Mystbloom = "mpeg/Mystbloom_Kill_";
        const string Neptune = "mpeg/Neptune_Kill_";
        const string Oni = "mpeg/Oni";
        const string ORARaja = "mpeg/ORA_by_OneTap_Kill_RAJA_";
        const string OraIgnition = "mpeg/ORA_by_OneTap_Kill_Ignition_";
        const string Ora = "mpeg/ORA_by_OneTap_Kill_";
        const string OraWatch = "mpeg/ORA_by_OneTap_Kill_Watch_";
        const string OraRenegade = "mpeg/ORA_by_OneTap_Kill_RENEGADE_";
        const string Phaseguard = "mpeg/Phaseguard_Kill_";
        const string Prelude = "mpeg/Prelude_to_Chaos_Kill_";
        const string Primordium = "mpeg/Primordium_Kill_";
        const string Reaver = "mpeg/reaverkill";
        const string RGX = "mpeg/RGX_11z_Pro_Kill_";

        public static int GoodAnswerCount = 0;
        public static List<string> soundGroups = new List<string>()
        {
            Evori,
            Champions2024,
            Aemondir,
            Arcane,
            Blackthron,
            Champions,
            Champions2021,
            Chronovoid,
            Elderflame,
            Gaia,
            Ion,
            Kuronami,
            Magepunk,
            Mystbloom,
            Neptune,
            Oni,
            ORARaja,
            OraIgnition,
            Ora,
            OraWatch ,
            OraRenegade,
            Phaseguard,
            Prelude,
            Primordium,
            Reaver,
            RGX,
        };
        public static int currentSoundIndex = 0;
        public static string GetAudioPathForCorrectAnswer(string homePath)
        {
            string tempPath = soundGroups[currentSoundIndex] + (GoodAnswerCount + 1).ToString();
            string res = Path.Combine(homePath, CompleteExt(tempPath));

            if(GoodAnswerCount > 3)
            {
                int tempIndex = new Random().Next(soundGroups.Count);
                while(tempIndex == currentSoundIndex)
                {
                    tempIndex = new Random().Next(soundGroups.Count);
                }
                currentSoundIndex = tempIndex;
            }
            GoodAnswerCount = (GoodAnswerCount + 1) % 5;
            return res;
        }

        public static string CompleteExt(string soundPath)
        {
            switch (soundPath.Remove(3))
            {
                case "mp3":
                    return $"{soundPath}.mp3";
                case "mpe":
                    return $"{soundPath}.mpeg";
            }
            return soundPath;
        }

        public static string GetAudioPathForWrongAnswer(string homePath)
        {
            currentSoundIndex = new Random().Next(soundGroups.Count);
            GoodAnswerCount = 0;
            return Path.Combine(homePath, "mp3/ValorantVandal.mp3");
        }

        public static string GetAudioPathForHalfAnswer(string homePath)
        {
            currentSoundIndex = new Random().Next(soundGroups.Count);
            GoodAnswerCount = 0;
            return Path.Combine(homePath, "mp3/HalfCorrectShoot.mp3");
        }

    }
}
