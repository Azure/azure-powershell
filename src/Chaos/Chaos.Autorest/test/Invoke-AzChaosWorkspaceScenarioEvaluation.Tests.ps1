if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzChaosWorkspaceScenarioEvaluation'))
{
  # Porcelain workflow cmdlet. The test dot-sources the custom cmdlet and mocks the
  # refresh-recommendations plumbing cmdlet, so it passes in playback with no recording.
  . (Join-Path $PSScriptRoot '..\custom\Invoke-AzChaosWorkspaceScenarioEvaluation.ps1')

  function Update-AzChaosWorkspaceRecommendation {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$SubscriptionId, $DefaultProfile, [switch]$NoWait)
  }
}

Describe 'Invoke-AzChaosWorkspaceScenarioEvaluation' {
    It 'evaluates the workspace over the refresh-recommendations cmdlet' {
        Mock Update-AzChaosWorkspaceRecommendation { $true }

        Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws

        Assert-MockCalled Update-AzChaosWorkspaceRecommendation -Scope It -Times 1 -Exactly -ParameterFilter { $WorkspaceName -eq 'ws' }
    }

    It 'forwards -NoWait to the plumbing cmdlet' {
        Mock Update-AzChaosWorkspaceRecommendation { $true }

        Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws -NoWait

        Assert-MockCalled Update-AzChaosWorkspaceRecommendation -Scope It -Times 1 -Exactly -ParameterFilter { [bool]$NoWait }
    }

    It 'does not mutate under -WhatIf' {
        Mock Update-AzChaosWorkspaceRecommendation { $true }

        Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws -WhatIf

        Assert-MockCalled Update-AzChaosWorkspaceRecommendation -Scope It -Times 0 -Exactly
    }
}
