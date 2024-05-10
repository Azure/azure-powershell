# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-RemovePolicySetDefinitionParameters'

Describe 'Backcompat-RemovePolicySetDefinitionParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
        $goodObject = Get-AzPolicySetDefinition -Builtin -BackwardCompatible | select -First 1
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Remove-AzPolicySetDefinition } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Remove-AzPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
            $ok = Remove-AzPolicySetDefinition -Name $someName -Force -BackwardCompatible
            Assert-AreEqual True $ok
            $ok = Remove-AzPolicySetDefinition -Name $someName -ManagementGroupName $managementGroup -Force -BackwardCompatible
            Assert-AreEqual True $ok
            $ok = Remove-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -Force -BackwardCompatible
            Assert-AreEqual True $ok
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate parameter combinations starting with -Id
            $ok = Remove-AzPolicySetDefinition -Id $goodId -Force -BackwardCompatible
            Assert-AreEqual True $ok
            Assert-ThrowsContains { Remove-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Remove-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -ManagementGroupName' {
        {
            # validate parameter combinations starting with -ManagementGroup
            Assert-ThrowsContains { Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -SubscriptionId' {
        {
            # validate parameter combinations starting with -SubscriptionId
            #Assert-ThrowsContains { Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Force } $httpMethodNotSupported
            # Improved error response
            Assert-ThrowsContains { Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Force } $missingParameters
        } | Should -Not -Throw
    }
}
