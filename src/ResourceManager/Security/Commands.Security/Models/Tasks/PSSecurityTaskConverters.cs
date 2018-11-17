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

namespace Microsoft.Azure.Commands.Security.Models.Tasks
{
    public static class PSSecurityTaskConverters
    {
        public static PSSecurityTask ConvertToPSType(this SecurityTask value)
        {
            return new PSSecurityTask()
            {
                Id = value.Id,
                Name = value.Name,
                ResourceId = value.SecurityTaskParameters.AdditionalProperties["resourceId"].ToString(),
                RecommendationType = value.SecurityTaskParameters.Name != "GenericSecuirtyTask" ? value.SecurityTaskParameters.Name : value.SecurityTaskParameters.AdditionalProperties["policyName"].ToString()
            };
        }

        public static List<PSSecurityTask> ConvertToPSType(this IEnumerable<SecurityTask> value)
        {
            return value.Select(task => task.ConvertToPSType()).ToList();
        }
    }
}
