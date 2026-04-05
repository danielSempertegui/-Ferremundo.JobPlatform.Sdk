using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.WorkerNodes.Requests;

public sealed class UpdateWorkerNodeRequest
{
    [Required]
    public Guid WorkerGroupGuid { get; set; }

    [Required]
    [MaxLength(100)]
    public string NodeName { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string MachineName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    public string Environment { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string OperatingSystem { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    public string WorkerVersion { get; set; } = default!;

    [Required]
    [EnumDataType(typeof(WorkerNodeStatus))]
    public WorkerNodeStatus Status { get; set; }
}
