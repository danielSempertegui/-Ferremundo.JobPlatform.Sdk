namespace Ferremundo.JobPlatform.Contracts.JobCommands;

public static class JobCommandResponseCodes
{
    public const string JobCommandRunNowRequested = "JOB_COMMAND_RUN_NOW_REQUESTED";
    public const string JobCommandStatusUpdated = "JOB_COMMAND_STATUS_UPDATED";
    public const string JobCommandNotFound = "JOB_COMMAND_NOT_FOUND";
    public const string JobCommandJobDefinitionNotFound = "JOB_COMMAND_JOB_DEFINITION_NOT_FOUND";
    public const string JobCommandWorkerNodeNotFound = "JOB_COMMAND_WORKER_NODE_NOT_FOUND";
    public const string JobCommandWorkerNodeGroupMismatch = "JOB_COMMAND_WORKER_NODE_GROUP_MISMATCH";
    public const string JobCommandPendingRunNowAlreadyExists = "JOB_COMMAND_PENDING_RUN_NOW_ALREADY_EXISTS";
    public const string JobCommandInvalidStatus = "JOB_COMMAND_INVALID_STATUS";
    public const string JobCommandInvalidCompletionStatus = "JOB_COMMAND_INVALID_COMPLETION_STATUS";
    public const string JobCommandAlreadyProcessed = "JOB_COMMAND_ALREADY_PROCESSED";
    public const string JobCommandAssignedToAnotherWorkerNode = "JOB_COMMAND_ASSIGNED_TO_ANOTHER_WORKER_NODE";
}
