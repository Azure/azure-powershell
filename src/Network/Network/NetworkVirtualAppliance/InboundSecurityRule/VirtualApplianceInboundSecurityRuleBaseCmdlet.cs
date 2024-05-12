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


using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    public class VirtualApplianceInboundSecurityRuleBaseCmdlet : NetworkBaseCmdlet
    {
        public IInboundSecurityRuleOperations InboundSecurityRuleClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.InboundSecurityRule;
            }
        }

        public PSInboundSecurityRule ToPsInboundSecurityRule(Management.Network.Models.InboundSecurityRule inboundSecurityRule)
        {
            return NetworkResourceManagerProfile.Mapper.Map<PSInboundSecurityRule>(inboundSecurityRule); ;
        }
        public PSInboundSecurityRule CreateOrUpdateInboundSecurityRule(string resourceGroupName, string nvaName, string ruleCollectionName, InboundSecurityRule parameters)
        {
            return this.ToPsInboundSecurityRule(this.InboundSecurityRuleClient.CreateOrUpdate(resourceGroupName, nvaName, ruleCollectionName, parameters));
            
        }
    }
}
