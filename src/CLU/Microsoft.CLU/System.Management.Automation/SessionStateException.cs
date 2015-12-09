namespace System.Management.Automation
{
    public class SessionStateException : RuntimeException
    {
        public SessionStateException() { }
        public SessionStateException(string message) : base(message) { }
        public SessionStateException(string message, Exception innerException) : base(message, innerException) { }
        public string ItemName { get; }
    }
}