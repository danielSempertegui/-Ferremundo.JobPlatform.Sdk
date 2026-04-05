using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobExecutions.Responses;

public sealed class JobExecutionResponse
{
    public Guid JobExecutionGuid { get; set; }

    public Guid JobDefinitionGuid { get; set; }

    public Guid? WorkerNodeGuid { get; set; }

    public string JobDefinitionCode { get; set; } = default!;

    public string JobDefinitionName { get; set; } = default!;

    public string? WorkerNodeName { get; set; }

    public JobExecutionSource ExecutionSource { get; set; }

    public DateTime StartedAtUtc { get; set; }

    public DateTime? FinishedAtUtc { get; set; }

    public JobExecutionStatus Status { get; set; }

    public string? SummaryMessage { get; set; }

    public string? ErrorMessage { get; set; }

    public string? CorrelationId { get; set; }
}
