# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyEnrollmentCRUDAtManagementGroup'

Describe 'PolicyEnrollmentCRUDAtManagementGroup' {

    BeforeAll {
        $testPA = Get-ResourceName -MaxLength 24
        $testEnrollment = Get-ResourceName -MaxLength 24
        $testEnrollment2 = Get-ResourceName -MaxLength 24

        # Get built-in Audit resource location matches resource group location policy
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"

        # make a policy assignment at MG scope with EnforcementMode=Enroll
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $managementGroupScope -DisplayName $description -EnforcementMode $enforcementModeEnroll

        # create the policy enrollment at MG scope
        $enrollment = New-AzPolicyEnrollment -Name $testEnrollment -Scope $managementGroupScope -PolicyAssignmentId $assignment.Id -Description $description -DisplayName $description -Metadata $metadata
    }

    It 'Make policy enrollment at MG level' {
        $enrollment.Name | Should -Be $testEnrollment
        $enrollment.Type | Should -Be 'Microsoft.Authorization/policyEnrollments'
        $enrollment.Id | Should -Be "$managementGroupScope/providers/Microsoft.Authorization/policyEnrollments/$testEnrollment"
        $enrollment.PolicyAssignmentId | Should -Be $assignment.Id
        $enrollment.Description | Should -Be $description
        $enrollment.DisplayName | Should -Be $description
        $enrollment.Metadata | Should -Not -BeNullOrEmpty
        $enrollment.Metadata.$metadataName | Should -Be $metadataValue
    }

    It 'Update policy enrollment at MG level' {
        # update the policy enrollment display name and metadata, validate the result
        $enrollment = Update-AzPolicyEnrollment -Id $enrollment.Id -DisplayName 'testDisplay'
        $enrollment.DisplayName | Should -Be 'testDisplay'
    }

    It 'Update policy enrollment at MG level by pipeline' {
        # update the enrollment using pipeline / input object
        $enrollment = Get-AzPolicyEnrollment -Name $testEnrollment -Scope $managementGroupScope
        $enrollment.DisplayName = 'testDisplay2'
        $enrollment = $enrollment | Update-AzPolicyEnrollment
        $enrollment.DisplayName | Should -Be 'testDisplay2'
    }

    It 'List policy enrollments at MG level' {
        # make another policy enrollment, ensure both are present in management group scope listing
        $enrollment2 = New-AzPolicyEnrollment -Name $testEnrollment2 -Scope $managementGroupScope -PolicyAssignmentId $assignment.Id -DisplayName $description
        $list = Get-AzPolicyEnrollment -Scope $managementGroupScope | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }
        $list | Should -HaveCount 2
    }

    It 'List policy enrollments by management group Id' {
        # ensure both are present when listing by management group Id
        $list = Get-AzPolicyEnrollment -ManagementGroupId $managementGroup | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }
        $list | Should -HaveCount 2
    }

    It 'IncludeDescendent switch not supported at MG scope' {
        # IncludeDescendent is blocked both when using -Scope with an MG scope string
        # and when using -ManagementGroupId (parameter set error in the latter case)
        {
            Get-AzPolicyEnrollment -Scope $managementGroupScope -IncludeDescendent
        } | Should -Throw $allSwitchNotSupported
    }

    # This test verifies remove of input object with scope parameter removes by name, not id
    It 'Remove of input object with scope parameter removes by name, not id' {
        # list existing enrollments at upper scopes
        $expected = Get-AzPolicyEnrollment -ManagementGroupId $managementGroup

        # remove with invalid scope should fail
        { $expected | Remove-AzPolicyEnrollment -Scope $someScope -Force } | Should -Throw $missingSubscription

        # remove at a different-but-valid scope: use subscription scope (not MG scope, where the
        # enrollments actually live), so name+scope has no match and delete succeeds returning $true
        $expected | Remove-AzPolicyEnrollment -Scope "/subscriptions/$subscriptionId" -Force -PassThru | %{ $_ | Should -Be $true }

        # confirm nothing was removed (our two enrollments are still there)
        (Get-AzPolicyEnrollment -ManagementGroupId $managementGroup | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }).Count | Should -Be 2
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyEnrollment -Name $testEnrollment -Scope $managementGroupScope -Force -PassThru
        $remove = (Remove-AzPolicyEnrollment -Name $testEnrollment2 -Scope $managementGroupScope -Force -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $managementGroupScope -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
