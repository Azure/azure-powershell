# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyEnrollment'

Describe 'NewPolicyEnrollment' {

    BeforeAll {
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $goodScope = "/subscriptions/$subscriptionId"

        $assignmentName = 'testPA1'
        $policy = Get-AzPolicyDefinition -Builtin | ?{ $_.Name -eq '0a914e76-4921-4c19-b460-a2d36003525a' }
        $goodPolicyAssignment = New-AzPolicyAssignment -Name $assignmentName -Scope $goodScope -PolicyDefinition $policy -Description $description -EnforcementMode $enforcementModeEnroll
    }

    It 'New-AzPolicyEnrollment' {
        {
            New-AzPolicyEnrollment
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyEnrollment -Name' {
        {
            New-AzPolicyEnrollment -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyEnrollment -Scope' {
        {
            New-AzPolicyEnrollment -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyEnrollment -Name -Scope <invalid>' {
        {
            New-AzPolicyEnrollment -Name $someName -Scope $someScope -PolicyAssignmentId $goodPolicyAssignment.Id
        } | Should -Throw $missingSubscription
    }

    It 'New-AzPolicyEnrollment -Name -Scope -PolicyDefinitionReferenceId <bad ref>' {
        {
            New-AzPolicyEnrollment -Name $someName -Scope $goodScope -PolicyAssignmentId $goodPolicyAssignment.Id -PolicyDefinitionReferenceId @($someId)
        } | Should -Throw $invalidPolicyDefinitionReference
    }

    AfterAll {
        Remove-AzPolicyAssignment -Name $assignmentName -Scope $goodScope -PassThru | Should -Be $true
        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
