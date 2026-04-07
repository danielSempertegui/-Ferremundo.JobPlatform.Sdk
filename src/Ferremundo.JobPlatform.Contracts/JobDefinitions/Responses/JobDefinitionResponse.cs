using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobDefinitions.Responses;

public sealed class JobDefinitionResponse
{
    public Guid JobDefinitionGuid { get; set; }

    public Guid WorkerGroupGuid { get; set; }

    public string Code { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public string HandlerName { get; set; } = default!;

    public int TimeoutSeconds { get; set; }

    public int RetryCount { get; set; }

    public bool DisallowConcurrent { get; set; }

    public JobDefinitionStatus Status { get; set; }

    public DateTime? LastKnownRunUtc { get; set; }

    public DateTime? LastKnownNextRunUtc { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }
}
