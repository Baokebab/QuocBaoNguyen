using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper.Portfolio.PortfolioItems
{
    public class ConvergencePI : PortfolioItem
    {
        public ConvergencePI(IStringLocalizer<PortfolioLocales> localizer) : base(localizer)
        {

        }

        public override string Title => "Convergence";
        public override string simpleDescription => localizer["Convergence_SimpleDesc"];
        public override string detailedDescription => localizer["Convergence_DetailedDesc"];
        public override string gameEngine => "PC - Unity, C#\r\nAndroid - Unreal Engine 5, C++";
        public override string imagePathGif => "Images/gif/Convergence.gif";
        public override string imagePathAvif => "Images/avif/Convergence.avif";
        public override string imagePathPng => "";
        public override string imagePathWebP => "Images/webp/Convergence.webp";
        public override string pageLink => "Convergence";
        public override string repositoryLink => "https://github.com/Blowerlop/Convergence";
        public override List<PortfolioCarouselItem> visuals => new List<PortfolioCarouselItem>
        {
           new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/shorts/nnue1qXgBIU",
                youtubeId = "nnue1qXgBIU",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Mobile Ad",
            },
               new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=B-Pr4Q9twxA&ab_channel=BaoCNAM",
                itemType = PortfolioItemType.YoutubeVideo,
                youtubeId = "B-Pr4Q9twxA",
                title = "PC & Mobile",
            },

                new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=vMLrDFHrmbM&ab_channel=BaoCNAM",
                youtubeId = "vMLrDFHrmbM",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Mobile Only",
            },

                new PortfolioCarouselItem
            {
                link = "https://www.youtube.com/watch?v=gr9l6X_NAaU&ab_channel=BaoCNAM",
                youtubeId = "gr9l6X_NAaU",
                itemType = PortfolioItemType.YoutubeVideo,
                title = "Making of",
            },
        };

        public override string logoPath => throw new NotImplementedException();

        public override List<PortfolioDetailsCard> detailsItems => new List<PortfolioDetailsCard>
        {
            new PortfolioDetailsCard
            {
                title = localizer["Title_Description"],
                description = localizer["Convergence_SimpleDesc"],
            },
               new PortfolioDetailsCard
            {
                title = localizer["Title_Software"],
                description = "Unreal Engine 5 (C++), Unity (C#), Fmod, Blender",
            },
            new PortfolioDetailsCard
            {
                title = "Pitch",
                description = localizer["Convergence_Pitch"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Gameplay"],
                description = localizer["Convergence_Gameplay"],
            },
              new PortfolioDetailsCard
            {
                title = localizer["Title_Network"],
                description = localizer["Convergence_Network"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Network"],
                description = localizer["Convergence_Sound"],
            },
            new PortfolioDetailsCard
            {
                title = localizer["Title_Visuals"],
                description = localizer["Convergence_Visual"],
            }
        };
    }
}
