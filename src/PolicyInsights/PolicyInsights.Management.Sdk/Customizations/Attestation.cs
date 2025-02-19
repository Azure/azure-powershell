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

namespace Microsoft.Azure.Management.PolicyInsights.Models
{
    public partial class Attestation : Resource
    {
        public Attestation(string policyAssignmentId, string id = default(string), string name = default(string), string type = default(string), string policyDefinitionReferenceId = default(string), string complianceState = default(string), System.DateTime? expiresOn = default(System.DateTime?), string owner = default(string), string comments = default(string), IList<AttestationEvidence> evidence = default(IList<AttestationEvidence>), string provisioningState = default(string), System.DateTime? lastComplianceStateChangeAt = default(System.DateTime?), SystemData systemData = default(SystemData))
            : base(id, name, type)
        {
            PolicyAssignmentId = policyAssignmentId;
            PolicyDefinitionReferenceId = policyDefinitionReferenceId;
            ComplianceState = complianceState;
            ExpiresOn = expiresOn;
            Owner = owner;
            Comments = comments;
            Evidence = evidence;
            ProvisioningState = provisioningState;
            LastComplianceStateChangeAt = lastComplianceStateChangeAt;
            SystemData = systemData;
            CustomInit();
        }
    }
}