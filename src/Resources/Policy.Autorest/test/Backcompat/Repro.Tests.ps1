# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Repro'

# Repro of crash in New-AzPolicyAssignment proxy cmdlet
Describe 'Repro' -Tag 'LiveOnly' {

    BeforeAll {
        # setup
        $rgname = Get-ResourceGroupName
        $policySetDefName = Get-ResourceName
        $policyDefName = Get-ResourceName
        $policyAssName = Get-ResourceName
        $subscriptionId = (Get-AzContext).Subscription.Id
        $array = @("westus", "eastus")

        # make a policy definition and policy set definition that references it
        $policyDefinition = New-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -Policy "$testFilesFolder\SamplePolicyDefinitionObject.json" -Description $description -BackwardCompatible
        $policySet = "[{""policyDefinitionId"":""" + $policyDefinition.PolicyDefinitionId + """}]"
        $expected = New-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -PolicyDefinition $policySet -Description $description -BackwardCompatible

        # make a policy assignment by piping the policy definition to New-AzPolicyAssignment
        $rg = New-ResourceGroup -Name $rgname -Location "west us"
    }

    It 'debug repro' -Skip {
        {
            # assign the policy definition to the resource group, get the assignment back and validate
            $actual = Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -BackwardCompatible | New-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -PolicyParameterObject @{'listOfAllowedLocations'=@('westus', 'eastus'); 'effectParam'='Deny'} -Description $description -BackwardCompatible
            $expected = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -BackwardCompatible
            Assert-AreEqual $expected.Name $actual.Name
            Assert-AreEqual Microsoft.Authorization/policyAssignments $actual.ResourceType
            Assert-NotNull $actual.Properties.PolicyDefinitionId
            Assert-NotNull $expected.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.PolicyAssignmentId $actual.PolicyAssignmentId
            Assert-AreEqual $expected.Properties.PolicyDefinitionId $actual.Properties.PolicyDefinitionId
            Assert-AreEqual $expected.Properties.Scope $rg.ResourceId
            Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations
            Assert-NotNull $expected.Properties.Parameters.listOfAllowedLocations.value
            Assert-NotNull $expected.Properties.Parameters.effectParam
            Assert-AreEqual 2 $expected.Properties.Parameters.listOfAllowedLocations.value.Length
            Assert-AreEqual "westus" $expected.Properties.Parameters.listOfAllowedLocations.value[0]
            Assert-AreEqual "eastus" $expected.Properties.Parameters.listOfAllowedLocations.value[1]
            Assert-AreEqual "deny" $expected.Properties.Parameters.effectParam.value

            # delete the assignment
            $remove = Get-AzPolicyAssignment -Name $policyAssName -Scope $rg.ResourceId -BackwardCompatible | Remove-AzPolicyAssignment -BackwardCompatible
            Assert-AreEqual True $remove
        } | Should -Not -Throw
    }

    AfterAll {
        # clean up
        $remove = (Remove-ResourceGroup -Name $rgname -Force)
        $remove = (Get-AzPolicySetDefinition -Name $policySetDefName -SubscriptionId $subscriptionId -BackwardCompatible | Remove-AzPolicySetDefinition -Force -BackwardCompatible) -and $remove
        $remove = (Get-AzPolicyDefinition -Name $policyDefName -SubscriptionId $subscriptionId -BackwardCompatible | Remove-AzPolicyDefinition -Force -BackwardCompatible) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
