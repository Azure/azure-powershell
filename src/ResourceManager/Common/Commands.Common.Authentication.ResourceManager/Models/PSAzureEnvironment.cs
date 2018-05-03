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
using Microsoft.Azure.Commands.Profile.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Settings and endpoints for management of Azure or Azure Stack services.
    /// </summary>
    public class PSAzureEnvironment : IAzureEnvironment
    {
        /// <summary>
        /// Convert the PowerShell representation of environment to the internal representation.
        /// </summary>
        /// <param name="environment">The PowerShell environment to convert.</param>
        /// <returns>The internal representation of the Azure environment, as used by .Net authentication libraries.</returns>
        public static implicit operator AzureEnvironment(PSAzureEnvironment environment)
        {
            if (environment == null)
            {
                return null;
            }

            var newEnvironment = new AzureEnvironment();
            newEnvironment.CopyFrom(environment);
            return newEnvironment;
        }

        /// <summary>
        /// Convert the internal representation of Azure libraries to a representation that is more readable for PowerShell.
        /// </summary>
        /// <param name="environment">The internal representation fo the Azure environment.</param>
        /// <returns>The PowerShell;-friendly representation of the environment.</returns>
        public static implicit operator PSAzureEnvironment(AzureEnvironment environment)
        {
            if (environment == null)
            {
                return null;
            }

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
        public PSAzureEnvironment(IAzureEnvironment environment)
        {
            this.CopyFrom(environment);
        }

        /// <summary>
        /// For conversion from serialized PSObjects
        /// </summary>
        /// <param name="other"></param>
        public PSAzureEnvironment(PSObject other)
        {
            if (other == null || other.Properties == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            Name = other.GetProperty<string>(nameof(Name));
            EnableAdfsAuthentication = other.GetProperty<bool>(nameof(EnableAdfsAuthentication));
            OnPremise = other.GetProperty<bool>(nameof(OnPremise));
            ActiveDirectoryAuthority = other.GetProperty<string>(nameof(ActiveDirectoryAuthority));
            ActiveDirectoryServiceEndpointResourceId = other.GetProperty<string>(nameof(ActiveDirectoryServiceEndpointResourceId));
            AdTenant = other.GetProperty<string>(nameof(AdTenant));
            AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = other.GetProperty<string>(nameof(AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix));
            AzureDataLakeStoreFileSystemEndpointSuffix = other.GetProperty<string>(nameof(AzureDataLakeStoreFileSystemEndpointSuffix));
            DataLakeEndpointResourceId = other.GetProperty<string>(nameof(DataLakeEndpointResourceId));
            AzureKeyVaultDnsSuffix = other.GetProperty<string>(nameof(AzureKeyVaultDnsSuffix));
            AzureKeyVaultServiceEndpointResourceId = other.GetProperty<string>(nameof(AzureKeyVaultServiceEndpointResourceId));
            BatchEndpointResourceId = other.GetProperty<string>(nameof(BatchEndpointResourceId));
            GalleryUrl = other.GetProperty<string>(nameof(GalleryUrl));
            GraphEndpointResourceId = other.GetProperty<string>(nameof(GraphEndpointResourceId));
            GraphUrl = other.GetProperty<string>(nameof(GraphUrl));
            ManagementPortalUrl = other.GetProperty<string>(nameof(ManagementPortalUrl));
            PublishSettingsFileUrl = other.GetProperty<string>(nameof(PublishSettingsFileUrl));
            ResourceManagerUrl = other.GetProperty<string>(nameof(ResourceManagerUrl));
            ServiceManagementUrl = other.GetProperty<string>(nameof(ServiceManagementUrl));
            SqlDatabaseDnsSuffix = other.GetProperty<string>(nameof(SqlDatabaseDnsSuffix));
            StorageEndpointSuffix = other.GetProperty<string>(nameof(StorageEndpointSuffix));
            TrafficManagerDnsSuffix = other.GetProperty<string>(nameof(TrafficManagerDnsSuffix));
            AzureOperationalInsightsEndpointResourceId =
                other.GetProperty<string>(nameof(AzureOperationalInsightsEndpointResourceId));
            AzureOperationalInsightsEndpoint = other.GetProperty<string>(nameof(AzureOperationalInsightsEndpoint));
            VersionProfiles.Populate(nameof(VersionProfiles), other);
            this.PopulateExtensions(other);
        }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ADFS authentication should be allowed . 
        /// Generally, this is only used in Azure Stack environments.
        /// </summary>
        public bool EnableAdfsAuthentication { get; set; }

        public bool OnPremise
        {
            get
            {
                return EnableAdfsAuthentication;
            }
            set
            {
                EnableAdfsAuthentication = value;
            }
        }

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
        /// Gets or sets the resource Id to use for contacting the Graph endpoint
        /// </summary>
        public string GraphEndpointResourceId { get; set; }

        /// <summary>
        /// Gets or sets the domain name suffix for traffig manager services.
        /// </summary>
        public string TrafficManagerDnsSuffix { get; set; }

        /// <summary>
        /// Gets or sets the domain name suffix for key vault services.
        /// </summary>
        public string AzureKeyVaultDnsSuffix { get; set; }

        /// <summary>
        /// Gets or sets the resource Id to use for contacting the Data Lake services endpoint
        /// </summary>
        public string DataLakeEndpointResourceId { get; set; }

        /// <summary>
        /// Gets or sets the domain name suffix for Data Lake store filesystem services.
        /// </summary>
        public string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }

        /// <summary>
        /// Gets or sets the domain name suffix for Data Lake Analytics job and catalog services.
        /// </summary>
        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

        /// <summary>
        /// Gets or sets the expected token audience for authenticating requests to the key vault service.
        /// </summary>
        public string AzureKeyVaultServiceEndpointResourceId { get; set; }

        /// <summary>
        /// The token audience required for communicating with the Azure Log Analytics query service in this environment
        /// </summary>
        public string AzureOperationalInsightsEndpointResourceId
        {
            get
            {
                return this.GetEndpoint(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId);
            }
            set
            {
                this.SetEndpoint(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId, value);
            }
        }

        /// <summary>
        /// The endpoint to use when communicating with the Azure Log Analytics query service in this environment
        /// </summary>
        public string AzureOperationalInsightsEndpoint
        {
            get
            {
                return this.GetEndpoint(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint);
            }
            set
            {
                this.SetEndpoint(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint, value);
            }
        }

        public IList<string> VersionProfiles { get; } = new List<string>();

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets or sets the Azure Batch AD resource ID.
        /// </summary>
        public string BatchEndpointResourceId { get; set; }

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
                       && AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix == other.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix
                       && AzureDataLakeStoreFileSystemEndpointSuffix == other.AzureDataLakeStoreFileSystemEndpointSuffix
                       && DataLakeEndpointResourceId == other.DataLakeEndpointResourceId
                       && TrafficManagerDnsSuffix == other.TrafficManagerDnsSuffix
                       && BatchEndpointResourceId == other.BatchEndpointResourceId
                       && AzureOperationalInsightsEndpointResourceId == other.AzureOperationalInsightsEndpointResourceId
                       && AzureOperationalInsightsEndpoint == other.AzureOperationalInsightsEndpoint;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }

        static Uri UrlOrNull(string urlValue)
        {
            Uri result = null;
            if (urlValue != null)
            {
                result = new Uri(urlValue);
            }

            return result;
        }

        static string StringOrNull(Uri urlValue)
        {
            string result = null;
            if (urlValue != null)
            {
                result = urlValue.AbsoluteUri;
            }

            return result;
        }
    }
}
