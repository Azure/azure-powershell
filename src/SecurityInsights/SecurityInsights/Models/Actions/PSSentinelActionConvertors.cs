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
using Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.Actions
{
    public static class PSSentinelActionConvertors
    {

        public static PSSentinelAction ConvertToPSType(this ActionResponse value)
        {
            return new PSSentinelAction()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                LogicAppResourceId = value.LogicAppResourceId,
                WorkflowId = value.WorkflowId
            };
        }

        public static List<PSSentinelAction> ConvertToPSType(this IEnumerable<ActionResponse> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
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
