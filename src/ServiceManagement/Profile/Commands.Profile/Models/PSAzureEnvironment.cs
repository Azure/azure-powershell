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
using System;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    /// <summary>
    /// Settings and endpoints for management of Azure or Azure Stack services.
    /// </summary>
    public class PSAzureEnvironment
    {
        /// <summary>
        /// Convert the PowerShell representation of environment to the internal representation.
        /// </summary>
        /// <param name="environment">The PowerShell environment to convert.</param>
        /// <returns>The internal representation of the Azure environment, as used by .Net authentication libraries.</returns>
        public static implicit operator AzureEnvironment(PSAzureEnvironment environment)
        {
            var newEnvironment = new AzureEnvironment
            {
                Name = environment.Name,
                OnPremise = environment.EnableAdfsAuthentication
            };
            newEnvironment.ActiveDirectoryServiceEndpointResourceId =
                environment.ActiveDirectoryServiceEndpointResourceId;
            newEnvironment.AdTenant = environment.AdTenant;
            newEnvironment.Gallery = new Uri(environment.GalleryUrl);
            newEnvironment.ManagementPortalUrl = new Uri(environment.ManagementPortalUrl);
            newEnvironment.ServiceManagement = new Uri(environment.ServiceManagementUrl);
            newEnvironment.PublishSettingsFileUrl =
                new Uri(environment.PublishSettingsFileUrl);
            newEnvironment.ResourceManager = new Uri(environment.ResourceManagerUrl);
            newEnvironment.SqlDatabaseDnsSuffix = environment.SqlDatabaseDnsSuffix;
            newEnvironment.StorageEndpointSuffix =
                environment.StorageEndpointSuffix;
            newEnvironment.Graph = new Uri(environment.GraphUrl);
            newEnvironment.TrafficManagerDnsSuffix =
                environment.TrafficManagerDnsSuffix;
            newEnvironment.AzureKeyVaultDnsSuffix =
                environment.AzureKeyVaultDnsSuffix;
            newEnvironment.AzureKeyVaultServiceEndpointResourceId =
                environment.AzureKeyVaultServiceEndpointResourceId;
            return newEnvironment;
        }

        /// <summary>
        /// Convert the internal representation of Azure libraries to a representation that is more readable for PowerShell.
        /// </summary>
        /// <param name="environment">The internal representation fo the Azure environment.</param>
        /// <returns>The PowerShell;-friendly representation of the environment.</returns>
        public static implicit operator PSAzureEnvironment(AzureEnvironment environment)
        {
            return new PSAzureEnvironment(environment);
        }

        /// <summary>
        /// Initializes a new azure environment.
        /// </summary>
        public PSAzureEnvironment()
        {
        }

        /// <summary>
        /// Initializes a new Azure environment from the given internal representation.
        /// </summary>
        /// <param name="environment">The internal representation of the environment.</param>
        public PSAzureEnvironment(AzureEnvironment environment)
        {
            Name = environment.Name;
            EnableAdfsAuthentication = environment.OnPremise;
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId))
            {
                ActiveDirectoryServiceEndpointResourceId =
                    environment.ActiveDirectoryServiceEndpointResourceId;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.AdTenant))
            {
                AdTenant = environment.AdTenant;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.Gallery))
            {
                GalleryUrl =
                    environment.Gallery.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ManagementPortalUrl))
            {
                ManagementPortalUrl =
                    environment.ManagementPortalUrl.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ServiceManagement))
            {
                ServiceManagementUrl =
                    environment.ServiceManagement.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.PublishSettingsFileUrl))
            {
                PublishSettingsFileUrl =
                    environment.PublishSettingsFileUrl.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ResourceManager))
            {
                ResourceManagerUrl =
                    environment.ResourceManager.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix))
            {
                SqlDatabaseDnsSuffix =
                    environment.SqlDatabaseDnsSuffix;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.StorageEndpointSuffix))
            {
                StorageEndpointSuffix =
                    environment.StorageEndpointSuffix;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectory))
            {
                ActiveDirectoryAuthority =
                    environment.ActiveDirectory.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.Graph))
            {
                GraphUrl =
                    environment.Graph.AbsoluteUri;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix))
            {
                TrafficManagerDnsSuffix =
                    environment.TrafficManagerDnsSuffix;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix))
            {
                AzureKeyVaultDnsSuffix =
                    environment.AzureKeyVaultDnsSuffix;
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId))
            {
                AzureKeyVaultServiceEndpointResourceId =
                    environment.AzureKeyVaultServiceEndpointResourceId;
            }
        }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whther ADFS authentication should be allowed . 
        /// Generally, this is only used in Azure Stack environments.
        /// </summary>
        public bool EnableAdfsAuthentication { get; set; }

        /// <summary>
        /// Gets or sets the expected token audience for authenticating management requests. 
        /// </summary>
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        /// <summary>
        /// Gets or sets the default tenant Id.
        /// </summary>
        public string AdTenant { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the Template Gallery service.
        /// </summary>
        public string GalleryUrl { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the management portal.
        /// </summary>
        public string ManagementPortalUrl { get; set; }

        /// <summary>
        /// Get or sets the Uri of the service management (RDFE) service.
        /// </summary>
        public string ServiceManagementUrl { get; set; }

        /// <summary>
        /// Gets or sets the endpoint of the publish settings download service.
        /// </summary>
        public string PublishSettingsFileUrl { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the Azure Resource Manager (ARM) service.
        /// </summary>
        public string ResourceManagerUrl { get; set; }

        /// <summary>
        /// Gets or sets the Dns suffix used for Sql database servers.
        /// </summary>
        public string SqlDatabaseDnsSuffix { get; set; }

        /// <summary>
        /// Gets or sets the dns suffix of storage services.
        /// </summary>
        public string StorageEndpointSuffix { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the Active Directory authentication endpoint.
        /// </summary>
        public string ActiveDirectoryAuthority { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the Active Directory metadata (Graph) endpoint.
        /// </summary>
        public string GraphUrl { get; set; }

        /// <summary>
        /// Gets or sets the domain name suffix for traffig manager services.
        /// </summary>
        public string TrafficManagerDnsSuffix { get; set; }

        /// <summary>
        /// Gets or sets the domain name suffix for key vault services.
        /// </summary>
        public string AzureKeyVaultDnsSuffix { get; set; }

        /// <summary>
        /// Gets or sets the expected token audience for authenticating requests to the key vault service.
        /// </summary>
        public string AzureKeyVaultServiceEndpointResourceId { get; set; }

        /// <summary>
        /// Determine equality of two PSAzureEnvironment instances.
        /// </summary>
        /// <param name="obj">The instance to compare.</param>
        /// <returns>True if the instances are equivalent, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as PSAzureEnvironment;
            if (other != null)
            {
                return Name == other.Name && EnableAdfsAuthentication == other.EnableAdfsAuthentication
                       && ActiveDirectoryAuthority == other.ActiveDirectoryAuthority
                       && ActiveDirectoryServiceEndpointResourceId == other.ActiveDirectoryServiceEndpointResourceId
                       && AdTenant == other.AdTenant
                       && AzureKeyVaultDnsSuffix == other.AzureKeyVaultDnsSuffix
                       && AzureKeyVaultServiceEndpointResourceId == other.AzureKeyVaultServiceEndpointResourceId
                       && GalleryUrl == other.GalleryUrl
                       && GraphUrl == other.GraphUrl
                       && ManagementPortalUrl == other.ManagementPortalUrl
                       && PublishSettingsFileUrl == other.PublishSettingsFileUrl
                       && ResourceManagerUrl == other.ResourceManagerUrl
                       && ServiceManagementUrl == other.ServiceManagementUrl
                       && StorageEndpointSuffix == other.StorageEndpointSuffix
                       && SqlDatabaseDnsSuffix == other.SqlDatabaseDnsSuffix
                       && TrafficManagerDnsSuffix == other.TrafficManagerDnsSuffix;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
