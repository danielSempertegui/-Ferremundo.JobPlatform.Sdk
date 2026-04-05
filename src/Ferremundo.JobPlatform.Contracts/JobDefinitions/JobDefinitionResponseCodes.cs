namespace Ferremundo.JobPlatform.Contracts.JobDefinitions;

public static class JobDefinitionResponseCodes
{
    public const string JobDefinitionCreated = "JOB_DEFINITION_CREATED";
    public const string JobDefinitionUpdated = "JOB_DEFINITION_UPDATED";
    public const string JobDefinitionDeleted = "JOB_DEFINITION_DELETED";
    public const string JobDefinitionRuntimeStateUpdated = "JOB_DEFINITION_RUNTIME_STATE_UPDATED";
    public const string JobDefinitionNotFound = "JOB_DEFINITION_NOT_FOUND";
    public const string JobDefinitionInvalidStatus = "JOB_DEFINITION_INVALID_STATUS";
    public const string JobDefinitionCodeAlreadyExists = "JOB_DEFINITION_CODE_ALREADY_EXISTS";
    public const string JobDefinitionWorkerGroupNotFound = "JOB_DEFINITION_WORKER_GROUP_NOT_FOUND";
    public const string JobDefinitionInvalidTimeout = "JOB_DEFINITION_INVALID_TIMEOUT";
    public const string JobDefinitionInvalidRetryCount = "JOB_DEFINITION_INVALID_RETRY_COUNT";
    public const string JobDefinitionInvalidRuntimeState = "JOB_DEFINITION_INVALID_RUNTIME_STATE";
}
