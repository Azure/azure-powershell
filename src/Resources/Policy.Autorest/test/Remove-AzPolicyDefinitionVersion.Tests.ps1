# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicyDefinitionVersion'

Describe 'RemovePolicyDefinitionVersion' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
        $goodMgId = "$managementGroupScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    }

    It 'Remove-AzPolicyDefinition -Version' {
        {
            Remove-AzPolicyDefinition
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyDefinition -Name <nonexistent> -Version <missing>' {
        {
            Remove-AzPolicyDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyDefinition -Id <nonexistent> -Version <missing>' {
        {
            Remove-AzPolicyDefinition -Id $someId -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyDefinition -Name -Version -Force' {
        {
            Remove-AzPolicyDefinition -Name $someName -Version $someVersion -Force
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Remove-AzPolicyDefinition -Name -ManagementGroupName -Version' {
        {
            Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -Version $someVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -SubscriptionId -Version' {
        {
            Remove-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -Version $someVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -Id -Version -Force' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -Version $someVersion -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Id -Version -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -Version $someVersion -ManagementGroupName $managementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Id -Version -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -Version $someVersion -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Id -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Name $someName -Version $someVersion -Force -ManagementGroupName $managementGroup
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Remove-AzPolicyDefinition -Name -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Name $someName -Version $someVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Remove-AzPolicyDefinition -Name -Version -Force -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -Version $someVersion -Force -PassThru
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Remove-AzPolicyDefinition -Name -ManagementGroupName -SubscriptionId -Version' {
        {
            Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -ManagementGroupName -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -Version $someVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'RemovePolicyDefinition -Id <missing> -Version' {
        {
            Remove-AzPolicyDefinition -Id -Version $someVersion 
        } | Should -Throw $missingAnArgument
    }

    It 'RemovePolicyDefinition -Id -Version' {
        {
            Remove-AzPolicyDefinition -Id $goodId -Version $someVersion 
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Id -Version -Force' {
        {
            Remove-AzPolicyDefinition -Id $goodId -Version $someVersion -Force
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Remove-AzPolicyDefinition -MgId -Version -Force' {
        {
            Remove-AzPolicyDefinition -Id $goodMgId -Version $someVersion -Force
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'RemovePolicyDefinition -Id -Version -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Id $someId -Version $someVersion -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -Id -SubscriptionId -Version' {
        {
            Remove-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId -Version $someVersion 
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -Id -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -Force -ManagementGroupName -Version' {
        {
            Remove-AzPolicyDefinition -Force -ManagementGroupName $someManagementGroup -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -Force -SubscriptionId -Version' {
        {
            Remove-AzPolicyDefinition -Force -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -Version -Force -PassThru' {
        {
            Remove-AzPolicyDefinition -Version $someVersion -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -ManagementGroupName -Version' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -ManagementGroupName -SubscriptionId -Version' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -ManagementGroupName -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Version $someVersion -PassThru
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -SubscriptionId -Version' {
        {
            Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -Version -PassThru' {
        {
            Remove-AzPolicyDefinition -Version $someVersion -PassThru
        } | Should -Throw $missingParameters
    }
}