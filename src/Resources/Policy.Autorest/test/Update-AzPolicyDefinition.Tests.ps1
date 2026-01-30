# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyDefinition'

Describe 'UpdatePolicyDefinition' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
        $goodObject = Get-AzPolicyDefinition -Builtin | select -First 1
    }

    It 'Update-AzPolicyDefinition' {
        {
            Update-AzPolicyDefinition
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyDefinition -Name <missing>' {
        {
            Update-AzPolicyDefinition -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyDefinition -Name' {
        {
            Update-AzPolicyDefinition -Name $someName
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Name -Id' {
        {
            Update-AzPolicyDefinition -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyDefinition -Name -ManagementGroupName' {
        {
            Update-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Name -SubscriptionId' {
        {
            Update-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Id <missing>' {
        {
            Update-AzPolicyDefinition -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyDefinition -Id' {
        {
            Update-AzPolicyDefinition -Id $goodId
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Update-AzPolicyDefinition -Id -ManagementGroupName' {
        {
            Update-AzPolicyDefinition -Id $someId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyDefinition -Id -SubscriptionId' {
        {
            Update-AzPolicyDefinition -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyDefinition -ManagementGroupName <missing>' {
        {
            Update-AzPolicyDefinition -ManagementGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyDefinition -ManagementGroupName' {
        {
            Update-AzPolicyDefinition -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyDefinition -ManagementGroupName -SubscriptionId' {
        {
            Update-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyDefinition -SubscriptionId <missing>' {
        {
            Update-AzPolicyDefinition -SubscriptionId
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyDefinition -SubscriptionId' {
        {
            Update-AzPolicyDefinition -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }
}