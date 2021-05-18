// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Cdn.Common
{
    public static class AfdResourceConstants
    {
        public const string AfdResourceLocation = "Global";
    }

    public static class AfdResourceProcessMessage
    {
        public const string AfdCustomDomainCreateMessage = "Creating the Azure Front Door custom domain.";
        public const string AfdCustomDomainDeleteMessage = "Deleting the Azure Front Door custom domain.";
        public const string AfdCustomDomainUpdateMessage = "Updating the Azure Front Door custom domain.";
        public const string AfdEndpointCreateMessage = "Creating the Azure Front Door endpoint.";
        public const string AfdEndpointDeleteMessage = "Deleting the Azure Front Door endpoint";
        public const string AfdEndpointUpdateMessage = "Updating the Azure Front Door endpoint.";
        public const string AfdOriginCreateMessage = "Creating the Azure Front Door origin.";
        public const string AfdOriginDeleteMessage = "Deleting the Azure Front Door origin.";
        public const string AfdOriginUpdateMessage = "Updating the Azure Front Door origin.";
        public const string AfdOriginGroupCreateMessage = "Creating the Azure Front Door origin group.";
        public const string AfdOriginGroupDeleteMessage = "Deleting the Azure Front Door origin group.";
        public const string AfdOriginGroupUpdateMessage = "Updating the Azure Front Door origin group.";
        public const string AfdProfileCreateMessage = "Creating the Azure Front Door profile.";
        public const string AfdProfileDeleteMessage = "Deleting the Azure Front Door profile.";
        public const string AfdProfileUpdateMessage = "Updating the Azure Front Door profile.";
        public const string AfdRouteCreateMessage = "Creating the Azure Front Door route.";
        public const string AfdRouteDeleteMessage = "Deleting the Azure Front Door route.";
        public const string AfdRouteUpdateMessage = "Updating the Azure Front Door route.";
        public const string AfdRuleCreateMessage = "Creating the Azure Front Door rule.";
        public const string AfdRuleDeleteMessage = "Deleting the Azure Front Door rule.";
        public const string AfdRuleSetCreateMessage = "Creating the Azure Front Door rule set.";
        public const string AfdRuleSetDeleteMessage = "Deleting the Azure Front Door rule set.";
        public const string AfdSecretCreateMessage = "Creating the Azure Front Door secret.";
        public const string AfdSecretDeleteMessage = "Deleteing the Azure Front Door secret.";
        public const string AfdSecretUpdateMessage = "Updating the Azure Front Door secret.";
        public const string AfdSecurityPolicyCreateMessage = "Creating the Azure Front Door security policy.";
        public const string AfdSecurityPolicyDeleteMessage = "Deleting the Azure Front Door security policy.";
        public const string AfdSecurityPolicyUpdateMessage = "Updating the Azure Front Door security policy.";
    }

    public static class AfdSkuConstants
    {
        public const string PremiumAzureFrontDoor = "Premium_AzureFrontDoor";
        public const string StandardAzureFrontDoor = "Standard_AzureFrontDoor";
    }

    public static class HelpMessageConstants
    {
        public const string AfdCustomDomainAzureDnsZoneId = "The resource reference to the Azure DNS zone.";
        public const string AfdCustomDomainHostName = "The host name of the domain. Must be a domain name.";
        public const string AfdCustomDomainIds = "The resource ids of the Azure Front Door custom domains.";
        public const string AfdCustomDomainMinimumTlsVersion = "TLS protocol version that will be used for Https";
        public const string AfdCustomDomainName = "The Azure Front Door custom domain name.";
        public const string AfdCustomDomainObject = "The Azure Front Door custom domain object.";
        public const string AfdCustomDomainSecretId = "The resource reference to the secret.";
        public const string AfdEndpointObject = "The Azure Front Door endpoint object.";
        public const string AfdEndpointName = "The Azure Front Door endpoint name.";
        public const string AfdOriginGroupAdditionalLatencyInMilliseconds = "The additional latency in milliseconds for probes to fall into the lowest latency bucket.";
        public const string AfdOriginHostHeader = "The host header value sent to the origin with each request. If you leave this blank, the request hostname determines this value.";
        public const string AfdOriginHostName = "The address of the origin. Domain names, IPv4 addresses, and IPv6 addresses are supported.This should be unique across all origins in an endpoint.";
        public const string AfdOriginHttpPort = "The value of the HTTP port. Must be between 1 and 65535.";
        public const string AfdOriginHttpsPort = "The value of the HTTPS port. Must be between 1 and 65535.";
        public const string AfdOriginGroupId = "The resource id of the Azure Front Door origin group.";
        public const string AfdOriginGroupName = "The Azure Front Door origin group name.";
        public const string AfdOriginGroupObject = "The Azure Front Door origin group object.";
        public const string AfdOriginGroupProbeIntervalInSeconds = "The number of seconds between health probes.";
        public const string AfdOriginGroupProbePath = "The path relative to the origin that is used to determine the health of the origin.";
        public const string AfdOriginGroupProbeProtocol = "Protocol to use for health probe.";
        public const string AfdOriginGroupProbeRequestType = "The type of health probe request that is made.";
        public const string AfdOriginGroupSampleSize = "The number of samples to consider for load balancing decisions.";
        public const string AfdOriginGroupSuccessfulSamplesRequired = "The number of samples within the sample period that must succeed.";
        public const string AfdOriginGroupTrafficRestorationTimeToHealedOrNewEndpointsInMinutes = "Time in minutes to shift the traffic to the endpoint gradually when an unhealthy endpoint comes healthy or a new endpoint is added.";
        public const string AfdOriginName = "The Azure Front Door origin name.";
        public const string AfdOriginObject = "The Azure Front Door origin object.";
        public const string AfdOriginPriority = "Priority of origin in given origin group for load balancing. Higher priorities will not be used for load balancing if any lower priority origin is healthy.";
        public const string AfdOriginPrivateLinkId = "The Azure resource id of the shared private link resource.";
        public const string AfdOriginPrivateLinkLocation = "The location of the shared private link resource.";
        public const string AfdOriginPrivateLinkRequestMessage = "The request message for requesting approval of the shared private link resource.";
        public const string AfdOriginWeight = "Weight of the origin in given origin group for load balancing.";
        public const string AfdProfileName = "The Azure Front Door profile name.";
        public const string AfdProfileSku = "The Azure Front Door profile SKU.";
        public const string AfdProfileObject = "The Azure Front Door profile object.";
        public const string AfdRouteForwardingProtocol = "Protocol this rule will use when forwarding traffic to backends.";
        public const string AfdRouteHttpsRedirect = "Whether to automatically redirect HTTP traffic to HTTPS traffic.";
        public const string AfdRouteName = "The Azure Front Door route name.";
        public const string AfdRouteObject = "The Azure Front Door route object.";
        public const string AfdRouteOriginPath = "A directory path on the origin that Azure Front Door can use to retrieve content from, e.g. contoso.cloudapp.net/originpath.";
        public const string AfdRouteQueryStringCachingBehavior = "Defines how Azure Front Door caches requests that include query strings.";
        public const string AfdRouteSupportedProtocols = "List of supported protocols for this route.";
        public const string AfdRuleActions = "The set of actions for the delivery rule.";
        public const string AfdRuleCachingBehavior = "Caching behavior for the action.";
        public const string AfdRuleCacheDuration = "The duration for which the content needs to be cached. Allowed format is [d.]hh:mm:ss";
        public const string AfdRuleConditions = "The set of conditions for the delivery rule.";
        public const string AfdRuleCustomFragment = "Fragment to add to the redirect URL. Fragment is the part of the URL that comes after #. Do not include the #.";
        public const string AfdRuleCustomHostname = "Host to redirect. Leave empty to use the incoming host as the destination host.";
        public const string AfdRuleCustomPath = "The full path to redirect. Path cannot be empty and must start with /. Leave empty to use the incoming path as destination path.";
        public const string AfdRuleCustomQueryString = "The set of query strings to be placed in the redirect URL. Setting this value would replace any existing query string; leave empty to preserve the incoming query string. Query string must be in <key>=<value> format. ? and & will be added automatically so do not include them.";
        public const string AfdRuleDestination = "Define the relative URL to which the above requests will be rewritten by.";
        public const string AfdRuleDestinationProtocol = "Protocol to use for the redirect. The default value is MatchRequest.";
        public const string AfdRuleHeaderAction = "Action to perform.";
        public const string AfdRuleHeaderName = "Name of the header to modify.";
        public const string AfdRuleHeaderType = "Whether to modify request header or response header.";
        public const string AfdRuleHeaderValue = "Value for the specified action.";
        public const string AfdRuleMatchProcessingBehavior = "If this rule is a match should the rules engine continue running the remaining rules or stop. If not present, defaults to Continue.";
        public const string AfdRuleMatchValue = "Match values to match against. The operator will apply to each value in here with OR semantics. If any of them match the variable with the given operator this match condition is considered a match.";
        public const string AfdRuleMatchVariable = "A list of conditions that must be matched for the actions to be executed.";
        public const string AfdRuleName = "The Azure Front Door rule name.";
        public const string AfdRuleNegateCondition = "Describes if the result of this condition should be negated.";
        public const string AfdRuleObject = "The Azure Front Door rule object.";
        public const string AfdRuleOperator = "Describes operator to be matched.";
        public const string AfdRuleOrder = "The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will be applied before a rule with a greater order.";
        public const string AfdRuleOriginGroupOverride = "Defines the origin group override action for the delivery rule.";
        public const string AfdRulePreservePath = "Whether to preserve unmatched path.";
        public const string AfdRuleQueryParameters = "Query parameters to include or exclude (comma separated).";
        public const string AfdRuleQueryStringBehavior = "Defines the parameters for the cache-key query string action. Accepted values : Include, IncludeAll, Exclude, ExcludeAll";
        public const string AfdRuleRedirectType = "The redirect type the rule will use when redirecting traffic.";
        public const string AfdRuleSelector = "Name of Selector to be matched.";
        public const string AfdRuleSetIds = "The resource ids of the Azure Front Door rule sets.";
        public const string AfdRuleSetName = "The Azure Front Door rule set name.";
        public const string AfdRuleSetObject = "The Azure Front Door rule set object.";
        public const string AfdRuleSourcePattern = "Define a request URI pattern that identifies the type of requests that may be rewritten. If value is blank, all strings are matched.";
        public const string AfdRuleTransform = "Transform to apply before matching. Possible values are Lowercase and Uppercase.";
        public const string AfdSecretCertificateAuthority = "The certificate issuing authority.";
        public const string AfdSecretName = "The Azure Front Door secret name.";
        public const string AfdSecretObject = "The Azure Front Door secret object.";
        public const string AfdSecretSubjectAlternativeNames = "The list of the subject alternative names.";
        public const string AfdSecretSource = "The resource reference to the Azure Key Vault secret.";
        public const string AfdSecretUseLatestVersion = "Whether to use the latest version for the certificate.";
        public const string AfdSecretVersion = "The version of the secret to be used";
        public const string AfdSecurityPolicyDomainIds = "The resource ids of the domains which will be linked to the Azure Front Door web application firewall.";
        public const string AfdSecurityPolicyObject = "The Azure Front Door security policy object.";
        public const string AfdSecurityPolicyName = "The Azure Front Door security policy name.";
        public const string AfdSecurityPolicyWafPolicyId = "The resource id of the Azure Front Door web application firewall.";
        public const string PassThruParameter = "Set by the user to signal that they would like to receive output from a cmdlet which does not return anything.";
        public const string ResourceId = "The Azure resource id.";
        public const string ResourceGroupName = "The Azure resource group name.";
        public const string TagsDescription = "The tags associated to the Azure resource.";
    }

    public static class AfdParameterSet 
    {
        public const string AfdRuleCacheExpirationAction = "AfdRuleCacheExpirationAction";
        public const string AfdRuleCacheKeyQueryStringAction = "AfdRuleCacheKeyQueryStringAction";
        public const string AfdRuleHeaderTypeAction = "AfdRuleHeaderTypeAction";
        public const string AfdRuleOriginGroupOverrideAction = "AfdRuleOriginGroupOverrideAction";
        public const string AfdRuleUrlRedirectAction = "AfdRuleUrlRedirectAction";
        public const string AfdRuleUrlRewriteAction = "AfdRuleUrlRewriteAction";
        public const string AfdCustomDomainCustomerCertificate = "AfdCustomDomainCustomerCertificate";
        public const string SharedPrivateLinkResource = "SharedPrivateLinkResource";
    }
}
