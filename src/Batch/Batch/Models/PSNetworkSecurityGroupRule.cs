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
    public partial class PSNetworkSecurityGroupRule
    {
        public static Microsoft.Azure.Batch.NetworkSecurityGroupRule FromMgmtNetworkSecurityGroupRule(NetworkSecurityGroupRule rule)
        {
            if (rule == null)
            {
                return null;
            }
            return new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                priority: rule.Priority,
                access: Utils.Utils.FromMgmtNetworkSecurityRuleAccess(rule.Access),
                sourceAddressPrefix: rule.SourceAddressPrefix,
                sourcePortRanges: (IReadOnlyList<string>)(rule.SourcePortRanges)
            );
        }

        public Microsoft.Azure.Management.Batch.Models.NetworkSecurityGroupRule toMgmtNetworkSecurityGroupRule()
        {
            return new NetworkSecurityGroupRule(
                priority: this.Priority,
                access: Utils.Utils.ToMgmtNetworkSecurityRuleAccess(this.Access),
                sourceAddressPrefix: this.SourceAddressPrefix,
                sourcePortRanges: (IList<string>)this.SourcePortRanges
            );
        }
    }
}
