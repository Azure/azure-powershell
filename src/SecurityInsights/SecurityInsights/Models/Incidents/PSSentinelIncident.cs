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

namespace Microsoft.Azure.Commands.SecurityInsights.Models.Incidents
{
    public class PSSentinelIncident
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public PSSentinelIncidentAdditionalData AdditonalData { get; set; }

        public string Classification { get; set; }

        public string ClassificationComment { get; set; }
        
        public string ClassificationReason { get; set; }

        public DateTime? CreatedTimeUTC { get; set; }

        public string Description { get; set; }

        public DateTime? FirstActivityTimeUtc { get; set; }

        public int? IncidentNumber { get; set; }

        public string IncidentUrl { get; set; }

        public IList<PSSentinelIncidentLabel> Labels { get; set; }

        public DateTime? LastActivityTimeUtc { get; set; }

        public DateTime? LastModifiedTimeUtc { get; set; }

        public PSSentinelIncidentOwner Owner { get; set; }

        public string Severity { get; set; }

        public string Status { get; set; }

        public string Title { get; set; }
    }
}
