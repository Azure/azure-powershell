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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmSecureGateway", SupportsShouldProcess = true),
        OutputType(typeof(PSSecureGateway))]
    public class NewAzureSecureGatewayCommand : SecureGatewayBaseCmdlet
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
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SKU of secure gateway")]
        [ValidateNotNullOrEmpty]
        public virtual PSSecureGatewaySku Sku { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "VirtualHubId")]
        [ValidateNotNullOrEmpty]
        public string VirtualHubId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "VirtualHub")]
        public PSSubnet VirtualHub { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "VirtualNetworkId")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "VirtualNetwork")]
        public PSSubnet VirtualNetwork { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of SecureGatewayNetworkRuleCollections")]
        public List<PSSecureGatewayNetworkRuleCollection> NetworkRuleCollections { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of SecureGatewayApplicationRuleCollections")]
        public List<PSSecureGatewayApplicationRuleCollection> ApplicationRuleCollections { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = this.IsSecureGatewayPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var secureGw = this.CreateSecureGateway();
                    WriteObject(secureGw);
                },
                () => present);
        }

        private PSSecureGateway CreateSecureGateway()
        {
            var secureGw = new PSSecureGateway();
            secureGw.Name = this.Name;
            secureGw.ResourceGroupName = this.ResourceGroupName;
            secureGw.Location = this.Location;
            secureGw.Sku = this.Sku;

            if (this.VirtualHub != null)
            {
                secureGw.VirtualHub = new PSResourceId();
                secureGw.VirtualHub.Id = this.VirtualHub.Id;
            }

            if (this.VirtualNetwork != null)
            {
                secureGw.VirtualNetwork = new PSResourceId();
                secureGw.VirtualNetwork.Id = this.VirtualNetwork.Id;
            }

            if (this.ApplicationRuleCollections != null)
            {
                secureGw.ApplicationRuleCollections = this.ApplicationRuleCollections;
            }

            if (this.NetworkRuleCollections != null)
            {
                secureGw.NetworkRuleCollections = this.NetworkRuleCollections;
            }

            // Map to the sdk object
            var nsgModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecureGateway>(secureGw);
            nsgModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create Secure Gateway call
            this.SecureGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, nsgModel);

            var getSecureGateway = this.GetSecureGateway(this.ResourceGroupName, this.Name);

            return getSecureGateway;
        }
    }
}
