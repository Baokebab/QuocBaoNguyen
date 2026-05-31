namespace QBNsite.Helper
{
    public class McqManager
    {
        public enum QuestionType
        {
            YesNo,
        }
        public class McqQuestion
        {
            public string Id { get; set; } = "";
            public QuestionType Type { get; set; }
            public string QuestionPrompt { get; set; } = "";
            public string[] Answers { get; set; } = new string[0];
            public bool[] CorrectAnswers { get; set; } = new bool[0];
            public string Commentary { get; set; } = "";
            public List<Spell> SpellsToShow { get; set; } = new List<Spell>();
        }
        public static McqQuestion GenerateBasicIsEffectPresentQuestion(ChampionsDetails champions)
        {
            var rnd = new Random();
            int questionType = rnd.Next(0, 3);
            string questionPrompt = "";
            string commentary = ""; 
            bool hasEffect = false;
            List<Spell> spellsToShow = new List<Spell>();

            //0 = hardCC, 1 = softCC, 2 = dash

            switch (questionType)
            {
                case 0:
                    questionPrompt = $"{champions.Name} possède‑t‑il un effet de Hard CC ?";
                    spellsToShow = GetHardCCSpells(champions.Spells);
                    hasEffect = spellsToShow.Count > 0;
                    commentary = hasEffect ? $"{champions.Name} a du Hard CC sur les sorts suivants : {string.Join(", ", spellsToShow.Select(x => x.Slot).ToList())}." : "";
                    break;
                case 1:
                    questionPrompt = $"{champions.Name} possède‑t‑il un sort appliquant un Soft CC ?";
                    spellsToShow = GetSoftCCSpells(champions.Spells);
                    hasEffect = spellsToShow.Count > 0;
                    commentary = hasEffect ? $"{champions.Name} a du soft CC sur les sorts suivants : {string.Join(", ", spellsToShow.Select( x => x.Slot).ToList())}." : "";
                    break;
                case 2:
                    questionPrompt = $"{champions.Name} possède‑t‑il un Dash?";
                    spellsToShow = GetDashSpells(champions.Spells);
                    hasEffect = spellsToShow.Count > 0;
                    commentary = hasEffect ? $"{champions.Name} peut dash avec les sorts suivants : {string.Join(", ", spellsToShow.Select(x => x.Slot).ToList())}." : "";
                    break;
            }

            return new McqQuestion
            {
                Id = champions.Name + "_" + questionType + "_BasicEffect" + "_" + questionType,
                Type = QuestionType.YesNo,
                QuestionPrompt = questionPrompt,
                Answers = new string[2] { "Oui", "Non" },
                CorrectAnswers = new bool[2] { hasEffect, !hasEffect },
                SpellsToShow = spellsToShow,
                Commentary = commentary
            };
        }

        public static bool HasHardCC(List<Spell> spell)
        {
            for(int i = 0 ; i < spell.Count; i++)
            {
                if (spell[i].SpellAttributes.Any(attr => SpellGroups.HardCC.Contains(attr)))
                {
                    return true;
                }
            }
            return false;
        }
        public static List<Spell> GetHardCCSpells(List<Spell> spell)
        {
            List<Spell> res = new List<Spell>();
            for (int i = 0; i < spell.Count; i++)
            {
                if (spell[i].SpellAttributes.Any(attr => SpellGroups.HardCC.Contains(attr)))
                {
                    res.Add(spell[i]);
                }
            }
            return res; 
        }
        public static bool HasSoftCC(List<Spell> spell)
        {
            for (int i = 0; i < spell.Count; i++)
            {
                if (spell[i].SpellAttributes.Any(attr => SpellGroups.SoftCC.Contains(attr)))
                {
                    return true;
                }
            }
            return false;
        }
        public static List<Spell> GetSoftCCSpells(List<Spell> spell)
        {
            List<Spell> res = new List<Spell>();
            for (int i = 0; i < spell.Count; i++)
            {
                if (spell[i].SpellAttributes.Any(attr => SpellGroups.SoftCC.Contains(attr)))
                {
                    res.Add(spell[i]);
                }
            }
            return res;
        }
        public static bool HasDash(List<Spell> spell)
        {
            for (int i = 0; i < spell.Count; i++)
            {
                if (spell[i].SpellAttributes.Any(attr => SpellGroups.Dash.Contains(attr)))
                {
                    return true;
                }
            }
            return false;
        }
        public static List<Spell> GetDashSpells(List<Spell> spell)
        {
            List<Spell> res = new List<Spell>();
            for (int i = 0; i < spell.Count; i++)
            {
                if (spell[i].SpellAttributes.Any(attr => SpellGroups.Dash.Contains(attr)))
                {
                    res.Add(spell[i]);
                }
            }
            return res;
        }
    }
}
