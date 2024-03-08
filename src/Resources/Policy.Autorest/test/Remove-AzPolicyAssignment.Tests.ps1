# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicyAssignment'

Describe 'RemovePolicyAssignment' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
        $goodObject = Get-AzPolicyAssignment | ?{ $_.Name -like '*test*' -or $_.Description -like '*test*' } | select -First 1
    }

    It 'Remove-AzPolicyAssignment' {
        {
            Remove-AzPolicyAssignment
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyAssignment -Name <missing>' {
        {
            Remove-AzPolicyAssignment -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyAssignment -Name' {
        Remove-AzPolicyAssignment -Name $someName | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyAssignment -Name -Scope' {
        Remove-AzPolicyAssignment -Name $someName -Scope $goodScope | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyAssignment -Name -Id' {
        {
            Remove-AzPolicyAssignment -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyAssignment -Name -PassThru' {
        Remove-AzPolicyAssignment -Name $someName -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyAssignment -Name -Scope -Id' {
        {
            Remove-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyAssignment -Name -Scope -PassThru' {
        Remove-AzPolicyAssignment -Name $someName -Scope $goodScope -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyAssignment -Name -Scope -Id -PassThru' {
        {
            Remove-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyAssignment -Scope <missing>' {
        {
            Remove-AzPolicyAssignment -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyAssignment -Scope' {
        {
            Remove-AzPolicyAssignment -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyAssignment -Scope -Id' {
        {
            Remove-AzPolicyAssignment -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyAssignment -Scope -PassThru' {
        {
            Remove-AzPolicyAssignment -Scope $someScope -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyAssignment -Scope -Id -PassThru' {
        {
            Remove-AzPolicyAssignment -Scope $someScope -Id $someId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyAssignment -Id <missing>' {
        {
            Remove-AzPolicyAssignment -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyAssignment -Id' {
        Remove-AzPolicyAssignment -Id $goodId | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyAssignment -Id -PassThru' {
        Remove-AzPolicyAssignment -Id $goodId -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyAssignment -PassThru' {
        {
            Remove-AzPolicyAssignment -PassThru
        } | Should -Throw $missingParameters
    }
}