# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'RemovePolicyExemption'

Describe 'RemovePolicyExemption' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyExemptions/$someName"
    }

    It 'Remove-AzPolicyExemption' {
        {
            Remove-AzPolicyExemption
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -Name <missing>' {
        {
            Remove-AzPolicyExemption -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyExemption -Name' {
        {
            Remove-AzPolicyExemption -Name $someName
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyExemption -Name -Scope' {
        {
            Remove-AzPolicyExemption -Name $someName -Scope $goodScope
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyExemption -Name -Id' {
        {
            Remove-AzPolicyExemption -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Force' {
        Remove-AzPolicyExemption -Name $someName -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyExemption -Name -PassThru' {
        {
            Remove-AzPolicyExemption -Name $someName -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyExemption -Name -Scope -Id' {
        {
            Remove-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Scope -Force' {
        Remove-AzPolicyExemption -Name $someName -Scope $goodScope -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyExemption -Name -Scope -PassThru' {
        {
            Remove-AzPolicyExemption -Name $someName -Scope $goodScope -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyExemption -Name -Scope -Force -PassThru' {
        Remove-AzPolicyExemption -Name $someName -Scope $goodScope -Force -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyExemption -Name -Scope -Id -Force' {
        {
            Remove-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Scope -Id -PassThru' {
        {
            Remove-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Scope -Id -Force -PassThru' {
        {
            Remove-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId -Force -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Id -Force' {
        {
            Remove-AzPolicyExemption -Name $someName -Id $someId -Force
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Id -PassThru' {
        {
            Remove-AzPolicyExemption -Name $someName -Id $someId -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Name -Id -Force -PassThru' {
        {
            Remove-AzPolicyExemption -Name $someName -Id $someId -Force -PassThru
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Scope <missing>' {
        {
            Remove-AzPolicyExemption -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyExemption -Scope' {
        {
            Remove-AzPolicyExemption -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -Scope -Id' {
        {
            Remove-AzPolicyExemption -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Remove-AzPolicyExemption -Scope -Force' {
        {
            Remove-AzPolicyExemption -Scope $someScope -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -Scope -PassThru' {
        {
            Remove-AzPolicyExemption -Scope $someScope -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -Scope -Force -PassThru' {
        {
            Remove-AzPolicyExemption -Scope $someScope -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -Id <missing>' {
        {
            Remove-AzPolicyExemption -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Remove-AzPolicyExemption -Id' {
        {
            Remove-AzPolicyExemption -Id $goodId
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyExemption -Id -Force' {
        Remove-AzPolicyExemption -Id $goodId -Force | Should -BeNullOrEmpty
    }

    It 'Remove-AzPolicyExemption -Id -PassThru' {
        {
            Remove-AzPolicyExemption -Id $goodId -PassThru
        } | Should -Throw $nonInteractiveMode
    }

    It 'Remove-AzPolicyExemption -Id -Force -PassThru' {
        Remove-AzPolicyExemption -Id $goodId -Force -PassThru | Should -Be $true
    }

    It 'Remove-AzPolicyExemption -Force' {
        {
            Remove-AzPolicyExemption -Force
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -Force -PassThru' {
        {
            Remove-AzPolicyExemption -Force -PassThru
        } | Should -Throw $missingParameters
    }

    It 'Remove-AzPolicyExemption -PassThru' {
        {
            Remove-AzPolicyExemption -PassThru
        } | Should -Throw $missingParameters
    }
}