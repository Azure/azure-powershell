# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicyExemption'

Describe 'GetPolicyExemption' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $mgScope = "/providers/Microsoft.Management/managementGroups/$someManagementGroup"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyExemptions/$someName"
    }

    # Need to fix this one
    It 'Get-AzPolicyExemption' {
        Get-AzPolicyExemption | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyExemption -Name <missing>' {
        {
            Get-AzPolicyExemption -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyExemption -Name' {
        {
            Get-AzPolicyExemption -Name $someName
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Get-AzPolicyExemption -Name -Scope' {
        {
            Get-AzPolicyExemption -Name $someName -Scope $goodScope
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Get-AzPolicyExemption -Name -Id' {
        {
            Get-AzPolicyExemption -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -Name -PolicyAssignmentIdFilter' {
        {
            Get-AzPolicyExemption -Name $someName -PolicyAssignmentIdFilter $someId
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Get-AzPolicyExemption -Name -IncludeDescendent' {
        {
            Get-AzPolicyExemption -Name $someName -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -Name -Scope -Id' {
        {
            Get-AzPolicyExemption -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -Name -Scope -PolicyAssignmentIdFilter' {
        {
            Get-AzPolicyExemption -Name $someName -Scope $someScope -PolicyAssignmentIdFilter $someId
        } | Should -Throw $missingSubscription
    }

    It 'Get-AzPolicyExemption -Name -Scope -IncludeDescendent' {
        {
            Get-AzPolicyExemption -Name $someName -Scope $someScope -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -Scope <missing>' {
        {
            Get-AzPolicyExemption -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyExemption -Scope' {
        Get-AzPolicyExemption -Scope $goodScope | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyExemption -Scope -Id' {
        {
            Get-AzPolicyExemption -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -Scope -PolicyAssignmentIdFilter' {
        Get-AzPolicyExemption -Scope $goodScope -PolicyAssignmentIdFilter $someId | Should -HaveCount 0
    }

    It 'Get-AzPolicyExemption -Scope -IncludeDescendent' {
        Get-AzPolicyExemption -Scope $goodScope -IncludeDescendent | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyExemption -Scope <MGScope> -IncludeDescendent' {
        {
            Get-AzPolicyExemption -Scope $mgScope -IncludeDescendent
        } | Should -Throw $allSwitchNotSupported
    }

    It 'Get-AzPolicyExemption -Scope PolicyAssignmentIdFilter -IncludeDescendent' {
        {
            Get-AzPolicyExemption -Scope $someScope -PolicyAssignmentIdFilter $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -Id <missing>' {
        {
            Get-AzPolicyExemption -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyExemption -Id' {
        {
            Get-AzPolicyExemption -Id $goodId
        } | Should -Throw $policyExemptionNotFound
    }

    It 'Get-AzPolicyExemption -Id -PolicyAssignmentIdFilter' {
        {
            Get-AzPolicyExemption -Id $someId -PolicyAssignmentIdFilter $someId
        } | Should -Throw $missingSubscription
    }

    It 'Get-AzPolicyExemption -Id -IncludeDescendent' {
        {
            Get-AzPolicyExemption -Id $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -PolicyAssignmentIdFilter <missing>' { 
        {
            Get-AzPolicyExemption -PolicyAssignmentIdFilter
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyExemption -PolicyAssignmentIdFilter' { 
        Get-AzPolicyExemption -PolicyAssignmentIdFilter $someId | Should -HaveCount 0
    }

    It 'Get-AzPolicyExemption -PolicyAssignmentIdFilter -IncludeDescendent' {
        {
            Get-AzPolicyExemption -PolicyAssignmentIdFilter $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyExemption -IncludeDescendent' {
        Get-AzPolicyExemption -IncludeDescendent | Should -BeOfType 'System.Object'
    }
}
