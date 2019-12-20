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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndpointObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorEndpointObject))]
    public class NewAzureNetworkWatcherConnectionMonitorEndpointObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ID of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Ip address of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The connection monitor filter type.")]
        [ValidateNotNullOrEmpty]
        public string FilterType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The connection monitor filter addresses.")]
        [ValidateNotNullOrEmpty]
        public List<string> FilterAddress { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();
            string EndpointName = null;

            if (!string.IsNullOrEmpty(this.ResourceId))
            {
                string[] SplittedName = ResourceId.Split('/');
                // Name is in the form resourceName(ResourceGroupName)
                EndpointName = SplittedName[9] + "(" + SplittedName[5]+ ")";
            }
            else if (!string.IsNullOrEmpty(this.Address))
            {
                EndpointName = this.Address;
            }

            PSNetworkWatcherConnectionMonitorEndpointObject endPoint = new PSNetworkWatcherConnectionMonitorEndpointObject()
            {
                Name = EndpointName,
                ResourceId = this.ResourceId,
                Address = this.Address,
                Filter = new PSConnectionMonitorEndpointFilter()
                {
                    Type = this.FilterType
                },
            };

            if (this.FilterAddress != null)
            {
                endPoint.Filter.Items = new List<PSConnectionMonitorEndpointFilterItem>();
                foreach (string Address in FilterAddress)
                {
                    endPoint.Filter.Items.Add(new PSConnectionMonitorEndpointFilterItem()
                    {
                        Type = "AgentAddress",
                        Address = Address
                    });
                };
            }

            WriteObject(endPoint);
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.ResourceId) && string.IsNullOrEmpty(this.Address) && string.IsNullOrEmpty(this.FilterType) && (!this.FilterAddress.Any()))
            {
                throw new ArgumentException("No Parameter is provided");
            }

            if (string.IsNullOrEmpty(this.ResourceId) && string.IsNullOrEmpty(this.Address))
            {
                throw new ArgumentException("ResourceId and Address can not be both empty");
            }
        
            if (!string.IsNullOrEmpty(ResourceId))
            {
                string[] SplittedName = ResourceId.Split('/');

                // Resource ID must be in this format
                // "resourceId": "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTest2"
                if (SplittedName.Count() < 9)
                {
                    throw new ArgumentException("ResourceId not in the correct format");
                }
            }

            if (this.FilterType != null && String.Compare(this.FilterType, "Include", true) != 0)
            {
                throw new ArgumentException("Only FilterType Include is supported");
            }
            else if (this.FilterType != null && this.FilterAddress == null)
            {
                throw new ArgumentException("FilterType defined without FilterAddress");
            }
            return true;
        }
    }
}
