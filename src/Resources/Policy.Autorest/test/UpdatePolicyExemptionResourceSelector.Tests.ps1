# setup the Pester environment for policy tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyExemptionResourceSelector'

if(($null -eq $TestName) -or ($TestName -contains 'UpdatePolicyExemptionResourceSelector'))
{
    # Update-AzPolicyExemption reads the existing exemption, merges the bound parameters into
    # it and writes the result back with New-AzPolicyExemption. The service clears resource
    # selectors that are omitted from that write, so the cmdlet has to carry them over.
    # These tests dot-source the custom cmdlet and mock both calls so the merge logic is exercised
    # without any HTTP traffic. They therefore pass in playback with no recording.
    . (Join-Path $PSScriptRoot '..\custom\Helpers.ps1')
    . (Join-Path $PSScriptRoot '..\custom\Update-AzPolicyExemption.ps1')

    function Get-AzPolicyExemption {
        [CmdletBinding()]
        param([string]$Id, $DefaultProfile, $Break, $HttpPipelineAppend, $HttpPipelinePrepend, $Proxy, $ProxyCredential, $ProxyUseDefaultCredentials)
    }

    function New-AzPolicyExemption {
        [CmdletBinding()]
        param(
            $ResourceSelector,
            [string]$Name, [string]$Scope, $PolicyAssignment, [string]$ExemptionCategory, $ExpiresOn, [string]$DisplayName,
            [string]$Description, $PolicyDefinitionReferenceId, $Metadata, $AssignmentScopeValidation,
            $DefaultProfile, $Break, $HttpPipelineAppend, $HttpPipelinePrepend, $Proxy, $ProxyCredential, $ProxyUseDefaultCredentials
        )
    }
}

Describe 'UpdatePolicyExemptionResourceSelector' {

    $exemptionId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/policyExemptions/$someName"
    $existingResourceSelector = @(@{ Name = 'existingSelector'; Selector = @(@{ Kind = 'resourceLocation'; In = @($env.location) }) })

    function New-ExistingExemption([switch]$Empty) {
        $existing = [pscustomobject]@{
            Id                 = $exemptionId
            PolicyAssignmentId = "/subscriptions/$subscriptionId/providers/Microsoft.Authorization/policyAssignments/$someName"
            ExemptionCategory  = 'Waiver'
            DisplayName        = 'existing display name'
            ResourceSelector   = $null
        }

        # assigned separately so single-element arrays aren't unrolled
        if (!$Empty) {
            $existing.ResourceSelector = $existingResourceSelector
        }

        $existing
    }

    It 'Keeps the existing resource selectors when they are not specified' {
        Mock Get-AzPolicyExemption { New-ExistingExemption }
        Mock New-AzPolicyExemption { }

        Update-AzPolicyExemption -Id $exemptionId -DisplayName 'new display name'

        Assert-MockCalled New-AzPolicyExemption -Scope It -Times 1 -Exactly -ParameterFilter {
            $ResourceSelector[0].Name -eq 'existingSelector' -and $DisplayName -eq 'new display name'
        }
    }

    It 'Uses -ResourceSelector over the existing value' {
        Mock Get-AzPolicyExemption { New-ExistingExemption }
        Mock New-AzPolicyExemption { }

        Update-AzPolicyExemption -Id $exemptionId `
            -ResourceSelector @(@{ Name = 'newSelector'; Selector = @(@{ Kind = 'resourceLocation'; In = @($env.location) }) })

        Assert-MockCalled New-AzPolicyExemption -Scope It -Times 1 -Exactly -ParameterFilter {
            @($ResourceSelector).Count -eq 1 -and $ResourceSelector[0].Name -eq 'newSelector'
        }
    }

    It 'Clears the resource selectors when an empty collection is specified' {
        Mock Get-AzPolicyExemption { New-ExistingExemption }
        Mock New-AzPolicyExemption { }

        Update-AzPolicyExemption -Id $exemptionId -ResourceSelector @()

        Assert-MockCalled New-AzPolicyExemption -Scope It -Times 1 -Exactly -ParameterFilter {
            $null -ne $ResourceSelector -and @($ResourceSelector).Count -eq 0
        }
    }

    It 'Omits resource selectors when neither the existing exemption nor the parameter has any' {
        Mock Get-AzPolicyExemption { New-ExistingExemption -Empty }
        Mock New-AzPolicyExemption { }

        Update-AzPolicyExemption -Id $exemptionId -DisplayName 'new display name'

        Assert-MockCalled New-AzPolicyExemption -Scope It -Times 1 -Exactly -ParameterFilter {
            $null -eq $ResourceSelector
        }
    }
}
