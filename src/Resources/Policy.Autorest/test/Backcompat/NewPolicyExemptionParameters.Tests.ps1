# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'NewPolicyExemptionParameters'

Describe 'NewPolicyExemptionParameters' -Tag 'LiveOnly' {

    BeforeAll {
        # make a new resource group and policy assignment of some built-in definition
        $rgname = Get-ResourceGroupName
        $goodScope = "/subscriptions/$subscriptionId/resourceGroups/$rgname"

        $rg = New-ResourceGroup -Name $rgname -Location "west us"
        $assignmentName = 'testPA1'
        $policy = Get-AzPolicyDefinition -Builtin | ?{ $_.Name -eq '0a914e76-4921-4c19-b460-a2d36003525a' }
        $goodPolicyAssignment = New-AzPolicyAssignment -Name $assignmentName -Scope $rg.ResourceId -PolicyDefinition $policy -Description $description -BackwardCompatible
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { New-AzPolicyExemption } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combtinations staring with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName } $missingParameters
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName -Scope $goodScope } $missingParameters
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName -Scope $goodScope -ExemptionCategory Waiver } $missingParameters
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName -Scope $goodScope -PolicyAssignment $goodPolicyAssignment } $missingParameters
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName -Scope $someScope -ExemptionCategory Waiver -PolicyAssignment $goodPolicyAssignment } $missingSubscription
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName -Scope $someScope -ExemptionCategory $someName -PolicyAssignment $goodPolicyAssignment } $invalidParameterValue
            Assert-ThrowsContains { New-AzPolicyExemption -Name $someName -Scope $goodScope -ExemptionCategory Waiver -PolicyAssignment $goodPolicyAssignment -PolicyDefinitionReferenceId @( $someId) } $invalidPolicyDefinitionReference
        } | Should -Not -Throw
    }

    It 'parameter combtinations staring with -Scope' {
        {
            # validate parameter combinations starting with -Scope
            Assert-ThrowsContains { New-AzPolicyExemption -Scope $someScope } $missingParameters
            Assert-ThrowsContains { New-AzPolicyExemption -Scope $someScope -ExemptionCategory Waiver } $missingParameters
            Assert-ThrowsContains { New-AzPolicyExemption -Scope $someScope -PolicyAssignment $goodPolicyAssignment } $missingParameters
        } | Should -Not -Throw
    }

    AfterAll {
        $remove = Remove-AzPolicyAssignment -Name $assignmentName -BackwardCompatible

        $remove = (Remove-ResourceGroup -Name $rgname -Force) -and $remove
        Assert-AreEqual True $remove

        Write-Host -ForegroundColor Magenta "Cleanup complete."
    }
}
