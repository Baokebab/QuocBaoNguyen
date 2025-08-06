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
        public override string imagePathGif => "Images/gif/Zodiaq.gif";
        public override string imagePathAvif => "Images/avif/Zodiaq.avif";
        public override string imagePathPng => "";
        public override string imagePathWebP => "Images/webp/Zodiaq.webp";
        public override string pageLink => "Zodiaq";
        public override string repositoryLink => "https://github.com/Blowerlop/Zodiaq";
        public override string trailerLink => "https://www.youtube.com/shorts/nnue1qXgBIU";
        public override List<PortfolioVideo> videos => new List<PortfolioVideo>
        {
            new PortfolioVideo
            {
                videoLink = "https://www.youtube.com/watch?v=B-Pr4Q9twxA&ab_channel=BaoCNAM",
                title = "Convergence - Gameplay (PC & Mobile)",
                description = ""
            },
            new PortfolioVideo
            {
                videoLink = "https://www.youtube.com/watch?v=4c7adaxixm0&ab_channel=BaoCNAM",
                title = "Convergence - PC Gameplay",
                description = ""
            },
            new PortfolioVideo
            {
                videoLink = "https://www.youtube.com/watch?v=vMLrDFHrmbM&ab_channel=BaoCNAM",
                title = "Convergence - Mobile Gameplay",
                description = ""
            }
        };
    }
}
