﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Security.Models.AssessmentMetadata
{
    public static class PSSecurityAssessmentMetadataConverters
    {
        public static PSSecurityAssessmentMetadata ConvertToPSType(this SecurityAssessmentMetadata value)
        {
            return new PSSecurityAssessmentMetadata()
            {
                Id = value.Id,
                Name = value.Name,
                AssessmentType = value.AssessmentType,
                Description = value.Description,
                DisplayName = value.DisplayName,
                PolicyDefinitionId = value.PolicyDefinitionId,
                RemediationDescription = value.RemediationDescription,
                Severity = value.Severity
            };
        }

        public static List<PSSecurityAssessmentMetadata> ConvertToPSType(this IEnumerable<SecurityAssessmentMetadata> value)
        {
            return value.Select(sc => sc.ConvertToPSType()).ToList();
        }
    }
}
