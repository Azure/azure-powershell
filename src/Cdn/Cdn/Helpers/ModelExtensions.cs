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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Cdn.Models;
using Microsoft.Azure.Commands.Cdn.Models.CustomDomain;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Models.Origin;
using Microsoft.Azure.Commands.Cdn.Models.Profile;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using SdkProfile = Microsoft.Azure.Management.Cdn.Models.Profile;
using SdkSkuName = Microsoft.Azure.Management.Cdn.Models.SkuName;
using SdkSku = Microsoft.Azure.Management.Cdn.Models.Sku;
using SdkProfileResourceState = Microsoft.Azure.Management.Cdn.Models.ProfileResourceState;
using SdkEndpointResourceState = Microsoft.Azure.Management.Cdn.Models.EndpointResourceState;
using SdkOriginResourceState = Microsoft.Azure.Management.Cdn.Models.OriginResourceState;
using SdkCustomDomainResourceState = Microsoft.Azure.Management.Cdn.Models.CustomDomainResourceState;
using SdkDeepCreatedOrigin = Microsoft.Azure.Management.Cdn.Models.DeepCreatedOrigin;
using SdkEndpoint = Microsoft.Azure.Management.Cdn.Models.Endpoint;
using SdkQueryStringCachingBehavior = Microsoft.Azure.Management.Cdn.Models.QueryStringCachingBehavior;
using SdkOrigin = Microsoft.Azure.Management.Cdn.Models.Origin;
using SdkCustomDomain = Microsoft.Azure.Management.Cdn.Models.CustomDomain;
using SdkGeoFilter = Microsoft.Azure.Management.Cdn.Models.GeoFilter;
using SdkGeoFilterAction = Microsoft.Azure.Management.Cdn.Models.GeoFilterActions;
using SdkDeliveryPolicy = Microsoft.Azure.Management.Cdn.Models.EndpointPropertiesUpdateParametersDeliveryPolicy;
using Microsoft.Azure.Commands.Cdn.EdgeNodes;

namespace Microsoft.Azure.Commands.Cdn.Helpers
{
    public static class ModelExtensions
    {
        public static TToEnum CastEnum<TFromEnum, TToEnum>(this TFromEnum fromEnum)
        {
            return (TToEnum)Enum.Parse(typeof(TToEnum), fromEnum.ToString());
        }

        public static SdkSku ToSdkSku(this PSSku psSku)
        {
            return new SdkSku(psSku.Name.ToString());
        }

        public static PSSku ToPsSku(this SdkSku sdkSku)
        {
            return new PSSku { Name = (PSSkuName) Enum.Parse(typeof(PSSkuName), sdkSku.Name) };
        }

        public static SdkProfile ToSdkProfile(this PSProfile psProfile)
        {
            return new SdkProfile(
                psProfile.Location,
                psProfile.Sku.ToSdkSku(),
                psProfile.Id, 
                psProfile.Name, 
                psProfile.Type,
                psProfile.Tags.ToDictionaryTags(),
                psProfile.ResourceState.ToString(),
                psProfile.ProvisioningState.ToString());
        }

        public static SdkDeepCreatedOrigin ToSdkDeepCreatedOrigin(this PSDeepCreatedOrigin psDeepCreatedOrigin)
        {
            return new SdkDeepCreatedOrigin(
                psDeepCreatedOrigin.Name, 
                psDeepCreatedOrigin.HostName,
                psDeepCreatedOrigin.HttpPort, 
                psDeepCreatedOrigin.HttpsPort);
        }

        public static PSDeepCreatedOrigin ToPsDeepCreatedOrigin(this SdkDeepCreatedOrigin sdkDeepCreatedOrigin)
        {
            return new PSDeepCreatedOrigin
            {
                Name = sdkDeepCreatedOrigin.Name,
                HostName = sdkDeepCreatedOrigin.HostName,
                HttpPort = sdkDeepCreatedOrigin.HttpPort,
                HttpsPort = sdkDeepCreatedOrigin.HttpsPort
            };
        }

        public static PSProfile ToPsProfile(this SdkProfile sdkProfile)
        {
            Debug.Assert(sdkProfile.ProvisioningState != null, "sdkProfile.ProvisioningState != null");
            Debug.Assert(sdkProfile.ResourceState != null, "sdkProfile.ResourceState != null");

            return new PSProfile
            {
                Id = sdkProfile.Id,
                Name = sdkProfile.Name,
                Type = sdkProfile.Type,
                ProvisioningState = (PSProvisioningState) Enum.Parse(typeof(PSProvisioningState), sdkProfile.ProvisioningState),
                Tags = sdkProfile.Tags.ToHashTableTags(),
                Location = sdkProfile.Location,
                ResourceState = (PSProfileResourceState) Enum.Parse(typeof(PSProfileResourceState), sdkProfile.ResourceState),

                // Entity specific properties
                Sku = sdkProfile.Sku.ToPsSku()
            };
        }

        public static PSEndpoint ToPsEndpoint(this SdkEndpoint sdkEndpoint)
        {
            Debug.Assert(sdkEndpoint.ProvisioningState != null, "sdkEndpoint.ProvisioningState != null");
            Debug.Assert(sdkEndpoint.ResourceState != null, "sdkEndpoint.ResourceState != null");
            Debug.Assert(sdkEndpoint.IsCompressionEnabled != null, "sdkEndpoint.IsCompressionEnabled != null");
            Debug.Assert(sdkEndpoint.IsHttpAllowed != null, "sdkEndpoint.IsHttpAllowed != null");
            Debug.Assert(sdkEndpoint.IsHttpsAllowed != null, "sdkEndpoint.IsHttpsAllowed != null");
            Debug.Assert(sdkEndpoint.QueryStringCachingBehavior != null, "sdkEndpoint.QueryStringCachingBehavior != null");

            return new PSEndpoint
            {
                Id = sdkEndpoint.Id,
                Name = sdkEndpoint.Name,
                Type = sdkEndpoint.Type,
                ProvisioningState = (PSProvisioningState) Enum.Parse(typeof(PSProvisioningState), sdkEndpoint.ProvisioningState),
                Tags = sdkEndpoint.Tags.ToHashTableTags(),
                Location = sdkEndpoint.Location,
                ResourceState = (PSEndpointResourceState) Enum.Parse(typeof(PSEndpointResourceState), sdkEndpoint.ResourceState),

                // Entity specific properties
                HostName = sdkEndpoint.HostName,
                OriginHostHeader = sdkEndpoint.OriginHostHeader,
                OriginPath = sdkEndpoint.OriginPath,
                ContentTypesToCompress = sdkEndpoint.ContentTypesToCompress.ToArray(),
                IsCompressionEnabled = sdkEndpoint.IsCompressionEnabled.Value,
                IsHttpAllowed = sdkEndpoint.IsHttpAllowed.Value,
                IsHttpsAllowed = sdkEndpoint.IsHttpsAllowed.Value,
                QueryStringCachingBehavior = sdkEndpoint.QueryStringCachingBehavior.Value.CastEnum<SdkQueryStringCachingBehavior, PSQueryStringCachingBehavior>(),
                Origins = sdkEndpoint.Origins.Select(o => o.ToPsDeepCreatedOrigin()).ToList(),
                OptimizationType = sdkEndpoint.OptimizationType,
                ProbePath = sdkEndpoint.ProbePath,
                GeoFilters = sdkEndpoint.GeoFilters.Select(ToPsGeoFilter).ToList(),
                DeliveryPolicy = sdkEndpoint.DeliveryPolicy?.ToPsDeliveryPolicy()
            };
        }

        public static PSGeoFilter ToPsGeoFilter(this SdkGeoFilter sdkGeoFilter)
        {
            Debug.Assert(sdkGeoFilter.RelativePath != null, "sdkGeoFilter.RelativePath != null");
            Debug.Assert(sdkGeoFilter.CountryCodes != null, "sdkGeoFilter.CountryCodes != null");

            return new PSGeoFilter
            {
                RelativePath = sdkGeoFilter.RelativePath,
                Action = (PSGeoFilterAction) Enum.Parse(typeof (PSGeoFilterAction), sdkGeoFilter.Action.ToString()),
                CountryCodes = sdkGeoFilter.CountryCodes.ToArray()
            };
        }

        public static PSDeliveryRuleAction ToPsDeliveryRuleAction(this DeliveryRuleAction deliveryRuleAction)
        {

            var deliveryRuleCacheExpirationAction = deliveryRuleAction as DeliveryRuleCacheExpirationAction;
            if (deliveryRuleCacheExpirationAction !=null)
            {
                
                return new PSDeliveryRuleCacheExpirationAction
                {
                    Parameters = new PSCacheExpirationActionParameters
                    {
                       CacheBehavior = deliveryRuleCacheExpirationAction.Parameters.CacheBehavior,
                       CacheDuration = deliveryRuleCacheExpirationAction.Parameters.CacheDuration
                    }
                };
            }
            return new PSDeliveryRuleAction();
        }

        public static PSDeliveryRuleCondition ToPsDeliveryRuleCondition(this DeliveryRuleCondition deliveryRuleCondition)
        {
            var deliveryRuleUrlFileExtensionCondition = deliveryRuleCondition as DeliveryRuleUrlFileExtensionCondition;
            if (deliveryRuleUrlFileExtensionCondition != null)
            {
                return new PSDeliveryRuleUrlFileExtensionCondition
                {
                    Parameters = new PSUrlFileExtensionConditionParameters
                    {
                        Extensions = deliveryRuleUrlFileExtensionCondition.Parameters.Extensions
                    }
                };
            }

            var deliveryRuleUrlPathCondition = deliveryRuleCondition as DeliveryRuleUrlPathCondition;
            if (deliveryRuleUrlPathCondition != null)
            {
                return new PSDeliveryRuleUrlPathCondition
                {
                    Parameters = new PSUrlPathConditionParameters
                    {
                        MatchType = deliveryRuleUrlPathCondition.Parameters.MatchType,
                        Path = deliveryRuleUrlPathCondition.Parameters.Path
                    }
                };
            }
            
            return new PSDeliveryRuleCondition();
        }

        public static PSDeliveryRule ToPsDeliveryRule(this DeliveryRule deliveryRule)
        {

            return new PSDeliveryRule
            {
                Order = deliveryRule.Order,
                Actions = deliveryRule.Actions.Select(action =>action.ToPsDeliveryRuleAction()).ToList(),
                Conditions = deliveryRule.Conditions.Select(condition => condition.ToPsDeliveryRuleCondition()).ToList()
            };
        }

        public static PSDeliveryPolicy ToPsDeliveryPolicy(this SdkDeliveryPolicy sdkDeliveryPolicy)
        {
            Debug.Assert(sdkDeliveryPolicy.Rules != null, "sdkDeliveryPolicy.Rules != null");

            return new PSDeliveryPolicy
            {
                Description = sdkDeliveryPolicy.Description,
                Rules = sdkDeliveryPolicy.Rules.Select(rule => rule.ToPsDeliveryRule()).ToList()
            };
        }


        public static SdkGeoFilter ToSdkGeoFilter(this PSGeoFilter psGeoFilter)
        {
            Debug.Assert(psGeoFilter.RelativePath != null, "psGeoFilter.RelativePath != null");
            Debug.Assert(psGeoFilter.CountryCodes != null, "psGeoFilter.CountryCodes != null");

            return new SdkGeoFilter
            {
                RelativePath = psGeoFilter.RelativePath,
                Action = (SdkGeoFilterAction)Enum.Parse(typeof(SdkGeoFilterAction), psGeoFilter.Action.ToString()),
                CountryCodes = psGeoFilter.CountryCodes.ToList()
            };
        }

        public static DeliveryRuleCondition ToDeliveryRuleCondition(
            this PSDeliveryRuleCondition psDeliveryRuleCondition)
        {
            var psDeliveryRuleUrlFileExtensionCondition = psDeliveryRuleCondition as PSDeliveryRuleUrlFileExtensionCondition;
            if (psDeliveryRuleUrlFileExtensionCondition != null)
            {
                return new DeliveryRuleUrlFileExtensionCondition
                {
                    Parameters = new UrlFileExtensionConditionParameters
                    {
                        Extensions = psDeliveryRuleUrlFileExtensionCondition.Parameters.Extensions
                    }
                };
            }

            var psDeliveryRuleUrlPathCondition = psDeliveryRuleCondition as PSDeliveryRuleUrlPathCondition;
            if (psDeliveryRuleUrlPathCondition != null)
            {
                return new DeliveryRuleUrlPathCondition
                {
                    Parameters = new UrlPathConditionParameters
                    {
                        Path = psDeliveryRuleUrlPathCondition.Parameters.Path,
                        MatchType = psDeliveryRuleUrlPathCondition.Parameters.MatchType
                    }
                };
            }

            return new DeliveryRuleCondition();
        }

        public static DeliveryRuleAction ToDeliveryRuleAction(this PSDeliveryRuleAction psDeliveryRuleAction)
        {
            var psDeliveryRuleCacheExpirationAction = psDeliveryRuleAction as PSDeliveryRuleCacheExpirationAction;
            if (psDeliveryRuleCacheExpirationAction != null)
            {
                return new DeliveryRuleCacheExpirationAction
                {
                    Parameters = new CacheExpirationActionParameters
                    {
                        CacheBehavior = psDeliveryRuleCacheExpirationAction.Parameters.CacheBehavior,
                        CacheDuration = psDeliveryRuleCacheExpirationAction.Parameters.CacheDuration
                    }
                };
            }
            return new DeliveryRuleAction();
        }

        public static DeliveryRule ToDeliveryRule(this PSDeliveryRule psDeliveryRule)
        {
            return new DeliveryRule
            {
                Order = psDeliveryRule.Order,
                Actions = psDeliveryRule.Actions.Select(action => action.ToDeliveryRuleAction()).ToList(),
                Conditions = psDeliveryRule.Conditions.Select(condition => condition.ToDeliveryRuleCondition()).ToList()
            };
        }

        public static SdkDeliveryPolicy ToSdkDeliveryPolicy(this PSDeliveryPolicy psDeliveryPolicy)
        {
            return new SdkDeliveryPolicy
            {
                Description = psDeliveryPolicy.Description,
                Rules = psDeliveryPolicy.Rules.Select(rule => rule.ToDeliveryRule()).ToList()
            };
        }

        public static PSValidateCustomDomainOutput ToPsValidateCustomDomainOutput(
            this ValidateCustomDomainOutput validateCustomDomainOutput)
        {
            Debug.Assert(validateCustomDomainOutput.CustomDomainValidated != null, "validateCustomDomainOutput.CustomDomainValidated != null");

            return new PSValidateCustomDomainOutput
            {
                CustomDomainValidated = validateCustomDomainOutput.CustomDomainValidated.Value,
                Message = validateCustomDomainOutput.Message,
                Reason = validateCustomDomainOutput.Reason,
            };
        }

        public static PSOrigin ToPsOrigin(this SdkOrigin origin)
        {
            Debug.Assert(origin.ProvisioningState != null, "origin.ProvisioningState != null");
            Debug.Assert(origin.ResourceState != null, "origin.ResourceState != null");

            return new PSOrigin
            {
                Id = origin.Id,
                Name = origin.Name,
                Type = origin.Type,
                ProvisioningState = (PSProvisioningState) Enum.Parse(typeof(PSProvisioningState), origin.ProvisioningState),
                ResourceState = (PSOriginResourceState) Enum.Parse(typeof(PSOriginResourceState), origin.ResourceState),
                HostName = origin.HostName,
                HttpPort = origin.HttpPort,
                HttpsPort = origin.HttpsPort
            };
        }

        public static PSCustomDomain ToPsCustomDomain(this SdkCustomDomain customDomain)
        {
            Debug.Assert(customDomain.ProvisioningState != null, "customDomain.ProvisioningState != null");
            Debug.Assert(customDomain.ResourceState != null, "customDomain.ResourceState != null");

            return new PSCustomDomain
            {
                Id = customDomain.Id,
                Name = customDomain.Name,
                Type = customDomain.Type,
                ProvisioningState = (PSProvisioningState) Enum.Parse(typeof(PSProvisioningState), customDomain.ProvisioningState),
                CustomHttpsProvisioningState = (PSCustomHttpsProvisioningState)Enum.Parse(typeof(PSCustomHttpsProvisioningState), customDomain.CustomHttpsProvisioningState),
                CustomHttpsProvisioningSubstate = (PSCustomHttpsProvisioningSubstate)Enum.Parse(typeof(PSCustomHttpsProvisioningSubstate), customDomain.CustomHttpsProvisioningSubstate),
                ResourceState = (PSCustomDomainResourceState)Enum.Parse(typeof(PSCustomDomainResourceState), customDomain.ResourceState),
                HostName = customDomain.HostName,
                ValidationData = customDomain.ValidationData
            };
        }

        public static IDictionary<string, string> ToDictionaryTags(this Hashtable table)
        {
            return table == null ? null :
                table.Cast<DictionaryEntry>()
                .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }

        public static Hashtable ToHashTableTags(this IDictionary<string, string> tags)
        {
            if (tags == null)
            {
                return null;
            }

            var tagsInHashTable = new Hashtable();
            tags.Keys.ForEach(key => tagsInHashTable.Add(key, tags[key]));
            return tagsInHashTable;
        }

        public static PSCheckNameAvailabilityOutput ToPsCheckNameAvailabilityOutput(
            this CheckNameAvailabilityOutput output)
        {
            Debug.Assert(output.NameAvailable != null, "output.NameAvailable != null");

            return new PSCheckNameAvailabilityOutput
            {
                Message = output.Message,
                NameAvailable = output.NameAvailable.Value,
                Reason = output.Reason
            };
        }

        public static PSValidateProbeOutput ToPsValideProbeOutput(
            this ValidateProbeOutput output)
        {

            return new PSValidateProbeOutput
            {
                Message = output.Message,
                ErrorCode = output.ErrorCode,
                IsValid = output.IsValid
            };
        }

        public static PSEdgeNode ToPsEdgeNode(this EdgeNode edgeNode)
        {
            return new PSEdgeNode
            {
                IpAddressGroups = edgeNode.IpAddressGroups.Select(i => i.ToPsIpAddressGroup()).ToList()
            };
        }

        public static PSIpAddressGroup ToPsIpAddressGroup(this IpAddressGroup ipAddressGroup)
        {
            return new PSIpAddressGroup
            {
                DeliveryRegion = ipAddressGroup.DeliveryRegion,
                Ipv4Addresses = ipAddressGroup.Ipv4Addresses.Select(i => i.ToPsCIDIRIpAddress()).ToList(),
                Ipv6Addresses = ipAddressGroup.Ipv6Addresses.Select(i => i.ToPsCIDIRIpAddress()).ToList()
            };
        }

        public static PSCIDRIpAddress ToPsCIDIRIpAddress(this CidrIpAddress cidrIpAddress)
        {
            return new PSCIDRIpAddress
            {
                BaseIpAddress = cidrIpAddress.BaseIpAddress,
                PrefixLength = cidrIpAddress.PrefixLength.Value
            };
        }


        public static PSResourceUsage ToPsResourceUsage(this ResourceUsage resourceUsage)
        {

            return new PSResourceUsage
            {
                ResourceType = resourceUsage.ResourceType,
                Unit = resourceUsage.Unit,
                CurrentValue = resourceUsage.CurrentValue.Value,
                Limit = resourceUsage.Limit.Value
            };
        }
    }
}
