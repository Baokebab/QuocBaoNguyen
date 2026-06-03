namespace QBNsite.Helper
{
    public enum ChampionGenre
    {
        Male,
        Female,
    }
    public class ChampionRoot
    {
        public string Type { get; set; } = "";
        public string Format { get; set; } = "";
        public string Version { get; set; } = "";
        public Dictionary<string, ChampionDto> Data { get; set; } = new Dictionary<string, ChampionDto>();
    }
    public class ChampionDetailRoot
    {
        public Dictionary<string, ChampionsDetailsDto> Data { get; set; } = new Dictionary<string, ChampionsDetailsDto>();
    }
    public class ChampionDto
    {
        public string Version { get; set; } = "";
        public string Id { get; set; } = "";
        public string Key { get; set; } = "";
        public string Name { get; set; } = "";
        public ImageDto Image { get; set; } = new ImageDto();
    }
    public class ChampionsDetailsDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Key { get; set; }
        public PassiveDto Passive { get; set; } = new PassiveDto();
        public List<SpellDto> Spells { get; set; } = new List<SpellDto>();
        public List<SkinDto> Skins { get; set; } = new List<SkinDto>();
    }
    public class ChampionsCsvDetails
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } =  "";
        public ChampionGenre Genre { get; set; } = ChampionGenre.Male;

    }
    public class ChampionsDetails
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public ChampionGenre Genre { get; set; } = ChampionGenre.Male;
        public string IconLink { get; set; } = "";
        public List<Spell> Spells { get; set; } = new List<Spell>();
        public int NumberOfSkins { get; set; } = 0; 
        public List<MultipleChoiceQuestion> Mcq { get; set; } = new List<MultipleChoiceQuestion>();
        public bool IsLockedFromRandom { get; set; } = false; 
    }
    public class ImageDto
    {
        public string full { get; set; } = "";
    }
    public class SkinDto
    {

    }

    public static class ChampionsManager
    {
        public static List<ChampionsDetails> ChampionsData = new List<ChampionsDetails>();
        public static int GetRandomUnlockedChampionIndex(List<ChampionsDetails> champions, int currentIndex)
        {
            var validIndexes = new List<int>();
            for (int i = 0; i < champions.Count; i++)
            {
                if (!champions[i].IsLockedFromRandom)
                    validIndexes.Add(i);
            }
            if (validIndexes.Count == 0)
                return -1;
            int randomPos = new Random().Next(validIndexes.Count); 
            return validIndexes[randomPos];

        }
        public static int GetNextUnlockedChampionIndex(List<ChampionsDetails> champions, int currentIndex)
        {
            int count = champions.Count;
            int i = currentIndex;

            do
            {
                i = (i + 1) % count;
                if (!champions[i].IsLockedFromRandom)
                    return i;

            } while (i != currentIndex);

            return -1; 
        }
        public static string GetNextUnlockedChampionName(List<ChampionsDetails> champions, int currentIndex)
        {
            int count = champions.Count;
            int i = currentIndex;

            do
            {
                i = (i + 1) % count;
                if (!champions[i].IsLockedFromRandom)
                    return champions[i].Name;

            } while (i != currentIndex);

            return "All completed";
        }
    }

}
