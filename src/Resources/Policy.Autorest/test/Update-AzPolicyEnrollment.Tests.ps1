# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyEnrollment'

Describe 'UpdatePolicyEnrollment' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyEnrollments/$someName"
    }

    It 'Update-AzPolicyEnrollment' {
        {
            Update-AzPolicyEnrollment
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyEnrollment -Name <missing>' {
        {
            Update-AzPolicyEnrollment -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyEnrollment -Name' {
        {
            Update-AzPolicyEnrollment -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyEnrollment -Name -Scope' {
        {
            Update-AzPolicyEnrollment -Name $someName -Scope $goodScope
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Name -Id' {
        {
            Update-AzPolicyEnrollment -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyEnrollment -Name -Scope -Id' {
        {
            Update-AzPolicyEnrollment -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyEnrollment -Name -Scope -DisplayName' {
        {
            Update-AzPolicyEnrollment -Name $someName -Scope $goodScope -DisplayName $someDisplayName
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Name -Scope -Description' {
        {
            Update-AzPolicyEnrollment -Name $someName -Scope $goodScope -Description $description
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Name -Scope -Metadata' {
        {
            Update-AzPolicyEnrollment -Name $someName -Scope $goodScope -Metadata $metadata
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Scope <missing>' {
        {
            Update-AzPolicyEnrollment -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyEnrollment -Scope' {
        {
            Update-AzPolicyEnrollment -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyEnrollment -Id <missing>' {
        {
            Update-AzPolicyEnrollment -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyEnrollment -Id' {
        {
            Update-AzPolicyEnrollment -Id $goodId
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Id -Scope' {
        {
            Update-AzPolicyEnrollment -Id $someId -Scope $someScope
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyEnrollment -Id -Name' {
        {
            Update-AzPolicyEnrollment -Id $someId -Name $someName
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyEnrollment -Id -DisplayName' {
        {
            Update-AzPolicyEnrollment -Id $someId -DisplayName $someDisplayName
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Id -Metadata' {
        {
            Update-AzPolicyEnrollment -Id $someId -Metadata $metadata
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Update-AzPolicyEnrollment -Id -Description' {
        {
            Update-AzPolicyEnrollment -Id $someId -Description $description
        } | Should -Throw $policyEnrollmentNotFound
    }
}
