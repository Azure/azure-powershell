# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyAssignmentOverridesSelectors'

Describe 'PolicyAssignmentOverridesSelectors' {

    BeforeAll {
        # setup
        $subScope = "/subscriptions/$subscriptionId"
        $testPA = Get-ResourceName
        $override = @(@{ Kind = 'policyEffect'; Value = 'Disabled'; Selector = @(@{ Kind = 'resourceLocation'; In = @('northeurope') }) })
        $resourceSelector = @(@{ Name = 'regions'; Selector = @(@{ Kind = 'resourceLocation'; In = @('northeurope', 'uksouth') }) })

        # Get built-in Audit VMs that do not use managed disks
        $policy = Get-AzPolicyDefinition -Id '/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d'

        # the number of overrides or resource selectors, whether the service returns none as null or as an empty array
        function Get-Count($Value) {
            @($Value | Where-Object { $_ }).Count
        }

        # validate the assignment still has the overrides and resource selectors it was created with
        function Assert-OriginalOverridesSelectors($Assignment) {
            Get-Count $Assignment.Override | Should -Be 1
            $Assignment.Override[0].Kind | Should -Be $override[0].Kind
            $Assignment.Override[0].Value | Should -Be $override[0].Value
            $Assignment.Override[0].Selector[0].Kind | Should -Be $override[0].Selector[0].Kind
            $Assignment.Override[0].Selector[0].In | Should -Be $override[0].Selector[0].In
            Get-Count $Assignment.ResourceSelector | Should -Be 1
            $Assignment.ResourceSelector[0].Name | Should -Be $resourceSelector[0].Name
            $Assignment.ResourceSelector[0].Selector[0].Kind | Should -Be $resourceSelector[0].Selector[0].Kind
            $Assignment.ResourceSelector[0].Selector[0].In | Should -Be $resourceSelector[0].Selector[0].In
        }
    }

    It 'Make policy assignment with overrides and resource selectors' {
        # assign the policy definition to the subscription without enforcing it
        $actual = New-AzPolicyAssignment -Name $testPA -Scope $subScope -PolicyDefinition $policy -Description $description -EnforcementMode DoNotEnforce -Override $override -ResourceSelector $resourceSelector
        $actual.Name | Should -Be $testPA
        Assert-OriginalOverridesSelectors $actual

        # get it back and validate
        $expected = Get-AzPolicyAssignment -Name $testPA -Scope $subScope
        Assert-OriginalOverridesSelectors $expected
    }

    It 'Update policy assignment by name keeps overrides and resource selectors' {
        # update an unrelated property, validate overrides and resource selectors are neither dropped from the response nor from the backend
        $updateResult = Update-AzPolicyAssignment -Name $testPA -Scope $subScope -DisplayName 'testDisplay'
        $updateResult.DisplayName | Should -Be 'testDisplay'
        Assert-OriginalOverridesSelectors $updateResult

        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $subScope
        $actual.DisplayName | Should -Be 'testDisplay'
        Assert-OriginalOverridesSelectors $actual
    }

    It 'Update policy assignment by Id keeps overrides and resource selectors' {
        $assignment = Get-AzPolicyAssignment -Name $testPA -Scope $subScope
        $updateResult = Update-AzPolicyAssignment -Id $assignment.Id -Description $updatedDescription
        $updateResult.Description | Should -Be $updatedDescription
        Assert-OriginalOverridesSelectors $updateResult

        $actual = Get-AzPolicyAssignment -Id $assignment.Id
        $actual.Description | Should -Be $updatedDescription
        Assert-OriginalOverridesSelectors $actual
    }

    It 'Update policy assignment from pipeline keeps overrides and resource selectors' {
        $updateResult = Get-AzPolicyAssignment -Name $testPA -Scope $subScope | Update-AzPolicyAssignment -DisplayName 'testDisplay2'
        $updateResult.DisplayName | Should -Be 'testDisplay2'
        Assert-OriginalOverridesSelectors $updateResult

        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $subScope
        $actual.DisplayName | Should -Be 'testDisplay2'
        Assert-OriginalOverridesSelectors $actual
    }

    It 'Update policy assignment with new overrides and resource selectors' {
        # specified values replace the existing ones
        $newOverride = @(@{ Kind = 'policyEffect'; Value = 'Disabled'; Selector = @(@{ Kind = 'resourceLocation'; In = @('uksouth') }) })
        $newResourceSelector = @(@{ Name = 'newRegions'; Selector = @(@{ Kind = 'resourceLocation'; In = @('uksouth') }) })
        $null = Update-AzPolicyAssignment -Name $testPA -Scope $subScope -Override $newOverride -ResourceSelector $newResourceSelector

        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $subScope
        Get-Count $actual.Override | Should -Be 1
        $actual.Override[0].Selector[0].In | Should -Be $newOverride[0].Selector[0].In
        Get-Count $actual.ResourceSelector | Should -Be 1
        $actual.ResourceSelector[0].Name | Should -Be $newResourceSelector[0].Name
        $actual.ResourceSelector[0].Selector[0].In | Should -Be $newResourceSelector[0].Selector[0].In

        # the other properties are kept
        $actual.DisplayName | Should -Be 'testDisplay2'
        $actual.EnforcementMode | Should -Be $enforcementModeDoNotEnforce
    }

    It 'Update policy assignment with empty overrides and resource selectors' {
        # empty collections clear the existing ones
        $null = Update-AzPolicyAssignment -Name $testPA -Scope $subScope -Override @() -ResourceSelector @()

        $actual = Get-AzPolicyAssignment -Name $testPA -Scope $subScope
        Get-Count $actual.Override | Should -Be 0
        Get-Count $actual.ResourceSelector | Should -Be 0
        $actual.DisplayName | Should -Be 'testDisplay2'
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyAssignment -Name $testPA -Scope $subScope -PassThru
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
