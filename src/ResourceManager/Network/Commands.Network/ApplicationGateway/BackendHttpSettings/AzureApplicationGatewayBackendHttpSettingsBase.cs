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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayBackendHttpSettingsBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the backend http settings")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Port")]
        [ValidateNotNullOrEmpty]
        public int Port { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Protocol")]
        [ValidateSet("Http", "Https", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Cookie Based Affinity")]
        [ValidateSet("Enabled", "Disabled", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string CookieBasedAffinity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Request Timeout. Default value 30 seconds.")]
        [ValidateNotNullOrEmpty]
        public uint RequestTimeout { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "ID of the application gateway Probe")]
        [ValidateNotNullOrEmpty]
        public string ProbeId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application gateway Probe")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayProbe Probe { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application gateway Authentication Certificates")]
        [ValidateNotNullOrEmpty]
        public List<PSApplicationGatewayAuthenticationCertificate> AuthenticationCertificates { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Probe != null)
            {
                this.ProbeId = this.Probe.Id;
            }
        }
        public PSApplicationGatewayBackendHttpSettings NewObject()
        {
            var backendHttpSettings = new PSApplicationGatewayBackendHttpSettings();
            backendHttpSettings.Name = this.Name;
            backendHttpSettings.Port = this.Port;
            backendHttpSettings.Protocol = this.Protocol;
            backendHttpSettings.CookieBasedAffinity = this.CookieBasedAffinity;
            if (0 == this.RequestTimeout)
            {
                backendHttpSettings.RequestTimeout = 30;
            }
            else
            {
                backendHttpSettings.RequestTimeout = this.RequestTimeout;
            }
            if (!string.IsNullOrEmpty(this.ProbeId))
            {
                backendHttpSettings.Probe = new PSResourceId();
                backendHttpSettings.Probe.Id = this.ProbeId;
            }
            if (this.AuthenticationCertificates != null && this.AuthenticationCertificates.Count > 0)
            {
                backendHttpSettings.AuthenticationCertificates = new List<PSResourceId>();
                foreach (var authcert in this.AuthenticationCertificates)
                {
                    backendHttpSettings.AuthenticationCertificates.Add(
                        new PSResourceId()
                        {
                            Id = authcert.Id
                        });
                }
            }
            backendHttpSettings.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewaybackendHttpSettingsName,
                                    this.Name);
            return backendHttpSettings;
        }
    }
}
