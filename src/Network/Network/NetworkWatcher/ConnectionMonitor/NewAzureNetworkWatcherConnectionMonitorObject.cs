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
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
        [LocationCompleter("Microsoft.Network/networkWatchers/connectionMonitors")]
        [ValidateNotNull]
        public string Location { get; set; }
  
        [Alias("ConnectionMonitorName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The connection monitor name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor test groups.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of connection monitor outputs.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.")]
        [ValidateNotNullOrEmpty]
        public string Note { get; set; }

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

            if (ParameterSetName.Contains("SetByResource"))
            {
                CMObject.NetworkWatcherName = this.NetworkWatcher.Name;
                CMObject.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                CMObject.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByName"))
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
                CMObject.Location = networkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                CMObject.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                CMObject.NetworkWatcherName = networkWatcher.Name;
                CMObject.Location = this.Location;
            }

            if (this.TestGroup != null)
            {
                CMObject.TestGroup = this.TestGroup;
            }

            if (this.Output != null)
            {
                CMObject.Output = this.Output;
            }

            if (this.Note != null)
            {
                CMObject.Notes = this.Note;
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
                    if (string.IsNullOrEmpty(TestGroup.Name) || TestGroup.Sources == null || TestGroup.Destinations == null || TestGroup.TestConfigurations == null)
                    {
                        throw new ArgumentException(Properties.Resources.TestGroupParameters);
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

                            if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && String.Compare(Endpoint.Filter.Type, "Include", true) != 0)
                            {
                                throw new PSArgumentException(Properties.Resources.EndpointFilterType);
                            }
                            else if (Endpoint.Filter != null && Endpoint.Filter.Items == null)
                            {
                                throw new PSArgumentException(Properties.Resources.EndpointFilterItem);
                            }
                            else if (Endpoint.Filter != null && !Endpoint.Filter.Items.Any())
                            {
                                throw new PSArgumentException(Properties.Resources.EndpointFilterItemList);
                            }
                            else if (Endpoint.Filter != null && Endpoint.Filter.Items.Any())
                            {
                                foreach (PSConnectionMonitorEndpointFilterItem Item in Endpoint.Filter.Items)
                                {
                                    if (!string.IsNullOrEmpty(Item.Type) && String.Compare(Item.Type, "AgentAddress", true) != 0)
                                    {
                                        throw new PSArgumentException(Properties.Resources.EndpointFilterItemType);
                                    }

                                    if (string.IsNullOrEmpty(Item.Address))
                                    {
                                        throw new PSArgumentException(Properties.Resources.EndpointFilterItemAddress);
                                    }
                                }
                            }

                            //Auto fill Filter Type and Filter Item Type
                            if (Endpoint.Filter != null && Endpoint.Filter.Items != null && Endpoint.Filter.Items.Any())
                            {
                                Endpoint.Filter.Type = string.IsNullOrEmpty(Endpoint.Filter.Type) ? "Include" : Endpoint.Filter.Type;

                                foreach (PSConnectionMonitorEndpointFilterItem Item in Endpoint.Filter.Items)
                                {
                                    if (string.IsNullOrEmpty(Item.Type))
                                    {
                                        Item.Type = "AgentAddress";
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
                    else
                    {
                        throw new PSArgumentException(Properties.Resources.EndpointSourceDestination);
                    }

                    if (TestGroup.TestConfigurations.Any())
                    {
                        uint TestConfigCounter = 1;
                        foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in TestGroup.TestConfigurations)
                        {
                            if (string.IsNullOrEmpty(TestConfiguration.Name))
                            {
                                TestConfiguration.Name = "TestConfig" + TestConfigCounter.ToString();
                            }

                            if (!string.IsNullOrEmpty(TestConfiguration.Name) && TestGroup.TestConfigurations.Count(x => x.Name == TestConfiguration.Name) > 2)
                            {
                                throw new ArgumentException(Properties.Resources.TestGroupTestConfigurationName);
                            }

                            // validate test configuration
                            if (TestConfiguration.HttpConfiguration == null && TestConfiguration.TcpConfiguration == null && TestConfiguration.IcmpConfiguration == null)
                            {
                                throw new ArgumentException(Properties.Resources.TestGroupProtocolConfiguration);
                            }

                            if (TestConfiguration.PreferredIPVersion != null & String.Compare(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv4, true) != 0 &&
                                String.Compare(TestConfiguration.PreferredIPVersion, NetworkBaseCmdlet.IPv6, true) != 0)
                            {
                                throw new ArgumentException(Properties.Resources.ProtocolConfigurationIPVersion);
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException(Properties.Resources.TestConfiguration);
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
                        throw new PSArgumentException(Properties.Resources.ConnectionMonitorOutput);
                    }
                    else if (string.IsNullOrEmpty(Output.WorkspaceSettings.WorkspaceResourceId))
                    {
                        throw new PSArgumentException(Properties.Resources.WorkspaceResourceId);
                    }
                }
            }

            return true;
        }
    }
}