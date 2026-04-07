using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobSchedules.Responses;

public sealed class JobScheduleResponse
{
    public Guid JobScheduleGuid { get; set; }

    public Guid JobDefinitionGuid { get; set; }

    public Guid WorkerGroupGuid { get; set; }

    public string JobDefinitionCode { get; set; } = default!;

    public string JobDefinitionName { get; set; } = default!;

    public JobScheduleType ScheduleType { get; set; }

    public string CronExpression { get; set; } = default!;

    public string TimeZoneId { get; set; } = default!;

    public TimeOnly? StartTimeLocal { get; set; }

    public int? EveryNValue { get; set; }

    public string? DaysOfWeek { get; set; }

    public byte? DayOfMonth { get; set; }

    public JobScheduleStatus Status { get; set; }

    public DateTime? LastAppliedAtUtc { get; set; }

    public bool PendingApply { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }
}
