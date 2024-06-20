# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-RemovePolicyDefinitionParameters'

Describe 'Backcompat-RemovePolicyDefinitionParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
        $goodObject = Get-AzPolicyDefinition -Builtin -BackwardCompatible | ?{ $_.Name -like '*test*' -or $_.Properties.Description -like '*test*' } | select -First 1
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Remove-AzPolicyDefinition } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Remove-AzPolicyDefinition -Name $someName -Id $someId } $parameterSetError
            $ok = Remove-AzPolicyDefinition -Name $someName -Force -BackwardCompatible
            Assert-AreEqual True $ok
            $ok = Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -Force -BackwardCompatible
            Assert-AreEqual True $ok
            $ok = Remove-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -Force -BackwardCompatible
            Assert-AreEqual True $ok
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate parameter combinations starting with -Id
            $ok = Remove-AzPolicyDefinition -Id $goodId -Force -BackwardCompatible
            Assert-AreEqual True $ok
            Assert-ThrowsContains { Remove-AzPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Remove-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -ManagementGroupName' {
        {
            # validate parameter combinations starting with -ManagementGroup
            Assert-ThrowsContains { Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -SubscriptionId
            Assert-ThrowsContains { Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Force } $missingParameters
        } | Should -Not -Throw
    }
}
