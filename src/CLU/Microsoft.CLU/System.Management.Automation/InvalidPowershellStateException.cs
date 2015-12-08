namespace System.Management.Automation
{
    public class InvalidPowerShellStateException : Exception
    {
        public InvalidPowerShellStateException() { }
        public InvalidPowerShellStateException(string message) : base(message) { }
        public InvalidPowerShellStateException(string message, Exception innerException) : base(message, innerException) { }
        public PSInvocationState CurrentState { get; }
    }
}