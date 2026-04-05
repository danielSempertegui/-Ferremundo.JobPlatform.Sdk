using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobCommands.Responses;

public sealed class JobCommandResponse
{
    public Guid JobCommandGuid { get; set; }

    public Guid JobDefinitionGuid { get; set; }

    public Guid? WorkerNodeGuid { get; set; }

    public string JobDefinitionCode { get; set; } = default!;

    public string JobDefinitionName { get; set; } = default!;

    public JobCommandType CommandType { get; set; }

    public JobCommandStatus Status { get; set; }

    public DateTime RequestedAtUtc { get; set; }

    public string RequestedBy { get; set; } = default!;

    public DateTime? ProcessedAtUtc { get; set; }

    public string? ResultMessage { get; set; }
}
