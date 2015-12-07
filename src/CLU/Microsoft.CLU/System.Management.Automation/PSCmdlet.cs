using System.Management.Automation.Host;

namespace System.Management.Automation
{
    public abstract class PSCmdlet : Cmdlet
    {
        public PSHost Host { get { return CommandRuntime.Host; } }

        public InvocationInfo MyInvocation { get; internal set; }

        public string ParameterSetName { get; internal set; }

        public SessionState SessionState { get; internal set; }
    }
}