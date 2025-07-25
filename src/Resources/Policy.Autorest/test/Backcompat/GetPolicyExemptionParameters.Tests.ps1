# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-GetPolicyExemptionParameters'

Describe 'Backcompat-GetPolicyExemptionParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $mgScope = "/providers/Microsoft.Management/managementGroups/$someManagementGroup"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyExemptions/$someName"
    }

    It 'no parameters' {
        {
            # validate with no parameters
            $ok = Get-AzPolicyExemption
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName } $policyExemptionNotFound
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -Scope $goodScope } $policyExemptionNotFound
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -PolicyAssignmentIdFilter $someId } $policyExemptionNotFound
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -IncludeDescendent } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId } $parameterSetError
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -Scope $someScope -PolicyAssignmentIdFilter $someId } $missingSubscription
            Assert-ThrowsContains { Get-AzPolicyExemption -Name $someName -Scope $someScope -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Scope' {
        {
            # validate remaining parameter combinations starting with -Scope
            $ok = Get-AzPolicyExemption -Scope $goodScope
            Assert-ThrowsContains { Get-AzPolicyExemption -Scope $someScope -Id $someId } $parameterSetError
            $ok = Get-AzPolicyExemption -Scope $goodScope -PolicyAssignmentIdFilter $someId
            Assert-AreEqual 0 $ok.Count
            $ok = Get-AzPolicyExemption -Scope $goodScope -IncludeDescendent
            Assert-ThrowsContains { Get-AzPolicyExemption -Scope $mgScope -IncludeDescendent } $allSwitchNotSupported
            Assert-ThrowsContains { Get-AzPolicyExemption -Scope $someScope -PolicyAssignmentIdFilter $someId -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate remaining parameter combinations starting with -Id
            Assert-ThrowsContains { Get-AzPolicyExemption -Id $goodId } $policyExemptionNotFound
            Assert-ThrowsContains { Get-AzPolicyExemption -Id $someId -PolicyAssignmentIdFilter $someId } $missingSubscription
            Assert-ThrowsContains { Get-AzPolicyExemption -Id $someId -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -PolicyAssignmentIdFilter' {
        {
            # validate remaining parameter combinations starting with -PolicyAssignmentIdFilter
            $ok = Get-AzPolicyExemption -PolicyAssignmentIdFilter $someId
            Assert-AreEqual 0 $ok.Count
            Assert-ThrowsContains { Get-AzPolicyExemption -PolicyAssignmentIdFilter $someId -IncludeDescendent } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -IncludeDescendent' {
        {
            # validate remaining parameter combinations starting with -IncludeDescendent
            $ok = Get-AzPolicyExemption -IncludeDescendent
        } | Should -Not -Throw
    }
}
