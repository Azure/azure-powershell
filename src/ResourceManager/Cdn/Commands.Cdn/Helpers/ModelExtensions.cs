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
using SdkProvisioningState = Microsoft.Azure.Management.Cdn.Models.ProvisioningState;
using SdkDeepCreatedOrigin = Microsoft.Azure.Management.Cdn.Models.DeepCreatedOrigin;
using SdkEndpoint = Microsoft.Azure.Management.Cdn.Models.Endpoint;
using SdkQueryStringCachingBehavior = Microsoft.Azure.Management.Cdn.Models.QueryStringCachingBehavior;
using SdkOrigin = Microsoft.Azure.Management.Cdn.Models.Origin;
using SdkCustomDomain = Microsoft.Azure.Management.Cdn.Models.CustomDomain;

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
            return new SdkSku(psSku.Name.CastEnum<PSSkuName, SdkSkuName>());
        }

        public static PSSku ToPsSku(this SdkSku sdkSku)
        {
            return new PSSku { Name = sdkSku.Name.Value.CastEnum<SdkSkuName, PSSkuName>() };
        }

        public static SdkProfile ToSdkProfile(this PSProfile psProfile)
        {
            return new SdkProfile(
                psProfile.Location, 
                psProfile.Tags.ToDictionaryTags(), 
                psProfile.Id, 
                psProfile.Name, 
                psProfile.Type,
                psProfile.Sku.ToSdkSku(),
                psProfile.ResourceState.CastEnum<PSProfileResourceState, SdkProfileResourceState>(),
                psProfile.ProvisioningState.CastEnum<PSProvisioningState, SdkProvisioningState>());
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
                ProvisioningState = sdkProfile.ProvisioningState.Value.CastEnum<SdkProvisioningState, PSProvisioningState>(),
                Tags = sdkProfile.Tags.ToHashTableTags(),
                Location = sdkProfile.Location,
                ResourceState = sdkProfile.ResourceState.Value.CastEnum<SdkProfileResourceState, PSProfileResourceState>(),

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
                ProvisioningState = sdkEndpoint.ProvisioningState.Value.CastEnum<SdkProvisioningState, PSProvisioningState>(),
                Tags = sdkEndpoint.Tags.ToHashTableTags(),
                Location = sdkEndpoint.Location,
                ResourceState = sdkEndpoint.ResourceState.Value.CastEnum<SdkEndpointResourceState, PSEndpointResourceState>(),

                // Entity specific properties
                HostName = sdkEndpoint.HostName,
                OriginHostHeader = sdkEndpoint.OriginHostHeader,
                OriginPath = sdkEndpoint.OriginPath,
                ContentTypesToCompress = sdkEndpoint.ContentTypesToCompress.ToArray(),
                IsCompressionEnabled = sdkEndpoint.IsCompressionEnabled.Value,
                IsHttpAllowed = sdkEndpoint.IsHttpAllowed.Value,
                IsHttpsAllowed = sdkEndpoint.IsHttpsAllowed.Value,
                QueryStringCachingBehavior = sdkEndpoint.QueryStringCachingBehavior.Value.CastEnum<SdkQueryStringCachingBehavior, PSQueryStringCachingBehavior>(),
                Origins = sdkEndpoint.Origins.Select(o => o.ToPsDeepCreatedOrigin()).ToList()
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
                Reason = validateCustomDomainOutput.Reason
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
                ProvisioningState = origin.ProvisioningState.Value.CastEnum<SdkProvisioningState, PSProvisioningState>(),
                ResourceState = origin.ResourceState.Value.CastEnum<SdkOriginResourceState, PSOriginResourceState>(),

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
                ProvisioningState = customDomain.ProvisioningState.Value.CastEnum<SdkProvisioningState, PSProvisioningState>(),
                ResourceState = customDomain.ResourceState.Value.CastEnum<SdkCustomDomainResourceState, PSCustomDomainResourceState>(),

                HostName = customDomain.HostName,
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
    }
}
