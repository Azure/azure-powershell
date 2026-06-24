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
            Remove-AzPolicySetDefinition -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Name -Version <missing>' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Version
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Version $someNewVersion -Force
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -Name -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -ManagementGroupName $managementGroup -Version $someNewVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Version $someNewVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force -ManagementGroupName $managementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Version -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force -ManagementGroupName $managementGroup -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -Version -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Version $someNewVersion -Force -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -Version $someNewVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -Version $someNewVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId -Version $someNewVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someNewVersion
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someNewVersion -Force
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -MgId -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Id $goodMgId -Version $someNewVersion -Force
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -Id -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someNewVersion -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someNewVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }
    
    It 'Remove-AzPolicySetDefinition -Id -Version -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -Version $someNewVersion -Force -PassThru
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Version -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Version -Force' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -Version' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -PassThru -Version' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Version $someNewVersion -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Version $someNewVersion -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId -Version' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Version $someNewVersion
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -Version $someNewVersion -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Version -PassThru' {
        {
            Remove-AzPolicySetDefinition -Version $someNewVersion -PassThru
        } | Should -Throw $missingParameters
    }
}