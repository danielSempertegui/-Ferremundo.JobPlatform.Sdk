using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Requests;

public sealed class CreateJobExecutionTraceRequest
{
    [Required]
    public Guid JobExecutionGuid { get; set; }

    [Range(1, int.MaxValue)]
    public int StepOrder { get; set; }

    [Required]
    [MaxLength(150)]
    public string StepName { get; set; } = default!;

    [Required]
    [EnumDataType(typeof(JobExecutionTraceType))]
    public JobExecutionTraceType TraceType { get; set; }

    [MaxLength(150)]
    public string? TargetName { get; set; }

    [MaxLength(500)]
    public string? TargetReference { get; set; }

    public string? RequestPayload { get; set; }

    public string? ResponsePayload { get; set; }

    public string? Message { get; set; }
}
