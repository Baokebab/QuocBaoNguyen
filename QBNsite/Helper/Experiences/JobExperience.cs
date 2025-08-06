using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper
{
    public abstract class JobExperience
    {
        protected readonly IStringLocalizer<JobsLocales> localizer;
        public JobExperience(IStringLocalizer<JobsLocales> localizer)
        {
            this.localizer = localizer;
        }
        public abstract string jobtitle { get; }
        public abstract string description { get; }
        public abstract string entrepriseName { get; }
        public abstract string hrefLink { get; }
        public abstract string dates { get; }
    }
}
