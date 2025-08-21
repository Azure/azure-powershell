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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIpamPoolStaticCidr", SupportsShouldProcess = true), OutputType(typeof(PSStaticCidr))]
    public class SetAzNetworkManagerIpamPoolStaticCidrCommand : IpamPoolStaticCidrBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Static CIDR object")]
        public PSStaticCidr InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(this.InputObject.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsStaticCidrPresent(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.PoolName, this.InputObject.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.InputObject.Name));
                }

                var existingStaticCidr = this.GetStaticCidr(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.PoolName, this.InputObject.Name);

                ApplyMutualExclusivityLogic(existingStaticCidr, this.InputObject);

                var staticCidrModel = NetworkResourceManagerProfile.Mapper.Map<MNM.StaticCidr>(this.InputObject);

                this.StaticCidrClient.Create(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.PoolName, this.InputObject.Name, staticCidrModel);
                var psStaticCidr = this.GetStaticCidr(this.InputObject.ResourceGroupName, this.InputObject.NetworkManagerName, this.InputObject.PoolName, this.InputObject.Name);
                WriteObject(psStaticCidr);
            }
        }

        private void ApplyMutualExclusivityLogic(PSStaticCidr existingStaticCidr, PSStaticCidr inputObject)
        {
            if (existingStaticCidr?.Properties == null || inputObject?.Properties == null)
            {
                return;
            }

            var existingAddressPrefixes = existingStaticCidr.Properties.AddressPrefixes ?? new List<string>();
            var inputAddressPrefixes = inputObject.Properties.AddressPrefixes ?? new List<string>();
            
            var existingNumberOfIPs = existingStaticCidr.Properties.NumberOfIPAddressesToAllocate;
            var inputNumberOfIPs = inputObject.Properties.NumberOfIPAddressesToAllocate;

            // Check if AddressPrefixes property is being updated
            bool addressPrefixesChanged = !AreAddressPrefixesEqual(existingAddressPrefixes, inputAddressPrefixes);
            
            // Check if NumberOfIPAddressesToAllocate property is being updated
            bool numberOfIPsChanged = !string.Equals(existingNumberOfIPs, inputNumberOfIPs, StringComparison.OrdinalIgnoreCase);

            if (addressPrefixesChanged && !numberOfIPsChanged)
            {
                // AddressPrefixes is being updated and NumberOfIPAddressesToAllocate remains unchanged
                // Set NumberOfIPAddressesToAllocate to "0"
                inputObject.Properties.NumberOfIPAddressesToAllocate = "0";
            }
            else if (numberOfIPsChanged && !addressPrefixesChanged)
            {
                // NumberOfIPAddressesToAllocate is being updated and AddressPrefixes remains unchanged
                // Set AddressPrefixes to empty list
                inputObject.Properties.AddressPrefixes = new List<string>();
            }
        }

        private bool AreAddressPrefixesEqual(IList<string> list1, IList<string> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null || list2 == null) return false;
            if (list1.Count != list2.Count) return false;

            // Compare sorted lists to handle order differences
            var sorted1 = list1.OrderBy(x => x).ToList();
            var sorted2 = list2.OrderBy(x => x).ToList();

            for (int i = 0; i < sorted1.Count; i++)
            {
                if (!string.Equals(sorted1[i], sorted2[i], StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}