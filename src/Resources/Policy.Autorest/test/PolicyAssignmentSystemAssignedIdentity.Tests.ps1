# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentSystemAssignedIdentity'

Describe 'PolicyAssignmentSystemAssignedIdentity' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $policyName = Get-ResourceName
        $testPA = Get-ResourceName
        $test2 = Get-ResourceName
        $location = $env.location

        # make a new resource group and policy definition
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description
        # assign the policy definition with system MSI to the resource group
        $actual = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $rgScope -Description $description -IdentityType SystemAssigned -Location $location
    }

    It 'Make a policy assignment at RG scope with MSI' {
        # get the assignment back
        $expected = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # validate the results
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be Microsoft.Authorization/policyAssignments
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.IdentityType | Should -Be 'SystemAssigned'
        $expected.IdentityPrincipalId | Should -Not -BeNullOrEmpty
        $expected.IdentityTenantId | Should -Not -BeNullOrEmpty
        $location | Should -Be $actual.Location
        $expected.Location | Should -Be $actual.Location
    }

    It 'Get policy assignment by Id' {
        # get it by id
        $actualById = Get-AzPolicyAssignment -Id $actual.Id

        # validate the results
        $actualById.Id | Should -Be $actual.Id
        $actualById.IdentityType | Should -Be 'SystemAssigned'
        $actualById.IdentityPrincipalId | Should -Not -BeNullOrEmpty
        $actualById.IdentityTenantId | Should -Not -BeNullOrEmpty
        $actualById.Location | Should -Be $location
    }

    It 'Update policy assignment' {
        # update the policy assignment
        $updateResult = Update-AzPolicyAssignment -Id $actual.Id -DisplayName "testDisplay"

        # validate it still has an identity
        $updateResult.DisplayName | Should -Be 'testDisplay'
        $updateResult.IdentityType | Should -Be 'SystemAssigned'
        $updateResult.IdentityPrincipalId | Should -Not -BeNullOrEmpty
        $updateResult.IdentityTenantId | Should -Not -BeNullOrEmpty
        $updateResult.Location | Should -Be $location
    }

    It 'Make another policy assignment without MSI' {
        # make another policy assignment without an identity
        $withoutIdentityResult = New-AzPolicyAssignment -Name $test2 -Scope $rgScope -PolicyDefinition $policy -Description $description

        # validate it does not have an identity
        $withoutIdentityResult.Identity | Should -BeNull

        $withoutIdentityResult.Location | Should -BeNull

        # add an identity to the new assignment using update
        $updateResult = Update-AzPolicyAssignment -Id $withoutIdentityResult.Id -IdentityType SystemAssigned -Location $location
        $updateResult.IdentityType | Should -Be 'SystemAssigned'
        $updateResult.IdentityPrincipalId | Should -Not -BeNullOrEmpty
        $updateResult.IdentityTenantId | Should -Not -BeNullOrEmpty
        $updateResult.Location | Should -Be $location
    }

    It 'List policy assignment with MSI' {
        # verify identity is returned in collection GET
        $list = Get-AzPolicyAssignment -Scope $rgScope | ?{ $_.Name -in @($testPA, $test2) }
        ($list.IdentityType | Select -Unique) | Should -Be 'SystemAssigned'
        @($list.IdentityPrincipalId | Select -Unique).Count | Should -Be 2
        @($list.IdentityTenantId | Select -Unique).Count | Should -Be 1
        $list.IdentityTenantId | Select -Unique | Should -Not -BeNullOrEmpty
        ($list.Location | Select -Unique) | Should -Be $location
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testPA -Scope $rgScope -PassThru
        $remove = (Remove-AzPolicyAssignment -Name $test2 -Scope $rgScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
