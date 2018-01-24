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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmSecureGateway", SupportsShouldProcess = true), OutputType(typeof(PSSecureGateway))]
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
            ParameterSetName = "SetByResource",
            HelpMessage = "IpConfigurations")]
        [ValidateNotNullOrEmpty]
        public List<PSSecureGatewayIpConfiguration> IpConfigurations { get; set; }

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
            var secureGw = new PSSecureGateway()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.Location,
                IpConfigurations = this.IpConfigurations,
                ApplicationRuleCollections = this.ApplicationRuleCollections
            };

            // Map to the sdk object
            var nsgModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecureGateway>(secureGw);
            nsgModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            nsgModel.Sku = new MNM.SecureGatewaySku
            {
                Name = MNM.SecureGatewaySkuName.StandardLarge,
                Tier = MNM.SecureGatewayTier.Standard
            };

            // Execute the Create Secure Gateway call
            this.SecureGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, nsgModel);

            var getSecureGateway = this.GetSecureGateway(this.ResourceGroupName, this.Name);

            return getSecureGateway;
        }
    }
}
