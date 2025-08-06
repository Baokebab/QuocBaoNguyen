
using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper
{
    public abstract class PortfolioItem
    {

        protected readonly IStringLocalizer<PortfolioLocales> localizer;
        public PortfolioItem(IStringLocalizer<PortfolioLocales> localizer)
        {
            this.localizer = localizer;
        }

        public abstract string Title { get; }

        public abstract string simpleDescription { get; }

        public abstract string detailedDescription { get; }

        public abstract string gameEngine { get; }

        public abstract string pageLink { get; }

        public abstract string imagePathGif { get;  }

        public abstract string imagePathAvif  { get; }
                
        public abstract string imagePathPng { get; }

        public abstract string imagePathWebP { get;  }

        public abstract string repositoryLink { get; }

        public abstract string trailerLink { get; }

        public abstract List<PortfolioVideo> videos { get; }
    }

    public class PortfolioVideo
    {
        public string videoLink = "";
        public string title = "";
        public string description = "";
    }
}
