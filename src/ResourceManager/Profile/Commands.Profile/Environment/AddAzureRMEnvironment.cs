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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to add Azure Environment to Profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmEnvironment", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureEnvironment))]
    public class AddAzureRMEnvironmentCommand : AzureRMCmdlet
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
            HelpMessage = "Dns Suffix of Azure Data Lake Store FileSystem. Example: azuredatalake.net")]
        public string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }

        [Parameter(Position = 15, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Dns Suffix of Azure Data Lake Analytics job and catalog services")]
        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

        [Parameter(Position = 16, Mandatory = false, ValueFromPipelineByPropertyName = true,
          HelpMessage = "Enable ADFS authentication by disabling the authority validation")]
        [Alias("OnPremise")]
        public SwitchParameter EnableAdfsAuthentication { get; set; }

        [Parameter(Position = 17, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The default tenant for this environment.")]
        public string AdTenant { get; set; }

        [Parameter(Position = 18, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The audience for tokens authenticating with the AD Graph Endpoint.")]
        [Alias("GraphEndpointResourceId", "GraphResourceId")]
        public string GraphAudience { get; set; }

        protected override void BeginProcessing()
        {
            // do not call begin processing there is no context needed for this cmdlet
        }

        public override void ExecuteCmdlet()
        {
            ConfirmAction("adding environment", Name,
                () =>
                {
                    var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);

                    var newEnvironment = new AzureEnvironment
                    {
                        Name = Name,
                        OnPremise = EnableAdfsAuthentication
                    };

                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl] = PublishSettingsFileUrl;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement] = ServiceEndpoint;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.ResourceManager] = ResourceManagerEndpoint;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl] = ManagementPortalUrl;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix] = StorageEndpoint;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory] = ActiveDirectoryEndpoint;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId] =
                        ActiveDirectoryServiceEndpointResourceId;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.Gallery] = GalleryEndpoint;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.Graph] = GraphEndpoint;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix] = AzureKeyVaultDnsSuffix;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId] =
                        AzureKeyVaultServiceEndpointResourceId;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.TrafficManagerDnsSuffix] =
                        TrafficManagerDnsSuffix;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix] = SqlDatabaseDnsSuffix;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix
                        ] = AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix] =
                        AzureDataLakeStoreFileSystemEndpointSuffix;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.AdTenant] = AdTenant;
                    newEnvironment.Endpoints[AzureEnvironment.Endpoint.GraphEndpointResourceId] = GraphAudience;
                    WriteObject((PSAzureEnvironment)profileClient.AddOrSetEnvironment(newEnvironment));
                });
        }
    }
}
