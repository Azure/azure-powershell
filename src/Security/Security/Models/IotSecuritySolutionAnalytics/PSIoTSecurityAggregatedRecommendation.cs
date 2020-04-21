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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutionAnalytics
{
    public class PSIoTSecurityAggregatedRecommendation : PSResource
    {
        public string RecommendationName { get; set; }

        public string RecommendationDisplayName { get; set; }

        public string Description { get; set; }

        public string RecommendationTypeId { get; set; }

        public string DetectedBy { get; set; }

        public string RemediationSteps { get; set; }

        public string ReportedSeverity { get; set; }

        public long? HealthyDevices { get; set; }

        public long? UnhealthyDeviceCount { get; set; }

        public string LogAnalyticsQuery { get; set; }

        public IDictionary<string, string> Tags { get; set; }
    }
}
