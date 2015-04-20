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
    using Gateway.Model;
    using Hyak.Common;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
    using Microsoft.WindowsAzure.Management.Compute;
    using NetworkSecurityGroup.Model;
    using Routes.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;
    using WindowsAzure.Commands.Common.Storage;
    using WindowsAzure.Commands.Utilities.Common;
    using WindowsAzure.Management;
    using WindowsAzure.Management.Network;
    using WindowsAzure.Management.Network.Models;
    using WindowsAzure.Storage.Auth;
    using ComputeModels = Microsoft.WindowsAzure.Management.Compute.Models;
    using PowerShellAppGwModel = ApplicationGateway.Model;

    public class NetworkClient
    {
        private readonly INetworkManagementClient client;
        private readonly IComputeManagementClient computeClient;
        private readonly IManagementClient managementClient;
        private readonly ICommandRuntime commandRuntime;

        public NetworkClient(AzureProfile profile, AzureSubscription subscription, ICommandRuntime commandRuntime)
            : this(CreateClient<NetworkManagementClient>(profile, subscription),
                   CreateClient<ComputeManagementClient>(profile, subscription),
                   CreateClient<ManagementClient>(profile, subscription),
                   commandRuntime)
        {   
        }
        public NetworkClient(INetworkManagementClient client, IComputeManagementClient computeClient, IManagementClient managementClient, ICommandRuntime commandRuntime)
        {
            this.client = client;
            this.computeClient = computeClient;
            this.managementClient = managementClient;
            this.commandRuntime = commandRuntime;
        }

        public PowerShellAppGwModel.ApplicationGateway GetApplicationGateway(string gatewayName)
        {
            ApplicationGatewayGetResponse parameters = client.ApplicationGateways.Get(gatewayName);

            PowerShellAppGwModel.SubnetCollection subnets = new PowerShellAppGwModel.SubnetCollection();
            foreach (string subnet in parameters.Subnets)
            {
                subnets.Add(subnet);
            }

            PowerShellAppGwModel.VirtualIpCollection VirtualIPs = new PowerShellAppGwModel.VirtualIpCollection();
            foreach (string vip in parameters.VirtualIPs)
            {
                VirtualIPs.Add(vip);
            }

            return (new ApplicationGateway.Model.ApplicationGateway
            {
                Name = parameters.Name,
                Description = parameters.Description,
                GatewaySize = parameters.GatewaySize,
                InstanceCount = parameters.InstanceCount,
                VnetName = parameters.VnetName,
                Subnets = subnets,
                State = parameters.State,
                VirtualIPs = VirtualIPs,
                DnsName = parameters.DnsName
            });
        }

        public IEnumerable<PowerShellAppGwModel.ApplicationGateway> ListApplicationGateway()
        {
            ApplicationGatewayListResponse gatewayList = client.ApplicationGateways.List();

            List<ApplicationGateway.Model.ApplicationGateway> psGatewayList = new List<ApplicationGateway.Model.ApplicationGateway>();
            foreach (ApplicationGatewayGetResponse gateway in gatewayList.ApplicationGateways)
            {
                PowerShellAppGwModel.SubnetCollection subnets = new PowerShellAppGwModel.SubnetCollection();
                foreach (string subnet in gateway.Subnets)
                {
                    subnets.Add(subnet);
                }

                PowerShellAppGwModel.VirtualIpCollection VirtualIPs = new PowerShellAppGwModel.VirtualIpCollection();
                foreach (string vip in gateway.VirtualIPs)
                {
                    VirtualIPs.Add(vip);
                }

                psGatewayList.Add(new PowerShellAppGwModel.ApplicationGateway
                {
                    Name = gateway.Name,
                    Description = gateway.Description,
                    GatewaySize = gateway.GatewaySize,
                    InstanceCount = gateway.InstanceCount,
                    VnetName = gateway.VnetName,
                    Subnets = subnets,
                    State = gateway.State,
                    VirtualIPs = VirtualIPs,
                    DnsName = gateway.DnsName
                });
            }
            return psGatewayList;
        }

        public ApplicationGatewayOperationResponse CreateApplicationGateway(string name, string vnetName, List<string> subnets, string description, uint instanceCount, string gatewaySize)
        {
            return client.ApplicationGateways.Create(new CreateApplicationGatewayParameters
            {
                Name = name,
                VnetName = vnetName,
                Subnets = subnets,
                Description = description,
                InstanceCount = instanceCount,
                GatewaySize = gatewaySize
            });
        }
        public ApplicationGatewayOperationResponse UpdateApplicationGateway(string name, string vnetName, List<string> subnets, string description, uint instanceCount, string gatewaySize)
        {
            return client.ApplicationGateways.Update(name,
                new UpdateApplicationGatewayParameters
                {
                    Description = description,
                    GatewaySize = gatewaySize,
                    InstanceCount = instanceCount,
                    Subnets = (((subnets == null) || subnets.Count == 0) ? null : new List<string>(subnets)),
                    VnetName = vnetName
                });
        }
        public ApplicationGatewayOperationResponse RemoveApplicationGateway(string gatewayName)
        {
            return client.ApplicationGateways.Delete(gatewayName);
        }

        public ApplicationGatewayOperationResponse SetApplicationGatewayConfig(string gatewayName, PowerShellAppGwModel.ApplicationGatewayConfiguration config)
        {
            return client.ApplicationGateways.SetConfig(gatewayName, HydraConfigFromPowerShellConfig(config));
        }

        public PowerShellAppGwModel.ApplicationGatewayConfigContext GetApplicationGatewayConfig(string gatewayName)
        {
            ApplicationGatewayGetConfiguration hydraConfig = client.ApplicationGateways.GetConfig(gatewayName);
            PowerShellAppGwModel.ApplicationGatewayConfiguration psConfig = PowerShellConfigFromHydraConfig(hydraConfig);

            return (new PowerShellAppGwModel.ApplicationGatewayConfigContext
            {
                OperationDescription = "Get-ApplicationGatewayConfig",
                OperationId = hydraConfig.RequestId,
                OperationStatus = hydraConfig.StatusCode.ToString(),
                Config = psConfig,
                XMLConfiguration = PowerShellAppGwModel.ApplicationGatewayConfiguration.Print(psConfig)
            });
        }

        public ApplicationGatewayOperationResponse ExecuteApplicationGatewayOperation(string gatewayName, string opName)
        {
            ApplicationGatewayOperation op = new ApplicationGatewayOperation();
            op.OperationType = opName;

            return client.ApplicationGateways.ExecuteOperation(gatewayName, op);
        }

        public ApplicationGatewayOperationResponse AddApplicationGatewayCertificate(string gatewayName, string certificateName, string password, string certificateFile)
        {
            X509Certificate2 cert = new X509Certificate2(certificateFile, password, X509KeyStorageFlags.Exportable);

            ApplicationGatewayCertificate appGwCert = new ApplicationGatewayCertificate()
            {
                Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password)),
                //CertificateFormat = "pfx",
                Password = password
            };

            return client.ApplicationGateways.AddCertificate(gatewayName, certificateName, appGwCert);
        }

        public PowerShellAppGwModel.ApplicationGatewayCertificate GetApplicationGatewayCertificate(string gatewayName, string certificateName)
        {
            ApplicationGatewayGetCertificate certificate = client.ApplicationGateways.GetCertificate(gatewayName, certificateName);
            X509Certificate2 certObject = new X509Certificate2(Convert.FromBase64String(certificate.Data));
            return (new PowerShellAppGwModel.ApplicationGatewayCertificate
            {
                Name = certificate.Name,
                SubjectName = certObject.SubjectName.Name,
                Thumbprint = certObject.Thumbprint,
                ThumbprintAlgo = certObject.SignatureAlgorithm.FriendlyName,
                State = certificate.State
            });
        }

        public List<PowerShellAppGwModel.ApplicationGatewayCertificate> ListApplicationGatewayCertificate(string gatewayName)
        {
            ApplicationGatewayListCertificate hydraCertList = client.ApplicationGateways.ListCertificate(gatewayName);

            List<PowerShellAppGwModel.ApplicationGatewayCertificate> psCertList = new List<PowerShellAppGwModel.ApplicationGatewayCertificate>();
            foreach (ApplicationGatewayGetCertificate certificate in hydraCertList.ApplicationGatewayCertificates)
            {
                X509Certificate2 certObject = new X509Certificate2(Convert.FromBase64String(certificate.Data));
                psCertList.Add(new PowerShellAppGwModel.ApplicationGatewayCertificate
                {
                    Name = certificate.Name,
                    SubjectName = certObject.SubjectName.Name,
                    Thumbprint = certObject.Thumbprint,
                    ThumbprintAlgo = certObject.SignatureAlgorithm.FriendlyName,
                    State = certificate.State
                });
            }
            return psCertList;
        }

        public ApplicationGatewayOperationResponse RemoveApplicationGatewayCertificate(string gatewayName, string certificateName)
        {
            return client.ApplicationGateways.DeleteCertificate(gatewayName, certificateName);
        }

        private ApplicationGatewaySetConfiguration HydraConfigFromPowerShellConfig(PowerShellAppGwModel.ApplicationGatewayConfiguration config)
        {
            ApplicationGatewaySetConfiguration outConfig = new ApplicationGatewaySetConfiguration();

            //Frontend IPs
            outConfig.FrontendIPConfigurations = new List<FrontendIPConfiguration>();

            //Config without Frontend IPs is also valid
            if (null != config.FrontendIPConfigurations)
            {                
                foreach (PowerShellAppGwModel.FrontendIPConfiguration fip in config.FrontendIPConfigurations)
                {
                    outConfig.FrontendIPConfigurations.Add(new FrontendIPConfiguration
                    {
                        Name = fip.Name,
                        Type = fip.Type,
                        StaticIPAddress = fip.StaticIPAddress
                    });
                }
            }

            //Frontend Port
            outConfig.FrontendPorts = new List<FrontendPort>();
            foreach (PowerShellAppGwModel.FrontendPort fp in config.FrontendPorts)
            {
                outConfig.FrontendPorts.Add(new FrontendPort
                {
                    Name = fp.Name,
                    Port = fp.Port
                });
            }

            //Backend Address Pools 
            outConfig.BackendAddressPools = new List<BackendAddressPool>();
            foreach (PowerShellAppGwModel.BackendAddressPool pool in config.BackendAddressPools)
            {
                List<BackendServer> servers = new List<BackendServer>();
                foreach (string server in pool.BackendServers)
                {
                    servers.Add(new BackendServer
                    {
                        IPAddress = server
                    });
                }

                outConfig.BackendAddressPools.Add(new BackendAddressPool
                {
                    Name = pool.Name,
                    BackendServers = servers
                });
            }

            //Backend Http Settings List 
            outConfig.BackendHttpSettingsList = new List<BackendHttpSettings>();
            foreach (PowerShellAppGwModel.BackendHttpSettings setting in config.BackendHttpSettingsList)
            {
                outConfig.BackendHttpSettingsList.Add(new BackendHttpSettings
                {
                    Name = setting.Name,
                    Port = setting.Port,
                    Protocol = (Protocol)setting.Protocol,
                    CookieBasedAffinity = setting.CookieBasedAffinity
                });
            }

            //Http Listeners 
            outConfig.HttpListeners = new List<AGHttpListener>();
            foreach (PowerShellAppGwModel.HttpListener listener in config.HttpListeners)
            {
                outConfig.HttpListeners.Add(new AGHttpListener
                {
                    Name = listener.Name,
                    FrontendIP = listener.FrontendIP,
                    FrontendPort = listener.FrontendPort,
                    Protocol = (Protocol)listener.Protocol,
                    SslCert = listener.SslCert
                });
            }

            //Http Load Balancing Rules 
            outConfig.HttpLoadBalancingRules = new List<HttpLoadBalancingRule>();
            foreach (PowerShellAppGwModel.HttpLoadBalancingRule rule in config.HttpLoadBalancingRules)
            {
                outConfig.HttpLoadBalancingRules.Add(new HttpLoadBalancingRule
                {
                    Name = rule.Name,
                    Type = rule.Type,
                    BackendHttpSettings = rule.BackendHttpSettings,
                    Listener = rule.Listener,
                    BackendAddressPool = rule.BackendAddressPool
                });
            }

            return outConfig;
        }

        private PowerShellAppGwModel.ApplicationGatewayConfiguration PowerShellConfigFromHydraConfig(ApplicationGatewayGetConfiguration config)
        {
            PowerShellAppGwModel.ApplicationGatewayConfiguration outConfig = new PowerShellAppGwModel.ApplicationGatewayConfiguration();

            //Frontend IPs
            List<PowerShellAppGwModel.FrontendIPConfiguration> fips = new List<PowerShellAppGwModel.FrontendIPConfiguration>();

            //Config without Frontend IPs is also valid
            if (null != config.FrontendIPConfigurations)
            {
                
                foreach (FrontendIPConfiguration fip in config.FrontendIPConfigurations)
                {

                    fips.Add(new PowerShellAppGwModel.FrontendIPConfiguration
                    {
                        Name = fip.Name,
                        Type = fip.Type,
                        StaticIPAddress = fip.StaticIPAddress
                    });
                }
            }

            //Frontend Port            
            List<PowerShellAppGwModel.FrontendPort> fps = new List<PowerShellAppGwModel.FrontendPort>();
            foreach (FrontendPort fp in config.FrontendPorts)
            {

                fps.Add(new PowerShellAppGwModel.FrontendPort
                {
                    Name = fp.Name,
                    Port = fp.Port
                });
            }

            //Backend Address Pools 
            List<PowerShellAppGwModel.BackendAddressPool> pools = new List<PowerShellAppGwModel.BackendAddressPool>();
            foreach (BackendAddressPool pool in config.BackendAddressPools)
            {
                PowerShellAppGwModel.BackendServerCollection servers = new PowerShellAppGwModel.BackendServerCollection();
                foreach (BackendServer server in pool.BackendServers)
                {
                    servers.Add(server.IPAddress);
                }

                pools.Add(new PowerShellAppGwModel.BackendAddressPool
                {
                    Name = pool.Name,
                    BackendServers = servers
                });
            }

            //Backend Http Settings List 
            List<PowerShellAppGwModel.BackendHttpSettings> settings = new List<PowerShellAppGwModel.BackendHttpSettings>();
            foreach (BackendHttpSettings setting in config.BackendHttpSettingsList)
            {
                settings.Add(new PowerShellAppGwModel.BackendHttpSettings
                {
                    Name = setting.Name,
                    Port = setting.Port,
                    Protocol = (PowerShellAppGwModel.Protocol)setting.Protocol,
                    CookieBasedAffinity = setting.CookieBasedAffinity
                });
            }

            //Http Listeners 
            List<PowerShellAppGwModel.HttpListener> listeners = new List<PowerShellAppGwModel.HttpListener>();
            foreach (AGHttpListener listener in config.HttpListeners)
            {
                listeners.Add(new PowerShellAppGwModel.HttpListener
                {
                    Name = listener.Name,
                    FrontendIP = listener.FrontendIP,
                    FrontendPort = listener.FrontendPort,
                    Protocol = (PowerShellAppGwModel.Protocol)listener.Protocol,
                    SslCert = listener.SslCert
                });
            }

            //Http Load Balancing Rules 
            List<PowerShellAppGwModel.HttpLoadBalancingRule> rules = new List<PowerShellAppGwModel.HttpLoadBalancingRule>();
            foreach (HttpLoadBalancingRule rule in config.HttpLoadBalancingRules)
            {
                rules.Add(new PowerShellAppGwModel.HttpLoadBalancingRule
                {
                    Name = rule.Name,
                    Type = rule.Type,
                    BackendHttpSettings = rule.BackendHttpSettings,
                    Listener = rule.Listener,
                    BackendAddressPool = rule.BackendAddressPool
                });
            }

            outConfig.FrontendIPConfigurations = fips;
            outConfig.FrontendPorts = fps;
            outConfig.BackendAddressPools = pools;
            outConfig.BackendHttpSettingsList = settings;
            outConfig.HttpListeners = listeners;
            outConfig.HttpLoadBalancingRules = rules;

            return outConfig;
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

        public GatewayGetOperationStatusResponse CreateGateway(string vnetName, string gatewayType, string gatewaySKU)
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

        public GatewayGetOperationStatusResponse ResetGateway(string vnetName)
        {
            ResetGatewayParameters parameters = new ResetGatewayParameters();
            return client.Gateways.Reset(vnetName, parameters);
        }

        public GatewayGetOperationStatusResponse ResizeGateway(string vnetName, string gatewaySKU)
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
            StartGatewayPublicDiagnosticsParameters parameters = new StartGatewayPublicDiagnosticsParameters()
            {
                CaptureDurationInSeconds = captureDurationInSeconds.ToString(),
                ContainerName = containerName,
                CustomerStorageKey = customerStorageKey,
                CustomerStorageName = customerStorageName,
                Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
            };

            return client.Gateways.StartDiagnostics(vnetName, parameters);
        }

        public GatewayOperationResponse StopDiagnostics(string vnetName)
        {
            StopGatewayPublicDiagnosticsParameters parameters = new StopGatewayPublicDiagnosticsParameters()
            {
                Operation = UpdateGatewayPublicDiagnosticsOperation.StopDiagnostics,
            };

            return client.Gateways.StopDiagnostics(vnetName, parameters);
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

        public GatewayGetOperationStatusResponse SetIPsecParameters(string vnetName, string localNetworkName, string encryptionType, string pfsGroup, int saDataSizeKilobytes, int saLifetimeSeconds)
        {
            GatewaySetIPsecParametersParameters parameters = new GatewaySetIPsecParametersParameters()
            {
                Parameters = new IPsecParameters()
                {
                    EncryptionType = encryptionType,
                    PfsGroup = pfsGroup,
                    SADataSizeKilobytes = saDataSizeKilobytes,
                    SALifeTimeSeconds = saLifetimeSeconds,
                },
            };

            return client.Gateways.SetIPsecParameters(vnetName, localNetworkName, parameters);
        }

        public IPsecParameters GetIPsecParameters(string vnetName, string localNetworkName)
        {
            return client.Gateways.GetIPsecParameters(vnetName, localNetworkName).IPsecParameters;
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

        public AzureOperationResponse CreateRouteTable(string routeTableName, string label, string location)
        {
            CreateRouteTableParameters parameters = new CreateRouteTableParameters()
            {
                Name = routeTableName,
                Label = label,
                Location = location,
            };

            return client.Routes.CreateRouteTable(parameters);
        }

        public AzureOperationResponse DeleteRouteTable(string routeTableName)
        {
            return client.Routes.DeleteRouteTable(routeTableName);
        }

        public AzureOperationResponse SetRoute(string routeTableName, string routeName, string addressPrefix, string nextHopType, string ipAddress)
        {
            NextHop nextHop = new NextHop()
            {
                Type = nextHopType,
                IpAddress = ipAddress
            };
            SetRouteParameters parameters = new SetRouteParameters()
            {
                Name = routeName,
                AddressPrefix = addressPrefix,
                NextHop = nextHop,
            };

            return client.Routes.SetRoute(routeTableName, routeName, parameters);
        }

        public AzureOperationResponse DeleteRoute(string routeTableName, string routeName)
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

        public AzureOperationResponse AddRouteTableToSubnet(string vnetName, string subnetName, string routeTableName)
        {
            AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
            {
                RouteTableName = routeTableName,
            };

            return client.Routes.AddRouteTableToSubnet(vnetName, subnetName, parameters);
        }

        public AzureOperationResponse RemoveRouteTableFromSubnet(string vnetName, string subnetName)
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

        private static ClientType CreateClient<ClientType>(AzureProfile profile, AzureSubscription subscription) where ClientType : ServiceClient<ClientType>
        {
            return AzureSession.ClientFactory.CreateClient<ClientType>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
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

        public NetworkSecurityGroupGetAssociationResponse GetNetworkSecurityGroupForSubnet(string virtualNetworkName, string subnetName)
        {
            return client.NetworkSecurityGroups.GetForSubnet(virtualNetworkName, subnetName);
        }

        public void RemoveNetworkSecurityGroupFromSubnet(string networkSecurityGroupName, string virtualNetworkName, string subnetName)
        {
            client.NetworkSecurityGroups.RemoveFromSubnet(virtualNetworkName, subnetName, networkSecurityGroupName);
        }

        public void SetNetworkSecurityGroupForSubnet(string networkSecurityGroupName, string subnetName, string virtualNetworkName)
        {
            var parameters = new NetworkSecurityGroupAddAssociationParameters()
            {
                Name = networkSecurityGroupName
            };

            client.NetworkSecurityGroups.AddToSubnet(virtualNetworkName, subnetName, parameters);
        }

        public string GetDeploymentBySlot(string serviceName, string slot)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentNullException(serviceName);
            }

            if (string.IsNullOrEmpty(slot))
            {
                throw new ArgumentNullException(slot);
            }

            var slotType = (ComputeModels.DeploymentSlot)Enum.Parse(typeof(ComputeModels.DeploymentSlot), slot, true);

            return this.computeClient.Deployments.GetBySlot(
                        serviceName,
                        slotType).Name;
        }

        public string GetDeploymentName(IPersistentVM vm, string slot, string serviceName)
        {
            string deploymentName = null;
            var vmRoleContext = vm as PersistentVMRoleContext;
            if (vmRoleContext != null)
            {
                deploymentName = vmRoleContext.DeploymentName;
            }

            if (string.IsNullOrEmpty(slot) && string.IsNullOrEmpty(deploymentName))
            {
                slot = DeploymentSlotType.Production;
            }

            if (string.IsNullOrEmpty(deploymentName))
            {
                deploymentName = this.GetDeploymentBySlot(serviceName, slot);
            }

            return deploymentName;
        }

        public GetEffectiveRouteTableResponse GetEffectiveRouteTableForRoleInstance(
            string serviceName,
            string deploymentName,
            string roleInstanceName)
        {
            return this.client.Routes.GetEffectiveRouteTableForRoleInstance(
                serviceName,
                deploymentName,
                roleInstanceName);
        }

        public GetEffectiveRouteTableResponse GetEffectiveRouteTableForNetworkInterface(
            string serviceName,
            string deploymentName,
            string roleInstanceName,
            string networkInterfaceName)
        {
            return this.client.Routes.GetEffectiveRouteTableForNetworkInterface(
                serviceName,
                deploymentName,
                roleInstanceName,
                networkInterfaceName);
        }

        public void SetIPForwardingForRole(string serviceName, string deploymentName, string roleName, bool ipForwarding)
        {
            var parameters = new IPForwardingSetParameters()
            {
                State = ipForwarding ? "Enabled" : "Disabled"
            };

            client.IPForwarding.SetOnRole(serviceName, deploymentName, roleName, parameters);
        }

        public void SetIPForwardingForNetworkInterface(string serviceName, string deploymentName, string roleName, string networkInterfaceName, bool ipForwarding)
        {
            var parameters = new IPForwardingSetParameters()
            {
                State = ipForwarding ? "Enabled" : "Disabled"
            };

            client.IPForwarding.SetOnNetworkInterface(serviceName, deploymentName, roleName, networkInterfaceName, parameters);
        }

        public string GetIPForwardingForRole(string serviceName, string deploymentName, string roleName)
        {
            IPForwardingGetResponse ipForwardingGetResponse = client.IPForwarding.GetForRole(serviceName, deploymentName, roleName);
            return ipForwardingGetResponse.State;
        }
        public string GetIPForwardingForNetworkInterface(string serviceName, string deploymentName, string roleName, string networkInterfaceName)
        {
            IPForwardingGetResponse ipForwardingGetResponse = client.IPForwarding.GetForNetworkInterface(serviceName, deploymentName, roleName, networkInterfaceName);
            return ipForwardingGetResponse.State;
        }
    }
}
