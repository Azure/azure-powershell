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

using Microsoft.Azure.Commands.Cdn.AfdModels.AfdCustomDomain;
using Microsoft.Azure.Commands.Cdn.AfdModels.AfdEndpoint;
using Microsoft.Azure.Commands.Cdn.AfdModels.AfdProfile;
using System.Collections.Generic;

using SdkAfdCustomDomain = Microsoft.Azure.Management.Cdn.Models.AFDDomain;
using SdkAfdEndpoint = Microsoft.Azure.Management.Cdn.Models.AFDEndpoint;
using SdkAfdProfile = Microsoft.Azure.Management.Cdn.Models.Profile;


namespace Microsoft.Azure.Commands.Cdn.AfdHelpers
{
    public static class AfdModelExtensions
    {
        public static PSAfdProfile ToPSAfdProfile(this SdkAfdProfile sdkAfdProfile)
        {
            return new PSAfdProfile
            {
                Id = sdkAfdProfile.Id,
                Name = sdkAfdProfile.Name,
                Type = sdkAfdProfile.Type,
                ProvisioningState = sdkAfdProfile.ProvisioningState,
                Location = sdkAfdProfile.Location,
                Tags = (Dictionary<string, string>)sdkAfdProfile.Tags,
                ResourceState = sdkAfdProfile.ResourceState,
                Sku = sdkAfdProfile.Sku.Name
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
                Tags = (Dictionary<string, string>)sdkAfdEndpoint.Tags,
                HostName = sdkAfdEndpoint.HostName,
                OriginResponseTimeoutSeconds = (int)sdkAfdEndpoint.OriginResponseTimeoutSeconds,
                EnabledState = sdkAfdEndpoint.EnabledState
            };
        }

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
    }
}
