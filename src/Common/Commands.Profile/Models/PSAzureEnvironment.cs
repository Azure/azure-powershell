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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    public class PSAzureEnvironment
    {
        public static implicit operator AzureEnvironment(PSAzureEnvironment environment)
        {
            var newEnvironment = new AzureEnvironment
            {
                Name = environment.Name,
                OnPremise = environment.EnableAdfsAuthentication
            };
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId] =
                environment.ActiveDirectoryServiceEndpointResourceId;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.AdTenant] = environment.AdTenant;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.Gallery] = environment.GalleryUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl] = environment.ManagementPortalUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement] = environment.ServiceManagementUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl] =
                environment.PublishSettingsFileUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ResourceManager] = environment.ResourceManagerUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix] = environment.SqlDatabaseDnsSuffix;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix] =
                environment.StorageEndpointSuffix;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.Graph] = environment.GraphUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.TrafficManagerDnsSuffix] =
                environment.TrafficManagerDnsSuffix;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix] =
                environment.AzureKeyVaultDnsSuffix;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId] =
                environment.AzureKeyVaultServiceEndpointResourceId;
            return newEnvironment;
        }

        public static implicit operator PSAzureEnvironment(AzureEnvironment environment)
        {
            return new PSAzureEnvironment(environment);
        }

        public PSAzureEnvironment()
        {
        }

        public PSAzureEnvironment(AzureEnvironment environment)
        {
            Name = environment.Name;
            EnableAdfsAuthentication = environment.OnPremise;
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId))
            {
                ActiveDirectoryServiceEndpointResourceId =
                    environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.AdTenant))
            {
                AdTenant = environment.Endpoints[AzureEnvironment.Endpoint.AdTenant];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.Gallery))
            {
                GalleryUrl =
                    environment.Endpoints[AzureEnvironment.Endpoint.Gallery];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ManagementPortalUrl))
            {
                ManagementPortalUrl =
                    environment.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ServiceManagement))
            {
                ServiceManagementUrl =
                    environment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.PublishSettingsFileUrl))
            {
                PublishSettingsFileUrl =
                    environment.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.ResourceManager))
            {
                ResourceManagerUrl =
                    environment.Endpoints[AzureEnvironment.Endpoint.ResourceManager];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix))
            {
                SqlDatabaseDnsSuffix =
                    environment.Endpoints[AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.StorageEndpointSuffix))
            {
                StorageEndpointSuffix =
                    environment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.Graph))
            {
                GraphUrl =
                    environment.Endpoints[AzureEnvironment.Endpoint.Graph];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix))
            {
                TrafficManagerDnsSuffix =
                    environment.Endpoints[AzureEnvironment.Endpoint.TrafficManagerDnsSuffix];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix))
            {
                AzureKeyVaultDnsSuffix =
                    environment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix];
            }
            if (environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId))
            {
                AzureKeyVaultServiceEndpointResourceId =
                    environment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId];
            }
        }

        public string Name { get; set; }
        public bool EnableAdfsAuthentication { get; set; }
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }
        public string AdTenant { get; set; }
        public string GalleryUrl { get; set; }
        public string ManagementPortalUrl { get; set; }
        public string ServiceManagementUrl { get; set; }
        public string PublishSettingsFileUrl { get; set; }
        public string ResourceManagerUrl { get; set; }
        public string SqlDatabaseDnsSuffix { get; set; }
        public string StorageEndpointSuffix { get; set; }
        public string ActiveDirectoryAuthority { get; set; }
        public string GraphUrl { get; set; }
        public string TrafficManagerDnsSuffix { get; set; }
        public string AzureKeyVaultDnsSuffix { get; set; }
        public string AzureKeyVaultServiceEndpointResourceId { get; set; }
    }
}
