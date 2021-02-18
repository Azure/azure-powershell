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

using SdkAfdCustomDomain = Microsoft.Azure.Management.Cdn.Models.AFDDomain;
using SdkAfdEndpoint = Microsoft.Azure.Management.Cdn.Models.AFDEndpoint;
using SdkAfdOrigin = Microsoft.Azure.Management.Cdn.Models.AFDOrigin;
using SdkAfdOriginGroup = Microsoft.Azure.Management.Cdn.Models.AFDOriginGroup;
using SdkAfdProfile = Microsoft.Azure.Management.Cdn.Models.Profile;

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
                OriginResponseTimeoutSeconds = sdkAfdEndpoint.OriginResponseTimeoutSeconds,
                EnabledState = sdkAfdEndpoint.EnabledState
            };
        }

        public static PSAfdOrigin ToPSAfdOrigin(this SdkAfdOrigin sdkOrigin)
        {
            var sharedPrivateLinkResource = sdkOrigin.SharedPrivateLinkResource; //??

            // origin group name is omitted since it is not provided by the SDK
            // we extract the origin group name via the input and utility methods
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
                //PrivateLinkId = ??,
                //PrivateLinkGroupId = ??,
                //PrivateLinkLocation = ??,
                //PrivateLinkStatus = ??,
                //PrivateLinkRequestMessage = ?? 
                //AzureOrigin = ??
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
                ResponseBasedDetectedErrorTypes = sdkOriginGroup.ResponseBasedAfdOriginErrorDetectionSettings?.ResponseBasedDetectedErrorTypes.Value.ToString(), // not showing up, something wrong with sdk?
                ResponseBasedFailoverThresholdPercentage = sdkOriginGroup.ResponseBasedAfdOriginErrorDetectionSettings?.ResponseBasedFailoverThresholdPercentage, // not showing up, something wrong with sdk?
                // HttpErrorRanges = Fill in when implementing New / Set
                TrafficRestorationTimeToHealedOrNewEndpointsInMinutes = sdkOriginGroup.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes,
                SessionAffinityState = sdkOriginGroup.SessionAffinityState
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
    }
}
