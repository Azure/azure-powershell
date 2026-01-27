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
    
    It 'Get-AzPolicySetDefinition -Expand <missing>' {
        {
            Get-AzPolicySetDefinition -Expand
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicySetDefinition -Expand' {
        {
            Get-AzPolicySetDefinition -Expand "LatestDefinitionVersion"
        } | Should -Throw $expandRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Expand' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Expand "EffectiveDefinitionVersion"
        } | Should -Throw $expandRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Expand' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Expand "EffectiveDefinitionVersion"
        } | Should -Throw $expandRequiresNameOrId
    }

    It 'Get-AzPolicySetDefinition -Custom -Expand' {
        {
            Get-AzPolicySetDefinition -Custom -Expand "EffectiveDefinitionVersion"
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicySetDefinition -BuiltIn -Expand' {
        {
            Get-AzPolicySetDefinition -BuiltIn -Expand "EffectiveDefinitionVersion"
        } | Should -Throw $parameterSetError
    }
    
    It 'Get-AzPolicySetDefinition -ManagementGroupName -Name -Expand <invalid value>' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Name $someName -Expand $someName
        } | Should -Throw $unsupportedFilterValue
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Name -Expand <invalid value>' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Name $someName -Expand $someName
        } | Should -Throw $unsupportedFilterValue
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Name -Expand' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Name $someName -Expand "EffectiveDefinitionVersion"
        } | Should -Throw $PolicySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -SubscriptionId -Name -Expand' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Name $someName -Expand "EffectiveDefinitionVersion"
        } | Should -Throw $PolicySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -Id -Expand <invalid value>' {
        {
            Get-AzPolicySetDefinition -Id $goodId -Expand $someName
        } | Should -Throw $unsupportedFilterValue
    }

    It 'Get-AzPolicySetDefinition -Id -Expand' {
        {
            Get-AzPolicySetDefinition -Id $goodId -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion"
        } | Should -Throw $policySetDefinitionNotFound
    }

    It 'Get-AzPolicySetDefinition -ManagementGroupName -Id -Expand' {
        {
            Get-AzPolicySetDefinition -ManagementGroupName $someManagementGroup -Id $goodId -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion"
        } | Should -Throw $missingParameters
    }
    
    It 'Get-AzPolicySetDefinition -SubscriptionId -Id -Expand' {
        {
            Get-AzPolicySetDefinition -SubscriptionId $subscriptionId -Id $goodId -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion"
        } | Should -Throw $missingParameters
    }
    
    It 'Get-AzPolicySetDefinition -Id -Name -Expand' {
        {
            Get-AzPolicySetDefinition -Id $goodId -Name $someName -Expand "LatestDefinitionVersion, EffectiveDefinitionVersion"
        } | Should -Throw $missingParameters
    }
}
