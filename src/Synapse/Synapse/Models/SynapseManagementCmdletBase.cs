using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseManagementCmdletBase : SynapseCmdletBase
    {
        private SynapseAnalyticsManagementClient _synapseAnalyticsManagementClient;

        public SynapseAnalyticsManagementClient SynapseAnalyticsClient
        {
            get
            {
                if (_synapseAnalyticsManagementClient == null)
                {
                    _synapseAnalyticsManagementClient = new SynapseAnalyticsManagementClient(DefaultProfile.DefaultContext);
                }

                return _synapseAnalyticsManagementClient;
            }

            set { _synapseAnalyticsManagementClient = value; }
        }
    }
}
