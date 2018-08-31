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
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpPrefix", DefaultParameterSetName = GetAzurePublicIpPrefixParameterSetNames.Default), OutputType(typeof(PSPublicIpPrefix))]
    public class GetAzurePublicIpPrefixCommand : PublicIpPrefixBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = GetAzurePublicIpPrefixParameterSetNames.GetByName)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = GetAzurePublicIpPrefixParameterSetNames.GetByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            ParameterSetName = GetAzurePublicIpPrefixParameterSetNames.GetByResourceId)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                PSPublicIpPrefix publicIpPrefix;

                publicIpPrefix = this.GetPublicIpPrefix(this.ResourceGroupName, this.Name);

                WriteObject(publicIpPrefix);
            }
            else
            {
                IPage<PublicIPPrefix> publicipprefixPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    publicipprefixPage = this.PublicIpPrefixClient.List(this.ResourceGroupName);
                }
                else
                {
                    publicipprefixPage = this.PublicIpPrefixClient.ListAll();
                }

                // Get all resources by polling on next page link
                List<PublicIPPrefix> publicIPPrefixList;

                publicIPPrefixList = ListNextLink<PublicIPPrefix>.GetAllResourcesByPollingNextLink(publicipprefixPage, this.PublicIpPrefixClient.ListNext);

                var psPublicIpPrefixes = new List<PSPublicIpPrefix>();

                // populate the publicIpPrefixes with the ResourceGroupName
                foreach (var publicIpPrefix in publicIPPrefixList)
                {
                    var psPublicIpPrefix = this.ToPsPublicIpPrefix(publicIpPrefix);
                    psPublicIpPrefix.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(publicIpPrefix.Id);
                    psPublicIpPrefixes.Add(psPublicIpPrefix);
                }

                WriteObject(psPublicIpPrefixes, true);
            }
        }
    }

    public static class GetAzurePublicIpPrefixParameterSetNames
    {
        public const string GetByName = "GetByNameParameterSet";
        public const string GetByResourceId = "GetByResourceIdParameterSet";

        // The Default
        public const string Default = GetByName;
    }
}
