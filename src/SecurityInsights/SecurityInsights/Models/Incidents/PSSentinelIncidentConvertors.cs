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

using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.Incidents
{
    public static class PSSentinelIncidentConvertors
    {

        public static PSSentinelIncident ConvertToPSType(this Incident value)
        {
            return new PSSentinelIncident()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                AdditonalData = value.AdditionalData.ConvertToPSType(),
                Classification = value.Classification,
                ClassificationComment = value.ClassificationComment,
                ClassificationReason = value.ClassificationReason,
                CreatedTimeUTC = value.CreatedTimeUtc,
                Description = value.Description,
                FirstActivityTimeUtc = value.FirstActivityTimeUtc,
                IncidentNumber = value.IncidentNumber,
                IncidentUrl = value.IncidentUrl,
                Labels = value.Labels.ConvertToPSType(),
                LastActivityTimeUtc = value.LastActivityTimeUtc,
                LastModifiedTimeUtc = value.LastModifiedTimeUtc,
                Owner = value.Owner.ConvertToPSType(),
                Severity = value.Severity,
                Status = value.Status,
                Title = value.Title
            };
        }

        public static List<PSSentinelIncident> ConvertToPSType(this IEnumerable<Incident> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelIncidentAdditionalData ConvertToPSType(this IncidentAdditionalData value)
        {
            return new PSSentinelIncidentAdditionalData()
            {
                AlertProductNames = value.AlertProductNames,
                AlertsCount = value.AlertsCount,
                BookmarksCount = value.BookmarksCount,
                CommentsCount = value.CommentsCount,
                Tactics = value.Tactics
            };
        }

        public static List<PSSentinelIncidentAdditionalData> ConvertToPSType(this IEnumerable<IncidentAdditionalData> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }
        
        public static PSSentinelIncidentLabel ConvertToPSType(this IncidentLabel value)
        {
            return new PSSentinelIncidentLabel()
            {
                LabelName = value.LabelName,
                LabelType = value.LabelType
            };
        }

        public static List<PSSentinelIncidentLabel> ConvertToPSType(this IEnumerable<IncidentLabel> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelIncidentOwner ConvertToPSType(this IncidentOwnerInfo value)
        {
            return new PSSentinelIncidentOwner()
            {
                AssignedTo = value.AssignedTo,
                Email = value.Email,
                ObjectId = value.ObjectId,
                UserPrincipalName = value.UserPrincipalName
            };
        }

        public static List<PSSentinelIncidentOwner> ConvertToPSType(this IEnumerable<IncidentOwnerInfo> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }


        public static IncidentLabel CreatePSType(this PSSentinelIncidentLabel value)
        {
            return new IncidentLabel()
            {
                LabelName = value.LabelName
            };
        }

        public static List<IncidentLabel> CreatePSType(this IEnumerable<PSSentinelIncidentLabel> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }

        public static IncidentOwnerInfo CreatePSType(this PSSentinelIncidentOwner value)
        {
            return new IncidentOwnerInfo()
            {
                AssignedTo = value.AssignedTo,
                Email = value.Email,
                ObjectId = value.ObjectId,
                UserPrincipalName = value.UserPrincipalName
            };
        }

        public static List<IncidentOwnerInfo> CreatePSType(this IEnumerable<PSSentinelIncidentOwner> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }

    }
}
