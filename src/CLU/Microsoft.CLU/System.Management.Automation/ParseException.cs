namespace System.Management.Automation
{
    public class ParseException : RuntimeException
    {
        public ParseException() { }
        public ParseException(string message) : base(message){ }
        public ParseException(string message, Exception innerException) : base(message, innerException) { }
    }
}