# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'AssignmentOverride'

Describe 'AssignmentOverride' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $newRgName1 = Get-ResourceGroupName
        $newRgName2 = Get-ResourceGroupName
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $resourceSelector = @{Kind = "resourceLocation"; In = @("eastus", "eastus2")}
        $override = @(@{Kind = "policyEffect"; Value = 'Disabled'; Selector = @($resourceSelector)})
        $overrideJson = $override | ConvertTo-Json -Depth 100

        # make a policy definition - deny all RGs without a "RequiredTag" tag and assign it
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SampleRequiredTagPolicyDefinition.json" -Description $description
    }

    It 'Create assignment with override' {
        # validate assignment contains the selector
        $policyAssignment = $policyDefinition | New-AzPolicyAssignment -Name $policyAssName -Override $override -Description $description
        $policyAssignment.Override[0].Kind | Should -Be $override[0].Kind
        $policyAssignment.Override[0].Value | Should -Be $override[0].Value
        $policyAssignment.Override[0].Selector[0].Kind | Should -Be $override[0].Selector[0].Kind
        $policyAssignment.Override[0].Selector[0].In | Should -Be $override[0].Selector[0].In
        $policyAssignment.Override[0].Selector[0].NotIn | Should -BeNull

        # validate assignment contains the selector after round trip
        $policyAssignment = Get-AzPolicyAssignment -Name $policyAssName
        $policyAssignment.Override[0].Kind | Should -Be $override[0].Kind
        $policyAssignment.Override[0].Value | Should -Be $override[0].Value
        $policyAssignment.Override[0].Selector[0].Kind | Should -Be $override[0].Selector[0].Kind
        $policyAssignment.Override[0].Selector[0].In | Should -Be $override[0].Selector[0].In
        $policyAssignment.Override[0].Selector[0].NotIn | Should -BeNull
    }

    It 'Validate override operation' {
        # creating an RG without the required tag should fail in locations outside of In since policy is deny without override
        { New-ResourceGroup -Location 'westus' -Name $newRgName1 } | Should -Throw $disallowedByPolicy

        # creating RG without the required tag should succeed in In locations, since override disables the policy effect
        { New-ResourceGroup -Location 'eastus' -Name $newRgName1 } | Should -Not -Throw
        $rg = Get-ResourceGroup -Name $newRgName1
        $rg.Location | Should -Be 'eastus'
    }

    It 'Update assignment with override' {
        # change In to NotIn
        $override[0].Selector[0].Remove('In')
        $override[0].Selector[0].NotIn = @("eastus", "eastus2")
        $policyAssignment = Update-AzPolicyAssignment -Name $policyAssName -Override $override

        # validate assignment contains the selector
        $policyAssignment.Override[0].Kind | Should -Be $override[0].Kind
        $policyAssignment.Override[0].Value | Should -Be $override[0].Value
        $policyAssignment.Override[0].Selector[0].Kind | Should -Be $override[0].Selector[0].Kind
        $policyAssignment.Override[0].Selector[0].In | Should -BeNull
        $policyAssignment.Override[0].Selector[0].NotIn | Should -Be $override[0].Selector[0].NotIn

        # validate assignment contains the selector after round trip
        $policyAssignment = Get-AzPolicyAssignment -Name $policyAssName
        $policyAssignment.Override[0].Kind | Should -Be $override[0].Kind
        $policyAssignment.Override[0].Value | Should -Be $override[0].Value
        $policyAssignment.Override[0].Selector[0].Kind | Should -Be $override[0].Selector[0].Kind
        $policyAssignment.Override[0].Selector[0].In | Should -BeNull
        $policyAssignment.Override[0].Selector[0].NotIn | Should -Be $override[0].Selector[0].NotIn
    }

    It 'Validate updated override operation' {
        # creating RG without the required tag should fail in NotIn locations, since policy is deny with no override
        { New-ResourceGroup -Location 'eastus2' -Name $newRgName2 } | Should -Throw $disallowedByPolicy

        # creating an RG without the required tag in locations other than NotIn should work since the policy override disables the deny effect
        { New-ResourceGroup -Location 'westus2' -Name $newRgName2 } | Should -Not -Throw
        $rg = Get-ResourceGroup -Name $newRgName2
        $rg.Location | Should -Be 'westus2'
    }

    AfterAll {
        # clean up RGs
        Remove-ResourceGroup -Name $newRgName1
        Remove-ResourceGroup -Name $newRgName2

        # remove the assignment
        $remove = (Remove-AzPolicyAssignment -Name $policyAssName -PassThru)

        # cleanup any/all subscription-level assignments left behind
        foreach ($assignment in Get-AzPolicyAssignment | Where-Object { $_.Scope -like '/subscriptions*' }) {
            $remove = ($assignment | Remove-AzPolicyAssignment -PassThru) -and $remove
        }

        # remove the policy defintion
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove

        # validate
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
