namespace System.Management.Automation
{
    public enum PSInvocationState
    {
        NotStarted = 0,
        Running = 1,
        Stopping = 2,
        Stopped = 3,
        Completed = 4,
        Failed = 5,
        Disconnected = 6
    }
}