# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyDefinitionVersion'

Describe 'NewPolicyDefinitionVersion' {

    It 'New-AzPolicyDefinition -Version' {
        {
            New-AzPolicyDefinition -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinition -Name -Version' {
        {
            New-AzPolicyDefinition -Name $someName -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinition -Name -Policy -Version' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version $someNewVersion
        } | Should -Throw $invalidPolicyRule
    }

    It 'New-AzPolicyDefinition -Name -Policy -ManagementGroupName -Version' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -Version $someNewVersion
        } | Should -Throw $authorizationFailed
    }

    It 'New-AzPolicyDefinition -Name -Policy -SubscriptionId -Version' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $invalidPolicyRule
    }

    It 'New-AzPolicyDefinition -Name -Policy -ManagementGroupName -SubscriptionId -Version' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicyDefinition -Policy -Version' {
        {
            New-AzPolicyDefinition -Policy $someJsonSnippet -Version $someNewVersion
        } | Should -Throw $missingParameters
    }
    
    It 'New-AzPolicyDefinition -Name -Policy -Version <invalid version>' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version $someName
        } | Should -Throw $invalidVersionIdentifier
    }
    
    It 'New-AzPolicyDefinition -Name -Policy -Version <missing>' {
        {
            New-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version
        } | Should -Throw $missingAnArgument
    }
}