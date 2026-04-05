using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobExecutions.Requests;

public sealed class CreateJobExecutionRequest
{
    [Required]
    public Guid JobDefinitionGuid { get; set; }

    public Guid? WorkerNodeGuid { get; set; }

    [Required]
    [EnumDataType(typeof(JobExecutionSource))]
    public JobExecutionSource ExecutionSource { get; set; }

    [MaxLength(100)]
    public string? CorrelationId { get; set; }
}
