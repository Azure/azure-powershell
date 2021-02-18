
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.Network;

namespace Commands.HDInsight.Test.ScenarioTests
{
    public class TestHelper
    {
        public static KeyVaultManagementClient KeyVaultManagementClient { get; set; }
        public static KeyVaultClient KeyVaultClient { get; set; }
        public static NetworkManagementClient NetworkManagementClient { get; set; }

        public TestHelper(KeyVaultManagementClient keyVaultManagementClient, KeyVaultClient keyVaultClient, NetworkManagementClient networkManagementClient)
        {
            KeyVaultManagementClient = keyVaultManagementClient;
            KeyVaultClient = keyVaultClient;
            NetworkManagementClient = networkManagementClient;
        }

        /// <summary>
        /// Get access token
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            string accessToken = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
                string authClientId = GetServicePrincipalId();
                string authSecret = GetServicePrincipalSecret();
                var clientCredential = new ClientCredential(authClientId, authSecret);
                var result = await context.AcquireTokenAsync(resource, clientCredential).ConfigureAwait(false);
                accessToken = result.AccessToken;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                accessToken = "fake-token";
            }

            return accessToken;
        }

        /// <summary>
        /// Get delegating handlers
        /// </summary>
        /// <returns></returns>
        public static DelegatingHandler[] GetHandlers()
        {
            HttpMockServer server = HttpMockServer.CreateInstance();
            return new DelegatingHandler[] { server };
        }

        /// <summary>
        /// Get service principal Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalId()
        {
            string servicePrincipalId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalKey);
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];
            }
            return servicePrincipalId;
        }

        /// <summary>
        /// Get service principal secret from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalSecret()
        {
            string servicePrincipalSecret = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                servicePrincipalSecret = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.ServicePrincipalSecretKey);
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalSecret = "xyz";
            }
            return servicePrincipalSecret;
        }

        /// <summary>
        /// Get service principal object id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetServicePrincipalObjectId()
        {
            string servicePrincipalObjectId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey] = environment.ConnectionString.KeyValuePairs.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.AADClientIdKey);
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                servicePrincipalObjectId = HttpMockServer.Variables[ConnectionStringKeys.AADClientIdKey];
            }
            return servicePrincipalObjectId;
        }

        /// <summary>
        /// New key identity using KeyVaultClient.
        /// </summary>
        /// <returns></returns>
        public static KeyIdentifier GenerateVaultKey(Vault vault, string keyName)
        {
            string vaultUri = vault.Properties.VaultUri;
            var attributes = new KeyAttributes();
            var createdKey = KeyVaultClient.CreateKeyAsync(vaultUri, keyName, JsonWebKeyType.Rsa,
                    keyOps: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();
            return new KeyIdentifier(createdKey.Key.Kid);
        }

        /// <summary>
        /// Get Vault using KeyVaultManagementClient.
        /// </summary>
        /// <returns></returns>
        public static Vault GetVault(string resourceGroupName, string vaultName)
        {
            return KeyVaultManagementClient.Vaults.Get(resourceGroupName, vaultName);
        }

        public static VirtualNetwork CreateVirtualNetworkWithSubnet(string resourceGroupName, string location, string virtualNetworkName, string subnetName, bool subnetPrivateEndpointNetworkPoliciesFlag = true, bool subnetPrivateLinkServiceNetworkPoliciesFlag = true)
        {
            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                    {
                        "10.0.0.0/16",
                    }
                },
                Subnets = new List<Subnet>()
                {
                    new Subnet()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                        PrivateEndpointNetworkPolicies = subnetPrivateEndpointNetworkPoliciesFlag ? "Enabled" : "Disabled",
                        PrivateLinkServiceNetworkPolicies = subnetPrivateLinkServiceNetworkPoliciesFlag ? "Enabled" : "Disabled"
                    }
                }
            };
            return NetworkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, virtualNetworkName, vnet);
        }
    }
}
