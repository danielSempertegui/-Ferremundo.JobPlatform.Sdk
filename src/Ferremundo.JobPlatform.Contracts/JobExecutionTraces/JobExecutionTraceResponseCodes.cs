namespace Ferremundo.JobPlatform.Contracts.JobExecutionTraces;

public static class JobExecutionTraceResponseCodes
{
    public const string JobExecutionTraceCreated = "JOB_EXECUTION_TRACE_CREATED";
    public const string JobExecutionTraceNotFound = "JOB_EXECUTION_TRACE_NOT_FOUND";
    public const string JobExecutionTraceJobExecutionNotFound = "JOB_EXECUTION_TRACE_JOB_EXECUTION_NOT_FOUND";
    public const string JobExecutionTraceInvalidStepOrder = "JOB_EXECUTION_TRACE_INVALID_STEP_ORDER";
    public const string JobExecutionTraceStepOrderAlreadyExists = "JOB_EXECUTION_TRACE_STEP_ORDER_ALREADY_EXISTS";
    public const string JobExecutionTraceInvalidType = "JOB_EXECUTION_TRACE_INVALID_TYPE";
}
