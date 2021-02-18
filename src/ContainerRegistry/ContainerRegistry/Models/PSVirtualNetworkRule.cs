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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSVirtualNetworkRule : IPSNetworkRule
    {
        public PSVirtualNetworkRule(string virtualNetworkResourceId, string action = default(string))
        {
            Action = action;
            VirtualNetworkResourceId = virtualNetworkResourceId;
            Validate();
        }

        public PSVirtualNetworkRule(VirtualNetworkRule rule)
        {
            Action = rule.Action;
            VirtualNetworkResourceId = rule.VirtualNetworkResourceId;
            Validate();
        }

        public string Action { get; set; }

        public string NetworkRuleType
        {
            get { return "VirtualNetworkRule"; }
        }

        public string VirtualNetworkResourceId { get; set; }

        public void Validate()
        {
            if (this.VirtualNetworkResourceId == null)
            {
                throw new PSArgumentNullException("VirtualNetworkResourceId of Virtual network rule cannot be null");
            }
        }

        public VirtualNetworkRule GetVirtualNetworkRule()
        {
            return new VirtualNetworkRule
            {
                Action = this.Action,
                VirtualNetworkResourceId = this.VirtualNetworkResourceId
            };
        }
    }
}
