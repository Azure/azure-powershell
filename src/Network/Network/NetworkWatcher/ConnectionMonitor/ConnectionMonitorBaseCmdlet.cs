
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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class ConnectionMonitorBaseCmdlet : NetworkBaseCmdlet
    {
        public IConnectionMonitorsOperations ConnectionMonitors
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ConnectionMonitors;
            }
        }

        public bool IsConnectionMonitorPresent(string resourceGroupName, string name, string connectionMonitorName, bool connectionMonitorV2 = false)
        {
            try
            {
                GetConnectionMonitor(resourceGroupName, name, connectionMonitorName, connectionMonitorV2);
            }
            catch (MNM.ErrorResponseException exception) when (exception.Response != null && exception.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return true;
        }

        public PSConnectionMonitorResult GetConnectionMonitor(string resourceGroupName, string name, string connectionMonitorName, bool connectionMonitorV2 = false)
        {
            ConnectionMonitorResult connectionMonitor = null;
            PSConnectionMonitorResult psConnectionMonitor = null;

            if (connectionMonitorV2)
            {
                connectionMonitor = this.ConnectionMonitors.Get(resourceGroupName, name, connectionMonitorName);

                WriteObject("Dispaly");

                if (String.Compare(connectionMonitor.ConnectionMonitorType, "SingleSourceDestination", true) == 0)
                {
                    psConnectionMonitor = ConvertConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitor);
                }
                else
                {
                    psConnectionMonitor = MapConnectionMonitorResultToPSConnectionMonitorResultV2(connectionMonitor);
                }

                WriteObject(psConnectionMonitor);
            }
            else
            {
                connectionMonitor = this.ConnectionMonitors.GetV1(resourceGroupName, name, connectionMonitorName);

                psConnectionMonitor = MapConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitor);
            }

            return psConnectionMonitor;
        }

        public ConnectionMonitorDetails GetConnectionMonitorDetails(string resourceId)
        {
            ConnectionMonitorDetails cmDetails = new ConnectionMonitorDetails();

            ResourceIdentifier connectionMonitorInfo = new ResourceIdentifier(resourceId);

            cmDetails.ConnectionMonitorName = connectionMonitorInfo.ResourceName;
            cmDetails.ResourceGroupName = connectionMonitorInfo.ResourceGroupName;

            string parent = connectionMonitorInfo.ParentResource;
            string[] tokens = parent.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            cmDetails.NetworkWatcherName = tokens[1];

            return cmDetails;
        }

        public MNM.NetworkWatcher GetNetworkWatcherByLocation(string location)
        {
            var nwList = this.NetworkClient.NetworkManagementClient.NetworkWatchers.ListAll();
            foreach (var nw in nwList)
            {
                if (nw.Location == location)
                {
                    return nw;
                }
            }

            return null;
        }

        public PSConnectionMonitorResultV2 MapConnectionMonitorResultToPSConnectionMonitorResultV2(ConnectionMonitorResult ConnectionMonitor)
        {
            PSConnectionMonitorResultV2 psConnectionMonitor = new PSConnectionMonitorResultV2()
            {
                Name = ConnectionMonitor.Name,
                Id = ConnectionMonitor.Id,
                Etag = ConnectionMonitor.Etag,
                ProvisioningState = ConnectionMonitor.ProvisioningState,
                Type = ConnectionMonitor.Type,
                Location = ConnectionMonitor.Location,
                StartTime = ConnectionMonitor.StartTime,
                Tags = new Dictionary<string, string>(),
                ConnectionMonitorType = ConnectionMonitor.ConnectionMonitorType,
                Notes = ConnectionMonitor.Notes,

                TestConfigurations = NetworkResourceManagerProfile.Mapper.Map<List<PSNetworkWatcherConnectionMonitorTestConfigurationObject>>(ConnectionMonitor.TestConfigurations),
                Endpoints = NetworkResourceManagerProfile.Mapper.Map<List<PSNetworkWatcherConnectionMonitorEndpointObject>>(ConnectionMonitor.Endpoints),
                Outputs = NetworkResourceManagerProfile.Mapper.Map<List<PSNetworkWatcherConnectionMonitorOutputObject>>(ConnectionMonitor.Outputs),
            };

            if (ConnectionMonitor.Tags != null)
            {
                foreach (KeyValuePair<string, string> KeyValue in ConnectionMonitor.Tags)
                {
                    psConnectionMonitor.Tags.Add(KeyValue.Key, KeyValue.Value);
                }
            }

            if (ConnectionMonitor.TestGroups != null)
            {
                foreach (ConnectionMonitorTestGroup TestGroup in ConnectionMonitor.TestGroups)
                {
                    PSNetworkWatcherConnectionMonitorTestGroupObject TestGroupObject = new PSNetworkWatcherConnectionMonitorTestGroupObject()
                    {
                        Name = TestGroup.Name,
                        Disable = TestGroup.Disable,
                        TestConfigurations = new List<PSNetworkWatcherConnectionMonitorTestConfigurationObject>(),
                        Sources = new List<PSNetworkWatcherConnectionMonitorEndpointObject>(),
                        Destinations = new List<PSNetworkWatcherConnectionMonitorEndpointObject>()
                    };

                    // Sources
                    if (TestGroup.Sources != null)
                    {
                        foreach (string SourceEndpoint in TestGroup.Sources)
                        {
                            ConnectionMonitorEndpoint SdkSourceEndpoint = GetEndpoinByName(ConnectionMonitor.Endpoints, SourceEndpoint);

                            PSNetworkWatcherConnectionMonitorEndpointObject EndpointObject =
                                NetworkResourceManagerProfile.Mapper.Map<PSNetworkWatcherConnectionMonitorEndpointObject>(SdkSourceEndpoint);

                            // Add the Source Endpoints to the TestGroup
                            TestGroupObject.Sources.Add(EndpointObject);
                        }
                    }

                    // Destinations
                    if (TestGroup.Destinations != null)
                    {
                        foreach (string DestinationEndpoint in TestGroup.Destinations)
                        {
                            ConnectionMonitorEndpoint SdkDestinationEndpoint = GetEndpoinByName(ConnectionMonitor.Endpoints, DestinationEndpoint);

                            PSNetworkWatcherConnectionMonitorEndpointObject EndpointObject =
                                NetworkResourceManagerProfile.Mapper.Map<PSNetworkWatcherConnectionMonitorEndpointObject>(SdkDestinationEndpoint);

                            // Add the Destination Endpoints to the TestGroup
                            TestGroupObject.Destinations.Add(EndpointObject);
                        }
                    }

                    // Test Configuration
                    if (TestGroup.TestConfigurations != null)
                    {
                        foreach (string TestConfigurationName in TestGroup.TestConfigurations)
                        {
                            ConnectionMonitorTestConfiguration SdkTestConfiguration = GetTestConfigurationByName(ConnectionMonitor.TestConfigurations, TestConfigurationName);

                            PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfigurationObject =
                                NetworkResourceManagerProfile.Mapper.Map<PSNetworkWatcherConnectionMonitorTestConfigurationObject>(SdkTestConfiguration);

                            // Add the Test Configuration to the TestGroup
                            TestGroupObject.TestConfigurations.Add(TestConfigurationObject);
                        }
                    }

                    if (psConnectionMonitor.TestGroups == null)
                    {
                        psConnectionMonitor.TestGroups = new List<PSNetworkWatcherConnectionMonitorTestGroupObject>();
                    }

                    psConnectionMonitor.TestGroups.Add(TestGroupObject);
                }
            }

            return psConnectionMonitor;
        }

        public PSConnectionMonitorResultV1 MapConnectionMonitorResultToPSConnectionMonitorResultV1(ConnectionMonitorResult ConnectionMonitor)
        {
            PSConnectionMonitorResultV1 psConnectionMonitor = new PSConnectionMonitorResultV1()
            {
                Name = ConnectionMonitor.Name,
                Id = ConnectionMonitor.Id,
                Etag = ConnectionMonitor.Etag,
                ProvisioningState = ConnectionMonitor.ProvisioningState,
                Type = ConnectionMonitor.Type,
                Location = ConnectionMonitor.Location,
                AutoStart = ConnectionMonitor.AutoStart,
                MonitoringIntervalInSeconds = ConnectionMonitor.MonitoringIntervalInSeconds,
                StartTime = ConnectionMonitor.StartTime,
                MonitoringStatus = ConnectionMonitor.MonitoringStatus,
                Tags = NetworkResourceManagerProfile.Mapper.Map<Dictionary<string, string>>(ConnectionMonitor.Tags),
                ConnectionMonitorType = ConnectionMonitor.ConnectionMonitorType,
                Source = NetworkResourceManagerProfile.Mapper.Map<PSConnectionMonitorSource>(ConnectionMonitor.Source),
                Destination = NetworkResourceManagerProfile.Mapper.Map<PSConnectionMonitorDestination>(ConnectionMonitor.Destination),
            };

            return psConnectionMonitor;
        }

        public MNM.ConnectionMonitorTestConfiguration GetTestConfigurationByName(IList<ConnectionMonitorTestConfiguration> TestConfigurations, string TestConfigName)
        {
            if (TestConfigurations == null || string.IsNullOrEmpty(TestConfigName))
                return null;

            foreach (ConnectionMonitorTestConfiguration TestConfiguration in TestConfigurations)
            {
                if (string.Compare(TestConfigName, TestConfiguration.Name) == 0)
                {
                    return TestConfiguration;
                }
            }

            return null;
        }

        public MNM.ConnectionMonitorEndpoint GetEndpoinByName(IList<ConnectionMonitorEndpoint> Endpoints, string EndpointName)
        {
            if (Endpoints == null || string.IsNullOrEmpty(EndpointName))
                return null;

            foreach (ConnectionMonitorEndpoint Endpoint in Endpoints)
            {
                if (string.Compare(EndpointName, Endpoint.Name) == 0)
                {
                    return Endpoint;
                }
            }

            return null;
        }

    public bool ValidateConnectionMonitorV2Parameters(string SourceResourceId, List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroups, List<PSNetworkWatcherConnectionMonitorOutputObject> Outputs)
        {
            if (!string.IsNullOrEmpty(SourceResourceId) && TestGroups != null)
            {
                throw new ArgumentException("SourceResourceId can not be defined with either TestGroup or Output. Either connection monitor V1 or V2 can be specified");
            }

            if (string.IsNullOrEmpty(SourceResourceId) && TestGroups == null)
            {
                throw new ArgumentException("SourceResourceId is not defined");
            }

            // Validate Test Group
            if (TestGroups != null && TestGroups.Any())
            {
                foreach (PSNetworkWatcherConnectionMonitorTestGroupObject TestGroup in TestGroups)
                {
                    // validate mandatory parameters
                    if (string.IsNullOrEmpty(TestGroup.Name) || TestGroup.TestConfigurations == null || TestGroup.Sources == null || TestGroup.Destinations == null)
                    {
                        throw new ArgumentException("Test group is missing one or more mandatory parameter");
                    }

                    // validate Source and Destination Endpoints
                    List<PSNetworkWatcherConnectionMonitorEndpointObject> Endpoints = TestGroup.Sources;
                    Endpoints.Concat(TestGroup.Destinations);

                    //validate end point
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

                            if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && String.Compare(Endpoint.Filter.Type, "Include", true) != 0)
                            {
                                throw new ArgumentException("Only FilterType Include is supported");
                            }
                            else if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && Endpoint.Filter.Items == null)
                            {
                                throw new ArgumentException("Endpoint FilterType defined without FilterAddress");
                            }
                            else if (Endpoint.Filter != null && !string.IsNullOrEmpty(Endpoint.Filter.Type) && !Endpoint.Filter.Items.Any())
                            {
                                throw new ArgumentException("Endpoint FilterAddress is empty");
                            }
                            else if (Endpoint.Filter != null && Endpoint.Filter.Items != null && Endpoint.Filter.Items.Any())
                            {
                                foreach (PSConnectionMonitorEndpointFilterItem Item in Endpoint.Filter.Items)
                                {
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
                    else
                    {
                        throw new ArgumentException("No sources or destination endpoints");
                    }

                    //validate test configuration
                    if (TestGroup.TestConfigurations.Any())
                    {
                        foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfiguration in TestGroup.TestConfigurations)
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
                            if (!string.IsNullOrEmpty(TestConfiguration.Name) && TestGroup.TestConfigurations.Count(x => x.Name == TestConfiguration.Name) > 2)
                            {
                                throw new ArgumentException("Test configuration name is not unique");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No test configuraiton is provided");
                    }
                }
            }
            else if (TestGroups != null && !TestGroups.Any())
            {
                throw new ArgumentException("TestGroup is empty");
            }

            // validate output
            if (Outputs != null && Outputs.Any())
            {
                foreach (PSNetworkWatcherConnectionMonitorOutputObject Output in Outputs)
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
            else if (Outputs != null && !Outputs.Any())
            {
                throw new ArgumentException("Output is empty");
            }

            return true;
        }

    public bool UpdateConnectionMonitorV2Parameters(List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroups, List<PSNetworkWatcherConnectionMonitorOutputObject> Outputs, ConnectionMonitor parameters)
        {
            if (TestGroups != null)
            {
                // Parse each input test group
                foreach (PSNetworkWatcherConnectionMonitorTestGroupObject TestGroup in TestGroups)
                {
                    // With start by add Test Group
                    ConnectionMonitorTestGroup TestGrp = new ConnectionMonitorTestGroup()
                    {
                        Name = TestGroup.Name,
                        Disable = TestGroup.Disable
                    };

                    // Add source Endpoint
                    foreach (PSNetworkWatcherConnectionMonitorEndpointObject SrcEndpoint in TestGroup.Sources)
                    {
                        ConnectionMonitorEndpoint SourceEndpoint = new ConnectionMonitorEndpoint()
                        {
                            Name = SrcEndpoint.Name,
                            ResourceId = SrcEndpoint.ResourceId,
                            Address = SrcEndpoint.Address,
                        };

                        // Add ConnectionMonitorEndpointFilterItem
                        if (SrcEndpoint.Filter?.Items != null)
                        {
                            SourceEndpoint.Filter = new ConnectionMonitorEndpointFilter()
                            {
                                Type = string.IsNullOrEmpty(SrcEndpoint.Filter.Type) ? "Include" : SrcEndpoint.Filter.Type
                            };

                            foreach (PSConnectionMonitorEndpointFilterItem Items in SrcEndpoint.Filter.Items)
                            {
                                if (SourceEndpoint.Filter.Items == null)
                                {
                                    SourceEndpoint.Filter.Items = new List<ConnectionMonitorEndpointFilterItem>();
                                }

                                SourceEndpoint.Filter.Items.Add(new ConnectionMonitorEndpointFilterItem()
                                {
                                    Type = string.IsNullOrEmpty(Items.Type) ? "AgnetAddress" : Items.Type,
                                    Address = Items.Address
                                });
                            }
                        }

                        if (parameters.Endpoints == null)
                        {
                            parameters.Endpoints = new List<ConnectionMonitorEndpoint>();
                        }

                        if (parameters.Endpoints.Count(x => x.Name == SourceEndpoint.Name) == 0)
                        {
                            parameters.Endpoints.Add(SourceEndpoint);
                        }

                        // Add it to the output
                        if (TestGrp.Sources == null)
                        {
                            TestGrp.Sources = new List<string>();
                        }

                        TestGrp.Sources.Add(SourceEndpoint.Name);
                    }

                    // Add destination Endpoint
                    foreach (PSNetworkWatcherConnectionMonitorEndpointObject DstEndpoint in TestGroup.Destinations)
                    {
                        ConnectionMonitorEndpoint DestinationEndpoint = new ConnectionMonitorEndpoint()
                        {
                            Name = DstEndpoint.Name,
                            ResourceId = DstEndpoint.ResourceId,
                            Address = DstEndpoint.Address,
                        };

                        // Add ConnectionMonitorEndpointFilterItem
                        if (DstEndpoint.Filter?.Items != null)
                        {
                            DestinationEndpoint.Filter = new ConnectionMonitorEndpointFilter()
                            {
                                Type = string.IsNullOrEmpty(DstEndpoint.Filter.Type) ? "Include" : DstEndpoint.Filter.Type
                            };

                            foreach (PSConnectionMonitorEndpointFilterItem Items in DstEndpoint.Filter.Items)
                            {
                                if (DestinationEndpoint.Filter.Items == null)
                                {
                                    DestinationEndpoint.Filter.Items = new List<ConnectionMonitorEndpointFilterItem>();
                                }

                                DestinationEndpoint.Filter.Items.Add(new ConnectionMonitorEndpointFilterItem()
                                {
                                    Type = string.IsNullOrEmpty(Items.Type)? "AgentAddress" : Items.Type,
                                    Address = Items.Address
                                });
                            }
                        }

                        if (parameters.Endpoints == null)
                        {
                            parameters.Endpoints = new List<ConnectionMonitorEndpoint>();
                        }

                        if (parameters.Endpoints.Count(x => x.Name == DestinationEndpoint.Name) == 0)
                        {
                            parameters.Endpoints.Add(DestinationEndpoint);
                        }

                        //Add it to the output
                        if (TestGrp.Destinations == null)
                        {
                            TestGrp.Destinations = new List<string>();
                        }
                        TestGrp.Destinations.Add(DestinationEndpoint.Name);
                    }

                    // Add test configuration
                    uint TestConfigCounter = 1;
                    foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject TestConfig in TestGroup.TestConfigurations)
                    {
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
                                foreach (PSHTTPHeader RequestHeadersEntry in TestConfig.HttpConfiguration.RequestHeaders)
                                {
                                    HTTPHeader RequestHeaders = new HTTPHeader()
                                    {
                                        Name = RequestHeadersEntry.Name,
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

                        if (parameters.TestConfigurations.Count(x => x.Name == TestConfiguration.Name) == 0)
                        {
                            parameters.TestConfigurations.Add(TestConfiguration);
                        }

                        // Add it to the ouput
                        if (TestGrp.TestConfigurations == null)
                        {
                            TestGrp.TestConfigurations = new List<string>();
                        }
                        TestGrp.TestConfigurations.Add(TestConfiguration.Name);
                    }

                    if (parameters.TestGroups == null)
                    {
                        parameters.TestGroups = new List<ConnectionMonitorTestGroup>();
                    }

                    parameters.TestGroups.Add(TestGrp);
                }
            }

            // Add this.Output to parameters
            if (Outputs != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorOutputObject Output in Outputs)
                {
                    ConnectionMonitorOutput CMOutput = new ConnectionMonitorOutput()
                    {
                        Type = Output.Type,
                        WorkspaceSettings = new ConnectionMonitorWorkspaceSettings()
                        {
                            WorkspaceResourceId = Output.WorkspaceSettings.WorkspaceResourceId
                        },
                    };

                    if (parameters.Outputs == null)
                    {
                        parameters.Outputs = new List<ConnectionMonitorOutput>();
                    }

                    parameters.Outputs.Add(CMOutput);
                }
            }
            return true;
        }

    public PSConnectionMonitorResultV1 ConvertConnectionMonitorResultToPSConnectionMonitorResultV1(ConnectionMonitorResult ConnectionMonitorResult)
        {
            PSConnectionMonitorResultV2 PSConnectionMonitorResultV2 = MapConnectionMonitorResultToPSConnectionMonitorResultV2(ConnectionMonitorResult);

            PSConnectionMonitorResultV1 ConnectionMonitorResultV1 = new PSConnectionMonitorResultV1()
            {
                Name = ConnectionMonitorResult.Name,
                Id = ConnectionMonitorResult.Id,
                Etag = ConnectionMonitorResult.Etag,
                ProvisioningState = ConnectionMonitorResult.ProvisioningState,
                Type = ConnectionMonitorResult.Type,
                Location = ConnectionMonitorResult.Location,
                AutoStart = ConnectionMonitorResult.AutoStart,
                MonitoringIntervalInSeconds = ConnectionMonitorResult.MonitoringIntervalInSeconds,
                StartTime = ConnectionMonitorResult.StartTime,
                MonitoringStatus = ConnectionMonitorResult.MonitoringStatus,
                ConnectionMonitorType = ConnectionMonitorResult.ConnectionMonitorType,
                Tags = new Dictionary<string, string>()
                //Source 
                //Destination
            };

            if (ConnectionMonitorResult.Tags != null)
            {
                foreach (KeyValuePair<string, string> KeyValue in ConnectionMonitorResult.Tags)
                {
                    ConnectionMonitorResultV1.Tags.Add(KeyValue.Key, KeyValue.Value);
                }
            }

            if (ConnectionMonitorResultV1.Source == null)
            {
                ConnectionMonitorResultV1.Source = new PSConnectionMonitorSource()
                {
                    ResourceId = PSConnectionMonitorResultV2.TestGroups?[0]?.Sources?[0]?.ResourceId
                    // Port
                };
            }

            if (ConnectionMonitorResultV1.Destination == null)
            {
                ConnectionMonitorResultV1.Destination = new PSConnectionMonitorDestination()
                {
                    ResourceId = PSConnectionMonitorResultV2.TestGroups?[0]?.Destinations?[0]?.ResourceId,
                    Address = PSConnectionMonitorResultV2.TestGroups?[0]?.Destinations?[0]?.Address,
                    Port = PSConnectionMonitorResultV2.TestConfigurations?[0]?.TcpConfiguration?.Port ?? default(int)
                };
            }

            // These parameters do not need mapping 
            // ConnectionMonitorResult.AutoStart = false;
            // getConnectionMonitor.StartTime
            // getConnectionMonitor.MonitoringStatus

            return ConnectionMonitorResultV1;
        }
    }
}