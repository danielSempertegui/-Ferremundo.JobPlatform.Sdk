namespace Ferremundo.JobPlatform.Contracts.Common.Enums;

public enum JobExecutionStatus : byte
{
    Pending = 1,
    Running = 2,
    Succeeded = 3,
    Failed = 4,
    Cancelled = 5
}
