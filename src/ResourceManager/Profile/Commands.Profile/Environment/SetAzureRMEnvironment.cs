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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to set Azure Environment in Profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmEnvironment", SupportsShouldProcess = true, DefaultParameterSetName = EnvironmentPropertiesParameterSet)]
    [OutputType(typeof(PSAzureEnvironment))]
    public class SetAzureRMEnvironmentCommand : AzureContextModificationCmdlet
    {
        // Currently, this is the only resource endpoint used for both AzureCloud and all dogfood for Data Lake
        // This ensures that existing scripts will automatically pick up the right environment with no changes.
        private string _defaultDataLakeResourceEndpoint = "https://datalake.azure.net";
        private EnvironmentHelper envHelper;

        private const string MetadataParameterSet = "ARMEndpoint";
        private const string EnvironmentPropertiesParameterSet = "Name";

        public EnvironmentHelper EnvHelper
        {
            get { return this.envHelper; }
            set { this.envHelper = value != null ? value : new EnvironmentHelper(); }
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string PublishSettingsFileUrl { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceManagement", "ServiceManagementUrl")]
        public string ServiceEndpoint { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string ManagementPortalUrl { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 4, Mandatory = false, HelpMessage = "The storage endpoint")]
        [Parameter(ParameterSetName = MetadataParameterSet, Position = 2, Mandatory = false, HelpMessage = "The storage endpoint")]
        [Alias("StorageEndpointSuffix")]
        public string StorageEndpoint { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The URI for the Active Directory service for this environment")]
        [Alias("AdEndpointUrl", "ActiveDirectory", "ActiveDirectoryAuthority")]
        public string ActiveDirectoryEndpoint { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The cloud service endpoint")]
        [Alias("ResourceManager", "ResourceManagerUrl")]
        public string ResourceManagerEndpoint { get; set; }

        [Parameter(ParameterSetName = MetadataParameterSet, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Azure Resource Manager endpoint")]
        [Alias("ArmUrl")]
        public string ARMEndpoint { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The public gallery endpoint")]
        [Alias("Gallery", "GalleryUrl")]
        public string GalleryEndpoint { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Identifier of the target resource that is the recipient of the requested token.")]
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The AD Graph Endpoint.")]
        [Alias("Graph", "GraphUrl")]
        public string GraphEndpoint { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 10, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Dns suffix of Azure Key Vault service. Example is vault-int.azure-int.net")]
        [Parameter(ParameterSetName = MetadataParameterSet, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Dns suffix of Azure Key Vault service")]
        public string AzureKeyVaultDnsSuffix { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 11, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource identifier of Azure Key Vault data service that is the recipient of the requested token.")]
        [Parameter(ParameterSetName = MetadataParameterSet, Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource identifier of Azure Key Vault data service that is the recipient of the requested token.")]
        public string AzureKeyVaultServiceEndpointResourceId { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 12, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Dns suffix of Traffic Manager service.")]
        public string TrafficManagerDnsSuffix { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 13, Mandatory = false, ValueFromPipelineByPropertyName = true,
          HelpMessage = "Dns suffix of Sql databases created in this environment.")]
        public string SqlDatabaseDnsSuffix { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 14, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Dns Suffix of Azure Data Lake Store FileSystem. Example: azuredatalake.net")]
        public string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 15, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Dns Suffix of Azure Data Lake Analytics job and catalog services")]
        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 16, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Determines whether to enable ADFS authentication, or to use AAD authentication instead. This value is normally true only for Azure Stack endpoints.")]
        [Alias("OnPremise")]
        public SwitchParameter EnableAdfsAuthentication { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 17, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The default tenant for this environment.")]
        public string AdTenant { get; set; }

        [Parameter(ParameterSetName = EnvironmentPropertiesParameterSet, Position = 18, Mandatory = false, ValueFromPipelineByPropertyName = true,
          HelpMessage = "The audience for tokens authenticating with the AD Graph Endpoint.")]
        [Alias("GraphEndpointResourceId", "GraphResourceId")]
        public string GraphAudience { get; set; }

        [Parameter(Position = 19, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The audience for tokens authenticating with the AD Data Lake services Endpoint.")]
        [Alias("DataLakeEndpointResourceId", "DataLakeResourceId")]
        public string DataLakeAudience
        {
            get
            {
                return _defaultDataLakeResourceEndpoint;
            }
            set
            {
                _defaultDataLakeResourceEndpoint = value;
            }
        }

        [Parameter(Position = 20, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource identifier of the Azure Batch service that is the recipient of the requested token.")]
        [Alias("BatchResourceId", "BatchAudience")]
        public string BatchEndpointResourceId { get; set; }

        [Parameter(Position = 21, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The audience for tokens authenticating with the Azure Log Analytics API.")]
        public string AzureOperationalInsightsEndpointResourceId { get; set; }

        [Parameter(Position = 22, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The endpoint to use when communicating with the Azure Log Analytics API.")]
        public string AzureOperationalInsightsEndpoint { get; set; }

        protected override void BeginProcessing()
        {
            // do not call begin processing there is no context needed for this cmdlet
        }

        public override void ExecuteCmdlet()
        {
            ConfirmAction("updating environment", Name,
                () =>
                {

                    if (AzureEnvironment.PublicEnvironments.Keys.Any((k) => string.Equals(k, Name, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                            "Cannot change built-in environment {0}.", Name));
                    }

                    if (this.ParameterSetName.Equals(MetadataParameterSet, StringComparison.Ordinal))
                    {
                        // Simply use built-in environments if the ARM endpoint matches the ARM endpoint for a built-in environment
                        var publicEnvironment = AzureEnvironment.PublicEnvironments.FirstOrDefault(
                            env => !string.IsNullOrWhiteSpace(ARMEndpoint) && 
                            string.Equals(
                                env.Value?.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager)?.ToLowerInvariant(),
                                GeneralUtilities.EnsureTrailingSlash(ARMEndpoint)?.ToLowerInvariant(), StringComparison.CurrentCultureIgnoreCase));

                        var defProfile = GetDefaultProfile();
                        IAzureEnvironment newEnvironment;
                        if (!defProfile.TryGetEnvironment(this.Name, out newEnvironment))
                        {
                            newEnvironment = new AzureEnvironment { Name = this.Name };
                        }

                        if (publicEnvironment.Key == null)
                        {
                            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ResourceManager, ARMEndpoint);
                            try
                            {
                                EnvHelper = (EnvHelper == null ? new EnvironmentHelper() : EnvHelper);
                                MetadataResponse metadataEndpoints = EnvHelper.RetrieveMetaDataEndpoints(newEnvironment.ResourceManagerUrl).Result;
                                string domain = EnvHelper.RetrieveDomain(ARMEndpoint);

                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectory,
                                    metadataEndpoints.authentication.LoginEndpoint.TrimEnd('/') + '/');
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId,
                                    metadataEndpoints.authentication.Audiences[0]);
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.Gallery, metadataEndpoints.GalleryEndpoint);
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.Graph, metadataEndpoints.GraphEndpoint);
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.GraphEndpointResourceId,
                                    metadataEndpoints.GraphEndpoint);
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix,
                                        AzureKeyVaultDnsSuffix ?? string.Format("vault.{0}", domain).ToLowerInvariant());
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId,
                                        AzureKeyVaultServiceEndpointResourceId ?? string.Format("https://vault.{0}", domain).ToLowerInvariant());
                                SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.StorageEndpointSuffix, StorageEndpoint ?? domain);
                                newEnvironment.OnPremise = metadataEndpoints.authentication.LoginEndpoint.TrimEnd('/').EndsWith("/adfs", System.StringComparison.OrdinalIgnoreCase);
                            }
                            catch (AggregateException ae)
                            {
                                if (ae.Flatten().InnerExceptions.Count > 1)
                                {
                                    throw;
                                }

                                if (ae.InnerException != null)
                                {
                                    throw ae.InnerException;
                                }
                            }
                        }
                        else
                        {
                            newEnvironment = new AzureEnvironment(publicEnvironment.Value);
                            newEnvironment.Name = Name;
                            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix,
                                    AzureKeyVaultDnsSuffix);
                            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId,
                                    AzureKeyVaultServiceEndpointResourceId);
                        }

                        ModifyContext((profile, client) =>
                        {
                            WriteObject(new PSAzureEnvironment(client.AddOrSetEnvironment(newEnvironment)));
                        });
                    }
                    else
                    {
                        ModifyContext((profile, profileClient) =>
                        {

                            IAzureEnvironment newEnvironment = new AzureEnvironment { Name = Name };
                            if (profile.EnvironmentTable.ContainsKey(Name))
                            {
                                newEnvironment = profile.EnvironmentTable[Name];
                            }

                            if (MyInvocation != null && MyInvocation.BoundParameters != null)
                            {
                                if (MyInvocation.BoundParameters.ContainsKey(nameof(EnableAdfsAuthentication)))
                                {
                                    newEnvironment.OnPremise = EnableAdfsAuthentication;
                                }

                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.PublishSettingsFileUrl,
                                        nameof(PublishSettingsFileUrl));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.ServiceManagement, nameof(ServiceEndpoint));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.ResourceManager,
                                    nameof(ResourceManagerEndpoint));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.ManagementPortalUrl,
                                    nameof(ManagementPortalUrl));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.StorageEndpointSuffix,
                                    nameof(StorageEndpoint));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectory,
                                    nameof(ActiveDirectoryEndpoint));
                                SetEndpointIfBound(newEnvironment,
                                    AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId,
                                    nameof(ActiveDirectoryServiceEndpointResourceId));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.Gallery, nameof(GalleryEndpoint));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.Graph, nameof(GraphEndpoint));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix,
                                   nameof(AzureKeyVaultDnsSuffix));
                                SetEndpointIfBound(newEnvironment,
                                    AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId,
                                    nameof(AzureKeyVaultServiceEndpointResourceId));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.TrafficManagerDnsSuffix,
                                    nameof(TrafficManagerDnsSuffix));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix,
                                    nameof(SqlDatabaseDnsSuffix));
                                SetEndpointIfBound(newEnvironment,
                                    AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                                    nameof(AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix));
                                SetEndpointIfBound(newEnvironment,
                                    AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix,
                                    nameof(AzureDataLakeStoreFileSystemEndpointSuffix));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.AdTenant, nameof(AdTenant));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.GraphEndpointResourceId,
                                   nameof(GraphAudience));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.DataLakeEndpointResourceId,
                                    nameof(DataLakeAudience));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.Endpoint.BatchEndpointResourceId,
                                    nameof(BatchEndpointResourceId));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId,
                                    nameof(AzureOperationalInsightsEndpointResourceId));
                                SetEndpointIfBound(newEnvironment, AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint,
                                    nameof(AzureOperationalInsightsEndpoint));
                                WriteObject(new PSAzureEnvironment(profileClient.AddOrSetEnvironment(newEnvironment)));
                            }
                        });
                    }
                });
        }

        private void SetEndpointIfProvided(IAzureEnvironment newEnvironment, string endpoint, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                newEnvironment.SetEndpoint(endpoint, property);
            }
        }

        private void SetEndpointIfBound(IAzureEnvironment newEnvironment, string endpoint, string key)
        {
            if (MyInvocation.BoundParameters.ContainsKey(key))
            {
                newEnvironment.SetEndpoint(endpoint, MyInvocation.BoundParameters[key] as string);
            }
        }
    }
}
