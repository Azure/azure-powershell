//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGateway : PSTopLevelResource
    {
        [Ps1Xml(Label = "Sku Name", Target = ViewControl.Table, ScriptBlock = "$_.Sku.Name")]
        public PSApplicationGatewaySku Sku { get; set; }

        [Ps1Xml(Label = "Policy Name", Target = ViewControl.Table, ScriptBlock = "$_.SslPolicy.PolicyName")]
        public PSApplicationGatewaySslPolicy SslPolicy { get; set; }

        public PSApplicationGatewayGlobalConfiguration GlobalConfiguration { get; set; }

        public List<PSApplicationGatewayIPConfiguration> GatewayIPConfigurations { get; set; }

        public List<PSApplicationGatewayAuthenticationCertificate> AuthenticationCertificates { get; set; }

        public List<PSApplicationGatewaySslCertificate> SslCertificates { get; set; }

        public List<PSApplicationGatewayTrustedRootCertificate> TrustedRootCertificates { get; set; }

        public List<PSApplicationGatewayTrustedClientCertificate> TrustedClientCertificates { get; set; }

        public List<PSApplicationGatewayFrontendIPConfiguration> FrontendIPConfigurations { get; set; }

        public List<PSApplicationGatewayFrontendPort> FrontendPorts { get; set; }

        public List<PSApplicationGatewayProbe> Probes { get; set; }

        public List<PSApplicationGatewayBackendAddressPool> BackendAddressPools { get; set; }

        public List<PSApplicationGatewayBackendHttpSettings> BackendHttpSettingsCollection { get; set; }

        public List<PSApplicationGatewayBackendSettings> BackendSettingsCollection { get; set; }

        public List<PSApplicationGatewaySslProfile> SslProfiles { get; set; }

        public List<PSApplicationGatewayHttpListener> HttpListeners { get; set; }

        public List<PSApplicationGatewayListener> Listeners { get; set; }

        public List<PSApplicationGatewayUrlPathMap> UrlPathMaps { get; set; }

        public List<PSApplicationGatewayRequestRoutingRule> RequestRoutingRules { get; set; }

        public List<PSApplicationGatewayRoutingRule> RoutingRules { get; set; }

        public List<PSApplicationGatewayRewriteRuleSet> RewriteRuleSets { get; set; }

        public List<PSApplicationGatewayRedirectConfiguration> RedirectConfigurations { get; set; }

        public PSApplicationGatewayWebApplicationFirewallConfiguration WebApplicationFirewallConfiguration { get; set; }

        public PSResourceId FirewallPolicy { get; set; }

        public PSApplicationGatewayAutoscaleConfiguration AutoscaleConfiguration { get; set; }

        public List<PSApplicationGatewayCustomError> CustomErrorConfigurations { get; set; }

        public List<PSApplicationGatewayPrivateLinkConfiguration> PrivateLinkConfigurations { get; set; }

        public List<PSApplicationGatewayPrivateEndpointConnection> PrivateEndpointConnections { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? EnableHttp2 { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? EnableFips { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? ForceFirewallPolicyAssociation { get; set; }
        
        public List<string> Zones { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string OperationalState { get; private set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSManagedServiceIdentity Identity { get; set; }

        [JsonIgnore]
        public string GatewayIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(GatewayIPConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string TrustedClientCertificatesText
        {
            get { return JsonConvert.SerializeObject(TrustedClientCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AuthenticationCertificatesText
        {
            get { return JsonConvert.SerializeObject(AuthenticationCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SslCertificatesText
        {
            get { return JsonConvert.SerializeObject(SslCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string FrontendIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(FrontendIPConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string FrontendPortsText
        {
            get { return JsonConvert.SerializeObject(FrontendPorts, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(BackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendHttpSettingsCollectionText
        {
            get { return JsonConvert.SerializeObject(BackendHttpSettingsCollection, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendSettingsCollectionText
        {
            get { return JsonConvert.SerializeObject(BackendSettingsCollection, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SslProfilesText
        {
            get { return JsonConvert.SerializeObject(SslProfiles, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string HttpListenersText
        {
            get { return JsonConvert.SerializeObject(HttpListeners, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ListenersText
        {
            get { return JsonConvert.SerializeObject(Listeners, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RewriteRuleSetsText
        {
            get { return JsonConvert.SerializeObject(RewriteRuleSets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RequestRoutingRulesText
        {
            get { return JsonConvert.SerializeObject(RequestRoutingRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RoutingRulesText
        {
            get { return JsonConvert.SerializeObject(RoutingRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ProbesText
        {
            get { return JsonConvert.SerializeObject(Probes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string UrlPathMapsText
        {
            get { return JsonConvert.SerializeObject(UrlPathMaps, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IdentityText
        {
            get { return JsonConvert.SerializeObject(Identity, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SslPolicyText
        {
            get { return JsonConvert.SerializeObject(SslPolicy, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
        
        [JsonIgnore]
        public string FirewallPolicyText
        {
            get { return JsonConvert.SerializeObject(FirewallPolicy, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateLinkConfigurationsText
        {
            get { return JsonConvert.SerializeObject(PrivateLinkConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateLinkEndpointConnectionsText
        {
            get { return JsonConvert.SerializeObject(PrivateEndpointConnections, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
