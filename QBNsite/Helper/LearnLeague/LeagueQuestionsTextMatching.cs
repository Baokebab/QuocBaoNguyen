using QBNsite.Resources.League;

namespace QBNsite.Helper
{
    public static class LeagueQuestionsTextMatching
    {
        public static Dictionary<List<SpellAttribute>, string> yesNoQuestionDict = new Dictionary<List<SpellAttribute>, string>()
        {
            { SpellGroups.HardCC, "HasHardCcQuestion_" },
            { SpellGroups.SoftCC, "HasSoftCcQuestion_" },
            { SpellGroups.Dash, "HasDashQuestion_" },
        };

        public static string yesNoAnswerPositive = "YesNoAnswerYes_";
        public static string yesNoAnswerNegative = "YesNoAnswerYes_";

        public static string GetWhatSpellHasThisEffectQuestionPrompt(SpellAttribute spellAttribute)
        {
            return GetLocalesString($"WhatSpellQuestion_{spellAttribute.ToString()}");
        }
        public static string GetWhatSpellHasThesesEffectsQuestionPrompt(string attributeName)
        {
            return GetLocalesString($"WhatSpellQuestion_Group_{attributeName}");
        }
        public static string GetWhatKindOfGroupEffectQuestionPrompt(string attributeName, string championName)
        {
            return GetLocalesString($"WhatKindEffectQuestion_Group_{attributeName}", championName);
        }
        public static string GetWhatSpellHasThisEffectAnswer(ChampionsDetails champions, SpellAttribute spellAttribute, HashSet<Spell> spellToShow)
        {
            string pronoun = champions.Genre == ChampionGenre.Male ? GetLocalesString("his") : GetLocalesString("her");
            string numeral = spellToShow.Count == 1 ? "Singular" : "Plural";
            string spellsSlot = string.Join(", ", spellToShow.Select(x => x.Slot));

            if (spellAttribute == SpellAttribute.AutoReset
                || spellAttribute == SpellAttribute.BlocksProjectiles
                || spellAttribute == SpellAttribute.Execute
                || spellAttribute == SpellAttribute.Finisher
                || spellAttribute == SpellAttribute.InvulnerabilityUntargetableVanished
                || spellAttribute == SpellAttribute.MagicShield
                || spellAttribute == SpellAttribute.MovementsBuff
                || spellAttribute == SpellAttribute.MultipleCharges
                || spellAttribute == SpellAttribute.NormalShield
                || spellAttribute == SpellAttribute.PhysicalShield
                || spellAttribute == SpellAttribute.Reset
                || spellAttribute == SpellAttribute.SpellShield
                || spellAttribute == SpellAttribute.AutoReset)
            {
                return GetLocalesString($"WhatSpellAnswer{numeral}_{spellAttribute.ToString()}", champions.Name, pronoun, spellsSlot);
            }
            else if (spellAttribute == SpellAttribute.BlockedByChampion
                || spellAttribute == SpellAttribute.BlockedByMinion)
            {
                return GetLocalesString($"WhatSpellAnswer{numeral}_{spellAttribute.ToString()}", pronoun, spellsSlot);
            }
            else if(spellAttribute == SpellAttribute.PointAndClick)
            {
                return GetLocalesString($"WhatSpellAnswer{numeral}_{spellAttribute.ToString()}", spellsSlot);
            }
            else
            {
                return GetLocalesString("WhatSpellAnswerNone", champions.Name, spellAttribute.ToFriendlyString());
            }
        }
        public static string GetWhatSpellHasThesesEffecstAnswer(ChampionsDetails champions, string attributeName, HashSet<Spell> spellToShow)
        {
            string pronoun = champions.Genre == ChampionGenre.Male ? GetLocalesString("his") : GetLocalesString("her");
            string spellsSlot = string.Join(", ", spellToShow.Select(x => x.Slot));

            if (spellToShow.Count > 0)
            {
                return GetLocalesString($"WhatSpellAnswer_Group_{attributeName}", champions.Name, pronoun, spellsSlot);
            }
            else
            {
                return GetLocalesString("WhatSpellAnswerNone", champions.Name, attributeName);
            }
        }
        public static string GetGuessTheSpellQuestionPrompt()
        {
            return GetLocalesString("GuessTheSpellQuestion");
        }
        public static string GetGuessTheSpellAnswer(SpellSlot spellSlot)
        {
            return GetLocalesString("GuessTheSpellAnswer", spellSlot.ToString());
        }
        public static string GetYesNoQuestionPrompt(List<SpellAttribute> spellAttributes, ChampionsDetails champions)
        {
            string championGenre = champions.Genre == ChampionGenre.Male ? "M" : "F";

            if (spellAttributes == SpellGroups.HardCC)
            {
                return GetLocalesString($"HasHardCCQuestion_{championGenre}", champions.Name);
            }
            else if (spellAttributes == SpellGroups.SoftCC)
            {
                return GetLocalesString($"HasSoftCCQuestion_{championGenre}", champions.Name);
            }
            else if (spellAttributes == SpellGroups.Dash)
            {
                return GetLocalesString($"HasDashQuestion_{championGenre}", champions.Name);
            }
            return "Error please contact Baobab";
        }
        public static string GetYesNoAnswer(bool isYes, List<SpellAttribute> spellAttributes, ChampionsDetails champions, string spells)
        {
            string friendlyAttributeName = "";
            if (spellAttributes == SpellGroups.HardCC)
            {
                friendlyAttributeName = "hard CC";
            }
            else if (spellAttributes == SpellGroups.SoftCC)
            {
                friendlyAttributeName = "soft CC";
            }
            else if (spellAttributes == SpellGroups.Dash)
            {
                friendlyAttributeName = "Dash";
            }
            if (isYes)
            {
                switch (champions.Genre)
                {
                    case ChampionGenre.Male:
                        return GetLocalesString("YesNoAnswerYes_M", champions.Name, friendlyAttributeName, spells);
                    case ChampionGenre.Female:
                        return GetLocalesString("YesNoAnswerYes_F", champions.Name, friendlyAttributeName, spells);
                }
            }
            else
            {
                switch (champions.Genre)
                {
                    case ChampionGenre.Male:
                        return GetLocalesString("YesNoAnswerNo_M", champions.Name, friendlyAttributeName);
                    case ChampionGenre.Female:
                        return GetLocalesString("YesNoAnswerNo_F", champions.Name, friendlyAttributeName);
                }
            }

            return "Error please contact Baobab";
        }
        public static string GetLocalesString(string key, params object[] args)
        {
            string? pattern = LeagueLocales.ResourceManager.GetString(key);
            if (pattern == null) pattern = $"Missing Key in Locales {key}";

            return string.Format(pattern, args);
        }
    }
}
