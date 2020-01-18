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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndpointFilterObject", SupportsShouldProcess = true), OutputType(typeof(PSConnectionMonitorEndpointFilter))]
    public class NewAzureNetworkWatcherConnectionMonitorEndpointFilterObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor filter type.")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor filter items.")]
        [ValidateNotNullOrEmpty]
        public List<PSConnectionMonitorEndpointFilterItem> Items;

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSConnectionMonitorEndpointFilter EndpointFilter = new PSConnectionMonitorEndpointFilter()
            {
                Type = this.Type,
                Items = new List<PSConnectionMonitorEndpointFilterItem>(Items)
            };

            WriteObject(EndpointFilter);
        }

        public bool Validate()
        {
            if (!string.IsNullOrEmpty(this.Type) && String.Compare(this.Type, "Include", true) != 0)
            {
                throw new ArgumentException("Only Type Include is supported");
            }
            else if (!string.IsNullOrEmpty(this.Type) && !this.Items.Any())
            {
                throw new ArgumentException("Endpoint Filter Item list is empty");
            }
            else if (!string.IsNullOrEmpty(this.Type))
            {
                foreach (PSConnectionMonitorEndpointFilterItem Item in this.Items)
                {
                    if (!string.IsNullOrEmpty(Item.Type) && String.Compare(Item.Type, "AgentAddress", true) != 0)
                    {
                        throw new ArgumentException("Endpoint Filter Item Type is not AgentAddress");
                    }

                    if (string.IsNullOrEmpty(Item.Address))
                    {
                        throw new ArgumentException("Endpoint Filter Item Address is empty");
                    }
                }
            }

            return true;
        }
    }
}
