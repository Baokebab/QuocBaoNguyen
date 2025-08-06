using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Experiences.JobExperiences
{
    public class CaceisExperience : JobExperience
    {
        public CaceisExperience(IStringLocalizer<JobsLocales> localizer) : base(localizer)
        {
        }

        public override string jobtitle => localizer["Caceis_JobTitle"];

        public override string description => localizer["Caceis_Desc"];

        public override string entrepriseName => "Caceis Luxembourg";

        public override string hrefLink => "https://www.caceis.com/fr/qui-sommes-nous/ou-nous-trouver/luxembourg/";

        public override string dates => localizer["Caceis_Dates"];
    }
}
