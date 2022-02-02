// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
