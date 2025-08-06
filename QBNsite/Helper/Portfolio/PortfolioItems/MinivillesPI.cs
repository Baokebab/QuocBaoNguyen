

using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class MinivillesPI : PortfolioItem
    {
        public MinivillesPI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {
        }

        public override string Title => "Minivilles";
        public override string simpleDescription => localizer["Minivilles_SimpleDesc"];
        public override string detailedDescription => localizer["Minivilles_DetailedDesc"];
        public override string gameEngine => "Windows Forms, C#";
        public override string imagePathGif => "Images/gif/Minivilles.gif";
        public override string imagePathAvif => "Images/avif/Minivilles.avif";
        public override string imagePathPng => "";
        public override string imagePathWebP => "Images/webp/Minivilles.webp";
        public override string pageLink => "Minivilles_pageLink";
        public override string repositoryLink => "";
        public override string trailerLink => "https://www.youtube.com/shorts/nnue1qXgBIU";

        public override List<PortfolioVideo> videos => throw new NotImplementedException();
    }
}
