# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyDefinitionVersion'

Describe 'NewPolicyDefinitionVersion' {

    It 'New-AzPolicyDefinitionVersion' {
        {
            New-AzPolicyDefinitionVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinitionVersion -Name' {
        {
            New-AzPolicyDefinitionVersion -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -Version' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -Version $someOldVersion
        } | Should -Throw $PolicyDefinitionNotFound
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -ManagementGroupName' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -ManagementGroupName -Version' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $authorizationFailed
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -SubscriptionId' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -SubscriptionId -Version' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $PolicyDefinitionNotFound
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -ManagementGroupName -SubscriptionId -Version' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicyDefinitionVersion -Policy' {
        {
            New-AzPolicyDefinitionVersion -Policy $someJsonSnippet
        } | Should -Throw $missingParameters
    }
    
    It 'New-AzPolicyDefinitionVersion -Policy -Version' {
        {
            New-AzPolicyDefinitionVersion -Policy $someJsonSnippet -Version $someOldVersion
        } | Should -Throw $missingParameters
    }
    
    It 'New-AzPolicyDefinitionVersion -Name -Policy -Version <missing>' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -Version
        } | Should -Throw $missingAnArgument
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -Version <invalid version>' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -Version $someName
        } | Should -Throw $policyDefinitionNotFound
    }
    
    It 'New-AzPolicyDefinitionVersion -Name -Policy -Version <valid version>' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -Version $someOldVersion
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'New-AzPolicyDefinitionVersion -Name -Policy -Version <valid preview version>' {
        {
            New-AzPolicyDefinitionVersion -Name $someName -Policy $someJsonSnippet -Version $somePreviewVersion
        } | Should -Throw $policyDefinitionNotFound
    }
}