using System.Management.Automation.Host;

namespace System.Management.Automation
{
    public class EngineIntrinsics
    {
        public PSHost Host { get; private set; }

        public SessionState SessionState { get; private set; }
    }
}
