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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayHttpListener", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayHttpListenerCommand : AzureApplicationGatewayHttpListenerBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Protocol")]
        [ValidateSet("Http", "Https", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string Protocol { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var httpListener = this.ApplicationGateway.HttpListeners.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (httpListener == null)
            {
                throw new ArgumentException("Http Listener with the specified name does not exist");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (FrontendIPConfiguration != null)
                {
                    this.FrontendIPConfigurationId = this.FrontendIPConfiguration.Id;
                }
                if (FrontendPort != null)
                {
                    this.FrontendPortId = this.FrontendPort.Id;
                }
                if (SslCertificate != null)
                {
                    this.SslCertificateId = this.SslCertificate.Id;
                }
            }

            if (!string.IsNullOrEmpty(this.Protocol))
            {
                httpListener.Protocol = this.Protocol;
            }

            if (!string.IsNullOrEmpty(this.Protocol))
            {
                httpListener.HostName = this.HostName;
            }

            // TODO: check processing
            if (string.Equals(this.RequireServerNameIndication, "true", StringComparison.OrdinalIgnoreCase))
            {
                httpListener.RequireServerNameIndication = true;
            }
            else if (string.Equals(this.RequireServerNameIndication, "false", StringComparison.OrdinalIgnoreCase))
            {
                httpListener.RequireServerNameIndication = false;
            }
            else if (string.Equals(this.Protocol, "https", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(this.HostName))
            {
                // Set default as true to be at parity with portal.
                httpListener.RequireServerNameIndication = true;
            }

            if (!string.IsNullOrEmpty(this.FrontendIPConfigurationId))
            {
                httpListener.FrontendIpConfiguration = new PSResourceId();
                httpListener.FrontendIpConfiguration.Id = this.FrontendIPConfigurationId;
            }

            if (!string.IsNullOrEmpty(this.FrontendPortId))
            {
                httpListener.FrontendPort = new PSResourceId();
                httpListener.FrontendPort.Id = this.FrontendPortId;
            }

            if (!string.IsNullOrEmpty(this.SslCertificateId))
            {
                httpListener.SslCertificate = new PSResourceId();
                httpListener.SslCertificate.Id = this.SslCertificateId;
            }

            if (this.CustomErrorConfiguration != null)
            {
                httpListener.CustomErrorConfigurations = this.CustomErrorConfiguration?.ToList();
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
