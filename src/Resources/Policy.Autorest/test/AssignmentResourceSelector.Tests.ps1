# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'AssignmentResourceSelector'

Describe 'AssignmentResourceSelector' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $newRgName1 = Get-ResourceGroupName
        $newRgName2 = Get-ResourceGroupName
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $resourceSelector = @{Name = "LocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}

        # make a policy definition - deny all RGs without a "RequiredTag" tag
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SampleRequiredTagPolicyDefinition.json" -Description $description
    }

    It 'Create assignment with resource selector' {
        # assign the policy definition to the resource group, get the assignment back
        $policyAssignment = $policyDefinition | New-AzPolicyAssignment -Name $policyAssName -ResourceSelector $resourceSelector -Description $description

        # validate assignment contains the selector
        $policyAssignment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyAssignment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyAssignment.ResourceSelector.Selector[0].In | Should -Be $resourceSelector.Selector[0].In
        $policyAssignment.ResourceSelector.Selector[0].NotIn | Should -BeNull

        # validate assignment contains the selector after round trip
        $policyAssignment = Get-AzPolicyAssignment -Name $policyAssName
        $policyAssignment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyAssignment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyAssignment.ResourceSelector.Selector[0].In | Should -Be $resourceSelector.Selector[0].In
        $policyAssignment.ResourceSelector.Selector[0].NotIn | Should -BeNull
    }

    It 'Validate selector operation' {
        # creating an RG without the required tag should fail in In locations due to policy since it applies
        { New-ResourceGroup -Location 'eastus' -Name $newRgName1 } | Should -Throw $disallowedByPolicy

        # creating RG without the required tag should work in locations other than In, since policy does not apply
        { New-ResourceGroup -Location 'westus' -Name $newRgName1 } | Should -Not -Throw
        $rg = Get-ResourceGroup -Name $newRgName1
        $rg.Location | Should -Be 'westus'
    }

    It 'Update assignment with resource selector' {
        # change In to NotIn
        $resourceSelector.Selector[0].Remove('In')
        $resourceSelector.Selector[0].NotIn = @("eastus", "eastus2")
        $policyAssignment = Update-AzPolicyAssignment -Name $policyAssName -ResourceSelector $resourceSelector

        # validate assignment contains the selector
        $policyAssignment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyAssignment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyAssignment.ResourceSelector.Selector[0].In | Should -BeNull
        $policyAssignment.ResourceSelector.Selector[0].NotIn | Should -Be $resourceSelector.Selector[0].NotIn

        # validate assignment contains the selector after round trip
        $policyAssignment = Get-AzPolicyAssignment -Name $policyAssName
        $policyAssignment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $policyAssignment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $policyAssignment.ResourceSelector.Selector[0].In | Should -BeNull
        $policyAssignment.ResourceSelector.Selector[0].NotIn | Should -Be $resourceSelector.Selector[0].NotIn
    }

    It 'Validate updated selector operation' {
        # creating an RG without the required tag not in NotIn locations should fail due to policy since it applies
        { New-ResourceGroup -Location 'westus2' -Name $newRgName2 } | Should -Throw $disallowedByPolicy

        # creating RG without the required tag should work in NotIn locations, since policy does not apply
        { New-ResourceGroup -Location 'eastus2' -Name $newRgName2 } | Should -Not -Throw
        $rg = Get-ResourceGroup -Name $newRgName2
        $rg.Location | Should -Be 'eastus2'
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
