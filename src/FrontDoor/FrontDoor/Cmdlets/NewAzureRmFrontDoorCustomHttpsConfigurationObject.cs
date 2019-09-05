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
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorFrontendEndpointObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCustomHttpsConfigurationObject"), OutputType(typeof(PSFrontendEndpoint))]
    public class NewAzureRmFrontDoorCustomHttpsConfigurationObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Gets or sets the frontend endpoint name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Custom Https Configuration name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The source of the SSL certificate. Part of CustomHttpsConfiguration.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = true, HelpMessage = "The source of the SSL certificate")]
        [PSArgumentCompleter("AzureKeyVault", "FrontDoor")]
        public string CertificateSource { get; set; }

        /// <summary>
        /// The minimum TLS version required from the clients to establish an SSL handshake with Front Door. Part of CustomHttpsConfiguration.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = true, HelpMessage = "The minimum TLS version required from the clients to establish an SSL handshake with Front Door.")]
        public string MinimumTlsVersion { get; set; }

        /// <summary>
        /// Defines the TLS extension protocol that is used for secure delivery. Part of CustomHttpsConfiguration.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = false, HelpMessage = "The Key Vault containing the SSL certificate")]
        public string Vault { get; set; }

        /// <summary>
        /// The name of the Key Vault secret representing the full certificate PFX. Part of CustomHttpsConfiguration.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = false, HelpMessage = "The name of the Key Vault secret representing the full certificate PFX")]
        public string SecretName { get; set; }

        /// <summary>
        /// The version of the Key Vault secret representing the full certificate PFX. Part of CustomHttpsConfiguration.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = false, HelpMessage = "The version of the Key Vault secret representing the full certificate PFX")]
        public string SecretVersion { get; set; }

        /// <summary>
        /// The type of the certificate used for secure connections to a frontendEndpoint. Part of CustomHttpsConfiguration.
        /// </summary>
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = false, HelpMessage = "The type of the certificate used for secure connections to a frontendEndpoint")]
        [PSArgumentCompleter("Shared", "Dedicated")]
        public string CertificateType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }
    }
}
