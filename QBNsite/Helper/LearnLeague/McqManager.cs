using static QBNsite.Helper.McqManager;

namespace QBNsite.Helper
{
    public static class McqManager
    {
        public enum QuestionType
        {
            YesNo,
            AllQuestionsAnswered
        }

        public static bool IgnoreResetQuestion = false;

        public static int GetNextUnansweredQuestion(ChampionsDetails champion, int currentQuestionIndex = -1)
        {

            for (int i = 0; i < champion.Mcq.Count; i++)
            {
                int index = (currentQuestionIndex + i + 1) % champion.Mcq.Count; 
                if (!champion.Mcq[index].hasBeenCorrectlyAnswered)
                {
                    return index;
                }
            }

            return -1;
        }
        public static List<MultipleChoiceQuestion> GenerateAllMcq(ChampionsDetails champions)
        {
            var res = new List<MultipleChoiceQuestion>();

            res.Add(GenerateYesNoIsEffectPresentQuestions(champions, SpellGroups.HardCC, "Hard CC"));
            res.Add(GenerateYesNoIsEffectPresentQuestions(champions, SpellGroups.SoftCC, "Soft CC"));
            res.Add(GenerateYesNoIsEffectPresentQuestions(champions, SpellGroups.Dash, "Dash"));

            return res;
        }
        public static MultipleChoiceQuestion GenerateYesNoIsEffectPresentQuestions(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string attributeName)
        {
            string questionPrompt = "";
            string commentary = "";
            bool hasEffect = false;
            List<Spell> spellsToShow = new List<Spell>();

            questionPrompt = $"{champions.Name} possède‑t‑il un {attributeName}?";
            spellsToShow = GetSpellsInAttributeList(champions.Spells, spellAttributes);
            hasEffect = spellsToShow.Count > 0;
            commentary = hasEffect ? $"{champions.Name} peut {attributeName} avec son {string.Join(", ", spellsToShow.Select(x => x.Slot).ToList())}." : "";

            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_Has{attributeName}",
                Type = QuestionType.YesNo,
                QuestionPrompt = questionPrompt,
                Answers = new string[2] { "Oui", "Non" },
                CorrectAnswers = new bool[2] { hasEffect, !hasEffect },
                SpellsToShow = spellsToShow,
                Commentary = commentary
            };
        }
        public static List<Spell> GetSpellsInAttributeList(List<Spell> spells, List<SpellAttribute> spellAttributes)
        {
            List<Spell> res = new List<Spell>();
            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].SpellAttributes.Any(attr => spellAttributes.Contains(attr)))
                {
                    res.Add(spells[i]);
                }
            }
            return res;
        }
    }
    public class MultipleChoiceQuestion
    {
        public string Id { get; set; } = "";
        public bool hasBeenCorrectlyAnswered { get; set; } = false;
        public QuestionType Type { get; set; }
        public string QuestionPrompt { get; set; } = "";
        public string[] Answers { get; set; } = new string[0];
        public bool[] CorrectAnswers { get; set; } = new bool[0];
        public string Commentary { get; set; } = "";
        public List<Spell> SpellsToShow { get; set; } = new List<Spell>();
    }
}
