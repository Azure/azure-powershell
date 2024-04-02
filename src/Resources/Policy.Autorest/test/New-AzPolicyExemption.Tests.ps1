# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyExemption'

Describe 'NewPolicyExemption' {

    BeforeAll {
        # make a new resource group and policy assignment of some built-in definition
        $rgName = $env.rgName
        $rgScope = $env.rgScope
        $goodScope = "/subscriptions/$subscriptionId/resourceGroups/$rgName"

        $assignmentName = 'testPA1'
        $policy = Get-AzPolicyDefinition -Builtin | ?{ $_.Name -eq '0a914e76-4921-4c19-b460-a2d36003525a' }
        $goodPolicyAssignment = New-AzPolicyAssignment -Name $assignmentName -Scope $rgScope -PolicyDefinition $policy -Description $description
    }

    It 'New-AzPolicyExemption' {
        {
            New-AzPolicyExemption
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Name' {
        {
            New-AzPolicyExemption -Name $someName
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Name -Scope' {
        {
            New-AzPolicyExemption -Name $someName -Scope $goodScope
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Name -Scope -ExemptionCategory' {
        {
            New-AzPolicyExemption -Name $someName -Scope $goodScope -ExemptionCategory Waiver
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Name -Scope -PolicyAssignment' {
        {
            New-AzPolicyExemption -Name $someName -Scope $goodScope -PolicyAssignment $goodPolicyAssignment
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Name -Scope -ExemptionCategory -PolicyAssignment' {
        {
            New-AzPolicyExemption -Name $someName -Scope $someScope -ExemptionCategory Waiver -PolicyAssignment $goodPolicyAssignment
        } | Should -Throw $missingSubscription
    }

    It 'New-AzPolicyExemption -Name -Scope -ExemptionCategory -PolicyAssignment' {
        {
            New-AzPolicyExemption -Name $someName -Scope $someScope -ExemptionCategory $someName -PolicyAssignment $goodPolicyAssignment
        } | Should -Throw $invalidParameterValue
    }

    It 'New-AzPolicyExemption -Name -Scope -ExemptionCategory -PolicyAssignment -PolicyDefinitionReferenceId' {
        {
            New-AzPolicyExemption -Name $someName -Scope $goodScope -ExemptionCategory Waiver -PolicyAssignment $goodPolicyAssignment -PolicyDefinitionReferenceId @($someId)
        } | Should -Throw $invalidPolicyDefinitionReference
    }

    It 'New-AzPolicyExemption -Scope' {
        {
            New-AzPolicyExemption -Scope $someScope
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Scope -ExemptionCategory' {
        {
            New-AzPolicyExemption -Scope $someScope -ExemptionCategory Waiver
        } | Should -Throw $missingParameters
    }

    It 'New-AzPolicyExemption -Scope -PolicyAssignment' {
        {
            New-AzPolicyExemption -Scope $someScope -PolicyAssignment $goodPolicyAssignment
        } | Should -Throw $missingParameters
    }

    AfterAll {
        Remove-AzPolicyAssignment -Name $assignmentName -PassThru | Should -Be $true
        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}