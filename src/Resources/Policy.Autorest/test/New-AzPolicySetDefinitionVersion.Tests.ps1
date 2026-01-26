# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicySetDefinitionVersion'

Describe 'NewPolicySetDefinitionVersion' {

    It 'New-AzPolicySetDefinitionVersion' {
        {
            New-AzPolicySetDefinitionVersion
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinitionVersion -Name' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -Version' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -ManagementGroupName' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -ManagementGroupName -Version' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $authorizationFailed
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -SubscriptionId' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -SubscriptionId -Version' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -ManagementGroupName -SubscriptionId -Version' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -Version <missing>' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -Version
        } | Should -Throw $missingAnArgument
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -Version <invalid version>' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -Version $someName
        } | Should -Throw $invalidVersionIdentifier
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -Version <valid version>' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'New-AzPolicySetDefinitionVersion -Name -PolicyDefinition -Version <valid preview version>' {
        {
            New-AzPolicySetDefinitionVersion -Name $someName -PolicyDefinition $someJsonArray -Version $somePreviewVersion
        } | Should -Throw $policySetDefinitionNotFound
    }
}