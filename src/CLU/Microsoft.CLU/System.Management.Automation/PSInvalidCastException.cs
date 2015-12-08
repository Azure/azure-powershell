namespace System.Management.Automation
{
    public class PSInvalidCastException : InvalidCastException, IContainsErrorRecord
    {
        public PSInvalidCastException() { }
        public PSInvalidCastException(string message) : base(message) { }
        public PSInvalidCastException(string message, Exception innerException) : base(message, innerException) { }
        public ErrorRecord ErrorRecord { get; }
    }
}