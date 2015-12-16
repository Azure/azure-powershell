namespace System.Management.Automation
{
    public class WarningRecord : InformationalRecord
    {
        public WarningRecord(string message)
        {
            Message = message;
        }
    }
}