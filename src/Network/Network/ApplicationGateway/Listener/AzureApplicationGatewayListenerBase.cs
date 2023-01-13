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
    public class AzureApplicationGatewayListenerBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the Listener")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway FrontendIPConfiguration")]
        [ValidateNotNullOrEmpty]
        public string FrontendIPConfigurationId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway FrontendIPConfiguration")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFrontendIPConfiguration FrontendIPConfiguration { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway FrontendPort")]
        [ValidateNotNullOrEmpty]
        public string FrontendPortId { get; set; }

        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway FrontendPort")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayFrontendPort FrontendPort { get; set; }

        [Parameter(
                ParameterSetName = "SetByResourceId",
                HelpMessage = "ID of the application gateway SslCertificate")]
        [ValidateNotNullOrEmpty]
        public string SslCertificateId { get; set; }
        
        [Parameter(
                ParameterSetName = "SetByResource",
                HelpMessage = "Application gateway SslCertificate")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewaySslCertificate SslCertificate { get; set; }

        [Parameter(
           ParameterSetName = "SetByResourceId",
           HelpMessage = "SslProfileId")]
        public string SslProfileId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "SslProfile")]
        public PSApplicationGatewaySslProfile SslProfile { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Protocol")]
        [ValidateSet("TCP", "TLS", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

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
                
                if (SslProfile != null)
                {
                    this.SslProfileId = this.SslProfile.Id;
                }
            }
        }

        public PSApplicationGatewayListener NewObject()
        {
            var listener = new PSApplicationGatewayListener();
            listener.Name = this.Name;
            listener.Protocol = this.Protocol;

            if (!string.IsNullOrEmpty(this.FrontendIPConfigurationId))
            {
                listener.FrontendIpConfiguration = new PSResourceId();
                listener.FrontendIpConfiguration.Id = this.FrontendIPConfigurationId;
            }

            if (!string.IsNullOrEmpty(this.FrontendPortId))
            {
                listener.FrontendPort = new PSResourceId();
                listener.FrontendPort.Id = this.FrontendPortId;
            }

            if (!string.IsNullOrEmpty(this.SslCertificateId))
            {
                listener.SslCertificate = new PSResourceId();
                listener.SslCertificate.Id = this.SslCertificateId;
            }

            if (!string.IsNullOrEmpty(this.SslProfileId))
            {
                listener.SslProfile = new PSResourceId();
                listener.SslProfile.Id = this.SslProfileId;
            }            

            listener.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayListenerName,
                                this.Name);

            return listener;
        }
    }
}
