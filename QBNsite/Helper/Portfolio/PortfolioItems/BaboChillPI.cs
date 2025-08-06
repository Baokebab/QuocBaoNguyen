

using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class BaboChillPI : PortfolioItem
    {
        public BaboChillPI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {
        }

        public override string Title => "BaboChill";
        public override string simpleDescription => localizer["BaboChill_SimpleDesc"];
        public override string detailedDescription => localizer["BaboChill_DetailedDesc"];
        public override string gameEngine => "WPF, C#";
        public override string imagePathGif => "";
        public override string imagePathAvif => "";
        public override string imagePathPng => "Images/png/WIP.png";
        public override string imagePathWebP => "";
        public override string pageLink => "BaboChill_pageLink";
        public override string repositoryLink => "";
        public override string trailerLink => "";
        public override List<PortfolioVideo> videos => throw new NotImplementedException();
    }
}
