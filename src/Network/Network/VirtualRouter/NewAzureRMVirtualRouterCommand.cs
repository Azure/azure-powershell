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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouter", SupportsShouldProcess = true, DefaultParameterSetName = VirtualRouterParameterSetNames.ByHostedGateway), OutputType(typeof(PSVirtualRouter))]
    public partial class NewAzureRmVirtualRouter : VirtualRouterBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualRouterParameterSetNames.ByHostedGateway,
            HelpMessage = "The gateway where Virtual Router needs to be hosted.")]
        public PSVirtualNetworkGateway HostedGateway { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = VirtualRouterParameterSetNames.ByHostedGatewayId,
            HelpMessage = "The id of gateway where Virtual Router needs to be hosted.")]
        [ResourceIdCompleter("Microsoft.Network/virtualNetworkGateways")]
        public string HostedGatewayId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
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

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.VirtualRouters.Get(this.ResourceGroupName, this.Name);
            }
            catch (Exception ex)
            {
                if (ex is Microsoft.Azure.Management.Network.Models.ErrorException || ex is Rest.Azure.CloudException)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (present)
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            string hostedGatewayId = null;

            //// Resolve the virtual wan
            if (ParameterSetName.Equals(VirtualRouterParameterSetNames.ByHostedGateway, StringComparison.OrdinalIgnoreCase))
            {
                hostedGatewayId = this.HostedGateway.Id;
            }
            else if (ParameterSetName.Equals(VirtualRouterParameterSetNames.ByHostedGatewayId, StringComparison.OrdinalIgnoreCase))
            {
                hostedGatewayId = this.HostedGatewayId;
            }

            if (string.IsNullOrWhiteSpace(hostedGatewayId))
            {
                throw new PSArgumentException(Properties.Resources.VirtualGatewayRequiredForVirtualRouter);
            }


            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    PSVirtualRouter virtualRouter = new PSVirtualRouter
                    {
                        ResourceGroupName = this.ResourceGroupName,
                        Name = this.Name,
                        HostedGateway = new PSResourceId() { Id = hostedGatewayId },
                        Location = this.Location,
                        VirtualRouterAsn = GatewayAsn
                    };

                    var vVirtualRouterModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualRouter>(virtualRouter);
                    vVirtualRouterModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

                    this.NetworkClient.NetworkManagementClient.VirtualRouters.CreateOrUpdate(this.ResourceGroupName, this.Name, vVirtualRouterModel);
                    var getVirtualRouter = this.NetworkClient.NetworkManagementClient.VirtualRouters.Get(this.ResourceGroupName, this.Name);
                    var psVirtualRouter = NetworkResourceManagerProfile.Mapper.Map<PSVirtualRouter>(getVirtualRouter);
                    psVirtualRouter.ResourceGroupName = this.ResourceGroupName;
                    psVirtualRouter.Tag = TagsConversionHelper.CreateTagHashtable(getVirtualRouter.Tags);
                    WriteObject(psVirtualRouter, true);
                });

        }
    }
}
