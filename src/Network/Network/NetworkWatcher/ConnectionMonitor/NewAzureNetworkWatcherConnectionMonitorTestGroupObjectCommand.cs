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
            HelpMessage = "The list of test configurations.")]
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
            // Validate test configuration
            foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in this.TestConfiguration)
            {
                // Validate test configuration
                if (string.IsNullOrEmpty(TestConfiguration.Protocol))
                {
                    throw new PSArgumentException(Properties.Resources.TestGroupProtocol);
                }

                if (TestConfiguration.HttpConfiguration == null && TestConfiguration.TcpConfiguration == null && TestConfiguration.IcmpConfiguration == null)
                {
                    throw new PSArgumentException(Properties.Resources.TestGroupProtocolConfiguration);
                }
                else if (TestConfiguration.TcpConfiguration != null)
                {
                    if (TestConfiguration.TcpConfiguration.Port == 0)
                    {
                        throw new PSArgumentException(Properties.Resources.ProtocolConfigurationPort);
                    }
                }

                if (TestConfiguration.PreferredIPVersion != null & !String.Equals(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv4) &&
                    !String.Equals(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv6))
                {
                    throw new PSArgumentException(Properties.Resources.ProtocolConfigurationIPVersion);
                }

                // Test configuration names must be unique
                if (!string.IsNullOrEmpty(TestConfiguration.Name) && this.TestConfiguration.Count(x => x.Name == TestConfiguration.Name) > 2)
                {
                    throw new PSArgumentException(Properties.Resources.TestGroupTestConfigurationName);
                }
            }

            if (!this.Source.Any() || !this.Destination.Any())
            {
                throw new PSArgumentException(Properties.Resources.TestGroupEndpoints);
            }
            // Validate Source and Destination Endpoints
            List<PSNetworkWatcherConnectionMonitorEndpointObject> Endpoints = this.Source;
            Endpoints.Concat(this.Destination);

            foreach (PSNetworkWatcherConnectionMonitorEndpointObject Endpoint in Endpoints)
            {
                if (string.IsNullOrEmpty(Endpoint.ResourceId) && string.IsNullOrEmpty(Endpoint.Address) && Endpoint.Filter == null)
                {
                    throw new PSArgumentException(Properties.Resources.TestGroupEndpointParameter);
                }

                if (string.IsNullOrEmpty(Endpoint.ResourceId) && string.IsNullOrEmpty(Endpoint.Address))
                {
                    throw new PSArgumentException(Properties.Resources.TestGroupEndpointResourceIdorAddress);
                }

                if (!string.IsNullOrEmpty(Endpoint.ResourceId))
                {
                    string[] SplittedName = Endpoint.ResourceId.Split('/');

                    // Resource ID must be in this format
                    // "resourceId": "/subscriptions/96e68903-0a56-4819-9987-8d08ad6a1f99/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/iraVmTest2"
                    if (SplittedName.Count() < 9)
                    {
                        throw new PSArgumentException(Properties.Resources.EndpointResourceId);
                    }
                }

                if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && !String.Equals(Endpoint.Filter.Type, "Include"))
                {
                    throw new PSArgumentException(Properties.Resources.EndpointFilterType);
                }
                else if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && Endpoint.Filter.Items == null)
                {
                    throw new PSArgumentException(Properties.Resources.EndpointFilterItemList);
                }
                else if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && !Endpoint.Filter.Items.Any())
                {
                    throw new PSArgumentException(Properties.Resources.EndpointFilterItemList);
                }
                else if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type))
                {
                    foreach (PSConnectionMonitorEndpointFilterItem Item in Endpoint.Filter.Items)
                    {
                        if (string.IsNullOrEmpty(Item.Address))
                        {
                            throw new PSArgumentException(Properties.Resources.EndpointFilterItemAddress);
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

                    // Assign the new name to the endpoint name
                    Endpoint.Name = EndpointName;
                }
            }

            return true;
        }
    }
}
