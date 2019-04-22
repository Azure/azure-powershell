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
using System.Net;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;


namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2IntegrationRuntime",DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,SupportsShouldProcess = true),OutputType(typeof(PSIntegrationRuntime))]
    public class SetAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public new string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public new string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        public new string DataFactoryName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpIntegrationRuntimeObject)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeObject,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpIntegrationRuntimeObject)]
        [ValidateNotNull]
        public new PSIntegrationRuntime InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IntegrationRuntimeName)]
        public new string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimetype)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeTypeManaged,
            Constants.IntegrationRuntimeSelfhosted,
            IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [LocationCompleter("Microsoft.DataFactory/factories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [ValidateNotNullOrEmpty]
        public string NodeSize { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        public int? NodeCount { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [ValidateNotNullOrEmpty]
        public string CatalogServerEndpoint { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [ValidateNotNull]
        public PSCredential CatalogAdminCredential { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [ValidateNotNullOrEmpty]
        public string CatalogPricingTier { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [ValidateNotNull]
        public string VNetId { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Alias(Constants.SubnetName)]
        [ValidateNotNull]
        public string Subnet { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [ValidateNotNullOrEmpty]
        public string SetupScriptContainerSasUri { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            IntegrationRuntimeEdition.Standard,
            IntegrationRuntimeEdition.Enterprise,
            IgnoreCase = true)]
        public string Edition { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        public int? MaxParallelExecutionsPerNode { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeLicenseIncluded,
            Constants.IntegrationRuntimeBasePrice,
            IgnoreCase = true)]
        public string LicenseType { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [ValidateNotNull]
        public System.Security.SecureString AuthKey { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Mandatory = true,
            HelpMessage = Constants.HelpSharedIntegrationRuntimeResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeResourceId,
            Mandatory = true,
            HelpMessage = Constants.HelpSharedIntegrationRuntimeResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeObject,
            Mandatory = true,
            HelpMessage = Constants.HelpSharedIntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string SharedIntegrationRuntimeResourceId { get; set; }

        [Parameter(
            Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        protected override void ByResourceId()
        {
            if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = parsedResourceId.ResourceGroupName;

                var parentResource = parsedResourceId.ParentResource.Split(new[] { '/' });
                DataFactoryName = parentResource[parentResource.Length - 1];

                Name = parsedResourceId.ResourceName;
            }
        }

        protected override void ByIntegrationRuntimeObject()
        {
            if (InputObject != null)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                DataFactoryName = InputObject.DataFactoryName;
                Name = InputObject.Name;
            }
        }


        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            if (string.Equals(Type, Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase))
            {
                if (AuthKey != null || !string.IsNullOrWhiteSpace(SharedIntegrationRuntimeResourceId))
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.InvalidIntegrationRuntimeSharing),
                        "AuthKey");
                }
            }

            IntegrationRuntimeResource resource = null;
            var isUpdate = false;
            try
            {
                resource = DataFactoryClient.GetIntegrationRuntimeAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult().IntegrationRuntime;

                isUpdate = true;
                if (Type != null && (resource.Properties is ManagedIntegrationRuntime ^
                    Type.Equals(Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeWrongType,
                            Name),
                        "Type");
                }

                if (AuthKey != null)
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.UpdateAuthKeyNotAllowed,
                            Name),
                        "AuthKey");
                }
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    if (Type == null)
                    {
                        throw new PSArgumentException(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                Resources.NeedIntegrationRuntimeType),
                            "Type");
                    }

                    resource = new IntegrationRuntimeResource();
                    if (Type.Equals(Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase))
                    {
                        resource.Properties = new ManagedIntegrationRuntime();
                    }
                    else
                    {
                        var selfHosted = new SelfHostedIntegrationRuntime();
                        if (AuthKey != null)
                        {
                            var authKey = ConvertToUnsecureString(AuthKey);
                            selfHosted.LinkedInfo = new LinkedIntegrationRuntimeKeyAuthorization(new SecureString(authKey));
                        }

                        resource.Properties = selfHosted;
                    }
                }
                else
                {
                    throw;
                }
            }

            if (!string.IsNullOrWhiteSpace(SharedIntegrationRuntimeResourceId))
            {
                var selfHostedIr = resource.Properties as SelfHostedIntegrationRuntime;
                if (selfHostedIr != null)
                {
                    selfHostedIr.LinkedInfo = new LinkedIntegrationRuntimeRbacAuthorization(SharedIntegrationRuntimeResourceId);
                }
                else
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.InvalidIntegrationRuntimeSharing),
                        "SharedIntegrationRuntimeResourceId");
                }
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                resource.Properties.Description = Description;
            }

            var managedIr = resource.Properties as ManagedIntegrationRuntime;
            if (managedIr != null)
            {
                HandleManagedIntegrationRuntime(managedIr);
            }

            var parameters = new CreatePSIntegrationRuntimeParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Name = Name,
                IsUpdate = isUpdate,
                IntegrationRuntimeResource = resource,
                Force = Force.IsPresent,
                ConfirmAction = base.ConfirmAction
            };

            WriteObject(DataFactoryClient.CreateOrUpdateIntegrationRuntime(parameters));
        }

        private void HandleManagedIntegrationRuntime(ManagedIntegrationRuntime integrationRuntime)
        {
            if (!string.IsNullOrWhiteSpace(Location))
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.Location = Location;
            }

            if (!string.IsNullOrWhiteSpace(NodeSize))
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.NodeSize = NodeSize;
            }

            if (NodeCount.HasValue)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.NumberOfNodes = NodeCount;

                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }
            }

            if (MaxParallelExecutionsPerNode.HasValue)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.MaxParallelExecutionsPerNode = MaxParallelExecutionsPerNode;
            }

            if (!string.IsNullOrWhiteSpace(CatalogServerEndpoint))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties()
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    };
                }
                else if (integrationRuntime.SsisProperties.CatalogInfo == null)
                {
                    integrationRuntime.SsisProperties.CatalogInfo = new IntegrationRuntimeSsisCatalogInfo();
                }

                integrationRuntime.SsisProperties.CatalogInfo.CatalogServerEndpoint = CatalogServerEndpoint;
            }

            if (CatalogAdminCredential != null)
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties()
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    };
                }
                else if (integrationRuntime.SsisProperties.CatalogInfo == null)
                {
                    integrationRuntime.SsisProperties.CatalogInfo = new IntegrationRuntimeSsisCatalogInfo();
                }

                integrationRuntime.SsisProperties.CatalogInfo.CatalogAdminUserName = CatalogAdminCredential.UserName;
                var passWord = ConvertToUnsecureString(CatalogAdminCredential.Password);
                if (passWord != null && passWord.Length > 128)
                {
                    throw new PSArgumentException("The password exceeds maximum length of '128'", "CatalogAdminCredential");
                }
                integrationRuntime.SsisProperties.CatalogInfo.CatalogAdminPassword = new SecureString(passWord);
            }

            if (!string.IsNullOrWhiteSpace(CatalogPricingTier))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties()
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    };
                }
                else if (integrationRuntime.SsisProperties.CatalogInfo == null)
                {
                    integrationRuntime.SsisProperties.CatalogInfo = new IntegrationRuntimeSsisCatalogInfo();
                }

                integrationRuntime.SsisProperties.CatalogInfo.CatalogPricingTier = CatalogPricingTier;
            }

            if (integrationRuntime.ComputeProperties?.VNetProperties == null
                || (string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.VNetId)
                    && string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.Subnet)))
            {
                // When no previous VNet set, both VNetId and Subnet must be present
                if (!string.IsNullOrWhiteSpace(VNetId) && !string.IsNullOrWhiteSpace(Subnet))
                {
                    // Both VNetId and Subnet are set
                    if (integrationRuntime.ComputeProperties == null)
                    {
                        integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                    }

                    integrationRuntime.ComputeProperties.VNetProperties = new IntegrationRuntimeVNetProperties()
                    {
                        VNetId = VNetId,
                        Subnet = Subnet
                    };
                }
                else if (string.IsNullOrWhiteSpace(VNetId) ^ string.IsNullOrWhiteSpace(Subnet))
                {
                    // Only one of the two pramaters is set
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeInvalidVnet),
                        "Type");
                }
            }
            else
            {
                // We have VNet properties set, then we are able to change VNetId or Subnet individually now.
                // Could be empty. If user input empty, then convert it to null. If user want to remove VNet settings, input both with empty string.
                if (VNetId != null)
                {
                    integrationRuntime.ComputeProperties.VNetProperties.VNetId = VNetId.IsEmptyOrWhiteSpace() ? null : VNetId;
                }
                if (Subnet != null)
                {
                    integrationRuntime.ComputeProperties.VNetProperties.Subnet = Subnet.IsEmptyOrWhiteSpace() ? null : Subnet;
                }

                // Make sure both VNetId and Subnet are present, or both null
                if (string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.VNetId)
                    ^ string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.Subnet))
                {
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeInvalidVnet),
                        "Type");
                }
            }

            if (!string.IsNullOrWhiteSpace(LicenseType))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }

                integrationRuntime.SsisProperties.LicenseType = LicenseType;
            }

            if (!string.IsNullOrEmpty(SetupScriptContainerSasUri))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }

                int index = SetupScriptContainerSasUri.IndexOf('?');

                integrationRuntime.SsisProperties.CustomSetupScriptProperties = new IntegrationRuntimeCustomSetupScriptProperties()
                {
                    BlobContainerUri = index >= 0 ? SetupScriptContainerSasUri.Substring(0, index) : SetupScriptContainerSasUri,
                    SasToken = index >= 0 ? new SecureString(SetupScriptContainerSasUri.Substring(index)) : null
                };
            }

            if (!string.IsNullOrEmpty(Edition))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }

                integrationRuntime.SsisProperties.Edition = Edition;
            }

            integrationRuntime.Validate();
        }
    }
}
