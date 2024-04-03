# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentUserAssignedIdentity'

Describe 'PolicyAssignmentUserAssignedIdentity' {

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
        $userAssignedIdentityId = $env.userAssignedIdentityId
        # assign the policy definition with user MSI to the resource group
        $actual = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $rgScope -Description $description -IdentityType "UserAssigned" -IdentityId $userassignedidentityid -Location $location
    }

    It 'Make a policy assignment at RG scope with user assigned MSI' {
        # get the assignment back
        $expected = Get-AzPolicyAssignment -Name $testPA -Scope $rgScope

        # validate the result
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $policy.Id
        $expected.Scope | Should -Be $rgScope
        $expected.IdentityType | Should -Be 'UserAssigned'
        $expected.IdentityType | Should -Be $actual.IdentityType

        # looks like format of userassigned identities changed in the newer spec: adjusting the test to conform to the new format
        $actualuserassignedidentitieshashtable = $expected.IdentityUserAssignedIdentity.AdditionalProperties
        $actualuserassignedidentityid = $($actualuserassignedidentitieshashtable.keys)
        $actualuserassignedidentityresource = $($actualuserassignedidentitieshashtable.values)[0]

        # validate user assigned identities
        $userAssignedIdentityid | Should -Be $actualuserassignedidentityid
        $actualuserassignedidentityresource.PrincipalId | Should -Not -BeNullOrEmpty
        $actualuserassignedidentityresource.ClientId | Should -Not -BeNullOrEmpty
        $actual.Location | Should -Be $location
        $expected.Location | Should -Be $actual.Location
    }

    It 'Get policy assignment with user assigned MSI by Id' {
        # get it back by id
        $actualById = Get-AzPolicyAssignment -Id $actual.Id
        $actual.Id | Should -Be $actualById.Id

        # validate the results
        $actualById.IdentityType | Should -Be 'UserAssigned'
        $actualbyiduserassignedidentityresource = $($actual.IdentityUserAssignedIdentity.AdditionalProperties.values)[0]
        $actualbyiduserassignedidentityresource.PrincipalId | Should -Not -BeNullOrEmpty
        $actualbyiduserassignedidentityresource.ClientId | Should -Not -BeNullOrEmpty
        $actualById.Location | Should -Be $location
    }

    It 'Update policy assignment with user assigned MSI' {
        # update the policy assignment, validate it still has an identity
        $updateResult = Update-AzPolicyAssignment -Id $actual.Id -DisplayName 'testDisplay'
        $updateResult.DisplayName | Should -Be 'testDisplay'
        $updateResult.IdentityType | Should -Be 'UserAssigned'
        $updateresultuserassignedidentityresource = $($updateresult.IdentityUserAssignedIdentity.AdditionalProperties.values)[0]
        $updateresultuserassignedidentityresource.PrincipalId | Should -Not -BeNullOrEmpty
        $updateresultuserassignedidentityresource.ClientId | Should -Not -BeNullOrEmpty
        $updateResult.Location | Should -Be $location
    }

    It 'Make another policy assignment without MSI then add MSI' {
        # make another policy assignment without an identity
        $withoutIdentityResult = New-AzPolicyAssignment -Name $test2 -Scope $rgScope -PolicyDefinition $policy -Description $description
        $withoutIdentityResult.Identity | Should -BeNull
        $withoutIdentityResult.Location | Should -BeNull

        # add an identity to the new assignment using the update cmdlet
        $updateResult = Update-AzPolicyAssignment -Id $withoutIdentityResult.Id -IdentityType 'UserAssigned' -IdentityId $userassignedidentityid -Location $location
        $updateResult.IdentityType | Should -Be 'UserAssigned'
        $updateresultuserassignedidentityresource = $($updateresult.IdentityUserAssignedIdentity.AdditionalProperties.values)[0]
        $updateresultuserassignedidentityresource.PrincipalId | Should -Not -BeNullOrEmpty
        $updateresultuserassignedidentityresource.ClientId | Should -Not -BeNullOrEmpty
        $updateResult.Location | Should -Be $location
    }

    It 'List policy assignments with user assigned MSI' {
        # verify identity is returned in collection GET
        $list = Get-AzPolicyAssignment -Scope $rgScope | Where-Object{ $_.Name -in @($testPA, $test2) }
        $list.IdentityType | Select -Unique | Should -Be 'UserAssigned'
        $userassignedidentityobject = ($list.IdentityUserAssignedIdentity | Select -Unique)    
        @(($($userassignedidentityobject.AdditionalProperties.values)[0]).PrincipalId | Select -Unique).Count | Should -Be 1
        @(($($userassignedidentityobject.AdditionalProperties.values)[0]).ClientId | Select -Unique).Count | Should -Be 1
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
