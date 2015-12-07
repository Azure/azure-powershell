namespace System.Management.Automation
{
    public class VerboseRecord : InformationalRecord
    {
        public VerboseRecord(string message)
        {
            Message = message;
        }
    }
}