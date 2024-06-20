# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-NewPolicyAssignmentParameters'

Describe 'Backcompat-NewPolicyAssignmentParameters' -Tag 'LiveOnly' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodPolicyDefinition = Get-AzPolicyDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
        $goodPolicySetDefinition = Get-AzPolicySetDefinition | ?{ $_.Properties.parameters -eq $null } | select -First 1
        $wrongParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { New-AzPolicyAssignment } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName } $policyDefinitionParameter
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $goodScope } $policyDefinitionParameter
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition } $missingSubscription
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicySetDefinition $goodPolicySetDefinition } $multiplePolicyDefinitionParams
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject } $undefinedPolicyParameter
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $goodScope -PolicyDefinition $goodPolicyDefinition -PolicyParameter $wrongParameters } $undefinedPolicyParameter
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinition $goodPolicyDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter } $parameterSetError
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject } $missingSubscription
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicySetDefinition $goodPolicySetDefinition -PolicyParameterObject $someParameterObject -PolicyParameter $somePolicyParameter } $parameterSetError
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject } $policyDefinitionParameter
            Assert-ThrowsContains { New-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $somePolicyParameter } $policyDefinitionParameter
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Scope' {
        {
            # validate parameter combinations starting with -Scope
            Assert-ThrowsContains { New-AzPolicyAssignment -Scope $someScope } $missingParameters
        } | Should -Not -Throw
    }
}
