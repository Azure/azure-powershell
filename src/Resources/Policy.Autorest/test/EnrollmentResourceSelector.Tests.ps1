# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'EnrollmentResourceSelector'

Describe 'EnrollmentResourceSelector' -Tag 'LiveOnly' {

    BeforeAll {
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $policyEnrName = Get-ResourceName
        $subScope = "/subscriptions/$subscriptionId"

        # ResourceSelector filters which resources the enrollment applies to
        $resourceSelector = @{Name = "LocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}

        # Enroll mode requires subscription or management group scope
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -Policy "$testFilesFolder\SampleRequiredTagPolicyDefinition.json" -Description $description
        $assignment = New-AzPolicyAssignment -Name $policyAssName -PolicyDefinition $policyDefinition -Scope $subScope -Description $description -EnforcementMode $enforcementModeEnroll
    }

    It 'Create enrollment with resource selector' {
        $enrollment = New-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope -PolicyAssignmentId $assignment.Id -ResourceSelector $resourceSelector -Description $description

        # validate enrollment contains the selector
        $enrollment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $enrollment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $enrollment.ResourceSelector.Selector[0].In | Should -Be $resourceSelector.Selector[0].In
        $enrollment.ResourceSelector.Selector[0].NotIn | Should -BeNull

        # validate selector is preserved after round-trip
        $enrollment = Get-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope
        $enrollment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $enrollment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $enrollment.ResourceSelector.Selector[0].In | Should -Be $resourceSelector.Selector[0].In
        $enrollment.ResourceSelector.Selector[0].NotIn | Should -BeNull
    }

    It 'Update enrollment to change selector from In to NotIn' {
        # change In to NotIn
        $resourceSelector.Selector[0].Remove('In')
        $resourceSelector.Selector[0].NotIn = @("eastus", "eastus2")
        $enrollment = Update-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope -ResourceSelector $resourceSelector

        # validate enrollment contains the updated selector
        $enrollment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $enrollment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $enrollment.ResourceSelector.Selector[0].In | Should -BeNull
        $enrollment.ResourceSelector.Selector[0].NotIn | Should -Be $resourceSelector.Selector[0].NotIn

        # validate selector is preserved after round-trip
        $enrollment = Get-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope
        $enrollment.ResourceSelector.Name | Should -Be $resourceSelector.Name
        $enrollment.ResourceSelector.Selector[0].Kind | Should -Be $resourceSelector.Selector[0].Kind
        $enrollment.ResourceSelector.Selector[0].In | Should -BeNull
        $enrollment.ResourceSelector.Selector[0].NotIn | Should -Be $resourceSelector.Selector[0].NotIn
    }

    It 'Update enrollment with resource type selector' {
        $typeSelector = @{Name = "ResourceTypeSelector"; Selector = @(@{Kind = "resourceType"; In = @("Microsoft.Compute/virtualMachines")})}
        $enrollment = Update-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope -ResourceSelector $typeSelector

        # validate enrollment contains the resource type selector
        $enrollment.ResourceSelector.Name | Should -Be $typeSelector.Name
        $enrollment.ResourceSelector.Selector[0].Kind | Should -Be $typeSelector.Selector[0].Kind
        $enrollment.ResourceSelector.Selector[0].In | Should -Be $typeSelector.Selector[0].In
        $enrollment.ResourceSelector.Selector[0].NotIn | Should -BeNull

        # validate selector is preserved after round-trip
        $enrollment = Get-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope
        $enrollment.ResourceSelector.Name | Should -Be $typeSelector.Name
        $enrollment.ResourceSelector.Selector[0].Kind | Should -Be $typeSelector.Selector[0].Kind
        $enrollment.ResourceSelector.Selector[0].In | Should -Be $typeSelector.Selector[0].In
        $enrollment.ResourceSelector.Selector[0].NotIn | Should -BeNull
    }

    It 'Update enrollment via pipeline preserves resource selector' {
        # get the enrollment and pipe it through Update without changing the selector
        $enrollment = Get-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope
        $existingSelector = $enrollment.ResourceSelector.Name

        $enrollment.DisplayName = 'selectorTest'
        $enrollment = $enrollment | Update-AzPolicyEnrollment

        # selector must be preserved across a pipeline Update
        $enrollment.DisplayName | Should -Be 'selectorTest'
        $enrollment.ResourceSelector.Name | Should -Be $existingSelector
    }

    AfterAll {
        $remove = (Remove-AzPolicyEnrollment -Name $policyEnrName -Scope $subScope -Force -PassThru)
        $remove = (Remove-AzPolicyAssignment -Name $policyAssName -Scope $subScope -PassThru) -and $remove
        $remove = (Remove-AzPolicyDefinition -Name $policyDefName -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
