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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGateway", DefaultParameterSetName = "IdentityByUserAssignedIdentityId", SupportsShouldProcess = true), OutputType(typeof(PSApplicationGateway))]
    public class NewAzureApplicationGatewayCommand : ApplicationGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/applicationGateways")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SKU of application gateway")]
        [ValidateNotNullOrEmpty]
        public virtual PSApplicationGatewaySku Sku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SSL policy of application gateway")]
        public virtual PSApplicationGatewaySslPolicy SslPolicy { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of IPConfiguration (subnet)")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayIPConfiguration[] GatewayIPConfigurations { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of ssl certificates")]
        public PSApplicationGatewaySslCertificate[] SslCertificates { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of authentication certificates")]
        public PSApplicationGatewayAuthenticationCertificate[] AuthenticationCertificates { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of trusted root certificates")]
        public PSApplicationGatewayTrustedRootCertificate[] TrustedRootCertificate { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of trusted client CA certificate chains")]
        public PSApplicationGatewayTrustedClientCertificate[] TrustedClientCertificates { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of frontend IP config")]
        public PSApplicationGatewayFrontendIPConfiguration[] FrontendIPConfigurations { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of frontend port")]
        public PSApplicationGatewayFrontendPort[] FrontendPorts { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of probe")]
        public PSApplicationGatewayProbe[] Probes { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of backend address pool")]
        public PSApplicationGatewayBackendAddressPool[] BackendAddressPools { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of backend http settings")]
        public PSApplicationGatewayBackendHttpSettings[] BackendHttpSettingsCollection { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of backend settings")]
        public PSApplicationGatewayBackendSettings[] BackendSettingsCollection { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of ssl profiles")]
        public PSApplicationGatewaySslProfile[] SslProfiles { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of http listener")]
        public PSApplicationGatewayHttpListener[] HttpListeners { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of listener")]
        public PSApplicationGatewayListener[] Listeners { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of UrlPathMap")]
        public PSApplicationGatewayUrlPathMap[] UrlPathMaps { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of request routing rule")]
        public PSApplicationGatewayRequestRoutingRule[] RequestRoutingRules { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of routing rule")]
        public PSApplicationGatewayRoutingRule[] RoutingRules { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of RewriteRuleSet")]
        public PSApplicationGatewayRewriteRuleSet[] RewriteRuleSet { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of redirect configuration")]
        public PSApplicationGatewayRedirectConfiguration[] RedirectConfigurations { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Firewall configuration")]
        public virtual PSApplicationGatewayWebApplicationFirewallConfiguration WebApplicationFirewallConfiguration { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "FirewallPolicyId")]
        public string FirewallPolicyId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResource",
            HelpMessage = "FirewallPolicy")]
        public PSApplicationGatewayWebApplicationFirewallPolicy FirewallPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Autoscale Configuration")]
        public virtual PSApplicationGatewayAutoscaleConfiguration AutoscaleConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = " Whether HTTP2 is enabled.")]
        public SwitchParameter EnableHttp2 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = " Whether FIPS is enabled.")]
        public SwitchParameter EnableFIPS { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = " Whether Request Buffering is enabled.")]
        public bool? EnableRequestBuffering { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = " Whether Response Buffering is enabled.")]
        public bool? EnableResponseBuffering { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = " Whether Force firewallPolicy association is enabled.")]
        public SwitchParameter ForceFirewallPolicyAssociation { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of availability zones denoting where the application gateway needs to come from.")]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = "IdentityByUserAssignedIdentityId",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ResourceId of the user assigned identity to be assigned to Application Gateway.")]
        [ValidateNotNullOrEmpty]
        [Alias("UserAssignedIdentity")]
        public string UserAssignedIdentityId { get; set; }

        [Parameter(
            ParameterSetName = "IdentityByIdentityObject",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Identity to be assigned to Application Gateway.")]
        [ValidateNotNullOrEmpty]
        public PSManagedServiceIdentity Identity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Customer error of an application gateway")]
        [ValidateNotNullOrEmpty]
        public PSApplicationGatewayCustomError[] CustomErrorConfiguration { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of privateLink Configuration")]
        public PSApplicationGatewayPrivateLinkConfiguration[] PrivateLinkConfiguration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.FirewallPolicy != null)
                {
                    this.FirewallPolicyId = this.FirewallPolicy.Id;
                }
            }

            var present = this.IsApplicationGatewayPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResource, Name),
                Microsoft.Azure.Commands.Network.Properties.Resources.OverwritingResourceMessage,
                Name,
                () =>
                {
                    var applicationGateway = CreateApplicationGateway();
                    WriteObject(applicationGateway);
                },
                () => present);
        }

        private PSApplicationGateway CreateApplicationGateway()
        {
            var applicationGateway = new PSApplicationGateway();
            applicationGateway.Name = this.Name;
            applicationGateway.ResourceGroupName = this.ResourceGroupName;
            applicationGateway.Location = this.Location;
            applicationGateway.Sku = this.Sku;

            if (this.SslPolicy != null)
            {
                applicationGateway.SslPolicy = new PSApplicationGatewaySslPolicy();
                applicationGateway.SslPolicy = this.SslPolicy;
            }

            if (this.GatewayIPConfigurations != null)
            {
                applicationGateway.GatewayIPConfigurations = this.GatewayIPConfigurations?.ToList();
            }

            if (this.SslCertificates != null)
            {
                applicationGateway.SslCertificates = this.SslCertificates?.ToList();
            }

            if (this.AuthenticationCertificates != null)
            {
                applicationGateway.AuthenticationCertificates = this.AuthenticationCertificates?.ToList();
            }

            if (this.TrustedRootCertificate != null)
            {
                applicationGateway.TrustedRootCertificates =this.TrustedRootCertificate?.ToList();
            }

            if (this.TrustedClientCertificates != null)
            {
                applicationGateway.TrustedClientCertificates = this.TrustedClientCertificates?.ToList();
            }

            if (this.FrontendIPConfigurations != null)
            {
                applicationGateway.FrontendIPConfigurations = this.FrontendIPConfigurations?.ToList();
            }

            if (this.FrontendPorts != null)
            {
                applicationGateway.FrontendPorts = this.FrontendPorts?.ToList();
            }

            if (this.Probes != null)
            {
                applicationGateway.Probes = this.Probes?.ToList();
            }

            if (this.BackendAddressPools != null)
            {
                applicationGateway.BackendAddressPools = this.BackendAddressPools?.ToList();
            }

            if (this.BackendHttpSettingsCollection != null)
            {
                applicationGateway.BackendHttpSettingsCollection = this.BackendHttpSettingsCollection?.ToList();
            }

            if (this.BackendSettingsCollection != null)
            {
                applicationGateway.BackendSettingsCollection = this.BackendSettingsCollection?.ToList();
            }

            if (this.SslProfiles != null)
            {
                applicationGateway.SslProfiles = this.SslProfiles?.ToList();
            }

            if (this.HttpListeners != null)
            {
                applicationGateway.HttpListeners = this.HttpListeners?.ToList();
            }

            if (this.Listeners != null)
            {
                applicationGateway.Listeners = this.Listeners?.ToList();
            }

            if (this.UrlPathMaps != null)
            {
                applicationGateway.UrlPathMaps = this.UrlPathMaps?.ToList();
            }

            if (this.RequestRoutingRules != null)
            {
                applicationGateway.RequestRoutingRules = this.RequestRoutingRules?.ToList();
            }

            if (this.RoutingRules != null)
            {
                applicationGateway.RoutingRules = this.RoutingRules?.ToList();
            }

            if (this.RewriteRuleSet != null)
            {
                applicationGateway.RewriteRuleSets = this.RewriteRuleSet?.ToList();
            }

            if (this.RedirectConfigurations != null)
            {
                applicationGateway.RedirectConfigurations = this.RedirectConfigurations?.ToList();
            }

            if (this.WebApplicationFirewallConfiguration != null)
            {
                applicationGateway.WebApplicationFirewallConfiguration = this.WebApplicationFirewallConfiguration;
            }

            if (!string.IsNullOrEmpty(this.FirewallPolicyId))
            {
                applicationGateway.FirewallPolicy = new PSResourceId();
                applicationGateway.FirewallPolicy.Id = this.FirewallPolicyId;
            }

            if (this.AutoscaleConfiguration != null)
            {
                applicationGateway.AutoscaleConfiguration = this.AutoscaleConfiguration;
            }

            if (this.PrivateLinkConfiguration != null)
            {
                applicationGateway.PrivateLinkConfigurations = this.PrivateLinkConfiguration?.ToList();
            }

            if (this.EnableHttp2.IsPresent)
            {
                applicationGateway.EnableHttp2 = true;
            }

            if (this.EnableFIPS.IsPresent)
            {
                applicationGateway.EnableFips = true;
            }

            if (!string.Equals(applicationGateway.Sku.Tier, "Standard", StringComparison.OrdinalIgnoreCase) && !string.Equals(applicationGateway.Sku.Tier, "WAF", StringComparison.OrdinalIgnoreCase))
            {
                applicationGateway.GlobalConfiguration = new PSApplicationGatewayGlobalConfiguration();

                if (this.EnableRequestBuffering.HasValue)
                {
                    applicationGateway.GlobalConfiguration.EnableRequestBuffering = this.EnableRequestBuffering.Value;
                }
                else
                {
                    applicationGateway.GlobalConfiguration.EnableRequestBuffering = true;
                }

                if (this.EnableResponseBuffering.HasValue)
                {
                    applicationGateway.GlobalConfiguration.EnableResponseBuffering = this.EnableResponseBuffering.Value;
                }
                else
                {
                    applicationGateway.GlobalConfiguration.EnableResponseBuffering = true;
                }
            }

            if (this.ForceFirewallPolicyAssociation.IsPresent)
            {
                applicationGateway.ForceFirewallPolicyAssociation = true;
            }

            if (this.Zone != null)
            {
                applicationGateway.Zones = this.Zone?.ToList();
            }

            if (this.UserAssignedIdentityId != null)
            {
                applicationGateway.Identity = new PSManagedServiceIdentity
                {
                    Type = MNM.ResourceIdentityType.UserAssigned,
                    UserAssignedIdentities = new Dictionary<string, PSManagedServiceIdentityUserAssignedIdentitiesValue>
                    {
                        { this.UserAssignedIdentityId, new PSManagedServiceIdentityUserAssignedIdentitiesValue() }
                    }
                };
            }
            else if (this.Identity != null)
            {
                applicationGateway.Identity = this.Identity;
            }

            if (this.CustomErrorConfiguration != null)
            {
                applicationGateway.CustomErrorConfigurations = this.CustomErrorConfiguration?.ToList();
            }

            // Normalize the IDs
            ApplicationGatewayChildResourceHelper.NormalizeChildIds(applicationGateway, this.ResourceGroupName, this.Name);

            // Map to the sdk object
            var appGwModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ApplicationGateway>(applicationGateway);
            appGwModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create ApplicationGateway call
            this.ApplicationGatewayClient.CreateOrUpdate(this.ResourceGroupName, this.Name, appGwModel);

            var getApplicationGateway = this.GetApplicationGateway(this.ResourceGroupName, this.Name);

            return getApplicationGateway;
        }
    }
}
