using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.WorkerGroups.Requests;

public sealed class CreateWorkerGroupRequest
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = default!;

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = default!;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Range(30, 600)]
    public int HeartbeatIntervalSeconds { get; set; } = 30;

    [Range(15, 600)]
    public int CommandPollingIntervalSeconds { get; set; } = 15;

    [Range(30, 3600)]
    public int ScheduleSyncIntervalSeconds { get; set; } = 60;

    [Required]
    [EnumDataType(typeof(WorkerGroupStatus))]
    public WorkerGroupStatus Status { get; set; } = WorkerGroupStatus.Active;
}
