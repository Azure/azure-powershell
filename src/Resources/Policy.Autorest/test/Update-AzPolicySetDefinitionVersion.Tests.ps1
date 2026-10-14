# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicySetDefinitionVersion'

Describe 'UpdatePolicySetDefinitionVersion' {
    It 'Update-AzPolicySetDefinition -Name -ManagementGroupName -Version' {
        {
            Update-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $versionRequiresPolicyDefinition
    }

    It 'Update-AzPolicySetDefinition -Name -Version' {
        {
            Update-AzPolicySetDefinition -Name $someName -Version $someOldVersion
        } | Should -Throw $versionRequiresPolicyDefinition
    }

    It 'Update-AzPolicySetDefinition -Name -Version <missing>' {
        {
            Update-AzPolicySetDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -Version' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -ManagementGroupName -Version' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -SubscriptionId -Version' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Id -PolicyDefinition -ManagementGroupName -Version' {
        {
            Update-AzPolicySetDefinition -Id $someId -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -Version $someOldVersion
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -Id -PolicyDefinition -SubscriptionId -Version' {
        {
            Update-AzPolicySetDefinition -Id $someId -PolicyDefinition $someJsonArray -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -ManagementGroupName -SubscriptionId -Version' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someOldVersion
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -PolicyDefinition -Version' {
        {
            Update-AzPolicySetDefinition -PolicyDefinition $someJsonArray -Version $someOldVersion
        } | Should -Throw $missingParameters
    }
    
    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -Version <missing>' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -Version <invalid version>' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version $someName
        } | Should -Throw $invalidVersionIdentifier
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -Version <valid version>' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version $someOldVersion
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Name -PolicyDefinition -Version <valid preview version>' {
        {
            Update-AzPolicySetDefinition -Name $someName -PolicyDefinition $someJsonArray -Version $somePreviewVersion
        } | Should -Throw $policySetDefinitionNotFound
    }
}