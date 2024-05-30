# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicySetDefinition'

Describe 'RemovePolicySetDefinition' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
        $goodObject = Get-AzPolicySetDefinition -Builtin | select -First 1
    }

    It 'Remove-AzPolicySetDefinition' {
        {
            Remove-AzPolicySetDefinition
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Name <missing>' {
        {
            Remove-AzPolicySetDefinition -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicySetDefinition -Name' {
        {
            Remove-AzPolicySetDefinition -Name $someName
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -Id' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Force' {
        Remove-AzPolicySetDefinition -Name $someName -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicySetDefinition -Name -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Name $someName -ManagementGroupName $managementGroup
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force -ManagementGroupName $managementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force -ManagementGroupName $managementGroup -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -Force -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $managementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Name -Id -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id <missing>' {
        {
            Remove-AzPolicySetDefinition -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicySetDefinition -Id' {
        {
            Remove-AzPolicySetDefinition -Id $goodId
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Id -Force' {
        Remove-AzPolicySetDefinition -Id $goodId -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicySetDefinition -Id -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $goodId -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicySetDefinition -Id -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Force -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Force -PassThru' {
        Remove-AzPolicySetDefinition -Id $goodId -Force -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicySetDefinition -Id -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Id -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Id $someId -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Force' {
        {
            Remove-AzPolicySetDefinition -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Force -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Force -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Force -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Force -PassThru' {
        {
            Remove-AzPolicySetDefinition -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Force -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -Force -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -Force -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -Force -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -Force -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName <missing>' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -PassThru' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId <missing>' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -SubscriptionId -PassThru' {
        {
            Remove-AzPolicySetDefinition -SubscriptionId $subscriptionId -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicySetDefinition -PassThru' {
        {
            Remove-AzPolicySetDefinition -PassThru
        } | Should -Throw $missingParameters
    }
}