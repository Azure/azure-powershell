namespace System.Management.Automation
{
    [Flags]
    public enum CommandTypes
    {
        Alias = 1,
        Function = 2,
        Filter = 4,
        Cmdlet = 8,
        ExternalScript = 16,
        Application = 32,
        Script = 64,
        All = 127
    }
}
