# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicyEnrollment'

Describe 'RemovePolicyEnrollment' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyEnrollments/$someName"
    }

    It 'Remove-AzPolicyEnrollment' {
        {
            Remove-AzPolicyEnrollment
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -Name <missing>' {
        {
            Remove-AzPolicyEnrollment -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyEnrollment -Name' {
        {
            Remove-AzPolicyEnrollment -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -Name -Scope' {
        {
            Remove-AzPolicyEnrollment -Name $someName -Scope $goodScope
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyEnrollment -Name -Id' {
        {
            Remove-AzPolicyEnrollment -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyEnrollment -Name -Scope -Force' {
        Remove-AzPolicyEnrollment -Name $someName -Scope $goodScope -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyEnrollment -Name -Scope -PassThru' {
        {
            Remove-AzPolicyEnrollment -Name $someName -Scope $goodScope -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyEnrollment -Name -Scope -Force -PassThru' {
        Remove-AzPolicyEnrollment -Name $someName -Scope $goodScope -Force -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyEnrollment -Name -Scope -Id' {
        {
            Remove-AzPolicyEnrollment -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyEnrollment -Name -Id -Force' {
        {
            Remove-AzPolicyEnrollment -Name $someName -Id $someId -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyEnrollment -Scope <missing>' {
        {
            Remove-AzPolicyEnrollment -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyEnrollment -Scope' {
        {
            Remove-AzPolicyEnrollment -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -Scope -Id' {
        {
            Remove-AzPolicyEnrollment -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyEnrollment -Scope -Force' {
        {
            Remove-AzPolicyEnrollment -Scope $someScope -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -Scope -Force -PassThru' {
        {
            Remove-AzPolicyEnrollment -Scope $someScope -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -Id <missing>' {
        {
            Remove-AzPolicyEnrollment -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyEnrollment -Id' {
        {
            Remove-AzPolicyEnrollment -Id $goodId
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyEnrollment -Id -Force' {
        Remove-AzPolicyEnrollment -Id $goodId -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyEnrollment -Id -PassThru' {
        {
            Remove-AzPolicyEnrollment -Id $goodId -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyEnrollment -Id -Force -PassThru' {
        Remove-AzPolicyEnrollment -Id $goodId -Force -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyEnrollment -Force' {
        {
            Remove-AzPolicyEnrollment -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -Force -PassThru' {
        {
            Remove-AzPolicyEnrollment -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyEnrollment -PassThru' {
        {
            Remove-AzPolicyEnrollment -PassThru
        } | Should -Throw $missingParameters
    }
}
