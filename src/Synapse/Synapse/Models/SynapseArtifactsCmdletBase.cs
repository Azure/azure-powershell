using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseArtifactsCmdletBase : SynapseCmdletBase
    {
        private SynapseAnalyticsArtifactsClient _synapseAnalyticsDataFactoryClient;
        public virtual string WorkspaceName { get; set; }

        public SynapseAnalyticsArtifactsClient SynapseAnalyticsClient
        {
            get
            {
                if (_synapseAnalyticsDataFactoryClient == null)
                {
                    _synapseAnalyticsDataFactoryClient = new SynapseAnalyticsArtifactsClient(this.WorkspaceName, DefaultProfile.DefaultContext);
                }

                return _synapseAnalyticsDataFactoryClient;
            }

            set { _synapseAnalyticsDataFactoryClient = value; }
        }
    }
}
