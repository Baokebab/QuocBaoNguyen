using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Experiences.JobExperiences
{
    public class DriVRExperience : JobExperience
    {
        public DriVRExperience(IStringLocalizer<JobsLocales> localizer) : base(localizer)
        {
        }

        public override string jobtitle => localizer["DriVR_JobTitle"];

        public override string description => localizer["DriVR_Desc"];

        public override string entrepriseName => "DriVR";

        public override string hrefLink => "https://drivr.online/";

        public override string dates => localizer["DriVR_Dates"];
    }
}
