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

using Azure.Core;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.PolicyInsights.Common;
using Microsoft.Azure.Commands.PolicyInsights.Models.Attestations;
using Microsoft.Azure.Commands.PolicyInsights.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.Azure.Management.PolicyInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets.Attestations
{
    /// <summary>
    /// Updates a policy attestation.
    /// </summary>
    [Cmdlet(verbName: VerbsCommon.Set, AzureRMConstants.AzureRMPrefix + "PolicyAttestation", DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(PSAttestation))]
    public class SetAzureRmPolicyAttestation : AttestationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, HelpMessage = ParameterHelpMessages.Scope)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AttestationObject)]
        [ValidateNotNull]
        public PSAttestation InputObject { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyAssignmentId)]
        public string PolicyAssignmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ComplianceState)]
        [PSArgumentCompleter("Compliant", "NonCompliant", "Unknown")]
        public string ComplianceState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyDefinitionReferenceId)]
        public string PolicyDefinitionReferenceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ExpiresOn)]
        public DateTime? ExpiresOn { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Owner)]
        public string Owner { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Comment)]
        public string Comment { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Evidence)]
        public PSAttestationEvidence[] Evidence { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AssessmentDate)]
        public DateTime? AssessmentDate { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.AttestationMetadata)]
        public string Metadata { get; set; }

        public override void Execute()
        {
            if (!string.IsNullOrEmpty(this.Name) && new[] { this.Scope, this.ResourceGroupName }.Count(s => s != null) > 1)
            {
                throw new AzPSArgumentException(Resources.Error_TooManyScopes, nameof(Scope));
            }
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceId = this.InputObject.Id;
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.Name;
                this.PolicyAssignmentId = this.IsParameterBound(c => c.PolicyAssignmentId) ? this.PolicyAssignmentId : this.InputObject?.PolicyAssignmentId;
                this.PolicyDefinitionReferenceId = this.IsParameterBound(c => c.PolicyDefinitionReferenceId) ? this.PolicyDefinitionReferenceId : this.InputObject?.PolicyDefinitionReferenceId;
                this.ComplianceState = this.IsParameterBound(c => c.ComplianceState) ? this.ComplianceState : this.InputObject?.ComplianceState;
                this.ExpiresOn = this.IsParameterBound(c => c.ExpiresOn) ? this.ExpiresOn : this.InputObject?.ExpiresOn;
                this.Owner = this.IsParameterBound(c => c.Owner) ? this.Owner : this.InputObject?.Owner;
                this.Comment = this.IsParameterBound(c => c.Comment) ? this.Comment : this.InputObject?.Comment;
                this.Evidence = this.IsParameterBound(c => c.Evidence) ? this.Evidence : this.InputObject?.Evidence;
                this.AssessmentDate = this.IsParameterBound(c => c.AssessmentDate) ? this.AssessmentDate : this.InputObject?.AssessmentDate;
                this.Metadata = this.IsParameterBound(c => c.Metadata) ? this.Metadata : this.InputObject?.Metadata?.ToString();
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.Name;
            }

            Attestation existingAttestation = null;
            var rootScope = this.GetRootScope(scope: this.Scope, resourceId: this.ResourceId, resourceGroupName: this.ResourceGroupName, inputObject: InputObject);
            var attestationName = this.GetAttestationName(name: this.Name, resourceId: this.ResourceId, inputObject: this.InputObject);
            try
            {
                existingAttestation = this.PolicyInsightsClient.Attestations.GetAtResource(rootScope, attestationName);
            }
            catch
            {
                existingAttestation = null;
            }

            if (existingAttestation == null)
            {
                throw new AzPSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.Error_AttestationDoesNotExists, attestationName, rootScope), attestationName);
            }

            existingAttestation.PolicyAssignmentId = this.PolicyAssignmentId ?? existingAttestation.PolicyAssignmentId;
            existingAttestation.PolicyDefinitionReferenceId = this.PolicyDefinitionReferenceId;
            existingAttestation.ComplianceState = this.ComplianceState;
            existingAttestation.ExpiresOn = this.ExpiresOn;
            existingAttestation.Comments = this.Comment;
            existingAttestation.Evidence = this.Evidence?.Select((e) => e.ToModel()).ToList();
            existingAttestation.Owner = this.Owner;
            existingAttestation.AssessmentDate = this.AssessmentDate;
            existingAttestation.Metadata = this.Metadata == null ? null : this.ConvertToMetadataJObject(this.Metadata);

            if (this.ShouldProcess(target: attestationName, action: String.Format(CultureInfo.InvariantCulture, Resources.UpdatingAttestation, rootScope, attestationName)))
            {
                var result = this.PolicyInsightsClient.Attestations.CreateOrUpdateAtResource(resourceId: rootScope, attestationName: attestationName, parameters: existingAttestation);

                WriteObject(new PSAttestation(result));
            }

        }
    }
}
