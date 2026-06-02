using System.Linq;

namespace QBNsite.Helper
{
    public enum QuestionType
    {
        YesNo,
        AllQuestionsAnswered,
        MultipleCheckbox,

    }
    public class MultipleChoiceQuestion
    {
        public string Id { get; set; } = "";
        public bool hasBeenCorrectlyAnswered { get; set; } = false;
        public QuestionType Type { get; set; }
        public string QuestionPrompt { get; set; } = "";
        public BaseAnswer[] Answers { get; set; } = new BaseAnswer[0];
        public string Commentary { get; set; } = "";
        public HashSet<Spell> SpellsToShow { get; set; } = new HashSet<Spell>();
    }
    public class BaseAnswer
    {
        public string AnswerText { get; set; } = "";
        public string IconLink { get; set; } = "";
        public bool IsCorrectAnswer { get; set; } = false;

        public BaseAnswer(string answerText, bool isCorrect, string iconLink = "")
        {
            AnswerText = answerText;
            IsCorrectAnswer = isCorrect;
            IconLink = iconLink;
        }

        public static BaseAnswer[] BaseAnswersWoLinks(List<string> answers, List<bool> answerBools)
        {
            List<BaseAnswer> res = new List<BaseAnswer>();
            for (int i = 0; i < answers.Count; i++)
            {
                res.Add(new BaseAnswer(answers[i], answerBools[i]));
            }
            return res.ToArray();
        }
    }
    public static class McqManager
    {
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
            res.Add(GenerateWhatKindOfGroupEffectsQuestion(champions, SpellGroups.Dash, "Dash"));
            res.Add(GenerateWhatKindOfGroupEffectsQuestion(champions, SpellGroups.CC, "CC"));
            res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.BlockedByChampion }, "blocable par un champion"));
            res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellGroups.Dash, "Dash"));
            res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellGroups.CC, "CC (Soft & Hard)"));
            res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.BlockedByMinion }, "blocable par un minion"));
            res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.UnitTargeted }, "unit targeted (point & click)"));

            if(DoesChamponHaveThisEffect(champions, SpellAttribute.Reset))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.Reset }, "Reset"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.MultipleCharges))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.MultipleCharges }, "Multiple Charges"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.Execute))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.Execute }, "Execute"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.Finisher))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.Finisher }, "Finisher"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.InvulnerabilityUntargetableVanished))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.InvulnerabilityUntargetableVanished }, "Invulnerability / Untargetable / Vanished"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.BlocksAuto))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.BlocksAuto }, "bloque les autoattaque"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.BlocksProjectiles))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.BlocksProjectiles }, "bloque les projectiles"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.MovementsBuff))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, new List<SpellAttribute>() { SpellAttribute.MovementsBuff }, "Movement Speed Buff"));
            }

            return res;
        }
        public static MultipleChoiceQuestion GenerateYesNoIsEffectPresentQuestions(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string attributeName)
        {
            string questionPrompt = "";
            string commentary = "";
            bool hasEffect = false;
            HashSet<Spell> spellsToShow = new HashSet<Spell>();

            questionPrompt = $"{champions.Name} possède‑t‑il un {attributeName}?";
            spellsToShow = GetSpellsInAttributeList(champions.Spells, spellAttributes);
            hasEffect = spellsToShow.Count > 0;
            commentary = hasEffect ? $"{champions.Name} peut {attributeName} avec son {string.Join(", ", spellsToShow.Select(x => x.Slot).ToList())}." : "";

            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_Has{attributeName}",
                Type = QuestionType.YesNo,
                QuestionPrompt = questionPrompt,
                Answers = BaseAnswer.BaseAnswersWoLinks(new List<string>() { "Oui", "Non" }, new List<bool>() { hasEffect, !hasEffect }),
                SpellsToShow = spellsToShow,
                Commentary = commentary
            };
        }
        public static MultipleChoiceQuestion GenerateWhatKindOfGroupEffectsQuestion(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string groupName)
        {
            string questionPrompt = $"Quel genre de {groupName} {champions.Name} a-t-il ?";
            string commentary = "";

            BaseAnswer[] possibleAnswers = spellAttributes.Select(attr => new BaseAnswer(attr.ToFriendlyString(), false)).ToArray();

            Dictionary<SpellAttribute, HashSet<SpellSlot>> spellDict = new Dictionary<SpellAttribute, HashSet<SpellSlot>>();
            HashSet<Spell> spellToShow = new HashSet<Spell>();

            for (int i = 0; i < champions.Spells.Count; i++)
            {
                for (int j = 0; j < champions.Spells[i].SpellAttributes.Count; j++)
                {
                    if (spellAttributes.Contains(champions.Spells[i].SpellAttributes[j]))
                    {
                        spellToShow.Add(champions.Spells[i]);
                        if (!spellDict.ContainsKey(champions.Spells[i].SpellAttributes[j]))
                        {
                            spellDict[champions.Spells[i].SpellAttributes[j]] = new HashSet<SpellSlot>() { champions.Spells[i].Slot };
                        }
                        else
                        {
                            spellDict[champions.Spells[i].SpellAttributes[j]].Add(champions.Spells[i].Slot);
                        }
                    }
                }
            }

            foreach (var spellAttribute in spellDict)
            {
                int index = spellAttributes.IndexOf(spellAttribute.Key);
                if (index == -1) continue;

                possibleAnswers[index].IsCorrectAnswer = true;
                commentary += $"{spellAttribute.Key.ToFriendlyString()} avec son {string.Join(", ", spellAttribute.Value)}. ";
            }

            if (commentary == "") commentary = $"{champions.Name} n'a pas de {groupName}.";

            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_What{groupName}",
                Type = QuestionType.MultipleCheckbox,
                QuestionPrompt = questionPrompt,
                Answers = possibleAnswers,
                SpellsToShow = spellToShow,
                Commentary = commentary
            };
        }
        public static MultipleChoiceQuestion GenerateWhatSpellsHasThisEffectQuestion(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string attributeName)
        {
            string questionPrompt = $"Quel sort de {champions.Name} est {attributeName} ?";
            string commentary = "";

            BaseAnswer[] possibleAnswers = champions.Spells.Select(spell => new BaseAnswer(spell.Slot + " - " + spell.Name, false, spell.IconLink)).ToArray();
            HashSet<Spell> spellToShow = new HashSet<Spell>();

            int plural = 0;
            for (int i = 0; i < champions.Spells.Count; i++)
            {
                if (champions.Spells[i].SpellAttributes.Any(attr => spellAttributes.Contains(attr)))
                {
                    spellToShow.Add(champions.Spells[i]);
                    possibleAnswers[i].IsCorrectAnswer = true;
                    commentary += $"{(plural > 0 ? ", " : "")}{champions.Spells[i].Slot}";
                    plural++;
                }
            }

            if (commentary == "")
            {
                commentary = $"{champions.Name} n'a pas de sorts {attributeName}.";
            }
            else
            {
                commentary += $" de {champions.Name} {(plural == 1 ? "a" : "ont")} la caractérisque {attributeName}" ;
            }
            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_WhatSpells_{attributeName}",
                Type = QuestionType.MultipleCheckbox,
                QuestionPrompt = questionPrompt,
                Answers = possibleAnswers,
                SpellsToShow = spellToShow,
                Commentary = commentary
            };
        }
        public static MultipleChoiceQuestion GenerateResetQuestion(string championId)
        {
            return new MultipleChoiceQuestion
            {
                Id = $"{championId}_NoMoreQuestion",
                Type = QuestionType.AllQuestionsAnswered,
                QuestionPrompt = "Tu as répondu correctement à chaque question pour ce champion. Veux tu les refaire? ",
                Answers = BaseAnswer.BaseAnswersWoLinks(new List<string>() { "Oui", "Non" }, new List<bool>() { true, false }),
            };
        }
        public static HashSet<Spell> GetSpellsInAttributeList(List<Spell> spells, List<SpellAttribute> spellAttributes)
        {
            HashSet<Spell> res = new HashSet<Spell>();
            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].SpellAttributes.Any(attr => spellAttributes.Contains(attr)))
                {
                    res.Add(spells[i]);
                }
            }
            return res;
        }
        public static HashSet<SpellSlot> ChampionSpellWithThisEffect(ChampionsDetails champion, SpellAttribute attribute)
        {
            HashSet<SpellSlot> res = new HashSet<SpellSlot>();
            foreach (var spell in champion.Spells)
            {
                if (spell.SpellAttributes.Contains(attribute))
                {
                    res.Add(spell.Slot);
                }
            }
            return res;
        }
        public static bool DoesChamponHaveThisEffect(ChampionsDetails champion, SpellAttribute attribute)
        {
            foreach (var spell in champion.Spells)
            {
                if (spell.SpellAttributes.Contains(attribute))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ChampionHasThesesEffect(ChampionsDetails champion, List<SpellAttribute> spellAttributes)
        {
            for (int i = 0; i < spellAttributes.Count; i++)
            {
                foreach (var spell in champion.Spells)
                {
                    if (spell.SpellAttributes.Contains(spellAttributes[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static HashSet<SpellSlot> DoesChampionHaveThesesEffects(ChampionsDetails champion, List<SpellAttribute> attributes)
        {
            HashSet<SpellSlot> res = new HashSet<SpellSlot>();

            for (int i = 0; i < attributes.Count; i++)
            {
                foreach (var spell in champion.Spells)
                {
                    if (spell.SpellAttributes.Contains(attributes[i]))
                    {
                        res.Add(spell.Slot);
                    }
                }
            }
            return res;
        }
    }
}
