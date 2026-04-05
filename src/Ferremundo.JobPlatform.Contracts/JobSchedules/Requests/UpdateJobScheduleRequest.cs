using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobSchedules.Requests;

public sealed class UpdateJobScheduleRequest
{
    [Required]
    public Guid JobDefinitionGuid { get; set; }

    [Required]
    [EnumDataType(typeof(JobScheduleType))]
    public JobScheduleType ScheduleType { get; set; }

    [MaxLength(120)]
    public string? CronExpression { get; set; }

    [Required]
    [MaxLength(100)]
    public string TimeZoneId { get; set; } = default!;

    public TimeOnly? StartTimeLocal { get; set; }

    [Range(1, int.MaxValue)]
    public int? EveryNValue { get; set; }

    [MaxLength(50)]
    public string? DaysOfWeek { get; set; }

    [Range(1, 31)]
    public byte? DayOfMonth { get; set; }

    [Required]
    [EnumDataType(typeof(JobScheduleStatus))]
    public JobScheduleStatus Status { get; set; } = JobScheduleStatus.Active;
}
