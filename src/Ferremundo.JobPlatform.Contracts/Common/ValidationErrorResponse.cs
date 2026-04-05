namespace Ferremundo.JobPlatform.Contracts.Common;

public sealed class ValidationErrorResponse
{
    public string Field { get; set; } = default!;

    public IReadOnlyCollection<string> Errors { get; set; } = Array.Empty<string>();
}
