using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseRoleCmdletBase : SynapseCmdletBase
    {
        private SynapseAnalyticsRoleClient _synapseAnalyticsRoleClient;
        public virtual string WorkspaceName { get; set; }

        public SynapseAnalyticsRoleClient SynapseAnalyticsClient
        {
            get
            {
                if (_synapseAnalyticsRoleClient == null)
                {
                    _synapseAnalyticsRoleClient = new SynapseAnalyticsRoleClient(this.WorkspaceName, DefaultProfile.DefaultContext);
                }

                return _synapseAnalyticsRoleClient;
            }

            set { _synapseAnalyticsRoleClient = value; }
        }
    }
}
