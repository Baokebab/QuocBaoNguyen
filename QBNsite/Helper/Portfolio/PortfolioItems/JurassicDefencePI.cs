using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class JurassicDefencePI : PortfolioItem
    {
        public JurassicDefencePI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {

        }
        public override string Title => "Jurassic Defence";
        public override string simpleDescription => localizer["JurassicDefence_SimpleDesc"];
        public override string detailedDescription => localizer["JurassicDefence_DetailedDesc"];
        public override string gameEngine => "Unity WebGL, C#";
        public override string imagePathGif => "";
        public override string imagePathAvif => "";
        public override string imagePathPng => "Images/png/JurassicDefence.png";
        public override string imagePathWebP => "";
        public override string pageLink => "JurassicDefence_pageLink";
        public override string repositoryLink => "";
        public override string trailerLink => "https://www.youtube.com/shorts/nnue1qXgBIU";

        public override List<PortfolioVideo> videos => throw new NotImplementedException();
    }
}
