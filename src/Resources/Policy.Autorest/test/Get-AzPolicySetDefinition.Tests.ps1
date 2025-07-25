# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicySetDefinition'

Describe 'GetPolicySetDefinition' -Tag 'LiveOnly' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policySetDefinitions/$someName"
    }

    It 'Get-AzPolicySetDefinition' {
        Get-AzPolicySetDefinition | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -Name <missing>' {
        {
            Get-AzPolicySetDefinition -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Name' {
        {
            Get-AzPolicySetDefinition -Name $someName
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Name -Id' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -ManagementGroupName' {
        {
            Get-AzPolicySetDefinition -Name $someName -ManagementGroupName $someManagementGroup
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Name -SubscriptionId' {
        {
            Get-AzPolicySetDefinition -Name $someName -SubscriptionId $subscriptionId
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Name -Builtin' {
        {
            Get-AzPolicySetDefinition -Name $someName -Builtin
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Custom' {
        {
            Get-AzPolicySetDefinition -Name $someName -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -ManagementGroupName' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -SubscriptionId' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -Builtin' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -Custom' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -ManagementGroupName -SubscriptionId' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -ManagementGroupName -BuiltIn' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -ManagementGroupName -Custom' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Name -Id -ManagementGroupName -BuiltIn -Custom' {
        {
            Get-AzPolicySetDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id <missing>' {
        {
            Get-AzPolicySetDefinition -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Id' {
        {
            Get-AzPolicySetDefinition -Id $goodId
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Id -ManagementGroupName' {
        {
            Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -SubscriptionId' {
        {
            Get-AzPolicySetDefinition -Id $goodId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -Builtin' {
        {
            Get-AzPolicySetDefinition -Id $goodId -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -Custom' {
        {
            Get-AzPolicySetDefinition -Id $goodId -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -ManagementGroupName -SubscriptionId' {
        {
            Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -ManagementGroupName -BuiltIn' {
        {
            Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -ManagementGroupName -Custom' {
        {
            Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Id -ManagementGroupName -BuiltIn -Custom' {
        {
            Get-AzPolicySetDefinition -Id $goodId -ManagementGroupName $someManagementGroup -Builtin -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName <missing>' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName' {
        Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -SubscriptionId' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Builtin' {
        Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -BuiltIn | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Custom' {
        Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Custom | Should -BeNullOrEmpty
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -BuiltIn' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn
        } | Should -Throw $onlyManagementGroupOrSubscription
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -Custom' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Custom
        } | Should -Throw $onlyManagementGroupOrSubscription
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -SubscriptionId -BuiltIn -Custom' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId <missing>' {
        {
            Get-AzPolicySetDefinition -SubscriptionId
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId' {
        Get-AzPolicySetDefinition -SubscriptionId $subscriptionId | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Builtin' {
        Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Custom' {
        Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Custom | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -BuiltIn -Custom' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Builtin' {
        Get-AzPolicySetDefinition -BuiltIn | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicySetDefinition -Builtin -Custom' {
        {
            Get-AzPolicySetDefinition -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -Custom' {
        Get-AzPolicySetDefinition -Custom | Should -BeOfType 'System.Object'
    }
}
