namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IJobPlatformAccessTokenProvider
{
    ValueTask<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
