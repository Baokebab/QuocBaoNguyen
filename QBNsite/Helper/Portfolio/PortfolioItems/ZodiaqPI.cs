using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class ZodiaqPI : PortfolioItem
    {
        public ZodiaqPI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {

        }

        public override string Title => "Zodiaq";
        public override string simpleDescription => localizer["Zodiaq_SimpleDesc"];
        public override string detailedDescription => localizer["Zodiaq_DetailedDesc"];
        public override string gameEngine => "Unreal Engine 5, C++";
        public override string logoPath => "Images/png/ZodiaqLogo.png";
        public override string imagePathGif => "Images/gif/Zodiaq.gif";
        public override string imagePathAvif => "Images/avif/Zodiaq.avif";
        public override string imagePathPng => "";
        public override string imagePathWebP => "Images/webp/Zodiaq.webp";
        public override string pageLink => "Zodiaq";
        public override string repositoryLink => "https://github.com/Blowerlop/Zodiaq";
        public override List<PortfolioCarouselItem> visuals => new List<PortfolioCarouselItem>
        {
            new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=YPPt4yNKmbs&ab_channel=BaoCNAM",
                youtubeId = "YPPt4yNKmbs",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Trailer",
                description = ""
            },

              new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=3vZ3rDpK1EE&t=20s&ab_channel=BaoCNAM",
                youtubeId = "3vZ3rDpK1EE",
                  itemType = PortfolioItemType.YoutubeVideo,
                title = "Gameplay",
                description = ""
            },

               new PortfolioCarouselItem
            {
                link = "Images/avif/Zodiaq_Analytics.avif",
                itemType = PortfolioItemType.Avif,
                fixedPngPath = "Images/png/Zodiaq_Analytics.png",
                youtubeId = "",
                title = "Analytics",
                description = ""
            },
        };

        public override List<PortfolioDetailsCard> detailsItems => new List<PortfolioDetailsCard>
        {
            new PortfolioDetailsCard
            {
                title = localizer["Title_Description"],
                description = localizer["Zodiaq_DetailedDesc"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Software"],
                description = "Unreal Engine 5 (C++), Firebase, Blender, Flutter",
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Lore"],
                description = localizer["Zodiaq_Lore"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Network"],
                description = localizer["Zodiaq_Networking"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Gameplay"],
                description = localizer["Zodiaq_GameplayJoueur"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Spells"],
                description = localizer["Zodiaq_Spells"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Boss"],
                description =localizer["Zodiaq_Boss"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Analytics"],
                description = localizer["Zodiaq_Analytics"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Visuals"],
                description = localizer["Zodiaq_Visuals"],
            },
        };
    }
}
