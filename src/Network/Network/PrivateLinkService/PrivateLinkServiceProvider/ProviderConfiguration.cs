using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider
{
    internal class ProviderConfiguration
    {

        private static IDictionary<string, ProviderConfiguration> _configurations = new Dictionary<string, ProviderConfiguration>(StringComparer.InvariantCultureIgnoreCase);

        static ProviderConfiguration()
        {
            RegisterConfiguration("Microsoft.AgFoodPlatform/farmBeats", "2021-09-01-preview", false, true);
            RegisterConfiguration("Microsoft.ApiManagement/service", "2021-04-01-preview", true, true);
            RegisterConfiguration("Microsoft.AppConfiguration/configurationStores", "2020-06-01", true, true);
            RegisterConfiguration("Microsoft.Attestation/attestationProviders", "2020-10-01", true, true);
            RegisterConfiguration("Microsoft.Authorization/resourceManagementPrivateLinks", "2020-05-01", true, false, true);
            RegisterConfiguration("Microsoft.Automation/automationAccounts", "2020-01-13-preview", true, false);
            RegisterConfiguration("Microsoft.Batch/batchAccounts", "2022-06-01", true, true);
            RegisterConfiguration("Microsoft.Cache/Redis", "2021-06-01", true, true);
            RegisterConfiguration("Microsoft.Cache/redisEnterprise", "2021-03-01", true, false);
            RegisterConfiguration("Microsoft.CognitiveServices/accounts", "2017-04-18", true, false);
            RegisterConfiguration("Microsoft.Compute/diskAccesses", "2020-09-30", true, false);
            RegisterConfiguration("Microsoft.ContainerRegistry/registries", "2019-12-01-preview", true, false);
            RegisterConfiguration("Microsoft.ContainerService/managedClusters", "2021-07-01", true, false);
            RegisterConfiguration("Microsoft.Databricks/workspaces", "2021-04-01-preview", true, true);
            RegisterConfiguration("Microsoft.DataFactory/factories", "2018-06-01", true, false);
            RegisterConfiguration("Microsoft.DBforMariaDB/servers", "2018-06-01", true, true);
            RegisterConfiguration("Microsoft.DBforMySQL/servers", "2018-06-01", true, true);
            RegisterConfiguration("Microsoft.DBforPostgreSQL/servers", "2018-06-01", true, true);
            RegisterConfiguration("Microsoft.DesktopVirtualization/hostpools", "2021-09-03-preview", true, false);
            RegisterConfiguration("Microsoft.DesktopVirtualization/workspaces", "2021-09-03-preview", true, false);
            RegisterConfiguration("Microsoft.Devices/IotHubs", "2020-03-01", true, true);
            RegisterConfiguration("Microsoft.Devices/ProvisioningServices", "2020-03-01", true, true);
            RegisterConfiguration("Microsoft.DeviceUpdate/accounts", "2023-07-01", true, true);
            RegisterConfiguration("Microsoft.DigitalTwins/digitalTwinsInstances", "2020-12-01", true, true);
            RegisterConfiguration("Microsoft.DocumentDB/databaseAccounts", "2019-08-01-preview", true, true);
            RegisterConfiguration("Microsoft.ElasticSan/elasticSans", "2022-12-01-preview", true, false);
            RegisterConfiguration("Microsoft.EventGrid/topics", "2020-04-01-preview", true, true);
            RegisterConfiguration("Microsoft.EventGrid/domains", "2020-04-01-preview", true, true);
            RegisterConfiguration("Microsoft.EventGrid/partnerNamespaces", "2021-06-01-preview", true, true);
            RegisterConfiguration("Microsoft.EventGrid/namespaces", "2023-06-01-preview", true, true);
            RegisterConfiguration("Microsoft.EventHub/namespaces", "2018-01-01-preview", true, false);
            RegisterConfiguration("Microsoft.HardwareSecurityModules/cloudHsmClusters", "2022-08-31-preview", true, true);
            RegisterConfiguration("Microsoft.HealthcareApis/services", "2020-03-30", false, true);
            RegisterConfiguration("Microsoft.HealthDataAIServices/deidServices", "2024-09-20", true, false);
            RegisterConfiguration("Microsoft.HDInsight/clusters", "2018-06-01-preview", true, true);
            RegisterConfiguration("Microsoft.HybridCompute/privateLinkScopes", "2021-05-20", true, true);
            RegisterConfiguration("Microsoft.Insights/privateLinkScopes", "2019-10-17-preview", true, true);
            RegisterConfiguration("Microsoft.KeyVault/vaults", "2018-02-14", false, false);
            RegisterConfiguration("Microsoft.Keyvault/managedHSMs", "2021-06-01-preview", true, false);
            RegisterConfiguration("Microsoft.MachineLearningServices/workspaces", "2021-07-01", true, false);
            RegisterConfiguration("Microsoft.MachineLearningServices/registries", "2022-10-01-preview", true, false);
            RegisterConfiguration("Microsoft.Media/mediaservices", "2021-06-01", true, true);
            RegisterConfiguration("Microsoft.Media/videoanalyzers", "2021-11-01-preview", true, true);
            RegisterConfiguration("Microsoft.Migrate/assessmentProjects", "2020-05-01-preview", false, false);
            RegisterConfiguration("Microsoft.Migrate/migrateProjects", "2020-06-01-preview", false, false);
            RegisterConfiguration("Microsoft.Monitor/accounts", "2021-06-03-preview", true, false);
            RegisterConfiguration("Microsoft.Network/applicationgateways", "2020-05-01", true, false);
            RegisterConfiguration("Microsoft.Network/privateLinkServices", "2020-05-01", true, false, false);
            RegisterConfiguration("Microsoft.OffAzure/masterSites", "2020-07-07", false, false);
            RegisterConfiguration("Microsoft.PowerBI/privateLinkServicesForPowerBI", "2020-06-01", false, true);
            RegisterConfiguration("Microsoft.Purview/accounts", "2020-12-01-preview", true, true);
            RegisterConfiguration("Microsoft.RecoveryServices/vaults", "2021-07-01", false, true);
            RegisterConfiguration("Microsoft.Relay/namespaces", "2018-01-01-preview", true, false);
            RegisterConfiguration("Microsoft.Search/searchServices", "2020-08-01", true, false);
            RegisterConfiguration("Microsoft.ServiceBus/namespaces", "2018-01-01-preview", true, false);
            RegisterConfiguration("Microsoft.SignalRService/signalr", "2020-05-01", false, false);
            RegisterConfiguration("Microsoft.SignalRService/webPubSub", "2021-10-01", true, false);
            RegisterConfiguration("Microsoft.Sql/servers", "2018-06-01-preview", true, true);
            RegisterConfiguration("Microsoft.Storage/storageAccounts", "2019-06-01", false, false);
            RegisterConfiguration("Microsoft.StorageSync/storageSyncServices", "2020-03-01", true, false);
            RegisterConfiguration("Microsoft.Synapse/privateLinkHubs", "2021-05-01", true, true);
            RegisterConfiguration("Microsoft.Synapse/workspaces", "2019-06-01-preview", true, true);
            RegisterConfiguration("Microsoft.Web/sites", "2019-08-01", true, false);
            RegisterConfiguration("Microsoft.Web/staticSites", "2021-02-01", true, false);
            RegisterConfiguration("Microsoft.Web/hostingEnvironments", "2020-10-01", true, false);
            RegisterConfiguration("Microsoft.BotService/botServices", "2021-05-01-preview", true, true);
            RegisterConfiguration("Microsoft.OpenEnergyPlatform/energyServices", "2022-07-21-preview", true, true);
            RegisterConfiguration("Microsoft.DBforMySQL/flexibleServers", "2022-09-30-privatepreview", true, true);
            RegisterConfiguration("Microsoft.DBforPostgreSQL/flexibleServers", "2023-06-01-preview", true, true);
            RegisterConfiguration("Microsoft.App/managedEnvironments", "2024-02-02-preview", true, true);
            RegisterConfiguration("Microsoft.VideoIndexer/accounts", "2024-06-01-preview", true, true, true);
        }
        /// <summary>
        /// Register priavte endopoint connection and private link resource configuration
        /// </summary>
        /// <param name="type">Resource type</param>
        /// <param name="apiVersion">Resource api version</param>
        /// <param name="hasConnectionsURI">True if the private endpoint connection can be list by URL <see cref="GenericProvider.BuildPrivateEndpointConnectionsURL(string, string)"/>, otherwise it can be list by URL <see cref="GenericProvider.BuildPrivateEndpointConnectionsOwnerURL(string, string)"/></param>
        /// <param name="supportGetPrivateLinkResource">True if the private link resource can be obtained by Id, otherwise false</param>
        /// <param name="supportListPrivateLinkResource">True if the private link resource can be listed, otherwise false</param>
        private static void RegisterConfiguration(string type, string apiVersion, bool hasConnectionsURI = false, bool supportGetPrivateLinkResource = false, bool supportListPrivateLinkResource = true)
        {
            ProviderConfiguration configuration = new ProviderConfiguration
            {
                Type = type,
                ApiVersion = apiVersion,
                HasConnectionsURI = hasConnectionsURI,
                SupportGetPrivateLinkResource = supportGetPrivateLinkResource,
                SupportListPrivateLinkResource = supportListPrivateLinkResource,
            };
            _configurations.Add(type, configuration);
        }

        public string Type { get; set; }
        public string ApiVersion { get; set; }
        public bool HasConnectionsURI { get; set; }
        public bool SupportGetPrivateLinkResource { get; set; }
        public bool SupportListPrivateLinkResource { get; set; }

        public static ProviderConfiguration GetProviderConfiguration(string type)
        {
            ProviderConfiguration outProviderConfiguration = null;
            _configurations.TryGetValue(type, out outProviderConfiguration);
            return outProviderConfiguration;
        }

        /// <summary>
        /// Generate a runtime parameter with ValidateSet matching the current context
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="parameterSetName">The name of the parameter set</param>
        /// <param name="runtimeParameter">The returned runtime parameter for context, with appropriate validate set</param>
        /// <returns>True if one or more contexts were found, otherwise false</returns>
        public static bool TryGetEndpointConnectionServiceParameter(string name, string parameterSetName, out RuntimeDefinedParameter runtimeParameter)
        {
            var result = false;
            runtimeParameter = null;
            if (_configurations != null && _configurations.Values != null)
            {
                var ObjArray = _configurations.Values.ToArray();
                var ProvideTypeList = ObjArray.Select(c => c.Type).ToArray();
                runtimeParameter = new RuntimeDefinedParameter(
                    name, typeof(string),
                    new Collection<Attribute>()
                    {
                    new ParameterAttribute { Mandatory = true,
                                            ValueFromPipeline = true,
                                            HelpMessage = "The resource provider and resource type which supports private endpoint connection.",
                                            ParameterSetName = parameterSetName },
                    new ValidateSetAttribute(ProvideTypeList)
                    }
                );
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Generate a runtime parameter with ValidateSet matching the current context
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="parameterSetName">The name of the parameter set</param>
        /// <param name="runtimeParameter">The returned runtime parameter for context, with appropriate validate set</param>
        /// <returns>True if one or more contexts were found, otherwise false</returns>
        public static bool TryGetLinkResourceServiceParameter(string name, string parameterSetName, out RuntimeDefinedParameter runtimeParameter)
        {
            var result = false;
            runtimeParameter = null;
            if (_configurations != null && _configurations.Values != null)
            {
                var ObjArray = _configurations.Values.ToArray();
                var ProvideTypeList = ObjArray.Where(c => (c.SupportListPrivateLinkResource || c.SupportGetPrivateLinkResource)).Select(c => c.Type).ToArray();
                runtimeParameter = new RuntimeDefinedParameter(
                    name, typeof(string),
                    new Collection<Attribute>()
                    {
                    new ParameterAttribute { Mandatory = false,
                                            ValueFromPipeline = true,
                                            HelpMessage = "The resource provider and resource type which supports private link resource.",
                                            ParameterSetName = parameterSetName },
                    new ValidateSetAttribute(ProvideTypeList)
                    }
                );
                result = true;
            }
            return result;
        }
    }
}
