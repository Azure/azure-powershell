# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyDefinitionVersion'

Describe 'UpdatePolicyDefinitionVersion' {

    It 'Update-AzPolicyDefinition -Id -Version' {
        {
            Update-AzPolicyDefinition -Id $someId -Version $someOldVersion
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyDefinition -Name -ManagementGroupName -Version' {
        {
            Update-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyDefinition -Name -Version' {
        {
            Update-AzPolicyDefinition -Name $someName -Version $someOldVersion
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyDefinition -Name -Version <missing>' {
        {
            Update-AzPolicyDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyDefinition -Id -Version <missing>' {
        {
            Update-AzPolicyDefinition -Id $someId -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyDefinition -Name -Policy -ManagementGroupName -Version' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Name -Policy -SubscriptionId -Version' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $PolicyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Name -Id -Policy -Version' {
        {
            Update-AzPolicyDefinition -Name $someName -Id $someId -Policy $someJsonSnippet -Version $someOldVersion
        } | Should -Throw $nameOrIdIdentifier
    }

    It 'Update-AzPolicyDefinition -Id -Policy -ManagementGroupName -Version' {
        {
            Update-AzPolicyDefinition -Id $someId -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $scopeRequiresName
    }

    It 'Update-AzPolicyDefinition -Id -Policy -SubscriptionId -Version' {
        {
            Update-AzPolicyDefinition -Id $someId -Policy $someJsonSnippet -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $scopeRequiresName
    }

    It 'Update-AzPolicyDefinition -Name -Policy -ManagementGroupName -SubscriptionId -Version' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $onlyManagementGroupOrSubscription
    }

    It 'Update-AzPolicyDefinition -Policy -Version' {
        {
            Update-AzPolicyDefinition -Policy $someJsonSnippet -Version $someOldVersion
        } | Should -Throw $versionRequiresNameOrId
    }
    
    It 'Update-AzPolicyDefinition -Name -Policy -Version <missing>' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version
        } | Should -Throw $missingAnArgument
    }
    
    It 'Update-AzPolicyDefinition -Name -Policy -Version <invalid version>' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version $someName
        } | Should -Throw $policyDefinitionNotFound
    }
    
    It 'Update-AzPolicyDefinition -Name -Policy -Version <valid version>' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version $someOldVersion
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Name -Policy -Version <valid preview version>' {
        {
            Update-AzPolicyDefinition -Name $someName -Policy $someJsonSnippet -Version $somePreviewVersion
        } | Should -Throw $policyDefinitionNotFound
    }
}