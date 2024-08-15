# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-GetPolicySetDefinitionParameters'

Describe 'Backcompat-GetPolicySetDefinitionParameters' -Tag 'LiveOnly' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    }

    It 'no parameters' {
        {
            # validate with no parameters
            $ok = Get-AzPolicySetDefinition
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName } $policySetDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policySetDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId } $policySetDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Builtin } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Custom } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -BuiltIn } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Name $someName -Id $someId -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate remaining parameter combinations starting with -Id
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId } $policySetDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -SubscriptionId $subscriptionId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -BuiltIn } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicySetDefinition -Id $goodId -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -ManagementGroupName' {
        {
            # validate remaining parameter combinations starting with -ManagementGroup
            $ok = Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup
            Assert-ThrowsContains { Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
            $ok = Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn
            $ok = Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Custom
            Assert-ThrowsContains { Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -SubscriptionId' {
        {
            # validate remaining parameter combinations starting with -SubscriptionId
            $ok = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId
            $ok = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn
            $ok = Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Custom
            Assert-ThrowsContains { Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Builtin' {
        {
            # validate remaining parameter combinations starting with -BuiltIn
            $ok = Get-AzPolicySetDefinition -BuiltIn
            Assert-ThrowsContains { Get-AzPolicySetDefinition -BuiltIn -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Custom' {
        {
            # validate remaining parameter combinations starting with -Custom
            $ok = Get-AzPolicySetDefinition -Custom
        } | Should -Not -Throw
    }
}
