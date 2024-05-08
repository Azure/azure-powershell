# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyExemption'

Describe 'UpdatePolicyExemption' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyExemptions/$someName"
    }

    It 'Update-AzPolicyExemption' {
        {
            Update-AzPolicyExemption
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyExemption -Name <missing>' {
        {
            Update-AzPolicyExemption -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyExemption -Name' {
        {
            Update-AzPolicyExemption -Name $someName
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Name -Scope' {
        {
            Update-AzPolicyExemption -Name $someName -Scope $goodScope
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Name -Id' {
        {
            Update-AzPolicyExemption -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyExemption -Name -DisplayName' {
        {
            Update-AzPolicyExemption -Name $someName -DisplayName $someDisplayName
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Name -Description' {
        {
            Update-AzPolicyExemption -Name $someName -Description $description
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Name -Metadata' {
        {
            Update-AzPolicyExemption -Name $someName -Metadata $metadata
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Name -Scope -Id' {
        {
            Update-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyExemption -Name -Scope -ExemptionCategory' {
        {
            Update-AzPolicyExemption -Name $someName -Scope $someScope -ExemptionCategory $someName
        } | Should -Throw $invalidParameterValue
    }

    It 'Update-AzPolicyExemption -Scope <missing>' {
        {
            Update-AzPolicyExemption -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyExemption -Scope' {
        {
            Update-AzPolicyExemption -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyExemption -Scope -ExemptionCategory' {
        {
            Update-AzPolicyExemption -Scope $someScope -ExemptionCategory Waiver
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyExemption -Id <missing>' {
        {
            Update-AzPolicyExemption -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyExemption -Id' {
        {
            Update-AzPolicyExemption -Id $goodId
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Id -Scope' {
        {
            Update-AzPolicyExemption -Id $someId -Scope $someScope
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyExemption -Id -Name' {
        {
            Update-AzPolicyExemption -Id $someId -Name $someName
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyExemption -Id -DisplayName' {
        {
            Update-AzPolicyExemption -Id $someId -DisplayName $someDisplayName
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Id -Metadata' {
        {
            Update-AzPolicyExemption -Id $someId -Metadata $metadata
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Update-AzPolicyExemption -Id -Description' {
        {
            Update-AzPolicyExemption -Id $someId -Description $description
        } | Should -Throw $policyExemptionNotFound
    }
}