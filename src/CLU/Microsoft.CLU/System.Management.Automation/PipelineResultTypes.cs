namespace System.Management.Automation.Runspaces
{
    [Flags]
    public enum PipelineResultTypes
    {
        None = 0,
        Output = 1,
        Error = 2,
        Warning = 3,
        Verbose = 4,
        Debug = 5,
        All = 6,
        Null = 7
    }
}