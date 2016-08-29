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
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    
    /// <summary>
    /// Sets a Microsoft Azure environment.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureEnvironment"), OutputType(typeof(PSAzureEnvironment))]
    public class SetAzureEnvironmentCommand : SubscriptionCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string PublishSettingsFileUrl { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceManagement", "ServiceManagementUrl")]
        public string ServiceEndpoint { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string ManagementPortalUrl { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The storage endpoint")]
        [Alias("StorageEndpointSuffix")]
        public string StorageEndpoint { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Active directory endpoint")]
        [Alias("AdEndpointUrl", "ActiveDirectory", "ActiveDirectoryAuthority")]
        public string ActiveDirectoryEndpoint { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The cloud service endpoint")]
        [Alias("ResourceManager", "ResourceManagerUrl")]
        public string ResourceManagerEndpoint { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The public gallery endpoint")]
        [Alias("Gallery", "GalleryUrl")]
        public string GalleryEndpoint { get; set; }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Identifier of the target resource that is the recipient of the requested token.")]
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        [Parameter(Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The AD Graph Endpoint.")]
        [Alias("Graph", "GraphUrl")]
        public string GraphEndpoint { get; set; }

        [Parameter(Position = 10, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Dns suffix of Azure Key Vault service. Example is vault-int.azure-int.net")]
        public string AzureKeyVaultDnsSuffix { get; set; }

        [Parameter(Position = 11, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource identifier of Azure Key Vault data service that is the recipient of the requested token.")]
        public string AzureKeyVaultServiceEndpointResourceId { get; set; }

        [Parameter(Position = 12, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Dns suffix of Traffic Manager service.")]
        public string TrafficManagerDnsSuffix { get; set; }

         [Parameter(Position = 13, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Dns suffix of Sql databases created in this environment.")]
        public string SqlDatabaseDnsSuffix { get; set; }

        [Parameter(Position = 14, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Determines whether to enable ADFS authentication, or to use AAD authentication instead. This value is normally true only for Azure Stack endpoints.")]
        [Alias("OnPremise")]
        public SwitchParameter EnableAdfsAuthentication { get; set; }

        [Parameter(Position = 15, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The default tenant for this environment.")]
        public string AdTenant { get; set; }

        public SetAzureEnvironmentCommand() : base(true) { }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureEnvironment.PublicEnvironments.Keys.ForEach((key) =>
            {
                if (string.Equals(Name, key, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                        Resources.CannotChangeBuiltinEnvironment, Name));
                }
            });

            var newEnvironment = new AzureEnvironment { Name = Name, OnPremise = EnableAdfsAuthentication };
            if (ProfileClient.Profile.Environments.ContainsKey(Name))
            {
                newEnvironment = ProfileClient.Profile.Environments[Name];
            }
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.PublishSettingsFileUrl, PublishSettingsFileUrl);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ServiceManagement, ServiceEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ResourceManager, ResourceManagerEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ManagementPortalUrl, ManagementPortalUrl);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.StorageEndpointSuffix, StorageEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectory, ActiveDirectoryEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, ActiveDirectoryServiceEndpointResourceId);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.Gallery, GalleryEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.Graph, GraphEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureKeyVaultDnsSuffix);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureKeyVaultServiceEndpointResourceId);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, TrafficManagerDnsSuffix);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, SqlDatabaseDnsSuffix);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AdTenant, AdTenant);

            ProfileClient.AddOrSetEnvironment(newEnvironment);

            WriteObject((PSAzureEnvironment)newEnvironment);
        }

        private void SetEndpointIfProvided(AzureEnvironment newEnvironment, AzureEnvironment.Endpoint endpoint, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                newEnvironment.Endpoints[endpoint] = property;
            }
        }

        private static string Value(string newValue, string existingValue)
        {
            return string.IsNullOrEmpty(newValue) ? existingValue : newValue;
        }
    }
}