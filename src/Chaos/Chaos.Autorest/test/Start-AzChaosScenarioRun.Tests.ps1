if(($null -eq $TestName) -or ($TestName -contains 'Start-AzChaosScenarioRun'))
{
  # Porcelain workflow cmdlets orchestrate the exported plumbing cmdlets. These tests
  # dot-source the custom cmdlet and mock the plumbing cmdlets so the workflow logic is
  # exercised without any HTTP traffic. They therefore pass in playback with no recording.
  . (Join-Path $PSScriptRoot '..\custom\Start-AzChaosScenarioRun.ps1')

  function Test-AzChaosScenarioConfiguration {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$ScenarioName, [string]$Name, [string]$SubscriptionId, $DefaultProfile, [switch]$PassThru)
  }
  function Get-AzChaosScenario {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$Name, [string]$SubscriptionId, $DefaultProfile)
  }
  function Invoke-AzChaosScenarioConfigurationExecution {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$ScenarioName, [string]$ScenarioConfigurationName, [string]$SubscriptionId, $DefaultProfile, [switch]$NoWait)
  }
}

Describe 'Start-AzChaosScenarioRun' {
    $customScenario = [pscustomobject]@{ CreatedFrom = ''; RecommendationStatus = '' }
    $evaluatedCatalog = [pscustomobject]@{ CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'Recommended' }
    $unevaluatedCatalog = [pscustomobject]@{ CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'NotEvaluated' }

    It 'validates first, then executes when validation succeeds' {
        Mock Test-AzChaosScenarioConfiguration { $true }
        Mock Get-AzChaosScenario { $customScenario }
        Mock Invoke-AzChaosScenarioConfigurationExecution { $true }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg

        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly -ParameterFilter { $Name -eq 'cfg' }
        Assert-MockCalled Invoke-AzChaosScenarioConfigurationExecution -Scope It -Times 1 -Exactly -ParameterFilter { $ScenarioConfigurationName -eq 'cfg' }
    }

    It 'does not execute when validation fails' {
        Mock Test-AzChaosScenarioConfiguration { $false }
        Mock Get-AzChaosScenario { $customScenario }
        Mock Invoke-AzChaosScenarioConfigurationExecution { $true }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $startError | Should -Not -BeNullOrEmpty
        Assert-MockCalled Invoke-AzChaosScenarioConfigurationExecution -Scope It -Times 0 -Exactly
    }

    It 'skips validation with -SkipValidation' {
        Mock Test-AzChaosScenarioConfiguration { $true }
        Mock Get-AzChaosScenario { $customScenario }
        Mock Invoke-AzChaosScenarioConfigurationExecution { $true }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -SkipValidation

        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 0 -Exactly
        Assert-MockCalled Invoke-AzChaosScenarioConfigurationExecution -Scope It -Times 1 -Exactly
    }

    It 'runs a catalog scenario once the workspace is evaluated' {
        Mock Test-AzChaosScenarioConfiguration { $true }
        Mock Get-AzChaosScenario { $evaluatedCatalog }
        Mock Invoke-AzChaosScenarioConfigurationExecution { $true }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg

        Assert-MockCalled Invoke-AzChaosScenarioConfigurationExecution -Scope It -Times 1 -Exactly
    }

    It 'fails with a friendly error for an unevaluated catalog scenario and does not evaluate or execute' {
        Mock Test-AzChaosScenarioConfiguration { $true }
        Mock Get-AzChaosScenario { $unevaluatedCatalog }
        Mock Invoke-AzChaosScenarioConfigurationExecution { $true }

        { Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction Stop } |
            Should -Throw 'catalog scenario'

        Assert-MockCalled Invoke-AzChaosScenarioConfigurationExecution -Scope It -Times 0 -Exactly
    }

    It 'does not mutate under -WhatIf' {
        Mock Test-AzChaosScenarioConfiguration { $true }
        Mock Get-AzChaosScenario { $customScenario }
        Mock Invoke-AzChaosScenarioConfigurationExecution { $true }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -WhatIf

        Assert-MockCalled Invoke-AzChaosScenarioConfigurationExecution -Scope It -Times 0 -Exactly
    }
}
