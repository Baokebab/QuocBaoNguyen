namespace QBNsite.Helper
{
    public enum SpellSlot
    {   
        P,
        Q,
        W,
        E,
        R,
        Error
    }

    public enum SpellAttribute
    {
        HardCC,
        SoftCC,
        Shield,
        Boost,
        Dash,
        Blink,
        Other
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
    }
    public class ChampionsDetails
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string IconLink { get; set; } = "";
        public List<Spell> Spells { get; set; } = new List<Spell>();
    }
    public class PassiveDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ImageDto Image { get; set; } = new();
    }
    public class ImageDto
    {
        public string full { get; set; } = "";
    }
    public class SpellDto
    {   
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public SpellDto(string id, string name, string description) 
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
    public class Spell
    {
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public SpellSlot Slot { get; set; } = SpellSlot.Error;
        public List<SpellAttribute> SpellAttributes { get; set; } = new List<SpellAttribute>();

        public string IconLink { get; set; } = ""; 
        public string VideoLink { get; set; } = "";
        public Spell() { }
        public Spell(string SpellSlot, string Name, string Id, string Description, string Tooltip, string iconLink, string VideoLink)
        {
            if (Enum.TryParse(SpellSlot.Remove(1), out SpellSlot slot))
            {
                this.Slot = slot;
            }
            this.Id = Id;
            this.Name = Name; 
            this.Description = Description;
            this.Tooltip = Tooltip;
            this.IconLink = iconLink;
            this.VideoLink = VideoLink;
        }
    }
}
