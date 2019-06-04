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
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Enable-AzCustomDomainHttps cmdlet.
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCustomDomainHttps", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet),  OutputType(typeof(PSFrontendEndpoint))]
    public class EnableAzureRmFrontDoorCustomDomainHttps : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group to which the Front Door belongs.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group to which the Front Door belongs.")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsWithVaultParameterSet, HelpMessage = "The resource group to which the Front Door belongs.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of the Front Door to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the Front Door.")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsWithVaultParameterSet, HelpMessage = "The name of the Front Door.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/frontdoors", nameof(ResourceGroupName))]
        public string FrontDoorName { get; set; }

        /// <summary>
        /// Gets or sets the frontend endpoint name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Frontend endpoint name.")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsWithVaultParameterSet, HelpMessage = "Frontend endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string FrontendEndpointName { get; set; }

        /// <summary>
        /// Resource Id of the Front Door endpoint to enable https
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the Front Door endpoint to enable https")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdWithVaultParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the Front Door endpoint to enable https")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        ///The Frontend Endpoint object to enable HTTPS.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The Frontend endpoint object to update.")]
        [Parameter(Mandatory = true, ParameterSetName = ObjectWithVaultParameterSet, ValueFromPipeline = true, HelpMessage = "The Frontend endpoint object to update.")]
        [ValidateNotNullOrEmpty]
        public PSFrontendEndpoint InputObject { get; set; }

        /// <summary>
        /// The Key Vault id containing the SSL certificate
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsWithVaultParameterSet, HelpMessage = "The Key Vault id containing the SSL certificate")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdWithVaultParameterSet, HelpMessage = "The Key Vault id containing the SSL certificate")]
        [Parameter(Mandatory = true, ParameterSetName = ObjectWithVaultParameterSet, HelpMessage = "The Key Vault id containing the SSL certificate")]
        public string VaultId { get; set; }

        /// <summary>
        /// The name of the Key Vault secret representing the full certificate PFX
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsWithVaultParameterSet, HelpMessage = "The name of the Key Vault secret representing the full certificate PFX")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdWithVaultParameterSet, HelpMessage = "The name of the Key Vault secret representing the full certificate PFX")]
        [Parameter(Mandatory = true, ParameterSetName = ObjectWithVaultParameterSet, HelpMessage = "The name of the Key Vault secret representing the full certificate PFX")]
        public string SecretName { get; set; }

        /// <summary>
        /// The version of the Key Vault secret representing the full certificate PFX
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsWithVaultParameterSet, HelpMessage = "The version of the Key Vault secret representing the full certificate PFX")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdWithVaultParameterSet, HelpMessage = "The version of the Key Vault secret representing the full certificate PFX")]
        [Parameter(Mandatory = true, ParameterSetName = ObjectWithVaultParameterSet, HelpMessage = "The version of the Key Vault secret representing the full certificate PFX")]
        public string SecretVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName == ResourceIdParameterSet || ParameterSetName == ResourceIdWithVaultParameterSet)
                {
                    ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                    if (!ResourceIdentifierExtensions.IsFrontendEndpointResourceType(identifier))
                    {
                        throw new PSArgumentException(string.Format(Resources.Error_InvalidResourceId, ResourceId));
                    }
                    ResourceGroupName = identifier.ResourceGroupName;
                    FrontendEndpointName = identifier.ResourceName;
                    FrontDoorName = ResourceIdentifierExtensions.GetFrontDoorName(identifier);
                }
                else if (ParameterSetName == ObjectParameterSet || ParameterSetName == ObjectWithVaultParameterSet)
                {
                    ResourceIdentifier identifier = new ResourceIdentifier(InputObject.Id);
                    ResourceGroupName = identifier.ResourceGroupName;
                    FrontendEndpointName = identifier.ResourceName;
                    FrontDoorName = ResourceIdentifierExtensions.GetFrontDoorName(identifier);
                }

                var customHttpsConfiguration = new Management.FrontDoor.Models.CustomHttpsConfiguration();

                if (ParameterSetName == FieldsParameterSet || ParameterSetName == ResourceIdParameterSet || ParameterSetName == ObjectParameterSet)
                {
                    customHttpsConfiguration.CertificateSource = PSCertificateSource.FrontDoor.ToString();
                    customHttpsConfiguration.CertificateType = PSCertificateType.Dedicated.ToString();
                }
                else if (ParameterSetName == FieldsWithVaultParameterSet || ParameterSetName == ResourceIdWithVaultParameterSet || ParameterSetName == ObjectWithVaultParameterSet)
                {
                    customHttpsConfiguration.CertificateSource = PSCertificateSource.AzureKeyVault.ToString();
                    customHttpsConfiguration.Vault = new Management.FrontDoor.Models.KeyVaultCertificateSourceParametersVault(VaultId);
                    customHttpsConfiguration.SecretName = SecretName;
                    customHttpsConfiguration.SecretVersion = SecretVersion;
                }

                customHttpsConfiguration.ProtocolType = PSProtocolType.ServerNameIndication.ToString();
                
                if (ShouldProcess(Resources.FrontDoorTarget, string.Format(Resources.EnableCustomDomainHttpsWarning, FrontendEndpointName)))
                {
                    FrontDoorManagementClient.FrontendEndpoints.BeginEnableHttps(ResourceGroupName, FrontDoorName, FrontendEndpointName, customHttpsConfiguration);

                    var frontDoorEndPoint = FrontDoorManagementClient.FrontendEndpoints.Get(ResourceGroupName, FrontDoorName, FrontendEndpointName);
                    WriteObject(frontDoorEndPoint.ToPSFrontendEndpoints());   
                }
            }
            catch (Microsoft.Azure.Management.FrontDoor.Models.ErrorResponseException e)
            {
                throw new PSArgumentException(string.Format(
                    Resources.Error_ErrorResponseFromServer,
                    e.Response.Content));
            }
        }
    }
}
