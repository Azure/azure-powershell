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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorObject))]
    public class AzureNetworkWatcherConnectionMonitorObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of test group.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The connection monitor output.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.")]
        [ValidateNotNullOrEmpty]
        public string Notes { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSNetworkWatcherConnectionMonitorObject CMObject = new PSNetworkWatcherConnectionMonitorObject()
            {
                NetworkWatcherName = this.NetworkWatcherName,
                ResourceGroupName = this.ResourceGroupName,
                Name = this.Name
            };

            if (this.TestGroup != null)
            {
                CMObject.TestGroup = this.TestGroup;
            }

            if (this.Output != null)
            {
                CMObject.Output = this.Output;
            }

            if (this.Notes != null)
            {
                CMObject.Notes = this.Notes;
            }

            WriteObject(CMObject);
        }

        public bool Validate()
        {

            if (this.TestGroup != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorTestGroupObject TestGroup in this.TestGroup)
                {
                    // validate mandatory parameters
                    if (string.IsNullOrEmpty(TestGroup.Name) || TestGroup.Sources == null || TestGroup.Destinations == null)
                    {
                        throw new ArgumentException("Test group is missing one or more mandatory parameter");
                    }

                    // validate Source and Destination Endpoints
                    List<PSNetworkWatcherConnectionMonitorEndpointObject> Endpoints = TestGroup.Sources;
                    Endpoints.Concat(TestGroup.Destinations);

                    if (Endpoints.Any())
                    {
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

                            if (Endpoint.Filter != null && Endpoint.Filter.Type != null && String.Compare(Endpoint.Filter.Type, "Include", true) != 0)
                            {
                                throw new ArgumentException("Only FilterType Include is supported");
                            }
                            else if (Endpoint.Filter != null && Endpoint.Filter.Type != null && Endpoint.Filter.Items == null)
                            {
                                throw new ArgumentException("Endpoint FilterType defined without FilterAddress");
                            }
                            else if (Endpoint.Filter != null && Endpoint.Filter.Type != null && Endpoint.Filter.Items[0] != null && Endpoint.Filter.Items[0].Type != null && String.Compare(Endpoint.Filter.Items[0].Type, "AgentAddress", true) != 0)
                            {
                                throw new ArgumentException("Endpoint Filter Items Type is not AgentAddress");
                            }
                            else if (Endpoint.Filter != null && Endpoint.Filter.Type != null && Endpoint.Filter.Items[0] != null && Endpoint.Filter.Items[0].Type != null && string.IsNullOrEmpty(Endpoint.Filter.Items[0].Address))
                            {
                                throw new ArgumentException("Endpoint Filter Items Address is empty");
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
                    else
                    {
                        throw new ArgumentException("No sources or destination endpoints");
                    }

                    if (TestGroup.TestConfigurations.Any())
                    {
                        foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in TestGroup.TestConfigurations)
                        {
                            if (!string.IsNullOrEmpty(TestConfiguration.Name) && TestGroup.TestConfigurations.Count(x => x.Name == TestConfiguration.Name) > 2)
                            {
                                throw new ArgumentException("Test configuration name is not unique");
                            }

                            // validate test configuration
                            if (TestConfiguration.HttpConfiguration == null && TestConfiguration.TcpConfiguration == null && TestConfiguration.IcmpConfiguration == null)
                            {
                                throw new ArgumentException("Protocol configuration is not provided.");
                            }

                            if (TestConfiguration.PreferredIPVersion != null & String.Compare(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv4, true) != 0 &&
                                String.Compare(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv6, true) != 0)
                            {
                                throw new ArgumentException("IP version is undefined.");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No test configuraiton is provided");
                    }
                }
            }

            // validate output
            if (this.Output != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorOutputObject Output in this.Output)
                {
                    if (Output.Type == null && Output.WorkspaceSettings == null)
                    {
                        throw new ArgumentException("No Output parameter is provided");
                    }
                    else if (string.IsNullOrEmpty(Output.WorkspaceSettings.WorkspaceResourceId))
                    {
                        throw new ArgumentException("Output WorkspaceResourceId parameter is empty");
                    }
                }
            }

            return true;
        }
    }
}