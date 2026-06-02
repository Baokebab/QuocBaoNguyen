namespace QBNsite.Helper
{
    public enum SpellSlot
    {
        P,
        Q,
        W,
        E,
        R,
        None
    }
    public enum SpellAttribute
    {
        Airborne,
        ForcedAction,
        Root,
        Sleep,
        Stasis,
        Stun,
        Supression,
        Polymorph,
        Slow,
        Cripple,
        Ground,
        Kinematics,
        Nearsight,
        Silence,
        Drowsy,
        Blind,
        AutoTargeted,
        DirectionFixedDistance,
        LocationTargeted,
        UnitTargeted,
        MiniUnitTargeted,
        TerrainTargeted,
        Blink,
        Reset,
        Execute,
        Finisher,
        InvulnerabilityUntargetableVanished,
        BlockedByChampion,
        BlockedByMinion,
        BlocksAuto,
        BlocksProjectiles,
        MultipleCharges,
        MovementsBuff,
        PointAndClick
    }

    public static class SpellGroups
    {
        public static readonly List<SpellAttribute> HardCC = new()
    {
        SpellAttribute.Airborne,
        SpellAttribute.ForcedAction,
        SpellAttribute.Root,
        SpellAttribute.Sleep,
        SpellAttribute.Stasis,
        SpellAttribute.Stun,
        SpellAttribute.Supression,
        SpellAttribute.Polymorph,
    };
        public static readonly List<SpellAttribute> SoftCC = new()
    {
        SpellAttribute.Slow,
        SpellAttribute.Cripple,
        SpellAttribute.Ground,
        SpellAttribute.Kinematics,
        SpellAttribute.Nearsight,
        SpellAttribute.Silence,
        SpellAttribute.Drowsy,
        SpellAttribute.Blind,
    };
        public static readonly List<SpellAttribute> CC = new()
        {
            SpellAttribute.Airborne,
            SpellAttribute.ForcedAction,
            SpellAttribute.Root,
            SpellAttribute.Sleep,
            SpellAttribute.Stasis,
            SpellAttribute.Stun,
            SpellAttribute.Supression,
            SpellAttribute.Polymorph,
            SpellAttribute.Slow,
            SpellAttribute.Cripple,
            SpellAttribute.Ground,
            SpellAttribute.Kinematics,
            SpellAttribute.Nearsight,
            SpellAttribute.Silence,
            SpellAttribute.Drowsy,
            SpellAttribute.Blind,
        };
        public static readonly List<SpellAttribute> Dash = new()
    {
        SpellAttribute.AutoTargeted,
        SpellAttribute.DirectionFixedDistance,
        SpellAttribute.LocationTargeted,
        SpellAttribute.UnitTargeted,
        SpellAttribute.MiniUnitTargeted,
        SpellAttribute.TerrainTargeted,
        SpellAttribute.Blink,
    };

        public static string ToFriendlyString(this SpellAttribute s) =>
        s switch
        {
            SpellAttribute.ForcedAction => "Forced Action",
            SpellAttribute.AutoTargeted => "Auto Targeted",
            SpellAttribute.DirectionFixedDistance => "Direction and Fixed Distance",
            SpellAttribute.LocationTargeted => "Location Targeted",
            SpellAttribute.UnitTargeted => "Unit Targeted",
            SpellAttribute.MiniUnitTargeted => "Mini Unit Targeted",
            SpellAttribute.TerrainTargeted => "Terrain Targeted",
            SpellAttribute.InvulnerabilityUntargetableVanished => "Invulnerability / Untargetable / Vanished",
            SpellAttribute.BlockedByChampion => "Blocked By Champion",
            SpellAttribute.BlockedByMinion => "Blocked By Minion",
            SpellAttribute.BlocksAuto => "Blocks Auto",
            SpellAttribute.BlocksProjectiles => "Blocks Projectiles",
            SpellAttribute.MultipleCharges => "Multiple Charges",
            SpellAttribute.MovementsBuff => "Movements Buff",
            _ => s.ToString()
        };
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
    public class PassiveDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ImageDto Image { get; set; } = new();
    }
    public class Spell
    {
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public SpellSlot Slot { get; set; } = SpellSlot.None;
        public List<SpellAttribute> SpellAttributes { get; set; } = new List<SpellAttribute>();

        public string IconLink { get; set; } = "";
        public string VideoLink { get; set; } = "";
        public string VideoLinkWebm => VideoLink.Replace(".mp4", ".webm");
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