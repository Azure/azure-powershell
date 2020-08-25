using Microsoft.Azure.Commands.Synapse.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseSparkCmdletBase : SynapseCmdletBase
    {
        private SynapseAnalyticsSparkClient _synapseAnalyticsSparkClient;
        public virtual string WorkspaceName { get; set; }
        public virtual string SparkPoolName { get; set; }

        public SynapseAnalyticsSparkClient SynapseAnalyticsClient
        {
            get
            {
                if (_synapseAnalyticsSparkClient == null)
                {
                    _synapseAnalyticsSparkClient = new SynapseAnalyticsSparkClient(this.WorkspaceName, this.SparkPoolName, DefaultProfile.DefaultContext);
                }

                return _synapseAnalyticsSparkClient;
            }

            set { _synapseAnalyticsSparkClient = value; }
        }
    }
}
