using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    public abstract class InformationalRecord
    {
        public InvocationInfo InvocationInfo { get; private set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}