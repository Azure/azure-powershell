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
                    endpoint = environment.ActiveDirectory;
                    break;
                case AzureEnvironment.Endpoint.Gallery:
                    endpoint = environment.Gallery;
                    break;
                case AzureEnvironment.Endpoint.Graph:
                    endpoint = environment.Graph;
                    break;
                case AzureEnvironment.Endpoint.ManagementPortalUrl:
                    endpoint = environment.ManagementPortalUrl;
                    break;
                case AzureEnvironment.Endpoint.PublishSettingsFileUrl:
                    endpoint = environment.PublishSettingsFileUrl;
                    break;
                case AzureEnvironment.Endpoint.ResourceManager:
                    endpoint = environment.ResourceManager;
                    break;
                case AzureEnvironment.Endpoint.ServiceManagement:
                    endpoint = environment.ServiceManagement;
                    break;
                default:
                    result = false;
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
            bool result = true;
            propertyValue = null;
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
                case AzureEnvironment.Endpoint.ActiveDirectory:
                    propertyValue = environment.ActiveDirectory.ToString();
                    break;
                case AzureEnvironment.Endpoint.Gallery:
                    propertyValue = environment.Gallery.ToString();
                    break;
                case AzureEnvironment.Endpoint.Graph:
                    propertyValue = environment.Graph.ToString();
                    break;
                case AzureEnvironment.Endpoint.ManagementPortalUrl:
                    propertyValue = environment.ManagementPortalUrl.ToString();
                    break;
                case AzureEnvironment.Endpoint.PublishSettingsFileUrl:
                    propertyValue = environment.PublishSettingsFileUrl.ToString();
                    break;
                case AzureEnvironment.Endpoint.ResourceManager:
                    propertyValue = environment.ResourceManager.ToString();
                    break;
                case AzureEnvironment.Endpoint.ServiceManagement:
                    propertyValue = environment.ServiceManagement.ToString();
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
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
                case AzureEnvironment.Endpoint.ActiveDirectory:
                    environment.ActiveDirectory = new Uri(propertyValue);
                    break;
                case AzureEnvironment.Endpoint.Gallery:
                    environment.Gallery = new Uri(propertyValue);
                    break;
                case AzureEnvironment.Endpoint.Graph:
                    environment.Graph = new Uri(propertyValue);
                    break;
                case AzureEnvironment.Endpoint.ManagementPortalUrl:
                    environment.ManagementPortalUrl = new Uri(propertyValue);
                    break;
                case AzureEnvironment.Endpoint.PublishSettingsFileUrl:
                    environment.PublishSettingsFileUrl = new Uri(propertyValue);
                    break;
                case AzureEnvironment.Endpoint.ResourceManager:
                    environment.ResourceManager = new Uri(propertyValue);
                    break;
                case AzureEnvironment.Endpoint.ServiceManagement:
                    environment.ServiceManagement = new Uri(propertyValue);
                    break;
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
            string resource = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId;
            if (targetEndpoint == AzureEnvironment.Endpoint.Graph)
            {
                resource = AzureEnvironment.Endpoint.GraphEndpointResourceId;
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

            return  environment. ManagementPortalUrl + realm;
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
    }

}
