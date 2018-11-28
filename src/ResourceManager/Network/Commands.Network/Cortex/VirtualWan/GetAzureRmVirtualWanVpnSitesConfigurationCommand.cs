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
    using System.Linq;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWanVpnConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteObject,
        SupportsShouldProcess = true), 
        OutputType(typeof(PSVirtualWanVpnSitesConfiguration))]
    public class GetAzureRmVirtualWanVpnSitesConfigurationCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteObject,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteResourceId,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualWanName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteObject,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteResourceId,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualWans", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualWan")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnSiteObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnSiteResourceId,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVirtualWan InputObject { get; set; }

        [Alias("VirtualWanId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnSiteObject,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnSiteResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SAS Url for the storage location where the configuration is to be generated.")]
        [ValidateNotNullOrEmpty]
        public string StorageSasUrl { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteResourceId,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        [ValidateNotNullOrEmpty]
        public string[] VpnSiteId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName + CortexParameterSetNames.ByVpnSiteObject,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        [ValidateNotNullOrEmpty]
        public PSVpnSite[] VpnSite { get; set; }

        public override void Execute()
        {
            base.Execute();

            //// Resolve the virtual wan
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVirtualWanObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.Name))
            {
                throw new PSArgumentException(Properties.Resources.VirtualWanRequiredForVpnSiteConfiguration);
            }

            PSVirtualWan virtualWan = this.GetVirtualWan(this.ResourceGroupName, this.Name);

            List<string> vpnSiteIdsToGetConfigurationFor = new List<string>();
            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteObject))
            {
                foreach (PSVpnSite psVpnSite in this.VpnSite)
                {
                    vpnSiteIdsToGetConfigurationFor.Add(psVpnSite.Id);
                }
            }

            if (ParameterSetName.Contains(CortexParameterSetNames.ByVpnSiteResourceId))
            {
                vpnSiteIdsToGetConfigurationFor.AddRange(this.VpnSiteId);
            }

            WriteObject(this.GetVirtualWanVpnSitesConfiguration(virtualWan, vpnSiteIdsToGetConfigurationFor, this.StorageSasUrl));
        }
    }
}
