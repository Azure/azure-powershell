# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyExemptionResourceSelector'

Describe 'PolicyExemptionResourceSelector' {

    BeforeAll {
        # setup
        $subScope = "/subscriptions/$subscriptionId"
        $testPA = Get-ResourceName
        $testExemption = Get-ResourceName
        $resourceSelector = @(@{ Name = 'regions'; Selector = @(@{ Kind = 'resourceLocation'; In = @('northeurope', 'uksouth') }) })

        # Get built-in Audit VMs that do not use managed disks
        $policy = Get-AzPolicyDefinition -Id '/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d'

        # assign the policy definition to the subscription without enforcing it
        $assignment = New-AzPolicyAssignment -Name $testPA -Scope $subScope -PolicyDefinition $policy -Description $description -EnforcementMode DoNotEnforce

        # the number of resource selectors, whether the service returns none as null or as an empty array
        function Get-Count($Value) {
            @($Value | Where-Object { $_ }).Count
        }

        # validate the exemption still has the resource selectors it was created with
        function Assert-OriginalResourceSelector($Exemption) {
            Get-Count $Exemption.ResourceSelector | Should -Be 1
            $Exemption.ResourceSelector[0].Name | Should -Be $resourceSelector[0].Name
            $Exemption.ResourceSelector[0].Selector[0].Kind | Should -Be $resourceSelector[0].Selector[0].Kind
            $Exemption.ResourceSelector[0].Selector[0].In | Should -Be $resourceSelector[0].Selector[0].In
        }
    }

    It 'Make policy exemption with resource selectors' {
        # exempt the subscription from the assignment
        $actual = New-AzPolicyExemption -Name $testExemption -PolicyAssignment $assignment -Scope $subScope -ExemptionCategory Waiver -Description $description -ResourceSelector $resourceSelector
        $actual.Name | Should -Be $testExemption
        $actual.PolicyAssignmentId | Should -Be $assignment.Id
        Assert-OriginalResourceSelector $actual

        # get it back and validate
        $expected = Get-AzPolicyExemption -Name $testExemption -Scope $subScope
        Assert-OriginalResourceSelector $expected
    }

    It 'Update policy exemption by name keeps resource selectors' {
        # update an unrelated property, validate resource selectors are neither dropped from the response nor from the backend
        $updateResult = Update-AzPolicyExemption -Name $testExemption -Scope $subScope -DisplayName 'testDisplay'
        $updateResult.DisplayName | Should -Be 'testDisplay'
        Assert-OriginalResourceSelector $updateResult

        $actual = Get-AzPolicyExemption -Name $testExemption -Scope $subScope
        $actual.DisplayName | Should -Be 'testDisplay'
        Assert-OriginalResourceSelector $actual
    }

    It 'Update policy exemption by Id keeps resource selectors' {
        $exemption = Get-AzPolicyExemption -Name $testExemption -Scope $subScope
        $updateResult = Update-AzPolicyExemption -Id $exemption.Id -ExemptionCategory Mitigated
        $updateResult.ExemptionCategory | Should -Be 'Mitigated'
        Assert-OriginalResourceSelector $updateResult

        $actual = Get-AzPolicyExemption -Id $exemption.Id
        $actual.ExemptionCategory | Should -Be 'Mitigated'
        Assert-OriginalResourceSelector $actual
    }

    It 'Update policy exemption with new resource selectors' {
        # specified values replace the existing ones
        $newResourceSelector = @(@{ Name = 'newRegions'; Selector = @(@{ Kind = 'resourceLocation'; In = @('uksouth') }) })
        $null = Update-AzPolicyExemption -Name $testExemption -Scope $subScope -ResourceSelector $newResourceSelector

        $actual = Get-AzPolicyExemption -Name $testExemption -Scope $subScope
        Get-Count $actual.ResourceSelector | Should -Be 1
        $actual.ResourceSelector[0].Name | Should -Be $newResourceSelector[0].Name
        $actual.ResourceSelector[0].Selector[0].In | Should -Be $newResourceSelector[0].Selector[0].In

        # the other properties are kept
        $actual.DisplayName | Should -Be 'testDisplay'
        $actual.ExemptionCategory | Should -Be 'Mitigated'
    }

    It 'Update policy exemption with empty resource selectors' {
        # an empty collection clears the existing ones
        $null = Update-AzPolicyExemption -Name $testExemption -Scope $subScope -ResourceSelector @()

        $actual = Get-AzPolicyExemption -Name $testExemption -Scope $subScope
        Get-Count $actual.ResourceSelector | Should -Be 0
        $actual.DisplayName | Should -Be 'testDisplay'
    }

    AfterAll {
        # clean up
        $remove = Remove-AzPolicyExemption -Name $testExemption -Scope $subScope -Force -PassThru
        $remove = (Remove-AzPolicyAssignment -Name $testPA -Scope $subScope -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
