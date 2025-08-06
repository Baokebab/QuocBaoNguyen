

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
        public override string pageLink => "ChromaClash_pageLink";
        public override string repositoryLink => "";
        public override string trailerLink => "https://www.youtube.com/shorts/nnue1qXgBIU";

        public override List<PortfolioVideo> videos => throw new NotImplementedException();
    }
}
