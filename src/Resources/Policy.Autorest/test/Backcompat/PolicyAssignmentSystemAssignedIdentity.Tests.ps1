# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentSystemAssignedIdentity'

Describe 'PolicyAssignmentSystemAssignedIdentity' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $rgname = Get-ResourceGroupName
        $policyName = Get-ResourceName
        $location = "westus"

        # make a new resource group and policy definition
        $rg = New-ResourceGroup -Name $rgname -Location $location
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible
        # assign the policy definition with system MSI to the resource group
        $actual = New-AzPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description -IdentityType SystemAssigned -Location $location -BackwardCompatible
    }

    It 'make a policy assignment at RG scope with MSI' {
        {
            # get the assignment back and validate
            $expected = Get-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
            Assert-AreEqual "SystemAssigned" $expected.Identity.IdentityType
            Assert-NotNull $expected.Identity.PrincipalId
            Assert-NotNull $expected.Identity.TenantId
            Assert-AreEqual $location $actual.Location
            Assert-AreEqual $expected.Location $actual.Location
        } | Should -Not -Throw
    }

    It 'get policy assignment by Id' {
        {
            # get it by id and validate
            $actualById = Get-AzPolicyAssignment -Id $actual.ResourceId -BackwardCompatible
            Assert-AreEqual $actual.ResourceId $actualById.ResourceId
            Assert-AreEqual "SystemAssigned" $actualById.Identity.IdentityType
            Assert-NotNull $actualById.Identity.PrincipalId
            Assert-NotNull $actualById.Identity.TenantId
            Assert-AreEqual $location $actualById.Location
        } | Should -Not -Throw
    }

    It 'update policy assignment' {
        {
            # update the policy assignment, validate it still has an identity
            $setResult = Set-AzPolicyAssignment -Id $actual.ResourceId -DisplayName "testDisplay" -BackwardCompatible
            Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
            Assert-AreEqual "SystemAssigned" $setResult.Identity.IdentityType
            Assert-NotNull $setResult.Identity.PrincipalId
            Assert-NotNull $setResult.Identity.TenantId
            Assert-AreEqual $location $setResult.Location
        } | Should -Not -Throw
    }

    It 'make another policy assignment without MSI' {
        {
            # make another policy assignment without an identity
            $withoutIdentityResult = New-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description -BackwardCompatible
            Assert-Null $withoutIdentityResult.Identity
            Assert-Null $withoutIdentityResult.Location
            # add an identity to the new assignment using set

            $setResult = Set-AzPolicyAssignment -Id $withoutIdentityResult.ResourceId -IdentityType SystemAssigned -Location $location -BackwardCompatible
            Assert-AreEqual "SystemAssigned" $setResult.Identity.IdentityType
            Assert-NotNull $setResult.Identity.PrincipalId
            Assert-NotNull $setResult.Identity.TenantId
            Assert-AreEqual $location $setResult.Location
        } | Should -Not -Throw
    }

    It 'list policy assignment with MSI' {
        {
            # verify identity is returned in collection GET
            $list = Get-AzPolicyAssignment -Scope $rg.ResourceId -BackwardCompatible | ?{ $_.Name -in @('testPA', 'test2') }
            Assert-AreEqual "SystemAssigned" ($list.Identity.IdentityType | Select -Unique)
            Assert-AreEqual 2 @($list.Identity.PrincipalId | Select -Unique).Count
            Assert-AreEqual 1 @($list.Identity.TenantId | Select -Unique).Count
            Assert-NotNull $list.Identity.TenantId | Select -Unique
            Assert-AreEqual $location ($list.Location | Select -Unique)
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId -BackwardCompatible
        $remove = (Remove-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible) -and $remove
        $remove = (Remove-ResourceGroup -Name $rgname -Force) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
