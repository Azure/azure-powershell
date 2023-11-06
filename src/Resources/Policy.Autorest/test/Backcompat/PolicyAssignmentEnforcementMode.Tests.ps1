# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentEnforcementMode'

Describe 'PolicyAssignmentEnforcementMode' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $rgname = Get-ResourceGroupName
        $policyName = Get-ResourceName
        $location = "westus"

        # make a new resource group and policy definition
        $rg = New-ResourceGroup -Name $rgname -Location $location
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible

        # assign the policy definition to the resource group
        $actual = New-AzPolicyAssignment -Name testPA -PolicyDefinition $policy -Scope $rg.ResourceId -Description $description -Location $location -EnforcementMode DoNotEnforce -BackwardCompatible
    }

    It 'make a policy assignment' {
        {
            # get the assignment back and validate
            $expected = Get-AzPolicyAssignment -Name testPA -Scope $rg.ResourceId -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
            Assert-AreEqual $expected.Properties.EnforcementMode $actual.Properties.EnforcementMode
            Assert-AreEqual $expected.Properties.EnforcementMode $enforcementModeDoNotEnforce
            Assert-AreEqual $location $actual.Location
            Assert-AreEqual $expected.Location $actual.Location
        } | Should -Not -Throw
    }

    It 'get policy assignment by Id' {
        {
            # get it back by id and validate
            $actualById = Get-AzPolicyAssignment -Id $actual.ResourceId -BackwardCompatible
            Assert-AreEqual $actual.Properties.EnforcementMode $actualById.Properties.EnforcementMode
        } | Should -Not -Throw
    }

    It 'update policy assignment enforcement mode by Id' {
        {
            # update the policy assignment, validate enforcement mode is updated correctly with Default enum value.
            $setResult = Set-AzPolicyAssignment -Id $actual.ResourceId -DisplayName "testDisplay" -EnforcementMode Default -BackwardCompatible
            Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
            Assert-AreEqual $enforcementModeDefault $setResult.Properties.EnforcementMode
        } | Should -Not -Throw
    }

    It 'update policy assignment enforcement mode' {
        {
            # update the policy assignment, validate enforcement mode is updated correctly with 'Default' enum as string value.
            $setResult = Set-AzPolicyAssignment -Id $actual.ResourceId -DisplayName "testDisplay" -EnforcementMode $enforcementModeDefault -BackwardCompatible
            Assert-AreEqual "testDisplay" $setResult.Properties.DisplayName
            Assert-AreEqual $enforcementModeDefault $setResult.Properties.EnforcementMode
        } | Should -Not -Throw
    }

    It 'make another policy assignment without enforcement mode' {
        {
            # make another policy assignment without an enforcementMode, validate default mode is set
            $withoutEnforcementMode = New-AzPolicyAssignment -Name test2 -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description -BackwardCompatible
            Assert-AreEqual $enforcementModeDefault $withoutEnforcementMode.Properties.EnforcementMode

            # set an enforcement mode to the new assignment using the SET cmdlet
            $setResult = Set-AzPolicyAssignment -Id $withoutEnforcementMode.ResourceId -Location $location -EnforcementMode $enforcementModeDoNotEnforce -BackwardCompatible
            Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode

            # set an enforcement mode to the new assignment using the SET cmdlet enum value and validate
            $setResult = Set-AzPolicyAssignment -Id $withoutEnforcementMode.ResourceId -Location $location -EnforcementMode DoNotEnforce -BackwardCompatible
            Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode
        } | Should -Not -Throw
    }

    It 'enforcement mode in policy assignment list' {
        {
            # verify enforcement mode is returned in collection GET
            $list = Get-AzPolicyAssignment -Scope $rg.ResourceId -BackwardCompatible | ?{ $_.Name -in @('testPA', 'test2') }
            Assert-AreEqual 2 @($list.Properties.EnforcementMode | Select -Unique).Count
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
