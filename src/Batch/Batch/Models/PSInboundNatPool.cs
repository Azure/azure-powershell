// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSInboundNatPool
    {
        internal static Azure.Batch.InboundNatPool FromMgmtInboundNatPool(InboundNatPool e)
        {
            if (e == null)
            {
                return null;
            }
            return new Azure.Batch.InboundNatPool(
            name: e.Name,
            protocol: Utils.Utils.FromMgmtInboundEndpointProtocol(e.Protocol),
            backendPort: e.BackendPort,
            frontendPortRangeStart: e.FrontendPortRangeStart,
            frontendPortRangeEnd: e.FrontendPortRangeEnd,
            networkSecurityGroupRules: (IReadOnlyList<Microsoft.Azure.Batch.NetworkSecurityGroupRule>)((e.NetworkSecurityGroupRules != null ? e.NetworkSecurityGroupRules.Select(PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule).ToList() : null))
        );
        }

        internal InboundNatPool toMgmtInboundNatPool()
        {
            return new InboundNatPool()
            {
                Name = this.Name,
                Protocol = Utils.Utils.ToMgmtInboundEndpointProtocol(this.Protocol),
                BackendPort = this.BackendPort,
                FrontendPortRangeStart = this.FrontendPortRangeStart,
                FrontendPortRangeEnd = this.FrontendPortRangeEnd,
                NetworkSecurityGroupRules = (this.NetworkSecurityGroupRules != null) ? this.NetworkSecurityGroupRules.Select(e => e.toMgmtNetworkSecurityGroupRule()).ToList() : null
            };
        }
    }
}
