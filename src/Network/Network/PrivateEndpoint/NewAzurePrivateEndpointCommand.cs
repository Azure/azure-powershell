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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateEndpoint", SupportsShouldProcess = true), OutputType(typeof(PSPrivateEndpoint))]
    public class NewAzurePrivateEndpoint : PrivateEndpointBaseCmdlet
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
        [LocationCompleter("Microsoft.Network/privateEndpoints")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The subnet of the private endpoint")]
        [ValidateNotNullOrEmpty]
        public PSSubnet Subnet { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The private link service connection.")]
        public PSPrivateLinkServiceConnection[] PrivateLinkServiceConnection { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Using manual request.")]
        public SwitchParameter ByManualRequest { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        private PSPrivateEndpoint CreatePSPrivateEndpoint()
        {
            var psPrivateEndpoint = new PSPrivateEndpoint
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                Location = Location,
                Subnet = Subnet
            };

            if (this.ByManualRequest.IsPresent)
            {
                psPrivateEndpoint.ManualPrivateLinkServiceConnections = this.PrivateLinkServiceConnection.ToList();
            }
            else
            {
                psPrivateEndpoint.PrivateLinkServiceConnections = this.PrivateLinkServiceConnection.ToList();
            }
            
            var peModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PrivateEndpoint>(psPrivateEndpoint);
            peModel.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            this.PrivateEndpointClient.CreateOrUpdate(ResourceGroupName, Name, peModel);
            var getPrivateEndpoint = GetPrivateEndpoint(ResourceGroupName, Name);

            return getPrivateEndpoint;
        }

        public override void Execute()
        {
            base.Execute();
            var present = IsPrivateEndpointPresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var privateEndpoint = CreatePSPrivateEndpoint();
                    WriteObject(privateEndpoint);
                },
                () => present);
        }
    }
}
