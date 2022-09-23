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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayBackendSettingsBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the backend settings")]
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
        [ValidateSet("TCP", "TLS", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Timeout. Default value 30 seconds.")]
        [ValidateNotNullOrEmpty]
        public int Timeout { get; set; }

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
            HelpMessage = "Application gateway Trusted Root Certificates")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayTrustedRootCertificate[] TrustedRootCertificate { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag if host header should be picked from the host name of the backend server.")]
        public SwitchParameter PickHostNameFromBackendAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sets host header to be sent to the backend servers.")]
        public string HostName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Probe != null)
            {
                this.ProbeId = this.Probe.Id;
            }
        }
        public PSApplicationGatewayBackendSettings NewObject()
        {
            var backendSettings = new PSApplicationGatewayBackendSettings();
            backendSettings.Name = this.Name;
            backendSettings.Port = this.Port;
            backendSettings.Protocol = this.Protocol;

            if (0 == this.Timeout)
            {
                backendSettings.Timeout = 30;
            }
            else
            {
                backendSettings.Timeout = this.Timeout;
            }

            if (!string.IsNullOrEmpty(this.ProbeId))
            {
                backendSettings.Probe = new PSResourceId();
                backendSettings.Probe.Id = this.ProbeId;
            }

            if (this.TrustedRootCertificate != null && this.TrustedRootCertificate.Length > 0)
            {
                backendSettings.TrustedRootCertificates = new List<PSResourceId>();
                foreach (var trustedRootCert in this.TrustedRootCertificate)
                {
                    backendSettings.TrustedRootCertificates.Add(
                        new PSResourceId()
                        {
                            Id = trustedRootCert.Id
                        });
                }
            }

            if(this.PickHostNameFromBackendAddress.IsPresent)
            {
                backendSettings.PickHostNameFromBackendAddress = true;
            }

            if(this.HostName != null)
            {
                backendSettings.HostName = this.HostName;
            }

            backendSettings.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewaybackendSettingsName,
                                    this.Name);

            return backendSettings;
        }
    }
}
