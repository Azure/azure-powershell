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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayBackendHttpSettings"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayBackendHttpSettingsCommand : AzureApplicationGatewayBackendHttpSettingsBase
    {
        [Parameter(
                 Mandatory = true,
                 ValueFromPipeline = true,
                 HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Port")]
        [ValidateNotNullOrEmpty]
        public override int Port { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Protocol")]
        [ValidateSet("Http", "Https", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string Protocol { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Cookie Based Affinity")]
        [ValidateSet("Enabled", "Disabled", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string CookieBasedAffinity { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var backendHttpSettings = this.ApplicationGateway.BackendHttpSettingsCollection.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (backendHttpSettings == null)
            {
                throw new ArgumentException("Backend http settings with the specified name does not exist");
            }

            if (MyInvocation.BoundParameters.ContainsKey("Port"))
            {
                backendHttpSettings.Port = this.Port;
            }

            if (this.Protocol != null)
            {
                backendHttpSettings.Protocol = this.Protocol;
            }

            if (this.CookieBasedAffinity != null)
            {
                backendHttpSettings.CookieBasedAffinity = this.CookieBasedAffinity;
            }

            if(MyInvocation.BoundParameters.ContainsKey("RequestTimeout"))
            {
                backendHttpSettings.RequestTimeout = this.RequestTimeout;
            }

            if (this.ConnectionDraining != null)
            {
                backendHttpSettings.ConnectionDraining = this.ConnectionDraining;
            }

            if (!string.IsNullOrEmpty(this.ProbeId))
            {
                backendHttpSettings.Probe = new PSResourceId();
                backendHttpSettings.Probe.Id = this.ProbeId;
            }

            if (this.AuthenticationCertificates != null && this.AuthenticationCertificates.Length > 0)
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

            if (this.TrustedRootCertificate != null && this.TrustedRootCertificate.Length > 0)
            {
                backendHttpSettings.TrustedRootCertificates = new List<PSResourceId>();
                foreach (var trustedRootCert in this.TrustedRootCertificate)
                {
                    backendHttpSettings.TrustedRootCertificates.Add(
                        new PSResourceId()
                        {
                            Id = trustedRootCert.Id
                        });
                }
            }

            if (this.PickHostNameFromBackendAddress.IsPresent)
            {
                backendHttpSettings.PickHostNameFromBackendAddress = true;
            }
            else
            {
                backendHttpSettings.PickHostNameFromBackendAddress = false;
            }

            if (this.HostName != null)
            {
                backendHttpSettings.HostName = this.HostName;
            }

            if (this.AffinityCookieName != null)
            {
                backendHttpSettings.AffinityCookieName = this.AffinityCookieName;
            }

            if (this.Path != null)
            {
                backendHttpSettings.Path = this.Path;
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
