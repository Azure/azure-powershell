# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-PolicyObjectPiping'

Describe 'Backcompat-PolicyObjectPiping' {

    BeforeAll {
        # setup
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $array = @("westus", "eastus")

        # make a policy definition and policy set definition that references it
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -Description $description -BackwardCompatible
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description -BackwardCompatible
    }

    It 'make policy assignment from piped definition' {
        {
            # assign the policy definition to the resource group, get the assignment back and validate
            $actual = Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -BackwardCompatible | New-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -PolicyParameterObject @{'listOfAllowedLocations'=@('westus', 'eastus'); 'effectParam'='Deny'} -Description $description -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-NotNull $actual.Properties.PolicyDefinitionId
            Assert-NotNull $expected.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations
            Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations.value
            Assert-NotNull $expected.Properties.Parameters.effectParam
            Assert-AreEqual 2 $expected.Properties.Parameters.listOfAllowedLocations.value.Length
            Assert-AreEqual "westus" $expected.Properties.Parameters.listOfAllowedLocations.value[0]
            Assert-AreEqual "eastus" $expected.Properties.Parameters.listOfAllowedLocations.value[1]
            Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.value
        } | Should -Not -Throw
    }

    It 'update assignment from piped object' {
        {
            # get assignment by name/scope
            $actual = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible

            # get assignment by Id, update some properties, including parameters
            $assignment = Get-AzPolicyAssignment -Id $actual.ResourceId -BackwardCompatible
            # need to update top-level properties to bind input parameters
            #$assignment.Properties.Parameters.effectParam.value = "Disabled"
            #$assignment.Properties.Parameters.listOfAllowedLocations.value = @("eastus")
            #$assignment.Properties.Description = $updatedDescription
            $assignment.Parameter.effectParam.value = "Disabled"
            $assignment.Parameter.listOfAllowedLocations.value = @("eastus")
            $assignment.Description = $updatedDescription
            $assignment | Set-AzPolicyAssignment -BackwardCompatible

            # get it back and validate the new values
            $assignment = Get-AzPolicyAssignment -Id $actual.ResourceId -BackwardCompatible
            Assert-NotNull $assignment.Properties.Parameters.listOfAllowedLocations
            Assert-NotNull $assignment.Properties.Parameters.effectParam
            Assert-NotNull $assignment.Properties.Parameters.listOfAllowedLocations.value
            Assert-AreEqual 1 $assignment.Properties.Parameters.listOfAllowedLocations.value.Length
            Assert-AreEqual "eastus" $assignment.Properties.Parameters.listOfAllowedLocations.value[0]
            Assert-AreEqual "disabled" $assignment.Properties.Parameters.effectParam.value
            Assert-AreEqual $updatedDescription $assignment.Properties.Description

            # delete the policy assignment
            $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible | Remove-AzPolicyAssignment -BackwardCompatible
            Assert-AreEqual True $remove
        } | Should -Not -Throw
    }

    It 'make policy assignment from piped set definition' {
        {
            # assign the policy set definition to the resource group, get the assignment back and validate
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -BackwardCompatible | New-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -Description $description -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-NotNull $actual.Properties.PolicyDefinitionId
            Assert-NotNull $expected.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
        } | Should -Not -Throw
    }

    It 'update policy definition from piped object' {
        {
            # update the policy definition
            $actual = Get-AzPolicyDefinition -Name $policyDefName -BackwardCompatible | Set-AzPolicyDefinition -Description $updatedDescription -BackwardCompatible
            $expected = Get-AzPolicyDefinition -Name $policyDefName -BackwardCompatible
            Assert-AreEqual $policyDefName $expected.Name
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.ResourceName $actual.ResourceName
            Assert-AreEqual Microsoft.Authorization/policyDefinitions $actual.ResourceType
            Assert-AreEqual $expected.ResourceType $actual.ResourceType
            Assert-NotNull $expected.ResourceId
            Assert-AreEqual $expected.ResourceId $actual.ResourceId
            Assert-AreEqual $updatedDescription $actual.Properties.Description
            Assert-AreEqual $updatedDescription $expected.Properties.Description
        } | Should -Not -Throw
    }

    It 'update policy set definition from piped object' {
        {
            # update the policy set definition
            $actual = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible | Set-AzPolicySetDefinition -Description $updatedDescription -BackwardCompatible
            $expected = Get-AzPolicySetDefinition -Name $policySetDefName -BackwardCompatible
            Assert-AreEqual $policySetDefName $expected.Name
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual $expected.ResourceName $actual.ResourceName
            Assert-AreEqual Microsoft.Authorization/policySetDefinitions $actual.ResourceType
            Assert-AreEqual $expected.ResourceType $actual.ResourceType
            Assert-NotNull $expected.ResourceId
            Assert-AreEqual $expected.ResourceId $actual.ResourceId
            Assert-AreEqual $updatedDescription $actual.Properties.Description
            Assert-AreEqual $updatedDescription $expected.Properties.Description
        } | Should -Not -Throw
    }

    It 'update policy assignment from pipline and command line' {
        {
            # update the policy assignment
            $actual = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible | Set-AzPolicyAssignment -Description $updatedDescription -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-AreEqual $expected.ResourceType $actual.ResourceType
            Assert-NotNull $actual.Properties.PolicyDefinitionId
            Assert-NotNull $expected.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rgScope
            Assert-AreEqual $updatedDescription $actual.Properties.Description
            Assert-AreEqual $updatedDescription $expected.Properties.Description
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rgScope -BackwardCompatible | Remove-AzPolicyAssignment -BackwardCompatible
        $remove = (Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -BackwardCompatible | Remove-AzPolicySetDefinition -Force -BackwardCompatible) -and $remove
        $remove = (Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -BackwardCompatible | Remove-AzPolicyDefinition -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
