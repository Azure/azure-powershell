# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicySetDefinitionVersion'

Describe 'RemovePolicySetDefinitionVersion' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
        $goodMgId = "$managementGroupScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    }

    It 'Remove-AzPolicySetDefinition -Version' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Name -Version <missing>' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Version $someVersion -Force
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -Name -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -ManagementGroupName $managementGroup -Version $someVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Version $someVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force -ManagementGroupName $managementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force -ManagementGroupName $managementGroup -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -Version -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someVersion -Force -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someVersion -Force
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -MgId -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Id $goodMgId -Version $someVersion -Force
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -Id -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }
    
    It 'Remove-AzPolicySetDefinition -Id -Version -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someVersion -Force -PassThru
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -PassThru -Version' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Version $someVersion -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Version $someVersion
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Version $someVersion -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someVersion -PassThru
        } | Should -Throw $missingParameters
    }
}