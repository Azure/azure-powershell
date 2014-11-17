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


namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Gateway.Model;
    using NetworkSecurityGroup.Model;
    using Routes.Model;
    using WindowsAzure;
    using WindowsAzure.Commands.Common;
    using WindowsAzure.Commands.Common.Models;
    using WindowsAzure.Commands.Common.Storage;
    using WindowsAzure.Commands.Utilities.Common;
    using WindowsAzure.Common;
    using WindowsAzure.Management;
    using WindowsAzure.Management.Network;
    using WindowsAzure.Management.Network.Models;
    using WindowsAzure.Storage.Auth;

    public class NetworkClient
    {
        private readonly NetworkManagementClient client;
        private readonly ManagementClient managementClient;
        private readonly ICommandRuntime commandRuntime;

        public NetworkClient(AzureSubscription subscription, ICommandRuntime commandRuntime)
            : this(CreateClient<NetworkManagementClient>(subscription),
                   CreateClient<ManagementClient>(subscription),
                   commandRuntime)
        {   
        }
        public NetworkClient(NetworkManagementClient client, ManagementClient managementClient, ICommandRuntime commandRuntime)
        {
            this.client = client;
            this.managementClient = managementClient;
            this.commandRuntime = commandRuntime;
        }

        public VirtualNetworkGatewayContext GetGateway(string vnetName)
        {
            if (string.IsNullOrWhiteSpace(vnetName))
            {
                throw new ArgumentException("vnetName cannot be null or whitespace.", "vnetName");
            }

            GatewayGetResponse response = client.Gateways.Get(vnetName);
            
            VirtualNetworkGatewayContext gatewayContext = new VirtualNetworkGatewayContext()
            {
                LastEventData = (response.LastEvent != null) ? response.LastEvent.Data : null,
                LastEventMessage = (response.LastEvent != null) ? response.LastEvent.Message : null,
                LastEventID = GetEventId(response.LastEvent),
                LastEventTimeStamp = (response.LastEvent != null) ? (DateTime?)response.LastEvent.Timestamp : null,
                State = (ProvisioningState)Enum.Parse(typeof(ProvisioningState), response.State, true),
                VIPAddress = response.VipAddress,
                DefaultSite = (response.DefaultSite != null ? response.DefaultSite.Name : null),
                GatewaySKU = response.GatewaySKU,
            };
            PopulateOperationContext(response.RequestId, gatewayContext);

            return gatewayContext;
        }

        public IEnumerable<GatewayConnectionContext> ListConnections(string vnetName)
        {
            GatewayListConnectionsResponse response = client.Gateways.ListConnections(vnetName);
            
            IEnumerable<GatewayConnectionContext> connections = response.Connections.Select(
                (GatewayListConnectionsResponse.GatewayConnection connection) =>
                {
                    return new GatewayConnectionContext()
                    {
                        ConnectivityState         = connection.ConnectivityState.ToString(),
                        EgressBytesTransferred    = (ulong)connection.EgressBytesTransferred,
                        IngressBytesTransferred   = (ulong)connection.IngressBytesTransferred,
                        LastConnectionEstablished = connection.LastConnectionEstablished.ToString(),
                        LastEventID               = connection.LastEvent != null ? connection.LastEvent.Id : null,
                        LastEventMessage          = connection.LastEvent != null ? connection.LastEvent.Message : null,
                        LastEventTimeStamp        = connection.LastEvent != null ? connection.LastEvent.Timestamp.ToString() : null,
                        LocalNetworkSiteName      = connection.LocalNetworkSiteName
                    };
                });
            PopulateOperationContext(response.RequestId, connections);

            return connections;
        }

        public VirtualNetworkDiagnosticsContext GetDiagnostics(string vnetName)
        {
            GatewayDiagnosticsStatus diagnosticsStatus = client.Gateways.GetDiagnostics(vnetName);
            
            VirtualNetworkDiagnosticsContext diagnosticsContext = new VirtualNetworkDiagnosticsContext()
            {
                DiagnosticsUrl = diagnosticsStatus.DiagnosticsUrl,
                State = diagnosticsStatus.State,
            };
            PopulateOperationContext(diagnosticsStatus.RequestId, diagnosticsContext);

            return diagnosticsContext;
        }

        public SharedKeyContext GetSharedKey(string vnetName, string localNetworkSiteName)
        {
            GatewayGetSharedKeyResponse response = client.Gateways.GetSharedKey(vnetName, localNetworkSiteName);
            
            SharedKeyContext sharedKeyContext = new SharedKeyContext()
            {
                Value = response.SharedKey
            };
            PopulateOperationContext(response.RequestId, sharedKeyContext);

            return sharedKeyContext;
        }

        public GatewayGetOperationStatusResponse SetSharedKey(string vnetName, string localNetworkSiteName, string sharedKey)
        {
            GatewaySetSharedKeyParameters sharedKeyParameters = new GatewaySetSharedKeyParameters()
            {
                Value = sharedKey,
            };

            return client.Gateways.SetSharedKey(vnetName, localNetworkSiteName, sharedKeyParameters);
        }

        public GatewayGetOperationStatusResponse CreateGateway(string vnetName, GatewayType gatewayType, GatewaySKU gatewaySKU)
        {
            GatewayCreateParameters parameters = new GatewayCreateParameters()
            {
                GatewayType = gatewayType,
                GatewaySKU = gatewaySKU,
            };

            return client.Gateways.Create(vnetName, parameters);
        }

        public GatewayGetOperationStatusResponse DeleteGateway(string vnetName)
        {
            return client.Gateways.Delete(vnetName);
        }

        public GatewayGetOperationStatusResponse ResizeGateway(string vnetName, GatewaySKU gatewaySKU)
        {
            ResizeGatewayParameters parameters = new ResizeGatewayParameters()
            {
                GatewaySKU = gatewaySKU,
            };
            return client.Gateways.Resize(vnetName, parameters);
        }

        public GatewayGetOperationStatusResponse ConnectDisconnectOrTest(string vnetName, string localNetworkSiteName, bool isConnect)
        {
            GatewayConnectDisconnectOrTestParameters connParams = new GatewayConnectDisconnectOrTestParameters()
            {
                Operation = isConnect ? GatewayConnectionUpdateOperation.Connect : GatewayConnectionUpdateOperation.Disconnect
            };

            return client.Gateways.ConnectDisconnectOrTest(vnetName, localNetworkSiteName, connParams);
        }

        public GatewayGetOperationStatusResponse StartDiagnostics(string vnetName, int captureDurationInSeconds, string containerName, AzureStorageContext storageContext)
        {
            StorageCredentials credentials = storageContext.StorageAccount.Credentials;
            string customerStorageKey = credentials.ExportBase64EncodedKey();
            string customerStorageName = credentials.AccountName;
            return StartDiagnostics(vnetName, captureDurationInSeconds, containerName, customerStorageKey, customerStorageName);
        }
        public GatewayGetOperationStatusResponse StartDiagnostics(string vnetName, int captureDurationInSeconds, string containerName, string customerStorageKey, string customerStorageName)
        {
            UpdateGatewayPublicDiagnostics parameters = new UpdateGatewayPublicDiagnostics()
            {
                CaptureDurationInSeconds = captureDurationInSeconds.ToString(),
                ContainerName = containerName,
                CustomerStorageKey = customerStorageKey,
                CustomerStorageName = customerStorageName,
                Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
            };

            return client.Gateways.UpdateDiagnostics(vnetName, parameters);
        }

        public GatewayGetOperationStatusResponse StopDiagnostics(string vnetName)
        {
            UpdateGatewayPublicDiagnostics parameters = new UpdateGatewayPublicDiagnostics()
            {
                Operation = UpdateGatewayPublicDiagnosticsOperation.StopDiagnostics,
            };

            return client.Gateways.UpdateDiagnostics(vnetName, parameters);
        }

        public GatewayGetOperationStatusResponse SetDefaultSite(string vnetName, string defaultSiteName)
        {
            GatewaySetDefaultSiteListParameters parameters = new GatewaySetDefaultSiteListParameters()
            {
                DefaultSite = defaultSiteName,
            };
            
            return client.Gateways.SetDefaultSites(vnetName, parameters);
        }

        public GatewayGetOperationStatusResponse RemoveDefaultSite(string vnetName)
        {
            return client.Gateways.RemoveDefaultSites(vnetName);
        }

        public RouteTable GetRouteTable(string routeTableName, string detailLevel)
        {
            RouteTable result;
            if (string.IsNullOrEmpty(detailLevel))
            {
                result = client.Routes.GetRouteTable(routeTableName).RouteTable;
            }
            else
            {
                result = client.Routes.GetRouteTableWithDetails(routeTableName, detailLevel).RouteTable;
            }
            return result;
        }

        public IEnumerable<RouteTable> ListRouteTables()
        {
            return client.Routes.ListRouteTables().RouteTables;
        }

        public OperationResponse CreateRouteTable(string routeTableName, string label, string location)
        {
            CreateRouteTableParameters parameters = new CreateRouteTableParameters()
            {
                Name = routeTableName,
                Label = label,
                Location = location,
            };

            return client.Routes.CreateRouteTable(parameters);
        }

        public OperationResponse DeleteRouteTable(string routeTableName)
        {
            return client.Routes.DeleteRouteTable(routeTableName);
        }

        public OperationResponse SetRoute(string routeTableName, string routeName, string addressPrefix, string nextHopType)
        {
            NextHop nextHop = new NextHop()
            {
                Type = nextHopType,
            };
            SetRouteParameters parameters = new SetRouteParameters()
            {
                Name = routeName,
                AddressPrefix = addressPrefix,
                NextHop = nextHop,
            };

            return client.Routes.SetRoute(routeTableName, routeName, parameters);
        }

        public OperationResponse DeleteRoute(string routeTableName, string routeName)
        {
            return client.Routes.DeleteRoute(routeTableName, routeName);
        }

        public SubnetRouteTableContext GetRouteTableForSubnet(string vnetName, string subnetName)
        {
            GetRouteTableForSubnetResponse response = client.Routes.GetRouteTableForSubnet(vnetName, subnetName);
            SubnetRouteTableContext context = new SubnetRouteTableContext()
            {
                RouteTableName = response.RouteTableName,
            };

            return context;
        }

        public OperationResponse AddRouteTableToSubnet(string vnetName, string subnetName, string routeTableName)
        {
            AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
            {
                RouteTableName = routeTableName,
            };

            return client.Routes.AddRouteTableToSubnet(vnetName, subnetName, parameters);
        }

        public OperationResponse RemoveRouteTableFromSubnet(string vnetName, string subnetName)
        {
            return client.Routes.RemoveRouteTableFromSubnet(vnetName, subnetName);
        }

        private int GetEventId(GatewayEvent gatewayEvent)
        {
            int val = -1;
            if (gatewayEvent != null)
            {
                int.TryParse(gatewayEvent.Id, out val);
            }

            return val;
        }

        private void PopulateOperationContext(string requestId, ManagementOperationContext operationContext)
        {
            OperationStatusResponse operationStatus = managementClient.GetOperationStatus(requestId);
            PopulateOperationContext(operationStatus, operationContext);
        }
        private void PopulateOperationContext(string requestId, IEnumerable<ManagementOperationContext> operationContexts)
        {
            OperationStatusResponse operationStatus = managementClient.GetOperationStatus(requestId);
            foreach (ManagementOperationContext operationContext in operationContexts)
            {
                PopulateOperationContext(operationStatus, operationContext);
            }
        }
        private void PopulateOperationContext(OperationStatusResponse operationStatus, ManagementOperationContext operationContext)
        {
            operationContext.OperationId = operationStatus.Id;
            operationContext.OperationStatus = operationStatus.Status.ToString();
            operationContext.OperationDescription = commandRuntime.ToString();
        }

        private static ClientType CreateClient<ClientType>(AzureSubscription subscription) where ClientType : ServiceClient<ClientType>
        {
            return AzureSession.ClientFactory.CreateClient<ClientType>(subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public void CreateNetworkSecurityGroup(string name, string location, string label)
        {
            NetworkSecurityGroupCreateParameters parameters = new NetworkSecurityGroupCreateParameters()
            {
                Location = location,
                Name = name,
                Label = label
            };

            client.NetworkSecurityGroups.Create(parameters);
        }

        public INetworkSecurityGroup GetNetworkSecurityGroup(string name, bool details)
        {
            var getResponse = client.NetworkSecurityGroups.Get(name, details ? "Full" : null);
            return details ? new NetworkSecurityGroupWithRules(getResponse) : new SimpleNetworkSecurityGroup(getResponse);
        }

        public IEnumerable<INetworkSecurityGroup> ListNetworkSecurityGroups(bool details)
        {
            var networkSecurityGroupList = client.NetworkSecurityGroups.List();
            IEnumerable<INetworkSecurityGroup> result;

            if (details)
            {
                // to get the rules, need to specifically call Get for each group
                result = networkSecurityGroupList.Select(nsg => GetNetworkSecurityGroup(nsg.Name, true));
            }

            else
            {
                result = networkSecurityGroupList.Select(nsg => new SimpleNetworkSecurityGroup(nsg.Name, nsg.Location, nsg.Label));
            }

            return result;
        }

        public void SetNetworkSecurityRule(
            string networkSecurityGroupName,
            string ruleName,
            string type,
            int priority,
            string action,
            string sourceAddressPrefix,
            string sourcePortRange,
            string destinationAddressPrefix,
            string destinationPortRange,
            string protocol)
        {
            var setSecurityRuleParameters = new NetworkSecuritySetRuleParameters()
            {
                Type = type,
                Priority = priority,
                Action = action,
                SourceAddressPrefix = sourceAddressPrefix,
                SourcePortRange = sourcePortRange,
                DestinationAddressPrefix = destinationAddressPrefix,
                DestinationPortRange = destinationPortRange,
                Protocol = protocol
            };

            client.NetworkSecurityGroups.SetRule(networkSecurityGroupName, ruleName, setSecurityRuleParameters);
        }

        public void RemoveNetworkSecurityGroup(string name)
        {
            client.NetworkSecurityGroups.Delete(name);
        }

        public void RemoveNetworkSecurityRule(string securityGroupName, string securityRuleName)
        {
            client.NetworkSecurityGroups.DeleteRule(securityGroupName, securityRuleName);
        }

        public NetworkSecurityGroupGetForSubnetResponse GetNetworkSecurityGroupForSubnet(string virtualNetworkName, string subnetName)
        {
            return client.NetworkSecurityGroups.GetForSubnet(virtualNetworkName, subnetName);
        }

        public void RemoveNetworkSecurityGroupFromSubnet(string networkSecurityGroupName, string virtualNetworkName, string subnetName)
        {
            client.NetworkSecurityGroups.RemoveFromSubnet(virtualNetworkName, subnetName, networkSecurityGroupName);
        }

        public void SetNetworkSecurityGroupForSubnet(string networkSecurityGroupName, string subnetName, string virtualNetworkName)
        {
            var parameters = new NetworkSecurityGroupAddToSubnetParameters()
            {
                Name = networkSecurityGroupName
            };

            client.NetworkSecurityGroups.AddToSubnet(virtualNetworkName, subnetName, parameters);
        }
    }
}
