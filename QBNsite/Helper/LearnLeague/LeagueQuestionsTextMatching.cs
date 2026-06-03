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
            if (spellAttributes == SpellGroups.HardCC)
            {
                switch (champions.Genre)
                {
                    case ChampionGenre.Male:
                        return GetLocalesString("HasHardCCQuestion_M", champions.Name);
                    case ChampionGenre.Female:
                        return GetLocalesString("HasHardCCQuestion_F", champions.Name);
                }
            }
            else if (spellAttributes == SpellGroups.SoftCC)
            {
                switch (champions.Genre)
                {
                    case ChampionGenre.Male:
                        return GetLocalesString("HasSoftCCQuestion_M", champions.Name);
                    case ChampionGenre.Female:
                        return GetLocalesString("HasSoftCCQuestion_F", champions.Name);
                }
            }
            else if (spellAttributes == SpellGroups.Dash)
            {
                switch (champions.Genre)
                {
                    case ChampionGenre.Male:
                        return GetLocalesString("HasDashQuestion_M", champions.Name);
                    case ChampionGenre.Female:
                        return GetLocalesString("HasDashQuestion_F", champions.Name);
                }
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
