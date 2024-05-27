# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-NewPolicyDefinitionParameters'

Describe 'Backcompat-NewPolicyDefinitionParameters' {

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { New-AzPolicyDefinition } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName } $missingParameters
            Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet } $invalidPolicyRule
            Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup } $authorizationFailed
            Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId } $invalidPolicyRule
            Assert-ThrowsContains { New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Policy' {
        {
            # validate remaining parameter combinations starting with -Policy
            Assert-ThrowsContains { New-AzPolicyDefinition -Policy $someJsonSnippet } $missingParameters
        } | Should -Not -Throw
    }
}
