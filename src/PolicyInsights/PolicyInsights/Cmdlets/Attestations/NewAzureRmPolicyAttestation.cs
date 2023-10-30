﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.PolicyInsights.Common;
using Microsoft.Azure.Commands.PolicyInsights.Models.Attestations;
using Microsoft.Azure.Commands.PolicyInsights.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.PolicyInsights;
using Microsoft.Azure.Management.PolicyInsights.Models;

using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.PolicyInsights.Cmdlets.Attestations
{
    /// <summary>
    /// Creates a new Policy Attestation
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "PolicyAttestation", DefaultParameterSetName = ParameterSetNames.ByName, SupportsShouldProcess = true), OutputType(typeof(PSAttestation))]
    public class NewAzureRmPolicyAttestation : AttestationCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Scope)]
        public string Scope { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(ParameterSetName = ParameterSetNames.ByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.PolicyAssignmentId)]
        [ValidateNotNullOrEmpty]
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
                throw new AzPSArgumentException(Resources.Error_TooManyScopes, nameof(this.Scope));
            }
            Attestation existingAttestation = null;
            var rootScope = this.GetRootScope(scope: this.Scope, resourceId: this.ResourceId, resourceGroupName: this.ResourceGroupName);
            var attestationName = this.GetAttestationName(name: this.Name, resourceId: this.ResourceId);
            try
            {
                existingAttestation = this.PolicyInsightsClient.Attestations.GetAtResource(rootScope, attestationName);
            }
            catch
            {
                existingAttestation = null;
            }

            if (existingAttestation != null)
            {
                throw new AzPSArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.Error_AttestationAlreadyExists, attestationName, rootScope), attestationName);
            }

            var attestation = new Attestation(
                policyAssignmentId: this.PolicyAssignmentId,
                policyDefinitionReferenceId: this.PolicyDefinitionReferenceId,
                complianceState: ComplianceState,
                expiresOn: ExpiresOn,
                owner: Owner,
                evidence: Evidence?.Select(e => e.ToModel()).ToList(),
                comments: Comment,
                assessmentDate: AssessmentDate,
                metadata: this.Metadata == null ? null : this.ConvertToMetadataJObject(this.Metadata)
                );

            if (this.ShouldProcess(target: attestationName, action: String.Format(CultureInfo.InvariantCulture, Resources.CreatingAttestation, rootScope, attestationName)))
            {
                var result = this.PolicyInsightsClient.Attestations.CreateOrUpdateAtResource(resourceId: rootScope, attestationName: attestationName, parameters: attestation);

                WriteObject(new PSAttestation(result));
            }
        }
    }
}
