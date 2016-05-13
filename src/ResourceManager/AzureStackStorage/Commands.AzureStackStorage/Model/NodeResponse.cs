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

using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal class NodeResponse : ResponseBase
    {
        public NodeResponse(NodeModel resource) : base(resource)
        {
        }

        public string CodeVersion { get; set; }

        public string ConfigVersion { get; set; }

        public Uri FaultDomain { get; set; }

        public HealthStatus HealthState { get; set; }


        public string IpAddressOrFqdn { get; set; }

        public bool IsSeedNode { get; set; }

        public string NodeId { get; set; }

        public string NodeName { get; set; }

        public NodeStatus NodeStatus { get; set; }

        public string NodeType { get; set; }

        public TimeSpan NodeUpTime { get; set; }

        public string UpgradeDomain { get; set; }

        public IEnumerable<string> RunningInstanceUris { get; set; }
    }
}
