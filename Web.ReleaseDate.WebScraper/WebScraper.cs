using HtmlAgilityPack;
using System.Net;
using System.Net.Mail;
using Web.ReleaseDate.WebScraper.Model;

namespace Web.ReleaseDate.WebScraper
{
    public class WebScraper
    {
        public static AnimeRelease CreateAnimeRelease(string target)
        {
            
            var title = ScrapeTitleElement(target);
            var release = ScrapeReleaseElement(target);
            var episode = ScrapeEpisodeElement(target);

            return new AnimeRelease { ShowName=title, ReleaseDate=release, Episode=episode };
        }

        public static string ScrapeTitleElement(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Find the parent div element with id="anime-wrapper"
            var animeWrapperDiv = doc.DocumentNode.SelectSingleNode("//div[@id='anime-wrapper']");

            if (animeWrapperDiv != null)
            {
                // Find the div element with id="anime-header-wrapper" within the anime-wrapper div
                var animeHeaderWrapperDiv = animeWrapperDiv.SelectSingleNode(".//div[@id='anime-header-wrapper']");

                if (animeHeaderWrapperDiv != null)
                {
                    // Find the h1 element with id="anime-header-titles" within the anime-header-wrapper div
                    var animeHeaderTitle = animeHeaderWrapperDiv.SelectSingleNode(".//h1[@id='anime-header-titles']");

                    if (animeHeaderTitle != null)
                    {
                        // Find the div element with id="anime-header-main-title" within the anime-header-titles h1
                        var animeHeaderMainTitleDiv = animeHeaderTitle.SelectSingleNode(".//div[@id='anime-header-main-title']");

                        if (animeHeaderMainTitleDiv != null)
                        {
                            // Extract the target div content
                            var targetDivContent = animeHeaderMainTitleDiv.InnerText;
                            return targetDivContent;
                        }
                    }
                }
            }
            return null;
        }

        public static string ScrapeReleaseElement(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Find the parent div element with id="page-content-wrapper"
            var pageContentDiv = doc.DocumentNode.SelectSingleNode("//div[@id='page-content-wrapper']");

            if (pageContentDiv != null)
            {
                // Find the div element with id="anime-wrapper" within the page-content-wrapper div
                var animeWrapperDiv = pageContentDiv.SelectSingleNode(".//div[@id='anime-wrapper']");

                if (animeWrapperDiv != null)
                {
                    // Find the div element with id="content-wrapper" within the anime-wrapper div
                    var contentWrapperDiv = animeWrapperDiv.SelectSingleNode(".//div[@id='content-wrapper']");

                    if (contentWrapperDiv != null)
                    {
                        // Find the aside element with id="left-sidebar" within the content-wrapper div
                        var leftSidebarAside = contentWrapperDiv.SelectSingleNode(".//aside[@id='left-sidebar']");

                        if (leftSidebarAside != null)
                        {
                            // Find the section element with id="release-times-section" within the left-sidebar aside
                            var releaseTimesSection = leftSidebarAside.SelectSingleNode(".//section[@id='release-times-section']");

                            if (releaseTimesSection != null)
                            {
                                // Find the div element with id="release-time-wrapper" within the release-times-section section
                                var releaseTimeWrapperDiv = releaseTimesSection.SelectSingleNode(".//div[contains(@class, 'release-time-wrapper') and contains(@class, 'release-time-wrapper-raw')]");

                                if (releaseTimeWrapperDiv != null)
                                {
                                    // Find the target time element with id="release-time-raw" within the release-time-wrapper div
                                    var targetTimeElement = releaseTimeWrapperDiv.SelectSingleNode(".//time[@id='release-time-raw']");

                                    if (targetTimeElement != null)
                                    {
                                        // Extract the target time value
                                        var targetTime = targetTimeElement.InnerText;
                                        return targetTime;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static string ScrapeEpisodeElement(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Find the parent div element with id="page-content-wrapper"
            var pageContentDiv = doc.DocumentNode.SelectSingleNode("//div[@id='page-content-wrapper']");

            if (pageContentDiv != null)
            {
                // Find the div element with id="anime-wrapper" within the page-content-wrapper div
                var animeWrapperDiv = pageContentDiv.SelectSingleNode(".//div[@id='anime-wrapper']");

                if (animeWrapperDiv != null)
                {
                    // Find the div element with id="content-wrapper" within the anime-wrapper div
                    var contentWrapperDiv = animeWrapperDiv.SelectSingleNode(".//div[@id='content-wrapper']");

                    if (contentWrapperDiv != null)
                    {
                        // Find the aside element with id="left-sidebar" within the content-wrapper div
                        var leftSidebarAside = contentWrapperDiv.SelectSingleNode(".//aside[@id='left-sidebar']");

                        if (leftSidebarAside != null)
                        {
                            // Find the section element with id="release-times-section" within the left-sidebar aside
                            var releaseTimesSection = leftSidebarAside.SelectSingleNode(".//section[@id='release-times-section']");

                            if (releaseTimesSection != null)
                            {
                                // Find the div element with id="release-time-wrapper" within the release-times-section section
                                var releaseTimeWrapperDiv = releaseTimesSection.SelectSingleNode(".//div[contains(@class, 'release-time-wrapper') and contains(@class, 'release-time-wrapper-raw')]");

                                if (releaseTimeWrapperDiv != null)
                                {
                                    // Find the target time element with id="release-time-raw" within the release-time-wrapper div
                                    var targetTimeElement = releaseTimeWrapperDiv.SelectSingleNode(".//time[@id='release-time-raw']");

                                    if (targetTimeElement != null)
                                    {
                                        // Find the h3 element with class="release-time-type-text release-time-type-raw" within the release-time-wrapper div
                                        var releaseTypeHeader = releaseTimeWrapperDiv.SelectSingleNode(".//h3[contains(@class, 'release-time-type-text') and contains(@class, 'release-time-type-raw')]");

                                        if (releaseTypeHeader != null)
                                        {
                                            // Find the span element with class="release-time-episode-number" within the h3 element
                                            var episodeNumberSpan = releaseTypeHeader.SelectSingleNode(".//span[@class='release-time-episode-number']");

                                            if (episodeNumberSpan != null)
                                            {
                                                // Extract the episode number value
                                                var episodeNumber = episodeNumberSpan.InnerText;
                                                return episodeNumber;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
