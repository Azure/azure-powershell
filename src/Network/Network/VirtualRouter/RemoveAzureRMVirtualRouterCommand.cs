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
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "Remove-AzRouteServer")]
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouter", DefaultParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureVirtualRouterCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName,
            HelpMessage = "The resource group name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName,
            HelpMessage = "The name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RouterName { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual router input object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualRouter InputObject { get; set; }

        [Parameter(
            ParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual router resource Id.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualRouters")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(VirtualRouterParameterSetNames.ByVirtualRouterInputObject, StringComparison.OrdinalIgnoreCase))
            {
                RouterName = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(VirtualRouterParameterSetNames.ByVirtualRouterResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                RouterName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.RemoveVirtualRouterWarning, this.RouterName),
                    Properties.Resources.RemoveResourceMessage,
                    this.RouterName,
                () =>
                {
                    string ipConfigName = "ipconfig1";

                    this.NetworkClient.NetworkManagementClient.VirtualHubIpConfiguration.Delete(ResourceGroupName, RouterName, ipConfigName);
                    this.NetworkClient.NetworkManagementClient.VirtualHubs.Delete(ResourceGroupName, RouterName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
