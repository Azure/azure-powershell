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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;
    using Newtonsoft.Json;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet("Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWanVpnServerConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName),
        OutputType(typeof(PSVpnServerConfigurationsResponse))]
    public class GetAzureRmVirtualWanVpnServerConfigurationsCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualWans", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualWan")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual wan object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualWan VirtualWanObject { get; set; }

        [Alias("VirtualWanId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWan")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSVirtualWan virtualWan = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                virtualWan = this.VirtualWanObject;
                this.ResourceGroupName = this.VirtualWanObject.ResourceGroupName;
                this.Name = this.VirtualWanObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                virtualWan = GetVirtualWan(this.ResourceGroupName, this.Name);
            }

            if (virtualWan == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualWanNotFound);
            }

            // There may be a required Json serialize for the returned contents to conform to REST-API
            // The try-catch below handles the case till the change is made and deployed to PROD
            string serializedVpnServerConfigurations = this.NetworkClient.GetVirtualWanVpnServerConfigurations(this.ResourceGroupName, this.Name);
            MNM.VpnServerConfigurationsResponse vpnServerConfigurations = new MNM.VpnServerConfigurationsResponse();
            try
            {
                vpnServerConfigurations = JsonConvert.DeserializeObject<MNM.VpnServerConfigurationsResponse>(serializedVpnServerConfigurations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            PSVpnServerConfigurationsResponse vpnServerConfigurationsResponse = new PSVpnServerConfigurationsResponse() { VpnServerConfigurationResourceIds = vpnServerConfigurations?.VpnServerConfigurationResourceIds.ToList() };
            WriteObject(vpnServerConfigurationsResponse);
        }
    }
}
