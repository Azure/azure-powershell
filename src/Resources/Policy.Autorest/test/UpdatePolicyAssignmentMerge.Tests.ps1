# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyAssignmentMerge'

if(($null -eq $TestName) -or ($TestName -contains 'UpdatePolicyAssignmentMerge'))
{
    # Update-AzPolicyAssignment reads the existing assignment, merges the bound parameters into
    # it and writes the result back with New-AzPolicyAssignment. These tests dot-source the custom
    # cmdlet and mock both calls so the merge logic is exercised without any HTTP traffic. They
    # therefore pass in playback with no recording.
    . (Join-Path $PSScriptRoot '..\custom\Helpers.ps1')
    . (Join-Path $PSScriptRoot '..\custom\Update-AzPolicyAssignment.ps1')

    function Get-AzPolicyAssignment {
        [CmdletBinding()]
        param([string]$Id, $DefaultProfile, $Break, $HttpPipelineAppend, $HttpPipelinePrepend, $Proxy, $ProxyCredential, $ProxyUseDefaultCredentials)
    }

    function New-AzPolicyAssignment {
        [CmdletBinding()]
        param(
            # same validation as the real cmdlet, so passing an empty enforcement mode fails the test
            [ValidateNotNullOrEmpty()]
            [ValidateSet('Default', 'DoNotEnforce', 'Enroll')]
            [string]$EnforcementMode,
            [string]$Name, [string]$Scope, [string[]]$NotScope, [string]$DisplayName, [string]$Description, $Metadata,
            [string]$IdentityType, [string]$IdentityId, [string]$Location, $NonComplianceMessage,
            $Override, $ResourceSelector, $PolicyDefinition, [string]$DefinitionVersion, $PolicyParameter, $PolicyParameterObject,
            $DefaultProfile, $Break, $HttpPipelineAppend, $HttpPipelinePrepend, $Proxy, $ProxyCredential, $ProxyUseDefaultCredentials
        )
    }
}

Describe 'UpdatePolicyAssignmentMerge' {

    $assignmentId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/policyAssignments/$someName"

    function New-ExistingAssignment([string]$EnforcementMode) {
        [pscustomobject]@{
            Id                 = $assignmentId
            PolicyDefinitionId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/policyDefinitions/$somePolicyDefinition"
            DisplayName        = 'existing display name'
            EnforcementMode    = $EnforcementMode
        }
    }

    It 'Keeps the existing enforcement mode when -EnforcementMode is not specified' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment 'DoNotEnforce' }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -DisplayName 'new display name'

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            $EnforcementMode -eq 'DoNotEnforce' -and $DisplayName -eq 'new display name'
        }
    }

    It 'Uses -EnforcementMode over the existing enforcement mode' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment 'DoNotEnforce' }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -EnforcementMode 'Default'

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            $EnforcementMode -eq 'Default'
        }
    }

    It 'Omits the enforcement mode when neither the existing assignment nor -EnforcementMode has one' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment $null }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -DisplayName 'new display name'

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            [string]::IsNullOrEmpty($EnforcementMode)
        }
    }
}
