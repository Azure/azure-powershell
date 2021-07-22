using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseManagedPrivateEndpointsClientCmdletBase : SynapseCmdletBase
    {
        private SynapseManagedPrivateEndpointsClient _synapseManagedPrivateEndpointClient;
        public virtual string WorkspaceName { get; set; }

        public SynapseManagedPrivateEndpointsClient SynapseManagedPrivateEndpointsClient
        {
            get
            {
                if (_synapseManagedPrivateEndpointClient == null)
                {
                    _synapseManagedPrivateEndpointClient = new SynapseManagedPrivateEndpointsClient(this.WorkspaceName, DefaultProfile.DefaultContext);
                }

                return _synapseManagedPrivateEndpointClient;
            }

            set { _synapseManagedPrivateEndpointClient = value; }
        }
    }
}
