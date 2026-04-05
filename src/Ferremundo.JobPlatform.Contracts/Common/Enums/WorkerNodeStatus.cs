namespace Ferremundo.JobPlatform.Contracts.Common.Enums;

public enum WorkerNodeStatus : byte
{
    Online = 1,
    Offline = 2,
    Busy = 3,
    Disabled = 4,
    Deleted = 5
}
