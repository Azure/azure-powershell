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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorFrontendEndpointObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorFrontendEndpointObject", DefaultParameterSetName = ObjectWithCustomHttpsConfigParameterSet), OutputType(typeof(PSFrontendEndpoint))]
    public class NewAzureRmFrontDoorFrontendEndpointObject : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// Gets or sets the frontend endpoint name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Frontend endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The host name of the frontendEndpoint. Must be a domain name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The host name of the frontendEndpoint.")]
        public string HostName { get; set; }

        /// <summary>
        /// Whether to allow session affinity on this host. Valid options are ‘Enabled’ or ‘Disabled’.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to allow session affinity on this host. Default value is Disabled")]
        public PSEnabledState SessionAffinityEnabledState { get; set; }

        /// <summary>
        /// The TTL to use in seconds for session affinity, if applicable.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The TTL to use in seconds for session affinity, if applicable. Default value is 0")]
        public int SessionAffinityTtlInSeconds { get; set; }

        /// <summary>
        /// The resource id of Web Application Firewall policy for each host (if applicable).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The resource id of Web Application Firewall policy for each host (if applicable)")]
        public string WebApplicationFirewallPolicyLink { get; set; }

        /// <summary>
        /// The Https settings for a domain.
        /// </summary>
        [Parameter(ParameterSetName = ObjectWithCustomHttpsConfigParameterSet, Mandatory = false, HelpMessage = "The Https settings for a domain")]
        public PSCustomHttpsConfiguration CustomHttpsConfiguration { get; set; }

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
        [Parameter(ParameterSetName = FieldsWithCustomHttpsConfigParameterSet, Mandatory = false, HelpMessage = "The TLS extension protocol that is used for secure delivery")]
        [PSArgumentCompleter("ServerNameIndication", "IPBased")]
        public string ProtocolType { get; set; }

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
            PSCustomHttpsConfiguration customHttpsConfiguration;

            switch (ParameterSetName)
            {
                case FieldsWithCustomHttpsConfigParameterSet:
                    {
                        PSKeyVaultCertificateSourceParameters psKeyVaultCertificateSourceParameters = null;
                        PSFrontDoorCertificateSourceParameters psFrontDoorCertificateSourceParameters = null;
                        if (CertificateSource == "AzureKeyVault")
                        {
                            psKeyVaultCertificateSourceParameters = new PSKeyVaultCertificateSourceParameters
                            {
                                Vault = Vault,
                                SecretName = SecretName,
                                SecretVersion = SecretVersion,
                                CertificateType = (PSCertificateType)Enum.Parse(typeof(PSCertificateType), CertificateType)
                            };
                        }
                        else
                        {
                            psFrontDoorCertificateSourceParameters = new PSFrontDoorCertificateSourceParameters
                            {
                                CertificateType = (PSCertificateType)Enum.Parse(typeof(PSCertificateType), CertificateType)

                            };
                        }

                        customHttpsConfiguration = new PSCustomHttpsConfiguration
                        {
                            CertificateSource = CertificateSource,
                            MinimumTlsVersion = MinimumTlsVersion,
                            KeyVaultCertificateSourceParameters = psKeyVaultCertificateSourceParameters,
                            FrontDoorCertificateSourceParameters = psFrontDoorCertificateSourceParameters
                        };
                        break;
                    }
                default:
                    {
                        customHttpsConfiguration = !this.IsParameterBound(c => c.CustomHttpsConfiguration) ? null : CustomHttpsConfiguration;
                        break;
                    }
            }

            var FrontendEndpoint = new PSFrontendEndpoint
            {
                Name = Name,
                HostName = HostName,
                SessionAffinityEnabledState = !this.IsParameterBound(c => c.SessionAffinityEnabledState) ? PSEnabledState.Disabled : SessionAffinityEnabledState,
                SessionAffinityTtlSeconds = !this.IsParameterBound(c => c.SessionAffinityTtlInSeconds) ? 0 : SessionAffinityTtlInSeconds,
                WebApplicationFirewallPolicyLink = WebApplicationFirewallPolicyLink,
                CustomHttpsConfiguration = customHttpsConfiguration
            };
            WriteObject(FrontendEndpoint);
        }

    }
}
