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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet("Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWanVpnServerConfigurationVpnProfile",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationObject),
        OutputType(typeof(PSVpnProfileResponse))]
    public class GetAzureRmVirtualWanVpnServerConfigurationVpnProfileCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualWans", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualWan")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual wan object.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual wan object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualWan VirtualWanObject { get; set; }

        [Alias("VirtualWanId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnServerConfigurationObject,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWan")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration with which this VirtualWan is associated.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration with which this VirtualWan is associated.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnServerConfigurationObject,
            HelpMessage = "The VpnServerConfiguration with which this VirtualWan is associated.")]
        [ValidateNotNull]
        public PSVpnServerConfiguration VpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuraiton object this Virtual wan will be associated with.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuraiton object this Virtual wan will be associated with.")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnServerConfigurationResourceId,
            HelpMessage = "The id of Vpn server configuraiton object this Virtual wan will be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/vpnServerConfigurations")]
        public string VpnServerConfigurationId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Authentication Method")]
        [ValidateSet(
            MNM.AuthenticationMethod.EAPTLS,
            MNM.AuthenticationMethod.EAPMSCHAPv2,
            IgnoreCase = true)]
        public string AuthenticationMethod { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSVirtualWan virtualWan = null;
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualWanObject))
            {
                virtualWan = this.VirtualWanObject;
                this.ResourceGroupName = this.VirtualWanObject.ResourceGroupName;
                this.Name = this.VirtualWanObject.Name;
            }
            else
            {
                if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualWanResourceId))
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

            PSVirtualWanVpnProfileParameters virtualWanVpnProfileParams = new PSVirtualWanVpnProfileParameters();

            virtualWanVpnProfileParams.AuthenticationMethod = string.IsNullOrWhiteSpace(this.AuthenticationMethod)
                ? MNM.AuthenticationMethod.EAPTLS.ToString()
                : this.AuthenticationMethod;

            if (this.VpnServerConfiguration != null)
            {
                virtualWanVpnProfileParams.VpnServerConfigurationResourceId = this.VpnServerConfiguration.Id;
            }

            var virtualWanVpnProfileParametersModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualWanVpnProfileParameters>(virtualWanVpnProfileParams);

            // There may be a required Json serialize for the package URL to conform to REST-API
            // The try-catch below handles the case till the change is made and deployed to PROD
            string serializedPackageUrl = this.NetworkClient.GenerateVirtualWanVpnProfile(this.ResourceGroupName, this.Name, virtualWanVpnProfileParametersModel);
            MNM.VpnProfileResponse vpnProfile = new MNM.VpnProfileResponse();
            try
            {
                vpnProfile = JsonConvert.DeserializeObject<MNM.VpnProfileResponse>(serializedPackageUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            PSVpnProfileResponse vpnProfileResponse = new PSVpnProfileResponse() { ProfileUrl = vpnProfile.ProfileUrl };
            WriteObject(vpnProfileResponse);
        }
    }
}
