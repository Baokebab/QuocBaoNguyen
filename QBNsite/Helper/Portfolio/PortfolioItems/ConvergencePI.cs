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
        public override string pageLink => "Convergence_pageLink";
        public override string repositoryLink => "https://github.com/Blowerlop/Convergence";
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
