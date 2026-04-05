using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobDefinitions.Requests;

public sealed class CreateJobDefinitionRequest
{
    [Required]
    public Guid WorkerGroupGuid { get; set; }

    [Required]
    [MaxLength(80)]
    public string Code { get; set; } = default!;

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = default!;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(150)]
    public string HandlerName { get; set; } = default!;

    [Range(1, int.MaxValue)]
    public int TimeoutSeconds { get; set; }

    [Range(0, int.MaxValue)]
    public int RetryCount { get; set; }

    public bool DisallowConcurrent { get; set; } = true;

    [Required]
    [EnumDataType(typeof(JobDefinitionStatus))]
    public JobDefinitionStatus Status { get; set; } = JobDefinitionStatus.Active;
}
