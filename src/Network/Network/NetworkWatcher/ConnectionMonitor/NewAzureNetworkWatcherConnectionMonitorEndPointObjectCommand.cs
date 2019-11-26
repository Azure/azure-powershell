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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndpointObject", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResult))]
    public class NewAzureNetworkWatcherConnectionMonitorEndpointObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The ID of the endpoint.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
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
            HelpMessage = "The list of connection monitor filters.")]
        [ValidateNotNullOrEmpty]
        public PSConnectionMonitorFilter Filter { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSConnectionMonitorEndpoint endPoint = new PSConnectionMonitorEndpoint()
            {
                Name = this.Name,
                ResourceId = this.ResourceId,
                Address = this.Address,
                Filter = this.Filter
            };

            WriteObject(endPoint);
        }

        public bool Validate()
        {
            if (this.FilterType != null && String.Compare(FilterType, "Include", true) != 0)
            {
                throw new ArgumentException("Only FilterType Include is supported");
            }
            else if (FilterType != null && this.Filter == null)
            {
                throw new ArgumentException("FilterType defined without Filter");
            }
            else
            {
                foreach (PSConnectionMonitorEndpointItem cmEndpointItem in this.Filter.Items)
                {
                    if (String.Compare(cmEndpointItem.Type, "AgentAddress", true) != 0)
                    {
                        throw new ArgumentException("Only AgentAddress is supported");
                    }
                }
            }
            return true;
        }
    }
}
