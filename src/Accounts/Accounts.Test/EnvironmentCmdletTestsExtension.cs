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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public static class EnvironmentCmdletTestsExtension
    {
        public static PSAzureEnvironment GetAzureCloudEndpoints()
        {
            // AdTenant: Common --> common
            // GalleryUrl: "https://gallery.azure.com/" --> null
            // ManagementPortalUrl: "https://portal.azure.com/" --> "https://portal.azure.com"
            // ActiveDirectoryAuthority: "https://login.microsoftonline.com/" --> "https://login.microsoftonline.com"
            var env = new PSAzureEnvironment
            {
                Name = "AzureCloud",
                Type = "Discovered",
                EnableAdfsAuthentication = false,
                OnPremise = false,
                ActiveDirectoryServiceEndpointResourceId = "https://management.core.windows.net/",
                AdTenant = "common",
                GalleryUrl = null,
                ManagementPortalUrl = "https://portal.azure.com",
                ServiceManagementUrl = "https://management.core.windows.net/",
                PublishSettingsFileUrl = "https://go.microsoft.com/fwlink/?LinkID=301775",
                ResourceManagerUrl = "https://management.azure.com/",
                SqlDatabaseDnsSuffix = ".database.windows.net",
                StorageEndpointSuffix = "core.windows.net",
                ActiveDirectoryAuthority = "https://login.microsoftonline.com",
                GraphUrl = "https://graph.windows.net/",
                GraphEndpointResourceId = "https://graph.windows.net/",
                TrafficManagerDnsSuffix = "trafficmanager.net",
                AzureKeyVaultDnsSuffix = "vault.azure.net",
                DataLakeEndpointResourceId = "https://datalake.azure.net/",
                AzureDataLakeStoreFileSystemEndpointSuffix = "azuredatalakestore.net",
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = "azuredatalakeanalytics.net",
                AzureKeyVaultServiceEndpointResourceId = "https://vault.azure.net",
                ContainerRegistryEndpointSuffix = "azurecr.io",
                AzureOperationalInsightsEndpointResourceId = "https://api.loganalytics.io",
                AzureOperationalInsightsEndpoint = "https://api.loganalytics.io/v1",
                AzureAnalysisServicesEndpointSuffix = "asazure.windows.net",
                AnalysisServicesEndpointResourceId = "https://region.asazure.windows.net",
                AzureAttestationServiceEndpointSuffix = "attest.azure.net",
                AzureAttestationServiceEndpointResourceId = "https://attest.azure.net",
                AzureSynapseAnalyticsEndpointSuffix = "dev.azuresynapse.net",
                AzureSynapseAnalyticsEndpointResourceId = "https://dev.azuresynapse.net",
                VersionProfiles = {},

                BatchEndpointResourceId = "https://batch.core.windows.net/",
            };
            env.SetProperty("OperationalInsightsEndpoint", "https://api.loganalytics.io/v1");
            env.SetProperty("OperationalInsightsEndpointResourceId", "https://api.loganalytics.io");
            env.SetProperty("AzureAnalysisServicesEndpointSuffix", "asazure.windows.net");
            env.SetProperty("AnalysisServicesEndpointResourceId", "https://region.asazure.windows.net");
            env.SetProperty("AzureAttestationServiceEndpointSuffix", "attest.azure.net");
            env.SetProperty("AzureAttestationServiceEndpointResourceId", "https://attest.azure.net");
            env.SetProperty("AzureSynapseAnalyticsEndpointSuffix", "dev.azuresynapse.net");
            env.SetProperty("AzureSynapseAnalyticsEndpointResourceId", "https://dev.azuresynapse.net");
            env.SetProperty("ManagedHsmServiceEndpointResourceId", "https://managedhsm.azure.net");
            env.SetProperty("ManagedHsmServiceEndpointSuffix", "managedhsm.azure.net");
            env.SetProperty("MicrosoftGraphEndpointResourceId", "https://graph.microsoft.com/");
            env.SetProperty("MicrosoftGraphUrl", "https://graph.microsoft.com");
            env.SetProperty("AzurePurviewEndpointSuffix", "purview.azure.net");
            env.SetProperty("AzurePurviewEndpointResourceId", "https://purview.azure.net");
            env.SetProperty("AzureAppConfigurationEndpointSuffix", "azconfig.io");
            env.SetProperty("AzureAppConfigurationEndpointResourceId", "https://azconfig.io");
            env.SetProperty("ContainerRegistryEndpointResourceId", "https://management.azure.com");
            env.SetProperty("AzureCommunicationEmailEndpointSuffix", "communication.azure.com");
            env.SetProperty("AzureCommunicationEmailEndpointResourceId", "https://communication.azure.com");
            return env;
        }

        public static PSAzureEnvironment GetAzureChinaCloudEndpoints()
        {
            var env = new PSAzureEnvironment()
            {
                Name = "AzureChinaCloud",
                Type = "Built-in",
                EnableAdfsAuthentication = false,
                OnPremise = false,
                ActiveDirectoryServiceEndpointResourceId = "https://management.core.chinacloudapi.cn/",
                AdTenant = "Common",
                GalleryUrl = "https://gallery.azure.com/",
                ManagementPortalUrl = "https://portal.azure.cn/",
                ServiceManagementUrl = "https://management.core.chinacloudapi.cn/",
                PublishSettingsFileUrl = "https://go.microsoft.com/fwlink/?LinkID=301776",
                ResourceManagerUrl = "https://management.chinacloudapi.cn/",
                SqlDatabaseDnsSuffix = ".database.chinacloudapi.cn",
                StorageEndpointSuffix = "core.chinacloudapi.cn",
                ActiveDirectoryAuthority = "https://login.chinacloudapi.cn/",
                GraphUrl = "https://graph.chinacloudapi.cn/",
                GraphEndpointResourceId = "https://graph.chinacloudapi.cn/",
                TrafficManagerDnsSuffix = "trafficmanager.cn",
                AzureKeyVaultDnsSuffix = "vault.azure.cn",
                DataLakeEndpointResourceId = null,
                AzureDataLakeStoreFileSystemEndpointSuffix = null,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                AzureKeyVaultServiceEndpointResourceId = "https://vault.azure.cn",
                ContainerRegistryEndpointSuffix = "azurecr.cn",
                AzureOperationalInsightsEndpointResourceId = "https://api.loganalytics.azure.cn",
                AzureOperationalInsightsEndpoint = "https://api.loganalytics.azure.cn/v1",
                AzureAnalysisServicesEndpointSuffix = "asazure.chinacloudapi.cn",
                AnalysisServicesEndpointResourceId = "https://region.asazure.chinacloudapi.cn",
                AzureAttestationServiceEndpointSuffix = null,
                AzureAttestationServiceEndpointResourceId = null,
                AzureSynapseAnalyticsEndpointSuffix = "dev.azuresynapse.azure.cn",
                AzureSynapseAnalyticsEndpointResourceId = "https://dev.azuresynapse.azure.cn",
                VersionProfiles = {},
                BatchEndpointResourceId = "https://batch.chinacloudapi.cn/",
            };
            env.SetProperty("OperationalInsightsEndpoint", "https://api.loganalytics.azure.cn/v1");
            env.SetProperty("OperationalInsightsEndpointResourceId", "https://api.loganalytics.azure.cn");
            env.SetProperty("AzureAnalysisServicesEndpointSuffix", "asazure.chinacloudapi.cn");
            env.SetProperty("AnalysisServicesEndpointResourceId", "https://region.asazure.chinacloudapi.cn");
            env.SetProperty("AzureSynapseAnalyticsEndpointSuffix", "dev.azuresynapse.azure.cn");
            env.SetProperty("AzureSynapseAnalyticsEndpointResourceId", "https://dev.azuresynapse.azure.cn");
            env.SetProperty("ManagedHsmServiceEndpointResourceId", "https://managedhsm.azure.cn");
            env.SetProperty("ManagedHsmServiceEndpointSuffix", "managedhsm.azure.cn");
            env.SetProperty("MicrosoftGraphEndpointResourceId", "https://microsoftgraph.chinacloudapi.cn/");
            env.SetProperty("MicrosoftGraphUrl", "https://microsoftgraph.chinacloudapi.cn");
            env.SetProperty("ContainerRegistryEndpointResourceId", "https://management.chinacloudapi.cn");
            return env;
        }

        public static PSAzureEnvironment GetAzureUSGovernmentEndpoints()
        {
            var env = new PSAzureEnvironment()
            {
                Name = "AzureUSGovernment",
                Type = "Built-in",
                EnableAdfsAuthentication = false,
                OnPremise = false,
                ActiveDirectoryServiceEndpointResourceId = "https://management.core.usgovcloudapi.net/",
                AdTenant = "Common",
                GalleryUrl = "https://gallery.azure.com/",
                ManagementPortalUrl = "https://portal.azure.us/",
                ServiceManagementUrl = "https://management.core.usgovcloudapi.net/",
                PublishSettingsFileUrl = "https://manage.windowsazure.us/publishsettings/index",
                ResourceManagerUrl = "https://management.usgovcloudapi.net/",
                SqlDatabaseDnsSuffix = ".database.usgovcloudapi.net",
                StorageEndpointSuffix = "core.usgovcloudapi.net",
                ActiveDirectoryAuthority = "https://login.microsoftonline.us/",
                GraphUrl = "https://graph.windows.net/",
                GraphEndpointResourceId = "https://graph.windows.net/",
                TrafficManagerDnsSuffix = "usgovtrafficmanager.net",
                AzureKeyVaultDnsSuffix = "vault.usgovcloudapi.net",
                DataLakeEndpointResourceId = null,
                AzureDataLakeStoreFileSystemEndpointSuffix = null,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                AzureKeyVaultServiceEndpointResourceId = "https://vault.usgovcloudapi.net",
                ContainerRegistryEndpointSuffix = "azurecr.us",
                AzureOperationalInsightsEndpointResourceId = "https://api.loganalytics.us",
                AzureOperationalInsightsEndpoint = "https://api.loganalytics.us/v1",
                AzureAnalysisServicesEndpointSuffix = "asazure.usgovcloudapi.net",
                AnalysisServicesEndpointResourceId = "https://region.asazure.usgovcloudapi.net",
                AzureAttestationServiceEndpointSuffix = null,
                AzureAttestationServiceEndpointResourceId = null,
                AzureSynapseAnalyticsEndpointSuffix = "dev.azuresynapse.usgovcloudapi.net",
                AzureSynapseAnalyticsEndpointResourceId = "https://dev.azuresynapse.usgovcloudapi.net",
                VersionProfiles = {},
                BatchEndpointResourceId = "https://batch.core.usgovcloudapi.net/"
            };
            env.SetProperty("OperationalInsightsEndpoint", "https://api.loganalytics.us/v1");
            env.SetProperty("OperationalInsightsEndpointResourceId", "https://api.loganalytics.us");
            env.SetProperty("AzureAnalysisServicesEndpointSuffix", "asazure.usgovcloudapi.net");
            env.SetProperty("AnalysisServicesEndpointResourceId", "https://region.asazure.usgovcloudapi.net");
            env.SetProperty("AzureSynapseAnalyticsEndpointSuffix", "dev.azuresynapse.usgovcloudapi.net");
            env.SetProperty("AzureSynapseAnalyticsEndpointResourceId", "https://dev.azuresynapse.usgovcloudapi.net");
            env.SetProperty("ManagedHsmServiceEndpointResourceId", "https://managedhsm.usgovcloudapi.net");
            env.SetProperty("ManagedHsmServiceEndpointSuffix", "managedhsm.usgovcloudapi.net");
            env.SetProperty("MicrosoftGraphEndpointResourceId", "https://graph.microsoft.us/");
            env.SetProperty("MicrosoftGraphUrl", "https://graph.microsoft.us");
            env.SetProperty("ContainerRegistryEndpointResourceId", "https://management.usgovcloudapi.net");
            return env;
        }

        public static bool IsAbsolutelyEqual(this PSAzureEnvironment source, PSAzureEnvironment target)
        {
            bool equal = true;
            var properties = target.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                if (property.PropertyType == typeof(string))
                {
                    equal = (0 == string.Compare(property.GetValue(target) as string,
                        source.GetType().GetProperty(propertyName).GetValue(source) as string));
                    if (!equal)
                    {
                        break;
                    }
                }
                else if (0 == string.Compare(property.Name, "ExtendedProperties"))
                {
                    equal = source.ExtendedProperties.Count == target.ExtendedProperties.Count;
                    if (equal)
                    {
                        foreach (var extendedProperty in target.ExtendedProperties)
                        {
                            equal = source.ExtendedProperties.ContainsKey(extendedProperty.Key);
                            if (!equal)
                            {
                                break;
                            }
                            equal = (0 == string.Compare(extendedProperty.Value, source.ExtendedProperties[extendedProperty.Key]));
                            if (!equal)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return equal;
        }
    }
}
