# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-SetPolicySetDefinitionParameters'

Describe 'Backcompat-SetPolicySetDefinitionParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
        $goodObject = Get-AzPolicySetDefinition -Builtin | select -First 1
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Set-AzPolicySetDefinition } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName } $policySetDefinitionNotFound
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policySetDefinitionNotFound
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId } $policySetDefinitionNotFound
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate parameter combinations starting with -Id
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Id $goodId } $policySetDefinitionNotFound
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -ManagementGroupName' {
        {
            # validate parameter combinations starting with -ManagementGroup
            Assert-ThrowsContains { Set-AzPolicySetDefinition -ManagementGroupName $someManagementGroup } $missingParameters
            Assert-ThrowsContains { Set-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -SubscriptionId' {
        {
            # validate parameter combinations starting with -SubscriptionId
            Assert-ThrowsContains { Set-AzPolicySetDefinition -SubscriptionId $subscriptionId } $missingParameters
        } | Should -Not -Throw
    }
}
