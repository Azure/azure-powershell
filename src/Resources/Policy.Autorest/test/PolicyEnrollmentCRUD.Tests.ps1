# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyEnrollmentCRUD'

Describe 'PolicyEnrollmentCRUD' {

    BeforeAll {
        # Get built-in Audit resource location matches resource group location policy
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"
        $testPA = Get-ResourceName
        $testEnrollment = Get-ResourceName
        $testEnrollment2 = Get-ResourceName

        # EnforcementMode Enroll is only supported at subscription and management group scope
        $subScope = "/subscriptions/$subscriptionId"

        # make a policy assignment at subscription scope with EnforcementMode=Enroll
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $subScope -DisplayName $description -EnforcementMode $enforcementModeEnroll
    }

    It 'Make policy enrollment' {
        # create the policy enrollment at subscription scope
        $enrollment = New-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope -PolicyAssignmentId $assignment.Id -Description $description -DisplayName $description -Metadata $metadata
        $enrollment.Name | Should -Be $testEnrollment
        $enrollment.Type | Should -Be 'Microsoft.Authorization/policyEnrollments'
        $enrollment.Id | Should -Be "$subScope/providers/Microsoft.Authorization/policyEnrollments/$testEnrollment"
        $enrollment.PolicyAssignmentId | Should -Be $assignment.Id
        $enrollment.Description | Should -Be $description
        $enrollment.DisplayName | Should -Be $description
        $enrollment.Metadata | Should -Not -BeNullOrEmpty
        $enrollment.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Get policy enrollment by name' {
        # get the enrollment by name and scope
        $enrollment = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope
        $enrollment.Name | Should -Be $testEnrollment
        $enrollment.Type | Should -Be 'Microsoft.Authorization/policyEnrollments'
        $enrollment.Id | Should -Be "$subScope/providers/Microsoft.Authorization/policyEnrollments/$testEnrollment"
        $enrollment.PolicyAssignmentId | Should -Be $assignment.Id
        $enrollment.Description | Should -Be $description
        $enrollment.DisplayName | Should -Be $description
        $enrollment.Metadata | Should -Not -BeNullOrEmpty
        $enrollment.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Get policy enrollment by Id' {
        # get the enrollment by name first (to get the Id)
        $enrollment = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope

        # get the enrollment by id
        $enrollment = Get-AzPolicyEnrollment -Id $enrollment.Id
        $enrollment.Name | Should -Be $testEnrollment
        $enrollment.Type | Should -Be 'Microsoft.Authorization/policyEnrollments'
        $enrollment.Id | Should -Be "$subScope/providers/Microsoft.Authorization/policyEnrollments/$testEnrollment"
        $enrollment.PolicyAssignmentId | Should -Be $assignment.Id
        $enrollment.Description | Should -Be $description
        $enrollment.DisplayName | Should -Be $description
        $enrollment.Metadata | Should -Not -BeNullOrEmpty
        $enrollment.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Update policy enrollment' {
        # get the enrollment by name first (to get the Id)
        $enrollment = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope

        # update display name and clear metadata using explicit parameters
        # (pipeline mutation with $enrollment.Metadata = $null is not sufficient to clear metadata
        # because the Update custom code skips null InputObject properties and restores from existing)
        $enrollment = Update-AzPolicyEnrollment -Id $enrollment.Id -DisplayName 'testDisplay' -Metadata '{}'
        $enrollment.DisplayName | Should -Be 'testDisplay'
        $enrollment.Metadata.$metadataName | Should -BeNull
    }

    It 'Update policy enrollment by Id' {
        # get the enrollment by name first (to get the Id)
        $enrollment = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope

        # update the enrollment via Id with a new display name
        $enrollment = Update-AzPolicyEnrollment -Id $enrollment.Id -DisplayName 'testDisplay2'
        $enrollment.DisplayName | Should -Be 'testDisplay2'
    }

    It 'Validate parameter round-trip' {
        # get the enrollment, do an update with no changes, validate nothing is changed in response or backend
        $expected = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope
        $response = Update-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope
        $response.DisplayName | Should -Be $expected.DisplayName
        $response.Description | Should -Be $expected.Description
        $response.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $response.PolicyAssignmentId | Should -Be $expected.PolicyAssignmentId
        $response.PolicyDefinitionReferenceId | Should -BeLike $expected.PolicyDefinitionReferenceId
        $response.AssignmentScopeValidation | Should -BeLike $expected.AssignmentScopeValidation
        $actual = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope
        $actual.DisplayName | Should -Be $expected.DisplayName
        $actual.Description | Should -Be $expected.Description
        $actual.Metadata.$metadataName | Should -Be $expected.Metadata.$metadataName
        $actual.PolicyAssignmentId | Should -Be $expected.PolicyAssignmentId
        $actual.PolicyDefinitionReferenceId | Should -BeLike $expected.PolicyDefinitionReferenceId
        $actual.AssignmentScopeValidation | Should -BeLike $expected.AssignmentScopeValidation
    }

    It 'List policy enrollments by scope' {
        # make another policy enrollment, ensure both are present in the subscription scope listing
        $enrollment2 = New-AzPolicyEnrollment -Name $testEnrollment2 -Scope $subScope -PolicyAssignmentId $assignment.Id -DisplayName $description
        $list = Get-AzPolicyEnrollment -Scope $subScope | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }
        $list | Should -HaveCount 2
    }

    It 'List policy enrollments by subscription' {
        # ensure both are present in subscription-level listing
        $list = Get-AzPolicyEnrollment | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }
        $list | Should -HaveCount 2
    }

    It 'List policy enrollments including descendants' {
        # IncludeDescendent suppresses the atScope() filter; both enrollments at sub scope should be present
        $list = Get-AzPolicyEnrollment -IncludeDescendent | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }
        $list | Should -HaveCount 2
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope -Force -PassThru
        $remove = (Remove-AzPolicyEnrollment -Name $testEnrollment2 -Scope $subScope -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $subScope -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
