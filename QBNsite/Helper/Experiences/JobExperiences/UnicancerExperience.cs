using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Experiences.JobExperiences
{
    public class UnicancerExperience : JobExperience
    {
        public UnicancerExperience(IStringLocalizer<JobsLocales> localizer) : base(localizer)
        {
        }

        public override string jobtitle => localizer["Unicancer_JobTitle"];

        public override string description => localizer["Unicancer_Desc"];

        public override string entrepriseName => "UNICANCER GCS";

        public override string hrefLink => "https://www.unicancer.fr/fr/";

        public override string dates => localizer["Unicancer_Dates"];
    }
}
