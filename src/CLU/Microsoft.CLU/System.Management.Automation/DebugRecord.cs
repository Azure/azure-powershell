namespace System.Management.Automation
{
    public class DebugRecord : InformationalRecord
    {
        public DebugRecord(string message)
        {
            Message = message;
        }
    }
}