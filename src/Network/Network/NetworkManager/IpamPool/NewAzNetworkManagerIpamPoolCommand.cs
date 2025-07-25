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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIpamPool", SupportsShouldProcess = true, DefaultParameterSetName = CreateByNameParameterSet), OutputType(typeof(PSIpamPool))]
    public class NewAzNetworkManagerIpamPoolCommand : IpamPoolBaseCmdlet
    {
        private const string CreateByNameParameterSet = "ByName";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = CreateByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.",
            ParameterSetName = CreateByNameParameterSet)]
        [LocationCompleter("Microsoft.Network/networkManagers/ipamPools")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefixes to assign.",
            ParameterSetName = CreateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual List<string> AddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description.",
            ParameterSetName = CreateByNameParameterSet)]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Display name.",
            ParameterSetName = CreateByNameParameterSet)]
        public virtual string DisplayName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the parent pool name to assign this pool to.",
            ParameterSetName = CreateByNameParameterSet)]
        public virtual string ParentPoolName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = CreateByNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsIpamPoolPresent(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var ipamPool = this.CreateIpamPool();
                    WriteObject(ipamPool);
                },
                () => present);
        }

        private PSIpamPool CreateIpamPool()
        {
            var ipamPool = new PSIpamPool();
            ipamPool.Name = this.Name;
            ipamPool.Location = this.Location;
            ipamPool.Properties = new PSIpamPoolProperties();

            ipamPool.Properties.AddressPrefixes = this.AddressPrefix;

            if (!string.IsNullOrEmpty(this.Description))
            {
                ipamPool.Properties.Description = this.Description;
            }

            if (!string.IsNullOrEmpty(this.DisplayName))
            {
                ipamPool.Properties.DisplayName = this.DisplayName;
            }

            if (!string.IsNullOrEmpty(this.ParentPoolName))
            {
                ipamPool.Properties.ParentPoolName = this.ParentPoolName;
            }

            // Map to the sdk object
            var ipamPoolModel = NetworkResourceManagerProfile.Mapper.Map<MNM.IpamPool>(ipamPool);
            ipamPoolModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create Network call
            this.IpamPoolClient.Create(this.ResourceGroupName, this.NetworkManagerName, this.Name, ipamPoolModel);
            var psIpamPool = this.GetIpamPool(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            return psIpamPool;
        }
    }
}