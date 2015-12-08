namespace System.Management.Automation
{
    public interface IContainsErrorRecord
    {
        ErrorRecord ErrorRecord { get; }
    }
}