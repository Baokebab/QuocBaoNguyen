

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
        public override string pageLink => "Minivilles";
        public override string repositoryLink => "";

        public override List<PortfolioCarouselItem> visuals => new List<PortfolioCarouselItem>
        {
            new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=2XokIX19gL0&ab_channel=BaoCNAM",
                youtubeId = "2XokIX19gL0",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Gameplay",
            }
        };
        public override string logoPath => throw new NotImplementedException();

        public override List<PortfolioDetailsCard> detailsItems => new List<PortfolioDetailsCard>
        {
            new PortfolioDetailsCard
            {
                title = localizer["Title_Description"],
                description = localizer["Minivilles_SimpleDesc"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Software"],
                description = gameEngine,
            }
        };
    }
}
