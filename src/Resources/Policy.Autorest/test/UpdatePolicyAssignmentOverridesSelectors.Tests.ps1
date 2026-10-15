# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyAssignmentOverridesSelectors'

if(($null -eq $TestName) -or ($TestName -contains 'UpdatePolicyAssignmentOverridesSelectors'))
{
    # Update-AzPolicyAssignment reads the existing assignment, merges the bound parameters into
    # it and writes the result back with New-AzPolicyAssignment. The service clears overrides and
    # resource selectors that are omitted from that write, so the cmdlet has to carry them over.
    # These tests dot-source the custom cmdlet and mock both calls so the merge logic is exercised
    # without any HTTP traffic. They therefore pass in playback with no recording.
    . (Join-Path $PSScriptRoot '..\custom\Helpers.ps1')
    . (Join-Path $PSScriptRoot '..\custom\Update-AzPolicyAssignment.ps1')

    function Get-AzPolicyAssignment {
        [CmdletBinding()]
        param([string]$Id, $DefaultProfile, $Break, $HttpPipelineAppend, $HttpPipelinePrepend, $Proxy, $ProxyCredential, $ProxyUseDefaultCredentials)
    }

    function New-AzPolicyAssignment {
        [CmdletBinding()]
        param(
            $Override, $ResourceSelector,
            [string]$Name, [string]$Scope, [string[]]$NotScope, [string]$DisplayName, [string]$Description, $Metadata,
            [string]$EnforcementMode, [string]$IdentityType, [string]$IdentityId, [string]$Location, $NonComplianceMessage,
            $PolicyDefinition, [string]$DefinitionVersion, $PolicyParameter, $PolicyParameterObject,
            $DefaultProfile, $Break, $HttpPipelineAppend, $HttpPipelinePrepend, $Proxy, $ProxyCredential, $ProxyUseDefaultCredentials
        )
    }
}

Describe 'UpdatePolicyAssignmentOverridesSelectors' {

    $assignmentId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/policyAssignments/$someName"
    $existingOverride = @(@{ Kind = 'policyEffect'; Value = 'Disabled' })
    $existingResourceSelector = @(@{ Name = 'existingSelector'; Selector = @(@{ Kind = 'resourceLocation'; In = @($env.location) }) })

    function New-ExistingAssignment([switch]$Empty) {
        $existing = [pscustomobject]@{
            Id                 = $assignmentId
            PolicyDefinitionId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/policyDefinitions/$somePolicyDefinition"
            DisplayName        = 'existing display name'
            Override           = $null
            ResourceSelector   = $null
        }

        # assigned separately so single-element arrays aren't unrolled
        if (!$Empty) {
            $existing.Override = $existingOverride
            $existing.ResourceSelector = $existingResourceSelector
        }

        $existing
    }

    It 'Keeps the existing overrides and resource selectors when they are not specified' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -DisplayName 'new display name'

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            $Override[0].Value -eq 'Disabled' -and $ResourceSelector[0].Name -eq 'existingSelector' -and $DisplayName -eq 'new display name'
        }
    }

    It 'Uses -Override and -ResourceSelector over the existing values' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -Override @(@{ Kind = 'policyEffect'; Value = 'Audit' }) `
            -ResourceSelector @(@{ Name = 'newSelector'; Selector = @(@{ Kind = 'resourceLocation'; In = @($env.location) }) })

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            @($Override).Count -eq 1 -and $Override[0].Value -eq 'Audit' -and
            @($ResourceSelector).Count -eq 1 -and $ResourceSelector[0].Name -eq 'newSelector'
        }
    }

    It 'Clears the overrides and resource selectors when empty collections are specified' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -Override @() -ResourceSelector @()

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            $null -ne $Override -and @($Override).Count -eq 0 -and $null -ne $ResourceSelector -and @($ResourceSelector).Count -eq 0
        }
    }

    It 'Omits overrides and resource selectors when neither the existing assignment nor the parameters have any' {
        Mock Get-AzPolicyAssignment { New-ExistingAssignment -Empty }
        Mock New-AzPolicyAssignment { }

        Update-AzPolicyAssignment -Id $assignmentId -DisplayName 'new display name'

        Assert-MockCalled New-AzPolicyAssignment -Scope It -Times 1 -Exactly -ParameterFilter {
            $null -eq $Override -and $null -eq $ResourceSelector
        }
    }
}
