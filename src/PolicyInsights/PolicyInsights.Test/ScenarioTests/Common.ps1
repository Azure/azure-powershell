# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Gets test management group name
#>
function Get-TestManagementGroupName {
   # should be a parent of the test subscription
   "AzGovPerfTest"
}

<#
.SYNOPSIS
Gets test subscription ID.
#>
function Get-TestSubscriptionId {
   # Reminder: The subscription ID in the test context (created via PS command or by creating an env variable) should be the same as this subscription ID.
   "086aecf4-23d6-4dfd-99a8-a5c6299f0322" # This is the Azure Governance Perf 21 subscription
}

<#
.SYNOPSIS
Gets test resource group group name
#>
function Get-FirstTestResourceGroupName {
   "PSTestRG1"
}

<#
.SYNOPSIS
Gets test resource group group name
#>
function Get-SecondTestResourceGroupName {
   "PSTestRG2"
}

<#
.SYNOPSIS
Gets empty test resource group group name
#>
function Get-EmptyTestResourceGroupName {
   "PSTestEmptyRG"
}

<#
.SYNOPSIS
Gets test resource name prefix
#>
function Get-TestResourceNamePrefix {
   "pstests"
}

<#
.SYNOPSIS
Gets test resource id
#>
function Get-TestResourceId {
   "/subscriptions/$(Get-TestSubscriptionId)/resourceGroups/$(Get-FirstTestResourceGroupName)/providers/Microsoft.Network/networkSecurityGroups/$(Get-TestResourceNamePrefix)1"
}

<#
.SYNOPSIS
Gets test modify policy definition name
#>
function Get-TestModifyPolicyDefinitionName {
   "PSTestModifyDefinition"
}

<#
.SYNOPSIS
Gets test DINE policy definition name
#>
function Get-TestDINEPolicyDefinitionName {
   "PSTestDINEDefinition"
}

<#
.SYNOPSIS
Gets test audit policy definition name
#>
function Get-TestAuditPolicyDefinitionName {
   "PSTestAuditDefinition"
}

<#
.SYNOPSIS
Gets test set definition name
#>
function Get-TestPolicySetDefinitionName {
   "PSTestInitiative"
}

<#
.SYNOPSIS
Gets test DINE assignment name (subscription level)
#>
function Get-TestSubscriptionDINEAssignmentName {
   "PSTestDeployAssignmentSub"
}

<#
.SYNOPSIS
Gets the policy assignment used in remediation tests at subscription level and below
#>
function Get-TestRemediationSubscriptionPolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestSubscriptionDINEAssignmentName)"
}

<#
.SYNOPSIS
Gets test DINE assignment name (MG level)
#>
function Get-TestManagementGroupDINEAssignmentName {
   "PSTestDeployAssignmentMG"
}

<#
.SYNOPSIS
Gets the policy assignment used in remediation tests at management group scope
#>
function Get-TestRemediationMgPolicyAssignmentId {
   "/providers/Microsoft.Management/managementGroups/$(Get-TestManagementGroupName)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestManagementGroupDINEAssignmentName)"
}

<#
.SYNOPSIS
Gets test modify assignment name (subscription level)
#>
function Get-TestSubscriptionModifyAssignmentName {
   "PSTestModifyAssignmentSub"
}

<#
.SYNOPSIS
Gets the policy assignment used in remediation tests at subscription level and below
#>
function Get-TestRemediationSubscriptionModifyPolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestSubscriptionModifyAssignmentName)"
}

<#
.SYNOPSIS
Gets test audit assignment name (subscription level)
#>
function Get-TestSubscriptionAuditAssignmentName {
   "PSTestAuditAssignmentSub"
}

<#
.SYNOPSIS
Gets test audit assignment name (RG level)
#>
function Get-TestResourceGroupAuditAssignmentName {
   "PSTestAuditAssignmentRG"
}

<#
.SYNOPSIS
Gets test audit assignment name (subscription level)
#>
function Get-TestSubscriptionAuditInitiativeAssignmentName {
   "PSTestAuditInitiativeAssignmentSub"
}

<#
.SYNOPSIS
Gets test query interval start
#>
function Get-TestQueryIntervalStart {
   "2022-01-08 00:00:00Z"
}

<#
.SYNOPSIS
Gets test query interval end
#>
function Get-TestQueryIntervalEnd {
   "2022-01-13 02:00:00Z"
}

<#
.SYNOPSIS
Validates a list of policy events
#>
function Validate-PolicyEvents {
   param([System.Collections.Generic.List`1[[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent]]]$policyEvents, [int]$count)

   Assert-True { $count -ge $policyEvents.Count }
   Assert-True { $policyEvents.Count -gt 0 }
   Foreach ($policyEvent in $policyEvents) {
      Validate-PolicyEvent $policyEvent
   }
}

<#
.SYNOPSIS
Validates a policy event
#>
function Validate-PolicyEvent {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.PolicyEvent]$policyEvent)

   Assert-NotNull $policyEvent

   Assert-NotNull $policyEvent.Timestamp
   Assert-NotNullOrEmpty $policyEvent.ResourceId
   Assert-NotNullOrEmpty $policyEvent.PolicyAssignmentId
   Assert-NotNullOrEmpty $policyEvent.PolicyDefinitionId
   Assert-NotNull $policyEvent.IsCompliant
   Assert-NotNullOrEmpty $policyEvent.SubscriptionId
   Assert-NotNullOrEmpty $policyEvent.PolicyDefinitionAction
   Assert-NotNullOrEmpty $policyEvent.TenantId
   Assert-NotNullOrEmpty $policyEvent.PrincipalOid
}

<#
.SYNOPSIS
Validates a list of policy states
#>
function Validate-PolicyStates {
   param(
      [System.Collections.Generic.List`1[[Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]]]$policyStates,
      [int]$count,
      [switch]$expandPolicyEvaluationDetails = $false)

   Assert-True { $count -ge $policyStates.Count }
   Assert-True { $policyStates.Count -gt 0 }
   Foreach ($policyState in $policyStates) {
      Validate-PolicyState $policyState -expandPolicyEvaluationDetails:$expandPolicyEvaluationDetails
   }
}

<#
.SYNOPSIS
Validates a policy state
#>
function Validate-PolicyState {
   param(
      [Microsoft.Azure.Commands.PolicyInsights.Models.PolicyState]$policyState,
      [switch]$expandPolicyEvaluationDetails = $false)

   Assert-NotNull $policyState

   Assert-NotNull $policyState.Timestamp
   Assert-NotNullOrEmpty $policyState.ResourceId
   Assert-NotNullOrEmpty $policyState.PolicyAssignmentId
   Assert-NotNullOrEmpty $policyState.PolicyDefinitionId
   Assert-NotNull $policyState.IsCompliant
   Assert-NotNullOrEmpty $policyState.SubscriptionId
   Assert-NotNullOrEmpty $policyState.PolicyDefinitionAction
   Assert-NotNullOrEmpty $policyState.ComplianceState

   if ($expandPolicyEvaluationDetails -and $policyState.ComplianceState -eq "NonCompliant") {
      Assert-NotNull $policyState.PolicyEvaluationDetails
   }
   else {
      Assert-Null $policyState.PolicyEvaluationDetails
   }
}

<#
.SYNOPSIS
Validates a policy state summary
#>
function Validate-PolicyStateSummary {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.PolicyStateSummary]$policyStateSummary)

   Assert-NotNull $policyStateSummary

   Assert-NotNull $policyStateSummary.Results
   Assert-NotNull $policyStateSummary.Results.NonCompliantResources
   Assert-NotNull $policyStateSummary.Results.NonCompliantPolicies

   Assert-NotNull $policyStateSummary.PolicyAssignments
   Assert-True { $policyStateSummary.PolicyAssignments.Count -gt 0 }

   Foreach ($policyAssignmentSummary in $policyStateSummary.PolicyAssignments) {
      Assert-NotNull $policyAssignmentSummary

      Assert-NotNullOrEmpty $policyAssignmentSummary.PolicyAssignmentId

      Assert-NotNull $policyAssignmentSummary.Results
      Validate-SummaryResults -results:$policyAssignmentSummary.Results -nonCompliantPoliciesAssertNull:$false
      Assert-NotNull $policyAssignmentSummary.PolicyDefinitions
      Assert-NotNull $policyAssignmentSummary.PolicyGroups
      Assert-True { $policyAssignmentSummary.PolicyGroups.Count -gt 0 }

      Assert-NotNull $policyAssignmentSummary.PolicyDefinitions
      if ($policyAssignmentSummary.PolicyDefinitions.Count -gt 0) {
         Assert-True { ($policyAssignmentSummary.PolicyDefinitions | Where-Object { $_.Results.NonCompliantResources -gt 0 }).Count -eq $policyAssignmentSummary.Results.NonCompliantPolicies }

         Foreach ($policyDefinitionSummary in $policyAssignmentSummary.PolicyDefinitions) {
            Assert-NotNull $policyDefinitionSummary
            Assert-NotNullOrEmpty $policyDefinitionSummary.PolicyDefinitionId
            Assert-NotNullOrEmpty $policyDefinitionSummary.Effect

            Assert-NotNull $policyDefinitionSummary.PolicyDefinitionGroupNames
            Assert-NotNull $policyDefinitionSummary.Results
            Validate-SummaryResults -results:$policyDefinitionSummary.Results
         }
      }
   }
}

<#
.SYNOPSIS
Validates a summary results
#>
function Validate-SummaryResults {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.SummaryResults] $results,
      [switch]$nonCompliantPoliciesAssertNull = $true
   )

   Assert-NotNull $results.NonCompliantResources
   if ($nonCompliantPoliciesAssertNull) {
      Assert-Null $results.NonCompliantPolicies
   }
   else {
      Assert-NotNull $results.NonCompliantPolicies
   }
   Assert-NotNull $results.ResourceDetails
   Assert-NotNull $results.PolicyDetails
   Assert-True { $results.PolicyDetails.Count -gt 0 }
   Assert-NotNull $results.PolicyGroupDetails
}

<#
.SYNOPSIS
Validates a remediation
#>
function Validate-Remediation {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediation]$remediation)

   Assert-NotNull $remediation
   Assert-NotNull $remediation.CreatedOn
   Assert-NotNull $remediation.LastUpdatedOn
   Assert-NotNull $remediation.CorrelationId
   Assert-True { $remediation.Id -like "*/providers/microsoft.policyinsights/remediations/*" }
   Assert-AreEqual "Microsoft.PolicyInsights/remediations" $remediation.Type
   Assert-NotNullOrEmpty $remediation.Name
   Assert-NotNullOrEmpty $remediation.PolicyAssignmentId
   Assert-NotNullOrEmpty $remediation.ProvisioningState
   Assert-NotNull $remediation.DeploymentSummary
}

<#
.SYNOPSIS
Validates a remediation deployment
#>
function Validate-RemediationDeployment {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediationDeployment]$deployment)

   Assert-NotNull $deployment

   Assert-NotNull $deployment.CreatedOn
   Assert-NotNull $deployment.LastUpdatedOn
   Assert-True { $deployment.RemediatedResourceId -like "/subscriptions/*/providers/*" }
   Assert-NotNullOrEmpty $deployment.Status
   Assert-NotNullOrEmpty $deployment.ResourceLocation
}

<#
.SYNOPSIS
Validates a policy metadata resource
#>
function Validate-PolicyMetadata {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.PSPolicyMetadata]$policyMetadata,
      [switch]$validateExtendedProperties = $false)

   Assert-NotNull $policyMetadata

   Assert-NotNull $policyMetadata.Name
   Assert-AreEqual "Microsoft.PolicyInsights/policyMetadata" $policyMetadata.Type
   Assert-True { $policyMetadata.Id -like "/providers/Microsoft.PolicyInsights/policyMetadata/" + $policyMetadata.Name }

   Assert-NotNull $policyMetadata.Owner
   Assert-NotNull $policyMetadata.Title
   Assert-NotNull $policyMetadata.Category
   Assert-NotNull $policyMetadata.MetadataId
   if ($validateExtendedProperties) {
      Assert-NotNull $policyMetadata.Requirements
      Assert-NotNull $policyMetadata.Description
   }
}

<#
.SYNOPSIS
Validates a string is not null or empty
#>
function Assert-NotNullOrEmpty {
   param([string]$value)

   Assert-False { [string]::IsNullOrEmpty($value) }
}

<#
.SYNOPSIS
Gets test manual policy definition name targetted at subcriptions.
#>
function Get-TestManualPolicyDefinitonNameSub{
   "PSTestAttestationSub"
}

<#
.SYNOPSIS
Gets test manual policy definition name targetted at resource groups.
#>
function Get-TestManualPolicyDefinitonNameRG{
   "PSTestAttestationRG"
}

<#
.SYNOPSIS
Gets test manual policy definition name targetted at resources.
#>
function Get-TestManualPolicyDefinitonNameResource{
   "PSTestAttestationResource"
}

<#
.SYNOPSIS
Gets test manual policy initiative name targetted at subcriptions.
#>
function Get-TestManualPolicyInitiativeNameSub{
   "PSTestAttestationInitiativeSub"
}

<#
.SYNOPSIS
Gets test manual policy initiative name targetted at resource groups.
#>
function Get-TestManualPolicyInitiativeNameRG{
   "PSTestAttestationInitiativeRG"
}

<#
.SYNOPSIS
Gets test manual policy initiative name targetted at resource.
#>
function Get-TestManualPolicyInitiativeNameResource{
   "PSTestAttestationInitiativeResource"
}

#region Attestation Subsciption Scope

<#
.SYNOPSIS
Get the name of the policy assignment at the subscription scope.
#>
function Get-TestAttestationSubscriptionPolicyAssignmentName {
   "PSAttestationSubAssignment"
}

<#
.SYNOPSIS
Get the name of the policy assignment at the subscription scope for a policy initiative.
#>
function Get-TestInitiativeAttestationSubPolicyAssignmentName {
   "PSAttestationInitiativeSubAssignment"
}

<#
.SYNOPSIS
Gets the resource id of policy assignment used for attestation tests at subscription scope.
#>
function Get-TestAttestationSubscriptionPolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestAttestationSubscriptionPolicyAssignmentName)"
}

<#
.SYNOPSIS
Gets the policy assignment id used for attestation tests at subscription scope.
#>
function Get-TestInitiativeAttestationSubPolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestInitiativeAttestationSubPolicyAssignmentName)"
}

<#
.SYNOPSIS
Gets the policy definition reference id of the initiative used for attestation tests at subscription scope.
#>
function Get-TestInitiativeAttestationSubPolicyRefId {
   "$(Get-TestManualPolicyDefinitonNameSub)_1"
}

#endregion

#region Attestation Resource Group Scope
<#
.SYNOPSIS
Gets the name of the resource group used for attestation tests at resource group scope.
#>
function Get-PSAttestationTestRGName {
   "ps-attestation-test-rg"
}

<#
.SYNOPSIS
Gets the name of the policy assignment for an initiative used for attestation tests at resource group scope.
#>
function Get-TestInitiativeAttestationRGPolicyAssignmentName {
   "PSAttestationInitiativeRGAssignment"
}

<#
.SYNOPSIS
Gets the name of the policy assignment for attestation tests at resource group scope.
#>
function Get-TestAttestationRGPolicyAssignmentName {
   "PSAttestationRGAssignment"
}

<#
.SYNOPSIS
Gets the policy assignment id for attestation tests at resource group scope.
#>
function Get-TestAttestationRGPolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestAttestationRGPolicyAssignmentName)"
}

<#
.SYNOPSIS
Gets the policy initiative's assignment id for attestation tests at resource group scope.
#>
function Get-TestInitiativeAttestationRGPolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestInitiativeAttestationRGPolicyAssignmentName)"
}

<#
.SYNOPSIS
Gets the policy definition reference id for attestation tests at resource group scope.
#>
function Get-TestInitiativeAttestationRGPolicyRefId {
   "$(Get-TestManualPolicyDefinitonNameRG)_1"
}

#endregion

#region Attestation Resource Scope
<#
.SYNOPSIS
Gets the name of the resource used in attestation tests at resource scope.
#>
function Get-PSAttestationTestResourceName {
   "$(Get-TestResourceNamePrefix)0"
}

<#
.SYNOPSIS
Gets the resource id of the resource used in attestation tests at resource scope.
#>
function Get-PSAttestationTestResourceId {
   "/subscriptions/$(Get-TestSubscriptionId)/resourceGroups/$(Get-PSAttestationTestRGName)/providers/Microsoft.Network/networkSecurityGroups/$(Get-PSAttestationTestResourceName)"
}

<#
.SYNOPSIS
Gets the name of the policy assignment used for attestation tests at resource scope.
#>
function Get-TestAttestationResourcePolicyAssignmentName {
   "PSAttestationResourceAssignment"
}

<#
.SYNOPSIS
Gets the resource id of the policy assignment used for attestation tests at resource scope.
#>
function Get-TestAttestationResourcePolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestAttestationResourcePolicyAssignmentName)"
}

<#
.SYNOPSIS
Gets the name of the policy assignment for an initiative used for attestation tests at resource scope.
#>
function Get-TestAttestationInitiativeResourcePolicyAssignmentName {
   "PSAttestationInitiativeResourceAssignment"
}

<#
.SYNOPSIS
Gets the resource id of the policy assignment for an initiative used for attestation tests at resource scope.
#>
function Get-TestAttestationInitiativeResourcePolicyAssignmentId {
   "/subscriptions/$(Get-TestSubscriptionId)/providers/Microsoft.Authorization/policyAssignments/$(Get-TestAttestationInitiativeResourcePolicyAssignmentName)"
}

<#
.SYNOPSIS
Gets the policy definition reference id used in attestation tests at resource scope.
#>
function Get-TestAttestationInitiativeResourcePolicyRefId {
   "$(Get-TestManualPolicyDefinitonNameResource)_1"
}
#endregion

<#
.SYNOPSIS
Validates an attestation
#>
function Validate-Attestation {
   param([Microsoft.Azure.Commands.PolicyInsights.Models.Attestations.PSAttestation]$attestation)

   Assert-NotNull $attestation
   Assert-NotNull $attestation.LastComplianceStateChangeAt
   Assert-True { $attestation.Id -like "*/providers/microsoft.policyinsights/attestations/*" }
   Assert-AreEqual "Microsoft.PolicyInsights/attestations" $attestation.Type
   Assert-NotNullOrEmpty $attestation.Name
   Assert-NotNullOrEmpty $attestation.PolicyAssignmentId
   Assert-NotNullOrEmpty $attestation.ProvisioningState
}

<#
.SYNOPSIS
Validates the properties of an attestation.
#>
function Validate-AttestationProperties {
   param(
      [Parameter(Mandatory = $true)]$attestation,
      [Parameter(Mandatory = $false)]$expectedName = $null,
      [Parameter(Mandatory = $false)]$expectedProvisioningState = $null,
      [Parameter(Mandatory = $false)]$expectedPolicyAssignmentId = $null,
      [Parameter(Mandatory = $false)]$expectedPolicyDefinitionReferenceId = $null,
      [Parameter(Mandatory = $false)]$expectedComplianceState = $null,
      [Parameter(Mandatory = $false)]$expectedComment = $null,
      [Parameter(Mandatory = $false)]$expectedExpiresOn = $null,
      [Parameter(Mandatory = $false)]$expectedMetadata = $null,
      [Parameter(Mandatory = $false)]$expectedEvidence = $null,
      [Parameter(Mandatory = $false)]$expectedOwner = $null,
      [Parameter(Mandatory = $false)]$expectedAssessmentDate = $null
   )
   if ($null -ne $expectedName) {
      Assert-AreEqual $expectedName $attestation.Name
   }
   if ($null -ne $expectedProvisioningState) {
      Assert-AreEqual $expectedProvisioningState $attestation.ProvisioningState
   }
   if ($null -ne $expectedPolicyAssignmentId) {
      Assert-AreEqual $expectedPolicyAssignmentId $attestation.PolicyAssignmentId
   }
   if ($null -ne $expectedPolicyDefinitionReferenceId) {
      Assert-AreEqual $expectedPolicyDefinitionReferenceId $attestation.PolicyDefinitionReferenceId
   }
   if ($null -ne $expectedComplianceState) {
      Assert-AreEqual $expectedComplianceState $attestation.ComplianceState
   }
   if ($null -ne $expectedExpiresOn) {
      Assert-AreEqual $expectedExpiresOn $attestation.ExpiresOn
   }
   if ($null -ne $expectedMetadata) {
      $expectedMetadataJson = [Newtonsoft.Json.Linq.JObject]::Parse($expectedMetadata)
      Assert-AreEqual $expectedMetadataJson.ToString() $attestation.metadata.ToString()
   }
   if ($null -ne $expectedEvidence) {
      Validate-PolicyAttestationEvidence($attestation.Evidence, $expectedEvidence)
   }
   if ($null -ne $expectedOwner) {
      Assert-AreEqual $expectedOwner $attestation.Owner
   }
   if ($null -ne $expectedComment) {
      Assert-AreEqual $expectedComment $attestation.Comment
   }
   if ($null -ne $expectedAssessmentDate) {
      Assert-AreEqual $expectedAssessmentDate $attestation.AssessmentDate
   }
}

<#
.SYNOPSIS
Validates an attestation evidence.
#>
function Validate-AttestationEvidence {
   param($actualEvidence, $expectedEvidence)

   Assert-NotNullOrEmpty $actualEvidence
   for ($i = 0; $i -lt $actualEvidence.Count; $i++) {
      Assert-AreEqual $expectedEvidence[$i].Description $actualEvidence[$i].Description
      Assert-AreEqual $expectedEvidence[$i].SourceUri $actualEvidence[$i].SourceUri
   }
}