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
using System.IO;
using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Azure.Commands.Attestation.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.Attestation.Models;
using AttestationProperties = Microsoft.Azure.Commands.Attestation.Properties;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Attestation
{
    /// <summary>
    /// Create a new Attestation.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Attestation",SupportsShouldProcess = true)]
    [OutputType(typeof(PSAttestation))] 
    public class NewAzureAttestation : AttestationManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Instance name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies the attestation provider name. The name can be any combination of letters, digits, or hyphens. The name must start and end with a letter or digit. The name must be universally unique."
            )]
        [ValidateNotNullOrEmpty]
        [Alias("InstanceName")]
        public string Name { get; set; }
        
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of an existing resource group in which to create the attestation provider.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the Azure region in which to create the attestation provider. Use the command Get-AzResourceProvider with the ProviderNamespace parameter to see your choices.")]
        [LocationCompleter("Microsoft.Attestation/attestationProviders")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies the set of trusted signing keys for issuance policy in a single certificate file."
        )]
        public string PolicySignersCertificateFile { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Resources.CreateAttestation))
            {
                var newServiceParameters = new AttestationCreationParameters
                {
                    ResourceGroupName = this.ResourceGroupName,
                    ProviderName = this.Name,
                    CreationParameters = new AttestationServiceCreationParams
                    {
                        Location = this.Location,
                        Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                        Properties = new AttestationServiceCreationSpecificParams
                        {
                            AttestationPolicy = null,
                            PolicySigningCertificates =
                                JwksHelper.GetJwks(ResolveUserPath(this.PolicySignersCertificateFile))
                        }
                    }
                };

                var newAttestation = AttestationClient.CreateNewAttestation(newServiceParameters);
                this.WriteObject(newAttestation);
            } 
        }
    }
}
