

using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class ChromaClashPI : PortfolioItem
    {
        public ChromaClashPI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {
        }

        public override string Title => "Chroma Clash";
        public override string simpleDescription => localizer["ChromaClash_SimpleDesc"];
        public override string detailedDescription => localizer["ChromaClash_DetailedDesc"];
        public override string gameEngine => "Unity, C#";
        public override string imagePathGif => "Images/gif/ChromaClash.gif";
        public override string imagePathAvif => "Images/avif/ChromaClash.avif";
        public override string imagePathPng => "";
        public override string imagePathWebP => "Images/webp/ChromaClash.webp";
        public override string pageLink => "ChromaClash";
        public override string repositoryLink => "";

        public override List<PortfolioCarouselItem> visuals => new List<PortfolioCarouselItem>
        {
            new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=E9fUczOYMlA&ab_channel=BaoCNAM",
                youtubeId = "E9fUczOYMlA",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Trailer",
                description = ""
            },

              new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=MuCdN6tAZ7c&ab_channel=BaoCNAM",
                youtubeId = "MuCdN6tAZ7c",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Gameplay",
                description = ""
            },
        };

        public override string logoPath => throw new NotImplementedException();

        public override List<PortfolioDetailsCard> detailsItems => new List<PortfolioDetailsCard>
        {
            new PortfolioDetailsCard
            {
                title = localizer["Title_Description"],
                description = localizer["ChromaClash_SimpleDesc"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Software"],
                description = "Unity (C#), Blender",
            }
        };
    }
}
