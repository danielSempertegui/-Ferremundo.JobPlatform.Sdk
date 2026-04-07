using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.WorkerGroups.Responses;

public sealed class WorkerGroupResponse
{
    public Guid WorkerGroupGuid { get; set; }

    public string Code { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public int HeartbeatIntervalSeconds { get; set; }

    public int CommandPollingIntervalSeconds { get; set; }

    public int ScheduleSyncIntervalSeconds { get; set; }

    public WorkerGroupStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }
}
