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

using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Security.Models.Alerts
{
    public class PSSecurityAlert
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AlertDisplayName { get; set; }

        public string CompromisedEntity { get; set; }

        public string Description { get; set; }

        public List<PSSecurityAlertEntity> Entities { get; set; }

        public IDictionary<string,string> ExtendedProperties { get; set; }

        public List<string> RemediationSteps { get; set; }

        public string Severity { get; set; }

        public string Status { get; set; }

        public string VendorName { get; set; }

        public string CorrelationKey { get; set; }
        
        public bool? IsIncident { get; set; }
        
        public string ProductName { get; set; }
        
        public DateTime? TimeGeneratedUtc { get; set; }
        public string AlertUri { get; set; }
        
        public List<IDictionary<string, string>> ExtendedLinks { get; set; }
        
        public List<ResourceIdentifier> ResourceIdentifiers { get; set; }
        
        public string Intent { get; set; }
        
        public string ProductComponentName { get; set; }

        public string SystemAlertId { get; set; }

        public string AlertType { get; set; }

        public DateTime? ProcessingEndTimeUtc { get; set; }

        public DateTime? EndTimeUtc { get; set; }

        public DateTime? StartTimeUtc { get; set; }
    }
}
