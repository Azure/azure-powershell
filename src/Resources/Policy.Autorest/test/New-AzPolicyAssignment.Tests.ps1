# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyAssignment'

Describe 'NewPolicyAssignment' -Tag 'LiveOnly' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodPolicyDefinition = Get-AzPolicyDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
        $goodPolicySetDefinition = Get-AzPolicySetDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
        $wrongParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'
    }

    It 'New-AzPolicyAssignment' {
        {
            New-AzPolicyAssignment
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyAssignment -Name' {
        {
            New-AzPolicyAssignment -Name $someName
        } | Should -Throw $policyDefinitionParameter
    }

    It 'New-AzPolicyAssignment -Name -Scope' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $goodScope
        } | Should -Throw $policyDefinitionParameter
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyDefinition' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition
        } | Should -Throw $missingSubscription
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyDefinition -PolicySetDefinition' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicySetDefinition $goodPolicySetDefinition
        } | Should -Throw $multiplePolicyDefinitionParams
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyDefinition -PolicyParameterObject' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject
        } | Should -Throw $undefinedPolicyParameter
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyDefinition -PolicyParameter' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameter $wrongParameters
        } | Should -Throw $undefinedPolicyParameter
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyDefinition -PolicyParameterObject -PolicyParameter' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicySetDefinition -PolicyParameterObject' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject
        } | Should -Throw $missingSubscription
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicySetDefinition -PolicyParameter' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter
        } | Should -Throw $parameterSetError
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyParameterObject' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyDefinitionParameter
    }

    It 'New-AzPolicyAssignment -Name -Scope -PolicyParameter' {
        {
            New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $somePolicyParameter
        } | Should -Throw $policyDefinitionParameter
    }

    It 'New-AzPolicyAssignment -Scope' {
        {
            New-AzPolicyAssignment -Scope $someScope
        } | Should -Throw $missingParameters
    }
}