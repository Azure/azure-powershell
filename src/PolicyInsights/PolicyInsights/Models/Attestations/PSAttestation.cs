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

namespace Microsoft.Azure.Commands.PolicyInsights.Models.Attestations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.PolicyInsights.Models.Attestations;
    using Microsoft.Azure.Management.PolicyInsights.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///
    /// </summary>
    public class PSAttestation{

        /// <summary>
        /// Gets fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the resource
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of the resource. E.g.
        /// "Microsoft.Compute/virtualMachines" or
        /// "Microsoft.Storage/storageAccounts"
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets or sets the resource ID of the policy assignment that the
        /// attestation is setting the state for.
        /// </summary>
        public string PolicyAssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the policy definition reference ID from a policy set
        /// definition that the attestation is setting the state for. If the
        /// policy assignment assigns a policy set definition the attestation
        /// can choose a definition within the set definition with this
        /// property or omit this and set the state for the entire set
        /// definition.
        /// </summary>
        public string PolicyDefinitionReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the compliance state that should be set on the
        /// resource. Possible values include: 'Compliant', 'NonCompliant',
        /// 'Unknown'
        /// </summary>
        public string ComplianceState { get; set; }

        /// <summary>
        /// Gets or sets the time the compliance state should expire.
        /// </summary>
        public System.DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the person responsible for setting the state of the
        /// resource. This value is typically an Azure Active Directory object
        /// ID.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets comments describing why this attestation was created.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the evidence supporting the compliance state set in
        /// this attestation.
        /// </summary>
        public PSAttestationEvidence[] Evidence { get; set; }

        /// <summary>
        /// Gets the status of the attestation.
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets the time the compliance state was last changed in this
        /// attestation.
        /// </summary>
        public System.DateTime? LastComplianceStateChangeAt { get; private set; }

        /// <summary>
        /// Gets or sets the time the evidence was assessed
        /// </summary>
        public System.DateTime? AssessmentDate { get; set; }

        /// <summary>
        /// Gets or sets additional metadata for this attestation
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets azure Resource Manager metadata containing createdBy and
        /// modifiedBy information.
        /// </summary>
        public SystemData SystemData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attestation"></param>
        public PSAttestation(Attestation attestation)
        {
            if(attestation == null)
            {
                return;
            }
            this.Id = attestation.Id;
            this.Name = attestation.Name;
            this.Type = attestation.Type;
            this.ProvisioningState = attestation.ProvisioningState;
            this.PolicyAssignmentId = attestation.PolicyAssignmentId;
            this.PolicyDefinitionReferenceId = attestation.PolicyDefinitionReferenceId;
            this.ComplianceState = attestation.ComplianceState;
            this.ExpiresOn = attestation.ExpiresOn;
            this.Owner = attestation.Owner;
            this.Comment = attestation.Comments;
            this.Metadata = attestation.Metadata != null? attestation.Metadata.ToString(): null;
            this.LastComplianceStateChangeAt = attestation.LastComplianceStateChangeAt;
            this.AssessmentDate = attestation.AssessmentDate;
            this.Evidence = attestation.Evidence?.Select(evidence => new PSAttestationEvidence(evidence)).ToArray();
        }
    }

}