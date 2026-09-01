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
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIpamPool", SupportsShouldProcess = true), OutputType(typeof(PSIpamPool))]
    public class SetAzNetworkManagerIpamPoolCommand : IpamPoolBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Ipam Pool")]
        public PSIpamPool InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Minimum number of IP addresses required for allocations from this IPAM pool to be compliant. Must be less than or equal to the maximum allocation size. Specify an empty string to clear the minimum.")]
        [AllowEmptyString]
        public string MinAllocationSize { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Maximum number of IP addresses allowed for allocations from this IPAM pool to be compliant. Must be greater than or equal to the minimum allocation size. Specify an empty string to clear the maximum.")]
        [AllowEmptyString]
        public string MaxAllocationSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsIpamPoolPresent(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.InputObject.Name));
                }

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(this.MinAllocationSize)))
                {
                    this.InputObject.Properties.MinAllocationSize = this.MinAllocationSize;
                }

                if (this.MyInvocation.BoundParameters.ContainsKey(nameof(this.MaxAllocationSize)))
                {
                    this.InputObject.Properties.MaxAllocationSize = this.MaxAllocationSize;
                }

                // Map to the sdk object
                var ipamPoolModel = NetworkResourceManagerProfile.Mapper.Map<MNM.IpamPool>(this.InputObject);

                // Execute the PUT IpamPool call
                this.IpamPoolClient.Create(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name, ipamPoolModel);
                var psIpamPool = this.GetIpamPool(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.Name);
                WriteObject(psIpamPool);
            }
        }
    }
}