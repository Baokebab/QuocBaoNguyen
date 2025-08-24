
using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class SenseiSimuPI : PortfolioItem
    {
        public SenseiSimuPI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {

        }

        public override string Title => "Sensei Simu";
        public override string simpleDescription => localizer["SenseiSimu_SimpleDesc"];
        public override string detailedDescription => localizer["SenseiSimu_DetailedDesc"];
        public override string gameEngine => "Unity, C#";
        public override string imagePathGif => "Images/gif/SenseiSimu.gif";
        public override string imagePathAvif => "Images/avif/SenseiSimu.avif";
        public override string imagePathPng => "";
        public override string imagePathWebP => "Images/webp/SenseiSimu.webp";
        public override string pageLink => "SenseiSimu";
        public override string repositoryLink => "";
        public override List<PortfolioCarouselItem> visuals => new List<PortfolioCarouselItem>
        {
            new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=GZ6z9dZaLls&ab_channel=BaoCNAM",
                title = "Trailer",
                youtubeId = "GZ6z9dZaLls",
                itemType = PortfolioItemType.YoutubeVideo
            },
            new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=t7rM2vcr9dI&ab_channel=BaoCNAM",
                title = "Gameplay",
                 itemType = PortfolioItemType.YoutubeVideo,
                youtubeId = "t7rM2vcr9dI"
            }
        };

        public override string logoPath => throw new NotImplementedException();

        public override List<PortfolioDetailsCard> detailsItems => new List<PortfolioDetailsCard>
        {
            new PortfolioDetailsCard
            {
                title = localizer["Title_Description"],
                description = localizer["SenseiSimu_SimpleDesc"],
            }
        };
    }
}
