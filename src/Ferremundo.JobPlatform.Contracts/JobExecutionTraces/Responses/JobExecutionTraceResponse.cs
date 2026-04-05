using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Responses;

public sealed class JobExecutionTraceResponse
{
    public Guid JobExecutionTraceGuid { get; set; }

    public Guid JobExecutionGuid { get; set; }

    public Guid JobDefinitionGuid { get; set; }

    public Guid? WorkerNodeGuid { get; set; }

    public int StepOrder { get; set; }

    public string StepName { get; set; } = default!;

    public JobExecutionTraceType TraceType { get; set; }

    public string? TargetName { get; set; }

    public string? TargetReference { get; set; }

    public string? RequestPayload { get; set; }

    public string? ResponsePayload { get; set; }

    public string? Message { get; set; }

    public DateTime CreatedAt { get; set; }
}
