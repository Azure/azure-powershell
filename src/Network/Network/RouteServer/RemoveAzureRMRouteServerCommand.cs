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
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServer", DefaultParameterSetName = RouteServerParameterSetNames.ByRouteServerName, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmRouteServerCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            HelpMessage = "The resource group name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerName,
            HelpMessage = "The name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RouteServerName { get; set; }

        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerInputObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The route server input object.")]
        [ValidateNotNullOrEmpty]
        public PSRouteServer InputObject { get; set; }

        [Parameter(
            ParameterSetName = RouteServerParameterSetNames.ByRouteServerResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The route server resource Id.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
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
            if (ParameterSetName.Equals(RouteServerParameterSetNames.ByRouteServerInputObject, StringComparison.OrdinalIgnoreCase))
            {
                RouteServerName = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(RouteServerParameterSetNames.ByRouteServerResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                RouteServerName = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();

            ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.RemoveRouteServerWarning, this.RouteServerName),
                    Properties.Resources.RemoveResourceMessage,
                    this.RouteServerName,
                () =>
                {
                    string ipConfigName = "ipconfig1";

                    this.NetworkClient.NetworkManagementClient.VirtualHubIpConfiguration.Delete(ResourceGroupName, RouteServerName, ipConfigName);
                    this.NetworkClient.NetworkManagementClient.VirtualHubs.Delete(ResourceGroupName, RouteServerName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
