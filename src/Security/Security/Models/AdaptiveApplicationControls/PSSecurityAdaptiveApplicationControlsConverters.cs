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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveApplicationControls
{
    public static class PSSecurityAdaptiveApplicationControlsConverters
    {
        public static PSSecurityAdaptiveApplicationControls ConvertToPSType(this AdaptiveApplicationControlGroup value)
        {
            return new PSSecurityAdaptiveApplicationControls()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Properties = new PSSecurityAdaptiveApplicationControlsProperties()
                {
                    RecommendationStatus = value.RecommendationStatus,
                    EnforcementMode = value.EnforcementMode,
                    ProtectionMode = value.ProtectionMode.ConvertToPSType(),
                    VmRecommendations = value.VmRecommendations.ConvertToPSType(),
                    PathRecommendations = value.PathRecommendations.ConvertToPSType(),
                    ConfigurationStatus = value.ConfigurationStatus,
                    Issues = value.Issues.ConvertToPSType(),
                    SourceSystem = value.SourceSystem
                }
            };
        }


        public static List<PSSecurityAdaptiveApplicationControls> ConvertToPSType(this IEnumerable<AdaptiveApplicationControlGroup> value)
        {
            return value.Select(appWhitelistingGroup => appWhitelistingGroup.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveApplicationControlsIssueSummary ConvertToPSType(this AdaptiveApplicationControlIssueSummary value)
        {
            return new PSSecurityAdaptiveApplicationControlsIssueSummary()
            {
                Issue = value.Issue,
                NumberOfVms = value.NumberOfVms
            };
        }

        public static List<PSSecurityAdaptiveApplicationControlsIssueSummary> ConvertToPSType(this IEnumerable<AdaptiveApplicationControlIssueSummary> value)
        {
            return value.Select(issueSummary => issueSummary.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveApplicationControlsPathRecommendation ConvertToPSType(this PathRecommendation value)
        {
            return new PSSecurityAdaptiveApplicationControlsPathRecommendation()
            {
                Path = value.Path,
                Type = value.Type,
                PublisherInfo = value.PublisherInfo.ConvertToPSType(),
                Common = value.Common,
                Action = value.Action,
                Usernames = value.Usernames.ConvertToPSType(),
                UserSids = value.UserSids,
                FileType = value.FileType,
                ConfigurationStatus= value.ConfigurationStatus
            };
        }

        public static List<PSSecurityAdaptiveApplicationControlsPathRecommendation> ConvertToPSType(this IEnumerable<PathRecommendation> value)
        {
            return value.Select(pathRecommendation => pathRecommendation.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveApplicationControlsProtectionMode ConvertToPSType(this ProtectionMode value)
        {
            return new PSSecurityAdaptiveApplicationControlsProtectionMode()
            {
                Exe = value.Exe,
                Msi = value.Msi,
                Script = value.Script
            };
        }

        public static List<PSSecurityAdaptiveApplicationControlsProtectionMode> ConvertToPSType(this IEnumerable<ProtectionMode> value)
        {
            return value.Select(mode => mode.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveApplicationControlsPublisherInfo ConvertToPSType(this PublisherInfo value)
        {
            if (value != null)
            {
                return new PSSecurityAdaptiveApplicationControlsPublisherInfo()
                {
                    PublisherName = value.PublisherName,
                    ProductName = value.ProductName,
                    BinaryName = value.BinaryName,
                    Version = value.Version
                };
            }

            return null;
        }

        public static List<PSSecurityAdaptiveApplicationControlsPublisherInfo> ConvertToPSType(this IEnumerable<PublisherInfo> value)
        {
            return value.Select(publisherInfo => publisherInfo.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveApplicationControlsUserRecommendation ConvertToPSType(this UserRecommendation value)
        {
            return new PSSecurityAdaptiveApplicationControlsUserRecommendation()
            {
                Username = value.Username,
                RecommendationAction = value.RecommendationAction
            };
        }

        public static List<PSSecurityAdaptiveApplicationControlsUserRecommendation> ConvertToPSType(this IEnumerable<UserRecommendation> value)
        {
            return value.Select(userRecommendation => userRecommendation.ConvertToPSType()).ToList();
        }

        public static PSSecurityAdaptiveApplicationControlsVmRecommendation ConvertToPSType(this VmRecommendation value)
        {
            return new PSSecurityAdaptiveApplicationControlsVmRecommendation()
            {
                ConfigurationStatus = value.ConfigurationStatus,
                ResourceId = value.ResourceId,
                RecommendationAction = value.RecommendationAction,
                EnforcementSupport = value.EnforcementSupport,
            };
        }

        public static List<PSSecurityAdaptiveApplicationControlsVmRecommendation> ConvertToPSType(this IEnumerable<VmRecommendation> value)
        {
            return value.Select(vmRecommendation => vmRecommendation.ConvertToPSType()).ToList();
        }
    }
}
