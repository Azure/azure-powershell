﻿// ----------------------------------------------------------------------------------
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
                "Specifies a name for the attestation provider. The name can be any combination of letters, digits, or hyphens. The name must start and end with a letter or digit. The name must be universally unique."
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


        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies the name of a policy template to be configured for the attestation provider."
        )]
        [PSArgumentCompleter("SgxDisableDebugMode", "SgxAllowDebugMode", "SgxRequireSqlServer", "SgxRequireSqlServerBogusMrSigner")]
        public string AttestationPolicy { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies the configuration signing keys passed in which to create the attestation."
        )]
        public string PolicySigningCertificateFile { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Resources.CreateAttestation))
            {
                JSONWebKeySet jsonWebKeySet = null;

                if (this.PolicySigningCertificateFile != null)
                {
                    FileInfo certFile = new FileInfo(ResolveUserPath(this.PolicySigningCertificateFile));

                    if (!certFile.Exists)
                    {
                        throw new FileNotFoundException(string.Format(AttestationProperties.Resources.CertificateFileNotFound, this.PolicySigningCertificateFile));
                    }

                    var pem = System.IO.File.ReadAllText(certFile.FullName);

                    X509Certificate2Collection certificateCollection = AttestationClient.GetX509CertificateFromPEM(pem, "CERTIFICATE");

                    if (certificateCollection.Count != 0)
                    {
                        jsonWebKeySet = AttestationClient.GetJSONWebKeySet(certificateCollection);
                    }                    
                }
                var newAttestation = AttestationClient.CreateNewAttestation(new AttestationCreationParameters()
                {
                    ProviderName = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    AttestationPolicy = this.AttestationPolicy,
                    PolicySigningCertificates = jsonWebKeySet
                });
                this.WriteObject(newAttestation);
            } 
        }
    }
}
