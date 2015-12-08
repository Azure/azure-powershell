namespace System.Management.Automation
{
    public class PSArgumentException : ArgumentException, IContainsErrorRecord
    {
        public PSArgumentException() { }
        public PSArgumentException(string message) : base(message) { }
        public PSArgumentException(string message, Exception innerException) : base(message, innerException) { }
        public PSArgumentException(string message, string paramName) : base(message, paramName) { }
        public ErrorRecord ErrorRecord { get; private set; }
    }
}