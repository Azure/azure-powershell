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

namespace Microsoft.Azure.Commands.GuestConfiguration.Models
{
    using System;
    using Microsoft.Azure.Management.GuestConfiguration.Models;

    // Contains data from Azure policy and guest configuration assignment from Guest Configuration service
    public class PolicyData
    {
        public PolicyData(GuestConfigurationAssignment gcrpAssignment, string policyDisplayName)
        {
            this.PolicyDisplayName = policyDisplayName;
            this.ComplianceStatus = gcrpAssignment.Properties.ComplianceStatus;
            this.Configuration = new ConfigurationInfo()
            {
                Name = gcrpAssignment.Properties.GuestConfiguration.Name,
                Version = gcrpAssignment.Properties.GuestConfiguration.Version,
            };
            this.LatestReportId = gcrpAssignment.Properties.LatestReportId;
            if (gcrpAssignment.Properties.LastComplianceStatusChecked != null)
            {
                this.LastUpdated = Convert.ToDateTime(gcrpAssignment.Properties.LastComplianceStatusChecked);
            }
        }

        public PolicyData()
        {

        }

        public ConfigurationInfo Configuration;
  
        public string PolicyDisplayName { get; set; }

        public string ComplianceStatus { get; set; }

        public string LatestReportId { get; set; }

        public DateTime? LastUpdated { get; set; }

        public class ConfigurationInfo
        {
            public string Name { get; set; }

            public string Version { get; set; }
        }
    }
}
