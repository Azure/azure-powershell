namespace System.Management.Automation
{
    public class PSInvalidOperationException : InvalidOperationException, IContainsErrorRecord
    {
        public PSInvalidOperationException() { }
        public PSInvalidOperationException(string message) : base(message) { }
        public PSInvalidOperationException(string message, Exception innerException) : base(message, innerException) { }
        public ErrorRecord ErrorRecord { get; }
    }
}