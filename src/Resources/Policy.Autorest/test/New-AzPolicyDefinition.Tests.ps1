# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyDefinition'

Describe 'NewPolicyDefinition' {

    It 'New-AzPolicyDefinition' {
        {
            New-AzPolicyDefinition
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinition -Name' {
        {
            New-AzPolicyDefinition -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinition -Name -Policy' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet
        } | Should -Throw $invalidPolicyRule
    }

    It 'New-AzPolicyDefinition -Name -Policy -ManagementGroupName' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup
        } | Should -Throw $authorizationFailed
    }

    It 'New-AzPolicyDefinition -Name -Policy -SubscriptionId' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId
        } | Should -Throw $invalidPolicyRule
    }

    It 'New-AzPolicyDefinition -Name -Policy -ManagementGroupName -SubscriptionId' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicyDefinition -Policy' {
        {
            New-AzPolicyDefinition -Policy $someJsonSnippet
        } | Should -Throw $missingParameters
    }
}