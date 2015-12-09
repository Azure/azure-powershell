namespace System.Management.Automation
{
    internal class ValidationException : Exception
    {
        public ValidationException(string message) :base(message)
        {
        }
        public ValidationException(string message, Exception internalException) : base(message, internalException)
        {
        }
    }
}
