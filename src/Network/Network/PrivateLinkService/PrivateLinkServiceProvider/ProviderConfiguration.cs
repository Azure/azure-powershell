using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider
{
    internal class ProviderConfiguration
    {

        private static IDictionary<string, ProviderConfiguration> _configurations = new Dictionary<string, ProviderConfiguration>();

        static ProviderConfiguration()
        {
            RegisterConfiguration("Microsoft.Sql/servers", "2018-06-01-preview");
            RegisterConfiguration("Microsoft.Insights/privateLinkScopes", "2019-10-17-preview");
            RegisterConfiguration("Microsoft.Storage/storageAccounts", "2019-06-01", false);
            RegisterConfiguration("Microsoft.KeyVault/vaults", "2019-09-01", false);
            RegisterConfiguration("Microsoft.DocumentDB/databaseAccounts", "2019-08-01-preview");
        }

        private static void RegisterConfiguration(string type, string apiVersion, bool hasConnectionsURI = true)
        {
            ProviderConfiguration configuration = new ProviderConfiguration();
            configuration.Type = type;
            configuration.ApiVersion = apiVersion;
            configuration.HasConnectionsURI = hasConnectionsURI;
            _configurations.Add(type.ToLower(), configuration);
        }

        public string Type { get; set; }
        public string ApiVersion { get; set; }
        public bool HasConnectionsURI { get; set; }

        public static ProviderConfiguration GetProviderConfiguration(string type)
        {
            return _configurations[type?.ToLower()];
        }
    }
}
