# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicySetDefinition'

Describe 'UpdatePolicySetDefinition' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
        $goodObject = Get-AzPolicySetDefinition -Builtin | select -First 1
    }

    It 'Update-AzPolicySetDefinition' {
        {
            Update-AzPolicySetDefinition
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicySetDefinition -Name <missing>' {
        {
            Update-AzPolicySetDefinition -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicySetDefinition -Name' {
        {
            Update-AzPolicySetDefinition -Name $someName
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Name -Id' {
        {
            Update-AzPolicySetDefinition -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -Name -ManagementGroupName' {
        {
            Update-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Name -SubscriptionId' {
        {
            Update-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Id <missing>' {
        {
            Update-AzPolicySetDefinition -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicySetDefinition -Id' {
        {
            Update-AzPolicySetDefinition -Id $goodId
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Update-AzPolicySetDefinition -Id -ManagementGroupName' {
        {
            Update-AzPolicySetDefinition -Id $someId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -Id -SubscriptionId' {
        {
            Update-AzPolicySetDefinition -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -ManagementGroupName <missing>' {
        {
            Update-AzPolicySetDefinition -ManagementGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicySetDefinition -ManagementGroupName' {
        {
            Update-AzPolicySetDefinition -ManagementGroupName $someManagementGroup
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicySetDefinition -ManagementGroupName -SubscriptionId' {
        {
            Update-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicySetDefinition -SubscriptionId <missing>' {
        {
            Update-AzPolicySetDefinition -SubscriptionId
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicySetDefinition -SubscriptionId' {
        {
            Update-AzPolicySetDefinition -SubscriptionId $subscriptionId
        } | Should -Throw $missingParameters
    }
}