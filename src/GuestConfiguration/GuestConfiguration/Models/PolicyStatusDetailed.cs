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
    public class PolicyStatusDetailed : PolicyStatus
    {
        public PolicyStatusDetailed(GuestConfigurationAssignmentReport gcrpReport, PolicyData gcPolicyAssignment) : base(gcrpReport, gcPolicyAssignment)
        {
            this.ComplianceReasons = new List<ComplianceReasonDetails>();

            if (gcrpReport != null && gcrpReport.Properties != null )
            {
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
                }
            }   
        }

        public IList<ComplianceReasonDetails> ComplianceReasons { get; set; }

        public class ComplianceReasonDetails
        {
            public string Policy { get; set; }

            public string ResourceId { get; set; }

            public string ComplianceStatus { get; set; }

            public IList<ReasonAndCode> Reasons { get; set; }
        }
    }
}