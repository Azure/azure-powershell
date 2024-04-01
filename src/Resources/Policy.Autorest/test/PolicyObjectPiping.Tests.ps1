# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyObjectPiping'

Describe 'PolicyObjectPiping' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $rgname = Get-ResourceGroupName
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $array = @("westus", "eastus")

        # make a policy definition and policy set definition that references it
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -Description $description
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.Id + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description

        # make a policy assignment by piping the policy definition to New-AzPolicyAssignment
        $rg = New-ResourceGroup -Name $rgname -Location "west us"
    }

    It 'Make policy assignment from piped definition' {
        # assign the policy definition to the resource group, get the assignment back and validate
        $actual = Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId | New-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -PolicyParameterObject @{'listOfAllowedLocations'=@('westus', 'eastus'); 'effectParam'='Deny'} -Description $description
        $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $actual.PolicyDefinitionId | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinitionId | Should -Not -BeNullOrEmpty
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.Scope | Should -Be $rg.ResourceId
        $expected.Parameter.listOfAllowedLocations | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations.value | Should -Not -BeNullOrEmpty
        $expected.Parameter.effectParam | Should -Not -BeNullOrEmpty
        $expected.Parameter.listOfAllowedLocations.value | Should -HaveCount 2
        $expected.Parameter.listOfAllowedLocations.value[0] | Should -Be 'westus'
        $expected.Parameter.listOfAllowedLocations.value[1] | Should -Be 'eastus'
        $expected.Parameter.effectParam.value | Should -Be 'deny'
    }

    It 'Update assignment from piped object' {
        # get assignment by name/scope
        $actual = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId

        # get assignment by Id, update some properties, including parameters
        $assignment = Get-AzPolicyAssignment -Id $actual.Id
        # need to update top-level properties to bind input parameters
        $assignment.Parameter.effectParam.value = 'Disabled'
        $assignment.Parameter.listOfAllowedLocations.value = @('eastus')
        $assignment.Description = $updatedDescription
        $assignment | Update-AzPolicyAssignment

        # get it back and validate the new values
        $assignment = Get-AzPolicyAssignment -Id $actual.Id
        $assignment.Parameter.listOfAllowedLocations | Should -Not -BeNullOrEmpty
        $assignment.Parameter.effectParam | Should -Not -BeNullOrEmpty
        $assignment.Parameter.listOfAllowedLocations.value | Should -Not -BeNullOrEmpty
        $assignment.Parameter.listOfAllowedLocations.value | Should -HaveCount 1
        $assignment.Parameter.listOfAllowedLocations.value[0] | Should -Be 'eastus'
        $assignment.Parameter.effectParam.value | Should -Be 'disabled'
        $assignment.Description | Should -Be $updatedDescription

        # delete the policy assignment
        $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId | Remove-AzPolicyAssignment -PassThru
        $remove | Should -Be $true
    }

    It 'Make policy assignment from piped set definition' {
        # assign the policy set definition to the resource group, get the assignment back and validate
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId | New-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -Description $description
        $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $actual.PolicyDefinitionId | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinitionId | Should -Not -BeNullOrEmpty
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.Scope | Should -Be $rg.ResourceId
    }

    It 'Update policy definition from piped object' {
        # update the policy definition
        $actual = Get-AzPolicyDefinition -Name $policyDefName | Update-AzPolicyDefinition -Description $updatedDescription
        $expected = Get-AzPolicyDefinition -Name $policyDefName
        $policyDefName | Should -Be $expected.Name
        $expected.Name | Should -Be $actual.Name
        $expected.ResourceName | Should -Be $actual.ResourceName
        $actual.Type | Should -Be 'Microsoft.Authorization/policyDefinitions'
        $expected.Type | Should -Be $actual.Type
        $expected.Id | Should -Not -BeNullOrEmpty
        $expected.Id | Should -Be $actual.Id
        $updatedDescription | Should -Be $actual.Description
        $updatedDescription | Should -Be $expected.Description
    }

    It 'Update policy set definition from piped object' {
        # update the policy set definition
        $actual = Get-AzPolicySetDefinition -Name $policySetDefName | Update-AzPolicySetDefinition -Description $updatedDescription
        $expected = Get-AzPolicySetDefinition -Name $policySetDefName
        $policySetDefName | Should -Be $expected.Name
        $expected.Name | Should -Be $actual.Name
        $expected.ResourceName | Should -Be $actual.ResourceName
        $actual.Type | Should -Be 'Microsoft.Authorization/policySetDefinitions'
        $expected.Type | Should -Be $actual.Type
        $expected.Id | Should -Not -BeNullOrEmpty
        $expected.Id | Should -Be $actual.Id
        $updatedDescription | Should -Be $actual.Description
        $updatedDescription | Should -Be $expected.Description
    }

    It 'Update policy assignment from pipline and command line' {
        # update the policy assignment
        $actual = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId | Update-AzPolicyAssignment -Description $updatedDescription
        $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId
        $expected.Name | Should -Be $actual.Name
        $actual.Type | Should -Be 'Microsoft.Authorization/policyAssignments'
        $expected.Type | Should -Be $actual.Type
        $actual.PolicyDefinitionId | Should -Not -BeNullOrEmpty
        $expected.PolicyDefinitionId | Should -Not -BeNullOrEmpty
        $expected.Id | Should -Be $actual.Id
        $expected.PolicyDefinitionId | Should -Be $actual.PolicyDefinitionId
        $expected.Scope | Should -Be $rg.ResourceId
        $updatedDescription | Should -Be $actual.Description
        $updatedDescription | Should -Be $expected.Description
    }

    AfterAll {
        # clean up
        $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId | Remove-AzPolicyAssignment -PassThru
        $remove = (Remove-ResourceGroup -Name $rgname) -and $remove
        $remove = (Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId | Remove-AzPolicySetDefinition -Force -PassThru) -and $remove
        $remove = (Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId | Remove-AzPolicyDefinition -Force -PassThru) -and $remove
        $remove | Should -Be $true

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
