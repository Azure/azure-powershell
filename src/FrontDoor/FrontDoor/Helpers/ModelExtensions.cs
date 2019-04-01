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
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using SdkFrontDoor = Microsoft.Azure.Management.FrontDoor.Models.FrontDoorModel;
using SdkRoutingRule = Microsoft.Azure.Management.FrontDoor.Models.RoutingRule;
using SdkBackendPool = Microsoft.Azure.Management.FrontDoor.Models.BackendPool;
using SdkBackend = Microsoft.Azure.Management.FrontDoor.Models.Backend;
using SdkHealthProbeSetting = Microsoft.Azure.Management.FrontDoor.Models.HealthProbeSettingsModel;
using SdkLoadBalancingSetting = Microsoft.Azure.Management.FrontDoor.Models.LoadBalancingSettingsModel;
using SdkFrontendEndpoint = Microsoft.Azure.Management.FrontDoor.Models.FrontendEndpoint;
using SdkFirewallPolicy = Microsoft.Azure.Management.FrontDoor.Models.WebApplicationFirewallPolicy1;
using SdkResourceState = Microsoft.Azure.Management.FrontDoor.Models.FrontDoorResourceState;
using SdkCacheConfiguration = Microsoft.Azure.Management.FrontDoor.Models.CacheConfiguration;
using SdkRefId = Microsoft.Azure.Management.FrontDoor.Models.SubResource;
using SdkFWPolicyLink = Microsoft.Azure.Management.FrontDoor.Models.FrontendEndpointUpdateParametersWebApplicationFirewallPolicyLink;
using SdkHttpsConfig = Microsoft.Azure.Management.FrontDoor.Models.CustomHttpsConfiguration;
using SdkValut = Microsoft.Azure.Management.FrontDoor.Models.KeyVaultCertificateSourceParametersVault;
using SdkCustomRule = Microsoft.Azure.Management.FrontDoor.Models.CustomRule;
using SdkCustomRules = Microsoft.Azure.Management.FrontDoor.Models.CustomRules;
using SdkManagedRule = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleSet;
using SdkManagedRules = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleSets;
using SdkAzureManagedRule = Microsoft.Azure.Management.FrontDoor.Models.AzureManagedRuleSet;
using sdkAzRuleGroupOverride = Microsoft.Azure.Management.FrontDoor.Models.AzureManagedOverrideRuleGroup;
using sdkMatchCondition = Microsoft.Azure.Management.FrontDoor.Models.MatchCondition1;
using sdkPolicySetting = Microsoft.Azure.Management.FrontDoor.Models.PolicySettings;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Helpers
{
    public static class ModelExtensions
    {
        public static TToEnum CastEnum<TFromEnum, TToEnum>(this TFromEnum fromEnum)
        {
            return (TToEnum)Enum.Parse(typeof(TToEnum), fromEnum.ToString());
        }

        public static SdkFrontDoor ToSdkFrontDoor(this PSFrontDoor psFrontDoor)
        {
            return new SdkFrontDoor(
                name: psFrontDoor.Name,
                location: "global",
                tags: psFrontDoor.Tags.ToDictionaryTags(),
                friendlyName: psFrontDoor.FriendlyName,
                routingRules: psFrontDoor.RoutingRules?.Select(x => x.ToSdkRoutingRule()).ToList(),
                loadBalancingSettings: psFrontDoor.LoadBalancingSettings?.Select(x => x.ToSdkLoadBalancingSetting()).ToList(),
                healthProbeSettings: psFrontDoor.HealthProbeSettings?.Select(x => x.ToSdkHealthProbeSetting()).ToList(),
                backendPools: psFrontDoor.BackendPools?.Select(x => x.ToSdkBackendPool()).ToList(),
                frontendEndpoints: psFrontDoor.FrontendEndpoints?.Select(x => x.ToSdkFrontendEndpoints()).ToList(),
                enabledState: psFrontDoor.EnabledState.ToString()
                );
        }
        public static PSFrontDoor ToPSFrontDoor(this SdkFrontDoor sdkFrontDoor)
        {
            return new PSFrontDoor
            {
                Id = sdkFrontDoor.Id,
                Name = sdkFrontDoor.Name,
                Type = sdkFrontDoor.Type,
                Tags = sdkFrontDoor.Tags.ToHashTableTags(),
                FriendlyName = sdkFrontDoor.FriendlyName,
                RoutingRules = sdkFrontDoor.RoutingRules?.Select(x => x.ToPSRoutingRule()).ToList(),
                BackendPools = sdkFrontDoor.BackendPools?.Select(x => x.ToPSBackendPool()).ToList(),
                HealthProbeSettings = sdkFrontDoor.HealthProbeSettings?.Select(x => x.ToPSHealthProbeSetting()).ToList(),
                LoadBalancingSettings = sdkFrontDoor.LoadBalancingSettings?.Select(x => x.ToPSLoadBalancingSetting()).ToList(),
                FrontendEndpoints = sdkFrontDoor.FrontendEndpoints?.Select(x => x.ToPSFrontendEndpoints()).ToList(),
                EnabledState = sdkFrontDoor.EnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkFrontDoor.EnabledState),
                ResourceState = sdkFrontDoor.ResourceState,
                ProvisioningState = sdkFrontDoor.ProvisioningState,
            };
        }
        public static PSRoutingRule ToPSRoutingRule(this SdkRoutingRule sdkRoutingRule)
        {
            return new PSRoutingRule
            {
                Name = sdkRoutingRule.Name,
                Type = sdkRoutingRule.Type,
                AcceptedProtocols = sdkRoutingRule.AcceptedProtocols?.Select(x => (PSProtocol)Enum.Parse(typeof(PSProtocol), x)).ToList(),
                PatternsToMatch = sdkRoutingRule.PatternsToMatch?.ToList(),
                FrontendEndpointIds = sdkRoutingRule.FrontendEndpoints?.Select(x => x.Id).ToList(),
                ForwardingProtocol = sdkRoutingRule.ForwardingProtocol == null ? (PSForwardingProtocol?)null : (PSForwardingProtocol)Enum.Parse(typeof(PSForwardingProtocol), sdkRoutingRule.ForwardingProtocol),
                BackendPoolId = sdkRoutingRule.BackendPool?.Id,
                EnableCaching = sdkRoutingRule.CacheConfiguration != null,
                QueryParameterStripDirective = sdkRoutingRule.CacheConfiguration == null ? (PSQueryParameterStripDirective?)null : (PSQueryParameterStripDirective)Enum.Parse(typeof(PSQueryParameterStripDirective), sdkRoutingRule.CacheConfiguration.QueryParameterStripDirective),
                DynamicCompression = sdkRoutingRule.CacheConfiguration == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkRoutingRule.CacheConfiguration.DynamicCompression),
                EnabledState = sdkRoutingRule.EnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkRoutingRule.EnabledState)
            };
        }
        public static SdkRoutingRule ToSdkRoutingRule(this PSRoutingRule psRoutingRule)
        {
            return new SdkRoutingRule
            (
                frontendEndpoints: psRoutingRule.FrontendEndpointIds?.Select(x => new SdkRefId(x)).ToList(),
                acceptedProtocols: psRoutingRule.AcceptedProtocols?.Select(x => x.ToString()).ToList(),
                patternsToMatch: psRoutingRule.PatternsToMatch,
                customForwardingPath: psRoutingRule.CustomForwardingPath,
                forwardingProtocol: psRoutingRule.ForwardingProtocol.ToString(),
                cacheConfiguration: psRoutingRule.EnableCaching? new SdkCacheConfiguration(psRoutingRule.QueryParameterStripDirective.ToString(), psRoutingRule.DynamicCompression.ToString()) : null,
                backendPool: new SdkRefId(psRoutingRule.BackendPoolId),
                name: psRoutingRule.Name,
                enabledState: psRoutingRule.EnabledState.ToString()
            );
        }
        public static PSBackend ToPSBackend(this SdkBackend sdkBackend)
        {
            return new PSBackend
            {
                Address = sdkBackend.Address,
                HttpPort = sdkBackend.HttpPort,
                HttpsPort = sdkBackend.HttpsPort,
                EnabledState = sdkBackend.EnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkBackend.EnabledState),
                Priority = sdkBackend.Priority,
                Weight = sdkBackend.Weight,
                BackendHostHeader = sdkBackend.BackendHostHeader

            };
        }
        public static SdkBackend ToSdkBackend(this PSBackend psBackend)
        {
            return new SdkBackend(
                psBackend.Address,
                psBackend.HttpPort,
                psBackend.HttpsPort,
                psBackend.EnabledState.ToString(),
                psBackend.Priority,
                psBackend.Weight,
                psBackend.BackendHostHeader
                );
        }
        public static PSBackendPool ToPSBackendPool(this SdkBackendPool sdkBackendPool)
        {
            return new PSBackendPool
            {
                Id = sdkBackendPool.Id,
                Type = sdkBackendPool.Type,
                Name = sdkBackendPool.Name,
                LoadBalancingSettingRef = sdkBackendPool.LoadBalancingSettings.Id,
                HealthProbeSettingRef = sdkBackendPool.HealthProbeSettings.Id,
                ResourceState = sdkBackendPool.ResourceState,
                Backends = sdkBackendPool.Backends?.Select(x => x.ToPSBackend()).ToList()
                
            };
        }

        public static SdkBackendPool ToSdkBackendPool(this PSBackendPool psBackendPool)
        {
            return new SdkBackendPool(
                backends: psBackendPool.Backends?.Select(x => x.ToSdkBackend()).ToList(),
                loadBalancingSettings: new SdkRefId(psBackendPool.LoadBalancingSettingRef),
                healthProbeSettings: new SdkRefId(psBackendPool.HealthProbeSettingRef),
                name: psBackendPool.Name
                );
        }

        public static PSHealthProbeSetting ToPSHealthProbeSetting(this SdkHealthProbeSetting sdkHealthProbeSetting)
        {
            return new PSHealthProbeSetting
            {
                Id = sdkHealthProbeSetting.Id,
                Name = sdkHealthProbeSetting.Name,
                Type = sdkHealthProbeSetting.Type,
                Path = sdkHealthProbeSetting.Path,
                Protocol = sdkHealthProbeSetting.Protocol == null ? (PSProtocol?)null : (PSProtocol)Enum.Parse(typeof(PSProtocol), sdkHealthProbeSetting.Protocol),
                IntervalInSeconds = sdkHealthProbeSetting.IntervalInSeconds,
                ResourceState = sdkHealthProbeSetting.ResourceState
            };
        }

        public static SdkHealthProbeSetting ToSdkHealthProbeSetting(this PSHealthProbeSetting psHealthProbeSetting)
        {
            return new SdkHealthProbeSetting(
                path: psHealthProbeSetting.Path,
                protocol: psHealthProbeSetting.Protocol.ToString(),
                intervalInSeconds: psHealthProbeSetting.IntervalInSeconds,
                name: psHealthProbeSetting.Name

            );
        }

        public static PSLoadBalancingSetting ToPSLoadBalancingSetting(this SdkLoadBalancingSetting sdkLoadBalancingSetting)
        {
            return new PSLoadBalancingSetting
            {
                Id = sdkLoadBalancingSetting.Id,
                SampleSize = sdkLoadBalancingSetting.SampleSize,
                SuccessfulSamplesRequired = sdkLoadBalancingSetting.SuccessfulSamplesRequired,
                AdditionalLatencyMilliseconds = sdkLoadBalancingSetting.AdditionalLatencyMilliseconds,
                ResourceState = sdkLoadBalancingSetting.ResourceState,
                Name = sdkLoadBalancingSetting.Name,
                Type = sdkLoadBalancingSetting.Type
            };
        }

        public static SdkLoadBalancingSetting ToSdkLoadBalancingSetting(this PSLoadBalancingSetting psLoadBalancingSetting)
        {
            return new SdkLoadBalancingSetting
            (
                sampleSize: psLoadBalancingSetting.SampleSize,
                successfulSamplesRequired: psLoadBalancingSetting.SuccessfulSamplesRequired,
                additionalLatencyMilliseconds: psLoadBalancingSetting.AdditionalLatencyMilliseconds,
                name: psLoadBalancingSetting.Name
            );
        }

        public static SdkFrontendEndpoint ToSdkFrontendEndpoints(this PSFrontendEndpoint psFrontendEndpoint)
        {
            return new SdkFrontendEndpoint
            (
                hostName: psFrontendEndpoint.HostName,
                sessionAffinityEnabledState: psFrontendEndpoint.SessionAffinityEnabledState.ToString(),
                sessionAffinityTtlSeconds: psFrontendEndpoint.SessionAffinityTtlSeconds,
                webApplicationFirewallPolicyLink: psFrontendEndpoint.WebApplicationFirewallPolicyLink == null ? null : new SdkFWPolicyLink(psFrontendEndpoint.WebApplicationFirewallPolicyLink),
                customHttpsConfiguration: new SdkHttpsConfig(psFrontendEndpoint.CertificateSource.ToString(),
                                   psFrontendEndpoint.ProtocolType.ToString(),
                                   new SdkValut(psFrontendEndpoint.Vault),
                                   psFrontendEndpoint.SecretName,
                                   psFrontendEndpoint.SecretVersion,
                                   psFrontendEndpoint.CertificateType.ToString()),
                name: psFrontendEndpoint.Name
            );
        }

        public static PSFrontendEndpoint ToPSFrontendEndpoints(this SdkFrontendEndpoint sdkFrontendEndpoint)
        {
            return new PSFrontendEndpoint
            {
                Id = sdkFrontendEndpoint.Id,
                HostName = sdkFrontendEndpoint.HostName,
                SessionAffinityEnabledState = sdkFrontendEndpoint.SessionAffinityEnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkFrontendEndpoint.SessionAffinityEnabledState),
                SessionAffinityTtlSeconds = sdkFrontendEndpoint.SessionAffinityTtlSeconds,
                WebApplicationFirewallPolicyLink = sdkFrontendEndpoint.WebApplicationFirewallPolicyLink?.Id,
                ResourceState = sdkFrontendEndpoint.ResourceState,
                CustomHttpsProvisioningState = sdkFrontendEndpoint.CustomHttpsProvisioningState == null ?
                        (PSCustomHttpsProvisioningState?)null : (PSCustomHttpsProvisioningState)Enum.Parse(typeof(PSCustomHttpsProvisioningState), sdkFrontendEndpoint.CustomHttpsProvisioningState),
                CustomHttpsProvisioningSubstate = sdkFrontendEndpoint.CustomHttpsProvisioningSubstate == null ?
                        (PSCustomHttpsProvisioningSubstate?)null : (PSCustomHttpsProvisioningSubstate)Enum.Parse(typeof(PSCustomHttpsProvisioningSubstate), sdkFrontendEndpoint.CustomHttpsProvisioningSubstate),
                CertificateSource = sdkFrontendEndpoint.CustomHttpsConfiguration == null || sdkFrontendEndpoint.CustomHttpsConfiguration.CertificateSource == null ?
                        (PSCertificateSource?)null : (PSCertificateSource)Enum.Parse(typeof(PSCertificateSource), sdkFrontendEndpoint.CustomHttpsConfiguration.CertificateSource),
                ProtocolType = sdkFrontendEndpoint.CustomHttpsConfiguration == null || sdkFrontendEndpoint.CustomHttpsConfiguration.ProtocolType == null ?
                        (PSProtocolType?)null : (PSProtocolType)Enum.Parse(typeof(PSProtocolType), sdkFrontendEndpoint.CustomHttpsConfiguration.ProtocolType),
                Vault = sdkFrontendEndpoint.CustomHttpsConfiguration?.Vault?.Id,
                SecretName = sdkFrontendEndpoint.CustomHttpsConfiguration?.SecretName,
                SecretVersion = sdkFrontendEndpoint.CustomHttpsConfiguration?.SecretVersion,
                CertificateType = sdkFrontendEndpoint.CustomHttpsConfiguration == null || sdkFrontendEndpoint.CustomHttpsConfiguration.CertificateType == null ?
                        (PSCertificateType?)null : (PSCertificateType)Enum.Parse(typeof(PSCertificateType), sdkFrontendEndpoint.CustomHttpsConfiguration.CertificateType),
                Name = sdkFrontendEndpoint.Name,
                Type = sdkFrontendEndpoint.Type
            };
        }
        public static PSCustomRule ToPSCustomRule(this SdkCustomRule sdkRule)
        {
            return new PSCustomRule
            {
                RateLimitDurationInMinutes = sdkRule.RateLimitDurationInMinutes,
                RateLimitThreshold = sdkRule.RateLimitThreshold,
                Name = sdkRule.Name,
                Action = sdkRule.Action == null ? (PSAction?)null : (PSAction)Enum.Parse(typeof(PSAction), sdkRule.Action),
                Etag = sdkRule.Etag,
                RuleType = sdkRule.RuleType == null ? (PSCustomRuleType?)null : (PSCustomRuleType)Enum.Parse(typeof(PSCustomRuleType), sdkRule.RuleType),
                Priority = sdkRule.Priority,
                Transforms = sdkRule.Transforms?.ToList(),
                MatchConditions = sdkRule.MatchConditions?.Select(x => x.ToPSMatchCondition()).ToList()
            };
        }

        public static PSAzureRuleGroupOverride ToPSAzRuleGroupOverride(this sdkAzRuleGroupOverride sdkAzOverride)
        {
            return new PSAzureRuleGroupOverride
            {
                RuleGroupOverride = (PSRuleGroupOverride)Enum.Parse(typeof(PSRuleGroupOverride), sdkAzOverride.RuleGroupOverride),
                Action = (PSAction)Enum.Parse(typeof(PSAction), sdkAzOverride.Action),
            };
        }


        public static PSManagedRule ToPSManagedRule(this SdkManagedRule sdkRule)
        {
            sdkRule.GetType().ToString();
            var sdkAzRule = (SdkAzureManagedRule)sdkRule;
            return new PSAzureManagedRule
            {
                Priority = sdkAzRule.Priority,
                RuleGroupOverrides = sdkAzRule.RuleGroupOverrides?.Select(x => x.ToPSAzRuleGroupOverride()).ToList()
            };
        }

        public static PSPolicy ToPSPolicy(this SdkFirewallPolicy sdkPolicy)
        {

            return new PSPolicy
            {
                Name = sdkPolicy.Name,
                Id = sdkPolicy.Id,
                PolicyEnabledState = sdkPolicy.PolicySettings == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkPolicy.PolicySettings.EnabledState),
                PolicyMode = sdkPolicy.PolicySettings == null ? (PSMode?)null : (PSMode)Enum.Parse(typeof(PSMode), sdkPolicy.PolicySettings.Mode),
                CustomRules = sdkPolicy.CustomRules?.Rules?.Select(x => x.ToPSCustomRule()).ToList(),
                ManagedRules = sdkPolicy.ManagedRules?.RuleSets?.Select(x => x.ToPSManagedRule()).ToList(),
                Etag = sdkPolicy.Etag,
                ProvisioningState = sdkPolicy.ProvisioningState
            };
        }

        public static PSMatchCondition ToPSMatchCondition(this sdkMatchCondition sdkMatchCondition)
        {
            return new PSMatchCondition
            {
                MatchVariable = sdkMatchCondition.MatchVariable == null? (PSMatchVariable?)null : (PSMatchVariable)Enum.Parse(typeof(PSMatchVariable), sdkMatchCondition.MatchVariable),
                MatchValue = sdkMatchCondition.MatchValue.ToList(),
                OperatorProperty = sdkMatchCondition.OperatorProperty == null? (PSOperatorProperty?)null : (PSOperatorProperty)Enum.Parse(typeof(PSOperatorProperty), sdkMatchCondition.OperatorProperty),
                Selector = sdkMatchCondition.Selector,
                NegateCondition = sdkMatchCondition.NegateCondition,
            };
        }

        public static sdkAzRuleGroupOverride ToSdkAzRuleGroupOverride(this PSAzureRuleGroupOverride psAzOverride)
        {
            return new sdkAzRuleGroupOverride
            {
                RuleGroupOverride = psAzOverride.RuleGroupOverride.ToString(),
                Action = psAzOverride.Action.ToString()
            };
        }

        public static SdkManagedRule ToSdkAzManagedRule(this PSManagedRule psRule)
        {
            var psAzRule = (PSAzureManagedRule)psRule;
            return new SdkAzureManagedRule
            {
                Priority = psAzRule.Priority,
                RuleGroupOverrides = psAzRule.RuleGroupOverrides?.Select(x => x.ToSdkAzRuleGroupOverride()).ToList()
            };
        }

        public static sdkMatchCondition ToSdkMatchCondition(this PSMatchCondition psMatchCondition)
        {
            return new sdkMatchCondition
            {
                MatchValue = psMatchCondition.MatchValue,
                MatchVariable = psMatchCondition.MatchVariable.ToString(),
                NegateCondition = psMatchCondition.NegateCondition,
                Selector = psMatchCondition.Selector,
                OperatorProperty = psMatchCondition.OperatorProperty.ToString()
            };
        }

        public static SdkCustomRule ToSdkCustomRule(this PSCustomRule psRule)
        {
            return new SdkCustomRule
            {
                Name = psRule.Name,
                RateLimitDurationInMinutes = psRule.RateLimitDurationInMinutes,
                RateLimitThreshold = psRule.RateLimitThreshold,
                Action = psRule.Action.ToString(),
                MatchConditions = psRule.MatchConditions?.Select(x => x.ToSdkMatchCondition()).ToList(),
                Priority = psRule.Priority,
                RuleType = psRule.RuleType.ToString(),
                Transforms = psRule.Transforms
            };
        }

        public static SdkFirewallPolicy ToSdkFirewallPolicy(this PSPolicy psPolicy)
        {
            return new SdkFirewallPolicy
            {
                Location = "global",
                PolicySettings = new sdkPolicySetting
                {
                    EnabledState = psPolicy.PolicyEnabledState.ToString(),
                    Mode = psPolicy.PolicyMode.ToString()
                },
                CustomRules = new SdkCustomRules {
                   Rules =  psPolicy.CustomRules?.Select(x => x.ToSdkCustomRule()).ToList()
                },
                ManagedRules = new SdkManagedRules
                {
                    RuleSets = psPolicy.ManagedRules?.Select(x => x.ToSdkAzManagedRule()).ToList()
                },
            };
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
        public static IDictionary<string, string> ToDictionaryTags(this Hashtable table)
        {
            return table?.Cast<DictionaryEntry>()
                .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
        }

        public static void ValidateFrontDoor(this PSFrontDoor frontDoor, string resourceGroup, string subId)
        {
            //Create Resource ID for existing subresources.
            HashSet<string> routingRuleIds = new HashSet<string>();
            foreach (var routingRule in frontDoor.RoutingRules)
            {
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/RoutingRules/{3}",
                   subId, resourceGroup, frontDoor.Name, routingRule.Name).ToLower();
                if (routingRuleIds.FirstOrDefault(x => x.Equals(id)) != null)
                {
                    throw new PSArgumentException(string.Format(
                            "Routingrule name need to be identical. {0}",
                            routingRule.Name
                            ));
                }
                routingRuleIds.Add(id);
            }

            HashSet<string> healthProbeSettingIds = new HashSet<string>();
            foreach (var hpSetting in frontDoor.HealthProbeSettings)
            {
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/HealthProbeSettings/{3}",
                        subId, resourceGroup, frontDoor.Name, hpSetting.Name).ToLower();
                if (healthProbeSettingIds.FirstOrDefault(x => x.Equals(id)) != null)
                {
                    throw new PSArgumentException(string.Format(
                            "HealthProbeSettings name need to be identical. {0}",
                            hpSetting.Name
                            ));
                }
                healthProbeSettingIds.Add(id);
            }

            HashSet<string> loadBalancingSettingIds = new HashSet<string>();
            foreach (var lbSetting in frontDoor.LoadBalancingSettings)
            {
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/LoadBalancingSettings/{3}",
                        subId, resourceGroup, frontDoor.Name, lbSetting.Name).ToLower();
                if (loadBalancingSettingIds.FirstOrDefault(x => x.Equals(id)) != null)
                {
                    throw new PSArgumentException(string.Format(
                            "LoadBalancingSettings name need to be identical. {0}",
                            lbSetting.Name
                            ));
                }
                loadBalancingSettingIds.Add(id);
            }

            HashSet<string> frontendEndpointIds = new HashSet<string>();
            foreach (var frontendEndpoint in frontDoor.FrontendEndpoints)
            {
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/FrontendEndpoints/{3}",
                        subId, resourceGroup, frontDoor.Name, frontendEndpoint.Name).ToLower();
                if (frontendEndpointIds.FirstOrDefault(x => x.Equals(id)) != null)
                {
                    throw new PSArgumentException(string.Format(
                            "FrontendEndpoint name need to be identical. {0}",
                            frontendEndpoint.Name
                            ));
                }
                frontendEndpointIds.Add(id.ToLower());
            }

            HashSet<string> backendPoolIds = new HashSet<string>();
            foreach (var backendPool in frontDoor.BackendPools)
            {
                string id = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/BackendPools/{3}",
                        subId, resourceGroup, frontDoor.Name, backendPool.Name).ToLower();
                if (backendPoolIds.FirstOrDefault(x => x.Equals(id)) != null)
                {
                    throw new PSArgumentException(string.Format(
                            "BackendPool name need to be identical. {0}",
                            backendPool.Name
                            ));
                }
                backendPoolIds.Add(id.ToLower());
            }

            // Validate reference in each resources
            foreach (var routingRule in frontDoor.RoutingRules)
            {
                
                foreach(var id in routingRule.FrontendEndpointIds)
                {
                    if (frontendEndpointIds.FirstOrDefault(x => x.Equals(id.ToLower())) == null)
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid FrontendEndpointId {0} in {1}. Target doesn't exist",
                                id, routingRule.Name
                                ));
                    }
                }

                if (backendPoolIds.FirstOrDefault(x => x.Equals(routingRule.BackendPoolId.ToLower())) == null)
                {
                    throw new PSArgumentException(string.Format(
                            "Invalid BackendPollId {0} in {1}. Target doesn't exist",
                            routingRule.BackendPoolId, routingRule.Name
                            ));
                }

            }
            
            foreach (var backendPool in frontDoor.BackendPools)
            {
                if (healthProbeSettingIds.FirstOrDefault(x => x.Equals(backendPool.HealthProbeSettingRef.ToLower())) == null)
                {
                    throw new PSArgumentException(string.Format(
                            "Invalid HealthProbeSetting {0} in {1}. Target doesn't exist",
                            backendPool.HealthProbeSettingRef,backendPool.Name
                            ));
                }

                if (loadBalancingSettingIds.FirstOrDefault(x => x.Equals(backendPool.LoadBalancingSettingRef.ToLower())) == null)
                {
                    throw new PSArgumentException(string.Format(
                            "Invalid HealthProbeSetting {0} in {1}. Target doesn't exist",
                            backendPool.LoadBalancingSettingRef, backendPool.Name
                            ));
                }
            }

        }

    }    
}
