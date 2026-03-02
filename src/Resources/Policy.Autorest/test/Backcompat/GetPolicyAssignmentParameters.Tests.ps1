# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-GetPolicyAssignmentParameters'

Describe 'Backcompat-GetPolicyAssignmentParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $mgScope = "/providers/Microsoft.Management/managementGroups/$someManagementGroup"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
    }

    It 'no parameters' {
        {
            # validate with no parameters
            $ok = Get-AzPolicyAssignment
        } | Should -Not -Throw
    }

    It 'parameters starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName } $policyAssignmentNotFound
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $goodScope } $policyAssignmentNotFound
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Id $someId } $parameterSetError
            # Message changed due to fixes in parameters and parameter sets
            #Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -PolicyDefinitionId $someId } $policyAssignmentNotFound
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -PolicyDefinitionId $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -IncludeDescendent } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError
            # Message changed due to fixes in parameters and parameter sets
            #Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinitionId $someId } $missingSubscription
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinitionId $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyAssignment -Name $someName -Scope $someScope -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Scope' {
        {
            # validate remaining parameter combinations starting with -Scope
            $ok = Get-AzPolicyAssignment -Scope $goodScope
            Assert-ThrowsContains { Get-AzPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError
            $ok = Get-AzPolicyAssignment -Scope $goodScope -PolicyDefinitionId $someId
            Assert-AreEqual 0 $ok.Count
            $ok = Get-AzPolicyAssignment -Scope $goodScope -IncludeDescendent
            Assert-ThrowsContains { Get-AzPolicyAssignment -Scope $mgScope -IncludeDescendent } $allSwitchNotSupported
            Assert-ThrowsContains { Get-AzPolicyAssignment -Scope $someScope -PolicyDefinitionId $someId -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate remaining parameter combinations starting with -Id
            Assert-ThrowsContains { Get-AzPolicyAssignment -Id $goodId } $policyAssignmentNotFound
            # Message changed due to fixes in parameters and parameter sets
            #Assert-ThrowsContains { Get-AzPolicyAssignment -Id $someId -PolicyDefinitionId $someId } $missingSubscription
            Assert-ThrowsContains { Get-AzPolicyAssignment -Id $someId -PolicyDefinitionId $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyAssignment -Id $someId -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -PolicyDefinitionId' {
        {
            # validate remaining parameter combinations starting with -PolicyDefinitionId
            $ok = Get-AzPolicyAssignment -PolicyDefinitionId $someId
            Assert-AreEqual 0 $ok.Count
            Assert-ThrowsContains { Get-AzPolicyAssignment -PolicyDefinitionId $someId -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameters starting with -IncludeDescendent' {
        {
            # validate remaining parameter combinations starting with -IncludeDescendent
            $ok = Get-AzPolicyAssignment -IncludeDescendent
        } | Should -Not -Throw
    }
}
