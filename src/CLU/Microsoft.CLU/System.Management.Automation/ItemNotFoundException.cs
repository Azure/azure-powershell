namespace System.Management.Automation
{
    public class ItemNotFoundException : SessionStateException
    {
        public ItemNotFoundException() { }
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}