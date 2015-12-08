namespace System.Management.Automation
{
    public class RuntimeException : Exception, IContainsErrorRecord
    {
        public RuntimeException() { }
        public RuntimeException(string message) : base(message) { }
        public RuntimeException(string message, Exception innerException) : base(message, innerException) { }

        public virtual ErrorRecord ErrorRecord { get; }
        public bool WasThrownFromThrowStatement { get; set; }
    }
}