namespace System.Management.Automation
{
    public class PSArgumentNullException : ArgumentNullException, IContainsErrorRecord
    {
        public PSArgumentNullException() { }
        public PSArgumentNullException(string paramName) : base(paramName) { }
        public PSArgumentNullException(string paramName, string message) : base(paramName, message) { }
        public PSArgumentNullException(string message, Exception innerException) : base(message, innerException) { }
        public ErrorRecord ErrorRecord { get; }
    }
}