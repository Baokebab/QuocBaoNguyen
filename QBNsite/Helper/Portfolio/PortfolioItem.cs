
using Microsoft.Extensions.Localization;
using QBNsite.Resources;

namespace QBNsite.Helper
{
    public abstract class PortfolioItem
    {

        protected readonly IStringLocalizer<PortfolioLocales> localizer;
        public PortfolioItem(IStringLocalizer<PortfolioLocales> localizer)
        {
            this.localizer = localizer;
        }

        public abstract string Title { get; }

        public abstract string simpleDescription { get; }

        public abstract string detailedDescription { get; }

        public abstract string gameEngine { get; }

        public abstract string pageLink { get; }

        public abstract string logoPath { get; }

        public abstract string imagePathGif { get;  }

        public abstract string imagePathAvif  { get; }
                
        public abstract string imagePathPng { get; }

        public abstract string imagePathWebP { get;  }

        public abstract string repositoryLink { get; }


        public abstract List<PortfolioCarouselItem> visuals { get; }

        public abstract List<PortfolioDetailsCard> detailsItems { get; }
    }

    public class PortfolioCarouselItem
    {
        public string link = "";
        public string youtubeId = "";
        public PortfolioItemType itemType = PortfolioItemType.YoutubeVideo;
        public string title = "";
        public string description = "";
        public string fixedPngPath = ""; 
        public string EmbedUrl => $"https://www.youtube-nocookie.com/embed/{youtubeId}?rel=0";
        public string Thumbnail => $"https://img.youtube.com/vi/{youtubeId}/hqdefault.jpg";
    }

    public enum PortfolioItemType
    {
        YoutubeVideo,
        Png,
        Gif,
        Webp,
        Avif,
    }

    public class  PortfolioDetailsCard
    {
        public string title = "";
        public string description = "";
        public List<string> imageLinks = new List<string>();
    }
}
