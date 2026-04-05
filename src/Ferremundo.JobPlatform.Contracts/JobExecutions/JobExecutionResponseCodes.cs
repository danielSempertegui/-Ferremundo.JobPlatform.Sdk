namespace Ferremundo.JobPlatform.Contracts.JobExecutions;

public static class JobExecutionResponseCodes
{
    public const string JobExecutionStarted = "JOB_EXECUTION_STARTED";
    public const string JobExecutionCompleted = "JOB_EXECUTION_COMPLETED";
    public const string JobExecutionNotFound = "JOB_EXECUTION_NOT_FOUND";
    public const string JobExecutionJobDefinitionNotFound = "JOB_EXECUTION_JOB_DEFINITION_NOT_FOUND";
    public const string JobExecutionWorkerNodeNotFound = "JOB_EXECUTION_WORKER_NODE_NOT_FOUND";
    public const string JobExecutionWorkerNodeGroupMismatch = "JOB_EXECUTION_WORKER_NODE_GROUP_MISMATCH";
    public const string JobExecutionInvalidSource = "JOB_EXECUTION_INVALID_SOURCE";
    public const string JobExecutionInvalidCompletionStatus = "JOB_EXECUTION_INVALID_COMPLETION_STATUS";
    public const string JobExecutionAlreadyCompleted = "JOB_EXECUTION_ALREADY_COMPLETED";
    public const string JobExecutionConcurrentExecutionNotAllowed = "JOB_EXECUTION_CONCURRENT_EXECUTION_NOT_ALLOWED";
}
