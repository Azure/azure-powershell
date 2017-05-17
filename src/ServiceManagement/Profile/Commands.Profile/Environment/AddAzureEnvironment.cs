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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.WindowsAzure.Commands.Profile
{


    /// <summary>
    /// Adds a new Microsoft Azure environment.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureEnvironment"), OutputType(typeof(PSAzureEnvironment))]
    public class AddAzureEnvironmentCommand : SubscriptionCmdletBase
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

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The URI for the Active Directory service for this environment")]
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
          HelpMessage = "Enable ADFS authentication by disabling the authority validation")]
        [Alias("OnPremise")]
        public SwitchParameter EnableAdfsAuthentication { get; set; }

        [Parameter(Position = 15, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The default tenant for this environment.")]
        public string AdTenant { get; set; }

        public AddAzureEnvironmentCommand() : base(true) { }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var newEnvironment = new AzureEnvironment
            {
                Name = Name,
                OnPremise = EnableAdfsAuthentication
            };
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl, PublishSettingsFileUrl);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.ServiceManagement, ServiceEndpoint);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.ResourceManager, ResourceManagerEndpoint);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl, ManagementPortalUrl);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix, StorageEndpoint);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory, ActiveDirectoryEndpoint);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, ActiveDirectoryServiceEndpointResourceId);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.Gallery, GalleryEndpoint);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.Graph, GraphEndpoint);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureKeyVaultDnsSuffix);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureKeyVaultServiceEndpointResourceId);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, TrafficManagerDnsSuffix);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, SqlDatabaseDnsSuffix);
            newEnvironment.SetEndpoint(AzureEnvironment.Endpoint.AdTenant, AdTenant);
            ProfileClient.AddOrSetEnvironment(newEnvironment);
            WriteObject((PSAzureEnvironment)newEnvironment);
        }
    }
}