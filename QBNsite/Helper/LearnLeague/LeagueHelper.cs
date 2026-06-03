using QBNsite.Resources.League;

namespace QBNsite.Helper
{
    public static class LeagueHelper
    {
        public static string baseUrl = "https://ddragon.leagueoflegends.com";
        public static string baseSpellVideoUrl = "https://lol.dyn.riotcdn.net/x/videos/champion-abilities";

        public static string csvUrl = "https://docs.google.com/spreadsheets/d/15MMcXOG5Jp-_1othPye3sLTA1N1T_0TOqsYlOkOOK-E/export?format=csv&gid=0";
        public static string champCsvUrl = "https://docs.google.com/spreadsheets/d/15MMcXOG5Jp-_1othPye3sLTA1N1T_0TOqsYlOkOOK-E/export?format=csv&gid=1527873599";
        
        public static string localCsvPath = "LoL/LolSpells.csv";
        public static string localChampionPath = "LoL/LolChampions.csv";
        public static string leagueVersion => $"{baseUrl}/api/versions.json";
        public static string GetCurrentVersionUrl(string version) => $"{baseUrl}/cdn/{version}"; 
        public static void test()
        {
            string? txt = LeagueLocales.ResourceManager.GetString("test");
        }
        public async static Task<Dictionary<string, List<SpellAttribute>>> LoadSpellCsvAttributes(HttpClient http, string path)
        {
            var result = new Dictionary<string, List<SpellAttribute>>();
            
            var csv = await http.GetStringAsync(path);
            var lines = csv.Split('\n');
            var headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                if (String.IsNullOrEmpty(lines[i]))
                    continue;

                var cols = lines[i].Split(',');
                string spellId = cols[1];
                var attributes = new List<SpellAttribute>();

                for (int c = 4; c < cols.Length; c++)
                {
                    if (Enum.TryParse(headers[c], out SpellAttribute attribute) && !String.IsNullOrEmpty(cols[c]))
                    {
                        attributes.Add(attribute);
                    }
                }
                result[spellId] = attributes;
            }
            return result;
        }

        public async static Task<Dictionary<string, ChampionsCsvDetails>> LoadChampionCsv(HttpClient http, string path)
        {
            var result = new Dictionary<string, ChampionsCsvDetails>();

            var csv = await http.GetStringAsync(path);
            var lines = csv.Split('\n');
            var headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                if (String.IsNullOrEmpty(lines[i]))
                    continue;

                var cols = lines[i].Split(',');

                if(Enum.TryParse(cols[2], out ChampionGenre genre))
                {
                    result[cols[1]] = new ChampionsCsvDetails()
                    {
                        Genre = genre
                    };
                }
            }
            return result;
        }
    }
}

