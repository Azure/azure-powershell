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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayFirewallPolicy", SupportsShouldProcess = true), OutputType(typeof(PSApplicationGatewayWebApplicationFirewallPolicy))]
    public class NewAzureApplicationGatewayFirewallPolicyCommand : ApplicationGatewayFirewallPolicyBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/applicationGatewayWebApplicationFirewallPolicies")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of CustomRules")]
        public PSApplicationGatewayFirewallCustomRule[] CustomRule { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsApplicationGatewayFirewallPolicyPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var firewallPolicy = this.CreateApplicationGatewayFirewallPolicy();
                    WriteObject(firewallPolicy);
                },
                () => present);
        }

        private PSApplicationGatewayWebApplicationFirewallPolicy CreateApplicationGatewayFirewallPolicy()
        {
            var firewallPolicy = new PSApplicationGatewayWebApplicationFirewallPolicy();
            firewallPolicy.Name = this.Name;
            firewallPolicy.ResourceGroupName = this.ResourceGroupName;
            firewallPolicy.Location = this.Location;
            firewallPolicy.CustomRules = this.CustomRule?.ToList();

            // Map to the sdk object
            var firewallPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.WebApplicationFirewallPolicy>(firewallPolicy);

            firewallPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create ApplicationGatewayFirewallPolicy call
            this.ApplicationGatewayFirewallPolicyClient.CreateOrUpdate(this.ResourceGroupName, this.Name, firewallPolicyModel);

            var getApplicationGatewayFirewallPolicy = this.GetApplicationGatewayFirewallPolicy(this.ResourceGroupName, this.Name);

            return getApplicationGatewayFirewallPolicy;
        }
    }
}
