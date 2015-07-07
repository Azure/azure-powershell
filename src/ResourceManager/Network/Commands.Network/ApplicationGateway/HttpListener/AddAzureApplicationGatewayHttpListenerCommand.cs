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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureApplicationGatewayHttpListener"), OutputType(typeof(PSApplicationGateway))]
    public class AddAzureApplicationGatewayHttpListenerCommand : AzureApplicationGatewayHttpListenerBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var httpListener = this.ApplicationGateway.HttpListeners.SingleOrDefault
                (resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (httpListener != null)
            {
                throw new ArgumentException("Http Listener with the specified name already exists");
            }

            httpListener = new PSApplicationGatewayHttpListener();
            httpListener.Name = this.Name;
            httpListener.Protocol = this.Protocol;

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

            httpListener.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkResourceProviderClient.Credentials.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayHttpListenerName,
                                this.Name);

            this.ApplicationGateway.HttpListeners.Add(httpListener);

            WriteObject(this.ApplicationGateway);
        }
    }
}
