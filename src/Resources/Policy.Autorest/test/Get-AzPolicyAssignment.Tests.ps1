# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicyAssignment'

Describe 'GetPolicyAssignment' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $mgScope = "/providers/Microsoft.Management/managementGroups/$someManagementGroup"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
    }

    It 'Get-AzPolicyAssignment' {
        Get-AzPolicyAssignment | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyAssignment -Name <missing>' {
        {
            Get-AzPolicyAssignment -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyAssignment -Name' {
        {
            Get-AzPolicyAssignment -Name $someName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Get-AzPolicyAssignment -Name -Scope' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $goodScope
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Get-AzPolicyAssignment -Name -Id' {
        {
            Get-AzPolicyAssignment -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -PolicyDefinitionId' {
        {
            Get-AzPolicyAssignment -Name $someName -PolicyDefinitionId $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Name $someName -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -Scope -Id' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -Scope -PolicyDefinitionId' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyDefinitionId $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -Scope -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $someScope -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -Scope -Id -PolicyDefinitionId' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId -PolicyDefinitionId $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -Scope -Id -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Name -Scope -Id -PolicyDefinitionId -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId -PolicyDefinitionId $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Scope <missing>' {
        {
            Get-AzPolicyAssignment -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyAssignment -Scope' {
        Get-AzPolicyAssignment -Scope $goodScope | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyAssignment -Scope <MGScope>' {
        {
            Get-AzPolicyAssignment -Scope $mgScope
        } | Should -Throw $authorizationFailed
    }

    It 'Get-AzPolicyAssignment -Scope -Id' {
        {
            Get-AzPolicyAssignment -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Scope -PolicyDefinitionId' {
        Get-AzPolicyAssignment -Scope $goodScope -PolicyDefinitionId $someId | Should -HaveCount 0
    }

    It 'Get-AzPolicyAssignment -Scope <MGScope> -PolicyDefinitionId' {
        {
            Get-AzPolicyAssignment -Scope $mgScope -PolicyDefinitionId $someId
        } | Should -Throw $authorizationFailed
    }

    It 'Get-AzPolicyAssignment -Scope -IncludeDescendent' {
        Get-AzPolicyAssignment -Scope $goodScope -IncludeDescendent
        | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyAssignment -Scope <MGScope> -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Scope $mgScope -IncludeDescendent
        } | Should -Throw $allSwitchNotSupported
    }

    It 'Get-AzPolicyAssignment -Scope -PolicyDefinitionId -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Scope $someScope -PolicyDefinitionId $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Id <missing>' {
        {
            Get-AzPolicyAssignment -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyAssignment -Id' {
        {
            Get-AzPolicyAssignment -Id $goodId
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Get-AzPolicyAssignment -Id -PolicyDefinitionId' {
        {
            Get-AzPolicyAssignment -Id $someId -PolicyDefinitionId $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Id -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Id $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -Id -PolicyDefinitionId -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -Id $someId -PolicyDefinitionId $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -PolicyDefinitionId <missing>' {
        {
            Get-AzPolicyAssignment -PolicyDefinitionId
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyAssignment -PolicyDefinitionId' {
        Get-AzPolicyAssignment -PolicyDefinitionId $someId | Should -HaveCount 0
    }

    It 'Get-AzPolicyAssignment -PolicyDefinitionId -IncludeDescendent' {
        {
            Get-AzPolicyAssignment -PolicyDefinitionId $someId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyAssignment -IncludeDescendent' {
        Get-AzPolicyAssignment -IncludeDescendent | Should -BeOfType 'System.Object'
    }
}
