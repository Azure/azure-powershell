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

using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Management.FrontDoor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using sdkAzManagedRuleExclusion = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleExclusion;
using sdkAzManagedRuleGroupOverride = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleGroupOverride;
using sdkAzManagedRuleOverride = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleOverride;
using SdkBackend = Microsoft.Azure.Management.FrontDoor.Models.Backend;
using SdkBackendPool = Microsoft.Azure.Management.FrontDoor.Models.BackendPool;
using SdkBackendPoolsSettings = Microsoft.Azure.Management.FrontDoor.Models.BackendPoolsSettings;
using SdkCacheConfiguration = Microsoft.Azure.Management.FrontDoor.Models.CacheConfiguration;
using SdkCustomRule = Microsoft.Azure.Management.FrontDoor.Models.CustomRule;
using SdkCustomRuleList = Microsoft.Azure.Management.FrontDoor.Models.CustomRuleList;
using SdkFirewallPolicy = Microsoft.Azure.Management.FrontDoor.Models.WebApplicationFirewallPolicy;
using SdkForwardingConfiguration = Microsoft.Azure.Management.FrontDoor.Models.ForwardingConfiguration;
using SdkFrontDoor = Microsoft.Azure.Management.FrontDoor.Models.FrontDoorModel;
using SdkFrontendEndpoint = Microsoft.Azure.Management.FrontDoor.Models.FrontendEndpoint;
using SdkFWPolicyLink = Microsoft.Azure.Management.FrontDoor.Models.FrontendEndpointUpdateParametersWebApplicationFirewallPolicyLink;
using SdkHealthProbeSetting = Microsoft.Azure.Management.FrontDoor.Models.HealthProbeSettingsModel;
using SdkHttpsConfig = Microsoft.Azure.Management.FrontDoor.Models.CustomHttpsConfiguration;
using SdkLoadBalancingSetting = Microsoft.Azure.Management.FrontDoor.Models.LoadBalancingSettingsModel;
using SdkManagedRule = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleSet;
using SdkManagedRuleDefinition = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleDefinition;
using SdkManagedRuleGroupDefinition = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleGroupDefinition;
using SdkManagedRuleList = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleSetList;
using SdkManagedRuleSetDefinition = Microsoft.Azure.Management.FrontDoor.Models.ManagedRuleSetDefinition;
using sdkMatchCondition = Microsoft.Azure.Management.FrontDoor.Models.MatchCondition;
using sdkPolicySetting = Microsoft.Azure.Management.FrontDoor.Models.PolicySettings;
using SdkRedirectConfiguration = Microsoft.Azure.Management.FrontDoor.Models.RedirectConfiguration;
using SdkRefId = Microsoft.Azure.Management.FrontDoor.Models.SubResource;
using SdkRouteConfiguration = Microsoft.Azure.Management.FrontDoor.Models.RouteConfiguration;
using SdkRoutingRule = Microsoft.Azure.Management.FrontDoor.Models.RoutingRule;
using SdkRulesEngine = Microsoft.Azure.Management.FrontDoor.Models.RulesEngine;
using SdkRulesEngineRule = Microsoft.Azure.Management.FrontDoor.Models.RulesEngineRule;
using SdkVault = Microsoft.Azure.Management.FrontDoor.Models.KeyVaultCertificateSourceParametersVault;

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
                enabledState: psFrontDoor.EnabledState.ToString(),
                backendPoolsSettings: psFrontDoor.BackendPoolsSetting.ToSdkBackendPoolsSettings()
                // Rule Engine should not be allowed to be updated here
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
                FrontDoorId = sdkFrontDoor.FrontdoorId,
                RoutingRules = sdkFrontDoor.RoutingRules?.Select(x => x.ToPSRoutingRule()).ToList(),
                BackendPools = sdkFrontDoor.BackendPools?.Select(x => x.ToPSBackendPool()).ToList(),
                HealthProbeSettings = sdkFrontDoor.HealthProbeSettings?.Select(x => x.ToPSHealthProbeSetting()).ToList(),
                LoadBalancingSettings = sdkFrontDoor.LoadBalancingSettings?.Select(x => x.ToPSLoadBalancingSetting()).ToList(),
                FrontendEndpoints = sdkFrontDoor.FrontendEndpoints?.Select(x => x.ToPSFrontendEndpoints()).ToList(),
                EnabledState = sdkFrontDoor.EnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkFrontDoor.EnabledState),
                ResourceState = sdkFrontDoor.ResourceState,
                ProvisioningState = sdkFrontDoor.ProvisioningState,
                BackendPoolsSetting = sdkFrontDoor.BackendPoolsSettings?.ToPSBackendPoolsSetting(),
                // PSFrontDoor parameter EnforceCertificateNameCheck is no longer actively used, in favor of BackendPoolsSetting which 
                // encapsulates this property. However, for backwards compability, we set this field so that it is still displayed to users.
                EnforceCertificateNameCheck = sdkFrontDoor.BackendPoolsSettings == null
                                                ? (PSEnforceCertificateNameCheck?)null
                                                : (PSEnforceCertificateNameCheck)Enum.Parse(typeof(PSEnforceCertificateNameCheck), sdkFrontDoor.BackendPoolsSettings.EnforceCertificateNameCheck),
                RulesEngine = sdkFrontDoor.RulesEngines?.Select(x => x.ToPSRulesEngine()).ToList()
            };
        }

        private static PSRouteConfiguration ToPSRouteConfiguration(this SdkRouteConfiguration sdkRouteConfiguration)
        {
            if (sdkRouteConfiguration is SdkForwardingConfiguration)
            {
                var SDKForwardingConfiguration = sdkRouteConfiguration as SdkForwardingConfiguration;
                return new PSForwardingConfiguration
                {
                    CustomForwardingPath = SDKForwardingConfiguration.CustomForwardingPath,
                    ForwardingProtocol = SDKForwardingConfiguration.ForwardingProtocol,
                    BackendPoolId = SDKForwardingConfiguration.BackendPool?.Id,
                    EnableCaching = SDKForwardingConfiguration.CacheConfiguration != null,
                    QueryParameterStripDirective = SDKForwardingConfiguration.CacheConfiguration?.QueryParameterStripDirective,
                    DynamicCompression = SDKForwardingConfiguration.CacheConfiguration?.DynamicCompression == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), SDKForwardingConfiguration.CacheConfiguration.DynamicCompression)
                };
            }
            else if (sdkRouteConfiguration is SdkRedirectConfiguration)
            {
                var SDKRedirectConfiguration = sdkRouteConfiguration as SdkRedirectConfiguration;
                return new PSRedirectConfiguration
                {
                    RedirectType = SDKRedirectConfiguration.RedirectType,
                    RedirectProtocol = SDKRedirectConfiguration.RedirectProtocol,
                    CustomHost = SDKRedirectConfiguration.CustomHost,
                    CustomPath = SDKRedirectConfiguration.CustomPath,
                    CustomFragment = SDKRedirectConfiguration.CustomFragment,
                    CustomQueryString = SDKRedirectConfiguration.CustomQueryString
                };
            }

            return null;
        }

        private static SdkRouteConfiguration ToSdkRouteConfiguration(this PSRouteConfiguration psRoutingConfiguration)
        {
            if (psRoutingConfiguration is PSForwardingConfiguration)
            {
                var psForwardingConfiguration = psRoutingConfiguration as PSForwardingConfiguration;
                return new SdkForwardingConfiguration
                {
                    CustomForwardingPath = psForwardingConfiguration.CustomForwardingPath,
                    ForwardingProtocol = psForwardingConfiguration.ForwardingProtocol,
                    BackendPool = new SdkRefId(psForwardingConfiguration.BackendPoolId),
                    CacheConfiguration = psForwardingConfiguration.EnableCaching ? new SdkCacheConfiguration(psForwardingConfiguration.QueryParameterStripDirective.ToString(), psForwardingConfiguration.DynamicCompression.ToString()) : null
                };
            }
            else if (psRoutingConfiguration is PSRedirectConfiguration)
            {
                var psRedirectConfiguration = psRoutingConfiguration as PSRedirectConfiguration;
                return new SdkRedirectConfiguration
                {
                    RedirectType = psRedirectConfiguration.RedirectType,
                    RedirectProtocol = psRedirectConfiguration.RedirectProtocol,
                    CustomHost = psRedirectConfiguration.CustomHost,
                    CustomPath = psRedirectConfiguration.CustomPath,
                    CustomFragment = psRedirectConfiguration.CustomFragment,
                    CustomQueryString = psRedirectConfiguration.CustomQueryString
                };
            }

            return null;
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
                RouteConfiguration = ToPSRouteConfiguration(sdkRoutingRule.RouteConfiguration),
                EnabledState = sdkRoutingRule.EnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkRoutingRule.EnabledState),
                RulesEngineId = sdkRoutingRule.RulesEngine?.Id
            };
        }
        public static SdkRoutingRule ToSdkRoutingRule(this PSRoutingRule psRoutingRule)
        {
            return new SdkRoutingRule
            (
                frontendEndpoints: psRoutingRule.FrontendEndpointIds?.Select(x => new SdkRefId(x)).ToList(),
                acceptedProtocols: psRoutingRule.AcceptedProtocols?.Select(x => x.ToString()).ToList(),
                patternsToMatch: psRoutingRule.PatternsToMatch,
                routeConfiguration: ToSdkRouteConfiguration(psRoutingRule.RouteConfiguration),
                name: psRoutingRule.Name,
                enabledState: psRoutingRule.EnabledState.ToString(),
                rulesEngine: string.IsNullOrWhiteSpace(psRoutingRule.RulesEngineId) ? null : new SdkRefId(psRoutingRule.RulesEngineId)
            );
        }

        public static PSRulesEngineRule ToPSRulesEngineRule(this SdkRulesEngineRule sdkRulesEngineRule)
        {
            return new PSRulesEngineRule
            {
                Name = sdkRulesEngineRule.Name,
                Priority = sdkRulesEngineRule.Priority,
                Action = ToPSRulesEngineAction(sdkRulesEngineRule.Action),
                MatchProcessingBehavior = sdkRulesEngineRule.MatchProcessingBehavior == null
                    ? PSMatchProcessingBehavior.Continue
                    : (PSMatchProcessingBehavior)Enum.Parse(typeof(PSMatchProcessingBehavior), sdkRulesEngineRule.MatchProcessingBehavior),
                MatchConditions = sdkRulesEngineRule.MatchConditions?.Select(x => ToPSRulesEngineMatchCondition(x)).ToList(),
            };
        }

        public static SdkRulesEngineRule ToSdkRulesEngineRule(this PSRulesEngineRule psRulesEngineRule)
        {
            return new SdkRulesEngineRule
            (
                name: psRulesEngineRule.Name,
                priority: psRulesEngineRule.Priority,
                action: ToSdkRulesEngineAction(psRulesEngineRule.Action),
                matchConditions: psRulesEngineRule.MatchConditions?.Select(x => ToSdkMatchcondition(x)).ToList(),
                matchProcessingBehavior: psRulesEngineRule.MatchProcessingBehavior.ToString()
            );
        }

        public static PSRulesEngineAction ToPSRulesEngineAction(RulesEngineAction sdkRulesEngineAction)
        {
            return new PSRulesEngineAction
            {
                RequestHeaderActions = sdkRulesEngineAction.RequestHeaderActions?
                                            .Select(x => ToPSHeaderAction(x))
                                            .ToList(),
                ResponseHeaderActions = sdkRulesEngineAction.ResponseHeaderActions?
                                            .Select(x => ToPSHeaderAction(x))
                                            .ToList(),
                RouteConfigurationOverride = ToPSRouteConfiguration(sdkRulesEngineAction.RouteConfigurationOverride)
            };
        }

        public static RulesEngineAction ToSdkRulesEngineAction(PSRulesEngineAction psRulesEngineAction)
        {
            return new RulesEngineAction
            (
                requestHeaderActions: psRulesEngineAction.RequestHeaderActions?
                                            .Select(x => ToSdkHeaderAction(x))
                                            .ToList(),
                responseHeaderActions: psRulesEngineAction.ResponseHeaderActions?
                                            .Select(x => ToSdkHeaderAction(x))
                                            .ToList(),
                routeConfigurationOverride: ToSdkRouteConfiguration(psRulesEngineAction.RouteConfigurationOverride)
            );
        }

        public static PSHeaderAction ToPSHeaderAction(HeaderAction sdkHeaderAction)
        {
            return new PSHeaderAction
            {
                HeaderName = sdkHeaderAction.HeaderName,
                HeaderActionType = (PSHeaderActionType)Enum.Parse(typeof(PSHeaderActionType), sdkHeaderAction.HeaderActionType),
                Value = sdkHeaderAction.Value
            };
        }

        public static HeaderAction ToSdkHeaderAction(PSHeaderAction psHeaderAction)
        {
            return new HeaderAction
            (
                headerActionType: psHeaderAction.HeaderActionType.ToString(),
                headerName: psHeaderAction.HeaderName,
                value: psHeaderAction.Value
            );
        }

        public static PSRulesEngineMatchCondition ToPSRulesEngineMatchCondition(RulesEngineMatchCondition sdkMatchCondition)
        {
            return new PSRulesEngineMatchCondition
            {
                RulesEngineMatchVariable = (PSRulesEngineMatchVariable)Enum.Parse(typeof(PSRulesEngineMatchVariable), sdkMatchCondition.RulesEngineMatchVariable),
                RulesEngineMatchValue = sdkMatchCondition.RulesEngineMatchValue.ToList(),
                Selector = sdkMatchCondition.Selector,
                RulesEngineOperator = (PSRulesEngineOperator)Enum.Parse(typeof(PSRulesEngineOperator), sdkMatchCondition.RulesEngineOperator),
                NegateCondition = sdkMatchCondition.NegateCondition,
                Transforms = sdkMatchCondition.Transforms?.Select(x => (PSTransform)Enum.Parse(typeof(PSTransform), x.ToString())).ToList()
            };
        }

        public static RulesEngineMatchCondition ToSdkMatchcondition(PSRulesEngineMatchCondition psRulesEngineMatchCondition)
        {
            return new RulesEngineMatchCondition
            (
                rulesEngineMatchVariable: psRulesEngineMatchCondition.RulesEngineMatchVariable.ToString(),
                rulesEngineOperator: psRulesEngineMatchCondition.RulesEngineOperator.ToString(),
                rulesEngineMatchValue: psRulesEngineMatchCondition.RulesEngineMatchValue,
                selector: psRulesEngineMatchCondition.Selector,
                negateCondition: psRulesEngineMatchCondition.NegateCondition,
                transforms: psRulesEngineMatchCondition.Transforms?.Select(x => x.ToString()).ToList()
            );
        }

        public static PSRulesEngine ToPSRulesEngine(this SdkRulesEngine sdkRulesEngine)
        {
            return new PSRulesEngine
            {
                Id = sdkRulesEngine.Id,
                Name = sdkRulesEngine.Name,
                RulesEngineRules = sdkRulesEngine.Rules?.Select(x => ToPSRulesEngineRule(x)).ToList()
            };
        }

        public static SdkRulesEngine ToSdkRulesEngine(this PSRulesEngine psRulesEngine)
        {
            return new SdkRulesEngine
            (
                rules: psRulesEngine.RulesEngineRules?.Select(x => ToSdkRulesEngineRule(x)).ToList()
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
                BackendHostHeader = sdkBackend.BackendHostHeader,
                PrivateLinkAlias = sdkBackend.PrivateLinkAlias,
                PrivateLinkResourceId = sdkBackend.PrivateLinkResourceId,
                PrivateLinkLocation = sdkBackend.PrivateLinkLocation,
                PrivateEndpointStatus = sdkBackend.PrivateEndpointStatus == null ?
                        (PSPrivateEndpointStatus?)null :
                        (PSPrivateEndpointStatus)Enum.Parse(typeof(PSPrivateEndpointStatus), sdkBackend.PrivateEndpointStatus.ToString()),
                PrivateLinkApprovalMessage = sdkBackend.PrivateLinkApprovalMessage
            };
        }
        public static SdkBackend ToSdkBackend(this PSBackend psBackend)
        {
            return new SdkBackend(
                address: psBackend.Address,
                httpPort: psBackend.HttpPort,
                httpsPort: psBackend.HttpsPort,
                enabledState: psBackend.EnabledState.ToString(),
                priority: psBackend.Priority,
                weight: psBackend.Weight,
                backendHostHeader: psBackend.BackendHostHeader,
                privateLinkAlias: psBackend.PrivateLinkAlias,
                privateLinkResourceId: psBackend.PrivateLinkResourceId,
                privateLinkLocation: psBackend.PrivateLinkLocation,
                privateEndpointStatus: psBackend.PrivateEndpointStatus?.ToString(),
                privateLinkApprovalMessage: psBackend.PrivateLinkApprovalMessage
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

        public static PSBackendPoolsSetting ToPSBackendPoolsSetting(this SdkBackendPoolsSettings sdkBackendPoolsSettings)
        {
            return new PSBackendPoolsSetting
            {
                EnforceCertificateNameCheck = sdkBackendPoolsSettings.EnforceCertificateNameCheck == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkBackendPoolsSettings.EnforceCertificateNameCheck),
                SendRecvTimeoutInSeconds = sdkBackendPoolsSettings.SendRecvTimeoutSeconds
            };
        }

        public static SdkBackendPoolsSettings ToSdkBackendPoolsSettings(this PSBackendPoolsSetting psBackendPoolsSetting)
        {
            return new SdkBackendPoolsSettings(
                enforceCertificateNameCheck: psBackendPoolsSetting.EnforceCertificateNameCheck?.ToString(),
                sendRecvTimeoutSeconds: psBackendPoolsSetting.SendRecvTimeoutInSeconds
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
                ResourceState = sdkHealthProbeSetting.ResourceState,
                HealthProbeMethod = sdkHealthProbeSetting.HealthProbeMethod,
                EnabledState = string.IsNullOrEmpty(sdkHealthProbeSetting.EnabledState) ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkHealthProbeSetting.EnabledState)
            };
        }

        public static SdkHealthProbeSetting ToSdkHealthProbeSetting(this PSHealthProbeSetting psHealthProbeSetting)
        {
            return new SdkHealthProbeSetting(
                path: psHealthProbeSetting.Path,
                protocol: psHealthProbeSetting.Protocol.ToString(),
                intervalInSeconds: psHealthProbeSetting.IntervalInSeconds,
                name: psHealthProbeSetting.Name,
                healthProbeMethod: psHealthProbeSetting.HealthProbeMethod,
                enabledState: psHealthProbeSetting.EnabledState.ToString()
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
            SdkHttpsConfig customHttpsConfiguration = null;
            if ((psFrontendEndpoint.CertificateSource != null) ||
                !String.IsNullOrEmpty(psFrontendEndpoint.MinimumTlsVersion) ||
                !String.IsNullOrEmpty(psFrontendEndpoint.Vault) ||
                !String.IsNullOrEmpty(psFrontendEndpoint.SecretName) ||
                !String.IsNullOrEmpty(psFrontendEndpoint.SecretVersion) ||
                !String.IsNullOrEmpty(psFrontendEndpoint.CertificateType))
            {
                customHttpsConfiguration = new SdkHttpsConfig(psFrontendEndpoint.CertificateSource,
                                   psFrontendEndpoint.MinimumTlsVersion,
                                   new SdkVault(psFrontendEndpoint.Vault),
                                   psFrontendEndpoint.SecretName,
                                   psFrontendEndpoint.SecretVersion,
                                   psFrontendEndpoint.CertificateType);
            }

            return new SdkFrontendEndpoint
            (
                hostName: psFrontendEndpoint.HostName,
                sessionAffinityEnabledState: psFrontendEndpoint.SessionAffinityEnabledState.ToString(),
                sessionAffinityTtlSeconds: psFrontendEndpoint.SessionAffinityTtlSeconds,
                webApplicationFirewallPolicyLink: psFrontendEndpoint.WebApplicationFirewallPolicyLink == null ? null : new SdkFWPolicyLink(psFrontendEndpoint.WebApplicationFirewallPolicyLink),
                customHttpsConfiguration: customHttpsConfiguration,
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
                CertificateSource = sdkFrontendEndpoint.CustomHttpsConfiguration?.CertificateSource,
                MinimumTlsVersion = sdkFrontendEndpoint.CustomHttpsConfiguration?.MinimumTlsVersion,
                Vault = sdkFrontendEndpoint.CustomHttpsConfiguration?.Vault?.Id,
                SecretName = sdkFrontendEndpoint.CustomHttpsConfiguration?.SecretName,
                SecretVersion = sdkFrontendEndpoint.CustomHttpsConfiguration?.SecretVersion,
                CertificateType = sdkFrontendEndpoint.CustomHttpsConfiguration?.CertificateType,
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
                Action = sdkRule.Action,
                RuleType = sdkRule.RuleType,
                Priority = sdkRule.Priority,
                MatchConditions = sdkRule.MatchConditions?.Select(x => x.ToPSMatchCondition()).ToList(),
                EnabledState = sdkRule.EnabledState
            };
        }

        public static PSAzureRuleGroupOverride ToPSAzRuleGroupOverride(this sdkAzManagedRuleGroupOverride sdkAzOverride)
        {
            return new PSAzureRuleGroupOverride()
            {
                RuleGroupName = sdkAzOverride.RuleGroupName,
                ManagedRuleOverrides = sdkAzOverride.Rules?.Select(ruleOverride =>
                {
                    return new PSAzureManagedRuleOverride()
                    {
                        Action = ruleOverride.Action,
                        EnabledState = ruleOverride.EnabledState == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), ruleOverride.EnabledState),
                        RuleId = ruleOverride.RuleId,
                        Exclusions = ruleOverride.Exclusions?.Select(exclusion => exclusion.ToPSAzManagedRuleExclusion()).ToList()
                    };
                }).ToList(),
                Exclusions = sdkAzOverride.Exclusions?.Select(exclusion => exclusion.ToPSAzManagedRuleExclusion()).ToList()
            };
        }

        public static PSManagedRuleExclusion ToPSAzManagedRuleExclusion(this sdkAzManagedRuleExclusion sdkAzExclusion)
        {
            return new PSManagedRuleExclusion()
            {
                MatchVariable = sdkAzExclusion.MatchVariable,
                Selector = sdkAzExclusion.Selector,
                SelectorMatchOperator = sdkAzExclusion.SelectorMatchOperator
            };
        }

        public static PSManagedRule ToPSManagedRule(this SdkManagedRule sdkRule)
        {
            return new PSAzureManagedRule
            {
                RuleSetType = sdkRule.RuleSetType,
                RuleSetVersion = sdkRule.RuleSetVersion,
                RuleGroupOverrides = sdkRule.RuleGroupOverrides?.Select(ruleGroupOverride => ruleGroupOverride.ToPSAzRuleGroupOverride()).ToList(),
                Exclusions = sdkRule.Exclusions?.Select(exclusion => exclusion.ToPSAzManagedRuleExclusion()).ToList()
            };
        }

        public static PSPolicy ToPSPolicy(this SdkFirewallPolicy sdkPolicy)
        {
            return new PSPolicy
            {
                Name = sdkPolicy.Name,
                Id = sdkPolicy.Id,
                PolicyEnabledState = sdkPolicy.PolicySettings == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkPolicy.PolicySettings.EnabledState),
                PolicyMode = sdkPolicy.PolicySettings?.Mode,
                CustomRules = sdkPolicy.CustomRules?.Rules?.Select(x => x.ToPSCustomRule()).ToList(),
                ManagedRules = sdkPolicy.ManagedRules?.ManagedRuleSets?.Select(x => x.ToPSManagedRule()).ToList(),
                Etag = sdkPolicy.Etag,
                ProvisioningState = sdkPolicy.ProvisioningState,
                CustomBlockResponseBody = sdkPolicy.PolicySettings?.CustomBlockResponseBody == null ? null : Encoding.UTF8.GetString(Convert.FromBase64String(sdkPolicy.PolicySettings?.CustomBlockResponseBody)),
                CustomBlockResponseStatusCode = (ushort?)sdkPolicy.PolicySettings?.CustomBlockResponseStatusCode,
                RedirectUrl = sdkPolicy.PolicySettings?.RedirectUrl,
                RequestBodyCheck = sdkPolicy.PolicySettings?.RequestBodyCheck == null ? (PSEnabledState?)null : (PSEnabledState)Enum.Parse(typeof(PSEnabledState), sdkPolicy.PolicySettings.RequestBodyCheck)
            };
        }

        public static PSManagedRuleSetDefinition ToPSManagedRuleSetDefinition(this SdkManagedRuleSetDefinition sdkManagedRuleSetDefinition)
        {
            return new PSManagedRuleSetDefinition
            {
                ProvisioningState = sdkManagedRuleSetDefinition.ProvisioningState,
                RuleSetType = sdkManagedRuleSetDefinition.RuleSetType,
                RuleSetVersion = sdkManagedRuleSetDefinition.RuleSetVersion,
                RuleGroups = sdkManagedRuleSetDefinition.RuleGroups?.Select(ruleGroup => ruleGroup.ToPSManagedRuleGroupDefinition()).ToList()
            };
        }

        public static PSManagedRuleGroupDefinition ToPSManagedRuleGroupDefinition(this SdkManagedRuleGroupDefinition sdkManagedRuleGroupDefinition)
        {
            return new PSManagedRuleGroupDefinition
            {
                RuleGroupName = sdkManagedRuleGroupDefinition.RuleGroupName,
                Description = sdkManagedRuleGroupDefinition.Description,
                Rules = sdkManagedRuleGroupDefinition.Rules?.Select(rule => rule.ToPSManagedRuleDefinition()).ToList()
            };
        }

        public static PSManagedRuleDefinition ToPSManagedRuleDefinition(this SdkManagedRuleDefinition sdkManagedRuleDefinition)
        {
            return new PSManagedRuleDefinition
            {
                RuleId = sdkManagedRuleDefinition.RuleId,
                DefaultAction = sdkManagedRuleDefinition.DefaultAction,
                DefaultState = sdkManagedRuleDefinition.DefaultState,
                Description = sdkManagedRuleDefinition.Description
            };
        }

        public static PSMatchCondition ToPSMatchCondition(this sdkMatchCondition sdkMatchCondition)
        {
            return new PSMatchCondition
            {
                MatchVariable = sdkMatchCondition.MatchVariable,
                MatchValue = sdkMatchCondition.MatchValue.ToList(),
                OperatorProperty = sdkMatchCondition.OperatorProperty,
                Selector = sdkMatchCondition.Selector,
                NegateCondition = sdkMatchCondition.NegateCondition,
                Transform = sdkMatchCondition.Transforms?.ToList()
            };
        }

        public static sdkAzManagedRuleGroupOverride ToSdkAzRuleGroupOverride(this PSAzureRuleGroupOverride psAzOverride)
        {
            return new sdkAzManagedRuleGroupOverride()
            {
                RuleGroupName = psAzOverride.RuleGroupName,
                Rules = psAzOverride.ManagedRuleOverrides?.Select(ruleOverride =>
                {
                    return new sdkAzManagedRuleOverride()
                    {
                        Action = ruleOverride.Action,
                        EnabledState = ruleOverride.EnabledState.HasValue ? ruleOverride.EnabledState.Value.ToString() : null,
                        RuleId = ruleOverride.RuleId,
                        Exclusions = ruleOverride.Exclusions?.Select(x => x.ToSdkAzManagedRuleExclusion()).ToList()
                    };
                }).ToList(),
                Exclusions = psAzOverride.Exclusions?.Select(x => x.ToSdkAzManagedRuleExclusion()).ToList()
            };
        }

        public static sdkAzManagedRuleExclusion ToSdkAzManagedRuleExclusion(this PSManagedRuleExclusion psAzManagedRuleExclusion)
        {
            return new sdkAzManagedRuleExclusion()
            {
                MatchVariable = psAzManagedRuleExclusion.MatchVariable,
                Selector = psAzManagedRuleExclusion.Selector,
                SelectorMatchOperator = psAzManagedRuleExclusion.SelectorMatchOperator
            };
        }

        public static SdkManagedRule ToSdkAzManagedRule(this PSManagedRule psRule)
        {
            var psAzRule = (PSAzureManagedRule)psRule;
            return new SdkManagedRule
            {
                RuleSetType = psAzRule.RuleSetType,
                RuleSetVersion = psAzRule.RuleSetVersion,
                RuleGroupOverrides = psAzRule.RuleGroupOverrides?.Select(x => x.ToSdkAzRuleGroupOverride()).ToList(),
                Exclusions = psAzRule.Exclusions?.Select(x => x.ToSdkAzManagedRuleExclusion()).ToList()
            };
        }

        public static sdkMatchCondition ToSdkMatchCondition(this PSMatchCondition psMatchCondition)
        {
            return new sdkMatchCondition
            {
                MatchValue = psMatchCondition.MatchValue,
                MatchVariable = psMatchCondition.MatchVariable,
                NegateCondition = psMatchCondition.NegateCondition,
                Selector = psMatchCondition.Selector,
                OperatorProperty = psMatchCondition.OperatorProperty,
                Transforms = psMatchCondition.Transform
            };
        }

        public static SdkCustomRule ToSdkCustomRule(this PSCustomRule psRule)
        {
            return new SdkCustomRule
            {
                Name = psRule.Name,
                RateLimitDurationInMinutes = psRule.RateLimitDurationInMinutes,
                RateLimitThreshold = psRule.RateLimitThreshold,
                Action = psRule.Action,
                MatchConditions = psRule.MatchConditions?.Select(x => x.ToSdkMatchCondition()).ToList(),
                Priority = psRule.Priority,
                RuleType = psRule.RuleType,
                EnabledState = psRule.EnabledState
            };
        }

        public static SdkFirewallPolicy ToSdkFirewallPolicy(this PSPolicy psPolicy)
        {
            return new SdkFirewallPolicy
            {
                Location = "global",
                PolicySettings = new sdkPolicySetting()
                {
                    EnabledState = psPolicy.PolicyEnabledState.ToString(),
                    Mode = psPolicy.PolicyMode
                },
                CustomRules = new SdkCustomRuleList()
                {
                    Rules = psPolicy.CustomRules?.Select(x => x.ToSdkCustomRule()).ToList()
                },
                ManagedRules = new SdkManagedRuleList()
                {
                    ManagedRuleSets = psPolicy.ManagedRules?.Select(x => x.ToSdkAzManagedRule()).ToList()
                }
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

                foreach (var id in routingRule.FrontendEndpointIds)
                {
                    if (frontendEndpointIds.FirstOrDefault(x => x.Equals(id.ToLower())) == null)
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid FrontendEndpointId {0} in {1}. Target doesn't exist",
                                id, routingRule.Name
                                ));
                    }
                }

                if (routingRule.RouteConfiguration is PSForwardingConfiguration)
                {
                    var forwardingConfiguration = routingRule.RouteConfiguration as PSForwardingConfiguration;
                    if (backendPoolIds.FirstOrDefault(x => x.Equals(forwardingConfiguration.BackendPoolId.ToLower())) == null)
                    {
                        throw new PSArgumentException(string.Format(
                                "Invalid BackendPollId {0} in {1}. Target doesn't exist",
                                forwardingConfiguration.BackendPoolId, routingRule.Name
                                ));
                    }
                }
            }

            foreach (var backendPool in frontDoor.BackendPools)
            {
                if (healthProbeSettingIds.FirstOrDefault(x => x.Equals(backendPool.HealthProbeSettingRef.ToLower())) == null)
                {
                    throw new PSArgumentException(string.Format(
                            "Invalid HealthProbeSetting {0} in {1}. Target doesn't exist",
                            backendPool.HealthProbeSettingRef, backendPool.Name
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
