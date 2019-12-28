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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitor", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"),OutputType(typeof(PSConnectionMonitorResult))]
    public class NewAzureNetworkWatcherConnectionMonitorCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
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
            ValueFromPipeline = true,
            HelpMessage = "The connection monitor name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
              Mandatory = true,
              HelpMessage = "The ID of the connection monitor source.")]
        [ValidateNotNullOrEmpty]
        public string SourceResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Monitoring interval in seconds. Default value is 60 seconds.")]
        [ValidateNotNullOrEmpty]
        public int? MonitoringIntervalInSeconds { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source port.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int SourcePort { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "The ID of the connection monitor destination.")]
        [ValidateNotNullOrEmpty]
        public string DestinationResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination port.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int DestinationPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Ip address of the connection monitor destination.")]
        [ValidateNotNullOrEmpty]
        public string DestinationAddress { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The list of test group.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The connection monitor output.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Notes associated with connection monitor.")]
        [ValidateNotNullOrEmpty]
        public string Notes { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Configure connection monitor, but do not start it")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ConfigureOnly { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        public override void Execute()
        {
            base.Execute();

            Validate();

            string resourceGroupName = this.ResourceGroupName;
            string networkWatcherName = this.NetworkWatcherName;
            bool connectionMonitorV2 = false;

            if (ParameterSetName.Contains("SetByResource"))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                networkWatcherName = this.NetworkWatcher.Name;
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                networkWatcherName = networkWatcher.Name;
            }
            else if (TestGroup != null && Output != null )
            {
                connectionMonitorV2 = true;
            }

            var present = this.IsConnectionMonitorPresent(resourceGroupName, networkWatcherName, this.Name);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    var connectionMonitor = CreateConnectionMonitor(resourceGroupName, networkWatcherName, connectionMonitorV2);
                    WriteObject(connectionMonitor);
                },
                () => present);
        }

        private PSConnectionMonitorResult CreateConnectionMonitor(string resourceGroupName, string networkWatcherName, bool connectionMonitorV2 = false)
        {
            MNM.ConnectionMonitor parameters = new MNM.ConnectionMonitor
             {
                Source = new MNM.ConnectionMonitorSource
                {
                    ResourceId = this.SourceResourceId,
                    Port = this.SourcePort
                },
                Destination = new MNM.ConnectionMonitorDestination
                {
                    ResourceId = this.DestinationResourceId,
                    Address = this.DestinationAddress,
                    Port = this.DestinationPort
                },
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            if (!string.IsNullOrEmpty(this.Notes))
            {
                parameters.Notes = this.Notes;
            }

            // Parse the TestGroup to parameters
            if (this.TestGroup != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorTestGroupObject TestGroup in this.TestGroup)
                {
                    // Add source Endpoint
                    foreach (PSNetworkWatcherConnectionMonitorEndpointObject SrcEndpoint in TestGroup.Sources)
                        {
                            ConnectionMonitorEndpoint SourceEndpoint = new ConnectionMonitorEndpoint()
                            {
                                Name = SrcEndpoint.Name,
                                ResourceId = SrcEndpoint.ResourceId,
                                Address = SrcEndpoint.Address,
                                Filter = new ConnectionMonitorEndpointFilter()
                                {
                                    Type = SrcEndpoint.Filter?.Type
                                }
                            };

                            // Add ConnectionMonitorEndpointFilterItem
                            if (SrcEndpoint.Filter?.Items != null)
                            {
                                foreach (PSConnectionMonitorEndpointFilterItem Items in SrcEndpoint.Filter.Items)
                                {
                                    if (SourceEndpoint.Filter.Items == null)
                                    {
                                        SourceEndpoint.Filter.Items = new List<ConnectionMonitorEndpointFilterItem>();
                                    }

                                    SourceEndpoint.Filter.Items.Add(new ConnectionMonitorEndpointFilterItem()
                                    {
                                        Type = Items.Type,
                                        Address = Items.Address
                                    });
                                }
                            }

                            if (parameters.Endpoints == null)
                            {
                                parameters.Endpoints = new List<ConnectionMonitorEndpoint>();
                            }

                            parameters.Endpoints.Add(SourceEndpoint);
                        }

                    // Add destination Endpoint
                    foreach (PSNetworkWatcherConnectionMonitorEndpointObject DstEndpoint in TestGroup.Destinations)
                        {
                            ConnectionMonitorEndpoint DestinationEndpoint = new ConnectionMonitorEndpoint()
                            {
                                Name = DstEndpoint.Name,
                                ResourceId = DstEndpoint.ResourceId,
                                Address = DstEndpoint.Address,
                                Filter = new ConnectionMonitorEndpointFilter()
                                {
                                    Type = DstEndpoint.Filter?.Type
                                }
                            };

                            // Add ConnectionMonitorEndpointFilterItem
                            if (DstEndpoint.Filter?.Items != null)
                            {
                                foreach (PSConnectionMonitorEndpointFilterItem Items in DstEndpoint.Filter.Items)
                                {
                                    if (DestinationEndpoint.Filter.Items == null)
                                    {
                                        DestinationEndpoint.Filter.Items = new List<ConnectionMonitorEndpointFilterItem>();
                                    }

                                    DestinationEndpoint.Filter.Items.Add(new ConnectionMonitorEndpointFilterItem()
                                    {
                                        Type = Items.Type,
                                        Address = Items.Address
                                    });
                                }
                            }

                            if (parameters.Endpoints == null)
                            {
                                parameters.Endpoints = new List<ConnectionMonitorEndpoint>();
                            }

                            parameters.Endpoints.Add(DestinationEndpoint);
                        }

                    // Add test configuration
                    foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfig in TestGroup.TestConfigurations)
                        {
                            uint TestConfigCounter = 1;
                            ConnectionMonitorTestConfiguration TestConfiguration = new ConnectionMonitorTestConfiguration()
                            {
                                Name = string.IsNullOrEmpty(TestConfig.Name) ? "TestConfig" + TestConfigCounter.ToString() : TestConfig.Name,
                                Protocol = TestConfig.Protocol,
                                PreferredIPVersion = TestConfig.PreferredIPVersion,
                                TestFrequencySec = TestConfig.TestFrequencySec,
                                SuccessThreshold = new ConnectionMonitorSuccessThreshold()
                                {
                                    ChecksFailedPercent = TestConfig.SuccessThreshold.ChecksFailedPercent,
                                    RoundTripTimeMs = TestConfig.SuccessThreshold.RoundTripTimeMs
                                }
                            };

                            TestConfigCounter++;

                            if (string.Compare(TestConfiguration.Protocol, "TCP", true) == 0)
                            {
                                ConnectionMonitorTcpConfiguration TcpConfiguration = new ConnectionMonitorTcpConfiguration()
                                {
                                    Port = TestConfig.TcpConfiguration?.Port,
                                    DisableTraceRoute = TestConfig.TcpConfiguration?.DisableTraceRoute
                                };

                                TestConfiguration.TcpConfiguration = TcpConfiguration;
                            }
                            else if (string.Compare(TestConfiguration.Protocol, "HTTP", true) == 0)
                            {
                                ConnectionMonitorHttpConfiguration HttpConfiguration = new ConnectionMonitorHttpConfiguration()
                                {
                                    Port = TestConfig.HttpConfiguration?.Port,
                                    Method = TestConfig.HttpConfiguration?.Method,
                                    Path = TestConfig.HttpConfiguration?.Path,
                                    PreferHTTPS = TestConfig.HttpConfiguration?.PreferHTTPS,
                                    ValidStatusCodeRanges = TestConfig.HttpConfiguration?.ValidStatusCodeRanges
                                };

                                if (TestConfig.HttpConfiguration?.RequestHeaders != null)
                                {
                                    foreach (KeyValuePair<string, string> RequestHeadersEntry in TestConfig.HttpConfiguration?.RequestHeaders)
                                    {
                                        HTTPHeader RequestHeaders = new HTTPHeader()
                                        {
                                            Name = RequestHeadersEntry.Key,
                                            Value = RequestHeadersEntry.Value
                                        };

                                        if (HttpConfiguration.RequestHeaders == null)
                                        {
                                            HttpConfiguration.RequestHeaders = new List<HTTPHeader>();
                                        }

                                        HttpConfiguration.RequestHeaders.Add(RequestHeaders);
                                    }

                                    TestConfiguration.HttpConfiguration = HttpConfiguration;
                                }
                            }
                            else if (string.Compare(TestConfiguration.Protocol, "ICMP", true) == 0)
                            {
                                ConnectionMonitorIcmpConfiguration IcmpConfiguration = new ConnectionMonitorIcmpConfiguration()
                                {
                                    DisableTraceRoute = TestConfig.IcmpConfiguration?.DisableTraceRoute
                                };

                                TestConfiguration.IcmpConfiguration = IcmpConfiguration;
                            }

                            // Add to parameters
                            if (parameters.TestConfigurations == null)
                            {
                                parameters.TestConfigurations = new List<ConnectionMonitorTestConfiguration>();
                            }

                            parameters.TestConfigurations.Add(TestConfiguration);
                        }

                    // Add Test Group
                    ConnectionMonitorTestGroup SdkTestGroup = new ConnectionMonitorTestGroup()
                    {
                        Name = TestGroup.Name,
                        Disable = TestGroup.Disable
                    };

                    foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in TestGroup.TestConfigurations)
                        {
                            if (SdkTestGroup.TestConfigurations == null)
                            {
                                SdkTestGroup.TestConfigurations = new List<string>();
                            }

                            SdkTestGroup.TestConfigurations.Add(TestConfiguration.Name);
                        };

                    foreach (PSNetworkWatcherConnectionMonitorEndpointObject Source in TestGroup.Sources)
                        {
                            if (SdkTestGroup.Sources == null)
                            {
                                SdkTestGroup.Sources = new List<string>();
                            }

                            SdkTestGroup.Sources.Add(Source.Name);
                        };

                    foreach (PSNetworkWatcherConnectionMonitorEndpointObject Destination in TestGroup.Destinations)
                        {
                            if (SdkTestGroup.Destinations == null)
                            {
                                SdkTestGroup.Destinations = new List<string>();

                            }
                            SdkTestGroup.Destinations.Add(Destination.Name);
                        };

                    if (parameters.TestGroups == null)
                    {
                        parameters.TestGroups  = new List<ConnectionMonitorTestGroup>();
                    }

                    parameters.TestGroups.Add(SdkTestGroup);
                }
            }

            // Add this.Output to parameters
            if (this.Output != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorOutputObject CMOutput in this.Output)
                {
                    if (parameters.Outputs == null)
                    {
                        parameters.Outputs = new List<ConnectionMonitorOutput>();
                    }

                    parameters.Outputs.Add(new ConnectionMonitorOutput()
                    {
                        Type = CMOutput.Type,
                        WorkspaceSettings = new ConnectionMonitorWorkspaceSettings()
                        {
                            WorkspaceResourceId = CMOutput.WorkspaceSettings.WorkspaceResourceId
                        },
                    });
                }
            }

            if (this.ConfigureOnly)
            {
                parameters.AutoStart = false;
            }

            if (this.MonitoringIntervalInSeconds != null)
            {
                parameters.MonitoringIntervalInSeconds = this.MonitoringIntervalInSeconds;
            }

            if (!string.IsNullOrEmpty(Notes))
            {
                parameters.Notes = this.Notes;
            }

            PSConnectionMonitorResult getConnectionMonitor = new PSConnectionMonitorResult();

            // Execute the CreateOrUpdate Connection monitor call
            if (ParameterSetName.Contains("SetByResource"))
            {
                parameters.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains("SetByName"))
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
                parameters.Location = networkWatcher.Location;
            }
            else
            {
                parameters.Location = this.Location;
            }

            if (connectionMonitorV2)
            {
                this.ConnectionMonitors.CreateOrUpdate(resourceGroupName, networkWatcherName, this.Name, parameters);
            }
            else
            {
                this.ConnectionMonitors.CreateOrUpdateV1(resourceGroupName, networkWatcherName, this.Name, parameters);
            }

            getConnectionMonitor = this.GetConnectionMonitor(resourceGroupName, networkWatcherName, this.Name, connectionMonitorV2);
            
            return getConnectionMonitor;
        }

        public bool Validate()
        {
            if (ParameterSetName.Contains("SetByResource") || ParameterSetName.Contains("SetByLocation") && (TestGroup != null || Output != null ))
            {
                throw new ArgumentException("Either connection monitor V1 or V2 can be specified");
            }

            // Validate Test Group
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

                        if (Endpoint.Filter.Type != null && String.Compare(Endpoint.Filter.Type, "Include", true) != 0)
                        {
                            throw new ArgumentException("Only FilterType Include is supported");
                        }
                        else if (Endpoint.Filter.Type != null && Endpoint.Filter.Items == null)
                        {
                            throw new ArgumentException("Endpoint FilterType defined without FilterAddress");
                        }
                        else if (Endpoint.Filter.Type != null && Endpoint.Filter.Items[0] != null && Endpoint.Filter.Items[0].Type != null && String.Compare(Endpoint.Filter.Items[0].Type, "AgentAddress", true) != 0)
                        {
                            throw new ArgumentException("Endpoint Filter Items Type is not AgentAddress");
                        }
                        else if (Endpoint.Filter.Type != null && Endpoint.Filter.Items[0] != null && Endpoint.Filter.Items[0].Type != null && string.IsNullOrEmpty(Endpoint.Filter.Items[0].Address))
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

                    foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in TestGroup.TestConfigurations)
                    {
                        if (TestGroup.TestConfigurations.Count(x => x.Name == TestConfiguration.Name) > 2)
                        {
                            throw new ArgumentException("Test configuration name is not unique");
                        }

                        // validate test configuration
                        if (TestConfiguration.HttpConfiguration == null && TestConfiguration.TcpConfiguration ==  null && TestConfiguration.IcmpConfiguration == null)
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
