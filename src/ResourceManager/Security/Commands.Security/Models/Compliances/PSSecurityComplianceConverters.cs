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

namespace Microsoft.Azure.Commands.Security.Models.Compliances
{
    public static class PSSecurityComplianceConverters
    {
        public static PSSecurityCompliance ConvertToPSType(this Compliance value)
        {
            return new PSSecurityCompliance()
            {
                Id = value.Id,
                Name = value.Name,
                AssessmentTimestampUtcDate = value.AssessmentTimestampUtcDate.Value,
                ResourceCount = value.ResourceCount.Value,
                AssessmentResult = value.AssessmentResult.ConvertToPSType()
            };
        }

        public static List<PSSecurityCompliance> ConvertToPSType(this IEnumerable<Compliance> value)
        {
            return value.Select(compliance => compliance.ConvertToPSType()).ToList();
        }

        public static PSSecurityComplianceSegment ConvertToPSType(this ComplianceSegment value)
        {
            return new PSSecurityComplianceSegment()
            {
                Percentage = value.Percentage.Value,
                SegmentType = value.SegmentType
            };
        }

        public static List<PSSecurityComplianceSegment> ConvertToPSType(this IEnumerable<ComplianceSegment> value)
        {
            return value.Select(cs => cs.ConvertToPSType()).ToList();
        }
    }
}
