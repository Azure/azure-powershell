# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-SetPolicyDefinitionParameters'

Describe 'Backcompat-SetPolicyDefinitionParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
        $goodObject = Get-AzPolicyDefinition -Builtin | select -First 1
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Set-AzPolicyDefinition } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName } $policyDefinitionNotFound
            Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policyDefinitionNotFound
            Assert-ThrowsContains { Set-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId } $policyDefinitionNotFound
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate parameter combinations starting with -Id
            Assert-ThrowsContains { Set-AzPolicyDefinition -Id $goodId } $policyDefinitionNotFound
            Assert-ThrowsContains { Set-AzPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -ManagementGroupName' {
        {
            # validate parameter combinations starting with -ManagementGroup
            Assert-ThrowsContains { Set-AzPolicyDefinition -ManagementGroupName $someManagementGroup } $missingParameters
            Assert-ThrowsContains { Set-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -SubscriptionId' {
        {
            # validate parameter combinations starting with -SubscriptionId
            Assert-ThrowsContains { Set-AzPolicyDefinition -SubscriptionId $subscriptionId } $missingParameters
        } | Should -Not -Throw
    }
}
