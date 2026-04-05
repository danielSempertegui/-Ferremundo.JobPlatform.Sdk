using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.WorkerNodes.Responses;

public sealed class WorkerNodeResponse
{
    public Guid WorkerNodeGuid { get; set; }

    public Guid WorkerGroupGuid { get; set; }

    public string NodeName { get; set; } = default!;

    public string MachineName { get; set; } = default!;

    public string Environment { get; set; } = default!;

    public string OperatingSystem { get; set; } = default!;

    public string WorkerVersion { get; set; } = default!;

    public WorkerNodeStatus Status { get; set; }

    public DateTime? LastHeartbeatUtc { get; set; }

    public DateTime? LastStartedAtUtc { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }
}
