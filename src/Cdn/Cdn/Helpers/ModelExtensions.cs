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
using System.Management.Automation;

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
            return new PSSku { Name = (PSSkuName)Enum.Parse(typeof(PSSkuName), sdkSku.Name) };
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
                ProvisioningState = (PSProvisioningState)Enum.Parse(typeof(PSProvisioningState), sdkProfile.ProvisioningState),
                Tags = sdkProfile.Tags.ToHashTableTags(),
                Location = sdkProfile.Location,
                ResourceState = (PSProfileResourceState)Enum.Parse(typeof(PSProfileResourceState), sdkProfile.ResourceState),

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
                ProvisioningState = (PSProvisioningState)Enum.Parse(typeof(PSProvisioningState), sdkEndpoint.ProvisioningState),
                Tags = sdkEndpoint.Tags.ToHashTableTags(),
                Location = sdkEndpoint.Location,
                ResourceState = (PSEndpointResourceState)Enum.Parse(typeof(PSEndpointResourceState), sdkEndpoint.ResourceState),

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
                Action = (PSGeoFilterAction)Enum.Parse(typeof(PSGeoFilterAction), sdkGeoFilter.Action.ToString()),
                CountryCodes = sdkGeoFilter.CountryCodes.ToArray()
            };
        }

        public static PSDeliveryRuleAction ToPsDeliveryRuleAction(this DeliveryRuleAction deliveryRuleAction)
        {

            if (deliveryRuleAction is DeliveryRuleRequestHeaderAction requestHeaderAction)
            {
                return new PSDeliveryRuleHeaderAction
                {
                    HeaderActionType = "ModifyRequestHeader",
                    Action = requestHeaderAction.Parameters.HeaderAction,
                    HeaderName = requestHeaderAction.Parameters.HeaderName,
                    Value = requestHeaderAction.Parameters.Value
                };
            }
            else if (deliveryRuleAction is DeliveryRuleResponseHeaderAction responseHeaderAction)
            {
                return new PSDeliveryRuleHeaderAction
                {
                    HeaderActionType = "ModifyResponseHeader",
                    Action = responseHeaderAction.Parameters.HeaderAction,
                    HeaderName = responseHeaderAction.Parameters.HeaderName,
                    Value = responseHeaderAction.Parameters.Value
                };
            }
            else if (deliveryRuleAction is DeliveryRuleCacheExpirationAction cacheExpirationAction)
            {
                return new PSDeliveryRuleCacheExpirationAction
                {
                    Parameters = new PSCacheExpirationActionParameters
                    {
                        CacheBehavior = cacheExpirationAction.Parameters.CacheBehavior,
                        CacheDuration = cacheExpirationAction.Parameters.CacheDuration
                    }
                };
            }
            else if (deliveryRuleAction is UrlRedirectAction urlRedirectAction)
            {
                return new PSDeliveryRuleUrlRedirectAction
                {
                    RedirectType = urlRedirectAction.Parameters.RedirectType
                };
            }
            else
            {
                return new PSDeliveryRuleAction();
            }
        }

        public static PSDeliveryRuleCondition ToPsDeliveryRuleCondition(this DeliveryRuleCondition deliveryRuleCondition)
        {
            if (deliveryRuleCondition is DeliveryRuleRemoteAddressCondition deliveryRuleRemoteAddressCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "RemoteAddress",
                    Operator = deliveryRuleRemoteAddressCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleRemoteAddressCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleRemoteAddressCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleRemoteAddressCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleRequestMethodCondition deliveryRuleRequestMethodCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "RequestMethod",
                    Operator = "Equal",
                    NegateCondition = deliveryRuleRequestMethodCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleRequestMethodCondition.Parameters.MatchValues
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleQueryStringCondition deliveryRuleQueryStringCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "QueryString",
                    Operator = deliveryRuleQueryStringCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleQueryStringCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleQueryStringCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleQueryStringCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRulePostArgsCondition deliveryRulePostArgsCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "PostArgs",
                    Operator = deliveryRulePostArgsCondition.Parameters.OperatorProperty,
                    Selector = deliveryRulePostArgsCondition.Parameters.Selector,
                    NegateCondition = deliveryRulePostArgsCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRulePostArgsCondition.Parameters.MatchValues,
                    Transfroms = deliveryRulePostArgsCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleRemoteAddressCondition deliveryRuleRequestUriCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "RequestUri",
                    Operator = deliveryRuleRequestUriCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleRequestUriCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleRequestUriCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleRequestUriCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleRequestHeaderCondition deliveryRuleRequestHeaderCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "RequestHeader",
                    Operator = deliveryRuleRequestHeaderCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleRequestHeaderCondition.Parameters.NegateCondition,
                    Selector = deliveryRuleRequestHeaderCondition.Parameters.Selector,
                    MatchValue = deliveryRuleRequestHeaderCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleRequestHeaderCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleRequestBodyCondition deliveryRuleRequestBodyCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "RequestBody",
                    Operator = deliveryRuleRequestBodyCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleRequestBodyCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleRequestBodyCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleRequestBodyCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleRequestSchemeCondition deliveryRuleRequestSchemeCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "RequestScheme",
                    NegateCondition = deliveryRuleRequestSchemeCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleRequestSchemeCondition.Parameters.MatchValues
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleUrlPathCondition deliveryRuleUrlPathCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "UrlPath",
                    Operator = deliveryRuleUrlPathCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleUrlPathCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleUrlPathCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleUrlPathCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleUrlFileExtensionCondition deliveryRuleUrlFileExtensionCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "UrlFileExtension",
                    Operator = deliveryRuleUrlFileExtensionCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleUrlFileExtensionCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleUrlFileExtensionCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleUrlFileExtensionCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleUrlFileNameCondition deliveryRuleUrlFileNameCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "UrlFileName",
                    Operator = deliveryRuleUrlFileNameCondition.Parameters.OperatorProperty,
                    NegateCondition = deliveryRuleUrlFileNameCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleUrlFileNameCondition.Parameters.MatchValues,
                    Transfroms = deliveryRuleUrlFileNameCondition.Parameters.Transforms
                };
            }
            else if (deliveryRuleCondition is DeliveryRuleIsDeviceCondition deliveryRuleIsDeviceCondition)
            {
                return new PSDeliveryRuleCondition
                {
                    MatchVariable = "IsDevice",
                    NegateCondition = deliveryRuleIsDeviceCondition.Parameters.NegateCondition,
                    MatchValue = deliveryRuleIsDeviceCondition.Parameters.MatchValues
                };
            }
            else
            {
                return new PSDeliveryRuleCondition();
            }
        }

        public static PSDeliveryRule ToPsDeliveryRule(this DeliveryRule deliveryRule)
        {

            return new PSDeliveryRule
            {
                Name = deliveryRule.Name,
                Order = deliveryRule.Order,
                Actions = deliveryRule.Actions.Select(action => action.ToPsDeliveryRuleAction()).ToList(),
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
            switch (psDeliveryRuleCondition.MatchVariable)
            {
                case "RemoteAddress":
                    return new DeliveryRuleRemoteAddressCondition
                    {
                        Parameters = new RemoteAddressMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "RequestMethod":
                    return new DeliveryRuleRequestMethodCondition
                    {
                        Parameters = new RequestMethodMatchConditionParameters
                        {
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition
                        }
                    };
                case "QueryString":
                    return new DeliveryRuleQueryStringCondition
                    {
                        Parameters = new QueryStringMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "PostArgs":
                    return new DeliveryRulePostArgsCondition
                    {
                        Parameters = new PostArgsMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            Selector = psDeliveryRuleCondition.Selector,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "RequestUri":
                    return new DeliveryRuleRequestUriCondition
                    {
                        Parameters = new RequestUriMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "RequestHeader":
                    return new DeliveryRuleRequestHeaderCondition
                    {
                        Parameters = new RequestHeaderMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            Selector = psDeliveryRuleCondition.Selector,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "RequestBody":
                    return new DeliveryRuleRequestBodyCondition
                    {
                        Parameters = new RequestBodyMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "RequestScheme":
                    return new DeliveryRuleRequestSchemeCondition
                    {
                        Parameters = new RequestSchemeMatchConditionParameters
                        {
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                        }
                    };
                case "UrlPath":
                    return new DeliveryRuleUrlPathCondition
                    {
                        Parameters = new UrlPathMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "UrlFileExtension":
                    return new DeliveryRuleUrlFileExtensionCondition
                    {
                        Parameters = new UrlFileExtensionMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "UrlFileName":
                    return new DeliveryRuleUrlFileNameCondition
                    {
                        Parameters = new UrlFileNameMatchConditionParameters
                        {
                            OperatorProperty = psDeliveryRuleCondition.Operator,
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                case "IsDevice":
                    return new DeliveryRuleIsDeviceCondition
                    {
                        Parameters = new IsDeviceMatchConditionParameters
                        {
                            MatchValues = psDeliveryRuleCondition.MatchValue,
                            NegateCondition = psDeliveryRuleCondition.NegateCondition,
                            Transforms = psDeliveryRuleCondition.Transfroms
                        }
                    };
                default:
                    return new DeliveryRuleCondition();
            }
        }

        public static DeliveryRuleAction ToDeliveryRuleAction(this PSDeliveryRuleAction psDeliveryRuleAction)
        {
            if (psDeliveryRuleAction is PSDeliveryRuleCacheExpirationAction psDeliveryRuleCacheExpirationAction)
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
            else if (psDeliveryRuleAction is PSDeliveryRuleHeaderAction psDeliveryRuleHeaderAction)
            {
                if (psDeliveryRuleHeaderAction.HeaderActionType == "ModifyRequestHeader")
                {
                    return new DeliveryRuleRequestHeaderAction
                    {
                        Parameters = new HeaderActionParameters
                        {
                            HeaderAction = psDeliveryRuleHeaderAction.Action,
                            HeaderName = psDeliveryRuleHeaderAction.HeaderName,
                            Value = psDeliveryRuleHeaderAction.Value
                        }
                    };
                }
                else if (psDeliveryRuleHeaderAction.HeaderActionType == "ModifyResponseHeader")
                {
                    return new DeliveryRuleResponseHeaderAction
                    {
                        Parameters = new HeaderActionParameters
                        {
                            HeaderAction = psDeliveryRuleHeaderAction.Action,
                            HeaderName = psDeliveryRuleHeaderAction.HeaderName,
                            Value = psDeliveryRuleHeaderAction.Value
                        }
                    };
                }
            }
            else if (psDeliveryRuleAction is PSDeliveryRuleUrlRedirectAction psDeliveryRuleUrlRedirectAction)
            {
                return new UrlRedirectAction
                {
                    Parameters = new UrlRedirectActionParameters
                    {
                        RedirectType = psDeliveryRuleUrlRedirectAction.RedirectType,
                        DestinationProtocol = psDeliveryRuleUrlRedirectAction.DestinationProtocol,
                        CustomPath = psDeliveryRuleUrlRedirectAction.CustomPath,
                        CustomHostname = psDeliveryRuleUrlRedirectAction.CustomHostname,
                        CustomQueryString = psDeliveryRuleUrlRedirectAction.CustomQueryString,
                        CustomFragment = psDeliveryRuleUrlRedirectAction.CustomFragment
                    }
                };
            }
            return new DeliveryRuleAction();
        }

        public static DeliveryRule ToDeliveryRule(this PSDeliveryRule psDeliveryRule)
        {
            return new DeliveryRule
            {
                Name = psDeliveryRule.Name,
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
                ProvisioningState = (PSProvisioningState)Enum.Parse(typeof(PSProvisioningState), origin.ProvisioningState),
                ResourceState = (PSOriginResourceState)Enum.Parse(typeof(PSOriginResourceState), origin.ResourceState),
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
                ProvisioningState = (PSProvisioningState)Enum.Parse(typeof(PSProvisioningState), customDomain.ProvisioningState),
                CustomHttpsProvisioningState = (PSCustomHttpsProvisioningState)Enum.Parse(typeof(PSCustomHttpsProvisioningState), customDomain.CustomHttpsProvisioningState),
                CustomHttpsProvisioningSubstate = (PSCustomHttpsProvisioningSubstate)Enum.Parse(typeof(PSCustomHttpsProvisioningSubstate), customDomain.CustomHttpsProvisioningSubstate),
                ResourceState = (PSCustomDomainResourceState)Enum.Parse(typeof(PSCustomDomainResourceState), customDomain.ResourceState),
                HostName = customDomain.HostName,
                ValidationData = customDomain.ValidationData
            };
        }

        public static IDictionary<string, string> ToDictionaryTags(this Hashtable table)
        {
            return table?.Cast<DictionaryEntry>()
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

        public static void ValidateDeliveryRuleCondition(this PSDeliveryRuleCondition condition)
        {
            switch (condition.MatchVariable)
            {
                case "RemoteAddress":
                    if (condition.Operator != "Any" && condition.Operator != "IPMatch" && condition.Operator != "GeoMatch")
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid Operator {0} found for {1} match variable. Valid operators are IPMatch, Any, GeoMatch", condition.Operator, condition.MatchVariable
                                ));
                    }
                    break;
                case "QueryString":
                case "RequestUri":
                case "RequestBody":
                case "UrlPath":
                case "UrlFileExtension":
                case "UrlFileName":
                    if (condition.Operator != "Any" && condition.Operator != "Equal" && condition.Operator != "Contains" &&
                        condition.Operator != "BeginsWith" && condition.Operator != "EndsWith" && condition.Operator != "LessThan" &&
                        condition.Operator != "LessThanOrEqual" && condition.Operator != "GreaterThan" && condition.Operator != "GreaterThanOrEqual")
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid Operator {0} found for {1} match condition. Valid operators are IPMatch, Any, GeoMatch", condition.Operator, condition.MatchVariable
                                ));
                    }
                    break;
                case "RequestHeader":
                case "PostArgs":
                    if (condition.Selector == null)
                    {
                        throw new PSArgumentException(string.Format(
                                "Selector is requried for {0} match condition", condition.MatchVariable
                                ));
                    }
                    if (condition.Operator != "Any" && condition.Operator != "Equal" && condition.Operator != "Contains" &&
                        condition.Operator != "BeginsWith" && condition.Operator != "EndsWith" && condition.Operator != "LessThan" &&
                        condition.Operator != "LessThanOrEqual" && condition.Operator != "GreaterThan" && condition.Operator != "GreaterThanOrEqual")
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid Operator {0} found for {1} match condition. Valid operators are Any, Equal, Contains, BeginsWith, EndsWith, LessThan, LessThanOrEqual, GreaterThan, GreaterThanOrEqual.",
                                condition.Operator, condition.MatchVariable));
                    }
                    break;
                case "RequestScheme":
                case "IsDevice":
                case "RequestMethod":
                    if (condition.Operator !="Equal")
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid Operator {0} found for {1} match condition. Valid operator is Equal", condition.Operator, condition.MatchVariable
                                ));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
