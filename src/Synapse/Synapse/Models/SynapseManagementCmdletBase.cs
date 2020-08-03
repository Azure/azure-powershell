using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
