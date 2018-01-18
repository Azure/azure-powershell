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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Endpoint Uris, authentication bootstrapping information and other metadata required to communicate with a particular azure cloud
    /// </summary>
    public interface IAzureEnvironment : IExtensibleModel
    {
        /// <summary>
        /// The name of the environment
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Determines of the environment use AAD authentication (false) or ADFS authentication (true)
        /// </summary>
        bool OnPremise { get; set; }

        /// <summary>
        /// The RDFE endpoint
        /// </summary>
        string ServiceManagementUrl { get; set; }

        /// <summary>
        /// The Resource Manager endpoint
        /// </summary>
        string ResourceManagerUrl { get; set; }

        /// <summary>
        /// The location fot eh manageemnt portal
        /// </summary>
        string ManagementPortalUrl { get; set; }

        /// <summary>
        /// The location fo the publish settings doenload web application
        /// </summary>
        string PublishSettingsFileUrl { get; set; }

        /// <summary>
        /// The Active Directory authentication endpoint
        /// </summary>
        string ActiveDirectoryAuthority { get; set; }

        /// <summary>
        /// The ARM template gallery endpoint.
        /// </summary>
        string GalleryUrl { get; set; }

        /// <summary>
        /// The Azure Active Directory Graph endpoint
        /// </summary>
        string GraphUrl { get; set; }

        /// <summary>
        /// The token audience required to access the RDFE or ARM endpoints
        /// </summary>
        string ActiveDirectoryServiceEndpointResourceId { get; set; }

        /// <summary>
        /// The domain name suffix for storage services
        /// </summary>
        string StorageEndpointSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for Sql databases
        /// </summary>
        string SqlDatabaseDnsSuffix { get; set; }

        /// <summary>
        /// The domain anme suffix for traffic manager endpoints
        /// </summary>
        string TrafficManagerDnsSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for Azure KeyVault valuts
        /// </summary>
        string AzureKeyVaultDnsSuffix { get; set; }

        /// <summary>
        /// The token audience required for authenticating with Azure KeyVault vaults
        /// </summary>
        string AzureKeyVaultServiceEndpointResourceId { get; set; }

        /// <summary>
        /// The token audience required to authenticate with the Azure Active Directory Graph services
        /// </summary>
        string GraphEndpointResourceId { get; set; }

        /// <summary>
        /// The token audience required to authenticate with the Azure Active Directory Data Lake services
        /// </summary>
        string DataLakeEndpointResourceId { get; set; }

        /// <summary>
        /// The token audience required to authenticate with the Azure Batch service
        /// </summary>
        string BatchEndpointResourceId { get; set; }

        /// <summary>
        ///  The domain name suffix for Azure DataLake Catalog and Job services
        /// </summary>
        string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for Azure Data Lake FileSyattem services
        /// </summary>
        string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }

        /// <summary>
        /// The default Active Directory Tenant
        /// </summary>
        string AdTenant { get; set; }

        /// <summary>
        /// The set of version profile s(service capabilities) supported
        /// </summary>
        IList<string> VersionProfiles { get; }
    }
}
