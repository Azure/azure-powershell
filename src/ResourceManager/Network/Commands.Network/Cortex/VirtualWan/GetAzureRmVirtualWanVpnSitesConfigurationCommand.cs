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
        "AzureRmVirtualWanVpnSitesConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName,
        SupportsShouldProcess = true), 
        OutputType(typeof(PSVirtualWanVpnSitesConfiguration))]
    public class GetAzureRmVirtualWanVpnSitesConfigurationCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName", "VirtualWanName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VirtualWan")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVirtualWan InputObject { get; set; }

        [Alias("VirtualWanId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The SAS Url for the storage location where the configuration is to be generated.")]
        [ValidateNotNullOrEmpty]
        public string StorageSasUrl { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnSite resource ids to generate configuration for.")]
        public List<string> VpnSiteId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of VpnSites to generate configuration for.")]
        public List<PSVpnSite> VpnSite { get; set; }

        public override void Execute()
        {
            base.Execute();

            //// Resolve the virtual wan
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.Name))
            {
                throw new PSArgumentException("A valid Virtual WAN is required to generate a vpnSites configuration.");
            }

            PSVirtualWan virtualWan = this.GetVirtualWan(this.ResourceGroupName, this.Name);

            //// Resolve the VpnSites
            if (this.VpnSite != null && this.VpnSite.Any())
            {
                this.VpnSiteId = new List<string>();
                foreach (PSVpnSite psVpnSite in this.VpnSite)
                {
                    this.VpnSiteId.Add(psVpnSite.Id);
                }
            }

            if (this.VpnSiteId == null || !this.VpnSiteId.Any())
            {
                throw new PSArgumentException("A list of connected VpnSites is required to generate a vpnSites configuration.");
            }

            WriteObject(this.GetVirtualWanVpnSitesConfiguration(virtualWan, this.VpnSiteId, this.StorageSasUrl));
        }
    }
}
