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
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    using Microsoft.Azure.Commands.GuestConfiguration.Common;
    using Microsoft.Azure.Management.GuestConfiguration.Models;

    /// <summary>
    /// Guest configuration assignment
    /// </summary>
    public class PolicyStatus
    {
        public PolicyStatus(GuestConfigurationAssignmentReport gcrpReport, PolicyData gcPolicyAssignment)
        {
            if (gcPolicyAssignment != null)
            {
                this.PolicyDisplayName = gcPolicyAssignment.PolicyDisplayName;
                this.Configuration = gcPolicyAssignment.Configuration;
                this.ComplianceStatus = gcPolicyAssignment.ComplianceStatus; // Initially, gcrpReport can be null. So use status from assignment.
            }

            if (gcrpReport != null && gcrpReport.Properties != null)
            {
                this.ReportId = gcrpReport.Id;
                this.StartTime = gcrpReport.Properties.StartTime;
                this.EndTime = gcrpReport.Properties.EndTime;
                this.ComplianceStatus = gcrpReport.Properties.ComplianceStatus;
                this.Configuration = new PolicyData.ConfigurationInfo
                {
                    Name = gcrpReport.Properties.Assignment.Configuration.Name,
                    Version = gcrpReport.Properties.Assignment.Configuration.Version
                };

                if (gcrpReport.Properties.Vm != null)
                {
                    this.VM = new VMInfo()
                    {
                        Uuid = gcrpReport.Properties.Vm.Uuid,
                        ResourceId = gcrpReport.Properties.Vm.Id,
                    };
                }
            }
        }

        public string PolicyDisplayName { get; set; }

        public string ComplianceStatus { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string ReportId { get; set; }

        public VMInfo VM { get; set; }

        public PolicyData.ConfigurationInfo Configuration { get; set; }

        public class VMInfo
        {
            public string Uuid { get; set; }

            public string ResourceId { get; set; }
        }

        public class ReasonAndCode
        {
            public string Reason;

            public string Code;
        }
    }
}