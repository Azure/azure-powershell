if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzChaosWorkspaceScenarioEvaluation'))
{
  # Porcelain workflow cmdlet. The test dot-sources the custom cmdlet and mocks the
  # refresh-recommendations plumbing cmdlet, so it passes in playback with no recording.
  . (Join-Path $PSScriptRoot '..\custom\Invoke-AzChaosWorkspaceScenarioEvaluation.ps1')

  function Update-AzChaosWorkspaceRecommendation {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$SubscriptionId, $DefaultProfile, [switch]$NoWait)
    $script:updateCallCount++
    $script:updateBoundParameters = @{} + $MyInvocation.BoundParameters
    $true
  }
}

Describe 'Invoke-AzChaosWorkspaceScenarioEvaluation' {
    BeforeEach {
        $script:updateBoundParameters = $null
        $script:updateCallCount = 0
    }

    It 'evaluates the workspace over the refresh-recommendations cmdlet' {
        Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws

        $script:updateCallCount | Should -Be 1
        $script:updateBoundParameters['WorkspaceName'] | Should -Be 'ws'
        $script:updateBoundParameters.ContainsKey('NoWait') | Should -Be $false
    }

    It 'forwards -NoWait to the plumbing cmdlet' {
        Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws -NoWait

        $script:updateCallCount | Should -Be 1
        $script:updateBoundParameters.ContainsKey('NoWait') | Should -Be $true
    }

    It 'does not mutate under -WhatIf' {
        Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws -WhatIf

        $script:updateCallCount | Should -Be 0
    }
}
