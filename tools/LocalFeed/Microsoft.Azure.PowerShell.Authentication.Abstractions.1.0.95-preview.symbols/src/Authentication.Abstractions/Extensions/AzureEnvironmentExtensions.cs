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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Properties;
using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Convenience methods for environments
    /// </summary>
    public static class AzureEnvironmentExtensions
    {
        /// <summary>
        /// Try to get the uri from the environment mathcing the given name
        /// </summary>
        /// <param name="environment">The environment to get the value from</param>
        /// <param name="endpointName">The name of the endpoint to attempt to get</param>
        /// <param name="endpoint">The returned endpoint value as a Uri, or null if no endpoint was found</param>
        /// <returns>true if the endpoint was found, otherwise false</returns>
        public static bool TryGetEndpointUrl(this IAzureEnvironment environment, string endpointName, out Uri endpoint)
        {
            bool result = true;
            endpoint = null;
            switch(endpointName)
            {
                case AzureEnvironment.Endpoint.ActiveDirectory:
                    endpoint = new Uri(environment.ActiveDirectoryAuthority);
                    break;
                case AzureEnvironment.Endpoint.Gallery:
                    endpoint = new Uri(environment.GalleryUrl);
                    break;
                case AzureEnvironment.Endpoint.Graph:
                    endpoint = new Uri(environment.GraphUrl);
                    break;
                case AzureEnvironment.Endpoint.ManagementPortalUrl:
                    endpoint = new Uri(environment.ManagementPortalUrl);
                    break;
                case AzureEnvironment.Endpoint.PublishSettingsFileUrl:
                    endpoint = new Uri(environment.PublishSettingsFileUrl);
                    break;
                case AzureEnvironment.Endpoint.ResourceManager:
                    endpoint = new Uri(environment.ResourceManagerUrl);
                    break;
                case AzureEnvironment.Endpoint.ServiceManagement:
                    endpoint = new Uri(environment.ServiceManagementUrl);
                    break;
                case AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId:
                    endpoint = new Uri(environment.ActiveDirectoryServiceEndpointResourceId);
                    break;
                case AzureEnvironment.Endpoint.GraphEndpointResourceId:
                    endpoint = new Uri(environment.GraphEndpointResourceId);
                    break;
                case AzureEnvironment.Endpoint.DataLakeEndpointResourceId:
                    endpoint = new Uri(environment.DataLakeEndpointResourceId);
                    break;
                case AzureEnvironment.Endpoint.BatchEndpointResourceId:
                    endpoint = new Uri(environment.BatchEndpointResourceId);
                    break;
                default:
                    result = environment.IsPropertySet(endpointName);
                    if (result)
                    {
                        endpoint = new Uri(environment.GetProperty(endpointName));
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// Get non-endpoint values of the environment, such as resource strings and dns suffixes for servides.
        /// </summary>
        /// <param name="environment">The environment to check for the given property</param>
        /// <param name="endpointName">The name of the property to check for</param>
        /// <param name="propertyValue">The value of the property, if found in the environment, or null if not found</param>
        /// <returns>True if the property value is found in the environment, otherwise false.</returns>
        public static bool TryGetEndpointString(this IAzureEnvironment environment, string endpointName, out string propertyValue)
        {
            propertyValue = null;
            if (environment != null)
            {
                switch (endpointName)
                {
                    case AzureEnvironment.Endpoint.AdTenant:
                        propertyValue = environment.AdTenant;
                        break;
                    case AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId:
                        propertyValue = environment.ActiveDirectoryServiceEndpointResourceId;
                        break;
                    case AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix:
                        propertyValue = environment.AzureKeyVaultDnsSuffix;
                        break;
                    case AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId:
                        propertyValue = environment.AzureKeyVaultServiceEndpointResourceId;
                        break;
                    case AzureEnvironment.Endpoint.GraphEndpointResourceId:
                        propertyValue = environment.GraphEndpointResourceId;
                        break;
                    case AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix:
                        propertyValue = environment.SqlDatabaseDnsSuffix;
                        break;
                    case AzureEnvironment.Endpoint.StorageEndpointSuffix:
                        propertyValue = environment.StorageEndpointSuffix;
                        break;
                    case AzureEnvironment.Endpoint.TrafficManagerDnsSuffix:
                        propertyValue = environment.TrafficManagerDnsSuffix;
                        break;
                    case AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix:
                        propertyValue = environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix;
                        break;
                    case AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix:
                        propertyValue = environment.AzureDataLakeStoreFileSystemEndpointSuffix;
                        break;
                    case AzureEnvironment.Endpoint.DataLakeEndpointResourceId:
                        propertyValue = environment.DataLakeEndpointResourceId;
                        break;
                    case AzureEnvironment.Endpoint.ActiveDirectory:
                        propertyValue = environment.ActiveDirectoryAuthority;
                        break;
                    case AzureEnvironment.Endpoint.Gallery:
                        propertyValue = environment.GalleryUrl;
                        break;
                    case AzureEnvironment.Endpoint.Graph:
                        propertyValue = environment.GraphUrl;
                        break;
                    case AzureEnvironment.Endpoint.ManagementPortalUrl:
                        propertyValue = environment.ManagementPortalUrl;
                        break;
                    case AzureEnvironment.Endpoint.PublishSettingsFileUrl:
                        propertyValue = environment.PublishSettingsFileUrl;
                        break;
                    case AzureEnvironment.Endpoint.ResourceManager:
                        propertyValue = environment.ResourceManagerUrl;
                        break;
                    case AzureEnvironment.Endpoint.ServiceManagement:
                        propertyValue = environment.ServiceManagementUrl;
                        break;
                    case AzureEnvironment.Endpoint.BatchEndpointResourceId:
                        propertyValue = environment.BatchEndpointResourceId;
                        break;
                    default:
                        // get property from the extended properties of the environment
                        propertyValue = environment.GetProperty(endpointName);
                        break;
                }
            }

            return propertyValue != null;
        }

        /// <summary>
        /// Get the url in this environment for the given named endpoint
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="endpoint"></param>
        /// <returns>The Uri of the given endpoint, or null if it is not set in the given environment</returns>
        public static Uri GetEndpointAsUri(this IAzureEnvironment environment, string endpoint)
        {
            Uri endpointUri;

            if (environment.TryGetEndpointUrl(endpoint, out endpointUri))
            {
                return endpointUri;
            }

            return null;
        }

        /// <summary>
        /// Get the string endpoint value from this environemtn for the given named endpoint
        /// </summary>
        /// <param name="environment">The environemnt to use</param>
        /// <param name="endpoint">The endpoint to get from the environemnt.</param>
        /// <returns>The value of the given endpoint in the environment if found, or null if not.</returns>
        public static string GetEndpoint(this IAzureEnvironment environment, string endpoint)
        {
            string endpointValue;
            if (environment.TryGetEndpointString(endpoint, out endpointValue))
            {
                return endpointValue;
            }

            return null;
        }

        /// <summary>
        /// Set the given named endpoint in this environment to the provided value
        /// </summary>
        /// <param name="environment">The environment to change</param>
        /// <param name="endpointName">The named endpoint to update</param>
        /// <param name="propertyValue">The value to set the named endpoint to in the given environment</param>
        public static void SetEndpoint(this IAzureEnvironment environment, string endpointName, string propertyValue)
        {
            if (!string.IsNullOrWhiteSpace(propertyValue))
            {
                switch (endpointName)
                {
                    case AzureEnvironment.Endpoint.AdTenant:
                        environment.AdTenant = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId:
                        environment.ActiveDirectoryServiceEndpointResourceId = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix:
                        environment.AzureKeyVaultDnsSuffix = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId:
                        environment.AzureKeyVaultServiceEndpointResourceId = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.GraphEndpointResourceId:
                        environment.GraphEndpointResourceId = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix:
                        environment.SqlDatabaseDnsSuffix = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.StorageEndpointSuffix:
                        environment.StorageEndpointSuffix = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.TrafficManagerDnsSuffix:
                        environment.TrafficManagerDnsSuffix = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix:
                        environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix:
                        environment.AzureDataLakeStoreFileSystemEndpointSuffix = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.DataLakeEndpointResourceId:
                        environment.DataLakeEndpointResourceId = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.BatchEndpointResourceId:
                        environment.BatchEndpointResourceId = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.ActiveDirectory:
                        environment.ActiveDirectoryAuthority = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.Gallery:
                        environment.GalleryUrl = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.Graph:
                        environment.GraphUrl = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.ManagementPortalUrl:
                        environment.ManagementPortalUrl = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.PublishSettingsFileUrl:
                        environment.PublishSettingsFileUrl = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.ResourceManager:
                        environment.ResourceManagerUrl = propertyValue;
                        break;
                    case AzureEnvironment.Endpoint.ServiceManagement:
                        environment.ServiceManagementUrl = propertyValue;
                        break;
                    case AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId:
                        environment.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId, propertyValue);
                        break;
                    case AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint:
                        environment.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint, propertyValue);
                        break;
                }
            }
        }

        /// <summary>
        /// Get the token audience for the given named endpoint
        /// </summary>
        /// <param name="environment">The environment to check</param>
        /// <param name="targetEndpoint">The named endpoint to target</param>
        /// <returns>The correct token audience for tokens bound for the given endpoint.</returns>
        public static string GetTokenAudience(this IAzureEnvironment environment, string targetEndpoint)
        {
            string resource;
            switch (targetEndpoint)
            {
                case AzureEnvironment.Endpoint.Graph:
                    resource = AzureEnvironment.Endpoint.GraphEndpointResourceId;
                    break;
                case AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix:
                case AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix:
                case AzureEnvironment.Endpoint.DataLakeEndpointResourceId:
                    resource = AzureEnvironment.Endpoint.DataLakeEndpointResourceId;
                    break;
                case AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix:
                case AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId:
                    resource = AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId;
                    break;
                case AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint:
                case AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId:
                    resource = AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId;
                    break;
                default:
                    resource = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId;
                    break;
            }

            return resource;
        }

        /// <summary>
        /// Determine if the given endpoint is set in the given environment
        /// </summary>
        /// <param name="environment">The environment to check</param>
        /// <param name="endpoint">The named endpoint to search for</param>
        /// <returns>True if the endpoint is set to a non-null value in the environment, otherwise false</returns>
        public static bool IsEndpointSet(this IAzureEnvironment environment, string endpoint)
        {
            string endpointValue;
            return environment.TryGetEndpointString(endpoint, out endpointValue);
        }

        /// <summary>
        /// Determine if the given endpoint is set to the provided value
        /// </summary>
        /// <param name="environment">The environment to search</param>
        /// <param name="endpoint">The endpoint to check</param>
        /// <param name="url">The value to check for</param>
        /// <returns>True if the endpoint is set to the proviuded value, otherwise false</returns>
        public static bool IsEndpointSetToValue(this IAzureEnvironment environment, string endpoint, string url)
        {
            if (url == null && !environment.IsEndpointSet(endpoint))
            {
                return true;
            }
            if (url != null && environment.IsEndpointSet(endpoint))
            {
                return environment.GetEndpoint(endpoint)
                    .Trim(new[] { '/' })
                    .Equals(url.Trim(new[] { '/' }), StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        /// <summary>
        /// Get the given endpoint suffix in the given environment
        /// </summary>
        /// <param name="environment">The environment to check</param>
        /// <param name="endpointSuffix">The nemaed endpoint suffix to search for</param>
        /// <returns>The value of the endpoint suffix, or null if it is not set</returns>
        public static string GetEndpointSuffix(this IAzureEnvironment environment, string endpointSuffix)
        {
            string suffix;
            if (environment.TryGetEndpointString(endpointSuffix, out suffix))
            {
                return suffix;
            }

            return null;
        }


        /// <summary>
        /// Gets the management portal URI with a particular realm suffix if supplied
        /// </summary>
        /// <param name="realm">Realm for user's account</param>
        /// <returns>Url to management portal.</returns>
        public static string GetManagementPortalUrlWithRealm(this IAzureEnvironment environment, string realm = null)
        {
            if (realm != null)
            {
                realm = string.Format(Resources.PublishSettingsFileRealmFormat, realm);
            }
            else
            {
                realm = string.Empty;
            }

            return  environment.ManagementPortalUrl + realm;
        }

        /// <summary>
        /// Get the publish settings file download url with a realm suffix if needed.
        /// </summary>
        /// <param name="realm">Realm for user's account</param>
        /// <returns>Url to publish settings file</returns>
        public static string GetPublishSettingsFileUrlWithRealm(this IAzureEnvironment environment, string realm = null)
        {
            if (realm != null)
            {
                realm = string.Format(Resources.PublishSettingsFileRealmFormat, realm);
            }
            else
            {
                realm = string.Empty;
            }
            return environment.PublishSettingsFileUrl + realm;
        }

        public static void CopyFrom(this IAzureEnvironment environment, IAzureEnvironment other)
        {
            if (environment != null && other != null)
            {
                environment.Name = other.Name;
                environment.OnPremise = other.OnPremise;
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId))
                {
                    environment.ActiveDirectoryServiceEndpointResourceId = other.ActiveDirectoryServiceEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AdTenant))
                {
                    environment.AdTenant = other.AdTenant;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.Gallery))
                {
                    environment.GalleryUrl = other.GalleryUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ManagementPortalUrl))
                {
                    environment.ManagementPortalUrl = other.ManagementPortalUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ServiceManagement))
                {
                    environment.ServiceManagementUrl = other.ServiceManagementUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.PublishSettingsFileUrl))
                {
                    environment.PublishSettingsFileUrl = other.PublishSettingsFileUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ResourceManager))
                {
                    environment.ResourceManagerUrl = other.ResourceManagerUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix))
                {
                    environment.SqlDatabaseDnsSuffix = other.SqlDatabaseDnsSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.StorageEndpointSuffix))
                {
                    environment.StorageEndpointSuffix = other.StorageEndpointSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectory))
                {
                    environment.ActiveDirectoryAuthority = other.ActiveDirectoryAuthority;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.Graph))
                {
                    environment.GraphUrl = other.GraphUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.GraphEndpointResourceId))
                {
                    environment.GraphEndpointResourceId = other.GraphEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix))
                {
                    environment.TrafficManagerDnsSuffix = other.TrafficManagerDnsSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix))
                {
                    environment.AzureKeyVaultDnsSuffix = other.AzureKeyVaultDnsSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix))
                {
                    environment.AzureDataLakeStoreFileSystemEndpointSuffix = other.AzureDataLakeStoreFileSystemEndpointSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix))
                {
                    environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix =
                         other.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.DataLakeEndpointResourceId))
                {
                    environment.DataLakeEndpointResourceId = other.DataLakeEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId))
                {
                    environment.AzureKeyVaultServiceEndpointResourceId =
                         other.AzureKeyVaultServiceEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.BatchEndpointResourceId))
                {
                    environment.BatchEndpointResourceId = other.BatchEndpointResourceId;
                }

                environment.VersionProfiles.Clear();
                foreach (var profile in other.VersionProfiles)
                {
                    environment.VersionProfiles.Add(profile);
                }

                environment.CopyPropertiesFrom(other);
            }

        }

        public static void Update(this IAzureEnvironment environment, IAzureEnvironment other)
        {
            if (environment != null && other != null)
            {
                environment.OnPremise = other.OnPremise;
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId))
                {
                    environment.ActiveDirectoryServiceEndpointResourceId = other.ActiveDirectoryServiceEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AdTenant))
                {
                    environment.AdTenant = other.AdTenant;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.Gallery))
                {
                    environment.GalleryUrl = other.GalleryUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ManagementPortalUrl))
                {
                    environment.ManagementPortalUrl = other.ManagementPortalUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ServiceManagement))
                {
                    environment.ServiceManagementUrl = other.ServiceManagementUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.PublishSettingsFileUrl))
                {
                    environment.PublishSettingsFileUrl = other.PublishSettingsFileUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ResourceManager))
                {
                    environment.ResourceManagerUrl = other.ResourceManagerUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix))
                {
                    environment.SqlDatabaseDnsSuffix = other.SqlDatabaseDnsSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.StorageEndpointSuffix))
                {
                    environment.StorageEndpointSuffix = other.StorageEndpointSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectory))
                {
                    environment.ActiveDirectoryAuthority = other.ActiveDirectoryAuthority;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.Graph))
                {
                    environment.GraphUrl = other.GraphUrl;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.GraphEndpointResourceId))
                {
                    environment.GraphEndpointResourceId = other.GraphEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix))
                {
                    environment.TrafficManagerDnsSuffix = other.TrafficManagerDnsSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix))
                {
                    environment.AzureKeyVaultDnsSuffix = other.AzureKeyVaultDnsSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix))
                {
                    environment.AzureDataLakeStoreFileSystemEndpointSuffix = other.AzureDataLakeStoreFileSystemEndpointSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix))
                {
                    environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix =
                         other.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId))
                {
                    environment.AzureKeyVaultServiceEndpointResourceId =
                         other.AzureKeyVaultServiceEndpointResourceId;
                }
                if (other.IsEndpointSet(AzureEnvironment.Endpoint.DataLakeEndpointResourceId))
                {
                    environment.DataLakeEndpointResourceId = other.DataLakeEndpointResourceId;
                }

                foreach (var profile in other.VersionProfiles)
                {
                    if (!environment.VersionProfiles.Contains(profile))
                    {
                        environment.VersionProfiles.Add(profile);
                    }
                }

                environment.UpdateProperties(other);
            }

        }

    }

}
