namespace Ferremundo.JobPlatform.Client.Configuration;

public sealed class JobPlatformClientOptions
{
    public const string SectionName = "JobPlatformClient";

    public string BaseUrl { get; set; } = default!;

    public int TimeoutSeconds { get; set; } = 100;

    public int RetryCount { get; set; }

    public int RetryDelayMilliseconds { get; set; } = 250;

    public string CorrelationHeaderName { get; set; } = "X-Correlation-Id";
}
