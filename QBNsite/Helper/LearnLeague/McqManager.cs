namespace QBNsite.Helper
{
    public enum QuestionType
    {
        YesNo,
        AllQuestionsAnswered,
        MultipleCheckbox,
        GuessTheSpell,
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
        public static bool AllRandomAllChampions = false;
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

            AddGuessTheSpellQuestion(champions, res);

            if (ChampionHasThesesEffect(champions, SpellGroups.Dash))
            {
                res.Add(GenerateWhatSpellsHasTheseEffectsQuestion(champions, SpellGroups.Dash, "Dash"));
                res.Add(GenerateWhatKindOfGroupEffectsQuestion(champions, SpellGroups.Dash, "Dash", 5));
            }
            if (ChampionHasThesesEffect(champions, SpellGroups.CC))
            {
                res.Add(GenerateWhatSpellsHasTheseEffectsQuestion(champions, SpellGroups.CC, "CC"));
                res.Add(GenerateWhatKindOfGroupEffectsQuestion(champions, SpellGroups.CC, "CC", 5));
            }
            if (ChampionHasThesesEffect(champions, SpellGroups.Shield))
            {
                res.Add(GenerateWhatSpellsHasTheseEffectsQuestion(champions, SpellGroups.Shield, "Shield"));
                res.Add(GenerateWhatKindOfGroupEffectsQuestion(champions, SpellGroups.Shield, "Shield"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.AutoReset))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.AutoReset, "Reset d'autoattaque"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.BlockedByChampion))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.BlockedByChampion, "blocable (ou ralenti au 1er contact) par un champion "));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.BlockedByMinion))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.BlockedByMinion, "blocable (ou ralenti au 1er contact) par un minion"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.PointAndClick))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.PointAndClick, "unit targeted (point & click)"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.Reset))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.Reset, "Reset"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.MultipleCharges))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.MultipleCharges, "Multiple Charges"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.Execute))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.Execute, "Execute"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.Finisher))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.Finisher, "Finisher"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.InvulnerabilityUntargetableVanished))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.InvulnerabilityUntargetableVanished, "Invulnerability / Untargetable / Vanished"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.BlocksAuto))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.BlocksAuto, "bloque les autoattaque"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.BlocksProjectiles))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.BlocksProjectiles, "bloque les projectiles"));
            }
            if (DoesChamponHaveThisEffect(champions, SpellAttribute.MovementsBuff))
            {
                res.Add(GenerateWhatSpellsHasThisEffectQuestion(champions, SpellAttribute.MovementsBuff, "Movement Speed Buff"));
            }
            if (ChampionHasThesesEffect(champions, SpellGroups.Damage))
            {
                res.Add(GenerateWhatKindOfGroupEffectsQuestion(champions, SpellGroups.Damage, "Damage"));
            }

            return res;
        }

        public static void AddGuessTheSpellQuestion(ChampionsDetails champions, List<MultipleChoiceQuestion> mcqList)
        {
            for(int i = 1; i < 5;i++)
            {
                BaseAnswer[] possibleAnswers = champions.Spells.Where(x => x.Slot != SpellSlot.P)
                                                            .Select(spell => new BaseAnswer(spell.Slot + " - " + spell.Name, false, spell.IconLink))
                                                            .ToArray();
                possibleAnswers[i - 1].IsCorrectAnswer = true;

                MultipleChoiceQuestion mcq = new MultipleChoiceQuestion
                {
                    Id = $"{champions.Name}_Question_GuessSpell{champions.Spells[i].Slot}",
                    Type = QuestionType.GuessTheSpell,
                    QuestionPrompt = LeagueQuestionsTextMatching.GetGuessTheSpellQuestionPrompt(),
                    Answers = possibleAnswers,
                    SpellsToShow = new HashSet<Spell>() { champions.Spells[i] },
                    Commentary = LeagueQuestionsTextMatching.GetGuessTheSpellAnswer(champions.Spells[i].Slot)
                };
                mcqList.Add(mcq);
            }
        }
        public static MultipleChoiceQuestion GenerateYesNoIsEffectPresentQuestions(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string attributeName)
        {
            bool hasEffect = false;
            HashSet<Spell> spellsToShow = new HashSet<Spell>();

            spellsToShow = GetSpellsInAttributeList(champions.Spells, spellAttributes);
            hasEffect = spellsToShow.Count > 0;
            string spellsAffected = string.Join(", ", spellsToShow.Select(x => x.Slot).ToList()); 

            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_Has{attributeName}",
                Type = QuestionType.YesNo,
                QuestionPrompt = LeagueQuestionsTextMatching.GetYesNoQuestionPrompt(spellAttributes, champions),
                Answers = BaseAnswer.BaseAnswersWoLinks(new List<string>() { LeagueQuestionsTextMatching.GetLocalesString("Yes"), LeagueQuestionsTextMatching.GetLocalesString("No") }, new List<bool>() { hasEffect, !hasEffect }),
                SpellsToShow = spellsToShow,
                Commentary = LeagueQuestionsTextMatching.GetYesNoAnswer(hasEffect, spellAttributes, champions, spellsAffected)
            };
        }
        public static MultipleChoiceQuestion GenerateWhatKindOfGroupEffectsQuestion(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string groupName, int maxPossibleChoices = -1)
        {
            string commentary = "";
            string championGenre = champions.Genre == ChampionGenre.Male ? "M" : "F";

            List<BaseAnswer> possibleAnswers = spellAttributes.Select(attr => new BaseAnswer(attr.ToFriendlyString(), false)).ToList();

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
                commentary += LeagueQuestionsTextMatching.GetLocalesString($"with_{championGenre}", spellAttribute.Key.ToFriendlyString(), string.Join(", ", spellAttribute.Value)) + "\n";
            }

            if (commentary == "") commentary = LeagueQuestionsTextMatching.GetLocalesString($"YesNoAnswerNo_{championGenre}", champions.Name, groupName);

            var finalAnswer = new BaseAnswer[0] ;
            if(maxPossibleChoices > 1)
            {
                var reducedAnswers = ReduceChoices(possibleAnswers, maxPossibleChoices);
                Helper.Shuffle(reducedAnswers);
                finalAnswer = reducedAnswers;
            }
            else
            {
                finalAnswer = possibleAnswers.ToArray();
            }
            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_What{groupName}",
                Type = QuestionType.MultipleCheckbox,
                QuestionPrompt = LeagueQuestionsTextMatching.GetWhatKindOfGroupEffectQuestionPrompt(groupName, champions.Name),
                Answers = finalAnswer,
                SpellsToShow = spellToShow,
                Commentary = commentary
            };
        }
        public static MultipleChoiceQuestion GenerateWhatSpellsHasTheseEffectsQuestion(ChampionsDetails champions, List<SpellAttribute> spellAttributes, string attributeName)
        {
            BaseAnswer[] possibleAnswers = champions.Spells.Select(spell => new BaseAnswer(spell.Slot + " - " + spell.Name, false, spell.IconLink)).ToArray();
            HashSet<Spell> spellToShow = new HashSet<Spell>();

            int plural = 0;
            for (int i = 0; i < champions.Spells.Count; i++)
            {
                if (champions.Spells[i].SpellAttributes.Any(attr => spellAttributes.Contains(attr)))
                {
                    spellToShow.Add(champions.Spells[i]);
                    possibleAnswers[i].IsCorrectAnswer = true;
                    plural++;
                }
            }

            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_WhatSpells_{attributeName}",
                Type = QuestionType.MultipleCheckbox,
                QuestionPrompt = LeagueQuestionsTextMatching.GetWhatSpellHasThesesEffectsQuestionPrompt(attributeName),
                Answers = possibleAnswers,
                SpellsToShow = spellToShow,
                Commentary = LeagueQuestionsTextMatching.GetWhatSpellHasThesesEffecstAnswer(champions, attributeName, spellToShow),
            };
        }
        public static MultipleChoiceQuestion GenerateWhatSpellsHasThisEffectQuestion(ChampionsDetails champions, SpellAttribute spellAttribute, string attributeName)
        {
            BaseAnswer[] possibleAnswers = champions.Spells.Select(spell => new BaseAnswer(spell.Slot + " - " + spell.Name, false, spell.IconLink)).ToArray();
            HashSet<Spell> spellToShow = new HashSet<Spell>();

            for (int i = 0; i < champions.Spells.Count; i++)
            {
                if (champions.Spells[i].SpellAttributes.Contains(spellAttribute))
                {
                    spellToShow.Add(champions.Spells[i]);
                    possibleAnswers[i].IsCorrectAnswer = true;
                }
            }
            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Name}_Question_WhatSpells_{attributeName}",
                Type = QuestionType.MultipleCheckbox,
                QuestionPrompt = LeagueQuestionsTextMatching.GetWhatSpellHasThisEffectQuestionPrompt(spellAttribute),
                Answers = possibleAnswers,
                SpellsToShow = spellToShow,
                Commentary = LeagueQuestionsTextMatching.GetWhatSpellHasThisEffectAnswer(champions, spellAttribute, spellToShow)
            };
        }
        public static MultipleChoiceQuestion GenerateResetQuestion(ChampionsDetails champions)
        {
            return new MultipleChoiceQuestion
            {
                Id = $"{champions.Id}_NoMoreQuestion",
                Type = QuestionType.AllQuestionsAnswered,
                QuestionPrompt = LeagueQuestionsTextMatching.GetLocalesString("WannaResetQuestion", champions.Name),
                Answers = BaseAnswer.BaseAnswersWoLinks(new List<string>() { LeagueQuestionsTextMatching.GetLocalesString("Yes"), LeagueQuestionsTextMatching.GetLocalesString("No") }, new List<bool>() { true, false }),
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
        public static BaseAnswer[] ReduceChoices(List<BaseAnswer> answers, int maxCount)
        {
            var correctAnswers = answers.Where(ans => ans.IsCorrectAnswer).ToList();
            var falseAnswers = answers.Where(ans => !ans.IsCorrectAnswer).ToList();

            if (correctAnswers.Count >= maxCount)
                return correctAnswers.Take(maxCount).ToArray();

            var rng = new Random();
            var needed = maxCount - correctAnswers.Count;

            var randomFalses = falseAnswers
                .OrderBy(_ => rng.Next())
                .Take(needed)
                .ToList();

            return correctAnswers.Concat(randomFalses).ToArray();
        }
    }
}
