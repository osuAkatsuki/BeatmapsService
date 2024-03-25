using BeatmapsService.Extensions;
using BeatmapsService.Models.Cheesegull;
using BeatmapsService.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BeatmapsService.Controllers;

[Route("api/b")]
[ApiController]
public class BeatmapController(IOsuService osuService) : ControllerBase
{
    [HttpGet("{beatmapId}")]
    public async Task<Results<Ok<CheesegullBeatmap>, NotFound, ProblemHttpResult>> FindBeatmapById(
        [FromRoute] int beatmapId,
        CancellationToken cancellationToken)
    {
        var beatmap = await osuService.FindBeatmapByIdAsync(beatmapId, cancellationToken);
        if (beatmap is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(beatmap.ToCheesegullBeatmap());
    }
}