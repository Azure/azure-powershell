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

namespace Microsoft.Azure.Commands.Security.Models.Assessments
{
    public static class PSSecurityAssessmentConverters
    {
        public static PSSecurityAssessment ConvertToPSType(this SecurityAssessment value)
        {
            return new PSSecurityAssessment()
            {
                Id = value.Id,
                Name = value.Name,
                DisplayName = value.DisplayName,
                ResourceDetails = value.ResourceDetails.ConvertToPSType(),
                Status = value.Status.ConvertToPSType()
            };
        }

        public static PSSecurityResourceDetails ConvertToPSType(this ResourceDetails value)
        {
            if (value is AzureResourceDetails details)
            {
                return new PSSecurityAzureResourceDetails()
                {
                    Source = "Azure",
                    Id = details.Id
                };
            }

            return new PSSecurityResourceDetails()
            {
                Source = "Unknown"
            };
        }

        public static PSSecurityAssessmentStatus ConvertToPSType(this AssessmentStatus value)
        {
            return new PSSecurityAssessmentStatus()
            {
                Code = value.Code,
                Cause = value.Cause,
                Description = value.Description
            };
        }

        public static List<PSSecurityAssessment> ConvertToPSType(this IEnumerable<SecurityAssessment> value)
        {
            return value.Select(obj => obj.ConvertToPSType()).ToList();
        }
    }
}
