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
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(
        VerbsCommon.Set,
        Constants.IntegrationRuntime,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSIntegrationRuntime))]
    public class SetAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
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
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [LocationCompleter("Microsoft.DataFactory/factories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [ValidateNotNullOrEmpty]
        public string NodeSize { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        public int? NodeCount { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [ValidateNotNullOrEmpty]
        public string CatalogServerEndpoint { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [ValidateNotNull]
        public PSCredential CatalogAdminCredential { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [ValidateNotNullOrEmpty]
        public string CatalogPricingTier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [ValidateNotNull]
        public string VNetId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Alias(Constants.SubnetName)]
        [ValidateNotNull]
        public string Subnet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [ValidateNotNullOrEmpty]
        public string SetupScriptContainerSasUri { get; set; }

        [Parameter(
                Mandatory = false,
                HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            IntegrationRuntimeEdition.Standard,
            IntegrationRuntimeEdition.Enterprise,
            IgnoreCase = true)]
        public string Edition { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        public int? MaxParallelExecutionsPerNode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeLicenseIncluded,
            Constants.IntegrationRuntimeBasePrice,
            IgnoreCase = true)]
        public string LicenseType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [ValidateNotNull]
        public System.Security.SecureString AuthKey { get; set; }

        [Parameter(
            Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            IntegrationRuntimeResource resource = null;
            var isUpdate = false;
            try
            {
                resource = DataFactoryClient.GetIntegrationRuntimeAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    base.Name).ConfigureAwait(true).GetAwaiter().GetResult().IntegrationRuntime;

                isUpdate = true;
                if (Type != null && (resource.Properties is ManagedIntegrationRuntime ^
                    Type.Equals(Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeWrongType,
                            base.Name),
                        "Type");
                }
            }
            catch (ErrorResponseException e)
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
                            selfHosted.LinkedInfo = new LinkedIntegrationRuntimeKey(new SecureString(authKey));
                        }

                        resource.Properties = selfHosted;
                    }
                }
                else
                {
                    throw;
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
                Name = base.Name,
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
