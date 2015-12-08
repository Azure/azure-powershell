namespace System.Management.Automation
{
    public sealed class PSInvocationStateInfo
    {
        public Exception Reason { get; private set; }
        public PSInvocationState State { get; private set; }
    }
}