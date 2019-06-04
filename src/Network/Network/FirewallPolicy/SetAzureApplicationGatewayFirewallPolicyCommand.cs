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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallPolicy", DefaultParameterSetName = "ByFactoryObject", SupportsShouldProcess = true), OutputType(typeof(PSApplicationGatewayWebApplicationFirewallPolicy))]
    public class SetAzureApplicationGatewayFirewallPolicyCommand : ApplicationGatewayFirewallPolicyBaseCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Mandatory = true,
            HelpMessage = "The Firewall Policy Name.")]
        [ResourceNameCompleter("Microsoft.Network/applicationGatewayWebApplicationFirewallPolicies", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByFactoryName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             ParameterSetName = ParameterSetNames.ByFactoryObject,
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGatewayFirewallPolicy")]
        public PSApplicationGatewayWebApplicationFirewallPolicy InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of CustomRules")]
        public PSApplicationGatewayFirewallCustomRule[] CustomRule { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.OverwritingResourceMessage))
            {
                if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
                {
                    Name = InputObject.Name;
                    ResourceGroupName = InputObject.ResourceGroupName;
                }
                else if (ParameterSetName.Equals(ParameterSetNames.ByResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                base.ExecuteCmdlet();

                if (!this.IsApplicationGatewayFirewallPolicyPresent(ResourceGroupName, Name))
                {
                    throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                }

                var firewallPolicy = this.GetApplicationGatewayFirewallPolicy(ResourceGroupName, Name);
                if (this.CustomRule != null)
                {
                    firewallPolicy.CustomRules = this.CustomRule.ToList();
                }
                else if (ParameterSetName.Equals(ParameterSetNames.ByFactoryObject, StringComparison.OrdinalIgnoreCase))
                {
                    firewallPolicy = InputObject;
                }

                // Map to the sdk object
                var firewallPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.WebApplicationFirewallPolicy>(firewallPolicy);
                firewallPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(firewallPolicy.Tag, validate: true);

                // Execute the Create VirtualNetwork call
                this.ApplicationGatewayFirewallPolicyClient.CreateOrUpdate(ResourceGroupName, Name, firewallPolicyModel);

                var getApplicationGatewayFirewallPolicy = this.GetApplicationGatewayFirewallPolicy(ResourceGroupName, Name);
                WriteObject(getApplicationGatewayFirewallPolicy);
            }
        }
    }
}
