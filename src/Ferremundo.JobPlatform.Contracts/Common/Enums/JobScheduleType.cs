namespace Ferremundo.JobPlatform.Contracts.Common.Enums;

public enum JobScheduleType : byte
{
    Daily = 1,
    Weekly = 2,
    Monthly = 3,
    EveryNMinutes = 4,
    EveryNHours = 5,
    CustomCron = 6
}
