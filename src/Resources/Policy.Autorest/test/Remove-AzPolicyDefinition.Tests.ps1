# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicyDefinition'

Describe 'RemovePolicyDefinition' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
        $goodObject = Get-AzPolicyDefinition -Builtin | ?{ $_.Name -like '*test*' -or $_.Description -like '*test*' } | select -First 1
    }

    It 'Remove-AzPolicyDefinition' {
        {
            Remove-AzPolicyDefinition
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyDefinition -Name <missing>' {
        {
            Remove-AzPolicyDefinition -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyDefinition -Name' {
        {
            Remove-AzPolicyDefinition -Name $someName
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -Id' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Force' {
        Remove-AzPolicyDefinition -Name $someName -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyDefinition -Name -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -Id -Force' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Id -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Id -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Id -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -Id $someId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -Force -ManagementGroupName' {
        Remove-AzPolicyDefinition -Name $someName -Force -ManagementGroupName $managementGroup | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyDefinition -Name -Force -SubscriptionId' {
        Remove-AzPolicyDefinition -Name $someName -Force -SubscriptionId $subscriptionId | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyDefinition -Name -Force -PassThru' {
        Remove-AzPolicyDefinition -Name $someName -Force -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyDefinition -Name -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyDefinition -Name -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -ManagementGroupName $managementGroup -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyDefinition -Name -SubscriptionId -PassThru' {
        {
            Remove-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'RemovePolicyDefinition -Id <missing>' {
        {
            Remove-AzPolicyDefinition -Id
        } | Should -Throw $missingAnArgument
    }

    It 'RemovePolicyDefinition -Id' {
        {
            Remove-AzPolicyDefinition -Id $goodId
        } | Should -Throw $nonInteractiveMode
    }

    It 'RemovePolicyDefinition -Id -Force' {
        Remove-AzPolicyDefinition -Id $goodId -Force | Should -BeNullOrEmpty
    }

    It 'RemovePolicyDefinition -Id -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -Id -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -Id -SubscriptionId -PassThru' {
        {
            Remove-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -Force' {
        {
            Remove-AzPolicyDefinition -Force
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -Force -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -Force -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -Force -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -Force -PassThru' {
        {
            Remove-AzPolicyDefinition -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -ManagementGroupName <missing>' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'RemovePolicyDefinition -ManagementGroupName' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'RemovePolicyDefinition -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicyDefinition -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -SubscriptionId <missing>' {
        {
            Remove-AzPolicyDefinition -SubscriptionId
        } | Should -Throw $missingAnArgument
    }

    It 'RemovePolicyDefinition -SubscriptionId' {
        {
            Remove-AzPolicyDefinition -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -SubscriptionId -PassThru' {
        {
            Remove-AzPolicyDefinition -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $missingParameters
    }

    It 'RemovePolicyDefinition -PassThru' {
        {
            Remove-AzPolicyDefinition -PassThru
        } | Should -Throw $missingParameters
    }
}