# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-SetPolicyExemptionParameters'

Describe 'Backcompat-SetPolicyExemptionParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyExemptions/$someName"
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Set-AzPolicyExemption } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName } $policyExemptionNotFound
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -Scope $goodScope } $policyExemptionNotFound
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -DisplayName $someDisplayName } $policyExemptionNotFound
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -Description $description } $policyExemptionNotFound
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -Metadata $metadata } $policyExemptionNotFound
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyExemption -Name $someName -Scope $someScope -ExemptionCategory $someName } $invalidParameterValue
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Scope' {
        {
            # validate parameter combinations starting with -Scope
            Assert-ThrowsContains { Set-AzPolicyExemption -Scope $someScope } $missingParameters
            Assert-ThrowsContains { Set-AzPolicyExemption -Scope $someScope -ExemptionCategory Waiver } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            #validation parameter combinations starting with -Id
            Assert-ThrowsContains { Set-AzPolicyExemption -Id $goodId } $policyExemptionNotFound
            Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -Scope $someScope } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -Name $someName } $parameterSetError
            #Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -DisplayName $someDisplayName } $missingSubscription
            Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -DisplayName $someDisplayName } $policyExemptionNotFound
            #Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -Description $description } $missingSubscription
            Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -Metadata $metadata } $policyExemptionNotFound
            #Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -Description $description } $missingSubscription
            Assert-ThrowsContains { Set-AzPolicyExemption -Id $someId -Metadata $metadata } $policyExemptionNotFound
        } | Should -Not -Throw
    }
}
