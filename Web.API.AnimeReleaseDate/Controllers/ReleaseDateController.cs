using Microsoft.AspNetCore.Mvc;
using MediatR;
using Web.API.AnimeReleaseDate.Models;

namespace WebsiteStatusAPI.Controllers
{
    [ApiController]
    [Route("AnimeRelease")]
    public class WebsiteStatusController : ControllerBase
    {
        private readonly ILogger<WebsiteStatusController> _logger;
        private readonly IMediator _mediator;

        public WebsiteStatusController(ILogger<WebsiteStatusController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetReleaseDates([FromRoute] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Invalid Title");
            }

            var result = await _mediator.Send(new GetShowName(title));

            return result.Title is null ? NotFound(new { ErrorMessage = "Title not found" }) : Ok(result);
        }
    }
}