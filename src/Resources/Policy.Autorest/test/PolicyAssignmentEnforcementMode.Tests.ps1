# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentEnforcementMode'

Describe 'PolicyAssignmentEnforcementMode' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $subScope = "/subscriptions/$subscriptionId"
        $policyName = Get-ResourceName
        $testDoNotEnforce = Get-ResourceName
        $testDefault = Get-ResourceName
        $testEnroll = Get-ResourceName
        $location = $env.location

        # make a new resource group and policy definition
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description

        # assign the policy definition to the resource group
        $actual = New-AzPolicyAssignment -Name $testDoNotEnforce -PolicyDefinition $policy -Scope $rgScope -Description $description -Location $location -EnforcementMode DoNotEnforce
    }

    It 'Make a policy assignment' {
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'

        $actual.Location | Should -Be $location

        # get the assignment
        $expected = Get-AzPolicyAssignment -Name $testDoNotEnforce -Scope $rgScope

        # validate results
        $expected.Name | Should -Be $actual.Name
        $expected.Type | Should -Be $actual.Type
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.EnforcementMode | Should -Be $actual.EnforcementMode
        $expected.EnforcementMode | Should -Be $enforcementModeDoNotEnforce
        $expected.Location | Should -Be $actual.Location
    }

    It 'Get policy assignment by Id' {
        # get it back by id and validate
        $actualById = Get-AzPolicyAssignment -Id $actual.Id
        $actual.EnforcementMode | Should -Be $actualById.EnforcementMode
    }

    It 'Update policy assignment enforcement mode by Id' {
        # update the policy assignment, validate enforcement mode is updated correctly with Default enum value.
        $updateResult = Update-AzPolicyAssignment -Id $actual.Id -DisplayName "testDisplay" -EnforcementMode Default
        $updateResult.DisplayName | Should -Be 'testDisplay'
        $updateResult.EnforcementMode | Should -Be $enforcementModeDefault
    }

    It 'Update policy assignment enforcement mode' {
        # update the policy assignment, validate enforcement mode is updated correctly with 'Default' enum as string value.
        $updateResult = Update-AzPolicyAssignment -Id $actual.Id -DisplayName "testDisplay" -EnforcementMode $enforcementModeDefault
        $updateResult.DisplayName | Should -Be 'testDisplay'
        $updateResult.EnforcementMode | Should -Be $enforcementModeDefault
    }

    It 'Make another policy assignment without enforcement mode' {
        # make another policy assignment without an enforcementMode, validate default mode is set
        $withoutEnforcementMode = New-AzPolicyAssignment -Name $testDefault -Scope $rgScope -PolicyDefinition $policy -Description $description
        $withoutEnforcementMode.EnforcementMode | Should -Be $enforcementModeDefault

        # set an enforcement mode to the new assignment using the Update- cmdlet
        $updateResult = Update-AzPolicyAssignment -Id $withoutEnforcementMode.Id -Location $location -EnforcementMode $enforcementModeDoNotEnforce
        $updateResult.EnforcementMode | Should -Be $enforcementModeDoNotEnforce

        # set an enforcement mode to the new assignment using the Update cmdlet enum value and validate
        $updateResult = Update-AzPolicyAssignment -Id $withoutEnforcementMode.Id -Location $location -EnforcementMode DoNotEnforce
        $updateResult.EnforcementMode | Should -Be $enforcementModeDoNotEnforce
    }

    It 'Make another policy assignment with enroll enforcement mode' {
        # make another policy assignment with enroll enforcementMode (currently 01/2026 only supported at sub and MG scope), validate enroll mode is set
        $withEnrollEnforcementMode = New-AzPolicyAssignment -Name $testEnroll -Scope $subScope -PolicyDefinition $policy -Description $description -EnforcementMode Enroll
        $withEnrollEnforcementMode.EnforcementMode | Should -Be $enforcementModeEnroll

        # set an enforcement mode to the new assignment using the Update- cmdlet
        $updateResult = Update-AzPolicyAssignment -Id $withEnrollEnforcementMode.Id -Location $location -EnforcementMode $enforcementModeDoNotEnforce
        $updateResult.EnforcementMode | Should -Be $enforcementModeDoNotEnforce

        # set an enforcement mode to the new assignment using the Update cmdlet enum value and validate
        $updateResult = Update-AzPolicyAssignment -Id $withEnrollEnforcementMode.Id -Location $location -EnforcementMode DoNotEnforce
        $updateResult.EnforcementMode | Should -Be $enforcementModeDoNotEnforce

        # set an enforcement mode back to the new assignment using the Update- cmdlet
        $updateResult = Update-AzPolicyAssignment -Id $withEnrollEnforcementMode.Id -Location $location -EnforcementMode $enforcementModeEnroll
        $updateResult.EnforcementMode | Should -Be $enforcementModeEnroll
    }

    It 'Enforcement mode in policy assignment list' {
        # verify enforcement mode is returned in collection GET
        $list = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -in @($testDoNotEnforce, $testDefault) }
        @($list.EnforcementMode).Count | Should -Be 2

        $list = Get-AzPolicyAssignment -Scope $subScope | ?{ $_.Name -in @($testEnroll) }
        @($list.EnforcementMode).Count | Should -Be 1
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testDoNotEnforce -Scope $rgScope -PassThru
        $remove = (Remove-AzPolicyAssignment -Name $testDefault -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testEnroll -Scope $subScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
