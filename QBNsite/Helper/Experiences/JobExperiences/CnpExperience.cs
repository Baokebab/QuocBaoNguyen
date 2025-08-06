using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Experiences.JobExperiences
{
    public class CnpExperience : JobExperience
    {
        public CnpExperience(IStringLocalizer<JobsLocales> localizer) : base(localizer)
        {
        }

        public override string jobtitle => localizer["Cnp_JobTitle"];

        public override string description => localizer["Cnp_Desc"];

        public override string entrepriseName => "CNP Assurances";

        public override string hrefLink => "https://www.cnp.fr/le-groupe-cnp-assurances";

        public override string dates => localizer["Cnp_Dates"];
    }
}
