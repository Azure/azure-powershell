# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'ExemptionResourceSelector'

Describe 'ExemptionResourceSelector' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $newRgName1 = Get-ResourceGroupName
        $newRgName2 = Get-ResourceGroupName
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $policyExmName = Get-ResourceName
        $resourceSelector = @{Name = "LocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}

        # make a policy definition - deny all RGs without a "RequiredTag" tag and assign it
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SampleRequiredTagPolicyDefinition.json" -Description $description
        $policyAssignment = $policyDefinition | New-AzPolicyAssignment -Name $policyAssName -Description $description
    }

    It 'Create exemption with resource selector' {
        # assign the policy definition to the resource group, get the assignment back
        $policyExemption = $policyAssignment | New-AzPolicyExemption -Name $policyExmName -ResourceSelector $resourceSelector -ExemptionCategory Waiver -Description $description

        # validate assignment contains the selector
        $policyExemption.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyExemption.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyExemption.ResourceSelector.Selector[0].In | Should -Be $resourceSelector.Selector[0].In
        $policyExemption.ResourceSelector.Selector[0].NotIn | Should -BeNull

        # validate assignment contains the selector after round trip
        $policyExemption = Get-AzPolicyExemption -Name $policyExmName
        $policyExemption.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyExemption.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyExemption.ResourceSelector.Selector[0].In | Should -Be $resourceSelector.Selector[0].In
        $policyExemption.ResourceSelector.Selector[0].NotIn | Should -BeNull
    }

    It 'Validate selector operation' {
        # creating an RG without the required tag in locations other than In should fail due to policy since the exemption is not selected
        { New-ResourceGroup -Location 'westus' -Name $newRgName1 } | Should -Throw $disallowedByPolicy

        # creating RG without the required tag should work in In locations, since the policy is exempted
        { New-ResourceGroup -Location 'eastus' -Name $newRgName1 } | Should -Not -Throw
        $rg = Get-ResourceGroup -Name $newRgName1
        $rg.Location | Should -Be 'eastus'
    }

    It 'Update exemption with resource selector' {
        # change In to NotIn
        $resourceSelector.Selector[0].Remove('In')
        $resourceSelector.Selector[0].NotIn = @("eastus", "eastus2")
        $policyExemption = Update-AzPolicyExemption -Name $policyExmName -ResourceSelector $resourceSelector

        # validate exemption contains the selector
        $policyExemption.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyExemption.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyExemption.ResourceSelector.Selector[0].In | Should -BeNull
        $policyExemption.ResourceSelector.Selector[0].NotIn | Should -Be $resourceSelector.Selector[0].NotIn

        # validate exemption contains the selector after round trip
        $policyExemption = Get-AzPolicyExemption -Name $policyExmName
        $policyExemption.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyExemption.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyExemption.ResourceSelector.Selector[0].In | Should -BeNull
        $policyExemption.ResourceSelector.Selector[0].NotIn | Should -Be $resourceSelector.Selector[0].NotIn
    }

    It 'Validate updated selector operation' {
        # creating an RG without the required tag in NotIn locations should fail due to policy since it is not exempted
        { New-ResourceGroup -Location 'eastus2' -Name $newRgName2 } | Should -Throw $disallowedByPolicy

        # creating RG without the required tag in locations not in NotIn should work since policy is exempted
        { New-ResourceGroup -Location 'westus2' -Name $newRgName2 } | Should -Not -Throw
        $rg = Get-ResourceGroup -Name $newRgName2
        $rg.Location | Should -Be 'westus2'
    }

    AfterAll {
        # clean up RGs
        Remove-ResourceGroup -Name $newRgName1
        Remove-ResourceGroup -Name $newRgName2

        # remove the exemption and assignment
        $remove = (Remove-AzPolicyExemption -Name $policyExmName -Force -PassThru)
        $remove = (Remove-AzPolicyAssignment -Name $policyAssName -PassThru) -and $remove

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
