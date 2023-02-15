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

namespace Microsoft.Azure.Commands.Security.Models.SolutionsReferenceData
{
    public static class PSSecuritySolutionReferenceDataConverters
    {
        public static PSSolutionReferenceData ConvertToPSType(this SecuritySolutionsReferenceData value)
        {
            return new PSSolutionReferenceData()
            {
                Id = value.Id,
                Name = value.Name,
                template = value.Template,
                SecurityFamily = value.SecurityFamily
            };
        }

        public static List<PSSolutionReferenceData> ConvertToPSType(this IEnumerable<SecuritySolutionsReferenceData> value)
        {
            return value.Select(solution => solution.ConvertToPSType()).ToList();
        }
    }
}