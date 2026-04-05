using System.Net.Http.Headers;
using Ferremundo.JobPlatform.Client.Abstractions;

namespace Ferremundo.JobPlatform.Client.Authentication;

public sealed class JobPlatformAuthenticationHandler : DelegatingHandler
{
    private readonly IJobPlatformAccessTokenProvider _accessTokenProvider;

    public JobPlatformAuthenticationHandler(IJobPlatformAccessTokenProvider accessTokenProvider)
    {
        _accessTokenProvider = accessTokenProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.Authorization is null)
        {
            var accessToken = await _accessTokenProvider.GetAccessTokenAsync(cancellationToken);

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
