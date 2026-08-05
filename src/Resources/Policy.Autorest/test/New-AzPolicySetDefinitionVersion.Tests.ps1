# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicySetDefinitionVersion'

Describe 'NewPolicySetDefinitionVersion' {

    It 'New-AzPolicySetDefinition -Version' {
        {
            New-AzPolicySetDefinition -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinition -Name -Version' {
        {
            New-AzPolicySetDefinition -Name $someName -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -Version' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version $someNewVersion
        } | Should -Throw $invalidPolicySetDefinitionRequest
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -ManagementGroupName -Version' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -Version $someNewVersion
        } | Should -Throw $authorizationFailed
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -SubscriptionId -Version' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $invalidPolicySetDefinitionRequest
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -ManagementGroupName -SubscriptionId -Version' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicySetDefinition -PolicyDefinition -Version' {
        {
            New-AzPolicySetDefinition -PolicyDefinition $someJsonArray -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -Version <invalid version>' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version $someName
        } | Should -Throw $invalidVersionIdentifier
    }

    It 'New-AzPolicySetDefinition -Name -PolicyDefinition -Version <missing>' {
        {
            New-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version
        } | Should -Throw $missingAnArgument
    }
}