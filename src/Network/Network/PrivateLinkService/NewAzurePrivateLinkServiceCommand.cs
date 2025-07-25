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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkService", SupportsShouldProcess = true), OutputType(typeof(PSPrivateLinkService))]
    public class NewAzurePrivateLinkService : PrivateLinkServiceBaseCmdlet
    {
        [Alias("ServiceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the service.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/privateLinkServices")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The ip configuration")]
        [ValidateNotNullOrEmpty]
        public PSPrivateLinkServiceIpConfiguration[] IpConfiguration { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The front end ip configuration")]
        [ValidateNotNullOrEmpty]
        public PSFrontendIPConfiguration[] LoadBalancerFrontendIpConfiguration { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The visibility list of the private link service.")]
        public string[] Visibility { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The auto approval list of the private link service.")]
        public string[] AutoApproval { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Whether to enable proxy protocol or not")]
        public SwitchParameter EnableProxyProtocol { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The edge zone of the private link service")]
        public string EdgeZone { get; set; }

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

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The destination IP address")]
        public string DestinationIPAddress { get; set; }

        private PSPrivateLinkService CreatePSPrivateLinkService()
        {
            var psPrivateLinkService = new PSPrivateLinkService
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                Location = Location
            };
            
            psPrivateLinkService.LoadBalancerFrontendIpConfigurations = LoadBalancerFrontendIpConfiguration?.ToList();
            psPrivateLinkService.IpConfigurations = IpConfiguration?.ToList();

            if(Visibility != null)
            {
                psPrivateLinkService.Visibility = new PSPrivateLinkServiceResourceSet();
                psPrivateLinkService.Visibility.Subscriptions = Visibility.ToList();
            }

            if (AutoApproval != null)
            {
                psPrivateLinkService.AutoApproval = new PSPrivateLinkServiceResourceSet();
                psPrivateLinkService.AutoApproval.Subscriptions = AutoApproval.ToList();
            }

            psPrivateLinkService.EnableProxyProtocol = this.EnableProxyProtocol.IsPresent;

            if (!string.IsNullOrEmpty(this.EdgeZone))
            {
                psPrivateLinkService.ExtendedLocation = new PSExtendedLocation(this.EdgeZone);
            }

            psPrivateLinkService.DestinationIPAddress = this.DestinationIPAddress;

            var plsModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PrivateLinkService>(psPrivateLinkService);
            plsModel.Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            this.PrivateLinkServiceClient.CreateOrUpdate(ResourceGroupName, Name, plsModel);
            var getPrivateLinkService = GetPrivateLinkService(ResourceGroupName, Name);

            return getPrivateLinkService;
        }

        public override void Execute()
        {
            base.Execute();
            var present = IsPrivateLinkServicePresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var privateLinkService = CreatePSPrivateLinkService();
                    WriteObject(privateLinkService);
                },
                () => present);
        }
    }
}
