namespace System.Management.Automation
{
    public class PSArgumentOutOfRangeException : ArgumentOutOfRangeException, IContainsErrorRecord
    {
        public PSArgumentOutOfRangeException() { }
        public PSArgumentOutOfRangeException(string paramName) : base(paramName) { }
        public PSArgumentOutOfRangeException(string message, Exception innerException) : base(message, innerException) { }
        public PSArgumentOutOfRangeException(string paramName, object actualValue, string message) : base(paramName, actualValue, message) { }
        public ErrorRecord ErrorRecord { get; }
    }
}