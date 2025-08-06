
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
        public override string pageLink => "SenseiSimu_pageLink";
        public override string repositoryLink => "";
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
