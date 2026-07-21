if(($null -eq $TestName) -or ($TestName -contains 'Initialize-AzChaosWorkspace'))
{
  # Porcelain workflow cmdlet. The test dot-sources the custom cmdlet and mocks the
  # plumbing and Az.Resources cmdlets it orchestrates, so it passes in playback with no
  # recording.
  . (Join-Path $PSScriptRoot '..\custom\Initialize-AzChaosWorkspace.ps1')

  function Get-AzResourceGroup { [CmdletBinding()] param([string]$Name) }
  function New-AzResourceGroup { [CmdletBinding()] param([string]$Name, [string]$Location) }
  function New-AzChaosWorkspace {
    [CmdletBinding()]
    param([string]$Name, [string]$ResourceGroupName, [string]$Location, [string[]]$Scope, [switch]$EnableSystemAssignedIdentity, [hashtable]$Tag, [string]$SubscriptionId, $DefaultProfile)
  }
  function New-AzRoleAssignment { [CmdletBinding()] param([string]$ObjectId, [string]$RoleDefinitionName, [string]$Scope) }
  function Invoke-AzChaosWorkspaceScenarioEvaluation {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$SubscriptionId, $DefaultProfile, [switch]$NoWait)
  }
  function Get-AzChaosScenario {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$Name, [string]$SubscriptionId, $DefaultProfile)
  }
}

Describe 'Initialize-AzChaosWorkspace' {
    $scope = '/subscriptions/00000000-0000-0000-0000-000000000000'
    $workspaceWithIdentity = [pscustomobject]@{ Name = 'ws'; IdentityPrincipalId = '11111111-1111-1111-1111-111111111111' }

    BeforeEach {
        Mock New-AzResourceGroup { }
        Mock New-AzChaosWorkspace { $workspaceWithIdentity }
        Mock New-AzRoleAssignment { }
        Mock Invoke-AzChaosWorkspaceScenarioEvaluation { $true }
        Mock Get-AzChaosScenario { @([pscustomobject]@{ Name = 'sc' }) }
    }

    It 'runs the five setup steps' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        Assert-MockCalled New-AzResourceGroup -Scope It -Times 1 -Exactly
        Assert-MockCalled New-AzChaosWorkspace -Scope It -Times 1 -Exactly -ParameterFilter { $EnableSystemAssignedIdentity.IsPresent }
        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 1 -Exactly -ParameterFilter { $Scope -eq '/subscriptions/00000000-0000-0000-0000-000000000000' -and $RoleDefinitionName -eq 'Reader' }
        Assert-MockCalled Invoke-AzChaosWorkspaceScenarioEvaluation -Scope It -Times 1 -Exactly
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 1 -Exactly
    }

    It 'does not create the resource group when it already exists' {
        Mock Get-AzResourceGroup { [pscustomobject]@{ ResourceGroupName = 'rg' } }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        Assert-MockCalled New-AzResourceGroup -Scope It -Times 0 -Exactly
    }

    It 'skips the RBAC grant with -SkipPermission' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipPermission | Out-Null

        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 0 -Exactly
    }

    It 'grants the role on each scope' {
        Mock Get-AzResourceGroup { $null }
        $scopes = @('/subscriptions/00000000-0000-0000-0000-000000000000', '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg2')

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scopes | Out-Null

        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 2 -Exactly
    }

    It 'runs a single evaluation attempt with -SkipEvaluationWait' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipEvaluationWait | Out-Null

        Assert-MockCalled Invoke-AzChaosWorkspaceScenarioEvaluation -Scope It -Times 1 -Exactly -ParameterFilter { [bool]$NoWait }
    }

    It 'waits for the evaluation by default' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        Assert-MockCalled Invoke-AzChaosWorkspaceScenarioEvaluation -Scope It -Times 1 -Exactly -ParameterFilter { -not ([bool]$NoWait) }
    }

    It 'does not mutate under -WhatIf' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -WhatIf | Out-Null

        Assert-MockCalled New-AzChaosWorkspace -Scope It -Times 0 -Exactly
        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 0 -Exactly
        Assert-MockCalled Invoke-AzChaosWorkspaceScenarioEvaluation -Scope It -Times 0 -Exactly
    }
}
