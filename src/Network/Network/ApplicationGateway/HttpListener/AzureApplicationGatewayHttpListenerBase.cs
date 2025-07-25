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
    public class AzureApplicationGatewayHttpListenerBase : NetworkBaseCmdlet
    {
        [Parameter(
                Mandatory = true,
                HelpMessage = "The name of the HTTP listener")]
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
           ParameterSetName = "SetByResourceId",
           HelpMessage = "FirewallPolicyId")]
        public string FirewallPolicyId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "FirewallPolicy")]
        public PSApplicationGatewayWebApplicationFirewallPolicy FirewallPolicy { get; set; }

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
               HelpMessage = "Host name")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(
            HelpMessage = "Host names")]
        [ValidateNotNullOrEmpty]
        public string[] HostNames { get; set; }

        [Parameter(
               HelpMessage = "RequireServerNameIndication")]
        [ValidateSet("true", "false", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RequireServerNameIndication { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Protocol")]
        [ValidateSet("Http", "Https", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
                HelpMessage = "Customer error of an application gateway")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayCustomError[] CustomErrorConfiguration { get; set; }

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

                if (FirewallPolicy != null)
                {
                    this.FirewallPolicyId = this.FirewallPolicy.Id;
                }

                if (SslProfile != null)
                {
                    this.SslProfileId = this.SslProfile.Id;
                }
            }
        }

        public PSApplicationGatewayHttpListener NewObject()
        {
            var httpListener = new PSApplicationGatewayHttpListener();
            httpListener.Name = this.Name;
            httpListener.Protocol = this.Protocol;
            httpListener.HostName = this.HostName;

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

            if (!string.IsNullOrEmpty(this.FirewallPolicyId))
            {
                httpListener.FirewallPolicy = new PSResourceId();
                httpListener.FirewallPolicy.Id = this.FirewallPolicyId;
            }

            if (!string.IsNullOrEmpty(this.SslProfileId))
            {
                httpListener.SslProfile = new PSResourceId();
                httpListener.SslProfile.Id = this.SslProfileId;
            }

            if (this.HostNames != null)
            {
                httpListener.HostNames = this.HostNames?.ToList();
            }

            if (this.CustomErrorConfiguration != null)
            {
                httpListener.CustomErrorConfigurations = this.CustomErrorConfiguration?.ToList();
            }

            httpListener.Id = ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                                this.NetworkClient.NetworkManagementClient.SubscriptionId,
                                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayHttpListenerName,
                                this.Name);

            return httpListener;
        }
    }
}
