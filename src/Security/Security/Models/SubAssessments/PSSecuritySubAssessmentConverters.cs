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
using Microsoft.Azure.Commands.Security.Models.Assessments;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.SubAssessments
{
    public static class PSSecuritySubAssessmentConverters
    {
        public static PSSecuritySubAssessment ConvertToPSType(this SecuritySubAssessment value)
        {
            return new PSSecuritySubAssessment()
            {
                Id = value.Id,
                Name = value.Name,
                Impact = value.Impact,
                Remediation = value.Remediation,
                ResourceDetails = value.ResourceDetails.ConvertToPSType(),
                Status = value.Status.ConvertToPSType(),
                SecuritySubAssessmentId = value.SecuritySubAssessmentId,
                TimeGenerated = value.TimeGenerated
            };
        }

        public static PSSecuritySubAssessmentStatus ConvertToPSType(this SubAssessmentStatus value)
        {
            return new PSSecuritySubAssessmentStatus()
            {
                Code = value.Code,
                Cause = value.Cause,
                Description = value.Description,
                Severity = value.Severity
            };
        }

        public static List<PSSecuritySubAssessment> ConvertToPSType(this IEnumerable<SecuritySubAssessment> value)
        {
            return value.Select(obj => obj.ConvertToPSType()).ToList();
        }
    }
}
