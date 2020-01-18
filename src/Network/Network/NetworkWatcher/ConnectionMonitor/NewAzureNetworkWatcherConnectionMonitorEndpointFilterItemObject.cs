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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndpointFilterItemObject", SupportsShouldProcess = true), OutputType(typeof(PSConnectionMonitorEndpointFilterItem))]
    public class NewAzureNetworkWatcherConnectionMonitorEndpointFilterItemObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor filter item type.")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor filter item address.")]
        [ValidateNotNullOrEmpty]
        public string Address;

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSConnectionMonitorEndpointFilterItem EndpointFilterItem = new PSConnectionMonitorEndpointFilterItem()
            {
                Type = this.Type,
                Address = this.Address
            };

            WriteObject(EndpointFilterItem);
        }

        public bool Validate()
        {
            if (!string.IsNullOrEmpty(this.Type) && String.Compare(this.Type, "AgentAddress", true) != 0)
            {
                throw new ArgumentException("Endpoint Filter Items Type is not AgentAddress");
            }

            return true;
        }
    }
}