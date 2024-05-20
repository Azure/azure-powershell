# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicySetDefinition'

Describe 'NewPolicySetDefinition' {

    It 'New-AzPolicySetDefinition' {
        {
            New-AzPolicySetDefinition
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinition -Name' {
        {
            New-AzPolicySetDefinition -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray
        } | Should -Throw $invalidPolicySetDefinitionRequest
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -ManagementGroupName' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup
        } | Should -Throw $authorizationFailed
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -SubscriptionId' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId
        } | Should -Throw $invalidPolicySetDefinitionRequest
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -ManagementGroupName -SubscriptionId' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicySetDefinition -PolicyDefinition' {
        {
            New-AzPolicySetDefinition -PolicyDefinition $someJsonArray
        } | Should -Throw $missingParameters
    }
}