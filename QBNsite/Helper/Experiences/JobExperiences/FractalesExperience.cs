using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Experiences.JobExperiences
{
    public class FractalesExperience : JobExperience
    {
        public FractalesExperience(IStringLocalizer<JobsLocales> localizer) : base(localizer)
        {
        }

        public override string jobtitle => localizer["Fractales_JobTitle"];

        public override string description => localizer["Fractales_Desc"];

        public override string entrepriseName => "Fractales";

        public override string hrefLink => "https://www.fractales.com/";

        public override string dates => localizer["Fractales_Dates"];
    }
}
