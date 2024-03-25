﻿using System.Diagnostics.CodeAnalysis;
using BeatmapsService.Adapters;
using BeatmapsService.Models.Osu;
using Microsoft.Extensions.Options;

namespace BeatmapsService.Services;

public class OsuService(IOsuAdapter osuAdapter, IOptions<BeatmapOptions> beatmapOptions) : IOsuService
{
    private string? _accessToken;
    private DateTimeOffset? _expiresAt;

    [MemberNotNull(nameof(_accessToken))]
    private async Task Authenticate(CancellationToken cancellationToken = default)
    {
        if (_accessToken is not null && _expiresAt is not null && DateTimeOffset.UtcNow < _expiresAt)
            return;

        var oauthResponse = await osuAdapter.AuthenticateAsync(
            beatmapOptions.Value.ClientId, 
            beatmapOptions.Value.ClientSecret,
            cancellationToken);

        _accessToken = oauthResponse.AccessToken;
        _expiresAt = DateTimeOffset.UtcNow.AddSeconds(oauthResponse.ExpiresIn);
    }

    public async Task<BeatmapExtended?> FindBeatmapByIdAsync(int beatmapId, CancellationToken cancellationToken = default)
    {
        await Authenticate(cancellationToken);

        var beatmap = await osuAdapter.FindBeatmapByIdAsync(
            beatmapId,
            _accessToken,
            cancellationToken);

        return beatmap;
    }

    public async Task<BeatmapsetExtended?> FindBeatmapsetByIdAsync(int beatmapsetId, CancellationToken cancellationToken = default)
    {
        await Authenticate(cancellationToken);

        var beatmapset = await osuAdapter.FindBeatmapsetByIdAsync(
            beatmapsetId,
            _accessToken,
            cancellationToken);

        return beatmapset;
    }
}