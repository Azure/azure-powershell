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

namespace Microsoft.Azure.Commands.SecurityInsights.Models.IncidentComments
{
    public static class PSSentinelIncidentCommentConvertors
    {

        public static PSSentinelIncidentComment ConvertToPSType(this IncidentComment value)
        {
            return new PSSentinelIncidentComment()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Author = value.Author.ConvertToPSType(),
                CreatedTimeUtc = value.CreatedTimeUtc,
                Message = value.Message
            };
        }

        public static List<PSSentinelIncidentComment> ConvertToPSType(this IEnumerable<IncidentComment> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelIncidentCommentAuthor ConvertToPSType(this ClientInfo value)
        {
            return new PSSentinelIncidentCommentAuthor()
            {
                Email = value.Email,
                Name = value.Name,
                ObjectId = value.ObjectId,
                UserPrincipalName = value.UserPrincipalName
            };
        }

    }
}
