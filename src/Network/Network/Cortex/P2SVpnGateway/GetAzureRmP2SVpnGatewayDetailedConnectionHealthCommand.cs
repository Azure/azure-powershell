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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2sVpnGatewayDetailedConnectionHealth",
        DefaultParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName),
        OutputType(typeof(PSP2SVpnConnectionHealth))]
    public class GetAzureRmP2SVpnGatewayDetailedConnectionHealthCommand : P2SVpnGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/p2sVpnGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("P2SVpnGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The p2s vpn gateway object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSP2SVpnGateway InputObject { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByP2SVpnGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the P2SVpnGateway to be modified.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "OutputBlob Sas url to which the p2s vpn connection health will be written.")]
        [ValidateNotNullOrEmpty]
        public string OutputBlobSasUrl { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of P2S vpn user names to filter.")]
        public string[] VpnUserNamesFilter { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSP2SVpnGateway existingP2SVpnGateway = null;
            if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                existingP2SVpnGateway = this.InputObject;
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnGatewayResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

                existingP2SVpnGateway = this.GetP2SVpnGateway(this.ResourceGroupName, this.Name);
            }

            if (existingP2SVpnGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.P2SVpnGatewayNotFound);
            }

            PSP2SVpnConnectionHealthRequest p2sVpnConnectionHealthParams = new PSP2SVpnConnectionHealthRequest();
            p2sVpnConnectionHealthParams.OutputBlobSasUrl = this.OutputBlobSasUrl;
            p2sVpnConnectionHealthParams.VpnUserNamesFilter = this.VpnUserNamesFilter != null ? this.VpnUserNamesFilter?.ToList() : new List<string>();
            var p2sVpnConnectionHealthParamsModel = NetworkResourceManagerProfile.Mapper.Map<MNM.P2SVpnConnectionHealthRequest>(p2sVpnConnectionHealthParams);

            // There may be a required Json serialize for the returned contents to conform to REST-API
            // The try-catch below handles the case till the change is made and deployed to PROD
            string serializedP2SVpnGatewayDetailedConnectionHealth = this.NetworkClient.GetP2SVpnGatewayDetailedConnectionHealth(this.ResourceGroupName, this.Name, p2sVpnConnectionHealthParamsModel);
            MNM.P2SVpnConnectionHealth p2sVpnGatewayDetailedConnectionHealth = new MNM.P2SVpnConnectionHealth();
            try
            {
                p2sVpnGatewayDetailedConnectionHealth = JsonConvert.DeserializeObject<MNM.P2SVpnConnectionHealth>(serializedP2SVpnGatewayDetailedConnectionHealth);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            PSP2SVpnConnectionHealth p2sVpnGatewayWithHealthResponse = new PSP2SVpnConnectionHealth() { SasUrl = p2sVpnGatewayDetailedConnectionHealth?.SasUrl };
            WriteObject(p2sVpnGatewayWithHealthResponse);
        }
    }
}
