# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-RemovePolicyAssignmentParameters'

Describe 'Backcompat-RemovePolicyAssignmentParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
        $goodObject = Get-AzPolicyAssignment -BackwardCompatible | ?{ $_.Name -like '*test*' -or $_.Properties.Description -like '*test*' } | select -First 1
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Remove-AzPolicyAssignment } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            $ok = Remove-AzPolicyAssignment -Name $someName -BackwardCompatible
            Assert-AreEqual True $ok
            $ok = Remove-AzPolicyAssignment -Name $someName -Scope $goodScope -BackwardCompatible
            Assert-AreEqual True $ok
            Assert-ThrowsContains { Remove-AzPolicyAssignment -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Remove-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Scope' {
        {
            # validate remaining parameter combinations starting with -Scope
            Assert-ThrowsContains { Remove-AzPolicyAssignment -Scope $someScope } $missingParameters
            Assert-ThrowsContains { Remove-AzPolicyAssignment -Scope $someScope -Id $someId } $parameterSetError
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            # validate remaining parameter combinations starting with -Id
            $ok = Remove-AzPolicyAssignment -Id $goodId -BackwardCompatible
            Assert-AreEqual True $ok
        } | Should -Not -Throw
    }
}
