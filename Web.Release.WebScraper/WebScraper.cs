using HtmlAgilityPack;

namespace Web.ReleaseDate.WebScraper.Model
{
    public class WebScraper
    {
        public static AnimeRelease CreateAnimeRelease(string target)
        {
            var web = new HtmlWeb();
            var doc = web.Load(target);

            var title = ScrapeElementText(doc, "#anime-header-main-title");
            var release = ScrapeElementText(doc, ".release-time-type-raw time");
            var episode = ScrapeElementText(doc, ".release-time-episode-number");

            return new AnimeRelease { ShowName = title, ReleaseDate = release, Episode = episode };
        }

        private static string ScrapeElementText(HtmlDocument doc, string selector)
        {
            var element = doc.DocumentNode.SelectSingleNode(selector);
            return element?.InnerText;
        }
    }
}
