# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyEnrollmentCRUDOnPolicySet'

Describe 'PolicyEnrollmentCRUDOnPolicySet' {

    BeforeAll {
        # Get built-in Audit resource location matches resource group location policy
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"
        $testEnrollment = Get-ResourceName
        $testEnrollment2 = Get-ResourceName
        $testPSD = Get-ResourceName
        $testPA = Get-ResourceName

        # EnforcementMode Enroll is only supported at subscription and management group scope
        $subScope = "/subscriptions/$subscriptionId"

        # make a new policy set, then a policy assignment with EnforcementMode=Enroll
        $policyRef = "[{""policyDefinitionId"":""" + $policy.Id + """}]"
        $policySet = New-AzPolicySetDefinition -Name $testPSD -PolicyDefinition $policyRef -DisplayName $description
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicySetDefinition $policySet -Scope $subScope -DisplayName $description -EnforcementMode $enforcementModeEnroll
        # remove metadata added by autorest serializer
        $assignment.Metadata = $null

        # create the policy enrollment at subscription scope targeting the full policy set
        $enrollment = New-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope -PolicyAssignmentId $assignment.Id -DisplayName $description
    }

    It 'Make policy enrollment on policy set definition' {
        $enrollment.Name | Should -Be $testEnrollment
        $enrollment.Type | Should -Be 'Microsoft.Authorization/policyEnrollments'
        $enrollment.PolicyAssignmentId | Should -Be $assignment.Id
        $enrollment.DisplayName | Should -Be $description
        # autorest serializer doesn't support $null Metadata, now checking for empty
        $enrollment.Metadata | Should -BeNull
        $enrollment.PolicyDefinitionReferenceId | Should -BeNull
    }

    It 'Update policy enrollment by pipeline input' {
        $enrollment.DisplayName = 'testDisplay'
        $enrollment.PolicyDefinitionReferenceId = @($policySet.PolicyDefinition[0].policyDefinitionReferenceId)
        $enrollment = $enrollment | Update-AzPolicyEnrollment
        $enrollment.DisplayName | Should -Be 'testDisplay'
        $enrollment.PolicyDefinitionReferenceId | Should -Not -BeNullOrEmpty
        $enrollment.PolicyDefinitionReferenceId | Should -HaveCount 1
        @($enrollment.PolicyDefinitionReferenceId)[0] | Should -Be $policySet.PolicyDefinition[0].policyDefinitionReferenceId
    }

    It 'Update policy enrollment by parameters' {
        # update the policy enrollment using Name+Scope parameters, validate the result
        $enrollment = Update-AzPolicyEnrollment -Name $testEnrollment -Scope $subScope -DisplayName 'testDisplay2'
        $enrollment.DisplayName | Should -Be 'testDisplay2'
        # policy definition reference ids should be preserved from previous update
        $enrollment.PolicyDefinitionReferenceId | Should -Not -BeNullOrEmpty
        $enrollment.PolicyDefinitionReferenceId | Should -HaveCount 1
        @($enrollment.PolicyDefinitionReferenceId)[0] | Should -Be $policySet.PolicyDefinition[0].policyDefinitionReferenceId
    }

    It 'Update policy enrollment to clear the policy definition reference' {
        # clear the policy definition reference via pipeline; @() passes the null-skip guard
        # in Update because ($value -is [array]) is true
        $enrollment.PolicyDefinitionReferenceId = @()
        $enrollment = $enrollment | Update-AzPolicyEnrollment
        # API may return $null or @() for a cleared list — BeNullOrEmpty covers both
        $enrollment.PolicyDefinitionReferenceId | Should -BeNullOrEmpty
    }

    It 'List policy enrollments' {
        # make another policy enrollment, ensure both are present
        $enrollment2 = New-AzPolicyEnrollment -Name $testEnrollment2 -Scope $subScope -PolicyAssignmentId $assignment.Id -DisplayName $description
        $list = Get-AzPolicyEnrollment | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }
        $list | Should -HaveCount 2
    }

    AfterAll {
        # clean up cleanly
        $subScope = "/subscriptions/$subscriptionId"
        $cleanupList = Get-AzPolicyEnrollment -Scope $subScope | ?{ $_.Name -in @($testEnrollment, $testEnrollment2) }

        $remove = $true
        foreach ($enrollment in $cleanupList) {
            $remove = ($enrollment | Remove-AzPolicyEnrollment -Force -PassThru) -and $remove
        }

        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $subScope -PassThru) -and $remove
        $remove = (Remove-AzPolicySetDefinition -Name $testPSD -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
