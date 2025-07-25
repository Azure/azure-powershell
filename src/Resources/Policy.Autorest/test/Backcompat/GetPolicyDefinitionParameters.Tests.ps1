# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-GetPolicyDefinitionParameters'

# $$$ add -Static to existing combinations
Describe 'Backcompat-GetPolicyDefinitionParameters' -Tag 'LiveOnly' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    }

    It 'no parameters' {
        {
            # validate with no parameters
            $ok = Get-AzPolicyDefinition
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName } $policyDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup } $policyDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId } $policyDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Builtin } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Custom } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -BuiltIn } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Name $someName -Id $someId -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate remaining parameter combinations starting with -Id
            Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId } $policyDefinitionNotFound
            Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -SubscriptionId $subscriptionId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -BuiltIn } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -Id $goodId -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -ManagementGroupName' {
        {
            # validate remaining parameter combinations starting with -ManagementGroup
            $ok = Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup
            Assert-ThrowsContains { Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
            $ok = Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn
            $ok = Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Custom
            Assert-ThrowsContains { Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -SubscriptionId' {
        {
            # validate remaining parameter combinations starting with -SubscriptionId
            $ok = Get-AzPolicyDefinition -SubscriptionId $subscriptionId
            $ok = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn
            $ok = Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Custom
            Assert-ThrowsContains { Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Builtin' {
        {
            # validate remaining parameter combinations starting with -BuiltIn
            $ok = Get-AzPolicyDefinition -BuiltIn
            Assert-ThrowsContains { Get-AzPolicyDefinition -BuiltIn -Custom } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyDefinition -BuiltIn -Custom -Static } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Custom' {
        {
            # validate remaining parameter combinations starting with -Custom
            $ok = Get-AzPolicyDefinition -Custom
            Assert-ThrowsContains { Get-AzPolicyDefinition -Custom -Static } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Static' {
        {
            # validate remaining parameter combinations starting with -Static
            $ok = Get-AzPolicyDefinition -Static
        } | Should -Not -Throw
    }
}
