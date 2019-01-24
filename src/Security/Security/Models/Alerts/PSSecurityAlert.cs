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

namespace Microsoft.Azure.Commands.Security.Models.Alerts
{
    public class PSSecurityAlert
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ActionTaken { get; set; }

        public string AlertDisplayName { get; set; }

        public string AlertName { get; set; }

        public string AssociatedResource { get; set; }

        public bool? CanBeInvestigated { get; set; }

        public string CompromisedEntity { get; set; }

        public List<PSSecurityAlertConfidenceReason> ConfidenceReasons { get; set; }

        public double? ConfidenceScore { get; set; }

        public string Description { get; set; }

        public DateTime? DetectedTimeUtc { get; set; }

        public List<PSSecurityAlertEntity> Entities { get; set; }

        public IDictionary<string,object> ExtendedProperties { get; set; }

        public string InstanceId { get; set; }

        public string RemediationSteps { get; set; }

        public string ReportedSeverity { get; set; }

        public DateTime? ReportedTimeUtc { get; set; }

        public string State { get; set; }

        public string SubscriptionId { get; set; }

        public string SystemSource { get; set; }

        public string VendorName { get; set; }

        public string WorkspaceArmId { get; set; }
    }
}
