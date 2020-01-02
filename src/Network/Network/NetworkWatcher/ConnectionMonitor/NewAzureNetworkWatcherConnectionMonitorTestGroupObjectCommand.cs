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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorTestGroupObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorTestGroupObject))]
    public class NetworkWatcherConnectionMonitorTestGroupObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The test group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of test configuration.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestConfigurationObject> TestConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of source endpoints.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorEndpointObject> Source { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of destination endpoints.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorEndpointObject> Destination { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The disable flag.")]
        public SwitchParameter Disable { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSNetworkWatcherConnectionMonitorTestGroupObject testGroup = new PSNetworkWatcherConnectionMonitorTestGroupObject()
            {
                Name = this.Name,
                Disable = this.Disable? true:false,
                TestConfigurations = this.TestConfiguration,
                Sources = this.Source,
                Destinations = this.Destination
            };

            WriteObject(testGroup);
        }

        public bool Validate()
        {            
            if (!this.TestConfiguration.Any())
            {
                throw new ArgumentException("Test configuration is undefined.");
            }
            else
            {
                //validate test configuration
                foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in this.TestConfiguration)
                {
                    // validate test configuration
                    if (string.IsNullOrEmpty(TestConfiguration.Protocol))
                    {
                        throw new ArgumentException("Protocol in test configuration is not provided.");
                    }

                    if (TestConfiguration.HttpConfiguration == null && TestConfiguration.TcpConfiguration == null && TestConfiguration.IcmpConfiguration == null)
                    {
                        throw new ArgumentException("Protocol configuration is not provided.");
                    }
                    else if (TestConfiguration.TcpConfiguration != null)
                    {
                        if (TestConfiguration.TcpConfiguration.Port == 0)
                        {
                            throw new ArgumentException("Port can not be zero for TCP configuration");
                        }
                    }

                    if (TestConfiguration.PreferredIPVersion != null & String.Compare(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv4, true) != 0 &&
                        String.Compare(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv6, true) != 0)
                    {
                        throw new ArgumentException("IP version is undefined.");
                    }

                    //test configuration names must be unique
                    if (!string.IsNullOrEmpty(TestConfiguration.Name) && this.TestConfiguration.Count(x => x.Name == TestConfiguration.Name) > 2)
                    {
                        throw new ArgumentException("Test configuration name is not unique");
                    }
                }
            }

            if (!this.Source.Any() || !this.Destination.Any())
            {
                throw new ArgumentException("Source or destination endpoint is undefined.");
            }
            else
            {
                // validate Source and Destination Endpoints
                List<PSNetworkWatcherConnectionMonitorEndpointObject> Endpoints = this.Source;
                Endpoints.Concat(this.Destination);

                foreach (PSNetworkWatcherConnectionMonitorEndpointObject Endpoint in Endpoints)
                {
                    if (string.IsNullOrEmpty(Endpoint.ResourceId) && string.IsNullOrEmpty(Endpoint.Address) && Endpoint.Filter == null)
                    {
                        throw new ArgumentException("No Endpoint parameter is provided");
                    }

                    if (string.IsNullOrEmpty(Endpoint.ResourceId) && string.IsNullOrEmpty(Endpoint.Address))
                    {
                        throw new ArgumentException("Endpoint ResourceId and Address can not be both empty");
                    }

                    if (!string.IsNullOrEmpty(Endpoint.ResourceId))
                    {
                        string[] SplittedName = Endpoint.ResourceId.Split('/');

                        // Resource ID must be in this format
                        // "resourceId": "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTest2"
                        if (SplittedName.Count() < 9)
                        {
                            throw new ArgumentException("Endpoint ResourceId is not in the correct format");
                        }
                    }

                    if (!string.IsNullOrEmpty(Endpoint.Filter.Type) && String.Compare(Endpoint.Filter.Type, "Include", true) != 0)
                    {
                        throw new ArgumentException("Only FilterType Include is supported");
                    }
                    else if (!string.IsNullOrEmpty(Endpoint.Filter.Type) && Endpoint.Filter.Items == null)
                    {
                        throw new ArgumentException("Endpoint FilterType defined without FilterAddress");
                    }
                    else if (!string.IsNullOrEmpty(Endpoint.Filter.Type) && !Endpoint.Filter.Items.Any())
                    {
                        throw new ArgumentException("Endpoint FilterAddress is empty");
                    }
                    else if (string.IsNullOrEmpty(Endpoint.Filter.Type) && Endpoint.Filter.Items != null)
                    {
                        throw new ArgumentException("FilterAddress defined without FilterType");
                    }
                    else if (!string.IsNullOrEmpty(Endpoint.Filter.Type))
                    {
                        foreach (PSConnectionMonitorEndpointFilterItem Item in Endpoint.Filter.Items)
                        {
                            if (!string.IsNullOrEmpty(Item.Type) && String.Compare(Item.Type, "AgentAddress", true) != 0)
                            {
                                throw new ArgumentException("Endpoint Filter Items Type is not AgentAddress");
                            }

                            if (string.IsNullOrEmpty(Item.Address))
                            {
                                throw new ArgumentException("Endpoint Filter Items Address is empty");
                            }
                        }
                    }

                    // Endpoint name is optional so if it is not provided, fill it out
                    if (string.IsNullOrEmpty(Endpoint.Name))
                    {
                        string EndpointName = null;

                        if (!string.IsNullOrEmpty(Endpoint.ResourceId))
                        {
                            string[] SplittedName = Endpoint.ResourceId.Split('/');
                            // Name is in the form resourceName(ResourceGroupName)
                            EndpointName = SplittedName[8] + "(" + SplittedName[4] + ")";
                        }
                        else if (!string.IsNullOrEmpty(Endpoint.Address))
                        {
                            EndpointName = Endpoint.Address;
                        }

                        // assign the new name to the endpoint name
                        Endpoint.Name = EndpointName;
                    }
                }
            }

            return true;
        }
    }
}
