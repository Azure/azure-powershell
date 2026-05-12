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

# setup the Pester environment
. (Join-Path $PSScriptRoot 'Common.ps1') 'Attestation-CRUD'

Describe 'Attestation-CRUD' {

    BeforeAll {
        $Compliant = "Compliant"
        $NonCompliant = "NonCompliant"
    }


    It 'Attestation-SubscriptionScope-Crud' {
        # Create a new attestation with minimal properties
        $policyAssignmentId = $env.attestationSubPolicyAssignmentId
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
        $updatedMinimalAttestation = Update-AzPolicyAttestation -Name $attestationName -ComplianceState $NonCompliant
        Validate-Attestation $updatedMinimalAttestation
        Validate-AttestationProperties `
           -attestation $updatedMinimalAttestation `
           -expectedName $attestationName `
           -expectedProvisioningState "Succeeded" `
           -expectedPolicyAssignmentId $policyAssignmentId `
           -expectedComplianceState $NonCompliant

        # Update an existing attestation by input object
        $comment = "Test Comment"
        $updatedMinimalAttestation2 = $updatedMinimalAttestation | Update-AzPolicyAttestation -Comment $comment
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
        $updatedMinimalAttestation3 = Update-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Id $updatedMinimalAttestation2.Id -ComplianceState $NonCompliant -Comment $comment -ExpiresOn $expiresOn
        Validate-Attestation $updatedMinimalAttestation3
        Validate-AttestationProperties `
           -attestation $updatedMinimalAttestation3 `
           -expectedName $attestationName `
           -expectedProvisioningState "Succeeded" `
           -expectedPolicyAssignmentId $policyAssignmentId `
           -expectedComplianceState $NonCompliant `
           -expectedComment $comment `
           -expectedExpiresOn $expiresOn

        # Attestations All Properties CRUD
        $attestationName = "Attestation-Sub-Full"
        $policyInitiativeAssignmentId = $env.attestationSetSubPolicyAssignmentId
        $policyDefinitionReferenceId = $env.attestationSetSubPolicyRefId

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
        $updatedFullAttestation = Update-AzPolicyAttestation `
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

        # Also validating the alias for Update-AzPolicyAttestation here
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
        $updatedFullAttestation3 = $updatedFullAttestation2 | Update-AzPolicyAttestation -Owner $newOwner

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
    }

    It 'Attestation-ResourceGroupScope-Crud' {
        # Minimal Attestation CRUD
        # Create a new attestation with minimal properties
        $policyAssignmentId = $env.attestationRgPolicyAssignmentId
        $attestationName = "Attestation-RGScope-Crud"
        $RGName = $env.attestationRgName

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
        $updatedMinimalAttestation = Update-AzPolicyAttestation -ResourceGroupName $RGName -Name $attestationName -ComplianceState $NonCompliant
        Validate-Attestation $updatedMinimalAttestation
        Validate-AttestationProperties `
           -attestation $updatedMinimalAttestation `
           -expectedName $attestationName `
           -expectedProvisioningState "Succeeded" `
           -expectedPolicyAssignmentId $policyAssignmentId `
           -expectedComplianceState $NonCompliant

        # Update an existing attestation by input object
        $comment = "Test Comment"
        $updatedMinimalAttestation2 = $updatedMinimalAttestation | Update-AzPolicyAttestation -Comment $comment
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
        $updatedMinimalAttestation3 = Update-AzPolicyAttestation -Id $updatedMinimalAttestation2.Id -ComplianceState $NonCompliant -Comment $comment -ExpiresOn $expiresOn
        Validate-Attestation $updatedMinimalAttestation3
        Validate-AttestationProperties `
           -attestation $updatedMinimalAttestation3 `
           -expectedName $attestationName `
           -expectedProvisioningState "Succeeded" `
           -expectedPolicyAssignmentId $policyAssignmentId `
           -expectedComplianceState $NonCompliant `
           -expectedComment $comment `
           -expectedExpiresOn $expiresOn

        # Attestations All Properties CRUD
        $attestationName = "Attestation-RG-Full"
        $policyInitiativeAssignmentId = $env.attestationSetRgPolicyAssignmentId
        $policyDefinitionReferenceId = $env.attestationSetRgPolicyRefId

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
        $updatedFullAttestation = Update-AzPolicyAttestation `
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
        $evidence2 = [Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.AttestationEvidence]::new()
        $evidence2.Description = $description2
        $evidence2.SourceUri = $sourceURI2


        $policyEvidence = @( `
              $evidence,
           $evidence2
        )

        $updatedFullAttestation2 = Update-AzPolicyAttestation `
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
        $updatedFullAttestation3 = $updatedFullAttestation2 | Update-AzPolicyAttestation -Owner $newOwner

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

        Remove-Item ".\AttestationMetadata.json" -Force
    }

    It 'Attestation-ResourceScope-Crud' {
        # Minimal Attestation CRUD
        # Create a new attestation with minimal properties
        $policyAssignmentId = $env.attestationResourcePolicyAssignmentId
        $attestationName = "Attestation-ResourceScope-Crud"
        $scope = $env.attestationTestResourceId

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
        $updatedMinimalAttestation = Update-AzPolicyAttestation -Scope $scope -Name $attestationName -ComplianceState $NonCompliant
        Validate-Attestation $updatedMinimalAttestation
        Validate-AttestationProperties `
           -attestation $updatedMinimalAttestation `
           -expectedName $attestationName `
           -expectedProvisioningState "Succeeded" `
           -expectedPolicyAssignmentId $policyAssignmentId `
           -expectedComplianceState $NonCompliant

        # Update an existing attestation by input object
        $comment = "Test Comment"
        $updatedMinimalAttestation2 = $updatedMinimalAttestation  | Update-AzPolicyAttestation -Comment $comment
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
        $updatedMinimalAttestation3 = Update-AzPolicyAttestation -PolicyAssignmentId $policyAssignmentId -Id $updatedMinimalAttestation2.Id -ComplianceState $NonCompliant -Comment $comment -ExpiresOn $expiresOn
        Validate-Attestation $updatedMinimalAttestation3
        Validate-AttestationProperties `
           -attestation $updatedMinimalAttestation3 `
           -expectedName $attestationName `
           -expectedProvisioningState "Succeeded" `
           -expectedPolicyAssignmentId $policyAssignmentId `
           -expectedComplianceState $NonCompliant `
           -expectedComment $comment `
           -expectedExpiresOn $expiresOn

        # Attestations All Properties CRUD
        $attestationName = "Attestation-Resource-Full"
        $policyInitiativeAssignmentId = $env.attestationSetResourcePolicyAssignmentId
        $policyDefinitionReferenceId = $env.attestationSetResourcePolicyRefId

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
        $updatedFullAttestation = Update-AzPolicyAttestation `
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
        $evidence2 = [Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.AttestationEvidence]::new()
        $evidence2.Description = $description2
        $evidence2.SourceUri = $sourceURI2

        $policyEvidence = @( `
              $evidence,
           $evidence2
        )

        $updatedFullAttestation2 = Update-AzPolicyAttestation `
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
        $updatedFullAttestation3 = $updatedFullAttestation2 | Update-AzPolicyAttestation -Owner $newOwner

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

        # Delete one attestation by resource id 
        $result = Remove-AzPolicyAttestation -Id $minimalAttestation.Id -PassThru
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
    }

    It 'Attestation-GetCollection' {
        # First Attestation
        $policyAssignmentId = $env.attestationSubPolicyAssignmentId
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
        $RGName = $env.attestationRgName
        $policyInitiativeAssignmentId = $env.attestationSetRgPolicyAssignmentId
        $policyDefinitionReferenceId = $env.attestationSetRgPolicyRefId
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
        $policyAssignmentId = $env.attestationResourcePolicyAssignmentId
        $attestationName = "Attestation-ResourceScope-Crud"
        $scope = $env.attestationTestResourceId

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

        $attestationsFilter = Get-AzPolicyAttestation -Filter "PolicyAssignmentId eq '$($env.attestationSubPolicyAssignmentId)'"
        Assert-AreEqual 1 $attestationsFilter.Count

        $attestations2 = Get-AzPolicyAttestation -ResourceGroupName $RGName
        Assert-AreEqual 2 $attestations2.Count

        $attestations3 = Get-AzPolicyAttestation -Scope $scope
        Assert-AreEqual 1 $attestations3.Count

        $result = $attestations1 | Remove-AzPolicyAttestation -PassThru
        Assert-AreEqual $true $result
    }

    It 'Attestation-Error-Handling' {
        # Attestation CRUD Error No Compliance Results
        # Create a new attestation with minimal properties
        $policyAssignmentId = $env.attestationSubPolicyAssignmentId
        $attestationName = "Attestation-Error-Crud"
        $RGName = $env.attestationRgName
        $codecompare = "InvalidCreateAttestationRequest"
        $messagecompare = "Unable to create attestation '$attestationName'. No compliance data was found for resource '/subscriptions/$($env.SubscriptionId)/resourceGroups/$RGName' against policy assignment '$policyAssignmentId'"

        try {
            New-AzPolicyAttestation -ResourceGroupName $RGName -PolicyAssignmentId $policyAssignmentId -Name $attestationName -ComplianceState $Compliant
        }
        catch {
            $actualMessage = $_.Exception.Message
            
            if (!$actualMessage.Contains($codecompare)) {
                throw "Did not find '$codecompare' in error message"
            }           
            if ($actualMessage.Contains($messagecompare)) {
                return $true
            }
            else {
                throw "Expected exception does not contain the expected text '$messagecompare', the actual message is '$actualMessage'"
            }
        }

        throw "No Error occurred"
    }
}