# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'GetPolicyEnrollment'

Describe 'GetPolicyEnrollment' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $mgScope = $managementGroupScope
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyEnrollments/$someName"

        # Create a policy assignment and enrollment at MG scope so the MG-scoped list tests have data to return
        $testPA = Get-ResourceName -MaxLength 24
        $testEnrollment = Get-ResourceName -MaxLength 24
        $policy = Get-AzPolicyDefinition -Id "/providers/Microsoft.Authorization/policyDefinitions/0a914e76-4921-4c19-b460-a2d36003525a"
        $assignment = New-AzPolicyAssignment -Name $testPA -PolicyDefinition $policy -Scope $mgScope -DisplayName $description -EnforcementMode $enforcementModeEnroll
        $mgEnrollment = New-AzPolicyEnrollment -Name $testEnrollment -Scope $mgScope -PolicyAssignmentId $assignment.Id -DisplayName $description
    }

    It 'Get-AzPolicyEnrollment' {
        Get-AzPolicyEnrollment | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyEnrollment -Name <missing>' {
        {
            Get-AzPolicyEnrollment -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyEnrollment -Name -Scope' {
        {
            Get-AzPolicyEnrollment -Name $someName -Scope $goodScope
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Get-AzPolicyEnrollment -Name -Id' {
        {
            Get-AzPolicyEnrollment -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyEnrollment -Scope <missing>' {
        {
            Get-AzPolicyEnrollment -Scope
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyEnrollment -Scope' {
        Get-AzPolicyEnrollment -Scope $goodScope | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyEnrollment -Scope -Id' {
        {
            Get-AzPolicyEnrollment -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyEnrollment -Scope <invalid>' {
        {
            Get-AzPolicyEnrollment -Scope $someScope
        } | Should -Throw $missingSubscription
    }

    It 'Get-AzPolicyEnrollment -Scope <MGScope>' {
        Get-AzPolicyEnrollment -Scope $mgScope | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyEnrollment -Id <missing>' {
        {
            Get-AzPolicyEnrollment -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyEnrollment -Id' {
        {
            Get-AzPolicyEnrollment -Id $goodId
        } | Should -Throw $policyEnrollmentNotFound
    }

    It 'Get-AzPolicyEnrollment -ResourceGroupName <missing>' {
        {
            Get-AzPolicyEnrollment -ResourceGroupName
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyEnrollment -ResourceGroupName' {
        Get-AzPolicyEnrollment -ResourceGroupName $env.rgName | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyEnrollment -ManagementGroupId <missing>' {
        {
            Get-AzPolicyEnrollment -ManagementGroupId
        } | Should -Throw $missingAnArgument
    }

    It 'Get-AzPolicyEnrollment -ManagementGroupId' {
        Get-AzPolicyEnrollment -ManagementGroupId $managementGroup | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyEnrollment -ManagementGroupId -IncludeDescendent' {
        {
            Get-AzPolicyEnrollment -ManagementGroupId $managementGroup -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyEnrollment -IncludeDescendent' {
        Get-AzPolicyEnrollment -IncludeDescendent | Should -BeOfType 'System.Object'
    }

    It 'Get-AzPolicyEnrollment -Name -IncludeDescendent' {
        {
            Get-AzPolicyEnrollment -Name $someName -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyEnrollment -Id -IncludeDescendent' {
        {
            Get-AzPolicyEnrollment -Id $goodId -IncludeDescendent
        } | Should -Throw $parameterSetError
    }

    It 'Get-AzPolicyEnrollment -Scope <MGScope> -IncludeDescendent' {
        {
            Get-AzPolicyEnrollment -Scope $mgScope -IncludeDescendent
        } | Should -Throw $allSwitchNotSupported
    }

    AfterAll {
        $null = Remove-AzPolicyEnrollment -Name $testEnrollment -Scope $mgScope -Force -PassThru
        $null = Remove-AzPolicyAssignment -Name $testPA -Scope $mgScope -PassThru
    }
}
