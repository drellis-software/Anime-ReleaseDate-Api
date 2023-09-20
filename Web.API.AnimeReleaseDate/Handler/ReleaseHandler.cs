using MediatR;
using Web.API.AnimeReleaseDate.Models;
using Web.ReleaseDate.WebScraper.Model;

namespace Web.API.AnimeReleaseDate.Handler
{
    public class ReleaseHandler : IRequestHandler<GetShowName, GetShowReleaseResponse>
    {
        private string urlRoot = "https://animeschedule.net/anime/";
        public ReleaseHandler() { }

        public Task<GetShowReleaseResponse> Handle(GetShowName request, CancellationToken cancellationToken)
        {
            var url = urlRoot + request.Title;

            try
            {
                var a = WebScraper.CreateAnimeRelease(url);


                if (a != null ) 
                {
                    if (a.ReleaseDate is null)
                    {
                        var response = new GetShowReleaseResponse()
                        {
                            Title = a.ShowName,
                            Airing = false,
                            ReleaseDate = a.ReleaseDate,
                            Episode = a.Episode
                        };
                        return Task.FromResult(response);
                    }
                    else
                    {
                        var response = new GetShowReleaseResponse()
                        {
                            Title = a.ShowName,
                            Airing = true,
                            ReleaseDate = a.ReleaseDate,
                            Episode = a.Episode
                        };
                        return Task.FromResult(response);
                    }  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
