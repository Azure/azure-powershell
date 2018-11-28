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
    /// Guest configuration assignment reort
    /// </summary>
    public class GuestConfigurationPolicyAssignmentReport
    {
        public GuestConfigurationPolicyAssignmentReport(GuestConfigurationAssignmentReport gcrpReport, GuestConfigurationPolicyAssignment gcPolicyAssignment)
        {
            if(gcPolicyAssignment != null)
            {
                this.PolicyDisplayName = gcPolicyAssignment.PolicyDisplayName;
                this.LatestReportId = gcrpReport.Id;
                this.Configuration = gcPolicyAssignment.Configuration;
            }

            if (gcrpReport.Properties != null)
            {
                this.ComplianceStatus = gcrpReport.Properties.ComplianceStatus;
            }

            this.ComplianceReasons = new List<ComplianceReasonDetails>();

            if (gcrpReport.Properties.Details != null)
            {
                foreach (var gcrpResource in gcrpReport.Properties.Details.Resources)
                {
                    if (gcrpResource == null)
                    {
                        continue;
                    }
                    var propertiesJObject = JObject.Parse(gcrpResource.Properties.ToString());

                    if (propertiesJObject == null)
                    {
                        continue;
                    }

                    var propertiesDictionary = propertiesJObject.ToObject<Dictionary<string, object>>();
                    string policy = null;
                    if (propertiesDictionary.ContainsKey(Constants.Policy))
                    {
                        policy = propertiesDictionary[Constants.Policy].ToString();
                    }

                    string resourceId = null;
                    if (propertiesDictionary.ContainsKey(Constants.ResourceId))
                    {
                        resourceId = propertiesDictionary[Constants.ResourceId].ToString();
                    }

                    var resourceReasons = new List<ReasonAndCode>();
                    foreach (var reason in gcrpResource.Reasons)
                    {
                        resourceReasons.Add(
                            new ReasonAndCode()
                            {
                                Reason = reason.Phrase,
                                Code = reason.Code,
                            }
                       );
                    }

                    var complianceReason = new ComplianceReasonDetails()
                    {
                        Policy = policy,
                        ResourceId = resourceId,
                        ComplianceStatus = gcrpResource.ComplianceStatus,
                        Reasons = resourceReasons,
                    };
                    this.ComplianceReasons.Add(complianceReason);
                }

                if(!string.IsNullOrEmpty(gcrpReport.Properties.Details.StartTime))
                {
                    this.StartTime = Convert.ToDateTime(gcrpReport.Properties.Details.StartTime);
                }

                if (!string.IsNullOrEmpty(gcrpReport.Properties.Details.EndTime))
                {
                    this.EndTime = Convert.ToDateTime(gcrpReport.Properties.Details.EndTime);
                }
            }

            if (gcrpReport.Properties.Vm != null)
            {
                this.VM = new VMInfo()
                {
                    Uuid = gcrpReport.Properties.Vm.Uuid,
                    ResourceId = gcrpReport.Properties.Vm.Id,
                };
            }
        }

        public string PolicyDisplayName { get; set; }

        public string ComplianceStatus { get; set; }

        public IList<ComplianceReasonDetails> ComplianceReasons { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string LatestReportId { get; set; }

        public VMInfo VM { get; set; }

        public GuestConfigurationPolicyAssignment.ConfigurationInfo Configuration { get; set; }

        public class ComplianceReasonDetails
        {
            public string Policy { get; set; }

            public string ResourceId { get; set; }

            public string ComplianceStatus { get; set; }

            public IList<ReasonAndCode> Reasons { get; set; }
        }

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