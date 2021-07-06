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

using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Management.Cdn.Models;
using System.Collections.Generic;

using SdkAfdCustomDomain = Microsoft.Azure.Management.Cdn.Models.AFDDomain;
using SdkAfdEndpoint = Microsoft.Azure.Management.Cdn.Models.AFDEndpoint;
using SdkAfdOrigin = Microsoft.Azure.Management.Cdn.Models.AFDOrigin;
using SdkAfdOriginGroup = Microsoft.Azure.Management.Cdn.Models.AFDOriginGroup;
using SdkAfdProfile = Microsoft.Azure.Management.Cdn.Models.Profile;
using SdkAfdRoute = Microsoft.Azure.Management.Cdn.Models.Route;
using SdkAfdRule = Microsoft.Azure.Management.Cdn.Models.Rule;
using SdkAfdRuleSet = Microsoft.Azure.Management.Cdn.Models.RuleSet;
using SdkAfdSecret = Microsoft.Azure.Management.Cdn.Models.Secret;
using SdkAfdSecurityPolicy = Microsoft.Azure.Management.Cdn.Models.SecurityPolicy;

namespace Microsoft.Azure.Commands.Cdn.AfdHelpers
{
    public static class AfdModelExtensions
    {
        public static PSAfdCustomDomain ToPSAfdCustomDomain(this SdkAfdCustomDomain sdkAfdCustomDomain)
        {
            return new PSAfdCustomDomain
            {
                Id = sdkAfdCustomDomain.Id,
                Name = sdkAfdCustomDomain.Name,
                Type = sdkAfdCustomDomain.Type,
                ProvisioningState = sdkAfdCustomDomain.ProvisioningState,
                HostName = sdkAfdCustomDomain.HostName,
                CertificateType = sdkAfdCustomDomain.TlsSettings?.CertificateType,
                MinimumTlsVersion = sdkAfdCustomDomain.TlsSettings?.MinimumTlsVersion.ToString(),
                Secret = sdkAfdCustomDomain.TlsSettings?.Secret?.Id,
                ValidationToken = sdkAfdCustomDomain.ValidationProperties?.ValidationToken,
                ExpirationDate = sdkAfdCustomDomain.ValidationProperties?.ExpirationDate,
                AzureDnsZone = sdkAfdCustomDomain.AzureDnsZone?.Id,
                DomainValidationState = sdkAfdCustomDomain.DomainValidationState
            };
        }

        public static PSAfdEndpoint ToPSAfdEndpoint(this SdkAfdEndpoint sdkAfdEndpoint)
        {
            return new PSAfdEndpoint
            {
                Id = sdkAfdEndpoint.Id,
                Name = sdkAfdEndpoint.Name,
                Type = sdkAfdEndpoint.Type,
                ProvisioningState = sdkAfdEndpoint.ProvisioningState,
                Location = sdkAfdEndpoint.Location,
                Tags = TagsConversionHelper.CreateTagHashtable(sdkAfdEndpoint.Tags),
                HostName = sdkAfdEndpoint.HostName,
                EnabledState = sdkAfdEndpoint.EnabledState
            };
        }

        public static PSAfdOrigin ToPSAfdOrigin(this SdkAfdOrigin sdkOrigin)
        {
            JObject sharedPrivateLinkResourceJObject = (JObject)sdkOrigin.SharedPrivateLinkResource;

            SharedPrivateLinkResource sharedPrivateLinkResource = null;

            if (sharedPrivateLinkResourceJObject != null)
            {
                sharedPrivateLinkResource = sharedPrivateLinkResourceJObject.ToObject<SharedPrivateLinkResource>();
            }

            // origin group name is not present here since it is not provided by the SDK
            // we extract the origin group name via the input and utility methods and then add it to the PSAfdOrigin
            return new PSAfdOrigin
            {
                Id = sdkOrigin.Id,
                Name = sdkOrigin.Name,
                Type = sdkOrigin.Type,
                ProvisioningState = sdkOrigin.ProvisioningState,
                HostName = sdkOrigin.HostName,
                HttpPort = sdkOrigin.HttpPort,
                HttpsPort = sdkOrigin.HttpsPort,
                OriginHostHeader = sdkOrigin.OriginHostHeader,
                Priority = sdkOrigin.Priority,
                Weight = sdkOrigin.Weight,
                EnabledState = sdkOrigin.EnabledState,
                PrivateLinkId = sharedPrivateLinkResource?.PrivateLink?.Id,
                //PrivateLinkGroupId = sharedPrivateLinkResource?.GroupId, // confirm this field
                PrivateLinkLocation = sharedPrivateLinkResource?.PrivateLinkLocation,
                //PrivateLinkStatus = sharedPrivateLinkResource?.Status, // confirm this field
                PrivateLinkRequestMessage = sharedPrivateLinkResource?.RequestMessage
            };
        }

        public static PSAfdOriginGroup ToPSAfdOriginGroup(this SdkAfdOriginGroup sdkOriginGroup)
        {
            return new PSAfdOriginGroup
            {
                Id = sdkOriginGroup.Id,
                Name = sdkOriginGroup.Name,
                Type = sdkOriginGroup.Type,
                ProvisioningState = sdkOriginGroup.ProvisioningState,
                SampleSize = sdkOriginGroup.LoadBalancingSettings?.SampleSize,
                SuccessfulSamplesRequired = sdkOriginGroup.LoadBalancingSettings?.SuccessfulSamplesRequired,
                AdditionalLatencyInMilliseconds = sdkOriginGroup.LoadBalancingSettings?.AdditionalLatencyInMilliseconds,
                ProbePath = sdkOriginGroup.HealthProbeSettings?.ProbePath,
                ProbeRequestType = sdkOriginGroup.HealthProbeSettings?.ProbeRequestType.ToString(),
                ProbeProtocol = sdkOriginGroup.HealthProbeSettings?.ProbeProtocol.ToString(),
                ProbeIntervalInSeconds = sdkOriginGroup.HealthProbeSettings?.ProbeIntervalInSeconds,
                TrafficRestorationTimeToHealedOrNewEndpointsInMinutes = sdkOriginGroup.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes
            };
        }
        
        public static PSAfdProfile ToPSAfdProfile(this SdkAfdProfile sdkAfdProfile)
        {
            return new PSAfdProfile
            {
                Id = sdkAfdProfile.Id,
                Name = sdkAfdProfile.Name,
                Type = sdkAfdProfile.Type,
                ProvisioningState = sdkAfdProfile.ProvisioningState,
                Location = sdkAfdProfile.Location,
                Tags = TagsConversionHelper.CreateTagHashtable(sdkAfdProfile.Tags),
                ResourceState = sdkAfdProfile.ResourceState,
                Sku = sdkAfdProfile.Sku.Name
            };
        }

        public static PSAfdRoute ToPSAfdRoute(this SdkAfdRoute sdkAfdRoute)
        {
            return new PSAfdRoute
            {
                Id = sdkAfdRoute.Id,
                Name = sdkAfdRoute.Name,
                Type = sdkAfdRoute.Type,
                ProvisioningState = sdkAfdRoute.ProvisioningState,
                OriginGroupId = sdkAfdRoute.OriginGroup?.Id,
                OriginPath = sdkAfdRoute.OriginPath,
                CustomDomainIds = (List<ResourceReference>)sdkAfdRoute.CustomDomains,
                RuleSetIds = (List<ResourceReference>)sdkAfdRoute.RuleSets,
                SupportedProtocols = (List<string>)sdkAfdRoute.SupportedProtocols,
                PatternsToMatch = (List<string>)sdkAfdRoute.PatternsToMatch,
                QueryStringCachingBehavior = sdkAfdRoute.QueryStringCachingBehavior.Value.ToString(),
                ForwardingProtocol = sdkAfdRoute.ForwardingProtocol,
                HttpsRedirect = sdkAfdRoute.HttpsRedirect,
                LinkToDefaultDomain = sdkAfdRoute.LinkToDefaultDomain,
                EnabledState = sdkAfdRoute.EnabledState
            };
        }

        public static PSAfdRule ToPSAfdRule(this SdkAfdRule sdkAfdRule)
        {
            return new PSAfdRule
            {
                Id = sdkAfdRule.Id,
                Name = sdkAfdRule.Name,
                Type = sdkAfdRule.Type,
                ProvisioningState = sdkAfdRule.ProvisioningState,
                Order = sdkAfdRule.Order,
                Actions = (List<DeliveryRuleAction>)sdkAfdRule.Actions,
                Conditions = (List<DeliveryRuleCondition>)sdkAfdRule.Conditions,
                MatchProcessingBehavior = sdkAfdRule.MatchProcessingBehavior
            };
        }

        public static PSAfdRuleSet ToPSAfdRuleSet(this SdkAfdRuleSet sdkAfdRuleSet)
        {
            return new PSAfdRuleSet
            {
                Id = sdkAfdRuleSet.Id,
                Name = sdkAfdRuleSet.Name,
                Type = sdkAfdRuleSet.Type,
                ProvisioningState = sdkAfdRuleSet.ProvisioningState
            };
        }

        public static PSAfdSecret ToPSAfdSecret(this SdkAfdSecret sdkAfdSecret)
        {
            if (sdkAfdSecret.Parameters.GetType() == typeof(CustomerCertificateParameters))
            {
                CustomerCertificateParameters customerCertificateParameters = (CustomerCertificateParameters)sdkAfdSecret.Parameters;

                return new PSAfdSecret
                {
                    Id = sdkAfdSecret.Id,
                    Name = sdkAfdSecret.Name,
                    Type = sdkAfdSecret.Type,
                    ProvisioningState = sdkAfdSecret.ProvisioningState,
                    CertificateAuthority = customerCertificateParameters.CertificateAuthority,
                    SecretSource = customerCertificateParameters.SecretSource?.Id,
                    SecretVersion = customerCertificateParameters.SecretVersion,
                    SubjectAlternativeNames = (List<string>)customerCertificateParameters.SubjectAlternativeNames,
                    UseLatestVersion = customerCertificateParameters.UseLatestVersion
                };
            }

            return new PSAfdSecret
            {
                Id = sdkAfdSecret.Id,
                Name = sdkAfdSecret.Name,
                Type = sdkAfdSecret.Type,
                ProvisioningState = sdkAfdSecret.ProvisioningState
            };
        }

        public static PSAfdSecurityPolicy ToPSAfdSecurityPolicy(this SdkAfdSecurityPolicy sdkAfdSecurityPolicy)
        {
            SecurityPolicyWebApplicationFirewallParameters securityPolicyWafParameters = (SecurityPolicyWebApplicationFirewallParameters)sdkAfdSecurityPolicy.Parameters;
            
            return new PSAfdSecurityPolicy
            {
                Id = sdkAfdSecurityPolicy.Id,
                Name = sdkAfdSecurityPolicy.Name,
                Type = sdkAfdSecurityPolicy.Type,
                ProvisioningState = sdkAfdSecurityPolicy.ProvisioningState,
                WafPolicyId = securityPolicyWafParameters.WafPolicy?.Id,
                Domains = (List<ResourceReference>)securityPolicyWafParameters?.Associations[0]?.Domains,
                PatternsToMatch = (List<string>)securityPolicyWafParameters?.Associations[0]?.PatternsToMatch
            };
        }
    }
}
