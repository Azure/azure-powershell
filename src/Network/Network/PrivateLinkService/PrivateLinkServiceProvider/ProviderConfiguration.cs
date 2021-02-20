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
            RegisterConfiguration("Microsoft.Automation/automationAccounts", "2020-01-13-preview");
            RegisterConfiguration("Microsoft.AppConfiguration/configurationStores", "2020-06-01");
            RegisterConfiguration("Microsoft.Batch/batchAccounts", "2020-03-01");
            RegisterConfiguration("Microsoft.Cache/redisEnterprise", "2020-10-01-preview");
            RegisterConfiguration("Microsoft.CognitiveServices/accounts", "2017-04-18");
            RegisterConfiguration("Microsoft.Compute/diskAccesses", "2020-09-30");
            RegisterConfiguration("Microsoft.ContainerRegistry/registries", "2019-12-01-preview");
            RegisterConfiguration("Microsoft.DBforMySQL/servers", "2018-06-01");
            RegisterConfiguration("Microsoft.DBforMariaDB/servers", "2018-06-01");
            RegisterConfiguration("Microsoft.DBforPostgreSQL/servers", "2018-06-01");
            RegisterConfiguration("Microsoft.Devices/IotHubs", "2020-03-01");
            RegisterConfiguration("Microsoft.DocumentDB/databaseAccounts", "2019-08-01-preview");
            RegisterConfiguration("Microsoft.EventGrid/topics", "2020-04-01-preview");
            RegisterConfiguration("Microsoft.EventGrid/domains", "2020-04-01-preview"); 
            RegisterConfiguration("Microsoft.EventHub/namespaces", "2018-01-01-preview");
            RegisterConfiguration("Microsoft.HealthcareApis/services", "2020-03-30", false);
            RegisterConfiguration("Microsoft.Insights/privateLinkScopes", "2019-10-17-preview");
            RegisterConfiguration("Microsoft.KeyVault/vaults", "2018-02-14", false);
            RegisterConfiguration("Microsoft.Media/mediaservices", "2020-05-01");
            RegisterConfiguration("Microsoft.Migrate/assessmentProjects", "2020-05-01-preview", false);
            RegisterConfiguration("Microsoft.Migrate/migrateProjects", "2020-06-01-preview", false);
            RegisterConfiguration("Microsoft.Network/applicationgateways", "2020-05-01");
            RegisterConfiguration("Microsoft.OffAzure/masterSites", "2020-07-07", false);
            RegisterConfiguration("Microsoft.Purview/accounts", "2020-12-01-preview");
            RegisterConfiguration("Microsoft.Search/searchServices", "2020-08-01");
            RegisterConfiguration("Microsoft.ServiceBus/namespaces", "2018-01-01-preview");
            RegisterConfiguration("Microsoft.SignalRService/signalr", "2020-05-01", false);
            RegisterConfiguration("Microsoft.Sql/servers", "2018-06-01-preview");
            RegisterConfiguration("Microsoft.Storage/storageAccounts", "2019-06-01", false);
            RegisterConfiguration("Microsoft.StorageSync/storageSyncServices", "2020-03-01");
            RegisterConfiguration("Microsoft.Synapse/workspaces", "2019-06-01-preview");
            RegisterConfiguration("Microsoft.Web/sites", "2019-08-01");
            RegisterConfiguration("Microsoft.Web/hostingEnvironments", "2020-10-01");
        }

        private static void RegisterConfiguration(string type, string apiVersion, bool hasConnectionsURI = true)
        {
            ProviderConfiguration configuration = new ProviderConfiguration
            {
                Type = type,
                ApiVersion = apiVersion,
                HasConnectionsURI = hasConnectionsURI
            };
            _configurations.Add(type, configuration);
        }

        public string Type { get; set; }
        public string ApiVersion { get; set; }
        public bool HasConnectionsURI { get; set; }

        public static ProviderConfiguration GetProviderConfiguration(string type)
        {
            return _configurations[type];
        }

        /// <summary>
        /// Generate a runtime parameter with ValidateSet matching the current context
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="runtimeParameter">The returned runtime parameter for context, with appropriate validate set</param>
        /// <returns>True if one or more contexts were found, otherwise false</returns>
        public static bool TryGetProvideServiceParameter(string name, string parameterSetName, out RuntimeDefinedParameter runtimeParameter)
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
                    new ParameterAttribute { Mandatory = false,
                                            ValueFromPipeline = true,
                                            HelpMessage = "The private link resource type.",
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
