# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-NewPolicySetDefinitionParameters'

Describe 'Backcompat-NewPolicySetDefinitionParameters' {

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { New-AzPolicySetDefinition } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName } $missingParameters
            Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray } $invalidPolicySetDefinitionRequest
            Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup } $authorizationFailed
            Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId } $invalidPolicySetDefinitionRequest
            Assert-ThrowsContains { New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -PolicyDefinition' {
        {
            # validate remaining parameter combinations starting with -PolicyDefinition
            Assert-ThrowsContains { New-AzPolicySetDefinition -PolicyDefinition $someJsonArray } $missingParameters
        } | Should -Not -Throw
    }
}
