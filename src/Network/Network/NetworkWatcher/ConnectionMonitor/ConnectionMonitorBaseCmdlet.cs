
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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
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

        public bool IsConnectionMonitorPresent(string resourceGroupName, string name, string connectionMonitorName)
        {
            try
            {
                this.ConnectionMonitors.Get(resourceGroupName, name, connectionMonitorName);
            }
            catch (MNM.ErrorResponseException exception) when (exception.Response != null && exception.Response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return true;
        }

        public PSConnectionMonitorResult GetConnectionMonitor(string resourceGroupName, string name, string connectionMonitorName, bool connectionMonitorV2 = false)
        {
            ConnectionMonitorResult connectionMonitor;
            PSConnectionMonitorResult psConnectionMonitor;

            if (connectionMonitorV2)
            {
                connectionMonitor = this.ConnectionMonitors.Get(resourceGroupName, name, connectionMonitorName);
                psConnectionMonitor = ConvertConnectionMonitorResultV2ToPSFormat(connectionMonitor);
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

        public PSConnectionMonitorResultV2 MapConnectionMonitorResultToPSConnectionMonitorResultV2(ConnectionMonitorResult connectionMonitor)
        {
            PSConnectionMonitorResultV2 psConnectionMonitor = new PSConnectionMonitorResultV2()
            {
                Name = connectionMonitor.Name,
                Id = connectionMonitor.Id,
                Etag = connectionMonitor.Etag,
                ProvisioningState = connectionMonitor.ProvisioningState,
                Type = connectionMonitor.Type,
                Location = connectionMonitor.Location,
                StartTime = connectionMonitor.StartTime,
                Tags = new Dictionary<string, string>(),
                ConnectionMonitorType = connectionMonitor.ConnectionMonitorType,
                Notes = connectionMonitor.Notes,
                TestGroups = new List<PSNetworkWatcherConnectionMonitorTestGroupObject>()
            };

            if (connectionMonitor.Tags != null)
            {
                foreach (KeyValuePair<string, string> KeyValue in connectionMonitor.Tags)
                {
                    psConnectionMonitor.Tags.Add(KeyValue.Key, KeyValue.Value);
                }
            }

            if (connectionMonitor.Outputs != null)
            {
                psConnectionMonitor.Outputs = new List<PSNetworkWatcherConnectionMonitorOutputObject>();
                foreach (ConnectionMonitorOutput output in connectionMonitor.Outputs)
                {
                    psConnectionMonitor.Outputs.Add(
                        new PSNetworkWatcherConnectionMonitorOutputObject()
                        {
                            Type = output.Type,
                            WorkspaceSettings = new PSConnectionMonitorWorkspaceSettings()
                            {
                                WorkspaceResourceId = output.WorkspaceSettings?.WorkspaceResourceId
                            }
                        });
                }
            }

            if (connectionMonitor.TestGroups != null)
            {
                foreach (ConnectionMonitorTestGroup testGroup in connectionMonitor.TestGroups)
                {
                    PSNetworkWatcherConnectionMonitorTestGroupObject testGroupObject = new PSNetworkWatcherConnectionMonitorTestGroupObject()
                    {
                        Name = testGroup.Name,
                        Disable = testGroup.Disable,
                        TestConfigurations = new List<PSNetworkWatcherConnectionMonitorTestConfigurationObject>(),
                        Sources = new List<PSNetworkWatcherConnectionMonitorEndpointObject>(),
                        Destinations = new List<PSNetworkWatcherConnectionMonitorEndpointObject>()
                    };

                    if (testGroup.Sources != null)
                    {
                        foreach (string sourceEndpointName in testGroup.Sources)
                        {
                            ConnectionMonitorEndpoint sourceEndpoint = GetEndpoinByName(connectionMonitor.Endpoints, sourceEndpointName);

                            PSNetworkWatcherConnectionMonitorEndpointObject EndpointObject =
                                NetworkResourceManagerProfile.Mapper.Map<PSNetworkWatcherConnectionMonitorEndpointObject>(sourceEndpoint);

                            testGroupObject.Sources.Add(EndpointObject);
                        }
                    }

                    if (testGroup.Destinations != null)
                    {
                        foreach (string destinationEndpointName in testGroup.Destinations)
                        {
                            ConnectionMonitorEndpoint destinationEndpoint = GetEndpoinByName(connectionMonitor.Endpoints, destinationEndpointName);

                            PSNetworkWatcherConnectionMonitorEndpointObject EndpointObject =
                                NetworkResourceManagerProfile.Mapper.Map<PSNetworkWatcherConnectionMonitorEndpointObject>(destinationEndpoint);

                            testGroupObject.Destinations.Add(EndpointObject);
                        }
                    }

                    // Test Configuration
                    if (testGroup.TestConfigurations != null)
                    {
                        foreach (string testConfigurationName in testGroup.TestConfigurations)
                        {
                            ConnectionMonitorTestConfiguration testConfiguration = GetTestConfigurationByName(connectionMonitor.TestConfigurations, testConfigurationName);

                            PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfigurationObject = new PSNetworkWatcherConnectionMonitorTestConfigurationObject()
                            {
                                Name = testConfiguration.Name,
                                PreferredIPVersion = testConfiguration.PreferredIPVersion,
                                TestFrequencySec = testConfiguration.TestFrequencySec,
                                SuccessThreshold = testConfiguration.SuccessThreshold == null ? null : 
                                    new PSNetworkWatcherConnectionMonitorSuccessThreshold()
                                    {
                                        ChecksFailedPercent = testConfiguration.SuccessThreshold.ChecksFailedPercent,
                                        RoundTripTimeMs = testConfiguration.SuccessThreshold.RoundTripTimeMs
                                    },
                                ProtocolConfiguration = this.GetPSProtocolConfiguration(testConfiguration)
                            };

                            testGroupObject.TestConfigurations.Add(testConfigurationObject);
                        }
                    }

                    psConnectionMonitor.TestGroups.Add(testGroupObject);
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
                if (string.Equals(TestConfigName, TestConfiguration.Name))
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
                if (string.Equals(EndpointName, Endpoint.Name))
                {
                    return Endpoint;
                }
            }

            return null;
        }

        public ConnectionMonitor PopulateConnectionMonitorParametersFromV2Request(
            PSNetworkWatcherConnectionMonitorTestGroupObject[] testGroups, 
            PSNetworkWatcherConnectionMonitorOutputObject[] outputs, 
            string notes)
        {
            ConnectionMonitor connectionMonitor = new ConnectionMonitor()
            {
                TestGroups = new List<ConnectionMonitorTestGroup>(),
                Endpoints = new List<ConnectionMonitorEndpoint>(),
                TestConfigurations = new List<ConnectionMonitorTestConfiguration>(),
                Outputs = this.GetOutputs(outputs),
                Notes = notes
            };

            foreach (PSNetworkWatcherConnectionMonitorTestGroupObject testGroup in testGroups)
            {
                ConnectionMonitorTestGroup cmTestGroup = new ConnectionMonitorTestGroup()
                {
                    Name = testGroup.Name,
                    Disable = testGroup.Disable,
                    Sources = new List<string>(),
                    Destinations = new List<string>(),
                    TestConfigurations = new List<string>()
                };

                this.AddSourceEndpointsToConnectionMonitorTestGroup(testGroup, cmTestGroup, connectionMonitor);
                this.AddDestinationEndpointsToConnectionMonitorTestGroup(testGroup, cmTestGroup, connectionMonitor);
                this.AddTestConfigurationsToConnectionMonitorTestGroup(testGroup, cmTestGroup, connectionMonitor);

                connectionMonitor.TestGroups.Add(cmTestGroup);
            }

            return connectionMonitor;
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
                StartTime = ConnectionMonitorResult.StartTime,
                MonitoringStatus = ConnectionMonitorResult.MonitoringStatus,
                ConnectionMonitorType = ConnectionMonitorResult.ConnectionMonitorType,
                MonitoringIntervalInSeconds = ConnectionMonitorResult.TestConfigurations?[0]?.TestFrequencySec,
                Tags = new Dictionary<string, string>()
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
                };
            }

            if (ConnectionMonitorResultV1.Destination == null)
            {
                ConnectionMonitorResultV1.Destination = new PSConnectionMonitorDestination()
                {
                    ResourceId = PSConnectionMonitorResultV2.TestGroups?[0]?.Destinations?[0]?.ResourceId,
                    Address = PSConnectionMonitorResultV2.TestGroups?[0]?.Destinations?[0]?.Address,
                    Port = GetDestinationPort(PSConnectionMonitorResultV2.TestGroups?[0]?.TestConfigurations[0])
                };
            }

            return ConnectionMonitorResultV1;
        }

        private int GetDestinationPort(PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration)
        {
            if (testConfiguration == null)
            {
                return 0;
            }

            if (testConfiguration.ProtocolConfiguration is PSNetworkWatcherConnectionMonitorTcpConfiguration tcpConfiguration)
            {
                return tcpConfiguration.Port == null ? 0 : (int)tcpConfiguration.Port;
            }

            if (testConfiguration.ProtocolConfiguration is PSNetworkWatcherConnectionMonitorHttpConfiguration httpConfiguration)
            {
                return httpConfiguration.Port == null ? 0 : (int)httpConfiguration.Port;
            }

            return 0;
        }

        public PSConnectionMonitorResult ConvertConnectionMonitorResultV2ToPSFormat(ConnectionMonitorResult connectionMonitor)
        {
            PSConnectionMonitorResult psConnectionMonitor = null;

            if (String.Equals(connectionMonitor.ConnectionMonitorType, "SingleSourceDestination"))
            {
                psConnectionMonitor = ConvertConnectionMonitorResultToPSConnectionMonitorResultV1(connectionMonitor);
            }
            else
            {
                psConnectionMonitor = MapConnectionMonitorResultToPSConnectionMonitorResultV2(connectionMonitor);
            }
            return psConnectionMonitor;
        }

        public void ValidateConnectionMonitor(PSNetworkWatcherConnectionMonitorObject connectionMonitor, bool throwIfTestGroupNotSet = true)
        {
            if (throwIfTestGroupNotSet && (connectionMonitor.TestGroups == null || !connectionMonitor.TestGroups.Any()))
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorMustHaveTestGroups);
            }

            if (connectionMonitor.TestGroups != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorTestGroupObject testGroup in connectionMonitor.TestGroups)
                {
                    this.ValidateTestGroup(testGroup);
                }
            }

            if (connectionMonitor.Outputs != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorOutputObject output in connectionMonitor.Outputs)
                {
                    this.ValidateOutput(output);
                }
            }
        }

        public void ValidateOutput(PSNetworkWatcherConnectionMonitorOutputObject output)
        {
            if (output.Type != null && !output.Type.Equals("Workspace", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.InvalidConnectionMonitorOutputType);
            }

            if (string.IsNullOrEmpty(output.WorkspaceSettings?.WorkspaceResourceId))
            {
                throw new PSArgumentException(Properties.Resources.WorkspaceResourceIdIsNotProvidedInConnectionMonitorOutput);
            }

            string[] SplittedName = output.WorkspaceSettings.WorkspaceResourceId.Split('/');
            if (SplittedName.Count() < 9 || string.IsNullOrEmpty(SplittedName[7]) || !SplittedName[7].Equals("workspaces", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.InvalidWorkspaceResourceId);
            }
        }

        public void ValidateProtocolConfiguration(PSNetworkWatcherConnectionMonitorProtocolConfiguration protocolConfiguration)
        {
            if (protocolConfiguration == null)
            {
                throw new PSArgumentException(Properties.Resources.ProtocolConfigurationIsNotDefined);
            }

            Type protocolConfigurationType = protocolConfiguration.GetType();
            if (protocolConfigurationType == typeof(PSNetworkWatcherConnectionMonitorTcpConfiguration))
            {
                this.ValidateTCPProtocolConfiguration(protocolConfiguration as PSNetworkWatcherConnectionMonitorTcpConfiguration);
            }
            else if (protocolConfigurationType == typeof(PSNetworkWatcherConnectionMonitorHttpConfiguration))
            {
                this.ValidateHTTPProtocolConfiguration(protocolConfiguration as PSNetworkWatcherConnectionMonitorHttpConfiguration);
            }
            else if (protocolConfigurationType != typeof(PSNetworkWatcherConnectionMonitorIcmpConfiguration))
            {
                throw new PSArgumentException(Properties.Resources.UnsupportedProtocolConfigurationType);
            }
        }

        public void ValidateTCPProtocolConfiguration(PSNetworkWatcherConnectionMonitorTcpConfiguration tcpProtocolConfiguration)
        {
            this.ValidatePort(tcpProtocolConfiguration.Port, throwIfNull: true);

            if (!string.IsNullOrEmpty(tcpProtocolConfiguration.DestinationPortBehavior)
                && !string.Equals(tcpProtocolConfiguration.DestinationPortBehavior, "None", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(tcpProtocolConfiguration.DestinationPortBehavior, "ListenIfAvailable", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.UnsupportedDestinationPortBehavior);
            }
        }

        public void ValidateHTTPProtocolConfiguration(PSNetworkWatcherConnectionMonitorHttpConfiguration httpProtocolConfiguration)
        {
            if (httpProtocolConfiguration.Port != null)
            {
                this.ValidatePort(httpProtocolConfiguration.Port);
            }

            if (!string.IsNullOrEmpty(httpProtocolConfiguration.Method) && !httpProtocolConfiguration.Method.Equals("GET", StringComparison.OrdinalIgnoreCase)
                && !httpProtocolConfiguration.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.UnsupportedHTTPMethod);
            }

            if (!string.IsNullOrEmpty(httpProtocolConfiguration.Path) && !Uri.IsWellFormedUriString(httpProtocolConfiguration.Path, UriKind.Relative))
            {
                throw new PSArgumentException(Properties.Resources.InvalidHttpUriPathFormat);
            }

            if (!this.IsValidStatusCodeRanges(httpProtocolConfiguration.ValidStatusCodeRanges))
            {
                throw new PSArgumentException(Properties.Resources.InvalidStatusCodeRangesFormat);
            }

            this.ValidateRequestHeaders(httpProtocolConfiguration.RequestHeaders);
        }

        public void ValidateConnectionMonitorV2Request(
            PSNetworkWatcherConnectionMonitorTestGroupObject[] testGroups,
            PSNetworkWatcherConnectionMonitorOutputObject[] outputs)
        {
            if (testGroups == null || !testGroups.Any())
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorMustHaveTestGroups);
            }

            foreach (PSNetworkWatcherConnectionMonitorTestGroupObject testGroup in testGroups)
            {
                this.ValidateTestGroup(testGroup);
            }

            if (outputs != null)
            {
                foreach (PSNetworkWatcherConnectionMonitorOutputObject output in outputs)
                {
                    this.ValidateOutput(output);
                }
            }
        }

        public void ValidateEndpoint(PSNetworkWatcherConnectionMonitorEndpointObject endpoint)
        {
            if (string.IsNullOrEmpty(endpoint.Name))
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorEndpointMustHaveName);
            }

            if (string.IsNullOrEmpty(endpoint.ResourceId) && string.IsNullOrEmpty(endpoint.Address))
            {
                throw new PSArgumentException(Properties.Resources.MissedPropertiesInConnectionMonitorEndpoint);
            }

            this.ValidateEndpointType(endpoint);
            this.ValidateEndpointResourceId(endpoint);
        }

        public void ValidateTestConfiguration(PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration)
        {
            if (string.IsNullOrEmpty(testConfiguration.Name))
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorTestConfigurationMustHaveName);
            }

            this.ValidateProtocolConfiguration(testConfiguration.ProtocolConfiguration);
            this.ValidateTestFrequency(testConfiguration.TestFrequencySec);
            this.ValidateSucessThreshold(testConfiguration.SuccessThreshold);
            this.ValidatePreferredIPVersion(testConfiguration.PreferredIPVersion);
        }

        public void ValidateTestGroup(PSNetworkWatcherConnectionMonitorTestGroupObject testGroup)
        {
            if (string.IsNullOrEmpty(testGroup.Name))
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorTestGroupMustHaveName);
            }

            if (testGroup.TestConfigurations == null || !testGroup.TestConfigurations.Any())
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorTestGroupMustHaveTestConfiguration);
            }

            HashSet<string> testConfigurationNames = new HashSet<string>();
            foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration in testGroup.TestConfigurations)
            {
                this.ValidateTestConfiguration(testConfiguration);

                if (!testConfigurationNames.Add(testConfiguration.Name))
                {
                    throw new PSArgumentException(Properties.Resources.TestConfigurationNamesMustBeUnique);
                }
            }

            if (testGroup.Sources == null || !testGroup.Sources.Any())
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorTestGroupMustHaveSourceEndpoint);
            }

            HashSet<string> sourceEndpointNames = new HashSet<string>();
            foreach (PSNetworkWatcherConnectionMonitorEndpointObject endpoint in testGroup.Sources)
            {
                this.ValidateEndpoint(endpoint);

                if (!sourceEndpointNames.Add(endpoint.Name))
                {
                    throw new PSArgumentException(Properties.Resources.ConnectionMonitorSourceEndpointNamesMustBeUnique);
                }
            }

            if (testGroup.Destinations == null || !testGroup.Destinations.Any())
            {
                throw new PSArgumentException(Properties.Resources.ConnectionMonitorTestGroupMustHaveDestinationEndpoint);
            }

            HashSet<string> destinationEndpointNames = new HashSet<string>();
            foreach (PSNetworkWatcherConnectionMonitorEndpointObject endpoint in testGroup.Destinations)
            {
                this.ValidateEndpoint(endpoint);

                if (!destinationEndpointNames.Add(endpoint.Name))
                {
                    throw new PSArgumentException(Properties.Resources.ConnectionMonitorDestinationEndpointNamesMustBeUnique);
                }
            }
        }

        private void AddTestConfigurationsToConnectionMonitorTestGroup(
            PSNetworkWatcherConnectionMonitorTestGroupObject testGroup,
            ConnectionMonitorTestGroup cmTestGroup,
            ConnectionMonitor connectionMonitor)
        {
            foreach (PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration in testGroup.TestConfigurations)
            {
                ConnectionMonitorTestConfiguration cmTestConfiguration = new ConnectionMonitorTestConfiguration()
                {
                    Name = testConfiguration.Name,
                    PreferredIPVersion = testConfiguration.PreferredIPVersion,
                    TestFrequencySec = testConfiguration.TestFrequencySec,
                    SuccessThreshold = this.GetSuccessThreshold(testConfiguration)
                };

                if (testConfiguration.ProtocolConfiguration is PSNetworkWatcherConnectionMonitorTcpConfiguration tcpConfiguration)
                {
                    cmTestConfiguration.Protocol = "Tcp";
                    cmTestConfiguration.TcpConfiguration = new ConnectionMonitorTcpConfiguration()
                    {
                        Port = tcpConfiguration.Port,
                        DisableTraceRoute = tcpConfiguration.DisableTraceRoute
                    };
                }
                else if (testConfiguration.ProtocolConfiguration is PSNetworkWatcherConnectionMonitorHttpConfiguration httpConfiguration)
                {
                    cmTestConfiguration.Protocol = "Http";
                    cmTestConfiguration.HttpConfiguration = new ConnectionMonitorHttpConfiguration()
                    {
                        Port = httpConfiguration.Port,
                        Method = httpConfiguration.Method,
                        Path = httpConfiguration.Path,
                        PreferHTTPS = httpConfiguration.PreferHTTPS,
                        ValidStatusCodeRanges = httpConfiguration.ValidStatusCodeRanges,
                        RequestHeaders = this.GetRequestHeaders(httpConfiguration)
                    };
                }
                else if (testConfiguration.ProtocolConfiguration is PSNetworkWatcherConnectionMonitorIcmpConfiguration icmpConfiguration)
                {
                    cmTestConfiguration.Protocol = "Icmp";
                    cmTestConfiguration.IcmpConfiguration = new ConnectionMonitorIcmpConfiguration()
                    {
                        DisableTraceRoute = icmpConfiguration.DisableTraceRoute
                    };
                }

                if (connectionMonitor.TestConfigurations.Count(x => x.Name == cmTestConfiguration.Name) == 0)
                {
                    connectionMonitor.TestConfigurations.Add(cmTestConfiguration);
                }

                cmTestGroup.TestConfigurations.Add(cmTestConfiguration.Name);
            }
        }

        private List<ConnectionMonitorOutput> GetOutputs(PSNetworkWatcherConnectionMonitorOutputObject[] outputs)
        {
            if (outputs == null)
            {
                return null;
            }

            var cmOutputs = new List<ConnectionMonitorOutput>();
            foreach (PSNetworkWatcherConnectionMonitorOutputObject output in outputs)
            {
                cmOutputs.Add(
                    new ConnectionMonitorOutput()
                        {
                            Type = output.Type,
                            WorkspaceSettings = new ConnectionMonitorWorkspaceSettings()
                            {
                                WorkspaceResourceId = output.WorkspaceSettings.WorkspaceResourceId
                            },
                        });
            }

            return cmOutputs;
        }

        private ConnectionMonitorSuccessThreshold GetSuccessThreshold(PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration)
        {
            if (testConfiguration.SuccessThreshold == null)
            {
                return null;
            }

            return new ConnectionMonitorSuccessThreshold()
            {
                ChecksFailedPercent = testConfiguration.SuccessThreshold.ChecksFailedPercent,
                RoundTripTimeMs = testConfiguration.SuccessThreshold.RoundTripTimeMs
            };
        }

        private void ValidatePort(int? port, bool throwIfNull = false)
        {
            if (throwIfNull && port == null)
            {
                throw new PSArgumentException(Properties.Resources.TCPProtocolConfigurationMustHavePort);
            }

            if (port != null && (port < 0 || port > 65535))
            {
                throw new PSArgumentException(Properties.Resources.InvalidPortValue);
            }
        }

        private void ValidateRequestHeaders(List<PSHTTPHeader> headers)
        {
            if (headers == null)
            {
                return;
            }

            foreach (PSHTTPHeader header in headers)
            {
                if (string.IsNullOrEmpty(header.Name) || string.IsNullOrEmpty(header.Value))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidHTTPRequestHeader);
                }
            }
        }

        private bool IsValidStatusCodeRanges(List<string> validStatusCodeRanges)
        {
            if (validStatusCodeRanges == null)
            {
                return true;
            }

            foreach (string statusCodeRange in validStatusCodeRanges)
            {
                var statusCodeParsed = statusCodeRange.Split('-');

                if (statusCodeParsed.Length > 2)
                {
                    return false;
                }

                string left = statusCodeParsed[0].ToString();
                if (statusCodeParsed.Length == 1)
                {
                    if (!int.TryParse(left, out int statusCode))
                    {
                        if (left.Length != 3)
                        {
                            return false;
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (!int.TryParse(left[i].ToString(), out int number) && left[i] != 'x')
                                {
                                    return false;
                                }

                                // We need to make special check for the first element in the code status
                                if (i == 0 && left[i] != 'x' && (number < 1 || number >= 6))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else if (statusCode < 100 || statusCode >= 600)
                    {
                        return false;
                    }
                }

                if (statusCodeParsed.Length == 2)
                {
                    if (!int.TryParse(left, out int statusCodeLeft))
                    {
                        return false;
                    }

                    if (!int.TryParse(statusCodeParsed[1].ToString(), out int statusCodeRight))
                    {
                        return false;
                    }

                    if (statusCodeLeft > statusCodeRight || statusCodeLeft < 100 || statusCodeRight >= 600)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ValidateEndpointType(PSNetworkWatcherConnectionMonitorEndpointObject endpoint)
        {
            if (string.IsNullOrEmpty(endpoint.Type))
            {
                throw new PSArgumentException(Properties.Resources.EmptyEndpointType, endpoint.Name);
            }

            if (!string.Equals(endpoint.Type, "AzureVM", StringComparison.OrdinalIgnoreCase) && !string.Equals(endpoint.Type, "AzureVNet", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(endpoint.Type, "AzureSubnet", StringComparison.OrdinalIgnoreCase) && !string.Equals(endpoint.Type, "MMAWorkspaceMachine", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(endpoint.Type, "MMAWorkspaceNetwork", StringComparison.OrdinalIgnoreCase) && !string.Equals(endpoint.Type, "ExternalAddress", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.InvalidEndpointType, endpoint.Name);
            }
        }

        private void ValidateEndpointResourceId(PSNetworkWatcherConnectionMonitorEndpointObject endpoint)
        {
            if (string.IsNullOrEmpty(endpoint.ResourceId))
            {
                return;
            }

            string[] splittedName = endpoint.ResourceId.Split('/');

            // Resource ID must be in the format "/subscriptions/00000000-0000-0000-0000-00000000/resourceGroups/MyResourceGroup/providers/Microsoft.Compute/virtualMachines/name"
            if (splittedName.Count() < 9)
            {
                throw new PSArgumentException(Properties.Resources.InvalidEndpointResourceId);
            }

            string resourceType = splittedName[7];
            if (string.IsNullOrEmpty(resourceType) || (!resourceType.Equals("virtualMachines", StringComparison.OrdinalIgnoreCase)
                && !resourceType.Equals("workspaces", StringComparison.OrdinalIgnoreCase)
                && !resourceType.Equals("virtualNetworks", StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.InvalidEndpointResourceType);
            }

            if (string.Equals(endpoint.Type, "AzureVM", StringComparison.OrdinalIgnoreCase))
            {
                if (!resourceType.Equals("virtualMachines", StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidEndpointResourceIdForSpecifiedType, endpoint.Type);
                }
            }
            else if (string.Equals(endpoint.Type, "AzureVNet", StringComparison.OrdinalIgnoreCase))
            {
                if (!resourceType.Equals("virtualNetworks", StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidEndpointResourceIdForSpecifiedType, endpoint.Type);
                }
            }
            else if (string.Equals(endpoint.Type, "AzureSubnet", StringComparison.OrdinalIgnoreCase))
            {
                if (!resourceType.Equals("virtualNetworks", StringComparison.OrdinalIgnoreCase) || splittedName.Count() != 11 
                    || splittedName[9].Equals("subnet", StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException(Properties.Resources.InvalidEndpointResourceIdForSpecifiedType, endpoint.Type);
                }
            }
            else if ((string.Equals(endpoint.Type, "MMAWorkspaceMachine", StringComparison.OrdinalIgnoreCase) || string.Equals(endpoint.Type, "MMAWorkspaceNetwork", StringComparison.OrdinalIgnoreCase)) 
                && !resourceType.Equals("workspaces", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.InvalidEndpointResourceIdForSpecifiedType, endpoint.Type);
            }
        }

        private PSNetworkWatcherConnectionMonitorProtocolConfiguration GetPSProtocolConfiguration(ConnectionMonitorTestConfiguration testConfiguration)
        {
            if (testConfiguration.TcpConfiguration != null)
            {
                return new PSNetworkWatcherConnectionMonitorTcpConfiguration()
                {
                    Port = testConfiguration.TcpConfiguration.Port,
                    DisableTraceRoute = testConfiguration.TcpConfiguration.DisableTraceRoute
                };
            }

            if (testConfiguration.HttpConfiguration != null)
            {
                return new PSNetworkWatcherConnectionMonitorHttpConfiguration()
                {
                    Port = testConfiguration.HttpConfiguration.Port,
                    Method = testConfiguration.HttpConfiguration.Method,
                    Path = testConfiguration.HttpConfiguration.Path,
                    PreferHTTPS = testConfiguration.HttpConfiguration.PreferHTTPS,
                    ValidStatusCodeRanges = testConfiguration.HttpConfiguration.ValidStatusCodeRanges?.ToList(),
                    RequestHeaders = this.GetPSRequestHeaders(testConfiguration.HttpConfiguration.RequestHeaders?.ToList())
                };
            }

            if (testConfiguration.IcmpConfiguration != null)
            {
                return new PSNetworkWatcherConnectionMonitorIcmpConfiguration()
                {
                    DisableTraceRoute = testConfiguration.IcmpConfiguration.DisableTraceRoute
                };
            }

            return null;
        }

        private List<PSHTTPHeader> GetPSRequestHeaders(List<HTTPHeader> headers)
        {
            if (headers == null)
            {
                return null;
            }

            List<PSHTTPHeader> psHeaders = new List<PSHTTPHeader>();
            foreach (HTTPHeader header in headers)
            {
                psHeaders.Add(
                    new PSHTTPHeader()
                    {
                        Name = header.Name,
                        Value = header.Value
                    });
            }

            return psHeaders;
        }

        private void AddSourceEndpointsToConnectionMonitorTestGroup(
            PSNetworkWatcherConnectionMonitorTestGroupObject testGroup,
            ConnectionMonitorTestGroup cmTestGroup,
            ConnectionMonitor connectionMonitor)
        {
            foreach (PSNetworkWatcherConnectionMonitorEndpointObject sourceEndpoint in testGroup.Sources)
            {
                ConnectionMonitorEndpoint cmSourceEndpoint = new ConnectionMonitorEndpoint()
                {
                    Name = sourceEndpoint.Name,
                    Type = sourceEndpoint.Type,
                    ResourceId = sourceEndpoint.ResourceId,
                    Address = sourceEndpoint.Address,
                    CoverageLevel = sourceEndpoint.CoverageLevel
                };

                // Add ConnectionMonitorEndpointScope
                if (sourceEndpoint.Scope != null)
                {
                    cmSourceEndpoint.Scope = new ConnectionMonitorEndpointScope();

                    if (sourceEndpoint.Scope.Include != null)
                    {
                        cmSourceEndpoint.Scope.Include = new List<ConnectionMonitorEndpointScopeItem>();
                        foreach (PSNetworkWatcherConnectionMonitorEndpointScopeItem item in sourceEndpoint.Scope.Include)
                        {
                            cmSourceEndpoint.Scope.Include.Add(
                                new ConnectionMonitorEndpointScopeItem()
                                {
                                    Address = item.Address
                                });
                        }
                    }

                    if (sourceEndpoint.Scope.Exclude != null)
                    {
                        cmSourceEndpoint.Scope.Exclude = new List<ConnectionMonitorEndpointScopeItem>();
                        foreach (PSNetworkWatcherConnectionMonitorEndpointScopeItem item in sourceEndpoint.Scope.Exclude)
                        {
                            cmSourceEndpoint.Scope.Exclude.Add(
                                new ConnectionMonitorEndpointScopeItem()
                                {
                                    Address = item.Address
                                });
                        }
                    }
                }

                if (connectionMonitor.Endpoints.Count(x => x.Name == sourceEndpoint.Name) == 0)
                {
                    connectionMonitor.Endpoints.Add(cmSourceEndpoint);
                }

                cmTestGroup.Sources.Add(sourceEndpoint.Name);
            }
        }

        private List<HTTPHeader> GetRequestHeaders(PSNetworkWatcherConnectionMonitorHttpConfiguration httpConfiguration)
        {
            if (httpConfiguration.RequestHeaders == null)
            {
                return null;
            }

            var requestHeaders = new List<HTTPHeader>();
            foreach (PSHTTPHeader header in httpConfiguration.RequestHeaders)
            {
                requestHeaders.Add(
                    new HTTPHeader()
                        {
                            Name = header.Name,
                            Value = header.Value
                        });
            }

            return requestHeaders;
        }

        private void AddDestinationEndpointsToConnectionMonitorTestGroup(
            PSNetworkWatcherConnectionMonitorTestGroupObject testGroup,
            ConnectionMonitorTestGroup cmTestGroup,
            ConnectionMonitor connectionMonitor)
        {
            foreach (PSNetworkWatcherConnectionMonitorEndpointObject destinationEndpoint in testGroup.Destinations)
            {
                ConnectionMonitorEndpoint cmDestinationEndpoint = new ConnectionMonitorEndpoint()
                {
                    Name = destinationEndpoint.Name,
                    Type = destinationEndpoint.Type,
                    ResourceId = destinationEndpoint.ResourceId,
                    Address = destinationEndpoint.Address,
                    CoverageLevel = destinationEndpoint.CoverageLevel
                };

                // Add ConnectionMonitorEndpointScope
                if (destinationEndpoint.Scope != null)
                {
                    cmDestinationEndpoint.Scope = new ConnectionMonitorEndpointScope();

                    if (destinationEndpoint.Scope.Include != null)
                    {
                        cmDestinationEndpoint.Scope.Include = new List<ConnectionMonitorEndpointScopeItem>();
                        foreach (PSNetworkWatcherConnectionMonitorEndpointScopeItem item in destinationEndpoint.Scope.Include)
                        {
                            cmDestinationEndpoint.Scope.Include.Add(
                                new ConnectionMonitorEndpointScopeItem()
                                {
                                    Address = item.Address
                                });
                        }
                    }

                    if (destinationEndpoint.Scope.Exclude != null)
                    {
                        cmDestinationEndpoint.Scope.Exclude = new List<ConnectionMonitorEndpointScopeItem>();
                        foreach (PSNetworkWatcherConnectionMonitorEndpointScopeItem item in destinationEndpoint.Scope.Exclude)
                        {
                            cmDestinationEndpoint.Scope.Exclude.Add(
                                new ConnectionMonitorEndpointScopeItem()
                                {
                                    Address = item.Address
                                });
                        }
                    }
                }

                if (connectionMonitor.Endpoints.Count(x => x.Name == destinationEndpoint.Name) == 0)
                {
                    connectionMonitor.Endpoints.Add(cmDestinationEndpoint);
                }

                cmTestGroup.Destinations.Add(cmDestinationEndpoint.Name);
            }
        }

        private void ValidateTestFrequency(int? testFrequencySec)
        {
            if (testFrequencySec == null)
            {
                return;
            }

            int maxTestFrequencySeconds = 1800;
            int minTestFrequencySeconds = 30;
            if (testFrequencySec > maxTestFrequencySeconds || testFrequencySec < minTestFrequencySeconds)
            {
                throw new PSArgumentException(Properties.Resources.TestFrequencyIsOutOfRange);
            }
        }

        private void ValidateSucessThreshold(PSNetworkWatcherConnectionMonitorSuccessThreshold successThreshold)
        {
            if (successThreshold == null)
            {
                return;
            }

            if (successThreshold.ChecksFailedPercent != null &&
                (successThreshold.ChecksFailedPercent < 0 || successThreshold.ChecksFailedPercent > 100))
            {
                throw new PSArgumentException(Properties.Resources.ChecksFailedPercentIsOutOfRange);
            }

            if (successThreshold.RoundTripTimeMs != null && successThreshold.RoundTripTimeMs < 0)
            {
                throw new PSArgumentException(Properties.Resources.InvalidRoundtripTimeMs);
            }
        }

        private void ValidatePreferredIPVersion(string preferredIPVersion)
        {
            if (!string.IsNullOrEmpty(preferredIPVersion) && !preferredIPVersion.Equals(NetworkBaseCmdlet.IPv4, StringComparison.OrdinalIgnoreCase)
                && !preferredIPVersion.Equals(NetworkBaseCmdlet.IPv6, StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.InvalidPreferredIPVersion);
            }
        }
    }
}