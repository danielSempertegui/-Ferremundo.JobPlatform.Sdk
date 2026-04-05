using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.WorkerGroups.Responses;

public sealed class WorkerGroupResponse
{
    public Guid WorkerGroupGuid { get; set; }

    public string Code { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public WorkerGroupStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
