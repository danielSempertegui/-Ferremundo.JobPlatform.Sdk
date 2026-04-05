using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.WorkerGroups.Requests;

public sealed class UpdateWorkerGroupRequest
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = default!;

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = default!;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    [EnumDataType(typeof(WorkerGroupStatus))]
    public WorkerGroupStatus Status { get; set; }
}
