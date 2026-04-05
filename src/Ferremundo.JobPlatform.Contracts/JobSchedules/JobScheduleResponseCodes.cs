namespace Ferremundo.JobPlatform.Contracts.JobSchedules;

public static class JobScheduleResponseCodes
{
    public const string JobScheduleCreated = "JOB_SCHEDULE_CREATED";
    public const string JobScheduleUpdated = "JOB_SCHEDULE_UPDATED";
    public const string JobScheduleDeleted = "JOB_SCHEDULE_DELETED";
    public const string JobScheduleNotFound = "JOB_SCHEDULE_NOT_FOUND";
    public const string JobScheduleJobDefinitionNotFound = "JOB_SCHEDULE_JOB_DEFINITION_NOT_FOUND";
    public const string JobScheduleAlreadyExists = "JOB_SCHEDULE_ALREADY_EXISTS";
    public const string JobScheduleInvalidStatus = "JOB_SCHEDULE_INVALID_STATUS";
    public const string JobScheduleInvalidTimeZone = "JOB_SCHEDULE_INVALID_TIME_ZONE";
    public const string JobScheduleInvalidStartTime = "JOB_SCHEDULE_INVALID_START_TIME";
    public const string JobScheduleInvalidEveryNValue = "JOB_SCHEDULE_INVALID_EVERY_N_VALUE";
    public const string JobScheduleInvalidDaysOfWeek = "JOB_SCHEDULE_INVALID_DAYS_OF_WEEK";
    public const string JobScheduleInvalidDayOfMonth = "JOB_SCHEDULE_INVALID_DAY_OF_MONTH";
    public const string JobScheduleInvalidCronExpression = "JOB_SCHEDULE_INVALID_CRON_EXPRESSION";
    public const string JobScheduleCannotBeModifiedWhileRunning = "JOB_SCHEDULE_CANNOT_BE_MODIFIED_WHILE_RUNNING";
}
