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

using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.VisualStudio.EtwListener.Common;
using Microsoft.VisualStudio.EtwListener.Common.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    public static class EtwStreamingHelper
    {
        private const string NatRuleNamePrefix = "MSVSAutoGen-";

        private const string SubjectNamePrefix = "CN=";

        private const string ServerCertificateFriendlyName = "Microsoft Azure Tools Etw Listener Server Certificate";

        private const string DefaultCertificateSubject = "Azure Tools";

        private const string ServerCertificateNamePrefix = "etwserver";

        private const string ClientCertificateNamePrefix = "etwclient";

        private const string KeyVaultNamePrefix = "AzureTools";

        private const int InitPriority = 1000;

        private static Random random = new Random();

        /// <summary>
        /// Check if a virtual machine extension is included in extension list
        /// </summary>
        /// <param name="extensionList">Extension list</param>
        /// <param name="extension">Virtual machine extension</param>
        /// <returns></returns>
        public static bool Includes(this IEnumerable<ComputeExtension> extensionList, VirtualMachineExtension extension)
        {
            return extensionList.Any(extensionInList =>
            {
                return extension.Publisher.Equals(extensionInList.Publisher, StringComparison.InvariantCultureIgnoreCase) &&
                extension.VirtualMachineExtensionType.Equals(extensionInList.Type, StringComparison.InvariantCultureIgnoreCase);
            });
        }

        /// <summary>
        /// Check if a VM scale set extension is included in extension list
        /// </summary>
        /// <param name="extensionList">Extension list</param>
        /// <param name="extension">VM scale set extension</param>
        /// <returns></returns>
        public static bool Includes(this IEnumerable<ComputeExtension> extensionList, VirtualMachineScaleSetExtension extension)
        {
            return extensionList.Any(extensionInList =>
            {
                return extension.Publisher.Equals(extensionInList.Publisher, StringComparison.InvariantCultureIgnoreCase) &&
                extension.Type.Equals(extensionInList.Type, StringComparison.InvariantCultureIgnoreCase);
            });
        }

        /// <summary>
        /// Check if the virtual machine extension is etw listener extension
        /// </summary>
        /// <param name="extension">Virtual machine extension</param>
        /// <returns></returns>
        public static bool IsEtwListenerExtension(this VirtualMachineExtension extension)
        {
            return Includes(new[] { EtwListenerConstants.EtwListenerExtension }, extension);
        }

        /// <summary>
        /// Check if the VM scale set extension is etw listener extension
        /// </summary>
        /// <param name="extension">VM scale set extension</param>
        /// <returns></returns>
        public static bool IsEtwListenerExtension(this VirtualMachineScaleSetExtension extension)
        {
            return Includes(new[] { EtwListenerConstants.EtwListenerExtension }, extension);
        }

        /// <summary>
        /// Generate a randome id using given prefix
        /// </summary>
        /// <param name="prefix">Prefix of the id</param>
        /// <returns></returns>
        public static string GenerateUniqueId(string prefix, Predicate<string> isQualified)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string result;
            do
            {
                result = prefix + new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (!isQualified(result));

            return result;
        }

        /// <summary>
        /// Enable given ports for the network security group
        /// </summary>
        /// <param name="networkSecurityGroup">Network security group</param>
        /// <param name="portMap">Port map where key is the port name and value is the port number</param>
        public static void EnableNetworkSecurityGroupRules(this NetworkSecurityGroup networkSecurityGroup, IDictionary<string, int> portMap)
        {
            var securityRules = networkSecurityGroup.SecurityRules;

            foreach (var port in portMap)
            {
                int portNumber = port.Value;
                string portName = port.Key;

                if (!securityRules.Select(v => GetPortRange(v.DestinationPortRange)).Any(v => v.Item1 <= portNumber && v.Item2 >= portNumber))
                {
                    if (securityRules.Any(v => v.Name.Equals(portName, StringComparison.OrdinalIgnoreCase)))
                    {
                        portName = GenerateUniqueId(portName, v => !securityRules.Any(rule => string.Equals(rule.Name, v, StringComparison.InvariantCultureIgnoreCase)));
                    }

                    var newRule = new SecurityRule(
                          protocol: SecurityRuleProtocol.Tcp,
                          sourceAddressPrefix: "*",
                          destinationAddressPrefix: "*",
                          access: SecurityRuleAccess.Allow,
                          direction: SecurityRuleDirection.Inbound,
                          sourcePortRange: "*",
                          destinationPortRange: Convert.ToString(portNumber),
                          priority: FindAvailableSecurityRulePriority(InitPriority, securityRules),
                          name: portName
                       );

                    securityRules.Add(newRule);
                }
            }
        }

        /// <summary>
        /// Disable given ports for the network security group
        /// </summary>
        /// <param name="networkSecurityGroup">Network security group</param>
        /// <param name="portMap">Port map where key is the port name and value is the port number</param>
        public static void DisableNetworkSecurityGroupRules(this NetworkSecurityGroup networkSecurityGroup, IDictionary<string, int> portMap)
        {
            var securityRules = networkSecurityGroup.SecurityRules;

            var rulesToRemove = new List<SecurityRule>();
            foreach (var port in portMap)
            {
                int portNumber = port.Value;
                string portName = port.Key;

                rulesToRemove.AddRange(securityRules.Where(v =>
                {
                    var portRange = GetPortRange(v.DestinationPortRange);
                    return v.Access.Equals(SecurityRuleAccess.Allow, StringComparison.OrdinalIgnoreCase) && portRange.Item1 == portNumber && portRange.Item2 == portNumber;
                }));
            }

            networkSecurityGroup.SecurityRules = securityRules.Except(rulesToRemove).ToList();
        }

        /// <summary>
        /// Enable inbound nat rule for the load balancer
        /// </summary>
        /// <param name="loadBalancer">Load balancer</param>
        /// <param name="networkInterface">Network interface</param>
        /// <param name="portMap">Port map where key is the port name and value is the port number</param>
        public static void EnableInboundNatRules(LoadBalancer loadBalancer, NetworkInterface networkInterface, IDictionary<string, int> portMap)
        {
            string inboundNatRuleNameSuffix = networkInterface.Name;
            IList<NetworkInterfaceIPConfiguration> ipConfigurations = networkInterface.IpConfigurations;
            NetworkInterfaceIPConfiguration ipConfiguration = FindNetworkInterfaceIpConfigurationForGivenLoadBalancer(loadBalancer, ipConfigurations);
            IList<InboundNatRule> loadBalanceInboundNatRules = loadBalancer.InboundNatRules ?? new List<InboundNatRule>();
            IList<InboundNatRule> networkInterfaceInboundNatRules = ipConfiguration.LoadBalancerInboundNatRules ?? new List<InboundNatRule>();

            foreach (var item in portMap)
            {
                string portName = item.Key;
                int portNumber = item.Value;

                string ruleName = GetInboundNatRuleName(portName, inboundNatRuleNameSuffix);
                string nicRuleId = GetNICRuleId(ruleName, loadBalancer);

                if (!networkInterfaceInboundNatRules.Any(v => v.Id.Equals(nicRuleId, StringComparison.InvariantCultureIgnoreCase)))
                {
                    networkInterfaceInboundNatRules.Add(new InboundNatRule(nicRuleId));
                }

                if (!loadBalanceInboundNatRules.Any(v => v.Name.Equals(ruleName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var ruleToAdd = new InboundNatRule(
                        name: ruleName,
                        frontendPort: FindAvailablePort(portNumber, loadBalanceInboundNatRules),
                        backendPort: portNumber,
                        protocol: TransportProtocol.Tcp,
                        idleTimeoutInMinutes: 4,
                        enableFloatingIP: false,
                        frontendIPConfiguration: new FrontendIPConfiguration(loadBalancer.FrontendIPConfigurations[0].Id),
                        backendIPConfiguration: new NetworkInterfaceIPConfiguration(ipConfiguration.Id)
                        );

                    loadBalanceInboundNatRules.Add(ruleToAdd);
                }
            }

            loadBalancer.InboundNatRules = loadBalanceInboundNatRules;
            ipConfiguration.LoadBalancerInboundNatRules = networkInterfaceInboundNatRules;
        }

        /// <summary>
        /// Disable inbound nat rule for the load balancer
        /// </summary>
        /// <param name="loadBalancer">Load balancer</param>
        /// <param name="networkInterface">Network interface</param>
        /// <param name="portMap">Port map where key is the port name and value is the port number</param>
        public static void DisableInboundNatRules(LoadBalancer loadBalancer, NetworkInterface networkInterface, IDictionary<string, int> portMap)
        {
            string inboundNatRuleNameSuffix = networkInterface.Name;

            IList<NetworkInterfaceIPConfiguration> ipConfigurations = networkInterface.IpConfigurations;
            NetworkInterfaceIPConfiguration ipConfiguration = FindNetworkInterfaceIpConfigurationForGivenLoadBalancer(loadBalancer, ipConfigurations);
            IList<InboundNatRule> loadBalanceInboundNatRules = loadBalancer.InboundNatRules ?? new List<InboundNatRule>();
            IList<InboundNatRule> networkInterfaceInboundNatRules = ipConfiguration.LoadBalancerInboundNatRules ?? new List<InboundNatRule>();

            foreach (var item in portMap)
            {
                string portName = item.Key;
                int portNumber = item.Value;

                string ruleName = GetInboundNatRuleName(portName, inboundNatRuleNameSuffix);
                string nicRuleId = GetNICRuleId(ruleName, loadBalancer);

                loadBalanceInboundNatRules = loadBalanceInboundNatRules.Where(v => !v.Name.Equals(ruleName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                networkInterfaceInboundNatRules = networkInterfaceInboundNatRules.Where(v => !v.Id.Equals(nicRuleId, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            loadBalancer.InboundNatRules = loadBalanceInboundNatRules;
            ipConfiguration.LoadBalancerInboundNatRules = networkInterfaceInboundNatRules;
        }

        /// <summary>
        /// Enable inbound nat pool for the load balancer
        /// </summary>
        /// <param name="loadBalancer">Load balancer</param>
        /// <param name="scaleSet">VM scale set</param>
        /// <param name="portMap">Port map where key is the port name and value is the port number</param>
        public static void EnableInboundNatPools(LoadBalancer loadBalancer, VirtualMachineScaleSet scaleSet, IDictionary<string, int> portMap)
        {
            if (loadBalancer.FrontendIPConfigurations == null || !loadBalancer.FrontendIPConfigurations.Any())
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.FrontendIpConfigurationNotFound, loadBalancer.Id));
            }

            if (loadBalancer.InboundNatPools == null)
            {
                loadBalancer.InboundNatPools = new List<InboundNatPool>();
            }

            string frontIpConfigurationId = loadBalancer.FrontendIPConfigurations.First().Id;

            VirtualMachineScaleSetNetworkConfiguration networkConfiguration = FindNetworkInterfaceIpConfigurationForGivenLoadBalancer(loadBalancer, scaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations).FirstOrDefault();
            VirtualMachineScaleSetIPConfiguration ipConfiguration = networkConfiguration.IpConfigurations.FirstOrDefault(ipc => ipc.LoadBalancerInboundNatPools != null && ipc.LoadBalancerInboundNatPools.Any(natPool => IsParentOf(loadBalancer.Id, natPool.Id)));

            foreach (var item in portMap)
            {
                string portName = item.Key;
                int portNumber = item.Value;

                var inboundNatPool = loadBalancer.InboundNatPools.FirstOrDefault(p => p.BackendPort == portNumber);

                string inboundNatPoolId;
                if (inboundNatPool == null)
                {
                    const int minPortCount = 10;
                    const int bufferMultiple = 3;
                    int portCount = (int)scaleSet.Sku.Capacity.Value * bufferMultiple;
                    if (portCount < minPortCount)
                    {
                        portCount = minPortCount;
                    }

                    Tuple<int, int> frontendPortRange = FindAvailablePortRage(portNumber, portCount, loadBalancer.InboundNatPools);

                    string poolName = GenerateUniqueId(portName, v => !loadBalancer.InboundNatPools.Any(pool => string.Equals(v, pool.Name, StringComparison.InvariantCultureIgnoreCase)));

                    inboundNatPool = new InboundNatPool(
                        protocol: TransportProtocol.Tcp,
                        frontendPortRangeStart: frontendPortRange.Item1,
                        frontendPortRangeEnd: frontendPortRange.Item2,
                        backendPort: portNumber,
                        frontendIPConfiguration: new Azure.Management.Network.Models.SubResource(frontIpConfigurationId),
                        name: poolName);

                    loadBalancer.InboundNatPools.Add(inboundNatPool);
                    inboundNatPoolId = GetNICPoolId(poolName, loadBalancer);
                }
                else
                {
                    inboundNatPoolId = inboundNatPool.Id;
                }

                if (!ipConfiguration.LoadBalancerInboundNatPools.Any(resource => string.Equals(resource.Id, inboundNatPoolId, StringComparison.InvariantCultureIgnoreCase)))
                {
                    ipConfiguration.LoadBalancerInboundNatPools.Add(new Azure.Management.Compute.Models.SubResource(inboundNatPoolId));
                }
            }
        }

        /// <summary>
        /// Disable inbound nat pool for the load balancer
        /// </summary>
        /// <param name="loadBalancer">Load balancer</param>
        /// <param name="scaleSet">VM scale set</param>
        /// <param name="portMap">Port map where key is the port name and value is the port number</param>
        public static void DisableInboundNatPools(LoadBalancer loadBalancer, VirtualMachineScaleSet scaleSet, IDictionary<string, int> portMap)
        {
            if (loadBalancer.InboundNatPools == null)
            {
                return;
            }

            IEnumerable<InboundNatPool> inboundNatPoolsToRemove = loadBalancer.InboundNatPools.Where(v => portMap.Values.Any(port => port == v.BackendPort)).ToList();
            loadBalancer.InboundNatPools = loadBalancer.InboundNatPools.Except(inboundNatPoolsToRemove).ToList();

            foreach (var fipc in loadBalancer.FrontendIPConfigurations)
            {
                var toRemove = fipc.InboundNatPools.Where(v => inboundNatPoolsToRemove.Any(p => string.Equals(p.Id, v.Id, StringComparison.InvariantCultureIgnoreCase))).ToList();
                toRemove.ForEach(v => fipc.InboundNatPools.Remove(v));
            }

            List<VirtualMachineScaleSetNetworkConfiguration> networkConfigurations = FindNetworkInterfaceIpConfigurationForGivenLoadBalancer(loadBalancer, scaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations);
            networkConfigurations.ForEach(networkConfiguration =>
            {
                foreach (var ipConfiguration in networkConfiguration.IpConfigurations)
                {
                    var toRemove = ipConfiguration.LoadBalancerInboundNatPools.Where(p => inboundNatPoolsToRemove.Any(v => string.Equals(p.Id, v.Id, StringComparison.InvariantCultureIgnoreCase)));

                    if (toRemove.Any())
                    {
                        ipConfiguration.LoadBalancerInboundNatPools = ipConfiguration.LoadBalancerInboundNatPools.Except(toRemove).ToList();
                    }
                }
            });
        }

        /// <summary>
        /// Check if a resource is the parent resource of the other resource
        /// </summary>
        /// <param name="parentId">Parent resource id</param>
        /// <param name="childId">Child resource id</param>
        /// <returns></returns>
        private static bool IsParentOf(string parentId, string childId)
        {
            return string.Equals(parentId, new ResourceIdentifier(childId).GetParentResourceIdentifier().ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Get parent resource id of a resource
        /// </summary>
        /// <param name="childId">Child resource id</param>
        /// <returns></returns>
        public static ResourceIdentifier GetParentResourceIdentifier(this ResourceIdentifier childId)
        {
            var childIdStr = childId.ToString();
            return new ResourceIdentifier(childIdStr.Substring(0, childIdStr.IndexOf(childId.ParentResource) + childId.ParentResource.Length));
        }

        /// <summary>
        /// Get connection information for etw streaming connection
        /// </summary>
        /// <param name="networkInterface">Network interface of the virtual machine</param>
        /// <param name="networkClient">Network client</param>
        /// <returns></returns>
        public static IPEndPoint GetEtwConnectionInfo(NetworkInterface networkInterface, NetworkClient networkClient)
        {
            int port = EtwListenerConstants.EtwListenerPortNumber;
            PublicIPAddress publicIpAddress = networkInterface.IpConfigurations.Select(ipc => ipc.PublicIPAddress).FirstOrDefault(v => v != null);

            if (publicIpAddress == null)
            {
                var loadBalancers = networkClient.NetworkManagementClient.LoadBalancers.ListAll();
                var nicBackendAddressPoolIds = networkInterface.IpConfigurations
                    .Where(ipc => ipc.LoadBalancerBackendAddressPools != null)
                    .SelectMany(v => v.LoadBalancerBackendAddressPools)
                    .Select(v => v.Id);

                LoadBalancer loadBalancer = loadBalancers.First(v => v.BackendAddressPools.Any(bap => nicBackendAddressPoolIds.Any(nicBapId => string.Equals(nicBapId, bap.Id, StringComparison.OrdinalIgnoreCase))));

                InboundNatRule inboundNatRule = loadBalancer.InboundNatRules.First(rule =>
                    rule.BackendPort == EtwListenerConstants.EtwListenerPortNumber &&
                    networkInterface.IpConfigurations.Any(ipc => string.Equals(rule.BackendIPConfiguration.Id, ipc.Id, StringComparison.OrdinalIgnoreCase)));

                publicIpAddress = loadBalancer.FrontendIPConfigurations.First(fipc => string.Equals(fipc.Id, inboundNatRule.FrontendIPConfiguration.Id, StringComparison.OrdinalIgnoreCase)).PublicIPAddress;
                port = inboundNatRule.FrontendPort.Value;
            }

            var pipResourceIndentifier = new ResourceIdentifier(publicIpAddress.Id);
            PublicIPAddress pip = networkClient.NetworkManagementClient.PublicIPAddresses.Get(pipResourceIndentifier.ResourceGroupName, pipResourceIndentifier.ResourceName);

            return new IPEndPoint(IPAddress.Parse(pip.IpAddress), port);
        }

        /// <summary>
        /// Create key vault for azure tools if not exists
        /// </summary>
        /// <param name="keyVaultManagementClient">KeyVault management client</param>
        /// <param name="resourceGroupName">Resource group name that will be used to create key vault</param>
        /// <param name="location">Locatio taht will be used to create key vault</param>
        /// <param name="objectId">Object Id that will be added to security access</param>
        /// <param name="tenantId">Tenant Id that will be added to security access</param>
        /// <returns></returns>
        public static async Task<Vault> CreateAzureToolsKeyVaultIfNotExists(this IKeyVaultManagementClient keyVaultManagementClient, string resourceGroupName, string location, Guid objectId, Guid tenantId)
        {
            Debug.Assert(objectId != Guid.Empty);

            var keyVaults = await keyVaultManagementClient.Vaults.ListByResourceGroupAsync(resourceGroupName);

            // Find azure tools keyvault which has permission to access
            Vault azureToolsKeyVault = keyVaults.FirstOrDefault(keyVault =>
            {
                // Vault name should start with azure tools prefix
                if (!keyVault.Name.StartsWith(KeyVaultNamePrefix, StringComparison.InvariantCulture))
                {
                    return false;
                }

                // If no access limit, always match
                if (keyVault.Properties?.AccessPolicies?.Any() != true)
                {
                    return true;
                }

                // Find if there's a policy entry defines the access
                return keyVault.Properties.AccessPolicies.Any(accessPolicyEntry =>
                    accessPolicyEntry.ObjectId == objectId &&
                    accessPolicyEntry.TenantId == tenantId &&
                    accessPolicyEntry.Permissions?.Secrets?.Any(permission => string.Equals(permission, SecretPermissions.All, StringComparison.OrdinalIgnoreCase)) == true);
            });


            if (azureToolsKeyVault == null)
            {
                string newKeyVaultName = GenerateUniqueId(KeyVaultNamePrefix, v => !keyVaults.Any(kv => string.Equals(kv.Name, v, StringComparison.InvariantCultureIgnoreCase)));

                azureToolsKeyVault = await keyVaultManagementClient.Vaults.CreateOrUpdateAsync(resourceGroupName, newKeyVaultName, new VaultCreateOrUpdateParameters(
                    location: location,
                    properties: new VaultProperties(
                        enabledForDeployment: true,
                        tenantId: tenantId,
                        accessPolicies: new[] { new AccessPolicyEntry(tenantId, objectId, new Permissions(secrets: new[] { SecretPermissions.All }, keys: new string[] { })) },
                        sku: new Azure.Management.KeyVault.Models.Sku(SkuName.Standard)
                )));
            }
            else
            {
                azureToolsKeyVault = await keyVaultManagementClient.Vaults.GetAsync(resourceGroupName, azureToolsKeyVault.Name);
            }

            return azureToolsKeyVault;
        }

        /// <summary>
        /// Generate new etw listener settings, which will generate server/client certificate and upload to key vault
        /// </summary>
        /// <param name="subjectName">Server certificate subject name</param>
        /// <param name="keyVaultClient">KeyVault client</param>
        /// <param name="vaultUrl">KeyVault base url</param>
        /// <returns></returns>
        public static async Task<EtwListenerExtensionPublicSettings> GenerateEtwListenerSettings(string subjectName, IKeyVaultClient keyVaultClient, string vaultUrl)
        {
            X509Certificate2 serverCertificate = CertificateHelper.CreateCertificate(ServerCertificateFriendlyName, SubjectNamePrefix + subjectName);
            X509Certificate2 clientCertificate = CertificateHelper.CreateCertificate(GetClientCertificateFriendlyName(), SubjectNamePrefix + DefaultCertificateSubject);

            string serverCertificateString = GetSerializedCertForKeyVault(serverCertificate);
            string clientCertificateString = GetSerializedCertForKeyVault(clientCertificate);

            SecretBundle serverSecretBundle = await keyVaultClient.SetSecretAsync(vaultUrl, ServerCertificateNamePrefix + subjectName, serverCertificateString);
            SecretBundle clientSecretBundle = await keyVaultClient.SetSecretAsync(vaultUrl, ClientCertificateNamePrefix + subjectName, clientCertificateString);

            return new EtwListenerExtensionPublicSettings
            {
                ClientCertificateThumbprint = clientCertificate.Thumbprint,
                ServerCertificateThumbprint = serverCertificate.Thumbprint,
                ClientCertificateUrl = clientSecretBundle.SecretIdentifier.Identifier,
                ServerCertificateUrl = serverSecretBundle.SecretIdentifier.Identifier
            };
        }

        /// <summary>
        /// Download certificate from keyvault and enroll to local certificate store
        /// </summary>
        /// <param name="keyVaultClient">KeyVault client</param>
        /// <param name="secretUrl">KeyVault secret url</param>
        /// <param name="certificateThumbprint">Certificate thumbprint</param>
        /// <returns></returns>
        public static async Task EnrollCertificateFromKeyVault(IKeyVaultClient keyVaultClient, string secretUrl, string certificateThumbprint)
        {
            var clientCertificate = CertificateHelper.FindCertificate(certificateThumbprint);
            if (clientCertificate == null)
            {
                var secret = await keyVaultClient.GetSecretAsync(secretUrl);
                var keyVaultCert = JsonConvert.DeserializeObject<KeyVaultCert>(Encoding.UTF8.GetString(Convert.FromBase64String(secret.Value)));

                var pfx = new X509Certificate2(Convert.FromBase64String(keyVaultCert.Data), keyVaultCert.Password);
                CertificateHelper.EnrollCertificate(pfx);

                clientCertificate = CertificateHelper.FindCertificate(certificateThumbprint);
            }

            if (clientCertificate == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Properties.Resources.CertificateNotFound, certificateThumbprint));
            }
        }

        /// <summary>
        /// Helper class for start etw streaming base cmdlet
        /// </summary>
        /// <param name="cmdlet">Cmdlet</param>
        /// <param name="connectionInfo">Listener connection info</param>
        /// <param name="providers">Etw providers</param>
        internal static void StartListening(this EtwStreamingCmdletBase cmdlet, ListenerConnectionInfo connectionInfo, string[] providers)
        {
            using (var remoteClient = new EtwListenerClient(connectionInfo, ListenerSessionConfiguration.Create(providers)))
            {
                remoteClient.EtwEventsCaptured += (sender, args) =>
                {
                    foreach (var evt in args.Events)
                    {
                        cmdlet.DispatchOutputMessage(evt.ToPSEtwEvent());
                    }
                };

                remoteClient.StateChanged += (sender, args) =>
                {
                    cmdlet.DispatchVerboseMessage(string.Format(Properties.Resources.ListenerStateChange, remoteClient.State));
                };

                remoteClient.Start();

                Console.ReadKey();
            }
        }

        private static string GetClientCertificateFriendlyName()
        {
            return "EtwListener" + DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture);
        }

        private static string GetInboundNatRuleName(string portName, string suffix)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}-{2}", NatRuleNamePrefix, portName, suffix);
        }

        private static string GetNICRuleId(string ruleName, LoadBalancer loadBalancer)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}/inboundNatRules/{1}", loadBalancer.Id, ruleName);
        }

        private static string GetNICPoolId(string poolName, LoadBalancer loadBalancer)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}/inboundNatPools/{1}", loadBalancer.Id, poolName);
        }

        /// <summary>
        /// Find available port number for load balancer
        /// </summary>
        /// <param name="initPort">Initial port number</param>
        /// <param name="loadBalancerInboundRules">List of load balancer inbound rules</param>
        /// <returns></returns>
        private static int FindAvailablePort(int initPort, IList<InboundNatRule> loadBalancerInboundRules)
        {
            while (loadBalancerInboundRules.Any(v => v.FrontendPort == initPort))
            {
                initPort++;
            }

            return initPort;
        }

        /// <summary>
        /// Find available port range for load balancer
        /// </summary>
        /// <param name="initPort">Initial port number</param>
        /// <param name="portCount">Size of port range</param>
        /// <param name="loadBalancerInboundRules">List of load balancer inbound rules</param>
        /// <returns></returns>
        private static Tuple<int, int> FindAvailablePortRage(int initPort, int portCount, IList<InboundNatPool> loadBalancerInboundRules)
        {
            var rangeStart = initPort;
            while (rangeStart < short.MaxValue)
            {
                var rangeEnd = rangeStart + portCount - 1;

                var conflictingPool = loadBalancerInboundRules.FirstOrDefault(p => rangeStart <= p.FrontendPortRangeEnd && rangeEnd >= p.FrontendPortRangeStart);
                if (conflictingPool == null)
                {
                    return new Tuple<int, int>(rangeStart, rangeEnd);
                }

                rangeStart = conflictingPool.FrontendPortRangeEnd;
            }

            return null;
        }

        /// <summary>
        /// Parse port range string
        /// </summary>
        /// <param name="portRange">Port range string</param>
        /// <returns></returns>
        private static Tuple<int, int> GetPortRange(string portRange)
        {
            var entities = portRange.Split('-');
            if (entities.Length == 1)
            {
                var portNumber = Convert.ToInt32(portRange);
                return new Tuple<int, int>(portNumber, portNumber);
            }
            else if (entities.Length == 2)
            {
                var portStart = Convert.ToInt32(entities[0]);
                var portEnd = Convert.ToInt32(entities[1]);

                return new Tuple<int, int>(portStart, portEnd);
            }

            throw new ArgumentException("Invalid format of port range.");
        }

        /// <summary>
        /// Find network interface ipconfiguration used by given load balancer
        /// </summary>
        /// <param name="loadBalancer">Load balancer</param>
        /// <param name="ipConfigurations">Ip configuration candidates</param>
        /// <returns></returns>
        private static NetworkInterfaceIPConfiguration FindNetworkInterfaceIpConfigurationForGivenLoadBalancer(LoadBalancer loadBalancer, IList<NetworkInterfaceIPConfiguration> ipConfigurations)
        {
            if (loadBalancer.BackendAddressPools == null)
            {
                return null;
            }

            var ipConfiguration = loadBalancer.BackendAddressPools.SelectMany(v => v.BackendIPConfigurations).FirstOrDefault();
            if (ipConfiguration == null)
            {
                return null;
            }

            return ipConfigurations.FirstOrDefault(v => v.Id == ipConfiguration.Id);
        }

        /// <summary>
        /// Find network interface ipconfiguarion used by given load balancer
        /// </summary>
        /// <param name="loadBalancer">Load balancer</param>
        /// <param name="ipConfigurations">Ip configuration candidates</param>
        /// <returns></returns>
        private static List<VirtualMachineScaleSetNetworkConfiguration> FindNetworkInterfaceIpConfigurationForGivenLoadBalancer(LoadBalancer loadBalancer, IList<VirtualMachineScaleSetNetworkConfiguration> ipConfigurations)
        {
            return ipConfigurations.Where(v => v.IpConfigurations.Any(ipConfiguration => ipConfiguration.LoadBalancerInboundNatPools.Any(p => IsParentOf(loadBalancer.Id, p.Id)))).ToList();
        }

        /// <summary>
        /// Find available network security group rule priority
        /// </summary>
        /// <param name="initPriority">Initial priority number</param>
        /// <param name="rules">Security rules</param>
        /// <returns></returns>
        private static int FindAvailableSecurityRulePriority(int initPriority, IList<SecurityRule> rules)
        {
            while (rules.Any(v => v.Priority == initPriority))
            {
                initPriority += 100;
            }

            return initPriority;
        }

        /// <summary>
        /// Serialize X509 certificate to key vault certificate string.
        /// </summary>
        /// <param name="cert">X509 Certificate</param>
        /// <returns></returns>
        private static string GetSerializedCertForKeyVault(X509Certificate2 cert)
        {
            var pwdArray = GetRandomPassword();

            // Build the secure string
            using (var secureString = new SecureString())
            {
                for (int i = 0; i < pwdArray.Length; i++)
                {
                    secureString.AppendChar(pwdArray[i]);
                }

                var keyVaultCert = new KeyVaultCert
                {
                    Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, secureString)),
                    DataType = "pfx",
                    Password = new string(pwdArray)
                };

                // Certificate file requires a string, we can't use SecureString.
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(keyVaultCert, Formatting.None)));
            }

        }

        private static char[] GetRandomPassword()
        {
            byte[] pwdData = new byte[32];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(pwdData);
            }

            // Convert the binary input into Base64 UUEncoded output.
            // Each 3 byte sequence in the source data becomes a 4 byte sequence in the character array. 
            long arrayLength = (long)((4.0d / 3.0d) * pwdData.Length);

            // If array length is not divisible by 4, go up to the next multiple of 4.
            if (arrayLength % 4 != 0)
            {
                arrayLength += 4 - (arrayLength % 4);
            }

            char[] pwdArray = new char[arrayLength];
            Convert.ToBase64CharArray(pwdData, 0, pwdData.Length, pwdArray, 0);

            // Scrub the contents of the byte array since we no longer need it
            Array.Clear(pwdData, 0, pwdData.Length);

            return pwdArray;
        }

        /// <summary>
        /// Contract for key vault certificate secret
        /// </summary>
        [DataContract]
        private class KeyVaultCert
        {
            [DataMember(Name = "data")]
            public string Data { get; set; }

            [DataMember(Name = "dataType")]
            public string DataType { get; set; }

            [DataMember(Name = "password")]
            public string Password { get; set; }
        }
    }

    public class ComputeExtension
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
    }
}
