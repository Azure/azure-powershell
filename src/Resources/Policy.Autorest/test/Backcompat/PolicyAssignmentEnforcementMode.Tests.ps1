# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyAssignmentEnforcementMode'

Describe 'Backcompat-PolicyAssignmentEnforcementMode' {

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
        $policy = New-AzPolicyDefinition -Name $policyName -Policy "$testFilesFolder\SamplePolicyDefinition.json" -Description $description -BackwardCompatible

        # assign the policy definition to the resource group
        $actual = New-AzPolicyAssignment -Name $testDoNotEnforce -PolicyDefinition $policy -Scope $rgScope -Description $description -Location $location -EnforcementMode DoNotEnforce -BackwardCompatible
    }

    It 'make a policy assignment' {
        {
            # get the assignment back and validate
            $expected = Get-AzPolicyAssignment -Name $testDoNotEnforce -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $policy.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
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
            $withoutEnforcementMode = New-AzPolicyAssignment -Name $testDefault -Scope $rgScope -PolicyDefinition $policy -Description $description -BackwardCompatible
            Assert-AreEqual $enforcementModeDefault $withoutEnforcementMode.Properties.EnforcementMode

            # set an enforcement mode to the new assignment using the SET cmdlet
            $setResult = Set-AzPolicyAssignment -Id $withoutEnforcementMode.ResourceId -Location $location -EnforcementMode $enforcementModeDoNotEnforce -BackwardCompatible
            Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode

            # set an enforcement mode to the new assignment using the SET cmdlet enum value and validate
            $setResult = Set-AzPolicyAssignment -Id $withoutEnforcementMode.ResourceId -Location $location -EnforcementMode DoNotEnforce -BackwardCompatible
            Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode
        } | Should -Not -Throw
    }

    It 'make another policy assignment with enroll enforcement mode' {
        {
            # make another policy assignment with enroll enforcementMode (currently 01/2026 only supported at sub and MG scope), validate enroll mode is set
            $withEnrollEnforcementMode = New-AzPolicyAssignment -Name $testEnroll -Scope $subScope -PolicyDefinition $policy -Description $description -Location $location -EnforcementMode $enforcementModeEnroll -BackwardCompatible
            Assert-AreEqual $enforcementModeEnroll $withEnrollEnforcementMode.Properties.EnforcementMode

            # set an enforcement mode to the new assignment using the SET cmdlet
            $setResult = Set-AzPolicyAssignment -Id $withEnrollEnforcementMode.ResourceId -Location $location -EnforcementMode $enforcementModeDoNotEnforce -BackwardCompatible
            Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode

            # set an enforcement mode to the new assignment using the SET cmdlet enum value and validate
            $setResult = Set-AzPolicyAssignment -Id $withEnrollEnforcementMode.ResourceId -Location $location -EnforcementMode DoNotEnforce -BackwardCompatible
            Assert-AreEqual $enforcementModeDoNotEnforce $setResult.Properties.EnforcementMode
            
            # set an enforcement mode back to the new assignment using the Update- cmdlet
            $setResult = Update-AzPolicyAssignment -Id $withEnrollEnforcementMode.Id -Location $location -EnforcementMode $enforcementModeEnroll -BackwardCompatible
            Assert-AreEqual $enforcementModeEnroll $setResult.Properties.EnforcementMode
        } | Should -Not -Throw
    }

    It 'enforcement mode in policy assignment list' {
        {
            # verify enforcement mode is returned in collection GET
            $list = Get-AzPolicyAssignment -Scope $rgScope -BackwardCompatible | ?{ $_.Name -in @($testDoNotEnforce, $testDefault) }
            Assert-AreEqual 2 @($list.Properties.EnforcementMode | Select -Unique).Count
            
            $list = Get-AzPolicyAssignment -Scope $subScope -BackwardCompatible | ?{ $_.Name -in @($testEnroll) }
            Assert-AreEqual 1 @($list.Properties.EnforcementMode | Select -Unique).Count
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testDoNotEnforce -Scope $rgScope -BackwardCompatible
        $remove = (Remove-AzPolicyAssignment -Name $testDefault -Scope $rgScope -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyAssignment -Name $testEnroll -Scope $subScope -BackwardCompatible) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyName -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
