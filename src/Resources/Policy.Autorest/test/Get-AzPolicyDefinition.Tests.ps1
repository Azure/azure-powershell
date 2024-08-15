# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicyDefinition'

Describe 'GetPolicyDefinition' -Tag 'LiveOnly' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyDefinitions/$someName"
    }

    It 'Get-AzPolicyDefinition' {
        Get-AzPolicyDefinition | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -Name <missing>' {
        {
            Get-AzPolicyDefinition -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyDefinition -Name' {
        {
            Get-AzPolicyDefinition -Name $someName
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Name -Id' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -ManagementGroupName' {
        {
            Get-AzPolicyDefinition -Name $someName -ManagementGroupName $someManagementGroup
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Name -SubscriptionId' {
        {
            Get-AzPolicyDefinition -Name $someName -SubscriptionId $subscriptionId
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Name -BuiltIn' {
        {
            Get-AzPolicyDefinition -Name $someName -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Custom' {
        {
            Get-AzPolicyDefinition -Name $someName -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Static' {
        {
            Get-AzPolicyDefinition -Name $someName -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -SubscriptionId' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -BuiltIn' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -Custom' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -Static' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -BuiltIn' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -Custom' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -Static' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId -BuiltIn' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId -Custom' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId -Static' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId -BuiltIn -Custom' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId -BuiltIn -Static' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Name -Id -ManagementGroupName -SubscriptionId -BuiltIn -Custom -Static' {
        {
            Get-AzPolicyDefinition -Name $someName -Id $someId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id <missing>' {
        {
            Get-AzPolicyDefinition -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyDefinition -Id' {
        {
            Get-AzPolicyDefinition -Id $goodId
        } | Should -Throw $policyDefinitionNotFound
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -SubscriptionId' {
        {
            Get-AzPolicyDefinition -Id $goodId -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -BuiltIn' {
        {
            Get-AzPolicyDefinition -Id $goodId -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -Custom' {
        {
            Get-AzPolicyDefinition -Id $goodId -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -Static' {
        {
            Get-AzPolicyDefinition -Id $goodId -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -BuiltIn' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -Custom' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -Static' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId -BuiltIn' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId -Custom' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId -Static' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId -BuiltIn -Custom' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId -BuiltIn -Static' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Id -ManagementGroupName -SubscriptionId -BuiltIn -Custom -Static' {
        {
            Get-AzPolicyDefinition -Id $goodId -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName <missing>' {
        {
            Get-AzPolicyDefinition -ManagementGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName' {
        Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -BuiltIn' {
        Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -BuiltIn | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -Custom' {
        Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Custom | Should -BeNullOrEmpty
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -Static' {
        Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -Static | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId -BuiltIn' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn
        } | Should -Throw $onlyManagementGroupOrSubscription
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId -Custom' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Custom
        } | Should -Throw $onlyManagementGroupOrSubscription
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId -Static' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -Static
        } | Should -Throw $onlyManagementGroupOrSubscription
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId -BuiltIn -Custom' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId -BuiltIn -Static' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -ManagementGroupName -SubscriptionId -BuiltIn -Custom -Static' {
        {
            Get-AzPolicyDefinition -ManagementGroupName $someManagementGroup -SubscriptionId $subscriptionId -BuiltIn -Custom -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -SubscriptionId <missing>' {
        {
            Get-AzPolicyDefinition -SubscriptionId
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyDefinition -SubscriptionId' {
        Get-AzPolicyDefinition -SubscriptionId $subscriptionId | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -BuiltIn' {
        Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -Custom' {
        Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Custom | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -Static' {
        Get-AzPolicyDefinition -SubscriptionId $subscriptionId -Static | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -BuiltIn -Custom' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -BuiltIn -Static' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -SubscriptionId -BuiltIn -Custom -Static' {
        {
            Get-AzPolicyDefinition -SubscriptionId $subscriptionId -BuiltIn -Custom -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -BuiltIn' {
        Get-AzPolicyDefinition -BuiltIn | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -BuiltIn -Custom' {
        {
            Get-AzPolicyDefinition -BuiltIn -Custom
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -BuiltIn -Static' {
        {
            Get-AzPolicyDefinition -BuiltIn -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -BuiltIn -Custom -Static' {
        {
            Get-AzPolicyDefinition -BuiltIn -Custom -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Custom' {
        Get-AzPolicyDefinition -Custom | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyDefinition -Custom -Static' {
        {
            Get-AzPolicyDefinition -Custom -Static
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyDefinition -Static' {
        Get-AzPolicyDefinition -Static | Should -BeOfType 'System.Object'
    }
}
