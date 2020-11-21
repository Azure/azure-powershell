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

namespace Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks
{
    public static class PSSentinelBookmarkConvertors
    {

        public static PSSentinelBookmark ConvertToPSType(this Bookmark value)
        {
            return new PSSentinelBookmark()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Created = value.Created,
                CreatedBy = value.CreatedBy.ConvertToPSType(),
                DisplayName = value.DisplayName,
                IncidentInfo = value.IncidentInfo.ConvertToPSType(),
                Labels = value.Labels,
                Notes = value.Notes,
                Query = value.Query,
                QueryResult = value.QueryResult,
                Updated = value.Updated,
                UpdatedBy = value.UpdatedBy.ConvertToPSType()
            };
        }

        public static List<PSSentinelBookmark> ConvertToPSType(this IEnumerable<Bookmark> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelBookmarkUserInfo ConvertToPSType(this UserInfo value)
        {
            return new PSSentinelBookmarkUserInfo()
            {
                Email = value.Email,
                ObjectId = value.ObjectId,
                Name = value.Name
            };
        }

        public static List<PSSentinelBookmarkUserInfo> ConvertToPSType(this IEnumerable<UserInfo> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelBookmarkIncidentInfo ConvertToPSType(this IncidentInfo value)
        {
            return new PSSentinelBookmarkIncidentInfo()
            {
                IncidentId = value.IncidentId,
                RelationName = value.RelationName,
                Severity = value.Severity,
                Title = value.Title
            };
        }

        public static IncidentInfo CreatePSType(this PSSentinelBookmarkIncidentInfo value)
        {
            return new IncidentInfo()
            {
                IncidentId = value.IncidentId,
                RelationName = value.RelationName,
                Severity = value.Severity,
                Title = value.Title
            };
        }

        public static List<IncidentInfo> CreatePSType(this IEnumerable<PSSentinelBookmarkIncidentInfo> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }
    }
}
