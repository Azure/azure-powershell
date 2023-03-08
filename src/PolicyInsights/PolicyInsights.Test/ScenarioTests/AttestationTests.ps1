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
. ".\Common.ps1"
$Compliant = "Compliant"
$NonCompliant = "NonCompliant"
<#
.SYNOPSIS
Perform attestation CRUD operations at subscription scope
#>
function Attestation-SubscriptionScope-Crud {
   # Import-Module "C:\One\azure-powershell\artifacts\Debug\Az.PolicyInsights\Az.PolicyInsights.psm1"
   #region Minimal Attestation CRUD
   # Create a new attestation with minimal properties
   $policyAssignmentId = Get-TestAttestationSubscriptionPolicyAssignmentId
   $attestationName = "Attestation-SubscriptionScope-Crud"

   $minimalAttestation = New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState $Compliant

   Validate-Attestation $minimalAttestation
   Validate-AttestationProperties `
      -attestation $minimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Get the attestation
   $attestation = Get-AzPolicyAttestation -Name $attestationName
   Validate-Attestation $attestation
   Validate-AttestationProperties `
      -attestation $attestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Update an existing attestation by resource name
   $updatedMinimalAttestation = Set-AzPolicyAttestation -Name $attestationName -ComplianceState $NonCompliant
   Validate-Attestation $updatedMinimalAttestation
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant

   # Update an existing attestation by input object
   $comment = "Test Comment"
   $updatedMinimalAttestation2 = $updatedMinimalAttestation | Set-AzPolicyAttestation -Comment $comment
   Validate-Attestation $updatedMinimalAttestation2
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation2 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment

   # Update an existing attestation by resource ID
   $expiresOn = [System.DateTime]::new(2050, 01, 01, 00, 00, 00)
   $updatedMinimalAttestation3 = Set-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Id $updatedMinimalAttestation2.Id -ComplianceState $NonCompliant -Comment $comment -ExpiresOn $expiresOn
   Validate-Attestation $updatedMinimalAttestation3
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation3 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn
   #endregion

   #region Attestations All Properties CRUD
   $attestationName = "Attestation-Sub-Full"
   $policyInitiativeAssignmentId = Get-TestInitiativeAttestationSubPolicyAssignmentId
   $policyDefinitionReferenceId = Get-TestInitiativeAttestationSubPolicyRefId

   $description = "This is a test description"
   $sourceURI = "https://contoso.org/test.pdf"
   $owner = "Test Owner"
   $evidence = @{
      "Description" = $description
      "SourceUri"   = $sourceURI
   }
   $policyEvidence = @($evidence)

   $metadata = '{"TestKey":"TestValue"}'

   $fullAttestation = New-AzPolicyAttestation `
      -Name $attestationName `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($fullAttestation)
   Validate-AttestationProperties `
      -attestation $fullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Get the attestation
   $attestation = Get-AzPolicyAttestation -Name $attestationName
   Validate-Attestation $attestation
   Validate-AttestationProperties `
      -attestation $attestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedComplianceState $Compliant

   # Update the existing attestation by resource name
   $comment = "This is an updated comment"
   $updatedFullAttestation = Set-AzPolicyAttestation `
      -Name $attestationName `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($updatedFullAttestation)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Update the existing attestation by resource id
   $description = "This is a test description"
   $sourceURI = "https://contoso.org/test.pdf"
   $owner = "Test Owner"
   $evidence = @{
      "Description" = $description
      "SourceUri"   = $sourceURI
   }

   $description2 = "Found new evidence to make the resource non-compliant"
   $sourceURI2 = "https://contoso.org/testnewevidence.pdf"
   $evidence2 = @{
      "Description" = $description2
      "SourceUri"   = $sourceURI2
   }

   $policyEvidence = @( `
         $evidence,
      $evidence2
   )

   $updatedFullAttestation2 = Set-AzPolicyAttestation `
      -Id $updatedFullAttestation.Id `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $NonCompliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($updatedFullAttestation2)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation2 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Update attestation by input object
   $newOwner = "Test Owner 2"
   $updatedFullAttestation3 = $updatedFullAttestation2 | Set-AzPolicyAttestation -Owner $newOwner

   Validate-Attestation($updatedFullAttestation3)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation3 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $newOwner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation
   Assert-NotNullorEmpty $attestations
   Assert-AreEqual 2 $attestations.Count

   # Delete one attestation
   $result = ($minimalAttestation | Remove-AzPolicyAttestation -PassThru)
   Assert-AreEqual $true $result

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation
   Assert-NotNullorEmpty $attestations
   Assert-AreEqual 1 $attestations.Count

   $result = ($fullAttestation | Remove-AzPolicyAttestation -PassThru)
   Assert-AreEqual $true $result

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation
   Assert-AreEqual 0 $attestations.Count

   #endregion
}

function Attestation-ResourceGroupScope-Crud {
   # Import-Module "C:\One\azure-powershell\artifacts\Debug\Az.PolicyInsights\Az.PolicyInsights.psm1"
   #region Minimal Attestation CRUD
   # Create a new attestation with minimal properties
   $policyAssignmentId = Get-TestAttestationRGPolicyAssignmentId
   $attestationName = "Attestation-RGScope-Crud"
   $RGName = Get-PSAttestationTestRGName

   $minimalAttestation = New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState $Compliant

   Validate-Attestation $minimalAttestation
   Validate-AttestationProperties `
      -attestation $minimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Get the attestation
   $attestation = Get-AzPolicyAttestation -ResourceGroupName $RGName -Name $attestationName
   Validate-Attestation $attestation
   Validate-AttestationProperties `
      -attestation $attestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Update an existing attestation by resource name
   $updatedMinimalAttestation = Set-AzPolicyAttestation -ResourceGroupName $RGName -Name $attestationName -ComplianceState $NonCompliant
   Validate-Attestation $updatedMinimalAttestation
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant

   # Update an existing attestation by input object
   $comment = "Test Comment"
   $updatedMinimalAttestation2 = $updatedMinimalAttestation | Set-AzPolicyAttestation -Comment $comment
   Validate-Attestation $updatedMinimalAttestation2
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation2 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment

   # Update an existing attestation by resource ID
   $expiresOn = [System.DateTime]::new(2050, 01, 01, 00, 00, 00)
   $updatedMinimalAttestation3 = Set-AzPolicyAttestation -Id $updatedMinimalAttestation2.Id -ComplianceState $NonCompliant -Comment $comment -ExpiresOn $expiresOn
   Validate-Attestation $updatedMinimalAttestation3
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation3 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn
   #endregion

   #region Attestations All Properties CRUD
   $attestationName = "Attestation-RG-Full"
   $policyInitiativeAssignmentId = Get-TestInitiativeAttestationRGPolicyAssignmentId
   $policyDefinitionReferenceId = Get-TestInitiativeAttestationRGPolicyRefId

   $description = "This is a test description"
   $sourceURI = "https://contoso.org/test.pdf"
   $owner = "Test Owner"
   $evidence = @{
      "Description" = $description
      "SourceUri"   = $sourceURI
   }
   $policyEvidence = @($evidence)
   $fileContent = '{"TestKey": "TestValue"}'

   Set-Content -Path ".\AttestationMetadata.json" -Value $fileContent
   $metadata = Join-Path . "AttestationMetadata.json"

   $fullAttestation = New-AzPolicyAttestation `
      -Name $attestationName `
      -ResourceGroupName $RGName `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($fullAttestation)
   Validate-AttestationProperties `
      -attestation $fullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $fileContent `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Get the attestation
   $attestation = Get-AzPolicyAttestation -Name $attestationName -ResourceGroupName $RGName
   Validate-Attestation $attestation
   Validate-AttestationProperties `
      -attestation $attestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedComplianceState $Compliant

   # Update the existing attestation by resource name
   $comment = "This is an updated comment"
   $updatedFullAttestation = Set-AzPolicyAttestation `
      -Name $attestationName `
      -ResourceGroupName $RGName `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($updatedFullAttestation)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $fileContent `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Update the existing attestation by resource id
   $description = "This is a test description"
   $sourceURI = "https://contoso.org/test.pdf"
   $owner = "Test Owner"
   $evidence = @{
      "Description" = $description
      "SourceUri"   = $sourceURI
   }

   $description2 = "Found new evidence to make the resource non-compliant"
   $sourceURI2 = "https://contoso.org/testnewevidence.pdf"
   $evidence2 = [Microsoft.Azure.Management.PolicyInsights.Models.AttestationEvidence]::new($description2, $sourceURI2)

   $policyEvidence = @( `
         $evidence,
      $evidence2
   )

   $updatedFullAttestation2 = Set-AzPolicyAttestation `
      -Id $updatedFullAttestation.Id `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $NonCompliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($updatedFullAttestation2)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation2 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $fileContent `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Update attestation by input object
   $newOwner = "Test Owner 2"
   $updatedFullAttestation3 = $updatedFullAttestation2 | Set-AzPolicyAttestation -Owner $newOwner

   Validate-Attestation($updatedFullAttestation3)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation3 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $fileContent `
      -expectedOwner $newOwner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation -ResourceGroupName $RGName
   Assert-NotNullorEmpty $attestations
   Assert-AreEqual 2 $attestations.Count

   # Delete one attestation
   $result = ($minimalAttestation | Remove-AzPolicyAttestation -PassThru)
   Assert-AreEqual $true $result

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation -ResourceGroupName $RGName
   Assert-NotNullorEmpty $attestations
   Assert-AreEqual 1 $attestations.Count

   # Delete the second attestation
   $result = ($fullAttestation | Remove-AzPolicyAttestation -PassThru)
   Assert-AreEqual $true $result

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation -ResourceGroupName $RGName
   Assert-AreEqual 0 $attestations.Count

   #endregion

   Remove-Item ".\AttestationMetadata.json" -Force
}

function Attestation-ResourceScope-Crud {
   # Import-Module "C:\One\azure-powershell\artifacts\Debug\Az.PolicyInsights\Az.PolicyInsights.psm1"
   #region Minimal Attestation CRUD
   # Create a new attestation with minimal properties
   $policyAssignmentId = Get-TestAttestationResourcePolicyAssignmentId
   $attestationName = "Attestation-ResourceScope-Crud"
   $scope = Get-PSAttestationTestResourceId

   $minimalAttestation = New-AzPolicyAttestation `
      -PolicyAssignmentId $policyAssignmentId `
      -Name $attestationName `
      -Scope $scope `
      -ComplianceState $Compliant

   Validate-Attestation $minimalAttestation
   Validate-AttestationProperties `
      -attestation $minimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Get the attestation
   $attestation = Get-AzPolicyAttestation -Name $attestationName -Scope $scope
   Validate-Attestation $attestation
   Validate-AttestationProperties `
      -attestation $attestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Update an existing attestation by resource name
   $updatedMinimalAttestation = Set-AzPolicyAttestation -Scope $scope -Name $attestationName -ComplianceState $NonCompliant
   Validate-Attestation $updatedMinimalAttestation
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant

   # Update an existing attestation by input object
   $comment = "Test Comment"
   $updatedMinimalAttestation2 = $updatedMinimalAttestation  | Set-AzPolicyAttestation -Comment $comment
   Validate-Attestation $updatedMinimalAttestation2
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation2 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment

   # Update an existing attestation by resource ID
   $expiresOn = [System.DateTime]::new(2050, 01, 01, 00, 00, 00)
   $updatedMinimalAttestation3 = Set-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Id $updatedMinimalAttestation2.Id -ComplianceState $NonCompliant -Comment $comment -ExpiresOn $expiresOn
   Validate-Attestation $updatedMinimalAttestation3
   Validate-AttestationProperties `
      -attestation $updatedMinimalAttestation3 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn
   #endregion

   #region Attestations All Properties CRUD
   $attestationName = "Attestation-Resource-Full"
   $policyInitiativeAssignmentId = Get-TestAttestationInitiativeResourcePolicyAssignmentId
   $policyDefinitionReferenceId = Get-TestAttestationInitiativeResourcePolicyRefId

   $description = "This is a test description"
   $sourceURI = "https://contoso.org/test.pdf"
   $owner = "Test Owner"
   $evidence = @{
      "Description" = $description
      "SourceUri"   = $sourceURI
   }
   $policyEvidence = @($evidence)

   $metadata = '{"TestKey":"TestValue"}'


   $fullAttestation = New-AzPolicyAttestation `
      -Name $attestationName `
      -Scope $scope `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($fullAttestation)
   Validate-AttestationProperties `
      -attestation $fullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Get the attestation
   $attestation = Get-AzPolicyAttestation -Name $attestationName -Scope $scope
   Validate-Attestation $attestation
   Validate-AttestationProperties `
      -attestation $attestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedComplianceState $Compliant

   # Update the existing attestation by resource name
   $comment = "This is an updated comment"
   $updatedFullAttestation = Set-AzPolicyAttestation `
      -Name $attestationName `
      -Scope $scope `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($updatedFullAttestation)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Update the existing attestation by resource id
   $description2 = "Found new evidence to make the resource non-compliant"
   $sourceURI2 = "https://contoso.org/testnewevidence.pdf"
   $evidence2 = [Microsoft.Azure.Management.PolicyInsights.Models.AttestationEvidence]::new($description2, $sourceURI2)

   $policyEvidence = @( `
         $evidence,
      $evidence2
   )

   $updatedFullAttestation2 = Set-AzPolicyAttestation `
      -Id $updatedFullAttestation.Id `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $NonCompliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($updatedFullAttestation2)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation2 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Update attestation by input object
   $newOwner = "Test Owner 2"
   $updatedFullAttestation3 = $updatedFullAttestation2 | Set-AzPolicyAttestation -Owner $newOwner

   Validate-Attestation($updatedFullAttestation3)
   Validate-AttestationProperties `
      -attestation $updatedFullAttestation3 `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $NonCompliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $newOwner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation -Scope $scope
   Assert-NotNullorEmpty $attestations
   Assert-AreEqual 2 $attestations.Count

   # Delete one attestation
   $result = ($minimalAttestation | Remove-AzPolicyAttestation -PassThru)
   Assert-AreEqual $true $result

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation -Scope $scope
   Assert-NotNullorEmpty $attestations
   Assert-AreEqual 1 $attestations.Count

   $result = ($fullAttestation | Remove-AzPolicyAttestation -PassThru)
   Assert-AreEqual $true $result

   # Get all attestations at the scope
   $attestations = Get-AzPolicyAttestation -Scope $scope
   Assert-AreEqual 0 $attestations.Count

   #endregion
}

function Attestation-GetCollection {
   # First Attestation
   $policyAssignmentId = Get-TestAttestationSubscriptionPolicyAssignmentId
   $attestationName = "Attestation-SubscriptionScope-Crud"
   $minimalAttestation = New-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState $Compliant

   Validate-Attestation $minimalAttestation
   Validate-AttestationProperties `
      -attestation $minimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   # Second Attestation
   $attestationName = "Attestation-RG-Full"
   $RGName = Get-PSAttestationTestRGName
   $policyInitiativeAssignmentId = Get-TestInitiativeAttestationRGPolicyAssignmentId
   $policyDefinitionReferenceId = Get-TestInitiativeAttestationRGPolicyRefId
   $comment = "Test Comment"
   $description = "This is a test description"
   $sourceURI = "https://contoso.org/test.pdf"
   $owner = "Test Owner"
   $evidence = @{
      "Description" = $description
      "SourceUri"   = $sourceURI
   }
   $policyEvidence = @($evidence)
   $expiresOn = [System.DateTime]::new(2050, 01, 01, 00, 00, 00)
   $metadata = '{"TestKey":"TestValue"}'


   $fullAttestation = New-AzPolicyAttestation `
      -Name $attestationName `
      -ResourceGroupName $RGName `
      -PolicyAssignmentId $policyInitiativeAssignmentId `
      -PolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -ComplianceState $Compliant `
      -Comment $comment `
      -Evidence $policyEvidence `
      -ExpiresOn $expiresOn `
      -AssessmentDate $expiresOn.AddDays(-2) `
      -Owner $owner `
      -Metadata $metadata

   Validate-Attestation($fullAttestation)
   Validate-AttestationProperties `
      -attestation $fullAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyInitiativeAssignmentId `
      -expectedPolicyDefinitionReferenceId $policyDefinitionReferenceId `
      -expectedComplianceState $Compliant `
      -expectedComment $comment `
      -expectedExpiresOn $expiresOn `
      -expectedMetadata $metadata `
      -expectedOwner $owner `
      -expectedAssessmentDate $expiresOn.AddDays(-2)

   # Third Attestation
   $policyAssignmentId = Get-TestAttestationResourcePolicyAssignmentId
   $attestationName = "Attestation-ResourceScope-Crud"
   $scope = Get-PSAttestationTestResourceId

   $minimalAttestation = New-AzPolicyAttestation `
      -PolicyAssignmentId $policyAssignmentId `
      -Name $attestationName `
      -Scope $scope `
      -ComplianceState $Compliant

   Validate-Attestation $minimalAttestation
   Validate-AttestationProperties `
      -attestation $minimalAttestation `
      -expectedName $attestationName `
      -expectedProvisioningState "Succeeded" `
      -expectedPolicyAssignmentId $policyAssignmentId `
      -expectedComplianceState $Compliant

   $attestations1 = Get-AzPolicyAttestation
   Assert-AreEqual 3 $attestations1.Count

   $attestationsTop = Get-AzPolicyAttestation -Top 2
   Assert-AreEqual 2 $attestationsTop.Count

   $attestationsFilter = Get-AzPolicyAttestation -Filter "PolicyAssignmentId eq '$(Get-TestAttestationSubscriptionPolicyAssignmentId)'"
   Assert-AreEqual 1 $attestationsFilter.Count

   $attestations2 = Get-AzPolicyAttestation -ResourceGroupName $RGName
   Assert-AreEqual 2 $attestations2.Count

   $attestations3 = Get-AzPolicyAttestation -Scope $scope
   Assert-AreEqual 1 $attestations3.Count

   $result = $attestations1 | Remove-AzPolicyAttestation -PassThru
   Assert-AreEqual $true $result
}

function Attestation-Error-Handling {
   #region Attestation CRUD Error No Compliance Results
   # Create a new attestation with minimal properties
   $policyAssignmentId = Get-TestAttestationSubscriptionPolicyAssignmentId
   $attestationName = "Attestation-Error-Crud"
   $RGName = Get-PSAttestationTestRGName

   Assert-ThrowsContains `
   {
      New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState $Compliant
   } `
      "InvalidCreateAttestationRequest: Unable to create attestation '$attestationName'. No compliance data was found for resource '/subscriptions/$(Get-TestSubscriptionId)/resourceGroups/$RGName' against policy assignment '$policyAssignmentId'"
   #endregion
}