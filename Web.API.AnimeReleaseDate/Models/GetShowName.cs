using MediatR;

namespace Web.API.AnimeReleaseDate.Models
{
    public class GetShowName : IRequest<GetShowReleaseResponse>
    {
        public GetShowName(string title)
        { Title = title; }
        public string Title { get; set; }
    }
}
