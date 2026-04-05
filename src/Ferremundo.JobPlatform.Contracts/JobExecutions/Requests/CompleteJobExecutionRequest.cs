using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobExecutions.Requests;

public sealed class CompleteJobExecutionRequest
{
    [Required]
    [EnumDataType(typeof(JobExecutionStatus))]
    public JobExecutionStatus Status { get; set; }

    [MaxLength(1000)]
    public string? SummaryMessage { get; set; }

    public string? ErrorMessage { get; set; }
}
