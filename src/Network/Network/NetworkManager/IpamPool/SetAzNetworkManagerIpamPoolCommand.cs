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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIpamPool", SupportsShouldProcess = true, DefaultParameterSetName = SetByInputObjectParameterSet), OutputType(typeof(PSIpamPool))]
    public class SetAzNetworkManagerIpamPoolCommand : IpamPoolBaseCmdlet
    {
        private const string SetByNameParameterSet = "ByNameParameters";
        private const string SetByResourceIdParameterSet = "ByResourceId";
        private const string SetByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = SetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/ipamPools", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description.",
            ParameterSetName = SetByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description.",
            ParameterSetName = SetByResourceIdParameterSet)]
        public string Description { get; set; }

        [Parameter(
            ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Ipam Pool")]
        public PSIpamPool InputObject { get; set; }

        [Parameter(
           ParameterSetName = SetByResourceIdParameterSet,
           Mandatory = true,
           HelpMessage = "The Resource Id.",
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("Resource Id")]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject?.Name ?? this.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                var (resourceGroupName, networkManagerName, ipamPoolName) = ExtractResourceDetails();

                if (!this.IsIpamPoolPresent(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.InputObject.Name));
                }

                // Map to the sdk object
                var ipamPoolModel = MapToSdkObject();

                // Execute the PUT IpamPool call
                var ipamPoolResponse = this.IpamPoolClient.Create(
                    resourceGroupName,
                    networkManagerName,
                    ipamPoolName,
                    ipamPoolModel);

                var psIpamPool = this.ToPsIpamPool(ipamPoolResponse);
                WriteObject(psIpamPool);
            }
        }
        private (string resourceGroupName, string networkManagerName, string ipamPoolname) ExtractResourceDetails() 
        {
            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                // Validate the format of the ResourceId
                var segments = parsedResourceId.ParentResource.Split('/');
                if (segments.Length < 2)
                {
                    throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                }

                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.NetworkManagerName = segments[1];
                

                return (this.ResourceGroupName, this.NetworkManagerName, this.Name);
            }
            else if (this.InputObject != null)
            {
                return (
                    this.InputObject.ResourceGroupName,
                    this.InputObject.NetworkManagerName,
                    this.InputObject.Name
                );
            }
            else
            {
                return (
                    this.ResourceGroupName,
                    this.NetworkManagerName,
                    this.Name
                );
            }
        }

        private IpamPool MapToSdkObject()
        {
            if (this.InputObject != null)
            {
                if (this.InputObject is PSIpamPool)
                {
                    return NetworkResourceManagerProfile.Mapper.Map<MNM.IpamPool>(this.InputObject);
                }
                else
                {
                    throw new PSArgumentException("Invalid InputObject type. Expected type is PSIpamPool.");
                }
            }
            else
            {
                var ipamPool = new IpamPool();

                if (ipamPool.Properties == null)
                {
                    ipamPool.Properties = new IpamPoolProperties();
                }
                if (!string.IsNullOrEmpty(this.Description))
                {
                    ipamPool.Properties.Description = this.Description;
                }
                return ipamPool;
            }
        }
    }
}