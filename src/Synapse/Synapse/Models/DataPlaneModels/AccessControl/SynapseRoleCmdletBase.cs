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
