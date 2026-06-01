namespace QBNsite.Helper
{
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
    public class ChampionsDetails
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string IconLink { get; set; } = "";
        public List<Spell> Spells { get; set; } = new List<Spell>();
        public int NumberOfSkins { get; set; } = 0; 
    }
    public class ImageDto
    {
        public string full { get; set; } = "";
    }
    public class SkinDto
    {

    }
}
