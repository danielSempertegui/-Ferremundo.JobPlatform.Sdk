namespace Ferremundo.JobPlatform.Client.Configuration;

public sealed class JobPlatformClientOptions
{
    public const string SectionName = "JobPlatformClient";

    public string BaseUrl { get; set; } = default!;
}
