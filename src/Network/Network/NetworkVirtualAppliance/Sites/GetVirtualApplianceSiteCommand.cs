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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceSite", DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSVirtualApplianceSite))]
    public class GetVirtualApplianceSiteCommand : VirtualApplianceSiteBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        private string NvaName;

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = ResourceNameParameterSet)]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Network Virtual Appliance that the site is attached.",
            ParameterSetName = ResourceNameParameterSet)]
        public virtual string NetworkVirtualApplianceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = ResourceNameParameterSet)]
        [ResourceGroupCompleter]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id of the Virtual Appliance Site.",
            ParameterSetName = ResourceIdParameterSet)]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                this.NvaName = GetResourceName(this.ResourceId, "Microsoft.Network/networkVirtualAppliances", "virtualApplianceSites");
                this.Name = GetResourceName(this.ResourceId, "virtualAppliancesites");
            }
            else
            {
                this.NvaName = GetResourceName(this.NetworkVirtualApplianceId, "Microsoft.Network/networkVirtualAppliances");
                if (!(String.IsNullOrEmpty(NetworkVirtualApplianceId)))
                {
                    string nvaRg = GetResourceGroup(NetworkVirtualApplianceId);
                    if (!nvaRg.Equals(this.ResourceGroupName))
                    {
                        throw new Exception("The resource group for Network Virtual Appliance is not same as that of site.");
                    }
                }
            }
            if (ShouldGetByName(this.ResourceGroupName, this.NvaName, this.Name))
            { 
                var site = this.GetVirtualApplianceSite(this.ResourceGroupName, this.NvaName, this.Name);
                WriteObject(site);
            }
            else
            {
                IPage<VirtualApplianceSite> sitePage;

                if(ShouldListByNva(this.ResourceGroupName, this.NvaName, this.Name))
                {
                    sitePage = this.VirtualApplianceSitesClient.List(this.ResourceGroupName, this.NvaName);
                    // Get all resources by polling on next page link
                    var siteList = ListNextLink<VirtualApplianceSite>.GetAllResourcesByPollingNextLink(sitePage, this.VirtualApplianceSitesClient.ListNext);

                    var psSites = new List<PSVirtualApplianceSite>();

                    foreach (var site in siteList)
                    {
                        var psSite = this.ToPsVirtualApplianceSite(site);
                        psSites.Add(psSite);
                    }
                    WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psSites), true);
                }
                if (ShouldListByResourceGroup(this.ResourceGroupName, this.NvaName))
                {
                    var nvaClient = this.NetworkClient.NetworkManagementClient.NetworkVirtualAppliances;
                    var nvaPage = nvaClient.ListByResourceGroup(this.ResourceGroupName);
                    var nvas = ListNextLink<NetworkVirtualAppliance>.GetAllResourcesByPollingNextLink(nvaPage, nvaClient.ListNext);
                    var psSites = new List<PSVirtualApplianceSite>();
                    foreach (var nva in nvas)
                    {
                        sitePage = this.VirtualApplianceSitesClient.List(this.ResourceGroupName, nva.Name);
                        // Get all resources by polling on next page link
                        var siteList = ListNextLink<VirtualApplianceSite>.GetAllResourcesByPollingNextLink(sitePage, this.VirtualApplianceSitesClient.ListNext);
                        foreach (var site in siteList)
                        {
                            var psSite = this.ToPsVirtualApplianceSite(site);
                            psSites.Add(psSite);
                        }
                    }
                    WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psSites), true);
                }
                else if(ShouldListBySubscription(this.ResourceGroupName, this.NvaName))
                {
                    var nvaClient = this.NetworkClient.NetworkManagementClient.NetworkVirtualAppliances;
                    var nvaPage = nvaClient.List();
                    var nvas = ListNextLink<NetworkVirtualAppliance>.GetAllResourcesByPollingNextLink(nvaPage, nvaClient.ListNext);
                    var psSites = new List<PSVirtualApplianceSite>();
                    foreach (var nva in nvas)
                    {
                        var rg = GetResourceGroup(nva.Id);
                        sitePage = this.VirtualApplianceSitesClient.List(rg, nva.Name);
                        // Get all resources by polling on next page link
                        var siteList = ListNextLink<VirtualApplianceSite>.GetAllResourcesByPollingNextLink(sitePage, this.VirtualApplianceSitesClient.ListNext);
                        foreach (var site in siteList)
                        {
                            var psSite = this.ToPsVirtualApplianceSite(site);
                            psSites.Add(psSite);
                        }
                    }
                    WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psSites), true);
                }
            }
        }

        private bool ShouldListByNva(string resourceGroupName, string nvaName, string name)
        {
            return !string.IsNullOrEmpty(resourceGroupName) &&
                !WildcardPattern.ContainsWildcardCharacters(resourceGroupName) &&
                !string.IsNullOrEmpty(nvaName) &&
                !WildcardPattern.ContainsWildcardCharacters(nvaName) &&
                (string.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name));
        }
        private bool ShouldGetByName(string resourceGroupName, string nvaName, string name)
        {
            return !string.IsNullOrEmpty(resourceGroupName) && 
                !WildcardPattern.ContainsWildcardCharacters(resourceGroupName) && 
                !string.IsNullOrEmpty(nvaName) && 
                !WildcardPattern.ContainsWildcardCharacters(nvaName) &&
                !string.IsNullOrEmpty(name) &&
                !WildcardPattern.ContainsWildcardCharacters(name);
        }
    }
}
